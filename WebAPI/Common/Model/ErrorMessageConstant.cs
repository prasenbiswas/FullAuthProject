using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Common.Model
{
    public static class ErrorMessageConstant
    {
        public const string PleaseEnterValidEmailPassword = "Please enter a valid Email/Password.";
        public const string PleaseEnterValidInput = "Please enter valid input.";
        public const string EmailAllreadyExist = "Email allready exist.";
        public const string IncorrectCurrentPassword = "Incorrect current password.";
        public const string PleaseEnterCorrectEmail = "Please enter your correct email.";

        //Sucess Constant Message
        public const string RegisteredSuccefully = "Registered succefully.";
        public const string PasswordChangedSuccesfully = "Password changed succesfully.";
        public const string LogoutSuccessfully = "Logout succesfully.";

    }
}
