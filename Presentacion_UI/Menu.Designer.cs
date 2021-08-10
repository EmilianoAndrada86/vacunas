namespace Presentacion_UI
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ingresoDePacientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atencionDePacientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atenderPacientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vacunasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMVacunasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.vacunasAplicadasPorEnfermeroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresoDePacientesToolStripMenuItem,
            this.atencionDePacientesToolStripMenuItem,
            this.vacunasToolStripMenuItem,
            this.consultasToolStripMenuItem1,
            this.xMLToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(899, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // ingresoDePacientesToolStripMenuItem
            // 
            this.ingresoDePacientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.ingresoDePacientesToolStripMenuItem.Name = "ingresoDePacientesToolStripMenuItem";
            this.ingresoDePacientesToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.ingresoDePacientesToolStripMenuItem.Text = "Inicio";
            this.ingresoDePacientesToolStripMenuItem.Click += new System.EventHandler(this.ingresoDePacientesToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // atencionDePacientesToolStripMenuItem
            // 
            this.atencionDePacientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresarToolStripMenuItem,
            this.atenderPacientesToolStripMenuItem});
            this.atencionDePacientesToolStripMenuItem.Name = "atencionDePacientesToolStripMenuItem";
            this.atencionDePacientesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.atencionDePacientesToolStripMenuItem.Text = "Pacientes";
            this.atencionDePacientesToolStripMenuItem.Click += new System.EventHandler(this.atencionDePacientesToolStripMenuItem_Click);
            // 
            // ingresarToolStripMenuItem
            // 
            this.ingresarToolStripMenuItem.Name = "ingresarToolStripMenuItem";
            this.ingresarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ingresarToolStripMenuItem.Text = "Ingresar Pacientes";
            this.ingresarToolStripMenuItem.Click += new System.EventHandler(this.ingresarToolStripMenuItem_Click);
            // 
            // atenderPacientesToolStripMenuItem
            // 
            this.atenderPacientesToolStripMenuItem.Name = "atenderPacientesToolStripMenuItem";
            this.atenderPacientesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.atenderPacientesToolStripMenuItem.Text = "Atender Pacientes";
            this.atenderPacientesToolStripMenuItem.Click += new System.EventHandler(this.atenderPacientesToolStripMenuItem_Click);
            // 
            // vacunasToolStripMenuItem
            // 
            this.vacunasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMVacunasToolStripMenuItem});
            this.vacunasToolStripMenuItem.Name = "vacunasToolStripMenuItem";
            this.vacunasToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.vacunasToolStripMenuItem.Text = "Vacunas";
            // 
            // aBMVacunasToolStripMenuItem
            // 
            this.aBMVacunasToolStripMenuItem.Name = "aBMVacunasToolStripMenuItem";
            this.aBMVacunasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aBMVacunasToolStripMenuItem.Text = "ABM Vacunas";
            this.aBMVacunasToolStripMenuItem.Click += new System.EventHandler(this.aBMVacunasToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem1
            // 
            this.consultasToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vacunasAplicadasPorEnfermeroToolStripMenuItem});
            this.consultasToolStripMenuItem1.Name = "consultasToolStripMenuItem1";
            this.consultasToolStripMenuItem1.Size = new System.Drawing.Size(71, 20);
            this.consultasToolStripMenuItem1.Text = "Consultas";
            // 
            // vacunasAplicadasPorEnfermeroToolStripMenuItem
            // 
            this.vacunasAplicadasPorEnfermeroToolStripMenuItem.Name = "vacunasAplicadasPorEnfermeroToolStripMenuItem";
            this.vacunasAplicadasPorEnfermeroToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.vacunasAplicadasPorEnfermeroToolStripMenuItem.Text = "Consultas";
            this.vacunasAplicadasPorEnfermeroToolStripMenuItem.Click += new System.EventHandler(this.vacunasAplicadasPorEnfermeroToolStripMenuItem_Click);
            // 
            // xMLToolStripMenuItem
            // 
            this.xMLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMXMLToolStripMenuItem});
            this.xMLToolStripMenuItem.Name = "xMLToolStripMenuItem";
            this.xMLToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.xMLToolStripMenuItem.Text = "XML";
            // 
            // aBMXMLToolStripMenuItem
            // 
            this.aBMXMLToolStripMenuItem.Name = "aBMXMLToolStripMenuItem";
            this.aBMXMLToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aBMXMLToolStripMenuItem.Text = "ABM XML";
            this.aBMXMLToolStripMenuItem.Click += new System.EventHandler(this.aBMXMLToolStripMenuItem_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 385);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Menu";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ingresoDePacientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atencionDePacientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem vacunasAplicadasPorEnfermeroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atenderPacientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vacunasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMVacunasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMXMLToolStripMenuItem;
    }
}