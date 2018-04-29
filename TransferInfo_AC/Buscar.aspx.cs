using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class Buscar : System.Web.UI.Page
{
    public string tabla;

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



            string[] carpetas = System.IO.Directory.GetDirectories(PathExp.Replace("\\\\", "\\"), "Expediente_" + txtExpediente.Text + "*");



            if (carpetas.GetLength(0) > 0)
            {

                if (carpetas.GetLength(0) == 1)
                {

                    tabla = "Se encontrarón los siguientes expedientes cargados en " + carpetas[0].ToString() + ":<br>";


                    string[] archivos = System.IO.Directory.GetFiles(carpetas[0].ToString());



                    foreach (string ab in System.IO.Directory.GetFiles(HttpContext.Current.Server.MapPath("tmp")))
                    {

                        System.IO.File.Delete(ab);


                    }




                    foreach (string archivo in archivos)
                    {

                        System.IO.FileInfo arch = new System.IO.FileInfo(archivo);

                        tabla = tabla + "<a href=\"tmp\\" + arch.Name + "\">" + arch.Name + "</a><br>";



                        System.IO.File.Copy(archivo, HttpContext.Current.Server.MapPath("tmp") + "\\" + arch.Name, true);


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
        catch {


            tabla = "Error en la búsqueda, favor de reintentar...";

        
        
        }







       
    } // del metodo












    protected void Button2_Click(object sender, EventArgs e)
    {

        try
        {
            
            string PathExp = System.Configuration.ConfigurationSettings.AppSettings["PathLog"].ToString();
             string archivo = PathExp.Replace("\\\\","\\") + "\\Log_" + txtfecha.Text.Trim() + "\\log.txt";

            if (System.IO.File.Exists(archivo))
            {
                TextBox1.Text = System.IO.File.ReadAllText(archivo);

            }
            else {

                TextBox1.Text = "No se encontró log con la información capturada." + archivo;

            
            }


        }
        catch {

            TextBox1.Text = "Error al visualizar el log...";
        
        
        
        }




    }
} //de la clase