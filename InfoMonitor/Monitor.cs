using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace InfoMonitor
{
    public class Monitor
    {
        public string SaveRequest(string IdUsuario, string IdTramite, string NSS, string idExpediente, byte[] ArchivoZip, string nombreLog)
        {
            //Byte[] ArchivoZip    log de sucesos cuando causa error.
            try
            {
                string PathExp = ConfigurationManager.AppSettings["PathLog"].ToString() + "\\Expediente_" + idExpediente + "_" + NSS + "_" + IdTramite;

                if (!System.IO.Directory.Exists(PathExp))
                {
                    System.IO.Directory.CreateDirectory(PathExp);
                }

                File.WriteAllBytes(PathExp + "\\Expediente_" + DateTime.Now.ToString("ddMMyyyy") + "_" + DateTime.Now.ToString("hmmss") + ".zip", ArchivoZip);
                string rutaLog = ConfigurationManager.AppSettings["PathLog"].ToString() + "\\Log_" + DateTime.Now.ToString("ddMMyyyy");

                if (!System.IO.Directory.Exists(rutaLog))
                {
                    System.IO.Directory.CreateDirectory(rutaLog);
                }
                
                using (StreamWriter sw = new StreamWriter(rutaLog + "\\" + nombreLog + ".txt", true, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine("Request|" + IdUsuario + "|" + NSS + "|" + idExpediente + "|" + PathExp + "\\Expediente_" + DateTime.Now.ToString("ddMMyyyy") + "_" + DateTime.Now.ToString("hmmss") + ".zip" + "|" + DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("h:mm:ss"));
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                return "ERROR|" + ex.Message.ToString();
            }

            return "OK|Servicio ejecutado correctamente.";

        }

        public string SaveLog(string IdUsuario, string IdTramite, string NSS, string idExpediente, string text, string nombreLog)
        {
            //Byte[] ArchivoZip    log de sucesos cuando causa error.
            try
            {
                string rutaLog = ConfigurationManager.AppSettings["PathLog"].ToString() + "\\Log_" + DateTime.Now.ToString("ddMMyyyy");

                if (!System.IO.Directory.Exists(rutaLog))
                {
                    System.IO.Directory.CreateDirectory(rutaLog);
                }

                using (StreamWriter sw = new StreamWriter(rutaLog + "\\" + nombreLog + ".txt", true, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine("Log|" + IdUsuario + "|" + NSS + "|" + idExpediente + "|" + text + "|" + DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("h:mm:ss"));
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                return "ERROR|" + ex.Message.ToString();
            }

            return "OK|Servicio ejecutado correctamente.";
        }

        public string SaveLog(string mensaje, string text, string nombreLog)
        {
            //Byte[] ArchivoZip    log de sucesos cuando causa error.
            try
            {
                string rutaLog = ConfigurationManager.AppSettings["PathLog"].ToString() + "\\Log_" + DateTime.Now.ToString("ddMMyyyy");

                if (!System.IO.Directory.Exists(rutaLog))
                {
                    System.IO.Directory.CreateDirectory(rutaLog);
                }

                using (StreamWriter sw = new StreamWriter(rutaLog + "\\" + nombreLog + ".txt", true, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine( "Resultado WS|" + text + "|" + mensaje+ "|" + DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("h:mm:ss") + Environment.NewLine);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                return "ERROR|" + ex.Message.ToString();
            }

            return "OK|Servicio ejecutado correctamente.";
        }

    }
}
