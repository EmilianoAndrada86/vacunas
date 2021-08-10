using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPaciente : Entidad
    {
        #region "Atributos"
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public int DNI { get; set; }
        public DateTime FN { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public BEVacunas vacunaxAplicar;
        public List<BEVacunas> Antecedentes { get; set; }
        public int idVacunacion { get; set; }
        #endregion}
        #region "Constructores"
        public BEPaciente(string nombre, string apellido, int dni, DateTime fechaNac, string direccion)
        {
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
            FN = fechaNac;
            Direccion = direccion;
            CalcularEdad();
            vacunaxAplicar = new BEVacunas();
        }
        
        public BEPaciente() { }
        #endregion

        private void CalcularEdad()
        {
            this.Edad = DateTime.Now.Year - FN.Year;
            if (DateTime.Now.Month < FN.Month)
                this.Edad -= 1;
            if (DateTime.Now.Month == FN.Month && DateTime.Now.Day < FN.Day)
                this.Edad -= 1;

   
        }
        
    }
}