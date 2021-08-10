using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALI;
using Abstraccion;
using BE;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;

namespace MPP
{
    public class MPPUsuario 
    {
        Acceso Conexion;
        ArrayList AL;

        public bool validarPass(BEUsuario usuario)
        {
            Conexion = new Acceso();
            string sp = "S_Usuarios_CountU";
            AL = new ArrayList();
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "@nomUsua";
            parametro.Value = usuario.nombreUsuario;
            AL.Add(parametro);
            if (Conexion.LeerSPEscalar(sp,AL))
            {
                sp = "S_Usuarios_CountP";
                parametro.ParameterName = "@pass";
                parametro.Value = usuario.password;
                AL.Clear();
                AL.Add(parametro);
                if (Conexion.LeerSPEscalar(sp,AL))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Error Password Incorrecto");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Error Usuario no existe");
                return false;
            }

        }

    }
}
