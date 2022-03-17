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
namespace FocusLab_L3_S2.Views.Services
{
    public partial class ShowServices : Form
    {
        public ShowServices()
        {
           
            InitializeComponent();
            //ajout des donnees
            foreach(src.Services service in ServicesModel.getAll())
            {
                this.dataGridView1.Rows.Add(service.Id, service.Nom, service.PrixConsultation,
                    service.Description, service.NomChefDeService, service.Etat, service.CouvrirParAssurance);
            }

            utils.Utils.btnInDataGrid(dataGridView1, "edit");
            utils.Utils.btnInDataGrid(dataGridView1, "delete");
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int line = dataGridView1.CurrentCell.RowIndex;
            String id = ""+dataGridView1.Rows[line].Cells[0].Value;
            //edit
            if(e.ColumnIndex == 7)
            {
                utils.Utils.loadform(ServiceView.p, new ServicesRegister(ServicesModel.getById(id)));
            }

            //supprime
            if(e.ColumnIndex == 8)
            {

                string message = "Voulez-vous vraiment supprimer";
                string title = "Supprimer Service";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {

                    //this.Close();
                    if(ServicesModel.delete(id) == 1)
                    {
                        MessageBox.Show("Suppression Effectue!", "Supprimer");
                        utils.Utils.loadform(ServiceView.p, new ShowServices());
                    }
                }
                else
                {

                    utils.Utils.loadform(ServiceView.p, new ShowServices());
                }
                
            }
        }
    }
}
