namespace FocusLab_L3_S2.Views.Consultations
{
    partial class ShowConsultations
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoDossier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.services = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consultationP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.motif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NeceHosp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HosParAss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Medecin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NoDossier,
            this.services,
            this.consultationP,
            this.motif,
            this.NeceHosp,
            this.HosParAss,
            this.Duree,
            this.Medecin,
            this.Date});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(977, 450);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // NoDossier
            // 
            this.NoDossier.HeaderText = "No Dossier P.";
            this.NoDossier.Name = "NoDossier";
            this.NoDossier.ReadOnly = true;
            // 
            // services
            // 
            this.services.HeaderText = "Services Cons.";
            this.services.Name = "services";
            this.services.ReadOnly = true;
            // 
            // consultationP
            // 
            this.consultationP.HeaderText = "Consultation P. Ass.";
            this.consultationP.Name = "consultationP";
            this.consultationP.ReadOnly = true;
            // 
            // motif
            // 
            this.motif.HeaderText = "Motif";
            this.motif.Name = "motif";
            this.motif.ReadOnly = true;
            // 
            // NeceHosp
            // 
            this.NeceHosp.HeaderText = "Hospitalisation";
            this.NeceHosp.Name = "NeceHosp";
            this.NeceHosp.ReadOnly = true;
            // 
            // HosParAss
            // 
            this.HosParAss.HeaderText = "Hosp. Par Ass.";
            this.HosParAss.Name = "HosParAss";
            this.HosParAss.ReadOnly = true;
            // 
            // Duree
            // 
            this.Duree.HeaderText = "Duree";
            this.Duree.Name = "Duree";
            this.Duree.ReadOnly = true;
            // 
            // Medecin
            // 
            this.Medecin.HeaderText = "Medecin en charge";
            this.Medecin.Name = "Medecin";
            this.Medecin.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // ShowConsultations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(977, 450);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowConsultations";
            this.Text = "ShowConsultations";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoDossier;
        private System.Windows.Forms.DataGridViewTextBoxColumn services;
        private System.Windows.Forms.DataGridViewTextBoxColumn consultationP;
        private System.Windows.Forms.DataGridViewTextBoxColumn motif;
        private System.Windows.Forms.DataGridViewTextBoxColumn NeceHosp;
        private System.Windows.Forms.DataGridViewTextBoxColumn HosParAss;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duree;
        private System.Windows.Forms.DataGridViewTextBoxColumn Medecin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
    }
}