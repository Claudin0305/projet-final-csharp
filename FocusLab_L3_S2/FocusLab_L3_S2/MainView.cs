using FocusLab_L3_S2.Views;
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

namespace FocusLab_L3_S2
{
    public partial class MainView : Form
    {
        public static Panel mainPanel_stat,
            header = null, panel_ser, panel_user, panel_pat, panel_pers, panel_cont,
            panel_consul, panel_ch, panel_aside, log_out;
        public static Button btn_h = null;
        public MainView()
        {
            InitializeComponent();
            header = headerMenu;
            header = headerMenu;
            btn_h = btnHome;
            mainPanel_stat = mainPanel;
            panel_ser = panelServices;
            panel_user = panelUtilisateur;
            panel_pat = panelPatients;
            panel_pers = panelPersonel;
            panel_cont = panelContrats;
            panel_consul = panelConsultation;
            panel_ch = panelChambre;
            panel_aside = asideMenu;
            log_out = panelLogOut;

            this.Text = "Home";
            utils.Utils.loadform(mainPanel, new Login());
        }

        /**
         Pour injecter les formulaires dans le mainPanel
        
        public void loadform(object Form)
        {
            if (this.mainPanel.Controls.Count > 0)
            {
                this.mainPanel.Controls.RemoveAt(0);
            }
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(f);
            this.mainPanel.Tag = f;
            f.Show();
            
        }
        */


        private void btn_chambre_Click_1(object sender, EventArgs e)
        {

            utils.Utils.loadform(mainPanel, new Views.Chambres.ChambresView());
            this.Text = "Chambres";
            resetDesign();
            activate(btn_chambre, pCh);
        }

        private void btn_personnel_Click_1(object sender, EventArgs e)
        {
            utils.Utils.loadform(mainPanel, new Views.Personnels.PersonnelsView());
            this.Text = "Personnels";
            resetDesign();
            activate(btn_personnel, pPers);

        }

        private void btn_contrats_Click_1(object sender, EventArgs e)
        {
            utils.Utils.loadform(mainPanel, new Views.Assurances.AssurancesView());
            this.Text = "Contrats Assurances";
            resetDesign();
            activate(btn_contrats, pContrat);
        }

        private void logout_Click(object sender, EventArgs e)
        {
            disableAll();

            header = headerMenu;
            header = headerMenu;
            btn_h = btnHome;
            mainPanel_stat = mainPanel;
            panel_ser = panelServices;
            panel_user = panelUtilisateur;
            panel_pat = panelPatients;
            panel_pers = panelPersonel;
            panel_cont = panelContrats;
            panel_consul = panelConsultation;
            panel_ch = panelChambre;
            panel_aside = asideMenu;

            this.Text = "Home";
            resetDesign();
            utils.Utils.loadform(mainPanel, new Login());
        }

        private void btn_patients_Click_1(object sender, EventArgs e)
        {
            utils.Utils.loadform(mainPanel, new Views.Patients.PatientsView());
            this.Text = "Patients";
            resetDesign();
            activate(btn_patients, pPatient);
        }

        private void btn_cosultation_Click(object sender, EventArgs e)
        {
            utils.Utils.loadform(mainPanel, new Views.Consultations.ConsultationsView());
            this.Text = "Consultations";
            resetDesign();
            activate(btn_cosultation, pCons);
        }

        private void btn_utilisateurs_Click_1(object sender, EventArgs e)
        {
            utils.Utils.loadform(mainPanel, new Views.Utilisateurs.UtilisateursView());
            this.Text = "Utilisateurs";
            resetDesign();
            activate(btn_utilisateurs, pUtilisateur);
        }

        private void btn_examens_Click_1(object sender, EventArgs e)
        {

            utils.Utils.loadform(mainPanel, new Views.Examens.ExamensView());
        }

        private void resetDesign()
        {
            Button[] buttons = {btn_chambre, btn_contrats, btn_examens, btn_patients, btn_personnel,
                                btn_services, btn_utilisateurs, btn_cosultation, btnHome};
            Panel[] panels = {pCh, pCons, pContrat, pExa, pPatient, pPers, pServ, pUtilisateur};

            foreach(Button btn in buttons)
            {
                btn.ForeColor = Color.FromArgb(60, 70, 96);
            }

            foreach(Panel p in panels)
            {
                p.BackColor = Color.Transparent;
                p.Visible = false;
            }
        }

        private void activate(Button button, Panel panel)
        {
            button.ForeColor = Color.FromArgb(30, 191, 194);
            panel.BackColor = Color.FromArgb(30, 191, 194);
            panel.Visible = true;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {

            this.Text = "Home";
            utils.Utils.loadform(mainPanel, new Views.Dashboard.StatistiqueView());
            resetDesign();
        }

        private void btn_services_Click(object sender, EventArgs e)
        {
            utils.Utils.loadform(mainPanel, new ServiceView());
            this.Text = "Services";
            resetDesign();
            activate(btn_services, pServ);
        }

        
        private void disableAll()
        {
            Panel[] panels = {asideMenu, panelPersonel, panelPatients, panelLogOut, panelChambre,
                               panelConsultation, panelContrats, panelServices, panelUtilisateur, header};
            foreach(Panel p in panels)
            {
                p.Visible = false;
            }
        }
    }
}
