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

namespace Presentacion_UI
{
    public partial class Menu : Form
    {
        public BEUsuario oBEUsuario = new BEUsuario();

        public Menu()
        {
            InitializeComponent();
            

            
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }

        private void ingresoDePacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void atencionDePacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ingresarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                fIngresoPaciente form = new fIngresoPaciente();
                form.oBEUsuario = this.oBEUsuario;
                form.MdiParent = this;
                form.Show();
                
            
            
            
        }

        private void atenderPacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AtencionPaciente form = new AtencionPaciente();
            form.oBEUsuario = this.oBEUsuario;
            form.MdiParent = this;
            form.Show();
        }

        private void aBMVacunasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fVacunas form = new fVacunas();
            form.oBEUsuario = this.oBEUsuario;
            form.MdiParent = this;
            form.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void vacunasAplicadasPorEnfermeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fConsultas form = new fConsultas();
            form.MdiParent = this;
            form.Show();
        }

        private void aBMXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XML form = new XML();
            form.MdiParent = this;
            form.Show();
        }
    }
}
