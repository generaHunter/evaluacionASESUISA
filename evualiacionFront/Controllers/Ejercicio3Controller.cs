using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceReference;

namespace evualiacionFront.Controllers
{
    public class Ejercicio3Controller : Controller
    {
        private Service1Client Service1Client = new Service1Client();
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult GetPalabra()
        {
            var palabra = Service1Client.GetPalabraRandmAsync().Result;
            return new JsonResult(palabra);
        }
    }
}
