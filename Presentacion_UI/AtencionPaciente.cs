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
    public partial class AtencionPaciente : Form
    {
        public BEUsuario oBEUsuario = new BEUsuario();
        BEVacunas oBEVacuna;
        BEPaciente oBEPaciente;
        BLLVacunas oBLLVacuna;
        BLLPaciente oBLLPaciente;

        public AtencionPaciente()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AtencionPaciente_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            oBEPaciente = new BEPaciente();
            oBEVacuna = new BEVacunas();
            oBLLPaciente = new BLLPaciente();
            oBLLVacuna = new BLLVacunas();
            textBox6.Text = oBEUsuario.nombreUsuario;
            cargarGrilla();
            cargarCombobox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargarGrilla();

        }
        private void cargarGrilla()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = oBLLPaciente.PacientesxVacunar(oBLLPaciente.ListarTodo());
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            oBEPaciente = (BEPaciente)dataGridView1.CurrentRow.DataBoundItem;
            textBox2.Text = oBEPaciente.vacunaxAplicar.Nombre;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            oBEPaciente = (BEPaciente)dataGridView1.CurrentRow.DataBoundItem;
            textBox2.Text = oBEPaciente.vacunaxAplicar.Nombre;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("Esta Seguro que desea aplicar la vacuna al paciente", "Confirmacion", MessageBoxButtons.YesNo);
            if (confirmacion == DialogResult.Yes)
            {
                if(dataGridView1.CurrentRow != null)
                {
                    string auxLote = textBox1.Text;
                    bool loteValido = Regex.IsMatch(auxLote, "^([A-Z]{1,1}[0-9]{6,6}[A-Z]{2,2})+$");
                    if (loteValido)
                    {
                        int idVacunacion = ((BEPaciente)dataGridView1.CurrentRow.DataBoundItem).idVacunacion;
                        oBEVacuna = ((BEPaciente)dataGridView1.CurrentRow.DataBoundItem).vacunaxAplicar;
                        oBEVacuna.Lote = textBox1.Text;
                        oBEVacuna.fechaVenc = dateTimePicker1.Value;
                        oBEVacuna.lugarAplic = (string)comboBox1.SelectedItem;
                        oBEVacuna.fechaAplic = DateTime.Now;
                        oBLLPaciente.vacunarPaciente(oBEVacuna, idVacunacion);
                        cargarGrilla();
                        clearTextbox();
                    }
                    else { MessageBox.Show("Ingrese un lote Valido Formato: A123456AB"); }
                }
                else 
                {
                
                    MessageBox.Show("Seleccione un paciente para vacunar");
                
                }
                
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void cargarCombobox()
        {
            
                List<String> ListaCombox = new List<string>();
                ListaCombox.Add("Brazo Izquierdo");
                ListaCombox.Add("Brazo Derecho");
                ListaCombox.Add("Muslo Izquierdo");
                ListaCombox.Add("Muslo Derecho");
                comboBox1.DataSource = null;
                comboBox1.DataSource = ListaCombox;
                comboBox1.DisplayMember = "Zona de Aplicacion";
           

        }
        void clearTextbox()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
