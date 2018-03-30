using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginApp.Models;

namespace LoginApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string client_id, string secret)
        {
            System.Console.WriteLine(client_id);
            System.Console.WriteLine(secret);

            if(CheckReferer(this.Request.Headers["Referer"].ToString()) && CheckClient(client_id, secret) ) {
                return View();
            } else {
                return Redirect("Error");
                Redirect
            }    
        }

        private bool CheckReferer(string redirectRef)
        {
            System.Console.WriteLine(redirectRef);
            return redirectRef.Equals("http://localhost:9090/");
        }

        private bool CheckClient(string client_id, string secret)
        {
            if(client_id == "abcdedg" && secret == "123456") {
                return true;
            } else {
                return false;
            }
        }


        public IActionResult Error()
        {
            return View();
        }
    }
}
