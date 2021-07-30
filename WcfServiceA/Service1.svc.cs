using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceA
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public Moviemiento GetMoviemientoPC()
        {
            Random rnd = new Random();
            var db = new dbAEntities();
            var list = db.Moviemientos.ToList();

            int randomId = rnd.Next(1, list.Count);

            var moviemiento = list.Where(x => x.Id == randomId).FirstOrDefault();

            return moviemiento;
        }

        public List<Moviemiento> GetMoviemientos()
        {
            var db = new dbAEntities();
            var list = db.Moviemientos.ToList();
            return list;
        }

        public Palabra GetPalabraRandm()
        {
            Random rnd = new Random();
            var db = new dbAEntities();
            var list = db.Palabras.ToList();

            int randomId = rnd.Next(1, list.Count);

            var palabra = list.Where(x => x.Id == randomId).FirstOrDefault();

            return palabra;
        }

        public List<Palabra> GetPalabras()
        {
            var db = new dbAEntities();
            var list = db.Palabras.ToList();
            return list;
        }

        public Response GetSumPar(string value)
        {
            Response response = new Response();
            if (!String.IsNullOrEmpty(value))
            {
                value = value.Replace(" ", String.Empty);

                string[] subs = value.Split(',');
                int sum = 0;
                foreach (var item in subs)
                {
                    int n;
                    bool isNumber = Int32.TryParse(item, out n);
                    if (isNumber)
                    {
                        if (n > 0)
                        {
                            if (n <= 1000)
                            {
                                if ((n % 2) == 0)
                                {
                                    sum = sum + n;

                                }
                            }
                            else
                            {
                                response.Error = "La cadena no puede contener numeros mayores a mil";
                                response.Result = -1;
                                return response;
                            }
                        }
                        else
                        {
                            response.Error = "La cadena no puede contener numeros negativos";
                            response.Result = -1;
                            return response;
                        }
                    }
                    else
                    {
                        response.Error = "La cadena no puede contener letras";
                        response.Result = -1;
                        return response;
                    }
                }

                response.Error = "";
                response.Result = sum;
                return response;

            }

            response.Error = "Cadena de texto vacia";
            response.Result = -1;
            return response;
        }

        public string InsertMoviemiento(string value)
        {
            var db = new dbAEntities();
           var lastM = db.Moviemientos.OrderByDescending(x => x.Id).FirstOrDefault();

            Moviemiento moviemiento = new Moviemiento();
            moviemiento.Moviemiento1 = value;
            if (lastM != null)
            {
                moviemiento.Id = lastM.Id + 1;
            }
            else
            {
                moviemiento.Id = 1;
            }

            db.Moviemientos.Add(moviemiento);
            db.SaveChanges();

            return "Exito";
        }

        public ResponsePalabra InsertPalabra(string value)
        {
            ResponsePalabra response = new ResponsePalabra();
            Palabra palabra = new Palabra();
            palabra.Palabra1 = value.ToUpper();
            var db = new dbAEntities();

            var lastP = db.Palabras.OrderByDescending(x => x.Id).FirstOrDefault();

            if (lastP != null)
            {
                palabra.Id = lastP.Id + 1;
            }
            else {
                palabra.Id = 1;
            }


            db.Palabras.Add(palabra);
            var r = db.SaveChanges();

            response.Error = false;
            response.Mensaje = "Exito";

            return response;
        }
    }
}
