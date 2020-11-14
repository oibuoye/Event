﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Core.Logger.Contracts
{
    public interface IFileLogger
    {
        void Debug(string message);

        void Debug(string message, Exception exception);

        void Error(string message);

        void Error(string message, Exception exception);

        void Fatal(string message);

        void Fatal(string message, Exception exception);

        void Info(string message, Exception exception);

        void Info(string message);

        void Warn(string message);

        void Warn(string message, Exception exception);
    }
}
