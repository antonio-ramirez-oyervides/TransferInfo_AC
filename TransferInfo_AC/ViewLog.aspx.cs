using System;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;

namespace TransferInfo_AC
{
    public partial class ViewLog : System.Web.UI.Page
    {
        public string tabla;

        protected void btnConsultaExp_Click(object sender, EventArgs e)
        {
            try
            {
                string PathExp = ConfigurationManager.AppSettings["PathLog"].ToString();

                if (txtExpediente.Text.Trim() == string.Empty)
                {
                    tabla = "Favor de escribir el id del expediente.";
                    return;
                }

                string[] carpetas = Directory.GetDirectories(PathExp.Replace("\\\\", "\\"), "Expediente_" + txtExpediente.Text + "*");

                if (carpetas.GetLength(0) > 0)
                {
                    if (carpetas.GetLength(0) == 1)
                    {
                        tabla = "Se encontrarón los siguientes expedientes cargados en " + carpetas[0].ToString() + ":<br>";
                        string[] archivos = Directory.GetFiles(carpetas[0].ToString());

                        foreach (string ab in Directory.GetFiles(HttpContext.Current.Server.MapPath("tmp")))
                        {
                            File.Delete(ab);
                        }

                        foreach (string archivo in archivos)
                        {
                            FileInfo arch = new System.IO.FileInfo(archivo);
                            tabla = tabla + "<a href=\"tmp\\" + arch.Name + "\">" + arch.Name + "</a><br>";
                            File.Copy(archivo, HttpContext.Current.Server.MapPath("tmp") + "\\" + arch.Name, true);
                            // tabla = tabla +  "<a href=\"tmp\\" +    arch.Name + ">" +  arch.Name + "    </a><br>";               
                        }
                    }
                    else
                    {
                        tabla = "Favor de escribir el id correctamente.";
                    }
                }
                else
                {
                    tabla = "No se encontrarón expedientes con ese id";
                }
            }
            catch
            {
                tabla = "Error en la búsqueda, favor de reintentar...";
            }
        }

        protected void btnVerLog_Click(object sender, EventArgs e)
        {
            try
            {
                string PathExp = ConfigurationManager.AppSettings["PathLog"].ToString();
                string archivo = PathExp.Replace("\\\\", "\\") + "\\Log_" + txtfecha.Text.Trim() + "\\log.txt";

                if (File.Exists(archivo))
                {
                    txtlog.Text = File.ReadAllText(archivo);

                    string input = txtlog.Text;
                    string pattern = @"\bResultado WS\b";
                    var matches = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);
                    txtCuenta.Text = String.Format("{0} Registros encontrados.", matches.Count.ToString());
                }
                else
                {
                    txtlog.Text = "No se encontró log con la información capturada." + archivo;
                }
            }
            catch
            {
                txtlog.Text = "Error al visualizar el log...";
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            string fecha = String.Format("{0:dd/MM/yyyy}", DateTime.Now.ToShortDateString());
            
        }
    }
}