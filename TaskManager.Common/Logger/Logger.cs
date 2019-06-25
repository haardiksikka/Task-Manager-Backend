using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Common.Logger
{
    public class Logger : ILogger
    {
        public void Info(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

        public void Error(string message, Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(message, ex.StackTrace);
        }
    }
}
