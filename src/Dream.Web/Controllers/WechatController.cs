using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Dream.Web.Controllers
{
    public class WechatController : Controller
    {
        public IActionResult Index()
        {
            var jsonResult = GetAccessToken("wx5fd56846a94a3375", "625e809525b77d3b3fb9d415fdab190a").GetAwaiter().GetResult();
            var result = ParseJson(jsonResult, "root");
            ViewData["access_token"] = result;

            return View();
        }

        public async Task< string> GetAccessToken(string appId, string appSecret)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", appId, appSecret);
            string result = await GetDataAsync(url);
            return result;

        }
        public async Task<string> GetDataAsync(string url)
        {
            return await SendGetHttpRequestAsync(url, "application/x-www-form-urlencoded");
        }
        public async Task<string> SendGetHttpRequestAsync(string url, string contentType)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = contentType;
            string result = string.Empty;
            using (WebResponse response = await request.GetResponseAsync())
            {
                if (response != null)
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            result = reader.ReadToEnd();
                        }
                    }
                }
            }
            return result;
        }
        public XDocument ParseJson(string json, string rootName)
        {
            return JsonConvert.DeserializeXNode(json, rootName);
        }

        //public void JsonConvertObject(string json)
        //{
        //    return JsonConvert.DeserializeObject<>(json);
            
        //}

        

    }
}