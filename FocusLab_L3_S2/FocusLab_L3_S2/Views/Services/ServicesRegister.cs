using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using FocusLab_L3_S2.src;
using FocusLab_L3_S2.Model;
using FocusLab_L3_S2.utils;

namespace FocusLab_L3_S2.Views.Services
{
    public partial class ServicesRegister : Form
    {
        src.Services service = null;
        public ServicesRegister(src.Services service)
        {
            this.service = service;
            InitializeComponent();
            if(this.service != null)
            {
                ServiceView.affich.Visible = true;
                ServiceView.ajout.Visible = false;
                textId.Text = service.Id;
                textNom.Text = service.Nom;
                textPrix.Text = ""+service.PrixConsultation;
                textChef.Text = service.NomChefDeService;
                textDescription.Text = service.Description;

                if (service.CouvrirParAssurance.Equals("Oui"))
                {
                    radioBtnYesAss.Checked = true;
                }else if (service.CouvrirParAssurance.Equals("Non"))
                {
                    radioBtnNoAss.Checked = true;
                }

                if (service.Etat.Equals("D"))
                {
                    radioBtnDEt.Checked = true;
                }
                else if (service.Etat.Equals("N"))
                {
                    radioBtnNEt.Checked = true;
                }
                if(textId.Text != null)
                {
                    btnRegister.Visible = false;
                    btnUpdate.Visible = true;
                }
            }
        }

        
        private void btnAffichage_Click(object sender, EventArgs e)
        {
            //utils.Utils.loadform()
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //reset
            resetData();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            bool testN = false, testS = false, testP = false, testC = false, testR = false, testE = false;
            src.Services service = new src.Services();
            if(Utils.stringOnly(Utils.cleanUp(textNom.Text), "Nom service"))
            {
                service.Nom = Utils.cleanUp(textNom.Text);
                testN = true;
            }
            

            if(Utils.serviceExiste(Utils.cleanUp(textNom.Text)))
            {

                service.Nom = Utils.cleanUp(textNom.Text);
                testS = true;
            }
            

            if(Utils.numberOnly(Utils.cleanUp(textPrix.Text), "Prix consultation"))
            {
                service.PrixConsultation = Double.Parse(Utils.cleanUp(textPrix.Text));
                testP = true;
            }
           

            if(Utils.stringOnly(Utils.cleanUp(textChef.Text), "Nom chef de service"))
            {
                service.NomChefDeService = Utils.cleanUp(textChef.Text);
                testC = true;
            }
            
            service.Description = textDescription.Text;
            if (Utils.radioButtonChooser(radioBtnNoAss.Checked, radioBtnYesAss.Checked, "Couvrir par assurance"))
            {
                if (radioBtnYesAss.Checked)
                {
                    service.CouvrirParAssurance = "Oui";
                }else if (radioBtnNoAss.Checked)
                {
                    service.CouvrirParAssurance = "Non";
                }
                testR = true;
            }
          
            

            if (Utils.radioButtonChooser(radioBtnDEt.Checked, radioBtnNEt.Checked, "Etat"))
            {
                if (radioBtnDEt.Checked)
                {
                    service.Etat = "D";
                }else if (radioBtnNEt.Checked)
                {
                    service.Etat = "N";
                }
                testE = true;

            }
           

            //Ajout de donnees
            if (testN && testC && testE && testS && testR && testP)
            {
                if (ServicesModel.enregistrer(service) == 1)
                {
                    MessageBox.Show("Enregistrement reussi!", "Enregistrer");
                    resetData();
                    Utils.loadform(ServiceView.p, new ShowServices());
                }
            }

           
            ServiceView.ajout.Visible = false;
            ServiceView.affich.Visible = true;
        }

        private void resetData()
        {
            textNom.Text = null;
            textPrix.Text = null;
            textChef.Text = null;
            textDescription.Text = null;
            radioBtnDEt.Checked = false;
            radioBtnNEt.Checked = false;
            radioBtnNoAss.Checked = false;
            radioBtnYesAss.Checked = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Update
            bool testN = false, testS = false, testP = false, testC = false, testR = false, testE = false;
            src.Services service = new src.Services();
            service.Id = textId.Text;
            
            if (Utils.stringOnly(Utils.cleanUp(textNom.Text), "Nom service"))
            {
                service.Nom = Utils.cleanUp(textNom.Text);
                testN = true;
            }
           

            if (Utils.serviceExisteForUpdate(textId.Text, Utils.cleanUp(textNom.Text)))
            {

                service.Nom = Utils.cleanUp(textNom.Text);
                testS = true;
            }
          

            if (Utils.numberOnly(Utils.cleanUp(textPrix.Text), "Prix consultation"))
            {
                service.PrixConsultation = Double.Parse(Utils.cleanUp(textPrix.Text));
                testP = true;
            }
            

            if (Utils.stringOnly(Utils.cleanUp(textChef.Text), "Nom chef de service"))
            {
                service.NomChefDeService = Utils.cleanUp(textChef.Text);
                testC = true;
            }
           
            service.Description = textDescription.Text;
            if (Utils.radioButtonChooser(radioBtnNoAss.Checked, radioBtnYesAss.Checked, "Couvrir par assurance"))
            {
                if (radioBtnYesAss.Checked)
                {
                    service.CouvrirParAssurance = "Oui";
                }
                else if (radioBtnNoAss.Checked)
                {
                    service.CouvrirParAssurance = "Non";
                }
                testR = true;
            }
           

            if (Utils.radioButtonChooser(radioBtnDEt.Checked, radioBtnNEt.Checked, "Etat"))
            {
                if (radioBtnDEt.Checked)
                {
                    service.Etat = "D";
                }
                else if (radioBtnNEt.Checked)
                {
                    service.Etat = "N";
                }
                testE = true;

            }
           
            if (testN && testC && testE && testS && testR && testP)
            {

                if (Model.ServicesModel.update(service) == 1)
                {
                    MessageBox.Show("Modification reussi!", "Modifier");
                    resetData();
                    Utils.loadform(ServiceView.p, new ShowServices());
                }
            }
            ServiceView.ajout.Visible = true;
            ServiceView.affich.Visible = false;

        }
    }
}
