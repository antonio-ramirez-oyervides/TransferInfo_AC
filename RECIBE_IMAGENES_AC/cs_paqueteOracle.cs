using System;
using Oracle.DataAccess.Client;
using System.Data;
using System.Configuration;
using ClsPiMxEncSer;

namespace WS_RECIBEIMAGENES_AC
{

    public class OperacionesOracle
    {
        string user;
        string password;
        string ipDataBase;
        string portDataBase;
        string sidDataBase;
        string dataSource;
        public string out_fecha, out_existe, out_error, mensajeOracle;
        OracleConnection cnn;

        public OperacionesOracle()
        {
            PIMX_EncryptionServices encryptor = new PIMX_EncryptionServices();
            user = encryptor.DecryptString128Bit(ConfigurationManager.AppSettings.Get("oraUser").ToString(), ConfigurationManager.AppSettings.Get("gsHexSeed").ToString()).Replace("\0", "");
            password = encryptor.DecryptString128Bit(ConfigurationManager.AppSettings.Get("oraPassword").ToString(), ConfigurationManager.AppSettings.Get("gsHexSeed").ToString()).Replace("\0", "");
            ipDataBase = encryptor.DecryptString128Bit(ConfigurationManager.AppSettings.Get("ipDataBase").ToString(), ConfigurationManager.AppSettings.Get("gsHexSeed").ToString()).Replace("\0", "");
            portDataBase = encryptor.DecryptString128Bit(ConfigurationManager.AppSettings.Get("portDataBase").ToString(), ConfigurationManager.AppSettings.Get("gsHexSeed").ToString()).Replace("\0", "");
            sidDataBase = encryptor.DecryptString128Bit(ConfigurationManager.AppSettings.Get("sidDataBase").ToString(), ConfigurationManager.AppSettings.Get("gsHexSeed").ToString()).Replace("\0", "");
            dataSource = "(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = " + ipDataBase + ")(PORT = " + portDataBase + "))(CONNECT_DATA = (SID = " + sidDataBase + ")))";

            /*
            user = ConfigurationManager.AppSettings.Get("oraUser").ToString();
            password =ConfigurationManager.AppSettings.Get("oraPassword").ToString();
            ipDataBase = ConfigurationManager.AppSettings.Get("ipDataBase").ToString();
            portDataBase = ConfigurationManager.AppSettings.Get("portDataBase").ToString();
            sidDataBase = ConfigurationManager.AppSettings.Get("sidDataBase").ToString();
            dataSource = "(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = " + ipDataBase + ")(PORT = " + portDataBase + "))(CONNECT_DATA = (SID = " + sidDataBase + ")))";
            */
        }

        public string guardaEstatus(string in_expediente, string in_proceso, string msj, string msj2)
        {
            string ermsj;
            int idError;

            OperacionesOracle objCon = new OperacionesOracle();
            OracleConnection cn = objCon.connect();
            OracleParameter op = null;
            idError = 1;

            //cn.Open();
            //Stored Procedure
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            idError = 2;

            cmd.CommandText = "BFP_IMAGENES_EXPELEC_PKG.act_log";
            cmd.Parameters.Add("p_id_expediente", OracleDbType.Varchar2).Value = in_expediente;
            cmd.Parameters.Add("p_id_proceso", OracleDbType.Varchar2).Value = in_proceso;
            cmd.Parameters.Add("p_id_linea", OracleDbType.Varchar2).Value = msj;
            cmd.Parameters.Add("p_id_detalle", OracleDbType.Varchar2).Value = msj2;
            idError = 3;

            //RETORNA LA FECHA
            //cmd.Parameters.Add("p_fecha", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
            op = new OracleParameter("p_result", OracleDbType.Varchar2);
            op.Direction = ParameterDirection.Output;
            op.Size = 4000;
            cmd.Parameters.Add(op);
            idError = 4;

            //out_existe = op.ToString();
            idError = 5;
            try
            {
                cmd.ExecuteNonQuery();

                cn.Dispose();
                cn.Close();

                idError = 6;
                //return "SP correcto";
                return op.Value.ToString();
            }

            catch (Exception ex)
            {
                switch (idError)
                {
                    case 1:
                        ermsj = "Error al crear SP ---> " + ex.ToString();
                        out_error = ermsj;
                        cn.Dispose();
                        cn.Close();
                        return "";
                    case 2:
                        ermsj = "Error al asignar variable al parametro---> " + ex.ToString();
                        out_error = ermsj;
                        cn.Dispose();
                        cn.Close();
                        return "";
                    case 3:
                        ermsj = "Error al obtener la fecha de salida---> " + ex.ToString();
                        out_error = ermsj;
                        cn.Dispose();
                        cn.Close();

                        return "";
                    case 4:
                        ermsj = "Error al obtener variable existe---> " + ex.ToString();
                        out_error = ermsj;
                        cn.Dispose();
                        cn.Close();

                        return "";
                    case 5:
                        ermsj = "Error al cerrar la conexion---> " + ex.ToString();
                        out_error = ermsj;
                        cn.Dispose();
                        cn.Close();

                        return "";
                    case 6:
                        ermsj = "Exito";
                        out_error = ermsj;
                        cn.Dispose();
                        cn.Close();

                        return "";
                    default:
                        ermsj = "Error al iniciar";
                        out_error = ermsj;
                        cn.Dispose();
                        cn.Close();

                        return "";
                }
            }



            //return "Si hay expediente";

        }
        
