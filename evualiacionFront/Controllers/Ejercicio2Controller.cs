using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceReference;
using evualiacionFront.ViewModels;

namespace evualiacionFront.Controllers
{
   
    public class Ejercicio2Controller : Controller
    {
        private Service1Client Service1Client = new Service1Client();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult comprobarHandler(Ejercicio2ViewModel data)
        {
            repos repos = new repos();
            Service1Client service1Client = new Service1Client();
            Random rnd = new Random();

            var res = service1Client.GetMoviemientosAsync().Result;

            int randomId = rnd.Next(1, 4);

            var moviemientoPc = res.Where(x => x.Id == randomId).FirstOrDefault();

            repos.ok = true;
            repos.mensaje = "";

            //Gana pc
            if (moviemientoPc.Moviemiento1 == "Tijera" && data.opcion == "Papel")
            {
                repos.mensaje = "opcion pc: Tijera - Opcion Humano: Papel, Ganador Pc";
                return Json(repos);
            }

            if (moviemientoPc.Moviemiento1 == "Piedra" && data.opcion == "Tijera")
            {
                repos.mensaje = "opcion pc: Piedra - Opcion Humano: Tijera, Ganador Pc";
                return Json(repos);
            }

            if (moviemientoPc.Moviemiento1 == "Papel" && data.opcion == "Piedra")
            {
                repos.mensaje = "opcion pc: Papel - Opcion Humano: Piedra, Ganador Pc";
                return Json(repos);
            }

            //Gana humano
            if (data.opcion == "Tijera" && moviemientoPc.Moviemiento1 == "Papel")
            {
                repos.mensaje = "opcion pc: Papel - Opcion Humano: Tijera, Ganador Humano";
                return Json(repos);
            }

            if (data.opcion == "Piedra" && moviemientoPc.Moviemiento1 == "Tijera")
            {
                repos.mensaje = "opcion pc: Tijera - Opcion Humano: Piedra, Ganador Humano";
                return Json(repos);
            }

            if (data.opcion == "Papel" && moviemientoPc.Moviemiento1 == "Piedra")
            {
                repos.mensaje = "opcion pc: Piedra - Opcion Humano: Papel, Ganador Humano";
                return Json(repos);
            }

            if (data.opcion == moviemientoPc.Moviemiento1)
            {
                repos.mensaje = String.Format("opcion pc: {0} - Opcion Humano: {1}, Empate", moviemientoPc.Moviemiento1, data.opcion);
                return Json(repos);
            }

            return Json(repos);
        }

        public class repos
        {
            public bool ok { get; set; }

            public string mensaje { get; set; }
        }
    }
}
