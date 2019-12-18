using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstCoreWebbApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreWebbApp.Controllers
{
    public class ReadViewsController : Controller
    {
        public IActionResult Index()
        {
            ////lägg till denna
            //ViewBag.ReviewList = new List<string>
            //{
            //    "Ica",
            //    "Maxi",
            //    "Coop"
            //};

            ViewBag.ReviewList = Review.reviewsList;
            
            return View();
        }


        //kommer till createviewn får en text och submitt
        [HttpGet]
        public IActionResult Create()
        {
                 return View();
        }

        //texten skickas upp hit
        //Methodoveerload tar empot en string som heter "info"
        [HttpPost]
        public IActionResult Create(string info)
        {
            if (string.IsNullOrWhiteSpace(info))
            {
                ViewBag.Msg = "You must enter a text.";
                return View();
            }
            else
            {
                //här sparar vi våran review, utvärderingar
                Review.reviewsList.Add(new Review() { Info = info });

                //nu vill vi kolla att den blev tillagd.
                return RedirectToAction("Index");
            }
            
            //denna returnen sätts med ovan.
            //return View();
        }


    }
}