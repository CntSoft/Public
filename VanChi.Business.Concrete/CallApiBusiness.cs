using VanChi.Business.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VanChi.Business.DTO;
using VanChi.Business.Concrete.ObjectBusiness;

namespace VanChi.Business.Concrete
{
    public partial class Business : IBusiness
    {
        public async Task<TokenDTO> API_AUTH(string username, string password, string clientId)
        {
            return await new APIBusiness(this.UnitOfWork).Auth(username, password, clientId);
        }
        public async Task<string[]> API_GET(string url, string token = "")
        {
            return await new APIBusiness(this.UnitOfWork).GET(url, token);
        }
        public async Task<string[]> API_POST(string url, object value, string token = "")
        {
            return await new APIBusiness(this.UnitOfWork).POST(url, value, token);
        }
        public async Task<string[]> API_PUT(string url, object value, string token = "")
        {
            return await new APIBusiness(this.UnitOfWork).PUT(url, value, token);
        }
        public async Task<string[]> API_DELETE(string url, string id, string token = "")
        {
            return await new APIBusiness(this.UnitOfWork).DELETE(url, id, token);
        }
    }
}
