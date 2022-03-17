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
using FocusLab_L3_S2.Views.Dashboard;

namespace FocusLab_L3_S2.Views.Dashboard
{
    public partial class Login : Form
    {
        public static string pseudo, pass;
        public Login()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            textPass.Text = utils.Utils.cleanUp(textPass.Text);
            textPseudo.Text = utils.Utils.cleanUp(textPseudo.Text);
            if (UtilisateursModel.getByPseudoAndPass(textPseudo.Text, textPass.Text) != null)
            {
                if(UtilisateursModel.getByPseudoAndPass(textPseudo.Text, textPass.Text).Etat.Equals("Actif"))
                {
                    activateButon(UtilisateursModel.getByPseudoAndPass(textPseudo.Text, textPass.Text));
                    utils.Utils.loadform(MainView.mainPanel_stat, new StatistiqueView());
                }
                else
                {
                    MessageBox.Show("Votre compte est inactif. Contactez l'administrateur!", "Erreur de connexion");
                }

            }
            else
            {
                MessageBox.Show("Pseudo ou password incorect", "Erreur de connexion");
            }
        }

        private void activateButon(src.Utilisateurs utilisateur)
        {
            if (utilisateur != null && !String.IsNullOrEmpty(utilisateur.Modules))
            {
                MainView.panel_aside.Visible = true;
                MainView.header.Visible = true;
                MainView.log_out.Visible = true;
                foreach (String str in utilisateur.Modules.Split(','))
                {
                    if (utils.Utils.isEqualsString(str, "Services"))
                    {
                        MainView.panel_ser.Visible = true;
                    }
                    else if (utils.Utils.isEqualsString(str, "Chambres"))
                    {
                        MainView.panel_ch.Visible = true;
                    }
                    else if (utils.Utils.isEqualsString(str, "Utilisateurs"))
                    {
                        MainView.panel_user.Visible = true;
                    }
                    else if (utils.Utils.isEqualsString(str, "Patients"))
                    {
                        MainView.panel_pat.Visible = true;
                    }
                    else if (utils.Utils.isEqualsString(str, "Personnels"))
                    {
                        MainView.panel_pers.Visible = true;
                    }
                    else if (utils.Utils.isEqualsString(str, "Consultations"))
                    {
                        MainView.panel_consul.Visible = true;
                    }
                    else if (utils.Utils.isEqualsString(str, "Contrats"))
                    {
                        MainView.panel_cont.Visible = true;
                    }
                }
            }

        }
    }
}
