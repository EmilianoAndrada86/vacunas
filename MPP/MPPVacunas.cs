using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DALI;
using Abstraccion;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace MPP
{
    public class MPPVacunas : IAdministrador<BEVacunas>
    {
        Acceso acceso;
        ArrayList AL;
        #region "Metodos Interface"
        public bool Baja(BEVacunas Objeto)
        {
            /*Opte por una baja logica, porque si bien las vacunas pueden ser borradas fisicamente, los antecedentes deberian perdurar aun cuando 
            las vacunas ya no esten en circulacion*/
            string sp = "D_vacunas";
            SqlParameter parametro = new SqlParameter("@cod", Objeto.Codigo);
            AL = new ArrayList();
            AL.Add(parametro);
            acceso = new Acceso();
            acceso.LeerSP(sp,AL);
            return true;
        }

        public BEVacunas BuscarObjeto(BEVacunas Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BEVacunas Objeto)
        {
            string Consulta;
            string sp;
            AL = new ArrayList();
            SqlParameter parametro;
            if (Objeto.Codigo != 0)
            {
                
           
                sp = "U_Vacunas";
                parametro = new SqlParameter("@nomb", Objeto.Nombre);
                AL.Add(parametro);
                parametro = new SqlParameter("@cant", Objeto.Cantidad);
                AL.Add(parametro);
                parametro = new SqlParameter("@cod", Objeto.Codigo);
                AL.Add(parametro);


            }
            else
            {
                
                sp = "I_Vacunas";
                parametro = new SqlParameter("@nom", Objeto.Nombre);
                AL.Add(parametro);
                parametro = new SqlParameter("@cant", Objeto.Cantidad);
                AL.Add(parametro);
            }
            acceso = new Acceso();
            acceso.EscribirSP(sp, AL);
            return true;
        }

        public List<BEVacunas> ListarTodo()
        {
            DataSet datos;
            acceso = new Acceso();
            string sp = "S_Vacunas_ListarAltas";
            datos = acceso.LeerSP(sp,null);
            List<BEVacunas> listaVacunas = new List<BEVacunas>();
            if (datos.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in datos.Tables[0].Rows)
                {
                    BEVacunas nuevo = new BEVacunas(fila[1].ToString(),Convert.ToInt32(fila[2]));
                    nuevo.Codigo = Convert.ToInt32(fila[0]);
                    listaVacunas.Add(nuevo);
                }
                
            }
            else
            {
                listaVacunas = null;
            }
            return listaVacunas;
        }
        #endregion
        public bool IngresarStock(int codigo, int cantidad)
        {
            DataSet datos;
            AL = new ArrayList();
            acceso = new Acceso();
            string sp = "S_Vacunas_Cantidad";
            SqlParameter parametro = new SqlParameter("@cod", codigo);
            AL.Add(parametro);
            datos = acceso.LeerSP(sp,AL);
            DataRow resulDatos = datos.Tables[0].Rows[0];
            int aux = Convert.ToInt32(resulDatos[0]) + cantidad; //Obtengo la cantidad de vacunas que figura en la bd y le sumo el valor cantidad
            sp = "U_Vacunas_Cantidad";
            AL.Clear();
            parametro = new SqlParameter("@cant", aux);
            AL.Add(parametro);
            parametro = new SqlParameter("@cod", codigo);
            AL.Add(parametro);
            acceso.EscribirSP(sp,AL);
            return true;
            
        }
        public List<BEConsulta1> VacunasxFecha(DateTime fecha)
        {
            AL = new ArrayList();
            DataSet datos;
            acceso = new Acceso();
            string sp = "S_Vacunas_VacunasxFecha";
            SqlParameter parametro = new SqlParameter("@fecha", fecha);
            AL.Add(parametro);
            datos = acceso.LeerSP(sp,AL);
            List<BEConsulta1> lista = new List<BEConsulta1>();
            foreach(DataRow fila in datos.Tables[0].Rows)
            {
                BEConsulta1 aux = new BEConsulta1(Convert.ToDateTime(fila[0].ToString()),fila[1].ToString(),fila[2].ToString(),fila[3].ToString());
                lista.Add(aux);
            }
            return lista;
        }
        
    }
}
