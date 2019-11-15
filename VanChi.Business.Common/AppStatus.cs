using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanChi.Business.Common
{
    public enum CustomerStatus : byte
    {
        Pending = 0,
        Approved = 1,
        Actived = 2,
        Rejected = 3
    }
    public enum BLStatus : byte
    {
        Pending = 0,
        SentDORequest = 1,
        ConfirmedDORequest = 2,
        RejectDORequest = 3,
        Cancelled = 4
    }
    public enum ANStatus : byte
    {
        NotSend = 1,
        Sent = 2,
        Cancelled = 3
    }
    public enum PIStatus : byte
    {
        Sent = 0,
        Confirmed = 1,
        Rejected = 2
    }
    public enum DOStatus : byte
    {
        Pending = 0,
        Transfer = 1,
        Release = 2,
        Return = 3
    }
    public enum TCRStatus : byte
    {
        SentByConsignee = 0,
        SentByIBOX = 1,
        Confirmed = 2,
        Extend = 3,
        Rejected = 4
    }

    public enum PaymentStatus : byte
    {
        Sent = 0,
        Confirmed = 1,
        Rejected = 2
    }

    public enum EInvoiceStatus : byte
    {
        Sent = 0,
        Completed = 1,
        Rejected = 2,
        Matched = 3,
        NotMatched = 4
    }
    public enum MailboxStatus : byte
    {
        NotSent = 0,
        Sent = 1
    }
}
