using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FocusLab_L3_S2.Views.Patients;

namespace FocusLab_L3_S2.Views.Patients
{
    public partial class PatientsView : Form
    {
        public static Panel p;
        public static Button ajout, affich;
        public PatientsView()
        {
            InitializeComponent();
            utils.Utils.loadform(container, new ShowPatients());
            p = container;
            ajout = ajouter;
            affich = btnAfficher;
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            utils.Utils.loadform(container, new ShowPatients());
            ajouter.Visible = true;
            btnAfficher.Visible = false;
        }

        private void ajouter_Click(object sender, EventArgs e)
        {
            utils.Utils.loadform(container, new PatientsRegister(null));
            ajouter.Visible = false;
            btnAfficher.Visible = true;
        }
    }
}
