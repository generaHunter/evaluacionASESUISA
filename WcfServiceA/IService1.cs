using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceA
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Response GetSumPar(string value);

        [OperationContract]
        string InsertMoviemiento(string value);

        [OperationContract]
        ResponsePalabra InsertPalabra(string value);


        [OperationContract]
        List<Moviemiento> GetMoviemientos();

        [OperationContract]
        Moviemiento GetMoviemientoPC();

        [OperationContract]
        List<Palabra> GetPalabras();

        [OperationContract]
        Palabra GetPalabraRandm();


        // TODO: agregue aquí sus operaciones de servicio
    }

    [DataContract]
    public class Response
    {
        int result = 0;
        string error = "";

        [DataMember]
        public int Result
        {
            get { return result; }
            set { result = value; }
        }

        [DataMember]
        public string Error
        {
            get { return error; }
            set { error = value; }
        }
    }

    [DataContract]
    public class ResponsePalabra
    {
        Boolean error = false;
        string mensaje = "";

        [DataMember]
        public Boolean Error
        {
            get { return error; }
            set { error = value; }
        }

        [DataMember]
        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }
    }

}
