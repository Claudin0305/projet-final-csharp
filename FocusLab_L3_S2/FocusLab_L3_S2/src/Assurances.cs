using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusLab_L3_S2.src
{
    public class Assurances
    {
        private String id;
        private string nomCompagnie;
        private String sigle;
        private String nomDirecteur;
        private String adresse;
        private string telephone;
        private String email;
        private double percentPaimentCons;
        private double percentPaimentCh;
        private double percentPaimentHosp;
        private String etat;

        public Assurances() { }
        public Assurances(String id, string nomCompagnie, String sigle, String nomDirecteur, String adresse, string telephone,
                            String email, double percentPaimentCons, double percentPaimentCh, double percentPaimentHosp, String etat){
            this.id = id;
            this.nomCompagnie = nomCompagnie;
            this.nomDirecteur = nomDirecteur;
            this.adresse = adresse;
            this.telephone = telephone;
            this.email = email;
            this.percentPaimentCons = percentPaimentCons;
            this.percentPaimentCh = percentPaimentCh;
            this.percentPaimentHosp = percentPaimentHosp;
            this.etat = etat;
        }

        public String Id
        {
            get;
            set;
        }
        public string NomCompagnie
        {
            get;
            set;
        }
        public String Sigle
        {
            get;
            set;
        }
        public String NomDirecteur
        {
            get;
            set;
        }
        public String Adresse
        {
            get;
            set;
        }
        public string Telephone
        {
            get;
            set;
        }
        public String Email
        {
            get;
            set;
        }
        public double PercentPaimentCons
        {
            get;
            set;
        }
        public double PercentPaimentCh
        {
            get;
            set;
        }
        public double PercentPaimentHosp
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
