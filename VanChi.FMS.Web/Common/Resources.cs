using VanChi.Business.Common;
using VanChi.Business.DTO;
using VanChi.FMS.Web.Controllers;
using System;
using System.Web.Mvc;

namespace VanChi.FMS.Web.Common
{
    public class ResourceManagement
    {
        #region Variables

        #endregion

        #region Contructor
        public ResourceManagement()
        {
        }

        #endregion

        #region Function
        public static string GetResourceText(string resourceID)
        {
            if (App.DicResources != null && App.DicResources.ContainsKey(resourceID))
            {
                var langCode = App.CacheProvider.GetLocalLanguage();
                if (langCode == AppLanguageCode.Vietnamese && !string.IsNullOrEmpty(App.DicResources[resourceID].ResourceText0))
                    return App.DicResources[resourceID].ResourceText0;
                if (langCode == AppLanguageCode.English && !string.IsNullOrEmpty(App.DicResources[resourceID].ResourceText1))
                    return App.DicResources[resourceID].ResourceText1;
                if (langCode == AppLanguageCode.French && !string.IsNullOrEmpty(App.DicResources[resourceID].ResourceText2))
                    return App.DicResources[resourceID].ResourceText2;
                if (langCode == AppLanguageCode.Chinese && !string.IsNullOrEmpty(App.DicResources[resourceID].ResourceText3))
                    return App.DicResources[resourceID].ResourceText3;
                if (langCode == AppLanguageCode.Japanese && !string.IsNullOrEmpty(App.DicResources[resourceID].ResourceText4))
                    return App.DicResources[resourceID].ResourceText4;
                if (langCode == AppLanguageCode.Russian && !string.IsNullOrEmpty(App.DicResources[resourceID].ResourceText5))
                    return App.DicResources[resourceID].ResourceText5;
            }
            return !string.IsNullOrEmpty(App.DicResources[resourceID].ResourceText0) ? App.DicResources[resourceID].ResourceText0 : resourceID.Split('.')[resourceID.Split('.').Length - 1];
        }
        public static string GetResourceText(string resourceID, string defaultTextVie)
        {
            if (string.IsNullOrEmpty(resourceID))
            {
                return Constant.Error_GetResourceID;
            }
            else
            {
                if (App.DicResources == null)
                {
                    return defaultTextVie;
                }
                else if (App.DicResources != null && App.DicResources.ContainsKey(resourceID))
                {
                    string mResource = GetResourceText(resourceID);
                    if (string.IsNullOrEmpty(mResource)) return defaultTextVie;
                    if (mResource == resourceID)
                    {
                        if (string.IsNullOrEmpty(App.DicResources[resourceID].ResourceText0))
                        {
                            App.DicResources[resourceID].ResourceText0 = defaultTextVie;
                            ResourceDTO res = new ResourceDTO();
                            res.ResourceID = resourceID;
                            res.DefaultText0 = defaultTextVie;
                            res.ResourceText0 = defaultTextVie;
                            DependencyResolver.Current.GetService<SystemManagementController>().ResourceUpdateAsync(res);
                        }
                    }
                    else return mResource;
                }
                else
                {
                    ResourceDTO res = new ResourceDTO();
                    res.ResourceID = resourceID;
                    res.DefaultText0 = defaultTextVie;
                    res.ResourceText0 = defaultTextVie;
                    bool result = DependencyResolver.Current.GetService<SystemManagementController>().ResourceInsertAsync(res);
                    if (result)
                    {
                        App.DicResources.Remove(resourceID);
                        App.DicResources.Add(resourceID, res);
                    }
                }
                return defaultTextVie;
            }
        }
        public static string GetResourceText(string resourceID, string defaultTextVie, string defaultTextEng)
        {
            if (string.IsNullOrEmpty(resourceID))
            {
                return Constant.Error_GetResourceID;
            }
            else
            {
                if (App.DicResources == null)
                {
                    return defaultTextVie;
                }
                else if (App.DicResources != null && App.DicResources.ContainsKey(resourceID))
                {
                    #region Update

                    string mResource = GetResourceText(resourceID);
                    if (string.IsNullOrEmpty(mResource)) return defaultTextVie;
                    //if (mResource == resourceID)
                    //{
                    //    if (string.IsNullOrEmpty(App.DicResources[resourceID].ResourceText0))
                    //    {
                    //        App.DicResources[resourceID].ResourceText0 = defaultTextVie;
                    //        App.DicResources[resourceID].ResourceText1 = defaultTextEng;
                    //        ResourceDTO res = new ResourceDTO();
                    //        res.ResourceID = resourceID;
                    //        res.DefaultText0 = defaultTextVie;
                    //        res.ResourceText0 = defaultTextVie;
                    //        res.DefaultText1 = defaultTextEng;
                    //        res.ResourceText1 = defaultTextEng;
                    //        DependencyResolver.Current.GetService<SystemManagementController>().Resource_UpdateAsync(res);
                    //    }
                    //}
                    else return mResource;

                    #endregion
                }
                else
                {
                    ResourceDTO res = new ResourceDTO();
                    res.ResourceID = resourceID;
                    res.DefaultText0 = defaultTextVie;
                    res.ResourceText0 = defaultTextVie;
                    res.DefaultText1 = defaultTextEng;
                    res.ResourceText1 = defaultTextEng;
                    bool result = DependencyResolver.Current.GetService<SystemManagementController>().ResourceInsertAsync(res);
                    if (result)
                    {
                        App.DicResources.Remove(resourceID);
                        App.DicResources.Add(resourceID, res);
                    }
                }
                return defaultTextVie;
            }
        }
        public static string GetResourceID(object classObject, string fieldName)
        {
            Type type = classObject.GetType();
            return GetResourceID(type, fieldName);
        }
        public static string GetResourceID(Type type, string fieldName)
        {
            return "SystemResourceID." + type.Name + "." + fieldName.Replace(" ", "-").Trim();
        }

        #endregion
    }
}