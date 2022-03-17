using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FocusLab_L3_S2.src;
using FocusLab_L3_S2.Model;
using FocusLab_L3_S2.Views.Assurances;

namespace FocusLab_L3_S2.Views.Assurances
{
    public partial class ShowAssurances : Form
    {
        public ShowAssurances()
        {
            InitializeComponent();
            foreach (src.Assurances assurance in AssurancesModel.getAll())
            {
                this.dataGridView1.Rows.Add(assurance.Id, assurance.NomCompagnie, assurance.Sigle, assurance.NomDirecteur,
                    assurance.Adresse, assurance.Telephone, assurance.Email, assurance.PercentPaimentCons,
                    assurance.PercentPaimentCh, assurance.PercentPaimentHosp, assurance.Etat);
            }

            utils.Utils.btnInDataGrid(dataGridView1, "edit");
            utils.Utils.btnInDataGrid(dataGridView1, "delete");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int line = dataGridView1.CurrentCell.RowIndex;
            String id = "" + dataGridView1.Rows[line].Cells[0].Value;
            //edit
            if (e.ColumnIndex == 11)
            {
                utils.Utils.loadform(AssurancesView.p, new AssurancesRegister(AssurancesModel.getById(id)));
            }

            //supprime
            if (e.ColumnIndex == 12)
            {

                string message = "Voulez-vous vraiment supprimer";
                string title = "Supprimer Contrat";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {

                    //this.Close();
                    if (AssurancesModel.delete(id) == 1)
                    {
                        MessageBox.Show("Suppression Effectue!", "Supprimer");
                        utils.Utils.loadform(AssurancesView.p, new ShowAssurances());
                    }
                }
                else
                {

                    utils.Utils.loadform(AssurancesView.p, new ShowAssurances());
                }

            }
        }
    }
}
