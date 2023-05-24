using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using YungChing_TestHomeWork_Client.DataSet;

namespace YungCging_TestHomework_MVC.Models
{
    public class DataSet_UserData
    {
        [Required]
        public  string Account { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Age { get; set; }
    }
}