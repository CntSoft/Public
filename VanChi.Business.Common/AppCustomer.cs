using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanChi.Business.Common
{
    public enum AppCustomer
    {
        Consignee = 0,
        Notify = 1
    }   
    
    public enum LogType : byte
    {
        Comment = 0,
        SectionLogin = 1
    }
    public enum OTPViewModel : int
    {
        Active = 0,
        Change = 1,
        Forgot = 2,
        ForgotUser = 3
    }

    public enum PasswordViewModel : int
    {
        Active = 0,
        Change = 1,
        Forgot = 2,
        ForgotUser = 3
    }
    public enum CheckLoginUser
    {
        NotFoud = 0,
        NotActive = 1,
        IsCustomer = 2,
        IsUser = 3,
        Block = 4,
        Successful = 5
    }
    public sealed class CustomerView
    {
        public const string TypeEdit_Approve = "1";
        public const string TypeEdit_Active = "2";
        public const string TypeEdit_Reject = "3";

        public const string CODE_BLOCK_LOGIN_MM_FIRST = "CODE_BLOCK_LOGIN_MM_FIRST";
        public const string CODE_BLOCK_LOGIN_SECOND = "CODE_BLOCK_LOGIN_SECOND";
    }
}
