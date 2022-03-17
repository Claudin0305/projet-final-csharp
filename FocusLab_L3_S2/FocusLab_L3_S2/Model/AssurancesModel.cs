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
    public class AssurancesModel
    {
        public static int enregistrer(Assurances assurance)
        {
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            int n = 0;
            try
            {

                String sql = "INSERT INTO ASSURANCES(nom_compagnie, sigle, nom_directeur, adresse, telephone, email, percent_paiment_cons," +
                    "percent_paiment_ch, percent_paiment_hosp, etat) VALUES(@nom, @si, @nom_d, @ad, @tel, @em, @per_cons, @per_ch, " +
                    "@per_hosp, @et)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //MySqlParameter mp = new MySqlParameter();
                cmd.Parameters.AddWithValue("@nom", assurance.NomCompagnie);
                cmd.Parameters.AddWithValue("@si", assurance.Sigle);
                cmd.Parameters.AddWithValue("@nom_d", assurance.NomDirecteur);
                cmd.Parameters.AddWithValue("@ad", assurance.Adresse);
                cmd.Parameters.AddWithValue("@tel", assurance.Telephone);
                cmd.Parameters.AddWithValue("@em", assurance.Email);
                cmd.Parameters.AddWithValue("@per_cons", assurance.PercentPaimentCons);
                cmd.Parameters.AddWithValue("@per_ch", assurance.PercentPaimentCh);
                cmd.Parameters.AddWithValue("@per_hosp", assurance.PercentPaimentHosp);
                cmd.Parameters.AddWithValue("@et", assurance.Etat);

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

        public static int update(Assurances assurance)
        {
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            int n = 0;
            try
            {

                String sql = "UPDATE ASSURANCES SET nom_compagnie=@nom, sigle=@si, nom_directeur=@nom_d, adresse=@ad, telephone=@tel," +
                    "email=@em, percent_paiment_cons=@per_cons, percent_paiment_ch=@per_ch, percent_paiment_hosp=@per_hosp, etat=@et " +
                   "WHERE id=@i";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //MySqlParameter mp = new MySqlParameter();
                cmd.Parameters.AddWithValue("@nom", assurance.NomCompagnie);
                cmd.Parameters.AddWithValue("@si", assurance.Sigle);
                cmd.Parameters.AddWithValue("@nom_d", assurance.NomDirecteur);
                cmd.Parameters.AddWithValue("@ad", assurance.Adresse);
                cmd.Parameters.AddWithValue("@tel", assurance.Telephone);
                cmd.Parameters.AddWithValue("@em", assurance.Email);
                cmd.Parameters.AddWithValue("@per_cons", assurance.PercentPaimentCons);
                cmd.Parameters.AddWithValue("@per_ch", assurance.PercentPaimentCh);
                cmd.Parameters.AddWithValue("@per_hosp", assurance.PercentPaimentHosp);
                cmd.Parameters.AddWithValue("@et", assurance.Etat);
                cmd.Parameters.AddWithValue("@i", assurance.Id);

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
            string sql = "DELETE FROM ASSURANCES WHERE id=@i";
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

        public static List<Assurances> getAll()
        {
            List<Assurances> assurances = new List<Assurances>();
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            String sql = "SELECT * FROM ASSURANCES";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            DbDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Assurances assurance = new Assurances();
                    assurance.Id = reader["id"].ToString();
                    assurance.NomCompagnie = reader["nom_compagnie"].ToString();
                    assurance.Sigle = reader["sigle"].ToString();
                    assurance.NomDirecteur = reader["nom_directeur"].ToString();
                    assurance.Adresse = reader["adresse"].ToString();
                    assurance.Telephone = reader["telephone"].ToString();
                    assurance.Email = reader["email"].ToString();
                    assurance.PercentPaimentCons = Double.Parse(reader["percent_paiment_cons"].ToString());
                    assurance.PercentPaimentCh = Double.Parse(reader["percent_paiment_ch"].ToString());
                    assurance.PercentPaimentHosp = Double.Parse(reader["percent_paiment_hosp"].ToString());
                    assurance.Etat = reader["etat"].ToString();


                    assurances.Add(assurance);
                }
            }
            reader.Close();
            conn.Close();

            return assurances;
        }

        public static Assurances getById(String id)
        {
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            Assurances assurance = new Assurances();
            String sql = "SELECT * FROM ASSURANCES WHERE id=@i";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@i", id);
            DbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    assurance.Id = reader["id"].ToString();
                    assurance.NomCompagnie = reader["nom_compagnie"].ToString();
                    assurance.Sigle = reader["sigle"].ToString();
                    assurance.NomDirecteur = reader["nom_directeur"].ToString();
                    assurance.Adresse = reader["adresse"].ToString();
                    assurance.Telephone = reader["telephone"].ToString();
                    assurance.Email = reader["email"].ToString();
                    assurance.PercentPaimentCons = Double.Parse(reader["percent_paiment_cons"].ToString());
                    assurance.PercentPaimentCh = Double.Parse(reader["percent_paiment_ch"].ToString());
                    assurance.PercentPaimentHosp = Double.Parse(reader["percent_paiment_hosp"].ToString());
                    assurance.Etat = reader["etat"].ToString();
                }
            }
            reader.Close();
            conn.Close();
            return assurance;
        }

        public static List<String> getListCompagnie()
        {
            List<String> list = new List<string>();
            foreach(Assurances assurance in getAll())
            {
                if(assurance.Etat.Equals("En cours"))
                {
                    list.Add(assurance.NomCompagnie);
                }
            }
            return list;
        }

        public static bool isEncours(String s)
        {
            foreach(String s1 in getListCompagnie())
            {
                if (!s1.Equals(s))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
