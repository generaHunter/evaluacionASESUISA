using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceReference;
using evualiacionFront.ViewModels;
using ServiceReference;

namespace evualiacionFront.Controllers
{
    public class Ejercicio1Controller : Controller
    {
        private Service1Client Service1Client = new Service1Client();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SumHandler(Ejericio1ViewModel data)
        {
            repos repos = new repos();
            Service1Client service1Client = new Service1Client();
            var res =  service1Client.GetSumParAsync(data.numeros).Result;
            repos.mensaje = res.Error;
            repos.ok = true;
            repos.sum = res.Result;
            return Json(repos);
        }

        public class repos
        {
            public bool ok { get; set; }
            public int sum { get; set; }

            public string mensaje { get; set; }
        }
    }
}
