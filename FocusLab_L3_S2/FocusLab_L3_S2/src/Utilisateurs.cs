using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusLab_L3_S2.src
{
    public class Utilisateurs
    {
        private String id;
        private String idEmp;
        private String pseudo;
        private String passWord;
        private String etat;
        private String modules;
        
        public Utilisateurs() { }

        public Utilisateurs(String id, String idEmp, String pseudo, String passWord, String etat, String modules)
        {
            this.id = id;
            this.idEmp = idEmp;
            this.pseudo = pseudo;
            this.passWord = passWord;
            this.etat = etat;
            this.modules = modules;
        }


        public String Id
        {
            get;
            set;
        }
        public String IdEmp
        {
            get;
            set;
        }
        public String Pseudo
        {
            get;
            set;
        }
        public String PassWord
        {
            get;
            set;
        }
        public String Etat
        {
            get;
            set;
        }
        public string Modules
        {
            get;
            set;
        }
    }
}
