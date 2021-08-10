using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Abstraccion;
using DALI;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Xml;

namespace MPP
{
    public class MPPPaciente : IAdministrador<BEPaciente>
    {
        XmlDocument archivoXML = new XmlDocument();
        Acceso acceso;
        ArrayList AL;
        #region "Metodos Interface"
        public bool Baja(BEPaciente Objeto)
        {
            acceso = new Acceso();
            AL = new ArrayList();
            SqlParameter parametro = new SqlParameter("@cod", Objeto.Codigo);
            AL.Add(parametro);
            string sp = "D_PacienteVacuna";
            acceso.EscribirSP(sp, AL);
            sp = "D_Pacientes";
            acceso.EscribirSP(sp, AL);
            return true;
        }
        public BEPaciente BuscarObjeto(BEPaciente Objeto)
        {
            throw new NotImplementedException();
        }
        public bool Guardar(BEPaciente Objeto)
        {
            String Consulta;
            string sp;
            AL = new ArrayList();
            SqlParameter parametro;
            if (Objeto.Codigo != 0)
            {
                Consulta = "Update pacientes SET Nombre = '"+ Objeto.Nombre+"',Apellido = '"+Objeto.Apellido+ "',DNI= '" + Objeto.DNI+ "', fechaNacimiento ='" + Objeto.FN.ToString("MM/dd/yyyy")+"', Direccion =  '" + Objeto.Direccion+"' where codigo = '"+ Objeto.Codigo + "'";
                sp = "U_Pacientes";
                parametro = new SqlParameter("@nom", Objeto.Nombre);
                AL.Add(parametro);
                parametro = new SqlParameter("@apell", Objeto.Apellido);
                AL.Add(parametro);
                parametro = new SqlParameter("@dni", Objeto.DNI);
                AL.Add(parametro);
                parametro = new SqlParameter("@fn", Objeto.FN);
                AL.Add(parametro);
                parametro = new SqlParameter("@dir", Objeto.Direccion);
                AL.Add(parametro);
                parametro = new SqlParameter("@cod", Objeto.Codigo);
                AL.Add(parametro);
            }
            else
            {
                Consulta = @"Insert into pacientes (Nombre, Apellido, DNI, fechaNacimiento,Direccion) " +
                    "values('" + Objeto.Nombre + "', '" + Objeto.Apellido + "','" + Objeto.DNI + "', '" + Objeto.FN.ToString("MM/dd/yyyy") +"', '" + Objeto.Direccion + "')";
                sp = "I_Paciente";
                parametro = new SqlParameter("@nom", Objeto.Nombre);
                AL.Add(parametro);
                parametro = new SqlParameter("@apell", Objeto.Apellido);
                AL.Add(parametro);
                parametro = new SqlParameter("@dni", Objeto.DNI);
                AL.Add(parametro);
                parametro = new SqlParameter("@fn", Objeto.FN);
                AL.Add(parametro);
                parametro = new SqlParameter("@dir", Objeto.Direccion);
                AL.Add(parametro);

            }
            acceso = new Acceso();
            acceso.EscribirSP(sp,AL);
            return true;

        }
        public List<BEPaciente> ListarTodo()
        {
            AL = new ArrayList();
            DataSet datos;
            acceso = new Acceso();
            string sp = "S_Pacientes_Listar";
            datos = acceso.LeerSP(sp,null);
            List<BEPaciente> listaPacientes = new List<BEPaciente>();
            if (datos.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in datos.Tables[0].Rows)
                {
                    AL.Clear();
                    BEPaciente nuevo = new BEPaciente(fila[1].ToString(), fila["Apellido"].ToString(), Convert.ToInt32(fila["DNI"]), Convert.ToDateTime(fila["fechaNacimiento"]), fila["Direccion"].ToString());
                    nuevo.Codigo = Convert.ToInt32(fila[0]);
                    sp = "S_Vacunas_RecibidasxPaciente";
                    SqlParameter parametro = new SqlParameter("@cod", nuevo.Codigo);
                    AL.Add(parametro);
                    Acceso acceso2 = new Acceso();
                    DataSet datos2 = new DataSet();
                    datos2 = acceso2.LeerSP(sp, AL);
                    List<BEVacunas> vacunaAplicadas = new List<BEVacunas>();
                    List<BEVacunas> vacunaxAplicar = new List<BEVacunas>();
                    foreach (DataRow fila2 in datos2.Tables[0].Rows)
                    {
                        if (Convert.ToInt32(fila2[6])!=0)
                        {
                            BEVacunas aux = new BEVacunas();
                            aux.Codigo = Convert.ToInt32(fila2[0]);
                            aux.Nombre = fila2["nombre"].ToString();
                            aux.Lote = fila2["lote"].ToString();
                            aux.fechaVenc = Convert.ToDateTime(fila2[3]);
                            aux.fechaAplic = Convert.ToDateTime(fila2[4]);
                            aux.lugarAplic = fila2[5].ToString();
                            vacunaAplicadas.Add(aux);
                        }
                        else
                        {
                            BEVacunas aux = new BEVacunas();
                            aux.Codigo = Convert.ToInt32(fila2[0]);
                            aux.Nombre = fila2["nombre"].ToString();
                            aux.Lote = "";
                            aux.fechaVenc = Convert.ToDateTime("01/01/1990");
                            aux.fechaAplic = Convert.ToDateTime("01/01/1990");
                            aux.lugarAplic = "";
                            
                        }
                    }

                    nuevo.Antecedentes = vacunaAplicadas;
                    listaPacientes.Add(nuevo);

                }
            }
            else
            {
                listaPacientes = null;
            }
            return listaPacientes;


        }
        #endregion
        public void AsignarVacuna(BEPaciente paciente, BEVacunas vacuna)
        {
            AL = new ArrayList();
            SqlParameter parametro = new SqlParameter("@codPac", paciente.Codigo);
            AL.Add(parametro);
            parametro = new SqlParameter("@codVac", vacuna.Codigo);
            AL.Add(parametro);
            //Este Metodo es el responsable de Asignar una vacuna por aplicar a un paciente en el form Ingreso Paciente
            string sp = "I_pacienteVacuna";
            acceso = new Acceso();
            acceso.EscribirSP(sp,AL);
        }
        public List<BEPaciente> PacientesxVacunar(List<BEPaciente> Pacientes)
        {
            DataSet datos;
            acceso = new Acceso();
            string sp = "S_PacientesxVacunar";
            datos = acceso.LeerSP(sp,null);
            List<BEPaciente> porVacunar = new List<BEPaciente>();
            foreach (DataRow aux in datos.Tables[0].Rows)
            {
                BEPaciente nuevo = new BEPaciente(aux[2].ToString(), aux[3].ToString(), 0, Convert.ToDateTime(aux[4]), "");
                nuevo.Codigo = Convert.ToInt32(aux[1]);
                nuevo.idVacunacion = Convert.ToInt32(aux[0]);
                nuevo.vacunaxAplicar.Codigo = Convert.ToInt32(aux["Codigo"]);
                nuevo.vacunaxAplicar.Nombre = aux[6].ToString();
                porVacunar.Add(nuevo);
            }
            return porVacunar;
        }
        public void vacunarPaciente(BEVacunas vacunaAplicada, int idVacunacion)
        {
            /*Este es el metodo que modifica la BD cuando realizamos la aplicacion de un paciente. La aplicacion es un atributo binario
            que por default se genera con 0. cuando realizamos la aplicacion agregamos los valores, lote, fecha vencimiento, lugar de aplicacion, etc.
            y cambiamos Aplicada = 1. esto lo que permite es que se liste como antecedente del paciente*/
            AL = new ArrayList();
            SqlParameter parametro = new SqlParameter("@lote", vacunaAplicada.Lote);
            AL.Add(parametro);
            parametro = new SqlParameter("@fechaVen", vacunaAplicada.fechaVenc);
            AL.Add(parametro);
            parametro = new SqlParameter("@la", vacunaAplicada.lugarAplic);
            AL.Add(parametro);
            parametro = new SqlParameter("@fechaApl", vacunaAplicada.fechaAplic);
            AL.Add(parametro);
            parametro = new SqlParameter("@idVacun", idVacunacion);
            AL.Add(parametro);
            acceso = new Acceso();
            string sp = "U_PacienteVacuna_VacunaAplicada";
            acceso.EscribirSP(sp,AL);

                                
        }
        public List<BEConsulta2> pacientesVacunadossxVacuna(int codigo)
        {
            acceso = new Acceso();
            AL = new ArrayList();
            SqlParameter parametro = new SqlParameter("@cod", codigo);
            AL.Add(parametro);
            string sp = "S_PacientesxVacuna";
            DataSet datos = acceso.LeerSP(sp,AL);
            List<BEConsulta2> lista = new List<BEConsulta2>();
            foreach(DataRow fila in datos.Tables[0].Rows)
            {
                if (fila[4].ToString() != "")
                {
                    BEConsulta2 aux = new BEConsulta2(Convert.ToInt32(fila[0]), fila[1].ToString(), fila[2].ToString(), Convert.ToInt32(fila[3]), Convert.ToDateTime(fila[4]));
                    lista.Add(aux);
                }
            }
            return lista;
        }
        public void guardarXML(XmlDocument archivo)
        {
            archivo.Save("paciente.xml");
        }
        public string mostrarArchivoXML()
        {
            archivoXML = new XmlDocument();
            archivoXML.Load("pacientes.xml");
            string texto = (archivoXML.FirstChild.OuterXml + "\r\n");
            foreach (XmlNode nodo in archivoXML)
            {
                mostrarNodo(nodo,ref texto);
            }
            return texto;
        }
        private void mostrarNodo(XmlNode pNodo,ref string texto ,int pNivel = 0)
        {


            switch (pNodo.NodeType)
            {

                case XmlNodeType.Comment:
                    texto += pNodo.Value + "\r\n";
                    break;
                case XmlNodeType.Text:
                    for (int x = 0; x <= pNivel + 1; x++)
                    {
                        texto += "  ";
                    }

                    texto += pNodo.InnerText + "\r\n";
                    break;
                case XmlNodeType.Element:
                    for (int x = 0; x <= pNivel; x++)
                    {
                        texto += "  ";
                    }

                    texto += "<" + pNodo.Name;
                    if (pNodo.Attributes.Count > 0)
                    {
                        foreach (XmlAttribute mAtr in pNodo.Attributes)
                        {
                            texto += " " + mAtr.Name + "=\"" + mAtr.Value + "\"";
                        }
                    }

                    if (pNodo.HasChildNodes)
                    {
                        texto += ">" + "\r\n";
                        foreach (XmlNode mNodo in pNodo.ChildNodes)
                        {
                            mostrarNodo(mNodo, ref texto, pNivel + 1);
                        }
                        for (int x = 0; x <= pNivel; x++)
                        {
                            texto += "  ";
                        }
                        texto += "</" + pNodo.Name + ">" + "\r\n";
                    }
                    else
                    {
                        texto += "/>" + "\r\n";
                    }

                    break;
            }
            
        }
            
            
        

    }
}
