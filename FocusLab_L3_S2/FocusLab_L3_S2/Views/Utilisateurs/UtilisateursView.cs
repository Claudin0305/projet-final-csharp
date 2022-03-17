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
    public partial class UtilisateursView : Form
    {
        public static Panel p;
        public static Button ajout, affich;
        public UtilisateursView()
        {
            InitializeComponent();
            utils.Utils.loadform(container3, new ShowUtilisateurs());
            p = container3;
            ajout = ajouter;
            affich = btnAfficher;
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            utils.Utils.loadform(container3, new ShowUtilisateurs());
            ajouter.Visible = true;
            btnAfficher.Visible = false;
        }

        private void ajouter_Click(object sender, EventArgs e)
        {
            if(PersonnelsModel.getListIdPersonnels().Count > 0)
            {
                utils.Utils.loadform(container3, new UtilisateursRegister(null));
                ajouter.Visible = false;
                btnAfficher.Visible = true;
            }
            else
            {
                MessageBox.Show("Option non disponible, pas de personnels!", "Ajouter utilisateur");
            }
        }
    }
}
