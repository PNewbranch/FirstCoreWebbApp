using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using FirstCoreWebbApp.Models;      //för att se classen - skall finnas i controllern och i viewreport

namespace FirstCoreWebbApp.Controllers
{
    public class CarsController : Controller
    {

        public IActionResult Index() //List
        {
            return View(Car.carList);              //måste lägga till using för models som är en 
        }

        [HttpGet]  //steg 1 - en get - vi hämtar formulärsdian att skapa
        public IActionResult Create()  //steg två skapa denna Add View
        {
            return View();
        }

        [HttpPost]  //steg 1 - en get - vi hämtar formulärsdian att skapa
        public IActionResult Create(CarViewModel carViewModel)  //steg två skapa denna Add View 

        //VI KASTAR IN CAR MODEL - VI MÅSTE ÄNDRA DETTA I carCreate


        {
            if (ModelState.IsValid) //om ok
            {
                Car.carList.Add(    //lägg till bilen
                    new Car()
                    {
                        Brand = carViewModel.Brand,
                        ModelName = carViewModel.ModelName
                    });

                return RedirectToAction("Index"); //går tillbaka tll vyn
            }

            return View(); //annart gå tillbaka till vyn
        }

        public IActionResult Details()
        {
            return View();
        }


        public IActionResult Remove()
        {
            return View();
        }

    }
}