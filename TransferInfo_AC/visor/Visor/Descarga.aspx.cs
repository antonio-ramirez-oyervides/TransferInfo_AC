using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Descarga : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //Response.Write("<a href=\"" + Request["archivo"].ToString() + "\">Descargar archivo</a>");


       // Response.ContentType = "image/jpeg";
      


        //byte[] buffer = System.IO.File.ReadAllBytes(archivo);

        //if (Context.Response.IsClientConnected)
        //{
        //    Context.Response.ContentType = "application/force-download";
        //    Context.Response.OutputStream.Write(buffer, 0, buffer.Length);
        //    Context.Response.Flush();
        //}
        if (!Page.IsPostBack) { 
        archivo.Text = Request["archivo"].ToString();
        archivo.ReadOnly = true;
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        archivo.ReadOnly = false;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["archivo"].ToString());
        Response.TransmitFile(Request["archivo"].ToString());
        Response.End();




        //string archivo = Request["archivo"].ToString();
    }
}