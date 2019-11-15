using VanChi.Logs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace VanChi.Business.DTO
{
    public class UserInfoDTO : BaseDTO
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public byte[] Picture { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string Ext { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public Nullable<System.Guid> LanguageID { get; set; }
        public Nullable<bool> Gender { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> FirstWorkingDate { get; set; }
        public string UserCode { get; set; }
        public string UserHRIS { get; set; }
        public string Diploma { get; set; }
        public string Position { get; set; }
        public string LanguageCode { get; set; }
        public Nullable<bool> IsCustomer { get; set; }
        public string OrgName { get; set; }
        public string JobTitleName { get; set; }
        public virtual ICollection<RoleDTO> Roles { get; set; }
    }
    public class ResourceDTO
    {
        public string ResourceID { get; set; }
        public string ResourceText0 { get; set; }
        public string DefaultText0 { get; set; }
        public string ResourceText1 { get; set; }
        public string DefaultText1 { get; set; }
        public string ResourceText2 { get; set; }
        public string DefaultText2 { get; set; }
        public string ResourceText3 { get; set; }
        public string DefaultText3 { get; set; }
        public string ResourceText4 { get; set; }
        public string DefaultText4 { get; set; }
        public string ResourceText5 { get; set; }
        public string DefaultText5 { get; set; }
        public System.DateTime CreateDate { get; set; }
        public bool ParseData(DataRow dr)
        {
            try
            {
                for (int i = 0; i < dr.Table.Columns.Count; i++)
                {
                    string _colName = dr.Table.Columns[i].ColumnName;
                    PropertyInfo _prop = this.GetType().GetProperty(_colName);
                    if (!(dr[_colName] is DBNull) && _prop != null)
                    {
                        _prop.SetValue(this, dr[_colName], null);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ResourceDTO()
        {
            this.CreateDate = DateTime.Now;
        }
    }
    public class SystemLogDTO : BaseDTO
    {
        public System.Guid LogId { get; set; }
        public string Module { get; set; }
        public string UserId { get; set; }
        public Nullable<int> UserFunction { get; set; }
        public Nullable<int> EventResult { get; set; }
        public Nullable<System.DateTime> FuncDateTime { get; set; }
        public string Source { get; set; }
        public string Transdata { get; set; }
        public string WSName { get; set; }
    }
    public class InformationDTO : BaseDTO
    {
        public System.Guid ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string InternationName { get; set; }
        public string Address { get; set; }
        public string HomePage { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string ZipCode { get; set; }
    }
    public class SystemFunctionDTO : BaseDTO
    {
        public string FunctionID { get; set; }
        public Guid MenuId { get; set; }
        public string FunctionName { get; set; }
        public string FunctionDesc { get; set; }
        public bool IsCustomer { get; set; }
        public int OrderNumber { get; set; }
        public byte Type { get; set; }
      
        public virtual ICollection<RoleDTO> Roles { get; set; }
    }
    public class RoleDTO : BaseDTO
    {
        public System.Guid RoleID { get; set; }
        public string RoleName { get; set; }
        public string RoleDesc { get; set; }
        public virtual ICollection<SystemFunctionDTO> SystemFunctions { get; set; }
        public virtual ICollection<UserInfoDTO> UserInfos { get; set; }
    }
    public class RoleFunctionDTO : BaseDTO
    {
        public System.Guid RoleID { get; set; }
        public string FunctionID { get; set; }    
            
    }
    public class UserRoleDTO : BaseDTO
    {
        public string UserName { get; set; }
        public System.Guid RoleID { get; set; }
    }
    public class SystemSettingDTO
    {
        public string SettingId { get; set; }
        public string Value { get; set; }
        public bool ParseData(DataRow dr)
        {
            try
            {
                for (int i = 0; i < dr.Table.Columns.Count; i++)
                {
                    string _colName = dr.Table.Columns[i].ColumnName;
                    PropertyInfo _prop = this.GetType().GetProperty(_colName);
                    if (!(dr[_colName] is DBNull) && _prop != null)
                    {
                        _prop.SetValue(this, dr[_colName], null);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.Business.DTO-SystemSettingDTO-ParseData", ex);
                return false;
            }
        }

    }
    public class MailboxDTO: BaseDTO
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string MailTo { get; set; }
        public string MailCc { get; set; }
        public int NumSend { get; set; }
        public Nullable<bool> Sent { get; set; }
    }

    public class NameMenuRoleDTO
    {
        public string FunctionName { get; set; }      
        public Guid RoleId { get; set; }
        public int Order { get; set; }
    }
}