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

namespace FocusLab_L3_S2.Views.Dashboard
{
    public partial class StatistiqueView : Form
    {
        public StatistiqueView()
        {
            InitializeComponent();
            tUs.Text += UtilisateursModel.getAll().Count;
            usAct.Text += UtilisateursModel.countUserActif();
            usInac.Text += (UtilisateursModel.getAll().Count - UtilisateursModel.countUserActif());

            tPers.Text += PersonnelsModel.getAll().Count;
            persAct.Text += PersonnelsModel.getListIdPersonnels().Count;
            persQ.Text += (PersonnelsModel.getAll().Count - PersonnelsModel.getListIdPersonnels().Count);

            tServ.Text += ServicesModel.getAll().Count;
            sDisp.Text += ServicesModel.getListServices().Count;
            servInd.Text += (ServicesModel.getAll().Count - ServicesModel.getListServices().Count);

            tPat.Text += PatientsModel.getAll().Count;
            homme.Text += PatientsModel.countHomme();
            femme.Text += (PatientsModel.getAll().Count - PatientsModel.countHomme());

            tCh.Text += ChambresModel.getAll().Count;
            chDispo.Text += ChambresModel.getListIdChDisponible().Count;
            chIndispo.Text += (ChambresModel.getAll().Count - ChambresModel.getListIdChDisponible().Count);

            tCons.Text += ConsultationsModel.getAll().Count;
            Hospitalisation.Text += ConsultationsModel.countHospitalisation();

            tCont.Text += AssurancesModel.getAll().Count;
            cEn.Text += AssurancesModel.getListCompagnie().Count;
            cR.Text += (AssurancesModel.getAll().Count - AssurancesModel.getListCompagnie().Count);
        }
    }
}
