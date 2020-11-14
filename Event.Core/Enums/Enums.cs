using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Event.Core.Enums
{
    public enum ContactTypeEnum
    {
        [Description("Primary")]
        Primary = 1,

        [Description("Secondary")]
        Secondary = 2,

        [Description("Tertiary")]
        Tertiary = 3,
    }

    public enum TestResult
    {
        [Description("Pending")]
        Pending = 1,

        [Description("Negative")]
        Negative = 2,

        [Description("Positive")]
        Positive = 3,

        [Description("InConclusive")]
        InConclusive = 4
    }

    public enum TreatmentStatusEnum
    {
        [Description("Pending")]
        Pending = 1,

        [Description("Negative")]
        Negative = 2,

        [Description("Active")]
        Active = 3,

        [Description("Discharged")]
        Discharged = 4,

        [Description("Death")]
        Death = 5
    }

    public enum MonthName
    {
        [Description("Jan")]
        Jan = 1,

        [Description("Feb")]
        Feb = 2,

        [Description("Mar")]
        Mar = 3,

        [Description("Apr")]
        Apr = 4,

        [Description("May")]
        May = 5,

        [Description("Jun")]
        Jun = 6,

        [Description("Jul")]
        Jul = 7,

        [Description("Aug")]
        Aug = 8,

        [Description("Sep")]
        Sep = 9,

        [Description("Oct")]
        Oct = 10,

        [Description("Nov")]
        Nov = 11,

        [Description("Dec")]
        Dec = 12

    }



    public enum UserTypeEnum
    {
        [Description("Facility Admin")]
        FacilityAdmin = 1,

        [Description("Facility User")]
        FacilityUser = 2,
    }

    public enum TestTypeEnum
    {
        [Description("Antigen")]
        FacilityAdmin = 1,

        [Description("Virus")]
        FacilityUser = 2,
    }

    public enum ErrorCode
    {
        [Description("9000")]
        General_Exception = 9000,
        [Description("1008")]
        Account_Unverified = 1008,
        [Description("1007")]
        Token_Expired = 1007,
        [Description("1006")]
        Record_Exist = 1006,
        [Description("1005")]
        Account_Locked = 1005,
        [Description("1004")]
        Invalid_Login = 1004,
        [Description("1003")]
        Bad_Model = 1003,
        [Description("1002")]
        Record_NotFound = 1002,
        [Description("1001")]
        Password_Error = 1001,
    }

    public enum ResponseCode
    {
        [Description("0000")]
        Success = 0000
    }

    public enum RegistrationStage
    {
        [Description("Awaiting Verification")]
        AwaitingVerification = 1,

        [Description("Verified")]
        Verified = 2
    }

    public static class EnumHelper
    {
        public static string ToDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

    }

}
