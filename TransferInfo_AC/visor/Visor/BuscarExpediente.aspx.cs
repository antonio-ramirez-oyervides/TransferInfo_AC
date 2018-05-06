using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BuscarExpediente : System.Web.UI.Page
{
    public string tabla = "";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        try
        {






            string PathExp = System.Configuration.ConfigurationSettings.AppSettings["PathLog"].ToString();

            if (txtExpediente.Text.Trim() == string.Empty)
            {

                tabla = "Favor de escribir el id del expediente.";



                return;

            }


            string condicion = "*" + txtExpediente.Text + "*";


            string[] carpetas = System.IO.Directory.GetDirectories(PathExp, condicion);



            if (carpetas.GetLength(0) > 0)
            {

                if (carpetas.GetLength(0) == 1)
                {

                    tabla = "Se encontrarón los siguientes expedientes cargados en " + carpetas[0].ToString() + ":<br>";


                    string[] archivos = System.IO.Directory.GetFiles(carpetas[0].ToString());


                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(carpetas[0].ToString());
              




                    foreach (string archivo in archivos)
                    {

                        System.IO.FileInfo arch = new System.IO.FileInfo(archivo);

                        tabla = tabla + "<a href=\"VisorExpediente.aspx?carpeta=" + di.Name + "&archivo=" + arch.Name + "\">" + arch.Name + "</a><br>";

              

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
        catch( Exception ex)
        {


            tabla = "Error en la búsqueda, favor de reintentar..." + ex.Message.ToString();



        }






    }
}