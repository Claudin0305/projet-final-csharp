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

namespace FocusLab_L3_S2.Views.Assurances
{
    public partial class AssurancesRegister : Form
    {
        public AssurancesRegister(src.Assurances assurance)
        {
            InitializeComponent();
            if(assurance != null)
            {
                btnRegister.Visible = false;
                btnUpdate.Visible = true;
                textId.Text = assurance.Id;
                textAdresse.Text = assurance.Adresse;
                textPercCh.Text = "" + assurance.PercentPaimentCh;
                textPercCons.Text = "" + assurance.PercentPaimentCons;
                textPercHos.Text = "" + assurance.PercentPaimentHosp;
                textEmail.Text = assurance.Email;
                textTel.Text = assurance.Telephone;
                textNomComp.Text = assurance.NomCompagnie;
                textNomDir.Text = assurance.NomDirecteur;
                comboEtat.SelectedIndex = comboEtat.FindStringExact(assurance.Etat);
                textSigle.Text = assurance.Sigle;
                AssurancesView.affich.Visible = true;
                AssurancesView.ajout.Visible = false;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetData();
        }
        private void resetData()
        {
            textNomComp.Text = null;
            textNomDir.Text = null;
            textAdresse.Text = null;
            textEmail.Text = null;
            textPercCh.Text = null;
            textPercCons.Text = null;
            textPercHos.Text = null;
            comboEtat.SelectedIndex = -1;
            textTel.Text = null;
            textSigle.Text = null;
            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            src.Assurances assurance = new src.Assurances();
            bool testN = false, testS = false, testND = false, testA = false, testTel = false, testMa = false,
                testPerC = false, testPercCh = false, testPercHost = false, testE = false;
            if(Utils.stringAndNumber(Utils.cleanUp(textNomComp.Text), "Nom compagnie"))
            {
                if (Utils.nomCompExiste(Utils.cleanUp(textNomComp.Text)))
                {
                    assurance.NomCompagnie = Utils.cleanUp(textNomComp.Text);
                    testN = true;
                }
            }
            if(Utils.stringAndNumber(Utils.cleanUp(textSigle.Text), "Sigle"))
            {
                testS = true;
                assurance.Sigle = Utils.cleanUp(textSigle.Text);
            }
            if(Utils.stringOnly(Utils.cleanUp(textNomDir.Text), "Nom Directeur"))
            {
                testND = true;
                assurance.NomDirecteur = Utils.cleanUp(textNomDir.Text);
            }
            if (Utils.adresseCorrect(Utils.cleanUp(textAdresse.Text)))
            {
                testA = true;
                assurance.Adresse = Utils.cleanUp(textAdresse.Text);
            }
            if (Utils.phoneCorrect(Utils.cleanUp(textTel.Text)))
            {
                testTel = true;
                assurance.Telephone = Utils.cleanUp(textTel.Text);
            }
            if (!String.IsNullOrEmpty(Utils.cleanUp(textEmail.Text)))
            {
                if (Utils.isValidMail(Utils.cleanUp(textEmail.Text)))
                {
                    testMa = true;
                    assurance.Email = Utils.cleanUp(textEmail.Text);
                }
            }
            else
            {

                testMa = true;
                assurance.Email = Utils.cleanUp(textEmail.Text);
            }
            if(Utils.numberOnly(Utils.cleanUp(textPercCons.Text), "% Consultation"))
            {
                double p = Double.Parse(Utils.cleanUp(textPercCons.Text));
                if(Utils.correctPercent(p, "% Consultation"))
                {
                    testPerC = true;
                    assurance.PercentPaimentCons = p;
                }
            }

            if (Utils.numberOnly(Utils.cleanUp(textPercCh.Text), "% Chambre"))
            {
                double p = Double.Parse(Utils.cleanUp(textPercCh.Text));
                if (Utils.correctPercent(p, "% Chambre"))
                {
                    testPercCh = true;
                    assurance.PercentPaimentCh = p;
                }
            }
            if (Utils.numberOnly(Utils.cleanUp(textPercHos.Text), "% Hospitalisation"))
            {
                double p = Double.Parse(Utils.cleanUp(textPercHos.Text));
                if (Utils.correctPercent(p, "% Hospitalisation"))
                {
                    testPercHost = true;
                    assurance.PercentPaimentHosp = p;
                }
            }

            if(Utils.comboSelected(comboEtat, "Etat"))
            {
                testE = true;
                assurance.Etat = comboEtat.SelectedItem.ToString();
            }
            if (testN && testS && testND && testA && testTel && testMa &&
                testPerC && testPercCh && testPercHost && testE)
            {

                if (AssurancesModel.enregistrer(assurance) == 1)
                {
                    MessageBox.Show("Enregistrement reussi!", "Enregistrer");
                    resetData();
                    Utils.loadform(AssurancesView.p, new ShowAssurances());
                }

                AssurancesView.ajout.Visible = false;
                AssurancesView.affich.Visible = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            src.Assurances assurance = new src.Assurances();
            assurance.Id = textId.Text;
            bool testN = false, testS = false, testND = false, testA = false, testTel = false, testMa = false,
                testPerC = false, testPercCh = false, testPercHost = false, testE = false;
            if (Utils.stringAndNumber(Utils.cleanUp(textNomComp.Text), "Nom compagnie"))
            {
                if (Utils.nomCompExisteForUpdate(textId.Text, Utils.cleanUp(textNomComp.Text)))
                {
                    assurance.NomCompagnie = Utils.cleanUp(textNomComp.Text);
                    testN = true;
                }
            }
            if (Utils.stringAndNumber(Utils.cleanUp(textSigle.Text), "Sigle"))
            {
                testS = true;
                assurance.Sigle = Utils.cleanUp(textSigle.Text);
            }
            if (Utils.stringOnly(Utils.cleanUp(textNomDir.Text), "Nom Directeur"))
            {
                testND = true;
                assurance.NomDirecteur = Utils.cleanUp(textNomDir.Text);
            }
            if (Utils.adresseCorrect(Utils.cleanUp(textAdresse.Text)))
            {
                testA = true;
                assurance.Adresse = Utils.cleanUp(textAdresse.Text);
            }
            if (Utils.phoneCorrect(Utils.cleanUp(textTel.Text)))
            {
                testTel = true;
                assurance.Telephone = Utils.cleanUp(textTel.Text);
            }
            if (!String.IsNullOrEmpty(Utils.cleanUp(textEmail.Text)))
            {
                if (Utils.isValidMail(Utils.cleanUp(textEmail.Text)))
                {
                    testMa = true;
                    assurance.Email = Utils.cleanUp(textEmail.Text);
                }
            }
            else
            {

                testMa = true;
                assurance.Email = Utils.cleanUp(textEmail.Text);
            }
            if (Utils.numberOnly(Utils.cleanUp(textPercCons.Text), "% Consultation"))
            {
                double p = Double.Parse(Utils.cleanUp(textPercCons.Text));
                if (Utils.correctPercent(p, "% Consultation"))
                {
                    testPerC = true;
                    assurance.PercentPaimentCons = p;
                }
            }

            if (Utils.numberOnly(Utils.cleanUp(textPercCh.Text), "% Chambre"))
            {
                double p = Double.Parse(Utils.cleanUp(textPercCh.Text));
                if (Utils.correctPercent(p, "% Chambre"))
                {
                    testPercCh = true;
                    assurance.PercentPaimentCh = p;
                }
            }
            if (Utils.numberOnly(Utils.cleanUp(textPercHos.Text), "% Hospitalisation"))
            {
                double p = Double.Parse(Utils.cleanUp(textPercHos.Text));
                if (Utils.correctPercent(p, "% Hospitalisation"))
                {
                    testPercHost = true;
                    assurance.PercentPaimentHosp = p;
                }
            }

            if (Utils.comboSelected(comboEtat, "Etat"))
            {
                testE = true;
                assurance.Etat = comboEtat.SelectedItem.ToString();
            }
            if (testN && testS && testND && testA && testTel && testMa && testPerC && testPercCh
                && testPercHost && testE)
            {
                if (AssurancesModel.update(assurance) == 1)
                {
                    MessageBox.Show("Modification reussi!", "Modifier");
                    resetData();
                    Utils.loadform(AssurancesView.p, new ShowAssurances());
                }

            }

            AssurancesView.ajout.Visible = false;
            AssurancesView.affich.Visible = true;
        }
    }
}
