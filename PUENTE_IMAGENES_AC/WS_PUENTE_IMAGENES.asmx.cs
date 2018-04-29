using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using InfoMonitor;

namespace PUENTE_IMAGENES_AC
{
    /// <summary>
    /// Summary description for WS_PUENTE_IMAGENES
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_PUENTE_IMAGENES : System.Web.Services.WebService
    {

        [WebMethod]
        public string ENLACE(string usuarioWin, string contrasenaWin, string idTramite, string idExpedientes, string nss, byte[] archivo)
        {
            pivalint002.WS_RECIBEIMAGENES_WD webService = new pivalint002.WS_RECIBEIMAGENES_WD();
            string usuario = ConfigurationManager.AppSettings.Get("userWinston").ToString();
            string contraseña = ConfigurationManager.AppSettings.Get("pswWinston").ToString();
            string respuesta=string.Empty;

            if (usuario == usuarioWin && contraseña == contrasenaWin)
            {
                Monitor monitor = new Monitor();

                monitor.SaveLog(usuarioWin, idTramite, nss, idExpedientes, "servicio ejecutado");
                //Byte[] archivo = System.IO.File.ReadAllBytes(@"C:\Users\ymat001\Downloads\libera.zip");
                string resp = monitor.SaveRequest("ymat001", "1", "23456787890", "223344", archivo);


                //OBTENEMOS RESPUESTA DEL WEB SERVICE 2 Y LA ASIGNAMOS A VARIABLE PARA MOSTRARLA EN ALERTA A WINSTON
                respuesta = webService.RECIBE(archivo, usuarioWin, contrasenaWin, idTramite, idExpedientes, nss);
                return respuesta;


            }
            return "02 Usuario o contraseña incorrectos";
        }
    }
}
