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

namespace FocusLab_L3_S2.Views.Personnels
{
    public partial class PersonnelsRegister : Form
    {
        public PersonnelsRegister(src.Personnels personnel)
        {
            InitializeComponent();
            Utils.loadStringInChecked(checkedListServices, ServicesModel.getListServices());
            if(personnel != null)
            {
                PersonnelsView.affich.Visible = true;
                PersonnelsView.ajout.Visible = false;
                dateTimePicker1.Value = DateTime.Parse(personnel.DateNaissance);
                textId.Text = personnel.Id;
                textDomain.Text = personnel.DomaineEtude;
                textSpecialisation.Text = personnel.Specialisation;
                textNbAnExp.Text = "" + personnel.NbAnneExpe;
                textNiveau.Text = personnel.NiveauEtude;
                textCinOrNif.Text = personnel.NifOrCin;
                textPrenom.Text = personnel.Prenom;
                textAdresse.Text = personnel.Adresse;
                comboCategorie.SelectedIndex = comboCategorie.FindStringExact(personnel.Categorie);
                comboEtat.SelectedIndex = comboEtat.FindStringExact(personnel.Etat);
                comboSexe.SelectedIndex = comboSexe.FindStringExact(personnel.Sexe);
                textEmail.Text = personnel.Email;
                textTel.Text = personnel.Telephone;
                textNom.Text = personnel.Nom;
                Utils.selectedChekedlistBox(checkedListServices, personnel.ServicesAff);
                btnRegister.Visible = false;
                btnUpdate.Visible = true;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            bool testCat = false, testN = false, testP = false, testSe = false, testEta = false, testAdr = false,
                testEm = false, testNif=false, testListServ = false, testD = false, testNiv = false, testAge = false,
                testTel = false, testNbY = false, testSpe = false;
            src.Personnels personnel = new src.Personnels();
            if(Utils.comboSelected(comboCategorie, "Categorie"))
            {
                testCat = true;
                personnel.Categorie = comboCategorie.SelectedItem.ToString();
            }

            if(Utils.stringOnly(Utils.cleanUp(textNom.Text), "Nom"))
            {
                testN = true;
                personnel.Nom = Utils.cleanUp(textNom.Text);
            }

            if(Utils.stringOnly(Utils.cleanUp(textPrenom.Text), "Prenom"))
            {
                testP = true;
                personnel.Prenom = Utils.cleanUp(textPrenom.Text);
            }
            if(Utils.comboSelected(comboSexe, "Sexe"))
            {
                testSe = true;
                personnel.Sexe = comboSexe.SelectedItem.ToString();
            }
            if(Utils.comboSelected(comboEtat, "Etat"))
            {
                testEta = true;
                personnel.Etat = comboEtat.SelectedItem.ToString();
            }

            if (Utils.adresseCorrect(Utils.cleanUp(textAdresse.Text)))
            {
                testAdr = true;
                personnel.Adresse = Utils.cleanUp(textAdresse.Text);
            }

            if (!String.IsNullOrEmpty(Utils.cleanUp(textEmail.Text)))
            {
                if (Utils.isValidMail(textEmail.Text))
                {
                    testEm = true;
                    personnel.Email = Utils.cleanUp(textEmail.Text);
                }
            }
            else
            {
                testEm = true;
                personnel.Email = null;
            }
            if (Utils.nifOrCinValid(textCinOrNif.Text))
            {
                testNif = true;
                personnel.NifOrCin = textCinOrNif.Text;
            }

            if (Utils.isSelectedOnList(checkedListServices, "Service affect."))
            {
                personnel.ServicesAff = Utils.chekedListToString(checkedListServices);
                testListServ = true;

            }

            if(Utils.stringAndNumber(Utils.cleanUp(textDomain.Text), "Domaine Etude"))
            {
                testD = true;
                personnel.DomaineEtude = Utils.cleanUp(textDomain.Text);
            }
            if(Utils.stringAndNumber(Utils.cleanUp(textNiveau.Text), "Niveau etude"))
            {
                testNiv = true;
                personnel.NiveauEtude = Utils.cleanUp(textNiveau.Text);
            }

            if (Utils.haveAge(dateTimePicker1.Value.ToString("MM/dd/yyyy"))){
                testAge = true;
                personnel.DateNaissance = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            }
            if (Utils.phoneCorrect(Utils.cleanUp(textTel.Text)))
            {
                testTel = true;
                personnel.Telephone = Utils.cleanUp(textTel.Text);
            }

            if(Utils.numberOnly(Utils.cleanUp(textNbAnExp.Text), "Nb annee exp"))
            {
                testNbY = true;
                personnel.NbAnneExpe = int.Parse(Utils.cleanUp(textNbAnExp.Text));
            }

            if (Utils.stringAndNumber(Utils.cleanUp(textSpecialisation.Text), "Specialisation"))
            {
                testSpe = true;
                personnel.Specialisation = Utils.cleanUp(textSpecialisation.Text);
            }

            if(testCat && testN && testP && testSe && testAdr && testD && testNiv && testSpe
                && testNbY && testTel && testAge && testListServ && testEm && testNif && testEta)
            {
                if(PersonnelsModel.enregistrer(personnel) == 1)
                {
                    MessageBox.Show("Enregistrement reussi!", "Enregistrer");
                    this.resetData();
                    Utils.loadform(PersonnelsView.p, new ShowPersonnels());
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetData();
        }

        private void resetData()
        {
            comboEtat.SelectedIndex = -1;
            comboSexe.SelectedIndex = -1;
            comboCategorie.SelectedIndex = -1;
            textAdresse.Text = null;
            textNbAnExp.Text = null;
            textNom.Text = null;
            textPrenom.Text = null;
            textNiveau.Text = null;
            textSpecialisation.Text = null;
            textTel.Text = null;
            textDomain.Text = null;
            textEmail.Text = null;
            textCinOrNif.Text = null;
            dateTimePicker1.Value = DateTime.Parse(DateTime.Now.ToShortTimeString());
            Utils.reesetselectedChekedlistBox(checkedListServices, Utils.chekedListToString(checkedListServices));
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool testCat = false, testN = false, testP = false, testSe = false, testEta = false, testAdr = false,
                testEm = false, testNif = false, testListServ = false, testD = false, testNiv = false, testAge = false,
                testTel = false, testNbY = false, testSpe = false;
            src.Personnels personnel = new src.Personnels();
            personnel.Id = textId.Text;
            if (Utils.comboSelected(comboCategorie, "Categorie"))
            {
                testCat = true;
                personnel.Categorie = comboCategorie.SelectedItem.ToString();
            }

            if (Utils.stringOnly(Utils.cleanUp(textNom.Text), "Nom"))
            {
                testN = true;
                personnel.Nom = Utils.cleanUp(textNom.Text);
            }

            if (Utils.stringOnly(Utils.cleanUp(textPrenom.Text), "Prenom"))
            {
                testP = true;
                personnel.Prenom = Utils.cleanUp(textPrenom.Text);
            }
            if (Utils.comboSelected(comboSexe, "Sexe"))
            {
                testSe = true;
                personnel.Sexe = comboSexe.SelectedItem.ToString();
            }
            if (Utils.comboSelected(comboEtat, "Etat"))
            {
                testEta = true;
                personnel.Etat = comboEtat.SelectedItem.ToString();
            }

            if (Utils.adresseCorrect(Utils.cleanUp(textAdresse.Text)))
            {
                testAdr = true;
                personnel.Adresse = Utils.cleanUp(textAdresse.Text);
            }

            if (!String.IsNullOrEmpty(Utils.cleanUp(textEmail.Text)))
            {
                if (Utils.isValidMail(textEmail.Text))
                {
                    testEm = true;
                    personnel.Email = Utils.cleanUp(textEmail.Text);
                }
            }
            else
            {
                testEm = true;
                personnel.Email = null;
            }
            if (Utils.nifOrCinValid(textCinOrNif.Text))
            {
                testNif = true;
                personnel.NifOrCin = textCinOrNif.Text;
            }

            if (Utils.isSelectedOnList(checkedListServices, "Service affect."))
            {
                personnel.ServicesAff = Utils.chekedListToString(checkedListServices);
                testListServ = true;

            }

            if (Utils.stringAndNumber(Utils.cleanUp(textDomain.Text), "Domaine Etude"))
            {
                testD = true;
                personnel.DomaineEtude = Utils.cleanUp(textDomain.Text);
            }
            if (Utils.stringAndNumber(Utils.cleanUp(textNiveau.Text), "Niveau etude"))
            {
                testNiv = true;
                personnel.NiveauEtude = Utils.cleanUp(textNiveau.Text);
            }

            if (Utils.haveAge(dateTimePicker1.Value.ToString("MM/dd/yyyy")))
            {
                testAge = true;
                personnel.DateNaissance = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            }
            if (Utils.phoneCorrect(Utils.cleanUp(textTel.Text)))
            {
                testTel = true;
                personnel.Telephone = Utils.cleanUp(textTel.Text);
            }

            if (Utils.numberOnly(Utils.cleanUp(textNbAnExp.Text), "Nb annee exp"))
            {
                testNbY = true;
                personnel.NbAnneExpe = int.Parse(Utils.cleanUp(textNbAnExp.Text));
            }

            if (Utils.stringAndNumber(Utils.cleanUp(textSpecialisation.Text), "Specialisation"))
            {
                testSpe = true;
                personnel.Specialisation = Utils.cleanUp(textSpecialisation.Text);
            }

            if (testCat && testN && testP && testSe && testAdr && testD && testNiv && testSpe
                && testNbY && testTel && testAge && testListServ && testEm && testNif && testEta)
            {
                if (PersonnelsModel.update(personnel) == 1)
                {
                    MessageBox.Show("Modification reussi!", "Modifier");
                    this.resetData();
                    Utils.loadform(PersonnelsView.p, new ShowPersonnels());
                }
            }

            PersonnelsView.ajout.Visible = true;
            PersonnelsView.affich.Visible = false;
        }
    }
}
