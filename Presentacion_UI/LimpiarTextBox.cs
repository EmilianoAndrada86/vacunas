using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Presentacion_UI
{
    public partial class LimpiarTextBox : UserControl
    {
        public Form aux;
        public LimpiarTextBox()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control c in aux.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = string.Empty;
                }
            }
        }

        private void LimpiarTextBox_Load(object sender, EventArgs e)
        {

        }
    }
}
