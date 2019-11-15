using VanChi.FMS.Web.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VanChi.Business.Common;

namespace VanChi.FMS.Web.Models
{
    public class VefifyAccountModel
    {
        public Guid CustomerId { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public string Hotline { get; set; }
        public string Code { get; set; }
    }
    public class VefifyOTPModel
    {
        public Guid CustomerId { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Code { get; set; }
        [Required]
        [ExDisplay(typeof(VefifyOTPModel), "CMS Token", "Mã OTP của bạn")]
        public string OTP { get; set; }   
        public DateTime ExpiryDate { get; set; } 
        public int countTime { get; set; }
        public OTPViewModel OTPViewModel { get; set; }       
        public VefifyOTPModel()
        {
            this.countTime = CommonFunc.DEFAULT_TIME_OTP;
        }
       
    }
    public class CustomerModel : BaseImageModel
    {
        [ExDisplay(typeof(CustomerModel),"Code", "Mã công ty", "Customer ID")]
        public string Code { get; set; }
        [Required]
        [ExDisplay(typeof(CustomerModel), "Name", "Tên tổ chức", "Organization Name")]
        public string Name { get; set; }
        [Required]
        [ExDisplay(typeof(CustomerModel), "International", "Tên quốc tế", "International Name")]
        public string International { get; set; }
        public string ShortName { get; set; }
        [Required]
        [ExDisplay(typeof(CustomerModel), "Address", "Địa chỉ", "Address")]
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        [Required]
        [ExDisplay(typeof(CustomerModel), "HotLine","Số điện thoại", "Phone")]
        [DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/im", ErrorMessage = "Not a valid phone number")]
        [RegularExpression(@"^\(?\+?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4,6})$", ErrorMessage = "Not a valid phone number")]
        public string Hotline { get; set; }
        [Required]
        [ExDisplay(typeof(CustomerModel), "Email","Email", "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required]
        [ExDisplay(typeof(CustomerModel), "TaxCode","Tax Code", "Tax Code")]
        public string TaxCode { get; set; }
        [ExDisplay(typeof(CustomerModel), "Owner", "Chủ sở hữu","Owner")]
        public string Owner { get; set; }
        [ExDisplay(typeof(CustomerModel), "Author", "Author", "Người đại diện")]
        public string Author { get; set; }
        [ExDisplay(typeof(CustomerModel), "IsCash", "Cash Customer", "Cash Customer")]
        public Nullable<bool> IsCash { get; set; }
        [ExDisplay(typeof(CustomerModel), "IsFixDeposit", "Fix Deposit", "Fix Deposit")]
        public Nullable<bool> IsFixDeposit { get; set; }
        [ExDisplay(typeof(CustomerModel), "Status", "Trạng thái","Status")]
        public byte Status { get; set; }
        public string ActionType { get; set; }
        [Required]
        [ExDisplay(typeof(CustomerModel), "OfficalLetter","Offical Letter", "Offical Letter")]
        public string OfficialLetter { get; set; }
        [ExDisplay(typeof(CustomerModel), "Comment","Nhận xét", "Comment")]
        public string Comment { get; set; }
        public string FileAttach { get; set; }
        public string TypeEdit { get; set; }
        public string CustomerFiles { get; set; }
        public string CAPTCHA { get; set; }
        public string DisplayCode
        {
            get
            {
                return (Code == null) ? string.Empty : Code;
            }
        }
        public CustomerModel() : base()
        {
            this.Code = string.Empty;
            this.Name = string.Empty;
            this.International = string.Empty;
            this.ShortName = string.Empty;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.Fax = string.Empty;
            this.Hotline = string.Empty;
            this.Email = string.Empty;
            this.TaxCode = string.Empty;
            this.Owner = string.Empty;
            this.Author = string.Empty;
            this.IsCash = false;
            this.IsFixDeposit = false;
            this.Status = 0;
            this.Comment = string.Empty;
            this.TypeEdit = string.Empty;
            this.OfficialLetter = string.Empty;
            this.FileAttach = string.Empty;
            this.CustomerFiles = string.Empty;
            this.Status = (byte)VanChi.Business.Common.CustomerStatus.Pending;
        }
        public string DisplayStatus
        {
            get
            {
                if (Status == (byte)CustomerStatus.Pending)
                {
                    return string.Format(@"<span class='label label-sm label-warning'>{0}</span>", ResourceManagement.GetResourceText("SystemResourceID.Pending", "Gửi phê chuẩn", "Pending"));
                }
                else if (Status == (byte)CustomerStatus.Approved)
                {
                    return string.Format(@"<span class='label label-sm label-success'>{0}</span>", ResourceManagement.GetResourceText("SystemResourceID.Approved", "Đã duyệt", "Approved"));
                }
                else if (Status == (byte)CustomerStatus.Actived)
                {
                    return string.Format(@"<span class='label label-sm label-primary'>{0}</span>", ResourceManagement.GetResourceText("SystemResourceID.Actived", "Hoạt động", "Actived"));
                }
                else
                {
                    return string.Format(@"<span class='label label-sm label-danger'>{0}</span>", ResourceManagement.GetResourceText("SystemResourceID.Rejected", "Từ chối", "Rejected"));
                }
            }
        }
        public string DisplayIsCash
        {
            get
            {
                if (IsCash == true)
                {
                    return string.Format(@"<span class='label label-sm label-primary'>{0}</span>", ResourceManagement.GetResourceText("SystemResourceID.Yes", "Có", "Yes"));
                }
                else
                {
                    return string.Format(@"<span class='label label-sm label-success'>{0}</span>", ResourceManagement.GetResourceText("SystemResourceID.No", "Không ", "No"));
                }
            }
        }
        public string DisplayIsFixDeposit
        {
            get
            {
                if (IsFixDeposit == true)
                {
                    return string.Format(@"<span class='label label-sm label-primary'>{0}</span>", ResourceManagement.GetResourceText("SystemResourceID.Yes", "Có", "Yes"));
                }
                else 
                {
                    return string.Format(@"<span class='label label-sm label-success'>{0}</span>", ResourceManagement.GetResourceText("SystemResourceID.No", "Không ", "No"));
                }
            }
        }
    }

    public class CustomerLogModel : BaseModel
    {
        public Guid CustomerId { get; set; }
        public LogType LogType { get; set; }
        public string Name { get; set; }
        public virtual CustomerModel Customer { get; set; }
        public CustomerLogModel() : base() {
            this.LogType = LogType.Comment;
            this.Name = string.Empty;
            this.CustomerId = Guid.Empty;
            this.Description = String.Empty;
        }
    }
    public class CustomerFileModel : BaseModel
    {
        public System.Guid CustomerId { get; set; }
        public string Name { get; set; }
        public byte[] FileAttach { get; set; }
        public string FileExt { get; set; }
        public string FileSize { get; set; }
        public int FileOrder { get; set; }
        public virtual CustomerModel Customer { get; set; }
        public CustomerFileModel() : base()
        {
            this.CustomerId = Guid.Empty;
            this.Name = String.Empty;
            this.FileExt = String.Empty;
            this.FileAttach = null;
            this.FileSize = String.Empty;
            this.FileOrder = 0;
        }
    }

    public class CustomerQAModel : BaseModel
    {
        public System.Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public virtual CustomerModel Customer { get; set; }
        public CustomerQAModel()
            : base()
        {
            this.CustomerId = Guid.Empty;
            this.Name = String.Empty;
            this.Value = String.Empty;
        }
    }
    public class CustomerTokenModel : BaseModel
    {
        public System.Guid CustomerId { get; set; }
        public string Value { get; set; }
        public byte TokenType { get; set; }
        public System.DateTime ExpiryDate { get; set; }
        public virtual CustomerModel Customer { get; set; }
        public CustomerTokenModel()
            : base()
        {
            this.CustomerId = Guid.Empty;
            this.Value = String.Empty;
            this.TokenType = 0;
            this.ExpiryDate = DateTime.Now;
        }
    }

    public class CusomerFilePath : BaseModel
    {
        public Guid CustomerId { get; set; }
    }

    public class QAModel
    {
        public Guid CustomerId { get; set; }
        public string UserName { get; set; }
        public string Code { get; set; }
        [Required]
        [ExDisplay(typeof(QAModel), "Password", "Mật khẩu")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }
      
        [DataType(DataType.Password)]
        [ExDisplay(typeof(QAModel), "Confirm password", "Nhập lại mật khẩu")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [ExDisplay(typeof(QAModel), "Security question 1", "Câu hỏi 1")]
        public string Question1 { get; set; }
        [Required]
        [ExDisplay(typeof(QAModel), "Answer", "Câu trả lời")]
        public string Answer1 { get; set; }
        [Required]
        [ExDisplay(typeof(QAModel), "Security question 2", "Câu hỏi 2")]
        public string Question2 { get; set; }
        [Required]
        [ExDisplay(typeof(QAModel), "Answer", "Câu trả lời")]
        public string Answer2 { get; set; }
        [Required]
        [ExDisplay(typeof(QAModel), "Security question 3", "Câu hỏi 3")]
        public string Question3 { get; set; }
        [Required]
        [ExDisplay(typeof(QAModel), "Answer", "Câu trả lời")]
        public string Answer3 { get; set; }
    }

    public class ChangPasswordModel
    {
        public Guid CustomerId { get; set; }
        public string UserName { get; set; }
               
        [ExDisplay(typeof(ChangPasswordModel), "Old Password", "Mật khẩu cũ")]
        public string OldPassword { get; set; }
        [Required]
        [ExDisplay(typeof(ChangPasswordModel), "New Password", "Mật khẩu mới")]
        public string NewPassword { get; set; }
        [Required]
        [ExDisplay(typeof(ChangPasswordModel), "Confirm New Password", "Nhập lại mật khẩu")]
        public string ConfirmPawword { get; set; }
       
        [ExDisplay(typeof(ChangPasswordModel), "Change Sercurity Question?", "Thay đổi câu hỏi bảo mật?")]
        public bool IsQA { get; set; }
        public string Hotline { get; set; }
        [ExDisplay(typeof(ChangPasswordModel), "SMS Token", "Mã OTP xác nhận")]
        public string OTP { get; set; }
        public QAMoreModel QADto { get; set; }

        public PasswordViewModel PasswordView { get; set; }
        public bool IsCustomer { get; set; }
        public string TemplateURL { get; set; }
        public string Code { get; set; }
        public ChangPasswordModel()
        {
            this.QADto = new QAMoreModel();
            this.IsQA = false;
            this.PasswordView = PasswordViewModel.Change;
            this.TemplateURL = BaseViewURL.BaseSharedURL("ForgotOrChangePassword");
        }
    }

    public class QAMoreModel
    {
        public Guid QAId1 { get; set; }
        public Guid QAId2 { get; set; }
        public Guid QAId3 { get; set; }
        public Guid CustomerId { get; set; }
        
        [ExDisplay(typeof(QAMoreModel), "Security question 1", "Câu hỏi 1")]
        public string Question1 { get; set; }
      
        [ExDisplay(typeof(QAMoreModel), "Answer", "Câu trả lời")]
        public string Answer1 { get; set; }
        
        [ExDisplay(typeof(QAMoreModel), "Security question 2", "Câu hỏi 2")]
        public string Question2 { get; set; }
      
        [ExDisplay(typeof(QAMoreModel), "Answer", "Câu trả lời")]
        public string Answer2 { get; set; }
      
        [ExDisplay(typeof(QAMoreModel), "Security question 3", "Câu hỏi 3")]
        public string Question3 { get; set; }
     
        [ExDisplay(typeof(QAMoreModel), "Answer", "Câu trả lời")]
        public string Answer3 { get; set; }
    }

    public class CustomerDecryptModel
    {
        public string UserName { get; set; }
        public Guid CustomerId { get; set; }
        public string TokenSMS { get; set; }
    }
}