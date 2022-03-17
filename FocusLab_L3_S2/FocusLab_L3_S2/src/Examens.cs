using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusLab_L3_S2.src
{
    public class Examens
    {
        private String id;
        private String idPatient;
        private String dateExamen;
        private String nomExamen;
        private String resultat;
        private String technicienLab;
        private String signatureMedecin;
        private String remarque;

        public Examens() { }

        public Examens(String id, String idPatient, String dateExamen, String nomExamen, String resultat,  String technicienLab,
                        String signatureMedecin, String remarque)
        {
            this.id = id;
            this.idPatient = idPatient;
            this.dateExamen = dateExamen;
            this.nomExamen = nomExamen;
            this.resultat = resultat;
            this.technicienLab = technicienLab;
            this.signatureMedecin = signatureMedecin;
            this.remarque = remarque;
        }


        public String Id
        {
            get;
            set;
        }

        public String IdPatient
        {
            get;
            set;
        }

        public String DateExamen
        {
            get;
            set;
        }

        public String NomExamen
        {
            get;
            set;
        }

        public String Resultat
        {
            get;
            set;
        }

        public String TechnicienLab
        {
            get;
            set;
        }
        public String SignatureMedecin
        {
            get;
            set;
        }
        public String Remarque
        {
            get;
            set;
        }

    }
}
