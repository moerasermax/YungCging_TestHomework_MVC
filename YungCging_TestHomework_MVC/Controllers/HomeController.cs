using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using YungChing_TestHomeWork_Client.DataSet;

namespace YungCging_TestHomework_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.Test = "Hello";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult YCAction()
        {
            ViewBag.Message = "YH";
            return View();
        }

        public ActionResult YCAction_Post() 
        {
            string hostname = HttpContext.Request.Url.Host;
            string port = HttpContext.Request.Url.Port.ToString();

            string API_CreateUser_URL = string.Format("http://{0}:{1}/api/User/Create", hostname,port);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(API_CreateUser_URL);
            request.Method = "POST";
            request.ContentType = "application/json";



            DataSet_User_CRUD postData = new DataSet_User_CRUD()
            {
                Account = "YC",
                Password = "123",
                Name = "Bboy",
                Age = "18"
            };

            string postBody = JsonConvert.SerializeObject(postData);//將匿名物件序列化為json字串
            byte[] byteArray = Encoding.UTF8.GetBytes(postBody);//要發送的字串轉為byte[]

            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(byteArray, 0, byteArray.Length);
            }//end using




            //發出Request
            string responseStr = "";
            HttpWebResponse response1 = (HttpWebResponse)request.GetResponse();

            using (WebResponse response = request.GetResponse())
            {

                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    responseStr = reader.ReadToEnd();
                }

            }


            return View();
        }


    }
}