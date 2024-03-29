﻿namespace WebApp.Constant
{
    public class DisplayConstant
    {
        #region Errors
        public const string ERROR_ALREADY_APPLIED = "You already applied this Cv to this Job!";
        public const string ERROR = "ERROR!";
        public const string ERROR_BADREQUEST = "Null object or unvalidated field!";
        public const string ERROR_UNAUTHENTICATED = "YOU MAY NOT LOGGED IN!";
        public const string ERROR_LOADFAIL = "Fail to load DataSet";
        public const string ERROR_CREATED = "Failed creation";
        public const string ERROR_REMOVED = "Failed delete";
        public const string ERROR_INSTANCE_NOT_FOUND = "Instance non-existent";
        public const string ERROR_INSTANCE_EXISTED = "Instance already existed";
        public const string ERROR_PASSWORD_REQUIRED = "Please input password";
        public const string ERROR_USERNAME_REQUIRED = "Please input Username";
        public const string ERROR_PASSWORD_VALIDATE = "Password have at least 8 characters contains at least one numeric, one alpharic, one special character";
        #endregion
        #region Success
        public const string SUCCESS_CREATED = "Success Created!";
        public const string SUCCESS_REMOVED = "Success Removed!";
        public const string SUCCESS = "Success!";
        #endregion
        #region ImageDefaultPath
        public const string USER_IMG_DEFAULT_PATH = "";
        public const string JOB_IMG_DEFAULT_PATH = "";
        #endregion
    }
}
