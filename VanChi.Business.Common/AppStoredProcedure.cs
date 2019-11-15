using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanChi.Business.Common
{
    /// <summary>
    /// Store Procedure
    /// </summary>
    public class AppStoredProcedure
    {
        #region System Log
        /// <summary>
        /// SP_Resource_GetAll
        /// </summary>
        public static string SP_Resource_GetAll = "SP_Resource_GetAll";

        /// <summary>
        /// SP_Resource_Delete
        /// </summary>
        public static string SP_Resource_Delete = "SP_Resource_Delete";

        /// <summary>
        /// SP_SystemLog_GetPaging
        /// </summary>
        public static string SP_SystemLog_GetPaging = "SP_SystemLog_GetPaging";

        #endregion

        #region Customer
        /// <summary>
        /// SP_Customer_GetPaging
        /// </summary>
        public static string SP_Customer_GetPaging = "SP_Customer_GetPaging";
        /// <summary>
        ///  SP_Customer_GetInfo
        /// </summary>
        public static string SP_Customer_GetInfo = "SP_Customer_GetInfo";

        /// <summary>
        /// SP_UserInfo_GetById
        /// </summary>
        public static string SP_UserInfo_GetById = "SP_UserInfo_GetById";

        /// <summary>
        /// SP_Customer_Insert
        /// </summary>
        public const string SP_Customer_Insert = "SP_Customer_Insert";
        #endregion
        
        #region Arrival notice
        /// <summary>
        /// SP_ArrivalNotice_GetByCode
        /// </summary>
        public const string SP_ArrivalNotice_GetByCode = "SP_ArrivalNotice_GetByCode";
        /// <summary>
        /// SP_ArrivalNotice_Detail
        /// </summary>
        public const string SP_ArrivalNotice_Detail = "SP_ArrivalNotice_Detail";
        /// <summary>
        /// SP_ArrivalNotice_Status
        /// </summary>
        public const string SP_ArrivalNotice_Status = "SP_ArrivalNotice_Status";
        /// <summary>
        /// an.SP_ArrivalNotice_GetNotSend
        /// </summary>
        public const string SP_ArrivalNotice_GetNotSend = "an.SP_ArrivalNotice_GetNotSend";
        /// <summary>
        /// SP_ArrivalNotice_UpdateNumSend
        /// </summary>
        public const string SP_ArrivalNotice_UpdateNumSend = "SP_ArrivalNotice_UpdateNumSend";
        /// <summary>
        /// SP_ArrivalNotice_Insert
        /// </summary>
        public const string SP_ArrivalNotice_Insert = "an.SP_ArrivalNotice_Insert";
        /// <summary>
        /// SP_ArrivalNotice_Update
        /// </summary>
        public const string SP_ArrivalNotice_Update = "an.SP_ArrivalNotice_Update";
        /// <summary>
        /// SP_ArrivalNotice_GetByListCode
        /// </summary>
        public const string SP_ArrivalNotice_GetByListCode = "SP_ArrivalNotice_GetByListCode";
        /// <summary>
        /// SP_ArrivalNotice_PutBL
        /// </summary>
        public const string SP_ArrivalNotice_PutBL = "SP_ArrivalNotice_PutBL";
        /// <summary>
        /// SP_ArrivalNotice_PutLstBL
        /// </summary>
        public const string SP_ArrivalNotice_PutListBL = "SP_ArrivalNotice_PutListBL";

        /// <summary>
        /// SP_ANHistory_GetByIdAN
        /// </summary>
        public static string SP_ANHistory_GetByIdAN = "SP_ANHistory_GetByIdAN";

        /// <summary>
        /// SP_ArrivalNotice_GetDataForTemplate
        /// </summary>
        public static string SP_ArrivalNotice_GetDataForTemplate = "SP_ArrivalNotice_GetDataForTemplate";
        /// <summary>
        /// SP_ArrivalNotice_GetDataForSendMail
        /// </summary>
        public static string SP_ArrivalNotice_GetDataForSendMail = "SP_ArrivalNotice_GetDataForSendMail";

        /// <summary>
        /// SP_ArrivalNotice_GetInfoToSendMail
        /// </summary>
        public static string SP_ArrivalNotice_GetInfoToSendMail = "SP_ArrivalNotice_GetInfoToSendMail";

        /// <summary>
        /// SP_ArrivalNotice_GetPaging
        /// </summary>
        public static string SP_ArrivalNotice_GetPaging = "SP_ArrivalNotice_GetPaging";

        #endregion

        #region Proforma Invoice
        /// <summary>
        /// SP_ProformaInvoice_GetPaging
        /// </summary>
        public static string SP_ProformaInvoice_GetPaging = "SP_ProformaInvoice_GetPaging";

        /// <summary>
        /// SP_ProformaInvoice_GetById
        /// </summary>
        public static string SP_ProformaInvoice_GetById = "SP_ProformaInvoice_GetById";

        /// <summary>
        /// SP_ProformalInvoices_GetDataForTemplate
        /// </summary>
        public static string SP_ProformalInvoices_GetDataForTemplate = "SP_ProformalInvoices_GetDataForTemplate";

        /// <summary>
        /// SP_ProformaInVoice_GetIDs_AN_PI_CDS
        /// </summary>
        public static string SP_ProformaInVoice_GetIDs_AN_PI_CDS = "SP_ProformaInVoice_GetIDs_AN_PI_CDS";

        /// <summary>
        /// pi.SP_ProformaInvoice_Insert
        /// </summary>
        public static string SP_ProformaInvoice_Insert = "pi.SP_ProformaInvoice_Insert";

        /// <summary>
        /// pi.SP_PI_ACT_CDS_Cancel
        /// </summary>
        public static string SP_PI_ACT_CDS_Cancel = "pi.SP_PI_ACT_CDS_Cancel";

        #endregion

        #region Charge Code
        /// <summary>
        /// SP_ChargeCode_GetPaging
        /// </summary>
        public static string SP_ChargeCode_GetPaging = "SP_ChargeCode_GetPaging";
        #endregion

        #region E Invoice

        /// <summary>
        /// SP_EInvoice_GetPaging
        /// </summary>
        public static string SP_EInvoice_GetPaging = "SP_EInvoice_GetPaging";

        /// <summary>
        /// SP_VoyNo_GetAll
        /// </summary>
        public static string SP_VoyNo_GetAll = "SP_VoyNo_GetAll";

        /// <summary>
        /// SP_EInvoice_GetById
        /// </summary>
        public static string SP_EInvoice_GetById = "SP_EInvoice_GetById";

        
        #endregion

        #region Container Deposit Slip

        public const string SP_ContainerDepositSlip_GetPaging = "cds.SP_ContainerDepositSlip_GetPaging";
        public const string SP_ContainerDepositSlip_GetById = "cds.SP_ContainerDepositSlip_GetById";


        /// <summary>
        /// cds.SP_ContainerDepositSlip_Insert
        /// </summary>
        public static string SP_ContainerDepositSlip_Insert = "cds.SP_ContainerDepositSlip_Insert";

        /// <summary>
        /// cds.SP_ContainerDepositSlip_Delete
        /// </summary>
        public static string SP_ContainerDepositSlip_Delete = "cds.SP_ContainerDepositSlip_Delete";

        #endregion

        #region Container Deposit Charge

        /// <summary>
        /// cds.SP_ContainerDepositCharge_Insert
        /// </summary>
        public static string SP_ContainerDepositCharge_Insert = "cds.SP_ContainerDepositCharge_Insert";

        /// <summary>
        /// cds.SP_ContainerDepositCharge_Delete
        /// </summary>
        public static string SP_ContainerDepositCharge_Delete = "cds.SP_ContainerDepositCharge_Delete";

        #endregion

        #region Container Release

        /// <summary>
        /// do.SP_ContainerRelease_Insert
        /// </summary>
        public static string SP_ContainerRelease_Insert = "do.SP_ContainerRelease_Insert";

        /// <summary>
        /// do.SP_ContainerRelease_Delete
        /// </summary>
        public static string SP_ContainerRelease_Delete = "do.SP_ContainerRelease_Delete";
        public static string SP_ContainerRelease_GetByDOId = "do.SP_ContainerRelease_GetByDOId";
        public static string SP_ContainerRelease_Total_GetByDOId = "do.SP_ContainerRelease_Total_GetByDOId";
        #endregion

        #region Container
        /// <summary>
        /// SP_Container_GetItemsByIdAN
        /// </summary>
        public const string SP_Container_GetItemsByIdAN = "SP_Container_GetItemsByIdAN";
        #endregion

        #region Local Charge
        /// <summary>
        /// SP_LocalCharge_GetByPIId
        /// </summary>
        public static string SP_LocalCharge_GetByPIId = "SP_LocalCharge_GetByPIId";

        /// <summary>
        /// pi.SP_LocalCharge_Insert
        /// </summary>
        public static string SP_LocalCharge_Insert = "pi.SP_LocalCharge_Insert";

        /// <summary>
        /// pi.SP_LocalCharge_Delete
        /// </summary>
        public static string SP_LocalCharge_Delete = "pi.SP_LocalCharge_Delete";

        #endregion

        #region  DO
        public const string SP_DO_GetPaging = "do.SP_DO_GetPaging";
        public const string SP_DO_GetById = "do.SP_DO_GetById";
        public static string SP_DO_GetInvoiceByBL = "do.SP_DO_GetInvoiceByBL";
        public static string SP_DO_GetPaymentByBL = "do.SP_DO_GetPaymentByBL";
        public static string SP_DO_TransferDOByDoId = "do.SP_DO_TransferDOByDoId";
        public const string SP_DORelease_GetPaging = "do.SP_DORelease_GetPaging";
        /// <summary>
        /// SP_DO_GetDataForTemplate
        /// </summary>
        public const string SP_DO_GetDataForTemplate = "SP_DO_GetDataForTemplate";

        /// <summary>
        /// do.SP_DO_Insert
        /// </summary>
        public static string SP_DO_Insert = "do.SP_DO_Insert";

        /// <summary>
        /// do.SP_DO_Update
        /// </summary>
        public static string SP_DO_Update = "do.SP_DO_Update";

        /// <summary>
        /// do.SP_DO_Cancel
        /// </summary>
        public static string SP_DO_Cancel = "do.SP_DO_Cancel";
        public static string SP_DO_Delete = "do.SP_DO_Delete";
        #endregion

        #region DO Extension
        public const string SP_DOExtensionRequest_GetPaging = "do.SP_DOExtensionRequest_GetPaging";
        public const string SP_DOExtension_GetPaging = "do.SP_DOExtension_GetPaging";
        public static string SP_DO_ExtentionByDOId = "do.SP_DO_ExtentionByDOId";
        public static string SP_DO_TCRById_BL = "do.SP_DO_TCRById_BL";
        #endregion
        
        #region Receipt
        /// <summary>
        /// inv.SP_Receipt_ConfirmPayment
        /// </summary>
        public const string SP_Receipt_ConfirmPayment = "inv.SP_Receipt_ConfirmPayment";
        #endregion

        #region Temporary Collection Request
        /// <summary>
        /// do.SP_TemporaryCollection_Insert
        /// </summary>
        public const string SP_TemporaryCollection_Insert = "do.SP_TemporaryCollection_Insert";
        /// <summary>
        /// do. SP_TemporaryCollectionRequest_Cancel
        /// </summary>
        public const string SP_TemporaryCollectionRequest_Cancel = "do.SP_TemporaryCollectionRequest_Cancel";
       
        #endregion

        #region Role
        public const string SP_RoleName_GetAllByUserName = "SP_RoleName_GetAllByUserName";
        public const string SP_FunctionName_GetAllByRoleID = "SP_RoleFunctionName_GetAllByRoleID";
        public const string SP_RoleFunction_GetByRoleId = "SP_RoleFunction_GetByRoleId";

        #endregion

        #region User Role

        public const string SP_UserRole_GetByUserName = "SP_UserRole_GetByUserName";
        public const string SP_UserRole_Insert = "SP_UserRole_Insert";
        public const string SP_UserRole_InsertByActive = "SP_UserRole_InsertByActive";
        public const string SP_UserRole_CountByUserRole = "SP_UserRole_CountByUserRole";
        public static string SP_UserRole_DeleteByUserName = "SP_UserRole_DeleteByUserName";

        #endregion

        #region Role function

        public const string SP_RoleFunction_DeleteByRoleId = "SP_RoleFunction_DeleteByRoleId";
        public const string SP_RoleFunction_Insert = "SP_RoleFunction_Insert";

        #endregion

        #region Menu Role

        public const string SP_MenuRole_DeleteByRoleId = "SP_MenuRole_DeleteByRoleId";

        #endregion

        #region Common
        /// <summary>
        ///  SP_Common_GetIDs_AN_PI_CDS
        /// </summary>
        public const string SP_Common_GetIDs_AN_PI_CDS = "SP_Common_GetIDs_AN_PI_CDS";
        #endregion

        #region Mail box

        /// <summary>
        /// SP_Mailbox_Insert
        /// </summary>
        public static string SP_Mailbox_Insert = "SP_Mailbox_Insert";

        /// <summary>
        /// SP_Mailbox_GetNotSent
        /// </summary>
        public static string SP_Mailbox_GetNotSent = "SP_Mailbox_GetNotSent";

        /// <summary>
        /// SP_Mailbox_GetPaging
        /// </summary>
        public static string SP_Mailbox_GetPaging = "SP_Mailbox_GetPaging";

        /// <summary>
        /// SP_Mailbox_UpdateSentNumSend
        /// </summary>
        public static string SP_Mailbox_UpdateSentNumSend = "SP_Mailbox_UpdateSentNumSend";

        #endregion

        #region Scan History

        /// <summary>
        /// do.SP_ScanHistory_GetPaging
        /// </summary>
        public static string SP_ScanHistory_GetPaging = "do.SP_ScanHistory_GetPaging";
        
        #endregion

        #region System Setting

        /// <summary>
        /// SP_SystemSetting_GetValue
        /// </summary>
        public static string SP_SystemSetting_GetValue = "SP_SystemSetting_GetValue";

        #endregion

        #region Status 

        /// <summary>
        /// SP_Status_Success
        /// </summary>
        public static string SP_Status_Success = "0";

        /// <summary>
        /// SP_Error_002
        /// </summary>
        public static string SP_Error_002 = "2";

        #endregion

    }
}
