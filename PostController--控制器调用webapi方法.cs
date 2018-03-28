using MVC5Test.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MVC5Test.Controllers
{
    public class PostController : ApiController
    {
        string url = "http://172.16.75.25:8090/api/My/";

        public void GetPort()
        {
            try
            {
                string result = WebRequestHelper.GetRequest(url);

                Models.JsonResult jr = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.JsonResult>(result);

                var a = jr.Head.Status;
            }
            catch(Exception ex)
            {
                var b = ex;
            }
        }
    }

    public class WebRequestHelper
    {
        public static string GetRequest(string url)
        {
            //请求地址为空
            string responseStr = string.Empty;
            //创建获取请求得Model中WebRequest类的变量；相当于创建一个数据库连接
            WebRequest request = WebRequest.Create(url);
            //request的请求方式为Get，同时Method字段赋值为Get
            request.Method = "Get";
            //获取返回的数据；相当于从数据库中获取值，赋值给response变量
            var response = request.GetResponse();
            //ReceiveStream获取GetResponseStream()返回的数据流
            Stream ReceiveStream = response.GetResponseStream();

            using (StreamReader stream = new StreamReader(ReceiveStream, Encoding.UTF8))
            {
                //将获取的数据流进行编码；转换成一个字符串
                responseStr = stream.ReadToEnd();
            }

            return responseStr;
        }


       
    }
}