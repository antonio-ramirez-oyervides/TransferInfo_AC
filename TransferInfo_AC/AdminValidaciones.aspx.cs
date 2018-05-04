using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TransferInfo_AC
{
    public partial class AdminValidaciones : System.Web.UI.Page
    {
        public DataTable dtValidaciones=new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dtValidaciones = ConsultaValidaciones();
            }
        }


        private DataTable ConsultaValidaciones()
        {
            DataTable dtReturn = new DataTable();
            try
            {
                string strConn = ConfigurationManager.AppSettings["Cnn_DBTransferInfo"].ToString();
                SqlConnection Cnn = new SqlConnection(strConn);
                SqlDataAdapter DA = new SqlDataAdapter(string.Format("Sps_Validaciones"), Cnn);
                DA.Fill(dtReturn);
                return dtReturn;
            }
            catch (Exception ex)
            {
                throw new Exception("ConsultaSQL: " + ex.Message.ToString());
            }
        }

        private bool CambiaActivationStatus(int idValidation, bool status)
        {
            string strConn = ConfigurationManager.AppSettings["Cnn_DBTransferInfo"].ToString();
            SqlConnection conn = new SqlConnection(strConn);

            try
            {
                SqlCommand cmd = new SqlCommand("Spu_ActivarValidacion");
                cmd.Parameters.Add(new SqlParameter("@idValidacion", idValidation));
                cmd.Parameters.Add(new SqlParameter("@bitActivo", status));
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
                if(conn.State== ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


    }
}