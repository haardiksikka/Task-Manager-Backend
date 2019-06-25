using System;
using System.Collections.Generic;
using TaskManager.Common.DTO;
using DAL.Repository;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using TaskManager.Common.Logger;

namespace BLL
{
    public class UserBll : IUserBll
    {
        private readonly IUserDal _userDal;
        private readonly ILogger _iLogger;
        public UserBll(IUserDal userDal, ILogger iLogger)
        {
            _userDal = userDal;
            _iLogger = iLogger;

        }
        public UserDto RegisterUser(UserDto userDto)
        {
            try
            {
                if (_userDal.GetUserByEmail(userDto.Email) == null)
                {

                    string password = userDto.Password;
                    string salt = CreateSalt();
                    string hash = CreateHash(password, salt);

                    userDto.Password = hash;
                    userDto.Salt = salt;

                    return _userDal.RegisterUser(userDto);
                }
                else
                {
                   
                    return null;
                }
            }
            catch (Exception e)
            {
                _iLogger.Error("Exception Thrown", e);
                throw;
            }
        }

       
        public UserDto GetUserByEmail(string email, string password)
        {
            try
            {
                var user = _userDal.GetUserByEmail(email);
                if (user != null)
                {
                    string salt = user.Salt;
                    string hashedPassword = CreateHash(password, salt);
                    if (!hashedPassword.Equals(user.Password))
                    {
                        user = null;
                    }
                }
                return user;
            }
            catch (Exception ex)
            {
                _iLogger.Error("Exception Thrown", ex);
                throw;
            }
        }

        public UserDto GetUser(string email)
        {

            try
            {
                return _userDal.GetUserByEmail(email);
            }
            catch (Exception e)
            {

                _iLogger.Error("Exception Thrown", e);
                throw;
            }
        }

        public string CreateHash(string value, string salt)
        {
            var valueBytes = KeyDerivation.Pbkdf2(
                             password: value,
                             salt: System.Text.Encoding.UTF8.GetBytes(salt),
                             prf: KeyDerivationPrf.HMACSHA512,
                             iterationCount: 10000,
                             numBytesRequested: 256 / 8);

            return Convert.ToBase64String(valueBytes);
        }

        public string CreateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
        }


    }
}
