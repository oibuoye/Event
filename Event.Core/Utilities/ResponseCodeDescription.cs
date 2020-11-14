using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Core.Utilities
{
    public static class ResponseCodeDescription
    {
        public static string Request_Successful(string message = null)
        {
            if (string.IsNullOrEmpty(message)) { return $"Created Successfully"; }
            return message;
        }

        public static string General_Exception(string message = null)
        {
            if (string.IsNullOrEmpty(message)) { return $"Error occurred, please contact the administrator"; }
            return message;
        }

        public static string Account_Locked(string message = null)
        {
            if (string.IsNullOrEmpty(message)) { return $"User account locked out"; }
            return message;
        }

        public static string Account_Unverified(string message = null)
        {
            if (string.IsNullOrEmpty(message)) { return $"User account has not been verified, email containing token has been sent to the user."; }
            return message;
        }

        public static string Invalid_Login(string message = null)
        {
            if (string.IsNullOrEmpty(message)) { return $"Invalid login attempt"; }
            return message;
        }

        public static string Bad_Model(string message = null)
        {
            if (string.IsNullOrEmpty(message)) { return $"Bad model"; }
            return message;
        }

        public static string Record_Already_Exist(string message = null)
        {
            if (string.IsNullOrEmpty(message)) { return $"Record already exist"; }
            return message;
        }

        public static string No_Record_Found(string message = null)
        {
            if (string.IsNullOrEmpty(message)) { return $"Record not found"; }
            return message;
        }

        public static string Password_Error(string message = null)
        {
            if (string.IsNullOrEmpty(message)) { return $"There is an issue with the password"; }
            return message;
        }

        public static string Token_Has_Expired(string message = null)
        {
            if (string.IsNullOrEmpty(message)) { return $"Code has expired, new one has been sent to your email"; }
            return message;
        }
    }
}
