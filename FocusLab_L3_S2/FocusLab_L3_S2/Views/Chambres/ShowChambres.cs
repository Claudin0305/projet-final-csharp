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
using FocusLab_L3_S2.Views.Chambres;

namespace FocusLab_L3_S2.Views.Chambres
{
    public partial class ShowChambres : Form
    {
        public ShowChambres()
        {
            InitializeComponent();
            foreach (src.Chambres chambre in ChambresModel.getAll())
            {
                this.dataGridView1.Rows.Add(chambre.Id, chambre.Nom, chambre.Type, chambre.PrixLocation, chambre.Etat, chambre.Constituants,
                    chambre.Description);
            }

            utils.Utils.btnInDataGrid(dataGridView1, "edit");
            utils.Utils.btnInDataGrid(dataGridView1, "delete");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int line = dataGridView1.CurrentCell.RowIndex;
            String id = "" + dataGridView1.Rows[line].Cells[0].Value;
            //edit
            if (e.ColumnIndex == 7)
            {
                utils.Utils.loadform(ChambresView.p, new ChambresRegister(ChambresModel.getById(id)));
            }

            //supprime
            if (e.ColumnIndex == 8)
            {

                string message = "Voulez-vous vraiment supprimer";
                string title = "Supprimer Chambre";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {

                    //this.Close();
                    if (ChambresModel.delete(id) == 1)
                    {
                        MessageBox.Show("Suppression Effectue!", "Supprimer");
                        utils.Utils.loadform(ChambresView.p, new ShowChambres());
                    }
                }
                else
                {

                    utils.Utils.loadform(ChambresView.p, new ShowChambres());
                }

            }
        }
    }
}
