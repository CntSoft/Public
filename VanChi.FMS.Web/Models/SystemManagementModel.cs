using VanChi.Business.Common;
using VanChi.FMS.Web.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VanChi.FMS.Web.Models
{
    public class UserInfoModel
    {
        [Required]
        [ExDisplay(typeof(UserInfoModel), "User Name", "Mã người dùng")]
        public string UserName { get; set; }

        [Required]
        [ExDisplay(typeof(UserInfoModel), "Full Name", "Tên người dùng")]
        public string FullName { get; set; }

        [ExDisplay(typeof(UserInfoModel), "Role Name", "Quyền truy cập")]
        public string RoleName { get; set; }

        [Required]
        [ExDisplay(typeof(UserInfoModel), "Email", "Email")]
        public string Email { get; set; }

        [Required]
        [ExDisplay(typeof(UserInfoModel), "Password", "Mật khẩu")]
        [RegularExpression("^(?=.*[\\d])(?=.*[A-Z])(?=.*[a-z])[\\w\\d!@#$%_]{6,40}$", ErrorMessage = "Invalid password format")]
        public string Password { get; set; }

        [ExDisplay(typeof(UserInfoModel), "Confirm new password", "Nhập lại mật khẩu")]
        [Required(ErrorMessage = "Confirm Password required")]
        [Compare("Password", ErrorMessage = "Password doesn't match.")]
        public string ConfirmPassword { get; set; }

        [ExDisplay(typeof(UserInfoModel), "Mobile", "Số điện thoại")]
        public string Mobile { get; set; }

        [ExDisplay(typeof(UserInfoModel), "Picture", "Hình ảnh")]
        public byte[] Picture { get; set; }

        [ExDisplay(typeof(UserInfoModel), "Address", "Địa chỉ")]
        public string Address { get; set; }

        [ExDisplay(typeof(UserInfoModel), "HomePhone", "Điện thoại nhà")]
        public string HomePhone { get; set; }

        [ExDisplay(typeof(UserInfoModel), "Ext", "Ext")]
        public string Ext { get; set; }

        //[Required]
        [ExDisplay(typeof(UserInfoModel), "Birthday", "Ngày sinh")]
        public Nullable<System.DateTime> Birthday { get; set; }

        public Nullable<System.Guid> LanguageID { get; set; }

        [ExDisplay(typeof(UserInfoModel), "Gender", "Giới Tính")]
        public Nullable<bool> Gender { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> FirstWorkingDate { get; set; }
        public string UserCode { get; set; }
        public string UserHRIS { get; set; }
        public string Diploma { get; set; }
        public string Position { get; set; }
        public string LanguageCode { get; set; }
        public bool IsCustomer { get; set; }
        public string OrgName { get; set; }
        public string JobTitleName { get; set; }
        public string ActionType { get; set; }
        public virtual ICollection<RoleModel> Roles { get; set; }
        public bool isNewPassWord { get; set; }
        public string DisplayUserName
        {
            get { return !string.IsNullOrEmpty(UserName) ? UserName : string.Empty; }
        }
        public string DisplayFullName
        {
            get { return !string.IsNullOrEmpty(FullName) ? FullName : string.Empty; }
        }
        public string DisplayEmail
        {
            get { return !string.IsNullOrEmpty(Email) ? Email : string.Empty; }
        }
        public string DisplayMobile
        {
            get { return !string.IsNullOrEmpty(Mobile) ? Mobile : string.Empty; }
        }
        public string DisplayAddress
        {
            get { return !string.IsNullOrEmpty(Address) ? Address : string.Empty; }
        }
        public string DisplayBirthday
        {
            get
            {
                if (!string.IsNullOrEmpty(Birthday.ToString()))
                {
                    return DateTime.Parse(Birthday.ToString()).ToString(App.DatePattern);
                }
                return string.Empty;
            }
        }
        public string DisplayGender
        {
            get
            {
                if ((bool)Gender)
                {
                    return string.Format(@"<span class='label label-sm label-primary'>{0}</span>", ResourceManagement.GetResourceText("SystemResourceID.Male", "Nam", "Male"));
                }
                else
                {
                    return string.Format(@"<span class='label label-sm label-success'>{0}</span>", ResourceManagement.GetResourceText("SystemResourceID.Female", "Nữ", "Female"));
                }
            }
        }
    }
    public class ResourceModel
    {
        [Required]
        [ExDisplay(typeof(ResourceModel), "ResourceId", "Mã ngôn ngữ")]
        //[ExRemote(Constant.Action_Resource_IsUnique, Constant.Controller_SystemManagement, typeof(ResourceModel), "ResourceID", "Mã ngôn ngữ đã tồn tại", "ResourceId is exist", AdditionalFields = "ActionType")]
        public string ResourceID { get; set; }

        [Required]
        [ExDisplay(typeof(ResourceModel), "Vietnamese", "Tiếng Việt")]
        public string ResourceText0 { get; set; }
        public string DefaultText0 { get; set; }

        [ExDisplay(typeof(ResourceModel), "English", "Tiếng Anh")]
        public string ResourceText1 { get; set; }
        public string DefaultText1 { get; set; }

        [ExDisplay(typeof(ResourceModel), "French", "Tiếng Pháp")]
        public string ResourceText2 { get; set; }
        public string DefaultText2 { get; set; }

        [ExDisplay(typeof(ResourceModel), "China", "Tiếng Trung")]
        public string ResourceText3 { get; set; }
        public string DefaultText3 { get; set; }

        [ExDisplay(typeof(ResourceModel), "Japanese", "Tiếng Nhật")]
        public string ResourceText4 { get; set; }
        public string DefaultText4 { get; set; }

        [ExDisplay(typeof(ResourceModel), "Russian", "Tiếng Nga")]
        public string ResourceText5 { get; set; }
        public string DefaultText5 { get; set; }
        [ExDisplay(typeof(ResourceModel), "CreateDate", "Ngày tạo", "Create date")]
        public System.DateTime CreateDate { get; set; }
        public string DisplayResourceText0
        {
            get { return !string.IsNullOrEmpty(ResourceText0) ? ResourceText0 : string.Empty; }
        }
        public string DisplayResourceText1
        {
            get { return !string.IsNullOrEmpty(ResourceText1) ? ResourceText1 : string.Empty; }
        }
        public string DisplayResourceText2
        {
            get { return !string.IsNullOrEmpty(ResourceText2) ? ResourceText2 : string.Empty; }
        }
        public string DisplayResourceText3
        {
            get { return !string.IsNullOrEmpty(ResourceText3) ? ResourceText3 : string.Empty; }
        }
        public string DisplayResourceText4
        {
            get { return !string.IsNullOrEmpty(ResourceText4) ? ResourceText4 : string.Empty; }
        }
        public string DisplayResourceText5
        {
            get { return !string.IsNullOrEmpty(ResourceText5) ? ResourceText5 : string.Empty; }
        }
        public string DisplayCreateDate
        {
            get
            {
                if (!string.IsNullOrEmpty(CreateDate.ToString()))
                {
                    return DateTime.Parse(CreateDate.ToString()).ToString(App.DatePattern);
                }
                return string.Empty;
            }
        }
        public string ActionType { get; set; }
        public ResourceModel()
        {
            this.CreateDate = DateTime.Now;
            this.ResourceText0 = string.Empty;
            this.ResourceText1 = string.Empty;
            this.ResourceText2 = string.Empty;
            this.ResourceText3 = string.Empty;
            this.ResourceText4 = string.Empty;
            this.ResourceText5 = string.Empty;
            this.DefaultText0 = string.Empty;
            this.DefaultText1 = string.Empty;
            this.DefaultText2 = string.Empty;
            this.DefaultText3 = string.Empty;
            this.DefaultText4 = string.Empty;
            this.DefaultText5 = string.Empty;
        }
    }
    public class SystemLogModel
    {
        [Required]
        [ExDisplay(typeof(SystemLogModel), "LogId", "Mã nhật ký")]
        public System.Guid LogId { get; set; }

        [ExDisplay(typeof(SystemLogModel), "Module", "Phân hệ")]
        public string Module { get; set; }

        [ExDisplay(typeof(SystemLogModel), "UserId", "Mã người dùng")]
        public string UserId { get; set; }

        [ExDisplay(typeof(SystemLogModel), "UserFunction", "Thao tác", "Action")]
        public Nullable<int> UserFunction { get; set; }

        [ExDisplay(typeof(SystemLogModel), "EventResult", "Kết quả", "Result")]
        public Nullable<int> EventResult { get; set; }

        [ExDisplay(typeof(SystemLogModel), "FuncDateTime", "Thời gian", "Datetime")]
        public Nullable<System.DateTime> FuncDateTime { get; set; }

        [ExDisplay(typeof(SystemLogModel), "Source", "Phương thức", "Method")]
        public string Source { get; set; }

        [ExDisplay(typeof(SystemLogModel), "Transdata", "Dữ liệu", "Data")]
        public string Transdata { get; set; }

        [ExDisplay(typeof(SystemLogModel), "WSName", "Địa chỉ", "Address")]
        public string WSName { get; set; }
        public string DisplayModule
        {
            get
            {
                if (Module == AppModule.SystemManagement.ToString())
                {
                    return ResourceManagement.GetResourceText("SystemResourceID.SystemManagement", "Quản lý hệ thống", "System management");
                }
                else if (Module == AppModule.CustomerManagement.ToString())
                {
                    return ResourceManagement.GetResourceText("SystemResourceID.CustomerManagement", "Quản lý khách hàng", "Customer management");
                }
                else if(Module == AppModule.UserManagement.ToString())
                {
                    return ResourceManagement.GetResourceText("SystemResourceID.UserManagement", "Quản lý người dùng", "User management");
                }
                else if(Module == AppModule.ArrivalNoticeManagement.ToString())
                {
                    return ResourceManagement.GetResourceText("SystemResourceID.ArrivalNoticeManagement", "Quản lý thông báo đến", "Arrival notice management");
                }
                else if(Module == AppModule.DOManagement.ToString())
                {
                    return ResourceManagement.GetResourceText("SystemResourceID.DOManagement", "Quản lý lệnh giao hàng", "DO management");
                }
                else if (Module == AppModule.IBOX.ToString())
                {
                    return ResourceManagement.GetResourceText("SystemResourceID.IBOX", "IBOX", "IBOX");
                }
                else if (Module == AppModule.CategoryManagement.ToString())
                {
                    return ResourceManagement.GetResourceText("SystemResourceID.CategoryManagement", "Quản lý danh mục", "Category management");
                }
                else
                {
                    return ResourceManagement.GetResourceText("SystemResourceID.Login", "Đăng nhập", "Login");
                }
            }
        }
        public string DisplayUserFunction
        {
            get
            {
                if (UserFunction == (int)AppAction.Insert)
                {
                    return string.Format(@"<span class='label label-success'>{0}</span>", UserFunctionName);
                }
                else if (UserFunction == (int)AppAction.Update)
                {
                    return string.Format(@"<span class='label label-primary'>{0}</span>", UserFunctionName);
                }
                else if (UserFunction == (int)AppAction.Delete)
                {
                    return string.Format(@"<span class='label label-danger'>{0}</span>", UserFunctionName);
                }
                else if (UserFunction == (int)AppAction.Export)
                {
                    return string.Format(@"<span class='label label-warning'>{0}</span>", UserFunctionName);
                }
                else if (UserFunction == (int)AppAction.Import)
                {
                    return string.Format(@"<span class='label label-danger'>{0}</span>", UserFunctionName);
                }
                else
                {
                    return string.Format(@"<span class='label label-info'>{0}</span>", UserFunctionName);
                }
            }
        }
        public string UserFunctionName
        {
            get
            {
                if (UserFunction == (int)AppAction.Insert)
                {
                    return ResourceManagement.GetResourceText("SystemResourceID.Insert", "Thêm", "Insert");
                }
                else if (UserFunction == (int)AppAction.Update)
                {
                    return ResourceManagement.GetResourceText("SystemResourceID.Update", "Sửa", "Update");
                }
                else if (UserFunction == (int)AppAction.Delete)
                {
                    return ResourceManagement.GetResourceText("SystemResourceID.Delete", "Xóa", "Delete");
                }
                else if (UserFunction == (int)AppAction.Export)
                {
                    return ResourceManagement.GetResourceText("SystemResourceID.Export", "Xuất dữ liệu", "Export");
                }
                else if (UserFunction == (int)AppAction.Import)
                {
                    return ResourceManagement.GetResourceText("SystemResourceID.Import", "Nhập dữ liệu", "Import");
                }
                else
                {
                    return ResourceManagement.GetResourceText("SystemResourceID.Login", "Đăng nhập", "Login");
                }
            }
        }
        public string DisplayEventResult
        {
            get
            {
                if (EventResult == (int)AppEventResult.Fail)
                {
                    return string.Format(@"<span class='label label-danger'>{0}</span>", EventResultName);
                }
                else
                {
                    return string.Format(@"<span class='label label-success'>{0}</span>", EventResultName);
                }
            }
        }
        public string EventResultName
        {
            get
            {
                if (EventResult == (int)AppEventResult.Fail)
                {
                    return ResourceManagement.GetResourceText("SystemResourceID.Fail", "Thất bại", "Fail");
                }
                else
                {
                    return ResourceManagement.GetResourceText("SystemResourceID.Success", "Thành công", "Success");
                }
            }
        }
        public string DisplayFuncDateTime
        {
            get
            {
                if (!string.IsNullOrEmpty(FuncDateTime.ToString()))
                {
                    return DateTime.Parse(FuncDateTime.ToString()).ToString(Constant.DateTimePattern);
                }
                return string.Empty;
            }
        }
    }
    public class LoginModel
    {
        [Required]
        [ExDisplay(typeof(LoginModel), "Username", "Tài khoản")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [ExDisplay(typeof(LoginModel), "Password", "Mật khẩu")]
        public string Password { get; set; }

        [ExDisplay(typeof(LoginModel), "Remember me", "Tự động đăng nhập lần sau")]
        public bool RememberMe { get; set; }

        public bool IsCustomer { get; set; }
        public int AccessFailedCount { get; set; }
        public int ExpriyNumber { get; set; }
        public int TimeBlock { get; set; }
        public LoginModel()
        {
            this.AccessFailedCount = 0;
            this.ExpriyNumber = 0;
            this.IsCustomer = false;
        }
    }
    public class LoginQAModel
    {
        public Guid CustomerId { get; set; }
        public string UserName { get; set; }
        public string UserNameMD5 { get; set; }
        public string Question { get; set; }
        [Required]
        [ExDisplay(typeof(LoginModel), "Answer", "Câu trả lời")]
        public string Answer { get; set; }
        public string RoleName { get; set; }
        public bool RememberMe { get; set; }
        public LoginQAModel()
        {           
        }
    }
    public class InformationModel
    {
        [Required]
        [ExDisplay(typeof(InformationModel), "Id", "Mã Id")]
        public System.Guid ID { get; set; }

        [Required]
        [ExDisplay(typeof(InformationModel), "Code", "Mã đơn vị")]
        public string Code { get; set; }

        [Required]
        [ExDisplay(typeof(InformationModel), "Name", "Tên đơn vị")]
        public string Name { get; set; }

        [Required]
        [ExDisplay(typeof(InformationModel), "InternationName", "Tên quốc tế")]
        public string InternationName { get; set; }

        [ExDisplay(typeof(InformationModel), "Address", "Địa chỉ")]
        public string Address { get; set; }

        [ExDisplay(typeof(InformationModel), "HomePage", "Trang gốc")]
        public string HomePage { get; set; }

        [ExDisplay(typeof(InformationModel), "Phone", "Điện Thoại")]
        public string Phone { get; set; }

        [ExDisplay(typeof(InformationModel), "Email", "Email")]
        public string Email { get; set; }

        [ExDisplay(typeof(InformationModel), "Fax", "Fax")]
        public string Fax { get; set; }

        [ExDisplay(typeof(InformationModel), "ZipCode", "Mã bưu chính")]
        public string ZipCode { get; set; }

        public string ActionType { get; set; }

        public string DisplayAddress
        {
            get { return !string.IsNullOrEmpty(Address) ? Address : string.Empty; }
        }
        public string DisplayHomePage
        {
            get { return !string.IsNullOrEmpty(HomePage) ? HomePage : string.Empty; }
        }
        public string DisplayPhone
        {
            get { return !string.IsNullOrEmpty(Phone) ? Phone : string.Empty; }
        }
        public string DisplayEmail
        {
            get { return !string.IsNullOrEmpty(Email) ? Email : string.Empty; }
        }
        public string DisplayFax
        {
            get { return !string.IsNullOrEmpty(Fax) ? Fax : string.Empty; }
        }
    }
    public class SystemFunctionModel
    {
        [Required]
        [ExDisplay(typeof(SystemFunctionModel), "Function ID", "Mã chức năng")]
        public string FunctionID { get; set; }

        [Required]
        [ExDisplay(typeof(SystemFunctionModel), "Function Name", "Tên chức năng")]
        public string FunctionName { get; set; }

        [Required]
        [ExDisplay(typeof(SystemFunctionModel), "Function Desc", "Mô tả chức năng")]
        public string FunctionDesc { get; set; }

        public int OrderNumber { get; set; }
        public byte Type { get; set; }

        public virtual ICollection<RoleModel> Roles { get; set; }
    }
    public class RoleModel
    {
        [Required]
        [ExDisplay(typeof(RoleModel), "Role ID", "Mã quyền truy cập")]
        public System.Guid RoleID { get; set; }

        [Required]
        [ExDisplay(typeof(RoleModel), "Role Name", "Tên quyền truy cập")]
        public string RoleName { get; set; }

        [ExDisplay(typeof(RoleModel), "System Function", "Chức năng hệ thống")]
        public string SystemFunction { get; set; }

        [ExDisplay(typeof(RoleModel), "Role Desc", "Mô tả quyền truy cập")]
        public string RoleDesc { get; set; }
        public string ActionType { get; set; }

        public bool IsCheckUpdate { get; set; }
        public string DisplayRoleName
        {
            get { return !string.IsNullOrEmpty(RoleName) ? RoleName : string.Empty; }
        }
        public virtual ICollection<SystemFunctionModel> SystemFunctions { get; set; }
        public virtual ICollection<UserInfoModel> UserInfos { get; set; }
        public RoleModel()
        {
            this.RoleID = Guid.Empty;
            this.RoleName = string.Empty;
            this.SystemFunction = string.Empty;
            this.RoleDesc = string.Empty;
            this.ActionType = string.Empty;
            this.IsCheckUpdate = true;
        }
    }
    public class UserRoleModel
    {
        public string UserName { get; set; }
        public System.Guid RoleID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public virtual RoleModel Role { get; set; }
    }
    public class SystemSettingModel
    {
        public string SettingId { get; set; }
        public string Value { get; set; }
    }
    public class MailboxModel:BaseModel
    {
        [ExDisplay(typeof(MailboxModel), "Subject", "Tiêu đề")]
        public string Subject { get; set; }
        [ExDisplay(typeof(MailboxModel), "Body", "Nội dung")]
        public string Body { get; set; }
        [ExDisplay(typeof(MailboxModel), "Mail To", "Gửi đến")]
        public string MailTo { get; set; }
        [ExDisplay(typeof(MailboxModel), "Mail Cc", "Mail Cc")]
        public string MailCc { get; set; }
        [ExDisplay(typeof(MailboxModel), "Num Send", "Số lần gửi")]
        public int NumSend { get; set; }
        [ExDisplay(typeof(MailboxModel), "Sent", "Đã gửi")]
        public Nullable<bool> Sent { get; set; }
    }
}