namespace FocusLab_L3_S2.Views.Assurances
{
    partial class AssurancesView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.container = new System.Windows.Forms.Panel();
            this.head = new System.Windows.Forms.Panel();
            this.btnAfficher = new System.Windows.Forms.Button();
            this.ajouter = new System.Windows.Forms.Button();
            this.chambres = new System.Windows.Forms.Label();
            this.printLabel = new System.Windows.Forms.Label();
            this.print = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.head.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8, 8, 0, 8);
            this.panel1.Size = new System.Drawing.Size(800, 71);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.container);
            this.panel2.Controls.Add(this.head);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 379);
            this.panel2.TabIndex = 5;
            // 
            // container
            // 
            this.container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.container.Location = new System.Drawing.Point(0, 33);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(800, 346);
            this.container.TabIndex = 3;
            // 
            // head
            // 
            this.head.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.head.Controls.Add(this.printLabel);
            this.head.Controls.Add(this.print);
            this.head.Controls.Add(this.btnAfficher);
            this.head.Controls.Add(this.ajouter);
            this.head.Controls.Add(this.chambres);
            this.head.Dock = System.Windows.Forms.DockStyle.Top;
            this.head.Location = new System.Drawing.Point(0, 0);
            this.head.Name = "head";
            this.head.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.head.Size = new System.Drawing.Size(800, 33);
            this.head.TabIndex = 2;
            // 
            // btnAfficher
            // 
            this.btnAfficher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(191)))), ((int)(((byte)(194)))));
            this.btnAfficher.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAfficher.FlatAppearance.BorderSize = 0;
            this.btnAfficher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAfficher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAfficher.ForeColor = System.Drawing.Color.White;
            this.btnAfficher.Location = new System.Drawing.Point(212, 4);
            this.btnAfficher.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnAfficher.Name = "btnAfficher";
            this.btnAfficher.Size = new System.Drawing.Size(75, 25);
            this.btnAfficher.TabIndex = 8;
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
            this.ajouter.Location = new System.Drawing.Point(137, 4);
            this.ajouter.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.ajouter.Name = "ajouter";
            this.ajouter.Size = new System.Drawing.Size(75, 25);
            this.ajouter.TabIndex = 7;
            this.ajouter.Text = "Ajouter";
            this.ajouter.UseVisualStyleBackColor = false;
            this.ajouter.Click += new System.EventHandler(this.ajouter_Click);
            // 
            // chambres
            // 
            this.chambres.AutoSize = true;
            this.chambres.Dock = System.Windows.Forms.DockStyle.Left;
            this.chambres.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chambres.Location = new System.Drawing.Point(0, 4);
            this.chambres.Margin = new System.Windows.Forms.Padding(3, 0, 8, 0);
            this.chambres.Name = "chambres";
            this.chambres.Padding = new System.Windows.Forms.Padding(8, 4, 0, 4);
            this.chambres.Size = new System.Drawing.Size(137, 24);
            this.chambres.TabIndex = 6;
            this.chambres.Text = "C. ASSURANCES";
            // 
            // printLabel
            // 
            this.printLabel.AutoSize = true;
            this.printLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.printLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printLabel.Location = new System.Drawing.Point(421, 4);
            this.printLabel.Margin = new System.Windows.Forms.Padding(3, 0, 8, 0);
            this.printLabel.Name = "printLabel";
            this.printLabel.Padding = new System.Windows.Forms.Padding(8, 4, 0, 4);
            this.printLabel.Size = new System.Drawing.Size(304, 21);
            this.printLabel.TabIndex = 15;
            this.printLabel.Text = "Cliquez ici pour imprimer la liste des compagnies d\'assurances";
            // 
            // print
            // 
            this.print.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(191)))), ((int)(((byte)(194)))));
            this.print.Dock = System.Windows.Forms.DockStyle.Right;
            this.print.FlatAppearance.BorderSize = 0;
            this.print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.print.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.print.ForeColor = System.Drawing.Color.White;
            this.print.Location = new System.Drawing.Point(725, 4);
            this.print.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(75, 25);
            this.print.TabIndex = 14;
            this.print.Text = "Imprimer";
            this.print.UseVisualStyleBackColor = false;
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // AssurancesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AssurancesView";
            this.Text = "AssurancesView";
            this.panel2.ResumeLayout(false);
            this.head.ResumeLayout(false);
            this.head.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel container;
        private System.Windows.Forms.Panel head;
        private System.Windows.Forms.Button btnAfficher;
        private System.Windows.Forms.Button ajouter;
        private System.Windows.Forms.Label chambres;
        private System.Windows.Forms.Label printLabel;
        private System.Windows.Forms.Button print;
    }
}