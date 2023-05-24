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
        public ActionResult YCAction_Controller(DataSet_UserData User_Data, string submit)
        {
            DataSet_User_CRUD postData = new DataSet_User_CRUD()
            {
                Account = User_Data.Account,
                Password = User_Data.Password,
                Name = User_Data.Name,
                Age = User_Data.Age
            };
            string result = "未處理";
            switch ((Action_Flow)Enum.Parse(typeof(Action_Flow),submit))
            {
                case Action_Flow.CreateUser:
                     result = YCAction_Create(postData);
                    break;
                case Action_Flow.ReadUser:
                    result = YCAction_Read(postData);
                    break;
                case Action_Flow.UpdateUser:
                    result = YCAction_Update(postData);
                    break;
                case Action_Flow.DeleteUser:
                    result = YCAction_Delete(postData);
                    break;
                default:
                    break;
            }
            ViewBag.Message = result;
            return View();
        }


        public string YCAction_Create(DataSet_User_CRUD postData)
        {
            DataSet_ExcuteResult result = Query_API.getInstance().Excute("POST", "Create", postData, HttpContext.Request);
            return result.FeedBackMessage;
        }
        public string YCAction_Delete(DataSet_User_CRUD postData)
        {

            DataSet_ExcuteResult result = Query_API.getInstance().Excute("POST", "Delete", postData, HttpContext.Request);
            return result.FeedBackMessage;
        }
        public string YCAction_Update(DataSet_User_CRUD postData)
        {
            DataSet_ExcuteResult result = Query_API.getInstance().Excute("POST", "Update", postData, HttpContext.Request);
            return result.FeedBackMessage;
        }
        public string YCAction_Read(DataSet_User_CRUD postData)
        {
            DataSet_ExcuteResult result = Query_API.getInstance().Excute("POST", "Read", postData, HttpContext.Request);
            return result.FeedBackMessage;
        }


        enum Action_Flow
        {
            CreateUser,
            ReadUser,
            UpdateUser,
            DeleteUser
        }
    }
}