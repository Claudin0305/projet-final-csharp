using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.Common;
using FocusLab_L3_S2.src;
using FocusLab_L3_S2.utils;
using System.Windows.Forms;

namespace FocusLab_L3_S2.Model
{
    public class PersonnelsModel
    {
        public static int enregistrer(Personnels personnel)
        {
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            int n = 0;
            try
            {

                String sql = "INSERT INTO PERSONNELS(categorie, nom, prenom, sexe, adresse, domaine_etude, niveau_etude," +
                    "specialisation, nb_annee_exp, telephone, date_naissance, services_affectes, email, nif_or_cin, etat)" +
                    " VALUES(@cat, @n, @p, @s, @ad, @do, @niv, @spe, @nb, @tel, @dat, @serv, @em, @nif, @et)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //MySqlParameter mp = new MySqlParameter();
                cmd.Parameters.AddWithValue("@cat", personnel.Categorie);
                cmd.Parameters.AddWithValue("@n", personnel.Nom);
                cmd.Parameters.AddWithValue("@p", personnel.Prenom);
                cmd.Parameters.AddWithValue("@s", personnel.Sexe);
                cmd.Parameters.AddWithValue("@ad", personnel.Adresse);
                cmd.Parameters.AddWithValue("@do", personnel.DomaineEtude);
                cmd.Parameters.AddWithValue("@niv", personnel.NiveauEtude);
                cmd.Parameters.AddWithValue("@spe", personnel.Specialisation);
                cmd.Parameters.AddWithValue("@nb", personnel.NbAnneExpe);
                cmd.Parameters.AddWithValue("@tel", personnel.Telephone);
                cmd.Parameters.AddWithValue("@dat", personnel.DateNaissance);
                cmd.Parameters.AddWithValue("@serv", personnel.ServicesAff);
                cmd.Parameters.AddWithValue("@em", personnel.Email);
                cmd.Parameters.AddWithValue("@nif", personnel.NifOrCin);
                cmd.Parameters.AddWithValue("@et", personnel.Etat);

                n = cmd.ExecuteNonQuery();
                conn.Close();
                return n;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return n;
        }

        public static int update(Personnels personnel)
        {
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            int n = 0;
            try
            {

                String sql = "UPDATE PERSONNELS SET categorie=@cat, nom=@n, prenom=@p, sexe=@s, adresse=@ad," +
                    "domaine_etude=@do, niveau_etude= @niv, specialisation=@spe, nb_annee_exp=@nb, telephone=@tel, date_naissance= @dat," +
                    "services_affectes=@serv, email=@em, nif_or_cin=@nif, etat=@et WHERE id=@i";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //MySqlParameter mp = new MySqlParameter();
                cmd.Parameters.AddWithValue("@cat", personnel.Categorie);
                cmd.Parameters.AddWithValue("@n", personnel.Nom);
                cmd.Parameters.AddWithValue("@p", personnel.Prenom);
                cmd.Parameters.AddWithValue("@s", personnel.Sexe);
                cmd.Parameters.AddWithValue("@ad", personnel.Adresse);
                cmd.Parameters.AddWithValue("@do", personnel.DomaineEtude);
                cmd.Parameters.AddWithValue("@niv", personnel.NiveauEtude);
                cmd.Parameters.AddWithValue("@spe", personnel.Specialisation);
                cmd.Parameters.AddWithValue("@nb", personnel.NbAnneExpe);
                cmd.Parameters.AddWithValue("@tel", personnel.Telephone);
                cmd.Parameters.AddWithValue("@dat", personnel.DateNaissance);
                cmd.Parameters.AddWithValue("@serv", personnel.ServicesAff);
                cmd.Parameters.AddWithValue("@em", personnel.Email);
                cmd.Parameters.AddWithValue("@nif", personnel.NifOrCin);
                cmd.Parameters.AddWithValue("@et", personnel.Etat);
                cmd.Parameters.AddWithValue("@i", personnel.Id);

                n = cmd.ExecuteNonQuery();
                conn.Close();
                return n;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return n;
        }

        public static int delete(string id)
        {
            int n = 0;
            MySqlConnection conn = Utils.GetDBConnection();
            string sql = "DELETE FROM PERSONNELS WHERE id=@i";
            conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add(new MySqlParameter("@i", id));
                n = cmd.ExecuteNonQuery();
                conn.Close();
                return n;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }

            return n;
        }

        public static List<Personnels> getAll()
        {
            List<Personnels> personnels = new List<Personnels>();
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            String sql = "SELECT * FROM PERSONNELS";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            DbDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Personnels personnel = new Personnels();
                    personnel.Id = reader["id"].ToString();
                    personnel.Categorie = reader["categorie"].ToString();
                    personnel.Nom = reader["nom"].ToString();
                    personnel.Prenom = reader["prenom"].ToString();
                    personnel.Sexe = reader["sexe"].ToString();
                    personnel.Adresse = reader["adresse"].ToString();
                    personnel.DomaineEtude = reader["domaine_etude"].ToString();
                    personnel.NiveauEtude = reader["niveau_etude"].ToString();
                    personnel.Specialisation = reader["specialisation"].ToString();
                    personnel.NbAnneExpe = int.Parse(reader["nb_annee_exp"].ToString());
                    personnel.Telephone = reader["telephone"].ToString();
                    personnel.DateNaissance = reader["date_naissance"].ToString();
                    personnel.ServicesAff = reader["services_affectes"].ToString();
                    personnel.Email = reader["email"].ToString();
                    personnel.NifOrCin = reader["nif_or_cin"].ToString();
                    personnel.Etat = reader["etat"].ToString();


                    personnels.Add(personnel);
                }
            }
            reader.Close();
            conn.Close();

            return personnels;
        }

        public static Personnels getById(String id)
        {
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            Personnels personnel = new Personnels();
            String sql = "SELECT * FROM PERSONNELS WHERE id=@i";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@i", id);
            DbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    personnel.Id = reader["id"].ToString();
                    personnel.Categorie = reader["categorie"].ToString();
                    personnel.Nom = reader["nom"].ToString();
                    personnel.Prenom = reader["prenom"].ToString();
                    personnel.Sexe = reader["sexe"].ToString();
                    personnel.Adresse = reader["adresse"].ToString();
                    personnel.DomaineEtude = reader["domaine_etude"].ToString();
                    personnel.NiveauEtude = reader["niveau_etude"].ToString();
                    personnel.Specialisation = reader["specialisation"].ToString();
                    personnel.NbAnneExpe = int.Parse(reader["nb_annee_exp"].ToString());
                    personnel.Telephone = reader["telephone"].ToString();
                    personnel.DateNaissance = reader["date_naissance"].ToString();
                    personnel.ServicesAff = reader["services_affectes"].ToString();
                    personnel.Email = reader["email"].ToString();
                    personnel.NifOrCin = reader["nif_or_cin"].ToString();
                    personnel.Etat = reader["etat"].ToString();
                }
            }
            reader.Close();
            conn.Close();
            return personnel;
        }

        public static List<String> getListIdPersonnels()
        {
            List<String> list = new List<string>();
            foreach(Personnels personnel in getAll())
            {
                if (personnel.Etat.Equals("Actif"))
                {
                    
                    list.Add(personnel.Id);
                    
                }
            }
            return list;
        }

        public static List<String> getMedecins()
        {
            List<String> list = new List<string>();
            foreach(Personnels personnel in getAll())
            {
                if(personnel.Categorie.Equals("Médecin") && personnel.Etat.Equals("Actif"))
                {
                    list.Add(personnel.Nom + " " + personnel.Prenom);
                }
            }
            return list;
        }
    }
}
