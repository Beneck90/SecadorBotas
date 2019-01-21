using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace SecadorBotas.Clases
{
    public class ConexBD
    {


        #region PARAMETROS_DE_CONEXION

        //LLAMA STRING DE CONEXION DEL App.config

        static string sqlConexionWebConfig = ConfigurationManager.ConnectionStrings["BDConnectionString"].ToString();

        static private string cadenaConexion = "";
        SqlConnection oCnn;

        #endregion PARAMETROS_DE_CONEXION


        #region METODOS

        //METODO PARA ESTABLECER CONEXION
        public SqlConnection SetConnection()
        {

            cadenaConexion = sqlConexionWebConfig;
            oCnn = new SqlConnection(cadenaConexion);
            try
            {
                oCnn.Open();
            }
            catch (SqlException oe)
            {
                throw new ArgumentException(oe.Message);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
            return oCnn;
        }

        //METODO AL CUAL SE LE PASA UNA CONSULTA SQL
        public DataTable Exec_Query(string query)
        {
            DataTable dt = new DataTable();

            //LLAMADA AL METODO ESTABLECER CONEXION
            SqlConnection oCNN = this.SetConnection();
            SqlCommand oCMD = new SqlCommand(query, oCNN);
            SqlDataAdapter oDA = new SqlDataAdapter(oCMD);

            try
            {
                oDA.Fill(dt);

            }
            catch (SqlException oe)
            {
                System.Console.WriteLine(oe);
            }
            finally
            {

                oDA.Dispose();
                oCMD.Dispose();
                oCNN.Close();
                oCNN.Dispose();
            }
            return dt;
        }

        #endregion METODOS




        #region SECADOR_1

        //METODO PARA INSERTAR ENCENDIDO AUTOMATICO DE SECADOR 1
        public void InsertarEncendido1(string Dia, int Hora, int Minuto)
        {

            try
            {

                Exec_Query("INSERT INTO EncendidoSecador1 (dia, hora, minuto) VALUES ('" + Dia + "'," + Hora + "," + Minuto + ")");

            }

            catch (Exception)
            {
                throw new ArgumentException("Hubo un problema en la conexión!");

            }
        }

        //METODO PARA INSERTAR APAGADO AUTOMATICO DE SECADOR 2
        public void InsertarApagado1(string Dia, int Hora, int Minuto)
        {

            try
            {

                Exec_Query("INSERT INTO ApagadoSecador1 (dia, hora, minuto) VALUES ('" + Dia + "'," + Hora + "," + Minuto + ")");

            }

            catch (Exception)
            {
                throw new ArgumentException("Hubo un problema en la conexión!");

            }
        }

        //METODO QUE VERIFICA ENCENDIDO AUTOMATICO SECADOR 1
        public static bool ValidaPeriodoONSecador1(string Dia, int Hora, int Minuto)
        {
            try
            {
                DataTable dt = new SecadorBotas.Clases.ConexBD().Exec_Query("Select * from EncendidoSecador1 where dia = '" + Dia + "' and hora = " + Hora + " and minuto = " + Minuto + "");
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("Hubo un error en la consulta!");
            }

        }

        //METODO QUE VERIFICA APAGADO AUTOMATICO SECADOR 1
        public static bool ValidaPeriodoOFFSecador1(string Dia, int Hora, int Minuto)
        {
            try
            {
                DataTable dt = new SecadorBotas.Clases.ConexBD().Exec_Query("Select * from ApagadoSecador1 where dia = '" + Dia + "' and hora = " + Hora + " and minuto = " + Minuto + "");
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("Hubo un error en la consulta!");
            }

        }

        #endregion SECADOR_1


        #region SECADOR_2

        //METODO PARA INSERTAR ENCENDIDO AUTOMATICO DE SECADOR 2
        public void InsertarEncendido2(string Dia, int Hora, int Minuto)
        {

            try
            {

                Exec_Query("INSERT INTO EncendidoSecador2 (dia, hora, minuto) VALUES ('" + Dia + "'," + Hora + "," + Minuto + ")");

            }

            catch (Exception)
            {
                throw new ArgumentException("Hubo un problema en la conexión!");

            }
        }

        //METODO PARA INSERTAR APAGADO AUTOMATICO DE SECADOR 2
        public void InsertarApagado2(string Dia, int Hora, int Minuto)
        {

            try
            {

                Exec_Query("INSERT INTO ApagadoSecador2 (dia, hora, minuto) VALUES ('" + Dia + "'," + Hora + "," + Minuto + ")");

            }

            catch (Exception)
            {
                throw new ArgumentException("Hubo un problema en la conexión!");

            }
        }

        //METODO QUE VERIFICA ENCENDIDO AUTOMATICO SECADOR 2
        public static bool ValidaPeriodoONSecador2(string Dia, int Hora, int Minuto)
        {
            try
            {
                DataTable dt = new SecadorBotas.Clases.ConexBD().Exec_Query("Select * from EncendidoSecador2 where dia = '" + Dia + "' and hora = " + Hora + " and minuto = " + Minuto + "");
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("Hubo un error en la consulta!");
            }

        }

        //METODO QUE VERIFICA APAGADO AUTOMATICO SECADOR 2
        public static bool ValidaPeriodoOFFSecador2(string Dia, int Hora, int Minuto)
        {
            try
            {
                DataTable dt = new SecadorBotas.Clases.ConexBD().Exec_Query("Select * from ApagadoSecador2 where dia = '" + Dia + "' and hora = " + Hora + " and minuto = " + Minuto + "");
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("Hubo un error en la consulta!");
            }

        }

        #endregion SECADOR_2


        #region SECADOR_3

        //METODO PARA INSERTAR ENCENDIDO AUTOMATICO DE SECADOR 3
        public void InsertarEncendido3(string Dia, int Hora, int Minuto)
        {

            try
            {

                Exec_Query("INSERT INTO EncendidoSecador3 (dia, hora, minuto) VALUES ('" + Dia + "'," + Hora + "," + Minuto + ")");

            }

            catch (Exception)
            {
                throw new ArgumentException("Hubo un problema en la conexión!");

            }
        }

        //METODO PARA INSERTAR APAGADO AUTOMATICO DE SECADOR 3
        public void InsertarApagado3(string Dia, int Hora, int Minuto)
        {

            try
            {

                Exec_Query("INSERT INTO ApagadoSecador3 (dia, hora, minuto) VALUES ('" + Dia + "'," + Hora + "," + Minuto + ")");

            }

            catch (Exception)
            {
                throw new ArgumentException("Hubo un problema en la conexión!");

            }
        }

        //METODO QUE VERIFICA ENCENDIDO AUTOMATICO SECADOR 3
        public static bool ValidaPeriodoONSecador3(string Dia, int Hora, int Minuto)
        {
            try
            {
                DataTable dt = new SecadorBotas.Clases.ConexBD().Exec_Query("Select * from EncendidoSecador3 where dia = '" + Dia + "' and hora = " + Hora + " and minuto = " + Minuto + "");
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("Hubo un error en la consulta!");
            }

        }

        //METODO QUE VERIFICA APAGADO AUTOMATICO SECADOR 3
        public static bool ValidaPeriodoOFFSecador3(string Dia, int Hora, int Minuto)
        {
            try
            {
                DataTable dt = new SecadorBotas.Clases.ConexBD().Exec_Query("Select * from ApagadoSecador3 where dia = '" + Dia + "' and hora = " + Hora + " and minuto = " + Minuto + "");
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("Hubo un error en la consulta!");
            }

        }

        #endregion SECADOR_3


        #region SECADOR_4

        //METODO PARA INSERTAR ENCENDIDO AUTOMATICO DE SECADOR 4
        public void InsertarEncendido4(string Dia, int Hora, int Minuto)
        {

            try
            {

                Exec_Query("INSERT INTO EncendidoSecador4 (dia, hora, minuto) VALUES ('" + Dia + "'," + Hora + "," + Minuto + ")");

            }

            catch (Exception)
            {
                throw new ArgumentException("Hubo un problema en la conexión!");

            }
        }

        //METODO PARA INSERTAR APAGADO AUTOMATICO DE SECADOR 4
        public void InsertarApagado4(string Dia, int Hora, int Minuto)
        {

            try
            {

                Exec_Query("INSERT INTO ApagadoSecador4 (dia, hora, minuto) VALUES ('" + Dia + "'," + Hora + "," + Minuto + ")");

            }

            catch (Exception)
            {
                throw new ArgumentException("Hubo un problema en la conexión!");

            }
        }

        //METODO QUE VERIFICA ENCENDIDO AUTOMATICO SECADOR 4
        public static bool ValidaPeriodoONSecador4(string Dia, int Hora, int Minuto)
        {
            try
            {
                DataTable dt = new SecadorBotas.Clases.ConexBD().Exec_Query("Select * from EncendidoSecador4 where dia = '" + Dia + "' and hora = " + Hora + " and minuto = " + Minuto + "");
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("Hubo un error en la consulta!");
            }

        }

        //METODO QUE VERIFICA APAGADO AUTOMATICO SECADOR 7
        public static bool ValidaPeriodoOFFSecador4(string Dia, int Hora, int Minuto)
        {
            try
            {
                DataTable dt = new SecadorBotas.Clases.ConexBD().Exec_Query("Select * from ApagadoSecador4 where dia = '" + Dia + "' and hora = " + Hora + " and minuto = " + Minuto + "");
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("Hubo un error en la consulta!");
            }

        }

        #endregion SECADOR_4


        #region SECADOR_5

        //METODO PARA INSERTAR ENCENDIDO AUTOMATICO DE SECADOR 5
        public void InsertarEncendido5(string Dia, int Hora, int Minuto)
        {

            try
            {

                Exec_Query("INSERT INTO EncendidoSecador5 (dia, hora, minuto) VALUES ('" + Dia + "'," + Hora + "," + Minuto + ")");

            }

            catch (Exception)
            {
                throw new ArgumentException("Hubo un problema en la conexión!");

            }
        }

        //METODO PARA INSERTAR APAGADO AUTOMATICO DE SECADOR 5
        public void InsertarApagado5(string Dia, int Hora, int Minuto)
        {

            try
            {

                Exec_Query("INSERT INTO ApagadoSecador5 (dia, hora, minuto) VALUES ('" + Dia + "'," + Hora + "," + Minuto + ")");

            }

            catch (Exception)
            {
                throw new ArgumentException("Hubo un problema en la conexión!");

            }
        }

        //METODO QUE VERIFICA ENCENDIDO AUTOMATICO SECADOR 5
        public static bool ValidaPeriodoONSecador5(string Dia, int Hora, int Minuto)
        {
            try
            {
                DataTable dt = new SecadorBotas.Clases.ConexBD().Exec_Query("Select * from EncendidoSecador5 where dia = '" + Dia + "' and hora = " + Hora + " and minuto = " + Minuto + "");
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("Hubo un error en la consulta!");
            }

        }

        //METODO QUE VERIFICA APAGADO AUTOMATICO SECADOR 5
        public static bool ValidaPeriodoOFFSecador5(string Dia, int Hora, int Minuto)
        {
            try
            {
                DataTable dt = new SecadorBotas.Clases.ConexBD().Exec_Query("Select * from ApagadoSecador5 where dia = '" + Dia + "' and hora = " + Hora + " and minuto = " + Minuto + "");
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("Hubo un error en la consulta!");
            }

        }

        #endregion SECADOR_5


        #region SECADOR_6

        //METODO PARA INSERTAR ENCENDIDO AUTOMATICO DE SECADOR 6
        public void InsertarEncendido6(string Dia, int Hora, int Minuto)
        {

            try
            {

                Exec_Query("INSERT INTO EncendidoSecador6 (dia, hora, minuto) VALUES ('" + Dia + "'," + Hora + "," + Minuto + ")");

            }

            catch (Exception)
            {
                throw new ArgumentException("Hubo un problema en la conexión!");

            }
        }

        //METODO PARA INSERTAR APAGADO AUTOMATICO DE SECADOR 7
        public void InsertarApagado6(string Dia, int Hora, int Minuto)
        {

            try
            {

                Exec_Query("INSERT INTO ApagadoSecador6 (dia, hora, minuto) VALUES ('" + Dia + "'," + Hora + "," + Minuto + ")");

            }

            catch (Exception)
            {
                throw new ArgumentException("Hubo un problema en la conexión!");

            }
        }

        //METODO QUE VERIFICA ENCENDIDO AUTOMATICO SECADOR 7
        public static bool ValidaPeriodoONSecador6(string Dia, int Hora, int Minuto)
        {
            try
            {
                DataTable dt = new SecadorBotas.Clases.ConexBD().Exec_Query("Select * from EncendidoSecador6 where dia = '" + Dia + "' and hora = " + Hora + " and minuto = " + Minuto + "");
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("Hubo un error en la consulta!");
            }

        }

        //METODO QUE VERIFICA APAGADO AUTOMATICO SECADOR 7
        public static bool ValidaPeriodoOFFSecador6(string Dia, int Hora, int Minuto)
        {
            try
            {
                DataTable dt = new SecadorBotas.Clases.ConexBD().Exec_Query("Select * from ApagadoSecador6 where dia = '" + Dia + "' and hora = " + Hora + " and minuto = " + Minuto + "");
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("Hubo un error en la consulta!");
            }

        }

        #endregion SECADOR_6


        #region SECADOR_7

        //METODO PARA INSERTAR ENCENDIDO AUTOMATICO DE SECADOR 7
        public void InsertarEncendido7(string Dia, int Hora, int Minuto)
        {          

            try
            {

                Exec_Query("INSERT INTO EncendidoSecador7 (dia, hora, minuto) VALUES ('" + Dia + "'," + Hora + "," + Minuto + ")");

            }

            catch (Exception)
            {
                throw new ArgumentException("Hubo un problema en la conexión!");

            }
        }

        //METODO PARA INSERTAR APAGADO AUTOMATICO DE SECADOR 7
        public void InsertarApagado7(string Dia, int Hora, int Minuto)
        {

            try
            {

                Exec_Query("INSERT INTO ApagadoSecador7 (dia, hora, minuto) VALUES ('" + Dia + "'," + Hora + "," + Minuto + ")");

            }

            catch (Exception)
            {
                throw new ArgumentException("Hubo un problema en la conexión!");

            }
        }

        //METODO QUE VERIFICA ENCENDIDO AUTOMATICO SECADOR 7
        public static bool ValidaPeriodoONSecador7(string Dia, int Hora, int Minuto)
        {
            try
            {
                DataTable dt = new SecadorBotas.Clases.ConexBD().Exec_Query("Select * from EncendidoSecador7 where dia = '" + Dia + "' and hora = " + Hora + " and minuto = " + Minuto + "");
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("Hubo un error en la consulta!");
            }

        }

        //METODO QUE VERIFICA APAGADO AUTOMATICO SECADOR 7
        public static bool ValidaPeriodoOFFSecador7(string Dia, int Hora, int Minuto)
        {
            try
            {
                DataTable dt = new SecadorBotas.Clases.ConexBD().Exec_Query("Select * from ApagadoSecador7 where dia = '" + Dia + "' and hora = " + Hora + " and minuto = " + Minuto + "");
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("Hubo un error en la consulta!");
            }

        }

        #endregion SECADOR_7

    }
}
