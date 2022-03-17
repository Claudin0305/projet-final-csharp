namespace FocusLab_L3_S2.Views
{
    partial class ServiceView
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
            this.panelCont = new System.Windows.Forms.Panel();
            this.container = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAfficher = new System.Windows.Forms.Button();
            this.ajouter = new System.Windows.Forms.Button();
            this.services = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelCont.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCont
            // 
            this.panelCont.Controls.Add(this.container);
            this.panelCont.Controls.Add(this.panel3);
            this.panelCont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCont.Location = new System.Drawing.Point(0, 71);
            this.panelCont.Name = "panelCont";
            this.panelCont.Size = new System.Drawing.Size(800, 426);
            this.panelCont.TabIndex = 2;
            // 
            // container
            // 
            this.container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.container.Location = new System.Drawing.Point(0, 33);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(800, 393);
            this.container.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.btnAfficher);
            this.panel3.Controls.Add(this.ajouter);
            this.panel3.Controls.Add(this.services);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panel3.Size = new System.Drawing.Size(800, 33);
            this.panel3.TabIndex = 2;
            // 
            // btnAfficher
            // 
            this.btnAfficher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(191)))), ((int)(((byte)(194)))));
            this.btnAfficher.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAfficher.FlatAppearance.BorderSize = 0;
            this.btnAfficher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAfficher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAfficher.ForeColor = System.Drawing.Color.White;
            this.btnAfficher.Location = new System.Drawing.Point(166, 4);
            this.btnAfficher.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnAfficher.Name = "btnAfficher";
            this.btnAfficher.Size = new System.Drawing.Size(75, 25);
            this.btnAfficher.TabIndex = 5;
            this.btnAfficher.Text = "Afficher";
            this.btnAfficher.UseVisualStyleBackColor = false;
            this.btnAfficher.Visible = false;
            this.btnAfficher.Click += new System.EventHandler(this.btnAfficher_Click);
            // 
            // ajouter
            // 
            this.ajouter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(191)))), ((int)(((byte)(194)))));
            this.ajouter.Dock = System.Windows.Forms.DockStyle.Left;
            this.ajouter.FlatAppearance.BorderSize = 0;
            this.ajouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ajouter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ajouter.ForeColor = System.Drawing.Color.White;
            this.ajouter.Location = new System.Drawing.Point(91, 4);
            this.ajouter.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.ajouter.Name = "ajouter";
            this.ajouter.Size = new System.Drawing.Size(75, 25);
            this.ajouter.TabIndex = 4;
            this.ajouter.Text = "Ajouter";
            this.ajouter.UseVisualStyleBackColor = false;
            this.ajouter.Click += new System.EventHandler(this.ajouter_Click);
            // 
            // services
            // 
            this.services.AutoSize = true;
            this.services.Dock = System.Windows.Forms.DockStyle.Left;
            this.services.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.services.Location = new System.Drawing.Point(0, 4);
            this.services.Margin = new System.Windows.Forms.Padding(3, 0, 8, 0);
            this.services.Name = "services";
            this.services.Padding = new System.Windows.Forms.Padding(8, 4, 0, 4);
            this.services.Size = new System.Drawing.Size(91, 24);
            this.services.TabIndex = 0;
            this.services.Text = "SERVICES";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8, 8, 0, 8);
            this.panel1.Size = new System.Drawing.Size(800, 71);
            this.panel1.TabIndex = 1;
            // 
            // ServiceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 497);
            this.Controls.Add(this.panelCont);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ServiceView";
            this.Text = "Service";
            this.panelCont.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelCont;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel container;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAfficher;
        private System.Windows.Forms.Button ajouter;
        private System.Windows.Forms.Label services;
    }
}