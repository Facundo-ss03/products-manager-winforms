using System;
using System.Data.SqlClient;

namespace AppServices
{
    public class AccesoDatos
    {
        public AccesoDatos()
        {
            this.conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true");
            this.cmd = new SqlCommand();
        }

        private SqlConnection conexion;
        private SqlCommand cmd;
        private SqlDataReader reader;
        private SqlDataAdapter adapter;
        public SqlDataAdapter Adapter
        {
            get { return adapter; }
        }
        public SqlDataReader Reader
        {
            get { return reader; }
        }
        public SqlCommand Cmd
        {
            get { return cmd; }
        }

        public void setearConsulta(string consulta)
        {
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = consulta;
        }
        public void setearConsultaEnAdapter(string consulta)
        {
            adapter = new SqlDataAdapter(consulta, conexion);
            conexion.Open();
        }

        public void ejecutarLectura()
        {
            cmd.Connection = conexion;

            try
            {
                conexion.Open();
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ejecutarAccion()
        {
            cmd.Connection = conexion;
            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void cerrarConexion()
        {
            conexion.Close();
        }
    }
}
