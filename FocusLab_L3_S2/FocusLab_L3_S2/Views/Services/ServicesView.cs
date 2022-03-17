using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FocusLab_L3_S2.Views
{
    public partial class ServiceView : Form
    {
        public static Panel p;
        public static Button ajout, affich;

        public ServiceView()
        {
            InitializeComponent();
            utils.Utils.loadform(container, new Services.ShowServices());
            p = container;
            ajout = ajouter;
            affich = btnAfficher;
        }


        private void ajouter_Click(object sender, EventArgs e)
        {
            utils.Utils.loadform(container, new Services.ServicesRegister(null));
            ajouter.Visible = false;
            btnAfficher.Visible = true;
            //p = container;
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            utils.Utils.loadform(container, new Services.ShowServices());
            ajouter.Visible = true;
            btnAfficher.Visible = false;
        }
    }
}
