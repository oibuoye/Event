using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Event.Core.Logger.Contracts;

namespace Event.Core.Logger
{
    public class FileLogger : IFileLogger
    {
        [Obsolete]
        private readonly IHostingEnvironment _host;

        [Obsolete]
        public FileLogger(IHostingEnvironment host)
        {
            _host = host;
        }

        public void Debug(string message)
        {
            string filePath = _host.ContentRootPath + $@"\Logs\{DateTime.Now.ToString("yyyy-MM-dd")}-debug.log";

            using (var sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")}:::DEBUG::{message}");
            }
        }

        public void Debug(string message, Exception exception)
        {
            string filePath = _host.ContentRootPath + $@"\Logs\{DateTime.Now.ToString("yyyy-MM-dd")}-debug.log";

            using (var sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")}:::DEBUG::{message}  {exception.Message + exception.StackTrace + exception.InnerException}");
            }
        }

        public void Error(string message)
        {
            string filePath = _host.ContentRootPath + $@"\Logs\{DateTime.Now.ToString("yyyy-MM-dd")}-debug.log";

            using (var sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")}:::ERROR::{message}");
            }
        }

        public void Error(string message, Exception exception)
        {
            string filePath = _host.ContentRootPath + $@"\Logs\{DateTime.Now.ToString("yyyy-MM-dd")}-debug.log";

            using (var sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")}:::ERROR::{message}  {exception.Message} {exception}");
            }
        }

        public void Fatal(string message)
        {
            string filePath = _host.ContentRootPath + $@"\Logs\{DateTime.Now.ToString("yyyy-MM-dd")}-debug.log";

            using (var sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")}:::FATAL::{message}");
            }
        }

        public void Fatal(string message, Exception exception)
        {
            string filePath = _host.ContentRootPath + $@"\Logs\{DateTime.Now.ToString("yyyy-MM-dd")}-debug.log";

            using (var sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")}:::FATAL::{message}  {exception.Message + exception.StackTrace + exception.InnerException}");
            }
        }

        public void Info(string message, Exception exception)
        {
            string filePath = _host.ContentRootPath + $@"\Logs\{DateTime.Now.ToString("yyyy-MM-dd")}-debug.log";

            using (var sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")}:::INFO::{message}  {exception.Message + exception.StackTrace + exception.InnerException}");
            }
        }

        public void Info(string message)
        {
            string filePath = _host.ContentRootPath + $@"\Logs\{DateTime.Now.ToString("yyyy-MM-dd")}-debug.log";

            using (var sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")}:::INFO::{message}");
            }
        }

        public void Warn(string message)
        {
            string filePath = _host.ContentRootPath + $@"\Logs\{DateTime.Now.ToString("yyyy-MM-dd")}-update.log";

            using (var sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")}:::UPDATE::{message}");
            }
        }

        public void Warn(string message, Exception exception)
        {
            string filePath = _host.ContentRootPath + $@"\Logs\{DateTime.Now.ToString("yyyy-MM-dd")}-update.log";

            using (var sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss")}:::UPDATE::{message}  {exception.Message + exception.StackTrace + exception.InnerException}");
            }
        }

    }
}