        public string verificaExpediente(string expediente)
        {
            string ermsj;
            int idError;
            //string fecha;
            //Abre la conexión
            OperacionesOracle objCon = new OperacionesOracle();
            OracleConnection cn = objCon.connect();
            OracleParameter op = null;
            idError = 1;

            //cn.Open();
            //Stored Procedure
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            idError = 2;

            cmd.CommandText = "BFP_IMAGENES_EXPELEC_PKG.valida_expediente";
            cmd.Parameters.Add("p_id_expediente", OracleDbType.Varchar2).Value = expediente;
            idError = 3;

            //RETORNA LA FECHA
            //cmd.Parameters.Add("p_fecha", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
            op = new OracleParameter("p_existe", OracleDbType.Varchar2);
            op.Direction = ParameterDirection.Output;
            op.Size = 4000;
            cmd.Parameters.Add(op);
            idError = 4;

            out_existe = op.ToString();
            idError = 5;
            try
            {
                cmd.ExecuteNonQuery();

                cn.Dispose();
                cn.Close();

                idError = 6;
                //return "SP correcto";
                return op.Value.ToString();
            }

            catch (Exception ex)
            {
                switch (idError)
                {
                    case 1:
                        ermsj = "Error al crear SP ---> " + ex.ToString();
                        out_error = ermsj;
                        cn.Dispose();
                        cn.Close();
                        return "0";
                    case 2:
                        ermsj = "Error al asignar variable al parametro---> " + ex.ToString();
                        out_error = ermsj;
                        cn.Dispose();
                        cn.Close();
                        return "0";
                    case 3:
                        ermsj = "Error al obtener la fecha de salida---> " + ex.ToString();
                        out_error = ermsj;
                        cn.Dispose();
                        cn.Close();

                        return "0";
                    case 4:
                        ermsj = "Error al obtener variable existe---> " + ex.ToString();
                        out_error = ermsj;
                        cn.Dispose();
                        cn.Close();

                        return "0";
                    case 5:
                        ermsj = "Error al cerrar la conexion---> " + ex.ToString();
                        out_error = ermsj;
                        cn.Dispose();
                        cn.Close();

                        return "0";
                    case 6:
                        ermsj = "Exito";
                        out_error = ermsj;
                        cn.Dispose();
                        cn.Close();

                        return "0";
                    default:
                        ermsj = "Error al iniciar";
                        out_error = ermsj;
                        cn.Dispose();
                        cn.Close();

                        return "0";
                }
            }



            //return "Si hay expediente";

        }

        public string obtenerRutas(string in_idTramite)
        {
            string ermsj;
            int idError;

            OperacionesOracle objCon = new OperacionesOracle();
            OracleConnection cn = objCon.connect();
            OracleParameter op = null;
            OracleParameter op2 = null;
            idError = 1;

            //cn.Open();
            //Stored Procedure
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            idError = 2;

            cmd.CommandText = "BFP_IMAGENES_EXPELEC_PKG.OBTIENE_RUTAS";
            cmd.Parameters.Add("p_id_Tramite", OracleDbType.Varchar2).Value = in_idTramite;
            idError = 3;

            //RETORNA LA FECHA
            //cmd.Parameters.Add("p_fecha", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
            op = new OracleParameter("p_ruta_recepcion_wd", OracleDbType.Varchar2);
            op.Direction = ParameterDirection.Output;
            op.Size = 4000;
            cmd.Parameters.Add(op);

            op2 = new OracleParameter("p_ruta_envio_procesar", OracleDbType.Varchar2);
            op2.Direction = ParameterDirection.Output;
            op2.Size = 4000;
            cmd.Parameters.Add(op2);

            idError = 4;

            //out_existe = op.ToString();
            idError = 5;
            try
            {
                cmd.ExecuteNonQuery();

                cn.Dispose();
                cn.Close();

                idError = 6;
                //return "SP correcto";
                return op.Value.ToString();
            }

            catch (Exception ex)
            {
                switch (idError)
                {
                    case 1:
                        ermsj = "Error al crear SP ---> " + ex.ToString();
                        out_error = ermsj;
                        cn.Dispose();
                        cn.Close();
                        return "";
                    case 2:
                        ermsj = "Error al asignar variable al parametro---> " + ex.ToString();
                        out_error = ermsj;
                        cn.Dispose();
                        cn.Close();
                        return "";
                    case 3:
                        ermsj = "Error al obtener la fecha de salida---> " + ex.ToString();
                        out_error = ermsj;
                        cn.Dispose();
                        cn.Close();

                        return "";
                    case 4:
                        ermsj = "Error al obtener variable existe---> " + ex.ToString();
                        out_error = ermsj;
                        cn.Dispose();
                        cn.Close();

                        return "";
                    case 5:
                        ermsj = "Error al cerrar la conexion---> " + ex.ToString();
                        out_error = ermsj;
                        cn.Dispose();
                        cn.Close();

                        return "";
                    case 6:
                        ermsj = "Exito";
                        out_error = ermsj;
                        cn.Dispose();
                        cn.Close();

                        return "";
                    default:
                        ermsj = "Error al iniciar";
                        out_error = ermsj;
                        cn.Dispose();
                        cn.Close();

                        return "";
                }
            }



            //return "Si hay expediente";

        }
        
