using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEConsulta2
    {
        #region "Atributos"
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public DateTime fechaAplicacion { get; set; }
        #endregion
        #region "Constructores"
        public BEConsulta2() { }
        public BEConsulta2(int cod, string nom, string apell, int dni, DateTime fa)
        {
            this.Codigo = cod;
            this.Nombre = nom;
            this.Apellido = apell;
            this.DNI = dni;
            this.fechaAplicacion = fa;
        }
        #endregion
    }
}
