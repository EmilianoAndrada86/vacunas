using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using Negocio;

namespace Presentacion_UI
{
    public partial class fVacunas : Form
    {
        BEVacunas oBEVacuna;
        BLLVacunas oBLLVacuna;
        public BEUsuario oBEUsuario = new BEUsuario();
        public fVacunas()
        {
            InitializeComponent();
            
        }

        private void fVacunas_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            oBEVacuna = new BEVacunas();
            oBLLVacuna = new BLLVacunas();
            textBox6.Text = oBEUsuario.nombreUsuario;
            cargarGrilla();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void cargarGrilla()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = oBLLVacuna.ListarTodo();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            oBEVacuna = (BEVacunas)dataGridView1.CurrentRow.DataBoundItem;
            textBox2.Text = oBEVacuna.Codigo.ToString();
            textBox1.Text = oBEVacuna.Nombre;
            textBox3.Text = oBEVacuna.Cantidad.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("Esta Seguro que desea eliminar la vacuna", "Confirmacion", MessageBoxButtons.YesNo);
            if (confirmacion == DialogResult.Yes)
            {
                oBEVacuna.Codigo = Convert.ToInt32(textBox2.Text);
                oBEVacuna.Nombre = textBox1.Text;
                oBLLVacuna.Baja(oBEVacuna);
                cargarGrilla();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("Esta Seguro que desea Crear la vacuna", "Confirmacion", MessageBoxButtons.YesNo);
            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    oBEVacuna = new BEVacunas(textBox1.Text, Convert.ToInt32(textBox3.Text));
                    oBLLVacuna.Guardar(oBEVacuna);
                    cargarGrilla();
                }
                catch(System.FormatException)
                {
                    MessageBox.Show("Los datos Ingresados son incorrectos, por favor reviselos y vuelva a intentarlo");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("Esta Seguro que desea modificar la vacuna", "Confirmacion", MessageBoxButtons.YesNo);
            if (confirmacion == DialogResult.Yes)
            {
                oBEVacuna = new BEVacunas(textBox1.Text, Convert.ToInt32(textBox3.Text));
                oBEVacuna.Codigo = Convert.ToInt32(textBox2.Text);
                oBLLVacuna.Guardar(oBEVacuna);
                cargarGrilla();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            oBEVacuna = (BEVacunas)dataGridView1.CurrentRow.DataBoundItem;
            textBox2.Text = oBEVacuna.Codigo.ToString();
            textBox1.Text = oBEVacuna.Nombre;
            textBox3.Text = oBEVacuna.Cantidad.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("Esta Seguro que desea agregar ese stock", "Confirmacion", MessageBoxButtons.YesNo);
            if (confirmacion == DialogResult.Yes)
            {
                string cantidad = textBox4.Text;
                bool cantidadValida = Regex.IsMatch(cantidad, "^([0-9])+$");
                if (cantidadValida)
                {
                    int codigo = Convert.ToInt32(textBox2.Text);
                    int canti = Convert.ToInt32(textBox4.Text);
                    oBLLVacuna.IngresarStock(codigo, canti);
                    cargarGrilla();
                }
                else
                {
                    MessageBox.Show("Ingrese un Valor Numerico");
                }
                
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) 
            {
                e.Handled = true;
            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

      
        private void limpiarTextBox1_Load_1(object sender, EventArgs e)
        {
            limpiarTextBox1.aux = this;
        }
    }
}
