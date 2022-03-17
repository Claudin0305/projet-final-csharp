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
using FocusLab_L3_S2.utils;
using FocusLab_L3_S2.Model;
namespace FocusLab_L3_S2.Views.Utilisateurs
{
    public partial class UtilisateursRegister : Form
    {
        src.Utilisateurs utilisateur = null;
        public UtilisateursRegister(src.Utilisateurs utilisateur)
        {
            this.utilisateur = utilisateur;
            InitializeComponent();
            Utils.addToCombo(comboidEmp, PersonnelsModel.getListIdPersonnels());
            if(utilisateur != null)
            {
                UtilisateursView.affich.Visible = true;
                UtilisateursView.ajout.Visible = false;
                if (utilisateur.Etat.Equals("Actif"))
                {
                    radioBtnActif.Checked = true;
                }
                else if (utilisateur.Etat.Equals("Inactif"))
                {
                    radioBtnInactif.Checked = true;
                }
                textPseudo.Text = utilisateur.Pseudo;
                textId.Text = "" + utilisateur.Id;
                comboidEmp.SelectedIndex = comboidEmp.FindString(utilisateur.IdEmp);
                btnRegister.Visible = false;
                btnUpdate.Visible = true;

                Utils.selectedChekedlistBox(checkedListModule, utilisateur.Modules);

            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dataReset();
        }

        private void dataReset()
        {
            textPseudo.Text = null;
            textPass.Text = null;
            textPassConf.Text = null;
            comboidEmp.SelectedIndex = -1;
            radioBtnActif.Checked = false;
            radioBtnInactif.Checked = false;
            Utils.reesetselectedChekedlistBox(checkedListModule, Utils.chekedListToString(checkedListModule));

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            src.Utilisateurs utilisateur = new src.Utilisateurs();
            bool testIdEnp = false, testPseudo = false, testPass = false, testModul = false, testEta = false;
            
            if( comboidEmp.SelectedIndex != -1)
            {
                if (!UtilisateursModel.empHaveAccount(comboidEmp.SelectedItem.ToString()))
                {
                    utilisateur.IdEmp = comboidEmp.SelectedItem.ToString();
                    testIdEnp = true;
                }
                else
                {
                    MessageBox.Show("Le personnel a deja un compte!", "Compte existe");
                }
            }
            else
            {
                MessageBox.Show("Vous devez choisir l'ID de l'employe!", "ID Employe");
            }
            if (!String.IsNullOrEmpty(textPass.Text))
            {
                if (!String.IsNullOrEmpty(textPassConf.Text))
                {
                    if (textPass.Text.Equals(textPassConf.Text))
                    {
                        utilisateur.PassWord = textPass.Text;
                        testPass = true;
                    }
                    else
                    {
                        MessageBox.Show("Les password ne sont pas identiques", "Password");
                    }
                }
                else
                {
                    MessageBox.Show("Vous devez confirmer le mot de pass", "Password");
                }
            }
            else
            {
                MessageBox.Show("Vous devez saisir un mot de pass", "Password");
            }
            if (Utils.pseudoExiste(textPseudo.Text))
            {
                utilisateur.Pseudo = textPseudo.Text;
                testPseudo = true;
            }
            if(Utils.radioButtonChooser(radioBtnActif.Checked, radioBtnInactif.Checked, "Etat du compte"))
            {
                testEta = true;
                if (radioBtnActif.Checked)
                {
                    utilisateur.Etat = "Actif";
                }else if (radioBtnInactif.Checked)
                {
                    utilisateur.Etat = "Inactif";
                }
            }
            if (Utils.isSelectedOnList(checkedListModule, "Modules accessible."))
            {
                utilisateur.Modules = Utils.chekedListToString(checkedListModule);
                testModul = true;

            }
            if(testIdEnp && testPseudo && testPass && testEta && testModul)
            {
                if(UtilisateursModel.enregistrer(utilisateur) == 1)
                {
                    MessageBox.Show("Enregistrement effectue!");
                    this.dataReset();
                    Utils.loadform(UtilisateursView.p, new ShowUtilisateurs());
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            src.Utilisateurs utilisateur = new src.Utilisateurs();
            utilisateur.Id = textId.Text;
            String idEmp = UtilisateursModel.getById(textId.Text).IdEmp;
            bool testIdEnp = false, testPseudo = false, testPass = false, testModul = false, testEta = false, testNotUpPass = false;

            if (comboidEmp.SelectedIndex != -1)
            {
                if (!comboidEmp.SelectedItem.ToString().Equals(idEmp))
                {
                    if (!UtilisateursModel.empHaveAccount(comboidEmp.SelectedItem.ToString()))
                    {
                        utilisateur.IdEmp = comboidEmp.SelectedItem.ToString();
                        testIdEnp = true;
                    }
                    else
                    {
                        MessageBox.Show("Le personnel a deja un compte!", "Compte existe");
                    }
                }
                else
                {

                    utilisateur.IdEmp = comboidEmp.SelectedItem.ToString();
                    testIdEnp = true;
                }
            }
            else
            {
                MessageBox.Show("Vous devez choisir l'ID de l'employe!", "ID Employe");
            }
            if (!String.IsNullOrEmpty(textPass.Text))
            {
                if (!String.IsNullOrEmpty(textPassConf.Text))
                {
                    if (textPass.Text.Equals(textPassConf.Text))
                    {
                        utilisateur.PassWord = textPass.Text;
                        testPass = true;
                    }
                    else
                    {
                        MessageBox.Show("Les password ne sont pas identiques", "Password");
                    }
                }
                else
                {
                    MessageBox.Show("Vous devez confirmer le mot de pass", "Password");
                }
            }
            else
            {
                testNotUpPass = true;
            }
            if (Utils.pseudoExisteForUpdate(textId.Text, textPseudo.Text))
            {
                utilisateur.Pseudo = textPseudo.Text;
                testPseudo = true;
            }
            if (Utils.radioButtonChooser(radioBtnActif.Checked, radioBtnInactif.Checked, "Etat du compte"))
            {
                testEta = true;
                if (radioBtnActif.Checked)
                {
                    utilisateur.Etat = "Actif";
                }
                else if (radioBtnInactif.Checked)
                {
                    utilisateur.Etat = "Inactif";
                }
            }
            if (Utils.isSelectedOnList(checkedListModule, "Modules accessible."))
            {
                utilisateur.Modules = Utils.chekedListToString(checkedListModule);
                testModul = true;

            }
            if (testNotUpPass)
            {
                utilisateur.PassWord = UtilisateursModel.getPassWordById(textId.Text);

                if (testIdEnp && testPseudo && testEta && testModul)
                {
                    if (UtilisateursModel.update(utilisateur) == 1)
                    {
                        MessageBox.Show("Modification effectue!", "Modification");
                        this.dataReset();
                        Utils.loadform(UtilisateursView.p, new ShowUtilisateurs());
                    }
                }

            }
            else
            {

                if (testIdEnp && testPseudo && testPass && testEta && testModul)
                {
                    if (UtilisateursModel.update(utilisateur) == 1)
                    {
                        MessageBox.Show("Modification effectue!", "Modification");
                        this.dataReset();
                        Utils.loadform(UtilisateursView.p, new ShowUtilisateurs());
                    }
                }
            }

            UtilisateursView.ajout.Visible = true;
            UtilisateursView.affich.Visible = false;
        }
    }
}
