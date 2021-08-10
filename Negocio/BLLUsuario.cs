using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;
using System.Security.Cryptography;


namespace Negocio
{
   public class BLLUsuario 
    {
        MPPUsuario usuario;
        
        public BLLUsuario()
        {
            usuario = new MPPUsuario();
        }

        public bool validarPass(BEUsuario ingreso)
        {
            ingreso.password = encriptar(ingreso.password);
            return usuario.validarPass(ingreso);
        }
        private string encriptar(string pass)
        {
            //Metodo que encripta el password antes de pasarlo a la BD
            UnicodeEncoding ePass = new UnicodeEncoding();
            byte[] Source = ePass.GetBytes(pass);
            MD5CryptoServiceProvider Md5 = new MD5CryptoServiceProvider();
            byte[] byteHash = Md5.ComputeHash(Source);
            return Convert.ToBase64String(byteHash);
        }

       



    }
}
