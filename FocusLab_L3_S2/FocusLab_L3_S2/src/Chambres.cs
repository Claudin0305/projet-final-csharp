using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusLab_L3_S2.src
{
    public class Chambres
    {
        private String id;
        private String nom;
        private String type;
        private String couvrirParAssurance;
        private double prixLocation;
        private String etat;
        private String constituants;
        private String description;

        public Chambres() { }
        public Chambres(String id, String nom, String type,  String couvrirParAssurance, double prixLocation,
                        String etat, String constituants, String description){
            this.id = id;
            this.nom = nom;
            this.type = type;
            this.couvrirParAssurance = couvrirParAssurance;
            this.prixLocation = prixLocation;
            this.etat = etat;
            this.constituants = constituants;
            this.description = description;
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
        public String Type
        {
            get;
            set;
        }
        public String CouvrirParAssurance
        {
            get;
            set;
        }
        public double PrixLocation
        {
            get;
            set;
        }
        public String Etat
        {
            get;
            set;
        }
        public String Constituants
        {
            get;
            set;
        }
        public String Description
        {
            get;
            set;
        }

    }
}
