using VanChi.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanChi.Business.DTO
{
    public class ChangPasswordDTO
    {
        public string UserName { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPawword { get; set; }
    }
    public class UserPasswordDTO
    {
        public string UserName { get; set; }       
        public string NewPassword { get; set; }
        public string ConfirmPawword { get; set; }
    }

    public class UserInfoCustomerDTO
    {
        public string UserName { get; set; }
        public Guid CustomerId { get; set; }
        public string UserCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }
    }
    public class UserInfoTerminalDTO
    {
        public string UserName { get; set; }   
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
       
    }

    public partial class MenuDTO : BaseDTO
    {  
        public Guid? ParentId { get; set; }
        public bool IsParent { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string NameVI { get; set; }
        public string NameEN { get; set; }
        public int OrderNumber { get; set; }
        public string ResourceID { get; set; }
        public string NameFunction { get; set; }
        public int Type { get; set; }
        public AppMenu.MenuStatus MenuStatus { get; set; }
        public string Icon { get; set; }        
        public string Method { get; set; }
    }
    public partial class MenuRoleDTO : BaseDTO
    {
        public System.Guid RoleId { get; set; }
        public System.Guid MenuId { get; set; }
        public string UserName { get; set; }

    }
}
