using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FocusLab_L3_S2.Views.Examens
{
    public partial class ExamensView : Form
    {
        public static Panel p;
        public static Button ajout, affich;
        public ExamensView()
        {
            InitializeComponent();
            utils.Utils.loadform(container2, new ShowExamens());
            p = container2;
            ajout = ajouter;
            affich = btnAfficher;
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {

            utils.Utils.loadform(container2, new ShowExamens());
            ajouter.Visible = true;
            btnAfficher.Visible = false;
        }

        private void ajouter_Click(object sender, EventArgs e)
        {
            utils.Utils.loadform(container2, new ExamensRegister(null));
            ajouter.Visible = false;
            btnAfficher.Visible = true;
        }
    }
}
