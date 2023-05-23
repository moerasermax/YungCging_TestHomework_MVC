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
            string url = HttpContext.Request.Url.Host;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            DataSet_User_CRUD  postData = new DataSet_User_CRUD() 
            {
                Account = "YC",
                Password ="123",
                Name ="Bboy",
                Age = "18"
            };

            string postBody = JsonConvert.SerializeObject(postData);//將匿名物件序列化為json字串
            byte[] byteArray = Encoding.UTF8.GetBytes(postBody);//要發送的字串轉為byte[]


            //發出Request
            string responseStr = "";
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