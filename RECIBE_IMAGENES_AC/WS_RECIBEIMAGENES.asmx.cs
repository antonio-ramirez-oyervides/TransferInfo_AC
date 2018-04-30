using ClsPiMxEncSer;
using Ionic.Zip;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using InfoMonitor;

namespace WS_RECIBEIMAGENES_AC
{
    /// <summary>
    /// Summary description for WS_RECIBEIMAGENES
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_RECIBEIMAGENES : System.Web.Services.WebService
    {
        public string nombreLog = "Recibe_Imagenes";
        [WebMethod]
        public string RECIBE(byte[] ArchivoZip, string Usuario, string Password, string idTramite, string idExpediente, string nss)
        {
            int paso = 0;
            Monitor monitor = new Monitor();

            try
            {
                monitor.SaveLog(Usuario, idTramite, nss, idExpediente, "Inicia RECIBE", nombreLog);
                monitor.SaveRequest(Usuario, idTramite, nss, idExpediente, ArchivoZip, nombreLog);
                paso += 1;
            }
            catch (Exception ex) {
                monitor.SaveLog( Usuario, idTramite, nss, idExpediente, "Inicia RECIBE", nombreLog);
                monitor.SaveLog("Error RECIBE", string.Format("Paso:{0}, Erorr:{1}", paso.ToString(), ex.Message), nombreLog);
            }
            

            string nombreImagenes = "";
            string mensaje = "";
            ZipFile zip = new ZipFile();
            string fecha = "";
            string existe = "0";
            string directorioImagenes = "";

            PIMX_EncryptionServices encryptor = new PIMX_EncryptionServices();
            string usuarioDencriptado = encryptor.DecryptString128Bit(ConfigurationManager.AppSettings.Get("userWinston").ToString(), ConfigurationManager.AppSettings.Get("gsHexSeed").ToString()).Replace("\0", "");
            string contraDencriptada = encryptor.DecryptString128Bit(ConfigurationManager.AppSettings.Get("pswWinston").ToString(), ConfigurationManager.AppSettings.Get("gsHexSeed").ToString()).Replace("\0", "");

            //VALIDA SI EL USUARIO Y CONTRASEÑA SON CORRECTOS
            if (Usuario == usuarioDencriptado && Password == contraDencriptada)
            {
                OperacionesOracle oracle = new OperacionesOracle();
                string msjError = oracle.out_error;

                //EJECUTA SP DE ORACLE QUE VERIFICA SI EL EXPEDIENTE EXISTE EN LA BD
                existe = oracle.verificaExpediente(idExpediente);
                directorioImagenes = oracle.obtenerRutas(idTramite);

                //VALIDA SI EXISTE EL EXPEDIENTE
                if (existe == "1")
                {
                    #region < Z I P >

                    //NOMENCLATURA ZIP
                    //afore(3)idtramite(2)curp(18)tipotrabajdor(1)countImagenes(2)fechaenvio(8(añoMesDia))constante(3).zip
                    string afore = "";
                    string curp = "";
                    string tipoTrabajador = "";
                    string fechaEnvio = "";
                    string constanteAfore = "000";
                    bool zipnuevo = false;
                    string nombreZipFinal = "";

                    mensaje = "CONVERTIR ARCHIVO EN BYTES";
                    byte[] bytes = new byte[ArchivoZip.Length];
                    bytes = ArchivoZip;

                    try
                    {
                        mensaje = "GUARDAR ARCHIVO ORIGINAL EN EL SERVIDOR DE IMAGENES";
                        //mensaje = "ESCRIBIR ARREGLO DE BYTES";
                        File.WriteAllBytes(directorioImagenes + "archivo.zip" + idExpediente, bytes);
                        mensaje = "ESCRITURA BYTES EXITOSA";
                    }
                    catch (Exception ex)
                    {
                        oracle.guardaEstatus(idExpediente, "RECIBE", mensaje + ex.Message, "");
                        return "02 - AL ESCRIBIR EN EL DIRECTORIO, " + mensaje + "\n" + ex.Message;
                    }
                    try
                    {

                        mensaje = "LEE ZIP DEL SERVIDOR DE IMAGENES";
                        zip = ZipFile.Read(directorioImagenes + "archivo.zip" + idExpediente);

                        mensaje = "CONTAR LAS IMAGENES";
                        int totalEntries = zip.Entries.Count;
                        //CONVIERTE A STRING EL NUMERO DE IMAGENES PARA ANEXARLO AL NOMBRE DEL ZIP
                        string imagenesCuenta = totalEntries.ToString();
                        //EL NOMBRE DEL ZIP LLEVA LA CANTIDAD DE IMAGENES EN EL EN 2 DIGITOS, SI SON
                        //MENOS DE 10 SE LE AGREGA UN CERO PARA APEGARSE A LA NOMENCLATURA DEL ZIP
                        if (totalEntries < 10)
                        {
                            imagenesCuenta = "0" + imagenesCuenta;
                        }

                        mensaje = "DESCOMPRIMIR EL ZIP Y/O MANDAR CADENA DE NOMBRE DE IMAGENES";
                        //GUARDA LOS NOMBRES DE LAS IMAGENES EN UNA CADENA. |||VARIABLE: "nombreImagenes"|||
                        // Y GUARDA LAS IMAGENES EN EL SERVIDOR DE IMAGENES (DESCOMPRESIÓN DE ZIP)
                        foreach (ZipEntry archivo in zip.Entries)
                        {
                            nombreImagenes = nombreImagenes + archivo.FileName + "#";
                            archivo.Extract(directorioImagenes);
                        }

                        mensaje = "SE EXTRAJERON LAS IMAGENES";
                        //OBTIENE LA INFORMACION DESGLOSADA DE LA IMAGEN PARA RENOMBRAR EL ZIP
                        afore = nombreImagenes.Substring(0, 3);
                        curp = nombreImagenes.Substring(5, 18);
                        tipoTrabajador = nombreImagenes.Substring(23, 1);
                        fechaEnvio = nombreImagenes.Substring(27, 8);
                        constanteAfore = nombreImagenes.Substring(35, 3);

                        zip.Dispose();

                        mensaje = "CONCATENAR NOMBRE FINAL";
                        nombreZipFinal = afore + idTramite + curp + tipoTrabajador + imagenesCuenta + fechaEnvio + constanteAfore;

                        mensaje = "RENOMBRADO";
                        System.IO.File.Move(directorioImagenes + "archivo.zip" + idExpediente,
                                            directorioImagenes + nombreZipFinal + ".zip");
                        //afore(3)idtramite(2)curp(18)tipotrabajdor(1)countImagenes(2)fechaenvio(8(añoMesDia))constante(3).zip
                        zipnuevo = true;
                        zip.Dispose();
                    }
                    catch (Exception ex)
                    {
                        oracle.guardaEstatus(idExpediente, "RECIBE", mensaje + ex.Message, "");
                        zip.Dispose();
                        //borra archivos y zip
                        if (zipnuevo == false)
                            BorraImagenes(nombreImagenes, directorioImagenes, "archivo.zip", true);
                        else
                            BorraImagenes(nombreImagenes, directorioImagenes, nombreZipFinal, true);
                        return "02 - ERROR EN CONVERSIONES DEL ZIP, " + mensaje + "\n" + ex.ToString();
                    }

                    #endregion

                    #region < P A R A M E T R O S   O R A C L E >

                    OperacionesOracle objCon = new OperacionesOracle();
                    OracleConnection cn = objCon.connect();
                    OracleParameter op = null;
                    OracleCommand cmd = cn.CreateCommand();
                    string estado = " ";
                    try
                    {
                        mensaje = "CREAR LOS COMANDOS ORACLE";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        mensaje = "ASIGNAR VARIABLES DE ENTRADA";
                        cmd.CommandText = "BFP_IMAGENES_EXPELEC_PKG.act_estatus_llegada_imagenes";
                        cmd.Parameters.Add("p_id_tramite", OracleDbType.Varchar2).Value = idTramite;

                        mensaje = "EXPEDIENTE O NSS";
                        cmd.Parameters.Add("p_id_expediente", OracleDbType.Varchar2).Value = idExpediente;
                        cmd.Parameters.Add("p_id_nss", OracleDbType.Varchar2).Value = nss;

                        mensaje = "NOMBRE ARCHIVO O ESTATUS";
                        cmd.Parameters.Add("p_nom_archivo_zip", OracleDbType.Varchar2).Value = nombreZipFinal + ".zip";
                        cmd.Parameters.Add("p_estatus", OracleDbType.Varchar2).Value = estado;

                        mensaje = "CADENA DE ARCHIVOS";
                        cmd.Parameters.Add("p_archivos", OracleDbType.Varchar2).Value = nombreImagenes;

                        mensaje = "RUTA";
                        cmd.Parameters.Add("p_ruta", OracleDbType.Varchar2).Value = directorioImagenes;

                        mensaje = "CREAR VARIABLE DE SALIDA (FECHA)";
                        op = new OracleParameter("p_fecha", OracleDbType.Varchar2);
                        op.Direction = ParameterDirection.Output;
                        op.Size = 4000;
                        cmd.Parameters.Add(op);

                        mensaje = "CONVERTIR FECHA A STRING";
                        cmd.ExecuteNonQuery();
                        fecha = op.Value.ToString();

                        mensaje = "FECHA ASIGNADA" + fecha;

                        cn.Dispose();
                        cn.Close();
                    }

                    catch (Exception ex)
                    {
                        BorraImagenes(nombreImagenes, directorioImagenes, nombreZipFinal, true);

                        cn.Dispose();
                        cn.Close();
                        return "02 - Error en la conexion " + mensaje + "\n" + ex.Message;
                    }

                    #endregion

                    try
                    {
                        if (fecha.Substring(0, 2) == "01")
                        {
                            //BORRAR IMAGENES PERO NO EL ZIP
                            mensaje = "INTENTAR BORRAR EL ZIP";
                            BorraImagenes(nombreImagenes, directorioImagenes, nombreZipFinal, false);
                            return fecha;
                        }
                        else
                        {
                            //BORRA TODO
                            mensaje = "INTENTAR BORRAR EL ZIP Y LAS IMAGENES";
                            BorraImagenes(nombreImagenes, directorioImagenes, nombreZipFinal, true);
                            return fecha;
                        }
                    }

                    catch (Exception ex)
                    {
                        mensaje = "ERROR AL PREGUNTAR EL 01 EN LA FECHA";
                        return "02 - " + fecha + "\n" + mensaje + "\n" + ex.ToString();
                    }
                }

                else
                {
                    return "02 - No existe expediente";
                }
            }
            else
                return "Usuario o contraseña incorrectos";
        }

        public void BorraImagenes(string nombreImagenes, string rutaBorrado, string zipBorrar, bool borraZip)
        {
            Monitor monitor = new Monitor();
            int paso = 0;
            monitor.SaveLog("Inicia BorradoImagenes", nombreImagenes, nombreLog);
            paso += 1;

            try
            {
                //SI NO HAY IMAGENES SOLO BORRA EL ZIP
                if (nombreImagenes != "" || nombreImagenes != null)
                {
                    paso += 1;
                    int i = 0;
                    int j = 0;
                    int count = nombreImagenes.Count(f => f == '#');
                    string[] imagen = new string[count];
                    string[] imgs = nombreImagenes.Split('#');

                    paso += 1;
                    // Separa la cadena en palabras individuales guardandolas en una variable cada una
                    foreach (string palabra in imgs)
                    {
                        if (i < count)
                        {
                            imagen[i] = palabra;
                            i++;
                        }
                    }

                    paso += 1;
                    for (j = 0; j < count; j++)
                    {
                        if (File.Exists(rutaBorrado + imagen[j]))
                        {
                            try
                            {
                                File.Delete(rutaBorrado + imagen[j]);
                            }
                            catch (System.IO.IOException e)
                            {
                                monitor.SaveLog("Error BorradoImagenes", string.Format("Paso:{0}, RutaBorrado:{1}, Error:{2}", paso.ToString(), rutaBorrado, e.Message), nombreLog);
                                return;
                            }
                        }
                    }
                }

                paso += 1;
                if (borraZip == true)
                {
                    //BORRA EL ZIP
                    System.IO.File.Delete(rutaBorrado + zipBorrar + ".zip");
                }


            }
            catch (Exception ex)
            {
                monitor.SaveLog("Error BorradoImagenes", string.Format("Paso:{0}, RutaBorrado:{1}, Error:{2}", paso.ToString(),rutaBorrado, ex.Message), nombreLog);
            }
        }
    }
}
