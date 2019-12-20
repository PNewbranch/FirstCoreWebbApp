using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

//lagt till denna
using Microsoft.AspNetCore.Http;



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstCoreWebbApp.Controllers
{
    public class SessionsController : Controller
    {
        // GET: /<controller>/
        public IActionResult LookAt()
        {
            ViewBag.Msg = HttpContext.Session.GetString("KeyName");  //lägger in nyckels får ut värdet... går på timer 10 minuter, timern tickar ner gissning - 
                                                                       //om inaktiv loggar automatiskt ut

            return View();
        }

        public IActionResult SaveSession(string message)
        {
            HttpContext.Session.SetString("KeyName", message);  
            return RedirectToAction("LookAt");
        }


    }
}
