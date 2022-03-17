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
using FocusLab_L3_S2.Model;
using FocusLab_L3_S2.utils;

namespace FocusLab_L3_S2.Views.Patients
{
    public partial class PatientsRegister : Form
    {
        public PatientsRegister(src.Patients patient)
        {
            InitializeComponent();
            Utils.loadStringInChecked(checkedListComp, AssurancesModel.getListCompagnie());
            Utils.loadStringInChecked(checkedListTrait, ServicesModel.getListServices());
            if(patient != null)
            {
                PatientsView.affich.Visible = true;
                PatientsView.ajout.Visible = false;
                textAdresse.Text = patient.Adresse;
                textAge.Text = "" + patient.Age;
                textNomP.Text = patient.Nom;
                textMemo.Text = patient.Memo;
                textPersonResp.Text = patient.PersonneResponsable;
                textPrenom.Text = patient.Prenom;
                textTelPersRes.Text = patient.TelPersonResp;
                comboSexe.SelectedIndex = -1;
                textEmail.Text = patient.Email;
                textTel.Text = patient.Telephone;
                textId.Text = patient.Id;
                comboSexe.SelectedIndex = comboSexe.FindStringExact(patient.Sexe);
                dateTimePicker1.Value = DateTime.Parse(patient.DateNaissance);
                Utils.selectedChekedlistBox(checkedListComp, patient.CompagnieAssure);
                Utils.selectedChekedlistBox(checkedListTrait, patient.TraitementSuiv);
                btnRegister.Visible = false;
                btnUpdate.Visible = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetData();
        }

        private void resetData()
        {
            textAdresse.Text = null;
            textMemo.Text = null;
            textAge.Text = null;
            textNomP.Text = null;
            textPersonResp.Text = null;
            textPrenom.Text = null;
            textTelPersRes.Text = null;
            comboSexe.SelectedIndex = -1;
            textEmail.Text = null;
            textTel.Text = null;
            dateTimePicker1.Value = DateTime.Parse(DateTime.Now.ToShortTimeString());
            Utils.reesetselectedChekedlistBox(checkedListComp, Utils.chekedListToString(checkedListComp));
            Utils.reesetselectedChekedlistBox(checkedListTrait, Utils.chekedListToString(checkedListTrait));
        }


        DateTime d = DateTime.Now;

      

        

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            src.Patients patient = new src.Patients();
            bool testN = false, testP = false, testS = false, testD = false, testNP = false, testTelP = false,
                testAdr = false, testEm = false, testTel = false, testTrait = false, testM = false;
            if (Utils.stringOnly(Utils.cleanUp(textNomP.Text), "Nom Patient"))
            {
                testN = true;
                patient.Nom = Utils.cleanUp(textNomP.Text);
            }

           if(Utils.stringOnly(Utils.cleanUp(textPrenom.Text), "Prenom Patient"))
           {
                testP = true;
                patient.Prenom = Utils.cleanUp(textPrenom.Text);
           }
            if (Utils.comboSelected(comboSexe, "Sexe"))
            {
                testS = true;
                patient.Sexe = comboSexe.SelectedItem.ToString();
            }
            if (d < dateTimePicker1.Value)
            {
                MessageBox.Show("La date de naissance est invalide", "Date naissance");
            }
            else
            {
                testD = true;
                patient.DateNaissance = dateTimePicker1.Value.ToString("MM/dd/yyyy");
                String[] array = d.ToShortDateString().Split('/');
                String[] array2 = dateTimePicker1.Value.ToString("MM/dd/yyyy").Split('/');
                double number = Double.Parse(array[2]) - Double.Parse(array2[2]);
                patient.Age = int.Parse("" + number);

            }

            if (Utils.stringOnly(Utils.cleanUp(textPersonResp.Text), "Personne responsable"))
            {
                testNP = true;
                patient.PersonneResponsable = Utils.cleanUp(textPersonResp.Text);
            }

            if (Utils.phoneCorrect(Utils.cleanUp(textTelPersRes.Text)))
            {
                patient.TelPersonResp = Utils.cleanUp(textTelPersRes.Text);
                testTelP = true;
            }
            if (Utils.adresseCorrect(Utils.cleanUp(textAdresse.Text)))
            {
                patient.Adresse = Utils.cleanUp(textAdresse.Text);
                testAdr = true;
            }
            if (!String.IsNullOrEmpty(Utils.cleanUp(textEmail.Text)))
            {
                if (Utils.isValidMail(Utils.cleanUp(textEmail.Text)))
                {
                    testEm = true;
                    patient.Email = textEmail.Text;
                }
            }
            else
            {
                testEm = true;
                patient.Email = null;
            }
            if (Utils.phoneCorrect(Utils.cleanUp(textTel.Text)))
            {
                testTel = true;
                patient.Telephone = Utils.cleanUp(textTel.Text);
            }
            if (Utils.isSelectedOnList(checkedListTrait, "Traitement"))
            {
                testTrait = true;
                patient.TraitementSuiv = Utils.chekedListToString(checkedListTrait);
            }
            if(Utils.stringAndNumber(Utils.cleanUp(textMemo.Text), "Memo"))
            {
                testM = true;
                patient.Memo = Utils.cleanUp(textMemo.Text);
            }
            patient.CompagnieAssure = Utils.chekedListToString(checkedListComp);
            if (testN && testP && testS && testD && testNP && testTelP &&
                testAdr && testEm && testTel && testTrait && testM)
            {
                if (PatientsModel.enregistrer(patient) == 1)
                {
                    MessageBox.Show("Enregistrement reussi!", "Enregistrer");
                    this.resetData();
                    Utils.loadform(PatientsView.p, new ShowPatients());
                }
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            src.Patients patient = new src.Patients();
            patient.Id = textId.Text;
            bool testN = false, testP = false, testS = false, testD = false, testNP = false, testTelP = false,
                testAdr = false, testEm = false, testTel = false, testTrait = false, testM = false;
            if (Utils.stringOnly(Utils.cleanUp(textNomP.Text), "Nom Patient"))
            {
                testN = true;
                patient.Nom = Utils.cleanUp(textNomP.Text);
            }
            if (Utils.stringOnly(Utils.cleanUp(textPrenom.Text), "Prenom Patient"))
            {
                testP = true;
                patient.Prenom = Utils.cleanUp(textPrenom.Text);
            }
            if (Utils.comboSelected(comboSexe, "Sexe"))
            {
                testS = true;
                patient.Sexe = comboSexe.SelectedItem.ToString();
            }
            if (d < dateTimePicker1.Value)
            {
                MessageBox.Show("La date de naissance est invalide", "Date naissance");
            }
            else
            {
                testD = true;
                patient.DateNaissance = dateTimePicker1.Value.ToString("MM/dd/yyyy");
                String[] array = d.ToShortDateString().Split('/');
                String[] array2 = dateTimePicker1.Value.ToString("MM/dd/yyyy").Split('/');
                double number = Double.Parse(array[2]) - Double.Parse(array2[2]);
                patient.Age = int.Parse("" + number);

            }

            if (Utils.stringOnly(Utils.cleanUp(textPersonResp.Text), "Personne responsable"))
            {
                testNP = true;
                patient.PersonneResponsable = Utils.cleanUp(textPersonResp.Text);
            }

            if (Utils.phoneCorrect(Utils.cleanUp(textTelPersRes.Text)))
            {
                patient.TelPersonResp = Utils.cleanUp(textTelPersRes.Text);
                testTelP = true;
            }
            if (Utils.adresseCorrect(Utils.cleanUp(textAdresse.Text)))
            {
                patient.Adresse = Utils.cleanUp(textAdresse.Text);
                testAdr = true;
            }
            if (!String.IsNullOrEmpty(Utils.cleanUp(textEmail.Text)))
            {
                if (Utils.isValidMail(Utils.cleanUp(textEmail.Text)))
                {
                    testEm = true;
                    patient.Email = textEmail.Text;
                }
            }
            else
            {
                testEm = true;
                patient.Email = null;
            }
            if (Utils.phoneCorrect(Utils.cleanUp(textTel.Text)))
            {
                testTel = true;
                patient.Telephone = Utils.cleanUp(textTel.Text);
            }
            if (Utils.isSelectedOnList(checkedListTrait, "Traitement"))
            {
                testTrait = true;
                patient.TraitementSuiv = Utils.chekedListToString(checkedListTrait);
            }
            if (Utils.stringAndNumber(Utils.cleanUp(textMemo.Text), "Memo"))
            {
                testM = true;
                patient.Memo = Utils.cleanUp(textMemo.Text);
            }
            patient.CompagnieAssure = Utils.chekedListToString(checkedListComp);
            if (testN && testP && testS && testD && testNP && testTelP &&
                testAdr && testEm && testTel && testTrait && testM)
            {
                if (PatientsModel.update(patient) == 1)
                {
                    MessageBox.Show("Modification reussi!", "Modifier");
                    this.resetData();
                    Utils.loadform(PatientsView.p, new ShowPatients());
                }
            }
            PatientsView.ajout.Visible = true;
            PatientsView.affich.Visible = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // MessageBox.Show(tab[2]);
            String[] array = d.ToShortDateString().Split('/');
            String[] array2 = dateTimePicker1.Value.ToString("MM/dd/yyyy").Split('/');
            double number = Double.Parse(array[2]) - Double.Parse(array2[2]);
            textAge.Text = "" + int.Parse("" + number);
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            resetData();
        }
    }
}
