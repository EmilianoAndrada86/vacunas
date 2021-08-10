using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    //Tanto esta clase como BEConsulta2 son simples clases de vista.
    public class BEConsulta1
    {
        #region "Atributos"
        public DateTime Fecha { get; set; }
        public string NombreVacuna { get; set; }
        public string NombrePaciente { get; set; }
        public string ApellidoPaciente { get; set; }
        #endregion

        #region "Constructores"
        public BEConsulta1() { }

        public BEConsulta1(DateTime fecha, string NV, string NP, string AP)
        {
            this.Fecha = fecha;
            this.NombreVacuna = NV;
            this.NombrePaciente = NP;
            this.ApellidoPaciente = AP;
        }
        #endregion

    }

}
