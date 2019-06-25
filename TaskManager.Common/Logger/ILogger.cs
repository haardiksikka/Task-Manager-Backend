using System;

namespace TaskManager.Common.Logger
{
    public interface ILogger
    {
        void Error(string message, Exception ex);
        void Info(string message);
    }
}