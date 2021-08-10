using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEVacunas : Entidad
    {
        #region "Atributos"
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public string Lote { get; set; }
        public DateTime fechaVenc { get; set; }
        public String lugarAplic { get; set; }
        public DateTime fechaAplic { get; set; }
        public BEUsuario UsuarioAplico { get; set; }
        #endregion
        #region "Constructores"
        public BEVacunas() { }

        public BEVacunas(string nombre, int cantidad)
        {
            this.Nombre = nombre;
            this.Cantidad = cantidad;
        }
        #endregion
    }
}
