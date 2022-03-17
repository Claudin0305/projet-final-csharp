using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FocusLab_L3_S2.Model;

namespace FocusLab_L3_S2.Views.Utilisateurs
{
    public partial class ShowUtilisateurs : Form
    {
        public ShowUtilisateurs()
        {
            InitializeComponent();
            foreach (src.Utilisateurs utilisateur in Model.UtilisateursModel.getAll())
            {
                this.dataGridView1.Rows.Add(utilisateur.Id, utilisateur.IdEmp, utilisateur.Pseudo, utilisateur.Etat,
                    utilisateur.Modules);
            }

            utils.Utils.btnInDataGrid(dataGridView1, "edit");
            utils.Utils.btnInDataGrid(dataGridView1, "delete");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int line = dataGridView1.CurrentCell.RowIndex;
            String id = "" + dataGridView1.Rows[line].Cells[0].Value;
            //edit
            if (e.ColumnIndex == 5)
            {
                utils.Utils.loadform(UtilisateursView.p, new UtilisateursRegister(UtilisateursModel.getById(id)));
            }

            //supprime
            if (e.ColumnIndex == 6)
            {

                string message = "Voulez-vous vraiment supprimer";
                string title = "Supprimer Consultation";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {

                    //this.Close();
                    if (UtilisateursModel.delete(id) == 1)
                    {
                        MessageBox.Show("Suppression Effectue!", "Supprimer");
                        utils.Utils.loadform(UtilisateursView.p, new ShowUtilisateurs());
                    }
                }
                else
                {

                    utils.Utils.loadform(UtilisateursView.p, new ShowUtilisateurs());
                }

            }
        }
    }
}
