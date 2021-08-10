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
using System.Xml;

namespace Presentacion_UI
{
    public partial class XML : Form
    {
        XmlDocument archivoXML;
        BEPaciente oBEPaciente;
        BLLPaciente oBLLPaciente;
        public XML()
        {
            InitializeComponent();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<BEPaciente> listaPacientes = oBLLPaciente.ListarTodo();
            foreach (BEPaciente aux in listaPacientes)
            {
                dataGridView1.Rows.Add(aux.Nombre, aux.Apellido, aux.DNI, aux.FN.ToString("dd/MM/yyyy"), aux.Direccion);
            }
        }

        private void XML_Load(object sender, EventArgs e)
        {
            oBEPaciente = new BEPaciente();
            oBLLPaciente = new BLLPaciente();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            archivoXML = new XmlDocument();
            archivoXML.AppendChild(archivoXML.CreateXmlDeclaration("1.0", System.Text.Encoding.UTF8.WebName, "yes"));
            XmlElement pacientes = archivoXML.CreateElement("Pacientes");
            archivoXML.AppendChild(pacientes);
            foreach (DataGridViewRow aux in dataGridView1.Rows)
            {
                if ((aux.Cells[0].Value == null) && (aux.Cells[1].Value == null) && (aux.Cells[2].Value == null) && (aux.Cells[3].Value == null) && (aux.Cells[4].Value == null))
                {

                }
                else
                {
                    XmlElement paciente = archivoXML.CreateElement("Paciente");
                    pacientes.AppendChild(paciente);
                    int i = 0;
                    foreach (DataGridViewColumn auxCol in dataGridView1.Columns)
                    {
                        switch (i)
                        {
                            case 0:
                                XmlElement nombre = archivoXML.CreateElement("Nombre");
                                nombre.InnerText = aux.Cells[i].Value.ToString();
                                paciente.AppendChild(nombre);
                                i++;
                                break;
                            case 1:
                                XmlElement apellido = archivoXML.CreateElement("Apellido");
                                apellido.InnerText = aux.Cells[i].Value.ToString();
                                paciente.AppendChild(apellido);
                                i++;
                                break;
                            case 2:
                                XmlElement dni = archivoXML.CreateElement("DNI");
                                dni.InnerText = aux.Cells[i].Value.ToString();
                                paciente.AppendChild(dni);
                                i++;
                                break;
                            case 3:
                                XmlElement FN = archivoXML.CreateElement("Fecha_Nacimiento");
                                FN.InnerText = aux.Cells[i].Value.ToString();
                                paciente.AppendChild(FN);
                                i++;
                                break;
                            case 4:
                                XmlElement direccion = archivoXML.CreateElement("Direccion");
                                direccion.InnerText = aux.Cells[i].Value.ToString();
                                paciente.AppendChild(direccion);
                                i++;
                                break;
                        }
                    }
                }

            }
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            oBLLPaciente.guardarXML(archivoXML);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = archivoXML.InnerXml;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = oBLLPaciente.mostrarArchivoXML();
        }
    }
}
