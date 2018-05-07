using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TransferInfo_AC
{
    public partial class Descarga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                archivo.Text = Request["archivo"].ToString();
                archivo.ReadOnly = true;
            }
        }

        protected void BtnDescarga_Click(object sender, EventArgs e)
        {
            archivo.ReadOnly = false;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request["archivo"].ToString());
            Response.TransmitFile(Request["archivo"].ToString());
            Response.End();
        }
    }
}