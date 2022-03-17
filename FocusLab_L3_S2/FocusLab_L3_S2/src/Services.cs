using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusLab_L3_S2.src
{
    public class Services
    {
        private string id;
        private string nom;
        private string couvrirParAssurance;
        private double prixConsultation;
        private string nomChefDeService;
        private string description;
        private string etat;

        public Services()
        {

        }
    
        public Services(string id, string nom, string couvrirParAssurance, double prixConsultation,
            string nomChefDeService, string description, string etat)
        {
            this.id = id;
            this.nom = nom;
            this.couvrirParAssurance = couvrirParAssurance;
            this.prixConsultation = prixConsultation;
            this.nomChefDeService = nomChefDeService;
            this.description = description;
            this.etat = etat;
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

        public String CouvrirParAssurance
        {
            get;
            set;
        }

        public Double PrixConsultation
        {
            get;
            set;
        }

        public String NomChefDeService
        {
            get;
            set;
        }


        public String Description
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
