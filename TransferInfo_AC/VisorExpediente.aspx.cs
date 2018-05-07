using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TransferInfo_AC
{
    public partial class VisorExpediente : System.Web.UI.Page
    {
        public string java = "";
        public string html = "";
        public string archivoZIP = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            //Consultar los archivos del folder
            string pathZips = ConfigurationManager.AppSettings["PathLog"].ToString() + "\\" + Request["carpeta"].ToString();

            //@"C:\Users\ymat001\Documents\carpeta";    //definirse web.config 


            archivoZIP = Request["archivo"].ToString();    //Exp1.zip con folder  y   sin folder  expzip.zip  viene request






            string carpetaInterna = "";   // si tiene folder adentro para formar el path de lectura de archivos si aplica

            string carpetaDescomp = archivoZIP.Replace(".zip", "");



            // Descomprimir

            ZipFile zip = new ZipFile(pathZips + "\\" + archivoZIP);

            if (!System.IO.Directory.Exists(pathZips + "\\" + carpetaDescomp))
            {
                System.IO.Directory.CreateDirectory(pathZips + "\\" + carpetaDescomp);
            }
            else
            {


                //try
                //{
                //    foreach (string archivoborra in System.IO.Directory.GetFiles(pathZips + "\\" + carpetaDescomp))
                //    {

                //        System.IO.File.Delete(archivoborra);
                //    }


                //    System.IO.Directory.Delete(pathZips + "\\" + carpetaDescomp);
                //}
                //catch { 


                //}


                if (!System.IO.Directory.Exists(pathZips + "\\" + carpetaDescomp))
                {
                    System.IO.Directory.CreateDirectory(pathZips + "\\" + carpetaDescomp);
                }

            }
            zip.ExtractAll(pathZips + "\\" + carpetaDescomp, ExtractExistingFileAction.OverwriteSilently);


            if (System.IO.Directory.GetDirectories(pathZips + "\\" + carpetaDescomp).GetLength(0) == 1)
            {

                foreach (string carpetainterabuscada in System.IO.Directory.GetDirectories(pathZips + "\\" + carpetaDescomp))
                {

                    System.IO.DirectoryInfo fold = new System.IO.DirectoryInfo(carpetainterabuscada);

                    carpetaInterna = fold.Name;
                }
            }




            string carpeta = pathZips + "\\" + carpetaDescomp;

            if (carpetaInterna != string.Empty)
            {

                carpeta = pathZips + "\\" + carpetaDescomp + "\\" + carpetaInterna;
            }

            string tipoarch = "";


            foreach (string archivo in System.IO.Directory.GetFiles(carpeta))
            {

                System.IO.FileInfo documento = new System.IO.FileInfo(archivo);
                tipoarch = "";
                if (documento.Extension.ToLower().Replace(".", "") == "pdf") { tipoarch = "pdf"; }
                if (documento.Extension.ToLower().Replace(".", "") == "jpg") { tipoarch = "imagen"; }
                if (documento.Extension.ToLower().Replace(".", "") == "jpeg") { tipoarch = "imagen"; }
                if (documento.Extension.ToLower().Replace(".", "") == "bmp") { tipoarch = "imagen"; }
                if (documento.Extension.ToLower().Replace(".", "") == "png") { tipoarch = "imagen"; }

                string filefinal = "";



                if (tipoarch == "imagen")
                {
                    filefinal = "data:image/jpg;base64," + Convert.ToBase64String(System.IO.File.ReadAllBytes(archivo));
                }
                if (tipoarch == "pdf")
                {
                    filefinal = "PDF.aspx?archivo=" + Server.UrlEncode(carpeta + "\\" + documento.Name);
                }
                if (tipoarch == "")
                {
                    filefinal = "Descarga.aspx?archivo=" + Server.UrlEncode(carpeta + "\\" + documento.Name);
                }
                html = html + "<!-- ... -->    <div class=\"newStyle2\" onmouseover=\"this.style.background='#878aed';\"  onmouseout=\"this.style.background='white';\"  style=\"text-decoration:none\" onclick=\"leer(\'" + filefinal + "\', \'" + tipoarch + "\');\" >   " + documento.Name.ToString() + "</div> <br> ";

            }



        }
    }
}