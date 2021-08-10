using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections;

namespace DALI
{
   public class Acceso
    {
        #region "Ingreso BD"
        private SqlConnection bdCC = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=BD_TP1_EmilianoAndrada;Integrated Security=True");
        private SqlCommand cmd;
        #endregion
        #region "Metodos BD"

        public DataSet LeerSP(string StoreProcedure, ArrayList Parametros)
        {
            DataSet data = new DataSet();
            cmd = new SqlCommand(StoreProcedure, bdCC);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                if(Parametros != null)
                {
                    foreach(SqlParameter dato in Parametros)
                    {
                        cmd.Parameters.AddWithValue(dato.ParameterName, dato.Value);
                    }

                }
                da.Fill(data);

            }
            catch(SqlException ex) { throw ex; }
            catch(Exception ex) { throw ex; }
            finally
            {
                bdCC.Close();
            }
            return data;
        }
        public void EscribirSP(string StoreProcedure, ArrayList Parametros)
        {
            bdCC.Open();
            cmd = new SqlCommand(StoreProcedure, bdCC);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                
                    foreach (SqlParameter dato in Parametros)
                    {
                        cmd.Parameters.AddWithValue(dato.ParameterName, dato.Value);
                    }
                
               int aux= cmd.ExecuteNonQuery();

            }
            catch (SqlException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally
            {
                bdCC.Close();
            }

        }

        public bool LeerSPEscalar(string StoreProcedure, ArrayList Parametros)
        {
            bdCC.Open();
            cmd = new SqlCommand(StoreProcedure, bdCC);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                foreach(SqlParameter dato in Parametros)
                {
                    cmd.Parameters.AddWithValue(dato.ParameterName, dato.Value);
                }

                int Respuesta = Convert.ToInt32(cmd.ExecuteScalar());
                bdCC.Close();
                if (Respuesta > 0)
                { return true; }
                else
                { return false; }
            }
            catch (SqlException ex)
            { throw ex; }

        }

        public bool LeerScalar(string consulta)
        {
            bdCC.Open();
            cmd = new SqlCommand(consulta, bdCC);
            cmd.CommandType = CommandType.Text;
            try
            {
                int Respuesta = Convert.ToInt32(cmd.ExecuteScalar());
                bdCC.Close();
                if (Respuesta > 0)
                { return true; }
                else
                { return false; }
            }
            catch (SqlException ex)
            { throw ex; }
        }
        public DataSet Leer(string Consulta_SQL)
        {
            DataSet data = new DataSet();
            try
            {
                SqlDataAdapter Da = new SqlDataAdapter(Consulta_SQL, bdCC);
                Da.Fill(data);
            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                bdCC.Close();
            }
            return data;
        }
        public void Escribir(string Consulta)
        {
            bdCC.Open();
            SqlCommand cmd = new SqlCommand(Consulta, bdCC);
            try
            {
                int aux = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                bdCC.Close();
            }
        }
        #endregion

    }
}
