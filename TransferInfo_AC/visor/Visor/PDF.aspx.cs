using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PDF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Context.Response.Buffer = false;


        string archivo = Request["archivo"].ToString();


        byte[] buffer = System.IO.File.ReadAllBytes(archivo);

        if (Context.Response.IsClientConnected)
        {
            Context.Response.ContentType = "application/pdf";
            Context.Response.OutputStream.Write(buffer, 0, buffer.Length);
            Context.Response.Flush();
        }

    }

    public byte[] Base64ToImage(string base64String)
    {
        // Convert Base64 String to byte[]
        byte[] imageBytes = Convert.FromBase64String(base64String);

        return imageBytes;

    }
}