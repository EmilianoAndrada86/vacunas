using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using Negocio;

namespace Presentacion_UI
{
    public partial class fConsultas : Form
    {
        BLLVacunas oBLLVacuna;
        BLLPaciente obLLPaciente;

        public fConsultas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            reportViewer1.RefreshReport();
            reportViewer1.LocalReport.DataSources[1].Value = new List<BEConsulta2>();
            reportViewer1.LocalReport.DataSources[0].Value = oBLLVacuna.VacunasxFecha(dateTimePicker1.Value);
            reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            obLLPaciente = new BLLPaciente();
            BEVacunas aux = (BEVacunas)comboBox1.SelectedItem;
            reportViewer1.RefreshReport();
            reportViewer1.LocalReport.DataSources[0].Value = new List<BEConsulta1>();
            reportViewer1.LocalReport.DataSources[1].Value = obLLPaciente.pacientesVacunadossxVacuna(aux.Codigo);
            reportViewer1.RefreshReport();
        }

        private void fConsultas_Load(object sender, EventArgs e)
        {
            cargarComboBox();
            this.reportViewer1.RefreshReport();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cargarComboBox()
        {
            oBLLVacuna = new BLLVacunas();
            comboBox1.DataSource = null;
            comboBox1.DataSource = oBLLVacuna.ListarTodo();
            comboBox1.ValueMember = "Codigo";
            comboBox1.DisplayMember = "Nombre";
            comboBox1.Refresh();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
