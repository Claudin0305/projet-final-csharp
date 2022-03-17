using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using FocusLab_L3_S2.src;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FocusLab_L3_S2.Model;
using FocusLab_L3_S2.utils;


namespace FocusLab_L3_S2.Views.Consultations
{
    public partial class ConsultationsRegister : Form
    {
        private src.Consultations consultation = null;
        private bool testHopitalisation, selectH;
        private string id= null;
        private bool change = false;
        public ConsultationsRegister(src.Consultations consultation)
        {
            this.consultation = consultation;
            this.testHopitalisation = false;
            this.selectH = false;
            InitializeComponent();
            Utils.loadStringInChecked(checkedListBoxServices, ServicesModel.getListServices());
            Utils.loadStringInChecked(checkedListMedecin, PersonnelsModel.getMedecins());
            Utils.addToCombo(comboIdCh, ChambresModel.getListIdChDisponible());
            Utils.addToCombo(comboNoDossier, PatientsModel.getListIdPatient());
            if (ChambresModel.getListIdChDisponible().Count > 0 && PersonnelsModel.getMedecins().Count > 0)
            {
                panelNeceHosp.Enabled = true;
            }

            if (consultation != null)
            {
                ConsultationsView.affich.Visible = true;
                ConsultationsView.ajout.Visible = false;
                dateTimeCons.Enabled = true;
                btnRegister.Visible = false;
                btnUpdate.Visible = true;
                dateTimeCons.Value = DateTime.Parse(consultation.DateConsOrHosp);
                Utils.selectedChekedlistBox(checkedListBoxServices, consultation.ConsultationPrServices);
                Utils.selectedChekedlistBox(checkedListMedecin, consultation.MedecinEnCharge);
                textId.Text = consultation.Id;
                textMotif.Text = consultation.MotifConsultation;
                textDureHosp.Text = ""+consultation.DureeHospital;
                if (consultation.HospitalisationSurAss.Equals("Oui"))
                {
                    radioHosAssY.Checked = true;
                }
                else
                {
                    radioHosAssN.Checked = true;
                }
                if (consultation.NecessiteHospita.Equals("Oui"))
                {
                    radioHospYess.Checked = true;
                    showPanel();

                }
                else
                {
                    radioHospNo.Checked = true;
                    hidePanel();
                }

                if (consultation.ConsultationPayAss.Equals("Oui"))
                {
                    radioBtnYesAss.Checked = true;
                }
                else
                {
                    radioBtnNoAss.Checked = true;
                }
                comboIdCh.SelectedIndex = comboIdCh.FindStringExact(consultation.IdChambre);
                comboNoDossier.SelectedIndex = comboNoDossier.FindStringExact(consultation.NoDossierPatient);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dataReset();
        }

        private void dataReset()
        {
            textDureHosp.Text = null;
            textMotif.Text = null;
            radioBtnNoAss.Checked = false;
            radioHospYess.Checked = false;
            radioHospNo.Checked = false;
            radioBtnYesAss.Checked = false;
            radioHosAssN.Checked = false;
            radioHosAssY.Checked = false;
            comboIdCh.SelectedIndex = -1;
            //checkedListBoxServices.SelectedIndices;
            comboNoDossier.SelectedIndex = -1;
            dateTimeCons.Value = DateTime.Parse(DateTime.Now.ToShortDateString());
            Utils.reesetselectedChekedlistBox(checkedListMedecin, Utils.chekedListToString(checkedListMedecin));
            Utils.reesetselectedChekedlistBox(checkedListBoxServices, Utils.chekedListToString(checkedListBoxServices));
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // register
            if (change)
            {
                if (PatientsModel.getListCompById(comboNoDossier.SelectedItem.ToString()).Count > 0)
                {
                    panelPayAs.Enabled = true;
                    panelHopAss.Enabled = true;
                }
            }
            
            bool testD = false, testM = false, testA = false, testMotif = false, testIdCh = false,
                testListServ = false, testCombo = false;
            src.Consultations consultation = new src.Consultations();
            if(Utils.comboSelected(comboNoDossier, "Numero dossier"))
            {
                testCombo = true;
                consultation.NoDossierPatient = comboNoDossier.SelectedItem.ToString();
            }
            if (Utils.isSelectedOnList(checkedListBoxServices, "Consultations Pour les serv."))
            {
                consultation.ConsultationPrServices = Utils.chekedListToString(checkedListBoxServices);
                testListServ = true;

            }
            if (panelNeceHosp.Enabled)
            {
                if (this.selectH)
                {
                    if (this.testHopitalisation)
                    {
                        consultation.NecessiteHospita = "Oui";
                    }
                    else
                    {
                        consultation.NecessiteHospita = "Non";
                    }
                }
                else
                {
                    MessageBox.Show("Vous devez choisir un des options", "Necessite Hospitalisation");
                }
                
            }
            else
            {

                consultation.NecessiteHospita = "Non";
                this.selectH = true;
            }

            if (panelHopAss.Enabled)
            {
                if (Utils.radioButtonChooser(radioBtnNoAss.Checked, radioBtnYesAss.Checked, "Couvrir par assurance"))
                {
                    if (radioBtnYesAss.Checked)
                    {
                        consultation.ConsultationPayAss = "Oui";
                    }
                    else if (radioBtnNoAss.Checked)
                    {
                        consultation.ConsultationPayAss = "Non";
                    }
                    testA = true;
                }
            }
            else
            {
                consultation.ConsultationPayAss = "Non";
                testA = true;
            }
            if (!String.IsNullOrEmpty(textMotif.Text))
            {
                testMotif = true;
                consultation.MotifConsultation = textMotif.Text;
            }
            else
            {
                MessageBox.Show("Vous devez donner une motif", "Motif consultation");
            }
            
            
            if (this.testHopitalisation)
            {
                if (panelHopAss.Enabled)
                {
                    if (Utils.radioButtonChooser(radioHosAssY.Checked, radioHosAssN.Checked, "Payer par Assurance"))
                    {
                        if (radioHosAssY.Checked)
                        {
                            consultation.HospitalisationSurAss = "Oui";

                        }
                        else if (radioHosAssN.Checked)
                        {
                            consultation.HospitalisationSurAss = "Non";
                        }
                        testA = true;
                    }
                }
                else
                {
                    consultation.HospitalisationSurAss = "Non";
                    testA = true;
                }
                if (Utils.comboSelected(comboIdCh, "Numero chambre"))
                {
                    testIdCh = true;
                    consultation.IdChambre = comboIdCh.SelectedItem.ToString();
                }
                if (Utils.numberOnly(textDureHosp.Text, "Duree Hospitalisation"))
                {
                    testD = true;
                    consultation.DureeHospital = int.Parse(textDureHosp.Text.ToString());
                }
                if (Utils.isSelectedOnList(checkedListBoxServices, "Medecin en charge"))
                {
                    testM = true;
                    consultation.MedecinEnCharge = Utils.chekedListToString(checkedListMedecin);
                }
                
            }

            consultation.DateConsOrHosp = DateTime.Now.ToString("MM/dd/yyyy");
            if (this.testHopitalisation)
            {
                if(testD && testM && testIdCh && testCombo && testA && testListServ)
                {
                    if (ConsultationsModel.enregistrer(consultation) == 1)
                    {

                        MessageBox.Show("Enregistrement reussi!", "Enregistrer");
                        this.dataReset();
                        Utils.loadform(ConsultationsView.p, new ShowConsultations());
                    }
                    
                }
            }
            else
            {
                if(this.selectH && testListServ && testCombo && testA && testMotif)
                {
                    consultation.MedecinEnCharge = null;
                    consultation.IdChambre = null;
                    if (ConsultationsModel.enregistrer(consultation) == 1)
                    {

                        MessageBox.Show("Enregistrement reussi!", "Enregistrer");
                        this.dataReset();
                        Utils.loadform(ConsultationsView.p, new ShowConsultations());
                    }
                }
            }
            
        }

        private void radioHospYess_Click(object sender, EventArgs e)
        {
            this.testHopitalisation = true;
            showPanel();
            this.selectH = true;
            
        }

        private void radioHospNo_Click(object sender, EventArgs e)
        {

            hidePanel();
            this.selectH = true;
            this.testHopitalisation = false;
        }

        private void showPanel()
        {
            panelHopAss.Visible = true;
            panelChambre.Visible = true;
            panelDuree.Visible = true;
            panelMedecin.Visible = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // register
            if (change)
            {
                id = comboNoDossier.SelectedItem.ToString();
                if (PatientsModel.getListCompById(id).Count > 0)
                {
                    panelPayAs.Enabled = true;
                    panelHopAss.Enabled = true;
                }
            }


            bool testD = false, testM = false, testA = false, testMotif = false, testIdCh = false,
                testListServ = false, testCombo = false;
            src.Consultations consultation = new src.Consultations();
            this.radioHospYess_Click(sender, e);
            this.radioHospNo_Click(sender, e);
            consultation.Id = textId.Text;
            if (Utils.comboSelected(comboNoDossier, "Numero dossier"))
            {
                testCombo = true;
                consultation.NoDossierPatient = comboNoDossier.SelectedItem.ToString();
            }
            if (Utils.isSelectedOnList(checkedListBoxServices, "Consultations Pour les serv."))
            {
                consultation.ConsultationPrServices = Utils.chekedListToString(checkedListBoxServices);
                testListServ = true;

            }
            if (this.selectH)
            {
                if (this.testHopitalisation)
                {
                    consultation.NecessiteHospita = "Oui";
                }
                else
                {
                    consultation.NecessiteHospita = "Non";
                }
            }
            else
            {
                MessageBox.Show("Vous devez choisir un des options", "Necessite Hospitalisation");
            }

            if (panelHopAss.Enabled)
            {
                if (Utils.radioButtonChooser(radioBtnNoAss.Checked, radioBtnYesAss.Checked, "Couvrir par assurance"))
                {
                    if (radioBtnYesAss.Checked)
                    {
                        consultation.ConsultationPayAss = "Oui";
                    }
                    else if (radioBtnNoAss.Checked)
                    {
                        consultation.ConsultationPayAss = "Non";
                    }
                    testA = true;
                }
            }
            else
            {
                consultation.ConsultationPayAss = "Non";
                testA = true;
            }
            if (!String.IsNullOrEmpty(textMotif.Text))
            {
                testMotif = true;
                consultation.MotifConsultation = textMotif.Text;
            }
            else
            {
                MessageBox.Show("Vous devez donner une motif", "Motif consultation");
            }


            if (this.testHopitalisation)
            {
                if (panelHopAss.Enabled)
                {
                    if (Utils.radioButtonChooser(radioHosAssY.Checked, radioHosAssN.Checked, "Payer par Assurance"))
                    {
                        if (radioHosAssY.Checked)
                        {
                            consultation.HospitalisationSurAss = "Oui";

                        }
                        else if (radioHosAssN.Checked)
                        {
                            consultation.HospitalisationSurAss = "Non";
                        }
                        testA = true;
                    }
                }
                else
                {

                    consultation.HospitalisationSurAss = "Non";
                    testA = true;
                }
                if (Utils.comboSelected(comboIdCh, "Numero chambre"))
                {
                    testIdCh = true;
                    consultation.IdChambre = comboIdCh.SelectedItem.ToString();
                }
                
                if (Utils.numberOnly(textDureHosp.Text, "Duree Hospitalisation"))
                {
                    testD = true;
                    consultation.DureeHospital = int.Parse(textDureHosp.Text.ToString());
                }
                if (Utils.isSelectedOnList(checkedListBoxServices, "Medecin en charge"))
                {
                    testM = true;
                    consultation.MedecinEnCharge = Utils.chekedListToString(checkedListMedecin);
                }

                consultation.DateConsOrHosp = dateTimeCons.Value.ToString("MM/dd/yyyy");
                if (testD && testM && testIdCh && testCombo && testA && testListServ)
                {
                    if (ConsultationsModel.update(consultation) == 1)
                    {

                        MessageBox.Show("Modification reussi!", "Modifier");
                        this.dataReset();
                        Utils.loadform(ConsultationsView.p, new ShowConsultations());
                    }

                }
            }
            else 
            {
                consultation.DateConsOrHosp = dateTimeCons.Value.ToString("MM/dd/yyyy");
                if (this.selectH && testListServ && testCombo && testA && testMotif)
                {
                    consultation.MedecinEnCharge = null;
                    consultation.IdChambre = null;
                    if (ConsultationsModel.update(consultation) == 1)
                    {

                        MessageBox.Show("Modification reussi!", "Modifier");
                        this.dataReset();
                        Utils.loadform(ConsultationsView.p, new ShowConsultations());
                    }
                }
            }

            ConsultationsView.ajout.Visible = true;
            ConsultationsView.affich.Visible = false;

        }

        private void comboNoDossier_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            change = true;
            test();
        }

       public void test()
       {
            try
            {
                 if (PatientsModel.getListCompById(comboNoDossier.SelectedItem.ToString()).Count > 0)
                 {
                    panelPayAs.Enabled = true;
                    panelHopAss.Enabled = true;
                 }
            }catch(Exception e)
            {
            }
             
            
       }

        private void comboNoDossier_SelectedValueChanged(object sender, EventArgs e)
        {
            //test();
        }

        private void hidePanel()
        {
            panelHopAss.Visible = false;
            panelChambre.Visible = false;
            panelDuree.Visible = false;
            panelMedecin.Visible = false;
        }
    }
}
