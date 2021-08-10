using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using Negocio;



namespace Presentacion_UI
{
    public partial class MenuInicial : Form
    {
        BEUsuario ingreso;
        BLLUsuario oBLLusu;
        
        public MenuInicial()
        {
            InitializeComponent();
             ingreso = new BEUsuario();
             oBLLusu = new BLLUsuario();
                

        }

        private void MenuInicial_Load(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            ingreso.nombreUsuario = textBox1.Text;
            ingreso.password = textBox2.Text;

            if (oBLLusu.validarPass(ingreso))
            {
                Menu form = new Menu();
                form.oBEUsuario.nombreUsuario = ingreso.nombreUsuario;
                form.oBEUsuario.Codigo = ingreso.Codigo;
                this.Hide();
                form.Show();
                
            }



            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
