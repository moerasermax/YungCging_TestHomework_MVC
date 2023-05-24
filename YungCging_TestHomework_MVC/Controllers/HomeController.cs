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
using YungCging_TestHomework_MVC.Models;
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

        public ActionResult YCAction(DataSet_UserData User_Data)
        {
            return View(User_Data);
        }
        [HttpPost]
        public ActionResult YCAction_Create(DataSet_UserData User_Data) 
        {
            
            DataSet_User_CRUD postData = new DataSet_User_CRUD()
            {
                Account = "YC",
                Password = "123",
                Name = "Bboy",
                Age = "18"
            };
            DataSet_ExcuteResult result = Query_API.getInstance().Excute("POST", "Create", postData, HttpContext.Request);
            ViewBag.Message = result.FeedBackMessage;
            return View();
        }
        public ActionResult YCAction_Delete()
        {
            DataSet_User_CRUD postData = new DataSet_User_CRUD()
            {
                Account = "YC",
            };
            DataSet_ExcuteResult result = Query_API.getInstance().Excute("POST", "Delete", postData, HttpContext.Request);
            ViewBag.Message = result.FeedBackMessage;
            return View();
        }
        public ActionResult YCAction_Update()
        {
            DataSet_User_CRUD postData = new DataSet_User_CRUD()
            {
                Account = "YC",
                Password = "123",
                Name = "Bboy",
                Age = "26"
            };
            DataSet_ExcuteResult result = Query_API.getInstance().Excute("POST", "Update", postData, HttpContext.Request);
            ViewBag.Message = result.FeedBackMessage;
            return View();
        }
        public ActionResult YCAction_Read()
        {
            DataSet_User_CRUD postData = new DataSet_User_CRUD()
            {
                Account = "YC",
            };
            DataSet_ExcuteResult result = Query_API.getInstance().Excute("POST", "Read", postData, HttpContext.Request);
            ViewBag.Message = result.FeedBackMessage;
            return View();
        }
    }
}