        public string guardaEstatusOracle(string tramite, string expediente, string nss, string nombreArchivo,string estatus, string cadenaArchivos, string ruta)
        {
            //Abre la conexión
            OperacionesOracle objCon = new OperacionesOracle();
            OracleConnection cn = objCon.connect();
            OracleParameter op = null;

            //cn.Open();
            //Stored Procedure

            mensajeOracle = "ERROR AL CREAR LOS COMANDOS ORACLE";
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            mensajeOracle = "ERROR AL ASIGNAR VARIABLES DE ENTRADA";
            cmd.CommandText = "BFP_IMAGENES_EXPELEC_PKG.act_estatus_llegada_imagenes";
            cmd.Parameters.Add("p_id_tramite", OracleDbType.Varchar2).Value = "01";//tramite;

            mensajeOracle = "ERROR EN EXPEDIENTE O NSS";
            cmd.Parameters.Add("p_id_expediente", OracleDbType.Varchar2).Value = "6257"; // expediente;
            cmd.Parameters.Add("p_id_nss", OracleDbType.Varchar2).Value = "6257"; //nss;

            mensajeOracle = "ERROR EN NOMBRE ARCHIVO O ESTATUS";
            cmd.Parameters.Add("p_nom_archivo_zip", OracleDbType.Varchar2).Value = " "; // nombreArchivo;
            cmd.Parameters.Add("p_estatus", OracleDbType.Varchar2).Value = estatus; // ;

            mensajeOracle = "ERROR EN CADENA DE ARCHIVOS";
            //CADENA CONCATENADA DE LOS ARCHIVOS
            cmd.Parameters.Add("p_archivos", OracleDbType.Varchar2).Value = " ";// cadenaArchivos;

            mensajeOracle = "ERROR EN RUTA";
            //RUTA DONDE SE GUARDA
            cmd.Parameters.Add("p_ruta", OracleDbType.Varchar2).Value = " "; // ruta;

            mensajeOracle = "ERROR AL CREAR VARIABLE DE SALIDA (FECHA)";
            //RETORNA LA FECHA
            //cmd.Parameters.Add("p_fecha", OracleDbType.Varchar2).Direction = ParameterDirection.Output;
            op = new OracleParameter("p_fecha", OracleDbType.Varchar2);
            op.Direction = ParameterDirection.Output;
            op.Size = 4000;
            cmd.Parameters.Add(op);

            mensajeOracle = "ERROR AL CONVERTIR FECHA A STRING";
            out_fecha = op.Value.ToString();


            try
            {
                cmd.ExecuteNonQuery();
                cn.Dispose();
                cn.Close();

                //return "Actualización de tracking.";

                //SE QUITO ESTA LINEA
                //return op.Value.ToString();

                //PROBAR CON ESTA
                return out_fecha;

            }
            catch (Exception ex)
            {
                cn.Dispose();
                cn.Close();

                return ex.Message;

            }

            //return op.ToString();
        }

        //Método para la conexión con el puerto 1575
        public OracleConnection connect()
        {
            string constr = /*@"Data Source=(DESCRIPTION=
                                    (ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.236.251 )(PORT=1521)))
                                    (CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=Desa)));
                                    User Id=consultor ;Password=consultor";---- CADENA CONEXION LOCAL*/

                           /* @"Data Source=(DESCRIPTION=
                                        (ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.236.251 )(PORT=1575)))
                                        (CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=Desa)));
                                        User Id=consultor ;Password=consultor";//---CADENA CONEXION SERVIDOR PROCESAR*/

                           @"Data Source=(DESCRIPTION=
                                                (ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + ipDataBase + " )(PORT=" + portDataBase + ")))" +
                                        "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + sidDataBase + ")));" +
                                        "User Id=" + user + ";Password=" + password;

            cnn = new OracleConnection(constr);
            OracleCommand oc = new OracleCommand();
            cnn.Open();
            return cnn;
        }
    }
}