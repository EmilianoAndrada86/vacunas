using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Abstraccion;
using MPP;

namespace Negocio 
{
    public class BLLVacunas : IAdministrador<BEVacunas>
    {
        MPPVacunas oMPPVacunas;

        public BLLVacunas()
        {
            oMPPVacunas = new MPPVacunas();
        }

        public bool Baja(BEVacunas Objeto)
        {
            return oMPPVacunas.Baja(Objeto);
        }

        public BEVacunas BuscarObjeto(BEVacunas Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BEVacunas Objeto)
        {
            return oMPPVacunas.Guardar(Objeto);
        }

        public List<BEVacunas> ListarTodo()
        {
            return oMPPVacunas.ListarTodo();
        }
        public bool IngresarStock(int codigo, int cantidad)
        {
            return oMPPVacunas.IngresarStock(codigo, cantidad);
        }
        public List<BEConsulta1> VacunasxFecha(DateTime fecha)
        {
            return oMPPVacunas.VacunasxFecha(fecha);
        }
        }
}
