using VanChi.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanChi.Business.Interface
{
    public partial interface IBusiness
    {
        Task<TokenDTO> API_AUTH(string username, string password, string clientId);
        Task<string[]> API_GET(string url, string token = "");
        Task<string[]> API_POST(string url, object value, string token = "");
        Task<string[]> API_PUT(string url, object value, string token = "");
        Task<string[]> API_DELETE(string url, string value, string token = "");
    }
}
