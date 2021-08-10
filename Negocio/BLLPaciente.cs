using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Abstraccion;
using MPP;
using System.Windows.Forms;
using System.Xml;

namespace Negocio
{
    public class BLLPaciente : IAdministrador<BEPaciente>
    {
        MPPPaciente oMPPPaciente;

        public BLLPaciente()
        {
            oMPPPaciente = new MPPPaciente();
        }


        public bool Baja(BEPaciente Objeto)
        {
            return oMPPPaciente.Baja(Objeto);
        }

        public BEPaciente BuscarObjeto(BEPaciente Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BEPaciente Objeto)
        {
            return oMPPPaciente.Guardar(Objeto);
        }

        public List<BEPaciente> ListarTodo()
        {
            return oMPPPaciente.ListarTodo();
        }
        public void AsignarVacuna(BEPaciente paciente, BEVacunas vacuna)
        {
            oMPPPaciente.AsignarVacuna(paciente, vacuna);
        }
        public List<BEPaciente> PacientesxVacunar(List<BEPaciente> Pacientes)
        {
            return oMPPPaciente.PacientesxVacunar(Pacientes);
        }
        public void vacunarPaciente(BEVacunas vacunaAplicada, int idVacunacion)
        {
            oMPPPaciente.vacunarPaciente(vacunaAplicada, idVacunacion);
        }
        public List<BEConsulta2> pacientesVacunadossxVacuna(int codigo)
        {
            return oMPPPaciente.pacientesVacunadossxVacuna(codigo);
        }
        public void guardarXML(XmlDocument archivo)
        {
            oMPPPaciente.guardarXML(archivo);
        }
        public string mostrarArchivoXML()
        {
            return oMPPPaciente.mostrarArchivoXML();
        }
    }
}
