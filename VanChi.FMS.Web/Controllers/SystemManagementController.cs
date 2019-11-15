using AutoMapper;
using VanChi.Business.Common;
using VanChi.Business.DTO;
using VanChi.Business.Interface;
using VanChi.Logs;
using VanChi.FMS.Web.Common;
using VanChi.FMS.Web.Models;
using VanChi.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace VanChi.FMS.Web.Controllers
{
    /// <summary>
    /// Quản lý hệ thống
    /// </summary>
    public class SystemManagementController : BaseController
    {
        #region Variables and Properties

        #endregion

        #region Constructors

        public SystemManagementController(IBusiness business)
            : base(business)
        {
        }

        #endregion

        #region Method

        #region Resource Management - Quản lý tài nguyên

        #region List

        [HttpGet]
        public ActionResult ResourceManagement()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ResourceGetPaging(int pageIndex, string keyWord)
        {
            var jsonModel = new JsonModel();
            try
            {
                int total = 0;
                var data = this.Business.Shared_GetItems<ResourceDTO, Resource>(out total, null, null, x => x.OrderByDescending(y => y.CreateDate), pageIndex, App.PageSize);

                if (!string.IsNullOrEmpty(keyWord) && !string.IsNullOrWhiteSpace(keyWord))
                {
                    data = this.Business.Shared_GetItems<ResourceDTO, Resource>(out total,
                        x => x.ResourceID.ToLower().Contains(keyWord.ToLower())
                        || x.ResourceText0.ToLower().Contains(keyWord.ToLower())
                        || x.ResourceText1.ToLower().Contains(keyWord.ToLower())
                        || x.ResourceText2.ToLower().Contains(keyWord.ToLower())
                        || x.ResourceText3.ToLower().Contains(keyWord.ToLower())
                        || x.ResourceText4.ToLower().Contains(keyWord.ToLower())
                        || x.ResourceText5.ToLower().Contains(keyWord.ToLower()), null, x => x.OrderByDescending(y => y.CreateDate), pageIndex, App.PageSize);
                }
                var dataModel = Mapper.Map<List<ResourceModel>>(data);
                jsonModel = new JsonModel(pageIndex, total, dataModel);
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.MVC.Controllers-SystemManagementController-ResourceGetPaging()", ex);
            }
            return Json(jsonModel, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Add & Edit

        [HttpGet]
        public async Task<ActionResult> ResourceUpdate(string resourceId)
        {
            var model = new ResourceModel();
            if (string.IsNullOrEmpty(resourceId))
            {
                model.ActionType = Constant.InsertAction;
            }
            else
            {
                var dto = await this.Business.Shared_GetItemAsync<ResourceDTO, Resource>(x => x.ResourceID == resourceId);
                model = Mapper.Map<ResourceModel>(dto);
                model.ActionType = Constant.UpdateAction;
            }
            return PartialView(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> ResourceUpdate(ResourceModel model)
        {
            try
            {
                if (model != null)
                {
                    bool result = false;
                    var dto = Mapper.Map<ResourceDTO>(model);

                    #region Insert

                    if (model.ActionType == Constant.InsertAction)
                    {
                        result = this.Business.Shared_Insert<ResourceDTO, Resource>(dto);
                        if (result)
                        {
                            await UserContext.WriteApplicationLog(AppModule.SystemManagement, AppAction.Insert, AppEventResult.Success, "ResourceUpdate", "ResourceId: " + model.ResourceID + " | ResourceText0: " + model.ResourceText0);
                        }
                        else
                        {
                            await UserContext.WriteApplicationLog(AppModule.SystemManagement, AppAction.Insert, AppEventResult.Fail, "ResourceUpdate", "ResourceId: " + model.ResourceID + " | ResourceText0: " + model.ResourceText0);
                        }
                    }

                    #endregion

                    #region Update

                    else
                    {
                        dto.CreateDate = DateTime.Now;
                        result = this.Business.Shared_Update<ResourceDTO, Resource>(dto, new List<Expression<Func<Resource, object>>> { x => x.ResourceText0, x => x.ResourceText1, x => x.ResourceText2, x => x.ResourceText3, x => x.ResourceText4, x => x.ResourceText5, x => x.CreateDate });
                        if (result)
                        {
                            await UserContext.WriteApplicationLog(AppModule.SystemManagement, AppAction.Update, AppEventResult.Success, "ResourceUpdate", "ResourceId: " + model.ResourceID + " | ResourceText0: " + model.ResourceText0);
                        }
                        else
                        {
                            await UserContext.WriteApplicationLog(AppModule.SystemManagement, AppAction.Update, AppEventResult.Fail, "ResourceUpdate", "ResourceId: " + model.ResourceID + " | ResourceText0: " + model.ResourceText0);
                        }
                    }

                    #endregion

                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.MVC.Controllers-SystemManagementController-ResourceUpdate()", ex);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<JsonResult> ResourceIsUnique(string resourceId)
        {
            int count = await this.Business.Shared_CountAsync<ResourceDTO, Resource>(x => x.ResourceID.ToLower() == resourceId.ToLower());
            if (count > 0)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Delete

        [HttpPost]
        public async Task<JsonResult> ResourceDelete(List<string> lstResourceId)
        {
            try
            {
                if (lstResourceId != null && lstResourceId.Count() > 0)
                {
                    bool result = this.Business.Resource_Delete(lstResourceId);
                    if (result)
                    {
                        await UserContext.WriteApplicationLog(AppModule.SystemManagement, AppAction.Delete, AppEventResult.Success, "ResourceDelete", "ResourceId: " + lstResourceId[0].ToString() + " ... " + lstResourceId[lstResourceId.Count - 1].ToString());
                    }
                    else
                    {
                        await UserContext.WriteApplicationLog(AppModule.SystemManagement, AppAction.Delete, AppEventResult.Fail, "ResourceDelete", "ResourceId: " + lstResourceId[0].ToString() + " ... " + lstResourceId[lstResourceId.Count - 1].ToString());
                    }
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.MVC.Controllers-SystemManagementController-ResourceDelete()", ex);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Common
        public bool ResourceInsertAsync(ResourceDTO resource)
        {
            return this.Business.Shared_Insert<ResourceDTO, Resource>(resource);
        }
        public bool ResourceUpdateAsync(ResourceDTO resource)
        {
            return this.Business.Shared_Update<ResourceDTO, Resource>(resource);
        }

        #endregion

        #endregion

        #region System Log - Nhật ký hệ thống
        [HttpGet]
        public ActionResult SystemLog()
        {
            ViewBag.ModuleId = Constant.Controller_SystemManagement;
            return View();
        }
        [HttpPost]
        public JsonResult SystemLogGetPaging(int pageIndex, string keyWord, string module, int userFunction, int eventResult, string dateFrom, string dateTo)
        {
            var jsonModel = new JsonModel();
            try
            {
                int total = 0;
                dateFrom = (string.IsNullOrEmpty(dateFrom)) ? string.Empty : DateTime.Parse(dateFrom).ToString(Constant.DatePatternDB) + Constant.TimeMinimum;
                dateTo = (string.IsNullOrEmpty(dateTo)) ? string.Empty : DateTime.Parse(dateTo).ToString(Constant.DatePatternDB) + Constant.TimeMaximum;

                var data = this.Business.SystemLog_GetPaging(out total, keyWord, module, userFunction, eventResult, dateFrom, dateTo, pageIndex, App.PageSize);
                var dataModel = Mapper.Map<List<SystemLogModel>>(data);
                jsonModel = new JsonModel(pageIndex, total, dataModel);
            }
            catch (Exception ex)
            {
                Logging.LogError("LacViet.HPS.EDO.MVC.Controllers-SystemManagementController-SystemLogGetPaging()", ex);
            }
            return Json(jsonModel, JsonRequestBehavior.AllowGet);
        }
        public async Task<bool> SystemLogInsertAsync(SystemLogModel systemLog)
        {
            return await this.Business.Shared_InsertAsync<SystemLogDTO, SystemLog>(Mapper.Map<SystemLogDTO>(systemLog)) != null ? true : false;
        }

        #endregion

        #region Mail Template - Mẫu mail

        public ActionResult MailTemplate()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> SystemSettingGetById(List<string> lstSetId)
        {
            var jsonModel = new JsonModel();
            try
            {
                var data = new List<SystemSettingDTO>();
                data = await SettingGetByListSetId(lstSetId);
                var dataModel = Mapper.Map<List<SystemSettingModel>>(data);
                jsonModel = new JsonModel(1, 1, dataModel);
            }
            catch (Exception ex)
            {
                base.InsertToLogFile(this, ex);
            }
            return Json(jsonModel, JsonRequestBehavior.AllowGet);
        }
        private async Task<List<SystemSettingDTO>> SettingGetByListSetId(List<string> lstSetId)
        {
            List<SystemSettingDTO> result = new List<SystemSettingDTO>();
            try
            {
                SystemSettingDTO setDTO = null;
                for (int i = 0; i < lstSetId.Count; i++)
                {
                    setDTO = await this.Business.SystemSetting_GetById(lstSetId[i]);
                    if (setDTO != null)
                        result.Add(setDTO);
                }
            }
            catch (Exception ex)
            {
                base.InsertToLogFile(this, ex);
                result = null;
            }
            return result;
        }

        public async Task<JsonResult> SystemSettingUpdate(List<SystemSettingModel> param)
        {
            bool result = false;
            List<SystemSettingDTO> lstsetDTO = new List<SystemSettingDTO>();
            try
            {
                lstsetDTO = Mapper.Map<List<SystemSettingDTO>>(param);
                result = await this.Business.SystemSetting_Update(lstsetDTO);
            }
            catch (Exception ex)
            {
                base.InsertToLogFile(this, ex);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Mailbox - Hôp thư

        //public ActionResult Mailbox()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<JsonResult> MailboxGetPaging(int pageIndex, string keyWord, string fromdate, string todate)
        //{
        //    fromdate = (string.IsNullOrEmpty(fromdate)) ? string.Empty : DateTime.Parse(fromdate).ToString(Constant.DatePatternDB) + Constant.TimeMinimum;
        //    todate = (string.IsNullOrEmpty(todate)) ? string.Empty : DateTime.Parse(todate).ToString(Constant.DatePatternDB) + Constant.TimeMinimum;
        //    var jsonModel = new JsonModel();
        //    try
        //    {
        //        int total = 0;
        //        var data = await this.Business.Mailbox_GetPaging(pageIndex, App.PageSize, keyWord, fromdate, todate);
        //        if (data != null)
        //        {
        //            total = data.Item1;
        //            var dataModel = Mapper.Map<List<MailboxModel>>(data.Item2);
        //            jsonModel = new JsonModel(pageIndex, total, dataModel);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        base.InsertToLogFile(this, ex);
        //    }
        //    return Json(jsonModel, JsonRequestBehavior.AllowGet);
        //}
        #endregion

        #endregion
    }
}
