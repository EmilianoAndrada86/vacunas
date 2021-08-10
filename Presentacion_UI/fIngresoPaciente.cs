using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BE;
using Negocio;

namespace Presentacion_UI
{
    public partial class fIngresoPaciente : Form
    {
        public BEUsuario oBEUsuario= new BEUsuario();
        BEPaciente oBEPaciente;
        BEVacunas oBEVacuna;
        BLLPaciente oBLLPaciente;
        BLLVacunas oBLLVacuna;

        public fIngresoPaciente()
        {
            InitializeComponent();
        }

        private void fIngresoPaciente_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            oBEPaciente = new BEPaciente();
            oBEVacuna = new BEVacunas();
            oBLLPaciente = new BLLPaciente();
            oBLLVacuna = new BLLVacunas();
            textBox6.Text = oBEUsuario.nombreUsuario;
            cargarGrillas();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("Esta Seguro que desea Crear el paciente", "Confirmacion", MessageBoxButtons.YesNo);
            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    string dni = textBox3.Text;
                    bool dniValido = Regex.IsMatch(dni, "^[0-9]{8,8}$");
                    if (dniValido)
                    {
                        oBEPaciente = new BEPaciente(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text), dateTimePicker1.Value, textBox5.Text);
                        oBLLPaciente = new BLLPaciente();
                        oBLLPaciente.Guardar(oBEPaciente);
                        cargarGrillas();
                        clearTextbox();
                    }
                    else
                    {
                        MessageBox.Show("Error de Ingreso Chequee el DNI");
                    }
                    
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Los datos ingresados son incorrectos vuelva a intentarlo");
                }
            }

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cargarGrillas()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = oBLLPaciente.ListarTodo();
            this.dataGridView2.DataSource = null;
            this.dataGridView2.DataSource = oBLLVacuna.ListarTodo();

        }
        private void clearTextbox()
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            oBEPaciente = (BEPaciente)dataGridView1.CurrentRow.DataBoundItem;
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = oBEPaciente.Antecedentes;
            this.textBox1.Text = oBEPaciente.Nombre;
            this.textBox2.Text = oBEPaciente.Apellido;
            this.textBox3.Text = oBEPaciente.DNI.ToString();
            dateTimePicker1.Value = oBEPaciente.FN;
            this.textBox5.Text = oBEPaciente.Direccion;
            this.textBox4.Text = oBEPaciente.Codigo.ToString();
            
            

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            oBEPaciente = (BEPaciente)dataGridView1.CurrentRow.DataBoundItem;
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = oBEPaciente.Antecedentes;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("Esta Seguro que desea eliminar el paciente", "Confirmacion", MessageBoxButtons.YesNo);
            if (confirmacion == DialogResult.Yes)
            {
                oBEPaciente = (BEPaciente)dataGridView1.CurrentRow.DataBoundItem;
                oBLLPaciente = new BLLPaciente();
                oBLLPaciente.Baja(oBEPaciente);
                cargarGrillas();
                clearTextbox();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("Esta Seguro que desea Modificar el paciente", "Confirmacion", MessageBoxButtons.YesNo);
            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    string dni = textBox3.Text;
                    bool dniValido = Regex.IsMatch(dni, "^[0-9]{8,8}$");
                    if (dniValido)
                    {
                        oBEPaciente = new BEPaciente(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text), dateTimePicker1.Value, textBox5.Text);
                        oBEPaciente.Codigo = int.Parse(textBox4.Text);
                        oBLLPaciente = new BLLPaciente();
                        oBLLPaciente.Guardar(oBEPaciente);
                        cargarGrillas();
                        clearTextbox();
                    }
                    else
                    {
                        MessageBox.Show("Erro de ingreso Chequee el DNI");
                    }
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Los datos ingresados son incorrectos por favor reviselos y vuelva a ingresar.");
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("Esta Seguro que desea asignar la vacuna al paciente", "Confirmacion", MessageBoxButtons.YesNo);
            if (confirmacion == DialogResult.Yes)
            {
                oBEPaciente = (BEPaciente)dataGridView1.CurrentRow.DataBoundItem;
                oBEVacuna = (BEVacunas)dataGridView2.CurrentRow.DataBoundItem;
                oBLLPaciente.AsignarVacuna(oBEPaciente, oBEVacuna);
                cargarGrillas();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            clearTextbox();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
