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

namespace FocusLab_L3_S2.Views.Chambres
{
    public partial class ChambresRegister : Form
    {
        public ChambresRegister(src.Chambres chambre)
        {
            InitializeComponent();
            if(chambre != null)
            {


                ChambresView.ajout.Visible = false;
                ChambresView.affich.Visible = true;


                textId.Text = chambre.Id;
                textNomCh.Text = chambre.Nom;
                textDesc.Text = chambre.Description;
                textConstituants.Text = chambre.Constituants;
                comboEtat.SelectedIndex = comboEtat.FindStringExact(chambre.Etat);
                comboTypeCh.SelectedIndex = comboTypeCh.FindStringExact(chambre.Type);
                textPrix.Text = "" + chambre.PrixLocation;
                if (chambre.CouvrirParAssurance.Equals("Oui"))
                {
                    radioAssY.Checked = true;
                }else if (chambre.CouvrirParAssurance.Equals("Non"))
                {
                    radioAssN.Checked = true;
                }
                if(textId.Text != null)
                {
                    btnRegister.Visible = false;
                    btnUpdate.Visible = true;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetData();
        }

        private void resetData()
        {
            textNomCh.Text = null;
            textPrix.Text = null;
            textDesc.Text = null;
            textConstituants.Text = null;
            comboEtat.SelectedIndex = -1;
            comboTypeCh.SelectedIndex = -1;
            radioAssN.Checked = false;
            radioAssY.Checked = false;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            bool testN = false, testT = false, testAs = false, testP = false, testE = false,
                testC = false;
            src.Chambres chambre = new src.Chambres();
            if(Utils.stringAndNumber(Utils.cleanUp(textNomCh.Text), "Nom chambre"))
            {
                if (Utils.chambreeExiste(Utils.cleanUp(textNomCh.Text)))
                {
                    testN = true;
                    chambre.Nom = Utils.cleanUp(textNomCh.Text);
                }
            }

            if(Utils.comboSelected(comboTypeCh, "Type chambre"))
            {
                testT = true;
                chambre.Type = comboTypeCh.SelectedItem.ToString();
            }

            if(Utils.radioButtonChooser(radioAssN.Checked, radioAssY.Checked, "Couvrir par assurance"))
            {
                testAs = true;
                if (radioAssY.Checked)
                {
                    chambre.CouvrirParAssurance = "Oui";
                }else if (radioAssN.Checked)
                {
                    chambre.CouvrirParAssurance = "Non";
                }
            }
            if(Utils.numberOnly(Utils.cleanUp(textPrix.Text), "Prix Location par jour"))
            {
                testP = true;
                chambre.PrixLocation = Double.Parse(Utils.cleanUp(textPrix.Text));
            }

            if(Utils.comboSelected(comboEtat, "Etat chambre"))
            {
                testE = true;
                chambre.Etat = comboEtat.SelectedItem.ToString();
            }
            if (!String.IsNullOrEmpty(Utils.cleanUp(textConstituants.Text)))
            {
                testC = true;
                chambre.Constituants = Utils.cleanUp(textConstituants.Text);
            }
            else
            {
                MessageBox.Show("Ce champ ne peut etre null", "Constituants Chambre");
            }
            chambre.Description = textDesc.Text;
            if (testN && testT && testAs && testP && testE && testC)
            {
                if(ChambresModel.enregistrer(chambre) == 1)
                {
                    MessageBox.Show("Enregistrement reussi!", "Enregistrer");
                    resetData();
                    Utils.loadform(ChambresView.p, new ShowChambres());
                }
            }
            ChambresView.ajout.Visible = true;
            ChambresView.affich.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool testN = false, testT = false, testAs = false, testP = false, testE = false,
                testC = false;
            src.Chambres chambre = new src.Chambres();
            chambre.Id = textId.Text;
            if (Utils.stringAndNumber(Utils.cleanUp(textNomCh.Text), "Nom chambre"))
            {
                if (Utils.chambreExisteForUpdate(textId.Text, Utils.cleanUp(textNomCh.Text)))
                {
                    testN = true;
                    chambre.Nom = Utils.cleanUp(textNomCh.Text);
                }
            }

            if (Utils.comboSelected(comboTypeCh, "Type chambre"))
            {
                testT = true;
                chambre.Type = comboTypeCh.SelectedItem.ToString();
            }

            if (Utils.radioButtonChooser(radioAssN.Checked, radioAssY.Checked, "Couvrir par assurance"))
            {
                testAs = true;
                if (radioAssY.Checked)
                {
                    chambre.CouvrirParAssurance = "Oui";
                }
                else if (radioAssN.Checked)
                {
                    chambre.CouvrirParAssurance = "Non";
                }
            }
            if (Utils.numberOnly(Utils.cleanUp(textPrix.Text), "Prix Location par jour"))
            {
                testP = true;
                chambre.PrixLocation = Double.Parse(Utils.cleanUp(textPrix.Text));
            }

            if (Utils.comboSelected(comboEtat, "Etat chambre"))
            {
                testE = true;
                chambre.Etat = comboEtat.SelectedItem.ToString();
            }
            if (!String.IsNullOrEmpty(Utils.cleanUp(textConstituants.Text)))
            {
                testC = true;
                chambre.Constituants = Utils.cleanUp(textConstituants.Text);
            }
            else
            {
                MessageBox.Show("Ce champ ne peut etre null", "Constituants Chambre");
            }
            chambre.Description = textDesc.Text;
            if (testN && testT && testAs && testP && testE && testC)
            {
                if (ChambresModel.update(chambre) == 1)
                {
                    MessageBox.Show("Modification reussi!", "Modification");
                    resetData();
                    Utils.loadform(ChambresView.p, new ShowChambres());
                }

                ChambresView.ajout.Visible = true;
                ChambresView.affich.Visible = false;
            }
        }
    }
}
