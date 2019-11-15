using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanChi.Repository.Interface;
using VanChi.Data;
using VanChi.Business.Common;
using VanChi.Business.DTO;
using System.Data.Entity;
using System.Reflection;

namespace VanChi.Business.Concrete.ObjectBusiness
{
    public class MenuBusiness : BaseObjectBusiness
    {
        #region Variables
        #endregion

        #region Constructors
        public MenuBusiness(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion
        
        #region Method 
            
        public IQueryable<Menu> GetAll()
        {
            try
            {
                return this.UnitOfWork.GetAll<Menu>().Where(x => x.ActiveFag == (byte)AppValues.ActiveFag.StatusActive);
            }
            catch (Exception ex)
            {
                InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw;
            }

        }
        public IQueryable<Menu> GetListMenuByRoleName(List<string> lstRoleName)
        {
            try
            {
                return this.UnitOfWork.GetAll<Role>().Where(x => lstRoleName.Contains(x.RoleName))
                .Join(this.UnitOfWork.GetAll<MenuRole>().Where(x => x.ActiveFag == (byte)AppValues.ActiveFag.StatusActive),
                r => r.RoleID,
                mr => mr.RoleId,
                (r, mr) => new { r, mr }.mr)
                .Join(this.UnitOfWork.GetAll<Menu>().Where(x => x.ActiveFag == (byte)AppValues.ActiveFag.StatusActive),
                mr => mr.MenuId,
                m => m.Id,
                (mr, m) => new { mr, m }.m);
            }
            catch (Exception ex)
            {
                InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw;
            }

        }
        public IQueryable<Menu> GetListSubMenu(List<Guid> lstMenuId)
        {
            try
            {
                return this.UnitOfWork.GetAll<Menu>()
                              .Where(x => lstMenuId.Any(y => y == x.ParentId)
                              && x.ParentId != null
                              && x.ActiveFag == (byte)AppValues.ActiveFag.StatusActive);
            }
            catch (Exception ex)
            {
                InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw;
            }

        }
        public async Task<List<NameMenuRoleDTO>> GetListMenuByRoleId(List<Guid> lstRole)
        {
            try
            {
                return await this.UnitOfWork.GetAll<Role>().Where(x => lstRole.Contains(x.RoleID))
                 .Join(this.UnitOfWork.GetAll<MenuRole>().Where(x => x.ActiveFag == (byte)AppValues.ActiveFag.StatusActive),
                 r => r.RoleID,
                 mr => mr.RoleId,
                 (r, mr) => new { r, mr }.mr)
                 .Join(this.UnitOfWork.GetAll<Menu>().Where(x => x.ActiveFag == (byte)AppValues.ActiveFag.StatusActive),
                 mr => mr.MenuId,
                 m => m.Id,
                 (mr, m) => new { mr, m })
                 .Select(x => new NameMenuRoleDTO()
                 {
                     RoleId = x.mr.RoleId,
                     FunctionName = x.m.NameFunction,
                     Order = x.m.OrderNumber
                 }).OrderBy(x => x.Order).ToListAsync();
            }
            catch (Exception ex)
            {
                InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw;
            }

        }
        public async Task<bool> Insert(List<Menu> lstEntity)
        {
            var result = false;
            try
            {
                var iquery = await this.UnitOfWork.InsertToListEntityAsync(lstEntity);
                if (iquery.Count > 0) result = true;
            }
            catch (Exception ex)
            {
                InsertToLogFile(MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw;
            } 
            return result;
        }

        #endregion
    }
}
