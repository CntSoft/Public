using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanChi.Business.Common
{
    /// <summary>
    /// Module
    /// </summary>
    public enum AppModule
    {
        /// <summary>
        /// Login, Logout
        /// </summary>
        Logons = 1,
        /// <summary>
        /// Quản lý hệ thống
        /// </summary>
        SystemManagement = 2,
        /// <summary>
        /// Quản lý khách hàng
        /// </summary>
        CustomerManagement = 3,
        /// <summary>
        /// Quản lý người dùng
        /// </summary>
        UserManagement = 4,
        /// <summary>
        /// Quản lý thông báo đến
        /// </summary>
        ArrivalNoticeManagement = 5,
        /// <summary>
        /// Quản lý lệnh giao hàng
        /// </summary>
        DOManagement = 6,
        /// <summary>
        /// Quản lý hóa đơn
        /// </summary>
        ProformaInvoiceManagement = 7,
        /// <summary>
        /// Quản lý cước cọc công
        /// </summary>
        ContainerDepositSlipManagement = 8,
        /// <summary>
        /// Yêu cầu hóa đơn
        /// </summary>
        EInvoiceRequest = 9,
        /// <summary>
        /// IBOX
        /// </summary>
        IBOX = 10,
        /// <summary>
        /// Quản lý danh mục
        /// </summary>
        CategoryManagement = 11
    }
}
