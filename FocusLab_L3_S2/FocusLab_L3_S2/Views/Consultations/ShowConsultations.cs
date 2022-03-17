using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FocusLab_L3_S2.Model;

namespace FocusLab_L3_S2.Views.Consultations
{
    public partial class ShowConsultations : Form
    {
        public ShowConsultations()
        {
            InitializeComponent();

            foreach (src.Consultations consultation in ConsultationsModel.getAll())
            {
                this.dataGridView1.Rows.Add(consultation.Id, consultation.NoDossierPatient, consultation.ConsultationPrServices,
                    consultation.ConsultationPayAss, consultation.MotifConsultation, consultation.NecessiteHospita,
                    consultation.HospitalisationSurAss, consultation.DureeHospital, consultation.MedecinEnCharge,
                    consultation.DateConsOrHosp);
            }

            utils.Utils.btnInDataGrid(dataGridView1, "edit");
            utils.Utils.btnInDataGrid(dataGridView1, "delete");
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int line = dataGridView1.CurrentCell.RowIndex;
            String id = "" + dataGridView1.Rows[line].Cells[0].Value;
            //edit
            if (e.ColumnIndex == 10)
            {
                utils.Utils.loadform(ConsultationsView.p, new ConsultationsRegister(ConsultationsModel.getById(id)));
            }

            //supprime
            if (e.ColumnIndex == 11)
            {

                string message = "Voulez-vous vraiment supprimer";
                string title = "Supprimer Consultation";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {

                    //this.Close();
                    if (ConsultationsModel.delete(id) == 1)
                    {
                        MessageBox.Show("Suppression Effectue!", "Supprimer");
                        utils.Utils.loadform(ConsultationsView.p, new ShowConsultations());
                    }
                }
                else
                {

                    utils.Utils.loadform(ConsultationsView.p, new ShowConsultations());
                }

            }

        }

        
    }
}
