using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanChi.Repository.Interface;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using VanChi.Business.DTO;

namespace VanChi.Business.Concrete.ObjectBusiness
{
    public class APIBusiness : BaseObjectBusiness
    {
        private string API_KEY = @"F8F8E19190FF84EEBFE9B510DC9E812A95F905B99A1595A1814A6E589D0C8671";
        private string BASE_API = "http://localhost:14375";
        public APIBusiness(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
        }

        public async Task<TokenDTO> Auth(string username, string password, string clientId)
        {
            var token = new TokenDTO();
            await Task.Run(() =>
            {
                var _url = $"{BASE_API}/api/token";
                var _user = !string.IsNullOrEmpty(username) ? username : "ibox";
                var _pass = !string.IsNullOrEmpty(password) ? password : "P@ssw0rd@ibox";
                var _clientId = !string.IsNullOrEmpty(clientId) ? clientId : "239d98e4922fb3895e9ae2107cbb5065";
                var client = new HttpClient();
                client.BaseAddress = new Uri(_url);
                client.DefaultRequestHeaders.Add("X-API-KEY", API_KEY);
                var myContent = $"grant_type=password&username={_user}&password={_pass}&client_id={_clientId}";
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = client.GetAsync(_url).Result;
                var contents = response.Content.ReadAsStringAsync().Result;
                token.Token = contents;
            });
            return token;
        }

        public async Task<string[]> GET(string url, string token = "")
        {
            var arr = new string[2];
            await Task.Run(() =>
            {
                var _url = $"{BASE_API}/api/{url}";
                var client = new HttpClient();
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Add("Authorization", $"BEARER {token}");
                var response = client.GetAsync(_url).Result;
                var contents = response.Content.ReadAsStringAsync().Result;
                arr[0] = ((int)response.StatusCode).ToString();
                arr[1] = response.Content.ReadAsStringAsync().Result;
            });

            return arr;
        }
        public async Task<string[]> POST(string url, object value, string token = "")
        {
            var arr = new string[2];
            await Task.Run(() =>
            {
                var _url = $"{BASE_API}/api/{url}";
                var client = new HttpClient();
                client.BaseAddress = new Uri(url);
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Add("Authorization", $"BEARER {token}");
                var myContent = JsonConvert.SerializeObject(value);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = client.PostAsync(_url, byteContent).Result;

                arr[0] = ((int)response.StatusCode).ToString();
                arr[1] = response.Content.ReadAsStringAsync().Result;

            });

            return arr;
        }
        public async Task<string[]> PUT(string url, object value, string token = "")
        {
            var arr = new string[2];
            await Task.Run(() =>
            {
                var _url = $"{BASE_API}/api/{url}";
                var client = new HttpClient();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Add("X-API-KEY", API_KEY);
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Add("Authorization", $"BEARER {token}");
                var myContent = JsonConvert.SerializeObject(value);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = client.PutAsync(_url, byteContent).Result;

                arr[0] = ((int)response.StatusCode).ToString();
                arr[1] = response.Content.ReadAsStringAsync().Result;
            });
            return arr;
        }
        public async Task<string[]> DELETE(string url, string id, string token = "")
        {
            var arr = new string[2];
            await Task.Run(() =>
            {
                var _url = $"{BASE_API}/api/{url}?id={id}";
                var client = new HttpClient();
                client.BaseAddress = new Uri(url);
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Add("Authorization", $"BEARER {token}");
                var response = client.DeleteAsync(url).Result;

                arr[0] = ((int)response.StatusCode).ToString();
                arr[1] = response.Content.ReadAsStringAsync().Result;
            });
            return arr;
        }
    }
}
