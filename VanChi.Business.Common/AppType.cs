using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanChi.Business.Common
{
    public sealed class AppType
    {
        public enum EInvoice : byte
        {
            EInvoice = 0,
            EInvoiceRequest = 1
        }
        public enum Payment : byte
        {
            Payment = 0,
            DebitNotes = 1
        }
        public enum ProformaInvoice : byte
        {
            PININL = 1,
            PDMINV = 2
        }
        public enum Receipt : byte
        {
            Confirm = 1,
            Match = 2,
            Unmatch = 3
        }

        public enum BLTypeE : byte
        {
            None = 0,
            OBL = 1,
            SWB = 2,
            Telex = 3
        }
        public enum FreeTime : int
        {
            DemFreeTime = 1,
            StoFreeTime = 2
        }
        public enum SenderOfMail : byte
        {
            None = 0,
            MSC = 1,
            Consignee = 2,
            /// <summary>
            /// Thông báo nhận DO thành công từ hệ thống IBOX cho consignee.
            /// </summary>
            DO_IBOXToConsignee = 3,
            /// <summary>
            /// Thông báo đã phát hành hóa đơn cho Consignee.
            /// </summary>
            EInvoice_ToConsignee = 4,
            /// <summary>
            /// Từ chối yêu cầu xuất hóa đơn đến Consignee.
            /// </summary>
            EInvoice_RefuseToConsignee = 5,
            DO_RequsetToConsignee = 6,
            /// <summary>
            /// Gởi email thông báo cho MSC staff.
            /// </summary>
            DO_RequsetToMSC = 7,
            DO_TransferToConsigne = 8,
            /// <summary>
            /// Gởi File E-Do cho Terminal.
            /// </summary>
            DO_TransferToMSC = 9,
            /// <summary>
            /// Gởi email thông báo cho Consignee đủ điều kiện để thực hiện DO Request.
            /// </summary>
            DO_ReleaseToConsignee = 10,
            /// <summary>
            /// Gởi email thông báo cho Counter Team(BL đã sẵn sàng phát hành DO)
            /// </summary>
            DO_ReleaseToMSC = 11

        }
        public enum Resend : byte
        {
            Notify = 1,
            Consignee = 0,
            ImportTeam = 2

        }
        public enum ChargeCode : int
        {
            LocalCharge = 1,
            TemporaryCharge = 2,
            ContainerDepositCharge = 3
        }

        public enum ActionView
        {
            Index = 0,
            Insert = 1,
            Edit = 2,
            Detail = 3,
            Delete = 4,
            Confirm = 5,
            Approve = 6
        }
        public enum Reason : byte
        {
            ProformaInvoice = 1,
            EInvoice = 2
        }
        public enum HavePortal : byte
        {
            No = 0,
            Yes = 1
        }
        public enum Container : byte
        {
            Release = 0,
            Return = 1
        }
        public enum ActionInsertOrRenewDO : byte
        {
            Insert = 0,
            Renew = 1
        }
        public enum ViewDoExtension : byte
        {
            Request = 0,
            Extended = 1
        }
        public enum ScanHistory : byte
        {
            Release = 0,
            Return = 1
        }

    }
}
