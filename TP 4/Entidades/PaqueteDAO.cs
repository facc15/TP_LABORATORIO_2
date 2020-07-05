using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Atributos
        /// <summary>
        /// Atributos para la conexión de base de datos.
        /// </summary>
        private static SqlCommand comando;
        private static SqlConnection conexion;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor por defecto que inicializa el objeto SqlCommand y elSqlConnection.
        /// </summary>
        static PaqueteDAO()
        {
            PaqueteDAO.conexion = new SqlConnection(Properties.Settings.Default.Conexion);
            PaqueteDAO.comando = new SqlCommand();
            PaqueteDAO.comando.CommandType = CommandType.Text;
            PaqueteDAO.comando.Connection = PaqueteDAO.conexion;
        }


        #endregion

        #region Métodos
        /// <summary>
        /// Método que configura los parámetros del Command, abre la conexión, ejecuta el Query y la cierra.
        /// Si no se pudo insertar lanzará una excepción.
        /// </summary>
        /// <param name="p">Objeto de tipo Paquete</param>
        /// <returns>Retorna true si se pudo agregar.</returns>
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;
            string sql = "INSERT INTO Paquetes (direccionEntrega, trackingID, alumno) ";
            sql += "VALUES (@direccionEntrega, @trackingID, @alumno)";

            try
            {
                PaqueteDAO.comando.CommandText = sql;
                PaqueteDAO.comando.Parameters.Clear();
                PaqueteDAO.comando.Parameters.AddWithValue("@direccionEntrega",p.DireccionEntrega);
                PaqueteDAO.comando.Parameters.AddWithValue("@trackingID",p.TrackingID);
                PaqueteDAO.comando.Parameters.AddWithValue("@alumno","Facundo Rocha");

                PaqueteDAO.conexion.Open();
                PaqueteDAO.comando.ExecuteNonQuery();
                retorno = true;

            }
            catch (Exception e)
            {

                throw new Exception("No se pudo insertar en la base de datos");
            }
            finally
            {
                if(PaqueteDAO.conexion.State==ConnectionState.Open)
                {
                    PaqueteDAO.conexion.Close();
                }

            }


            return retorno;

        }
        #endregion


    }
}
