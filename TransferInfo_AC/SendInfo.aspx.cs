using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TransferInfo_AC
{
    public partial class SendInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                Random rnd = new Random(DateTime.Now.Second);
                string NSS = string.Format("{0}{1}", DateTime.Now.Year.ToString(), rnd.Next().ToString().Substring(0,7));
                string idExpediente = rnd.Next().ToString().Substring(0, 5);

                txtNSS.Text = NSS;
                txtIdExpedientes.Text = idExpediente;
            }
        }

        protected void btnTestWS_Click(object sender, EventArgs e)
        {
            lblResultado.Text = "";
            try
            {
                PUENTE_IMAGENES_AC.WS_PUENTE_IMAGENES oWS = new PUENTE_IMAGENES_AC.WS_PUENTE_IMAGENES();
                if (fuArchivo.HasFile)
                {
                    byte[] fileZip = fuArchivo.FileBytes;
                    string resp = oWS.ENLACE(txtUsuario.Text, txtContrasena.Text, txtIdTramite.Text, txtIdExpedientes.Text, txtNSS.Text, fileZip);
                    lblResultado.Text = resp;
                }
                else
                {
                    lblResultado.Text = "El archivo zip es requerido";
                }
            }
            catch(Exception ex)
            {
                Response.Write("Error:" + ex.Message);
            }

        }

        protected void btnNewInfo_Click(object sender, EventArgs e)
        {
            Random rnd = new Random(DateTime.Now.Second);
            string NSS = string.Format("{0}{1}", DateTime.Now.Year.ToString(), rnd.Next().ToString().Substring(0, 7));
            string idExpediente = rnd.Next().ToString().Substring(0, 5);

            txtNSS.Text = NSS;
            txtIdExpedientes.Text = idExpediente;
        }
    }
}