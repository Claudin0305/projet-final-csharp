using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusLab_L3_S2.src
{
    public class Consultations
    {
        private String id;
        private String noDossierPatient;
        private string consultationPrServices;
        private String consultationPayAss;
        private String motifConsultation;
        private String necessiteHospita;
        private String hospitalisationSurAss;
        private String idChambre;
        private int dureeHospital;
        private String medecinEnCharge;
        private String dateConsOrHosp;

        public Consultations() { }

        public Consultations(String id, String noDossierPatient, String consultationPrServices, String consultationPayAss,
            String motifConsultation, String necessiteHospita, String hospitalisationSurAss, String idChambre, int dureeHospital,
            String medecinEnCharge, String dateConsOrHosp)
        {
            this.id = id;
            this.noDossierPatient = noDossierPatient;
            this.consultationPrServices = consultationPrServices;
            this.consultationPayAss = consultationPayAss;
            this.motifConsultation = motifConsultation;
            this.necessiteHospita = necessiteHospita;
            this.hospitalisationSurAss = hospitalisationSurAss;
            this.idChambre = idChambre;
            this.dureeHospital = dureeHospital;
            this.medecinEnCharge = medecinEnCharge;
            this.dateConsOrHosp = dateConsOrHosp;

        }

        public String Id
        {
            get;
            set;
        }
        public String NoDossierPatient
        {
            get;
            set;
        }
        public string ConsultationPrServices
        {
            get;
            set;
        }
        public String ConsultationPayAss
        {
            get;
            set;
        }
        public String MotifConsultation
        {
            get;
            set;
        }
        public String NecessiteHospita
        {
            get;
            set;
        }
        public String HospitalisationSurAss
        {
            get;
            set;
        }
        public String IdChambre
        {
            get;
            set;
        }
        public int DureeHospital
        {
            get;
            set;
        }
        public String MedecinEnCharge
        {
            get;
            set;
        }
        public String DateConsOrHosp
        {
            get;
            set;

        }
    }
}
