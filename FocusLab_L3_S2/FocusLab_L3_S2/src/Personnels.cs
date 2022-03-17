using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusLab_L3_S2.src
{
    public class Personnels
    {
        private String id;
        private String categorie;
        private String nom;
        private String prenom;
        private String sexe;
        private String adresse;
        private String domaineEtude;
        private String niveauEtude;
        private String specialisation;
        private int nbAnneExpe;
        private String telephone;
        private String dateNaissance;
        private String servicesAff;
        private String email;
        private String nifOrCin;
        private String etat;

        public Personnels() { }

        public Personnels(String id, String categorie, String nom, String prenom, String sexe, String adresse, String domaineEtude,
                            String niveauEtude, String specialisation, int nbAnneExpe, String telephone, String dateNaissance,
                            String servicesAff, String email, String nifOrCin, String etat){
            this.id = id;
            this.categorie = categorie;
            this.nom = nom;
            this.prenom = prenom;
            this.sexe = sexe;
            this.adresse = adresse;
            this.domaineEtude = domaineEtude;
            this.niveauEtude = niveauEtude;
            this.specialisation = specialisation;
            this.nbAnneExpe = nbAnneExpe;
            this.telephone = telephone;
            this.dateNaissance = dateNaissance;
            this.servicesAff = servicesAff;
            this.email = email;
            this.nifOrCin = nifOrCin;
            this.etat = etat;

        }

        public String Id
        {
            get;
            set;
        }
        public String Categorie
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
        public String Adresse
        {
            get;
            set;
        }
        public String DomaineEtude
        {
            get;
            set;
        }
        public String NiveauEtude
        {
            get;
            set;
        }
        public String Specialisation
        {
            get;
            set;
        }
        public int NbAnneExpe
        {
            get;
            set;
        }
        public String Telephone
        {
            get;
            set;
        }
        public String DateNaissance
        {
            get;
            set;
        }
        public String ServicesAff
        {
            get;
            set;
        }
        public String Email
        {
            get;
            set;
        }
        public String NifOrCin
        {
            get;
            set;
        }
        public String Etat
        {
            get;
            set;
        }
    }
}
