namespace FocusLab_L3_S2.Views.Assurances
{
    partial class ShowAssurances
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
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sigle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nom_d = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percent_cons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chambre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hosp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.etat = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Id,
            this.nom,
            this.sigle,
            this.nom_d,
            this.ad,
            this.tel,
            this.mail,
            this.percent_cons,
            this.chambre,
            this.hosp,
            this.etat});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(899, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // nom
            // 
            this.nom.HeaderText = "Nom compagnie";
            this.nom.Name = "nom";
            this.nom.ReadOnly = true;
            // 
            // sigle
            // 
            this.sigle.HeaderText = "Sigle compagnie";
            this.sigle.Name = "sigle";
            this.sigle.ReadOnly = true;
            // 
            // nom_d
            // 
            this.nom_d.HeaderText = "Nom Directeur";
            this.nom_d.Name = "nom_d";
            this.nom_d.ReadOnly = true;
            // 
            // ad
            // 
            this.ad.HeaderText = " Adresse";
            this.ad.Name = "ad";
            this.ad.ReadOnly = true;
            // 
            // tel
            // 
            this.tel.HeaderText = "Téléphone";
            this.tel.Name = "tel";
            this.tel.ReadOnly = true;
            // 
            // mail
            // 
            this.mail.HeaderText = "Email";
            this.mail.Name = "mail";
            this.mail.ReadOnly = true;
            // 
            // percent_cons
            // 
            this.percent_cons.HeaderText = "% paiement consultation";
            this.percent_cons.Name = "percent_cons";
            this.percent_cons.ReadOnly = true;
            // 
            // chambre
            // 
            this.chambre.HeaderText = "% paiement chambre";
            this.chambre.Name = "chambre";
            this.chambre.ReadOnly = true;
            // 
            // hosp
            // 
            this.hosp.HeaderText = "% paiement hospitalisation";
            this.hosp.Name = "hosp";
            this.hosp.ReadOnly = true;
            // 
            // etat
            // 
            this.etat.HeaderText = "Etat";
            this.etat.Name = "etat";
            this.etat.ReadOnly = true;
            // 
            // ShowAssurances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(899, 450);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowAssurances";
            this.Text = "ShowAssurances";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn sigle;
        private System.Windows.Forms.DataGridViewTextBoxColumn nom_d;
        private System.Windows.Forms.DataGridViewTextBoxColumn ad;
        private System.Windows.Forms.DataGridViewTextBoxColumn tel;
        private System.Windows.Forms.DataGridViewTextBoxColumn mail;
        private System.Windows.Forms.DataGridViewTextBoxColumn percent_cons;
        private System.Windows.Forms.DataGridViewTextBoxColumn chambre;
        private System.Windows.Forms.DataGridViewTextBoxColumn hosp;
        private System.Windows.Forms.DataGridViewTextBoxColumn etat;
    }
}