using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VanChi.FMS.Web.Models
{
    public class WebAPIModel
    {
        public int status { get; set; }
        public string message { get; set; }
        public WebAPIModel()
        {
            this.status = 0;
            this.message = string.Empty;
        }
    }
    public class WebAPIExtendModel
    {
        public int status { get; set; }
        public string message { get; set; }
        public string BLNo { get; set; }
        public string voyage { get; set; }
        public WebAPIExtendModel()
        {
            this.status = 0;
            this.message = string.Empty;
            this.BLNo = string.Empty;
            this.voyage = string.Empty;
        }
    }
    public class ArrivalNoticeEntity
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Required(AllowEmptyStrings = false)]
        public DateTime Date { get; set; }
        public string ConsigneeCode { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string NotifyCode { get; set; }
        public string ConsigneeInformation { get; set; }
        [Required]
        public string NotifyInformation { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Vessel { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Voyage { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime ETA { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> ETD { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string BLNo { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string BLType { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string TerminalCode { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string PortOfLoading { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string PortOfDischarge { get; set; }
        public string PlaceOfReceipt { get; set; }
        public string PlaceOfDelivery { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string NumOfContainer { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Weight { get; set; }
        public string Measurement { get; set; }
        [Required(AllowEmptyStrings = false)]
        public List<FreeTimeEntiry> StoFreeTimes { get; set; }
        [Required(AllowEmptyStrings = false)]
        public List<FreeTimeEntiry> DemFreeTimes { get; set; }
        [Required(AllowEmptyStrings = false)]
        public List<ContainerEntity> Containers { get; set; }
    }
    public class FreeTimeEntiry
    {
        [Required(AllowEmptyStrings = false)]
        public string CType { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string FreeTime { get; set; }
    }
    public class TemporaryCollectionRequestEntity
    {
        [Required(AllowEmptyStrings = false)]
        public string DocNo { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string BLNo { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Voyage { get; set; }
        public string IssuedBy { get; set; }
        [Required(AllowEmptyStrings = false)]
        public List<TemporaryChargeEntity> TemporaryCharge { get; set; }
    }
    public class TemporaryChargeEntity
    {
        [Required(AllowEmptyStrings = false)]
        public string ChargeCode { get; set; }
        [Required(AllowEmptyStrings = false)]
        public int Quantity { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Currency { get; set; }
        public Nullable<double> Day { get; set; }
        [Required(AllowEmptyStrings = false)]
        public double Amount { get; set; }
    }
    public class ContainerEntity
    {
        [Required(AllowEmptyStrings = false)]
        public string CNo { get; set; }
        public string SealNo { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string CType { get; set; }
        [Required(AllowEmptyStrings = false)]
        public bool SmartContainer { get; set; }
        [Required(AllowEmptyStrings = false)]
        public bool ReeferContainer { get; set; }
        [Required(AllowEmptyStrings = false)]
        public bool OOG { get; set; }
        [Required(AllowEmptyStrings = false)]
        public bool SOC { get; set; }
        [Required(AllowEmptyStrings = false)]
        public bool Imco { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; }
        [Required(AllowEmptyStrings = false)]
        public double Weight { get; set; }
        public Nullable<double> Measurement { get; set; }
    }
    public class ProformaInvoiceEntity
    {
        [Required(AllowEmptyStrings = false)]
        public string DocNo { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string CustomerCode { get; set; }
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Currency { get; set; }
        [Required]
        public int Type { get; set; }
        [Required]
        public List<LocalChargeEntity> LocalCharge { get; set; }
    }
    public class LocalChargeEntity
    {
        public string CNo { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string ChargeCode { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Currency { get; set; }
        [Required]
        public double AmountInCurrency { get; set; }
        public Nullable<double> VAT { get; set; }
        public Nullable<double> AmountTax { get; set; }
        [Required]
        public double ROE { get; set; }
        [Required]
        public double AmountVND { get; set; }
    }
    public class ContainerDepositSlipEntity
    {
        [Required(AllowEmptyStrings = false)]
        public string DocNo { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string CustomerCode { get; set; }
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Currency { get; set; }
        [Required]
        public List<ContainerDepositChargeEntity> ContainerDepositCharge { get; set; }
    }
    public class ContainerDepositChargeEntity
    {
        public string CNo { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string ChargeCode { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Currency { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        public double AmountVND { get; set; }
        public string Note { get; set; }
    }
    public class DOBaseEntity
    {
        [Required(AllowEmptyStrings = false)]
        public string DONo { get; set; }
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime ArrivalDate { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string BLNo { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Vessel { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Voyage { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string ConsigneeCode { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string TerminalCode { get; set; }
        public string PlaceOfDelivery { get; set; }
        public Nullable<bool> Destuff { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string PlaceOfEmpty { get; set; }
        public string Remarks { get; set; }
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime IssueDate { get; set; }
        [Required]
        public List<ContainerReleaseEntity> ContainerRelease { get; set; }
    }
    public class DOEntity : DOBaseEntity
    {
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime ValidDate { get; set; }
    }
    public class RenewalDOEntity : DOBaseEntity
    {
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime NewValidDate { get; set; }
    }
    public class ContainerReleaseEntity
    {
        [Required(AllowEmptyStrings = false)]
        public string CNo { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string SealNo { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string CType { get; set; }
        [Required]
        public bool SmartContainer { get; set; }
        [Required]
        public bool ReeferContainer { get; set; }
        [Required]
        public bool OOG { get; set; }
        [Required]
        public bool SOC { get; set; }
        [Required]
        public bool Imco { get; set; }
        [Required(AllowEmptyStrings = false)]
        public Nullable<int> Number { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }
        [Required(AllowEmptyStrings = false)]
        public double Weight { get; set; }
        public Nullable<double> Measurement { get; set; }
    }
    public class ReceiptDetailEntity
    {
        [Required(AllowEmptyStrings = false)]
        public string DocNo { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string BLNo { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Voyage { get; set; }
        [Required(AllowEmptyStrings = false)]
        public double Amount { get; set; }
    }
    public class UnmatchReceiptDetailEntity
    {
        [Required(AllowEmptyStrings = false)]
        public string DocNo { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string BLNo { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Voyage { get; set; }
    }
}