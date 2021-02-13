using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Infrastructure
{
    public class ApplicationStatusCode
    {
        public static string Successful { get; set; } = "00";
        public static string BadRequest { get; set; } = "01";
        public static string Pending { get; set; } = "02";
        public static string InvalidIssuer { get; set; } = "03";
        public static string TokenExpired { get; set; } = "04";
        public static string ModelValidation { get; set; } = "05";
        public static string AlreadyExist { get; set; } = "06";
        public static string NotFound { get; set; } = "07";
        public static string NotActive { get; set; } = "08";
        public static string InvalidToken { get; set; } = "09";
        public static string VerificationCode { get; set; } = "11";
        public static string PasswordError { get; set; } = "12";
        public static string SessionExpired { get; set; } = "13";
        public static string InvalidOperation { get; set; } = "14";
        public static string LoginOperation { get; set; } = "15";
        public static string GenericError { get; set; } = "16";
        public static string UnkownStatus { get; set; } = "17";
        public static string SystemError { get; set; } = "18";
        public static string Failed { get; set; } = "19";

        public static string GetResponseCode(string code)
        {
            switch (code)
            {
                case "00":
                    return "Successful";
                case "01":
                    return "BadRequest";
                case "02":
                    return "Pending";
                case "03":
                    return "InvalidIssuer";
                case "04":
                    return "TokenExpired";
                case "05":
                    return "ModelValidation";
                case "06":
                    return "AlreadyExist";
                case "07":
                    return "NotFound";
                case "08":
                    return "NotActive";
                case "09":
                    return "InvalidToken";
                case "11":
                    return "VerificationCode";
                case "12":
                    return "PasswordError";
                case "13":
                    return "SessionExpired";
                case "14":
                    return "InvalidOperation";
                case "15":
                    return "LoginOperation";
                case "16":
                    return "GenericError";
                case "17":
                    return "UnkownStatus";
                case "18":
                    return "SystemError";
                case "19":
                    return "Failed";
                default:
                    return "UnkownStatus";
            }

        }
        //
    }
}
