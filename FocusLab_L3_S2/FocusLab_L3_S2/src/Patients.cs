using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusLab_L3_S2.src
{
    public class Patients
    {
        private String id;
        private String nom;
        private String prenom;
        private String sexe;
        private String dateNaissance;
        private int age;
        private String compagnieAssure;
        private String personneResponsable;
        private String telPersonResp;
        private String adresse;
        private String telephone;
        private String email;
        private String traitementSuiv;
        private String memo;

        public Patients() { }
        public Patients(String id, String nom, String prenom, String sexe, String dateNaissance, int age,
                        String compagnieAssure, String personneResponsable, String telPersonResp,
                        String adresse, String telephone, String email, String traitementSuiv, String memo)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.sexe = sexe;
            this.dateNaissance = dateNaissance;
            this.age = age;
            this.compagnieAssure = compagnieAssure;
            this.personneResponsable = personneResponsable;
            this.telPersonResp = telPersonResp;
            this.adresse = adresse;
            this.telephone = telephone;
            this.email = email;
            this.traitementSuiv = traitementSuiv;
            this.memo = memo;
        }

        public String Id
        {
            get;
            set;
        }
        public String Nom
        {
            get;
            set;
        }
        public String Prenom
        {
            get;
            set;
        }
        public String Sexe
        {
            get;
            set;
        }
        public String DateNaissance
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }
        public String CompagnieAssure
        {
            get;
            set;
        }
        public String PersonneResponsable
        {
            get;
            set;
        }
        public String TelPersonResp
        {
            get;
            set;
        }
        public String Adresse
        {
            get;
            set;
        }
        public String Telephone
        {
            get;
            set;
        }
        public String Email
        {
            get;
            set;
        }
        public String TraitementSuiv
        {
            get;
            set;
        }
        public String Memo
        {
            get;
            set;
        }
    }
}
