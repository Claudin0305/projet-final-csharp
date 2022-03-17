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
namespace FocusLab_L3_S2.Views.Personnels
{
    public partial class ShowPersonnels : Form
    {
        public ShowPersonnels()
        {
            InitializeComponent();

            foreach (src.Personnels personnel in PersonnelsModel.getAll())
            {
                this.dataGridView1.Rows.Add(personnel.Id, personnel.Categorie, personnel.Nom, personnel.Prenom, personnel.Sexe,
                    personnel.Adresse, personnel.DomaineEtude, personnel.NiveauEtude, personnel.Specialisation,
                    personnel.NbAnneExpe, personnel.Telephone, personnel.DateNaissance, personnel.ServicesAff,
                    personnel.Email, personnel.NifOrCin, personnel.Etat);
            }

            utils.Utils.btnInDataGrid(dataGridView1, "edit");
            utils.Utils.btnInDataGrid(dataGridView1, "delete");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int line = dataGridView1.CurrentCell.RowIndex;
            String id = "" + dataGridView1.Rows[line].Cells[0].Value;
            //edit
            if (e.ColumnIndex == 16)
            {
                if(ServicesModel.getListServices().Count > 0)
                {

                    utils.Utils.loadform(PersonnelsView.p, new PersonnelsRegister(PersonnelsModel.getById(id)));
                }
                else
                {
                    MessageBox.Show("Option indisponible, pas de services!", "Erreur de modification");
                }
            }

            //supprime
            if (e.ColumnIndex == 17)
            {

                string message = "Voulez-vous vraiment supprimer";
                string title = "Supprimer Personnels";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {

                    //this.Close();
                    if (PersonnelsModel.delete(id) == 1)
                    {
                        MessageBox.Show("Suppression Effectue!", "Supprimer");
                        utils.Utils.loadform(PersonnelsView.p, new ShowPersonnels());
                    }
                }
                else
                {

                    utils.Utils.loadform(PersonnelsView.p, new ShowPersonnels());
                }

            }
        }
    }
}
