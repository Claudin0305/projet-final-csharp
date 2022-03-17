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
    public class PatientsModel
    {
        public static int enregistrer(Patients patient)
        {
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            int n = 0;
            try
            {

                String sql = "INSERT INTO PATIENTS(nom, prenom, sexe, date_naissance, age, compagnie_assure," +
                    "personne_responsable, tel_person_resp, adresse, telephone, email, traitement_suiv, memo) " +
                    "VALUES(@n, @p, @s, @dat, @ag, @comp, @pers_res, @tel_p, @adr, @tel, @em, @tr, @me)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //MySqlParameter mp = new MySqlParameter();
                cmd.Parameters.AddWithValue("@n", patient.Nom);
                cmd.Parameters.AddWithValue("@p", patient.Prenom);
                cmd.Parameters.AddWithValue("@s", patient.Sexe);
                cmd.Parameters.AddWithValue("@dat", patient.DateNaissance);
                cmd.Parameters.AddWithValue("@ag", patient.Age);
                cmd.Parameters.AddWithValue("@comp", patient.CompagnieAssure);
                cmd.Parameters.AddWithValue("@pers_res", patient.PersonneResponsable);
                cmd.Parameters.AddWithValue("@tel_p", patient.TelPersonResp);
                cmd.Parameters.AddWithValue("@adr", patient.Adresse);
                cmd.Parameters.AddWithValue("@tel", patient.Telephone);
                cmd.Parameters.AddWithValue("@em", patient.Email);
                cmd.Parameters.AddWithValue("@tr", patient.TraitementSuiv);
                cmd.Parameters.AddWithValue("@me", patient.Memo);

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

        public static int update(Patients patient)
        {
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            int n = 0;
            try
            {

                String sql = "UPDATE PATIENTS SET nom=@n, prenom=@p, sexe=@s, date_naissance=@dat, age=@ag," +
                    "compagnie_assure=@comp, personne_responsable=@pers_res, tel_person_resp=@tel_p, adresse=@adr," +
                    "telephone=@tel, email=@em, traitement_suiv=@tr, memo=@me WHERE id=@i";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //MySqlParameter mp = new MySqlParameter();
                cmd.Parameters.AddWithValue("@n", patient.Nom);
                cmd.Parameters.AddWithValue("@p", patient.Prenom);
                cmd.Parameters.AddWithValue("@s", patient.Sexe);
                cmd.Parameters.AddWithValue("@dat", patient.DateNaissance);
                cmd.Parameters.AddWithValue("@ag", patient.Age);
                cmd.Parameters.AddWithValue("@comp", patient.CompagnieAssure);
                cmd.Parameters.AddWithValue("@pers_res", patient.PersonneResponsable);
                cmd.Parameters.AddWithValue("@tel_p", patient.TelPersonResp);
                cmd.Parameters.AddWithValue("@adr", patient.Adresse);
                cmd.Parameters.AddWithValue("@tel", patient.Telephone);
                cmd.Parameters.AddWithValue("@em", patient.Email);
                cmd.Parameters.AddWithValue("@tr", patient.TraitementSuiv);
                cmd.Parameters.AddWithValue("@me", patient.Memo);
                cmd.Parameters.AddWithValue("@i", patient.Id);

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
            string sql = "DELETE FROM PATIENTS WHERE id=@i";
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

        public static List<Patients> getAll()
        {
            List<Patients> patients = new List<Patients>();
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            String sql = "SELECT * FROM PATIENTS";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            DbDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Patients patient = new Patients();
                    patient.Id = reader["id"].ToString();
                    patient.Nom = reader["nom"].ToString();
                    patient.Prenom = reader["prenom"].ToString();
                    patient.Sexe = reader["sexe"].ToString();
                    patient.DateNaissance = reader["date_naissance"].ToString();
                    patient.Age = int.Parse(reader["age"].ToString());
                    patient.CompagnieAssure = reader["compagnie_assure"].ToString();
                    patient.PersonneResponsable = reader["personne_responsable"].ToString();
                    patient.TelPersonResp = reader["tel_person_resp"].ToString();
                    patient.Adresse = reader["adresse"].ToString();
                    patient.Telephone = reader["telephone"].ToString();
                    patient.Email = reader["email"].ToString();
                    patient.TraitementSuiv = reader["traitement_suiv"].ToString();
                    patient.Memo = reader["memo"].ToString();


                    patients.Add(patient);
                }
            }
            reader.Close();
            conn.Close();

            return patients;
        }

        public static Patients getById(String id)
        {
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            Patients patient = new Patients();
            String sql = "SELECT * FROM PATIENTS WHERE id=@i";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@i", id);
            DbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {

                    patient.Id = reader["id"].ToString();
                    patient.Nom = reader["nom"].ToString();
                    patient.Prenom = reader["prenom"].ToString();
                    patient.Sexe = reader["sexe"].ToString();
                    patient.DateNaissance = reader["date_naissance"].ToString();
                    patient.Age = int.Parse(reader["age"].ToString());
                    patient.CompagnieAssure = reader["compagnie_assure"].ToString();
                    patient.PersonneResponsable = reader["personne_responsable"].ToString();
                    patient.TelPersonResp = reader["tel_person_resp"].ToString();
                    patient.Adresse = reader["adresse"].ToString();
                    patient.Telephone = reader["telephone"].ToString();
                    patient.Email = reader["email"].ToString();
                    patient.TraitementSuiv = reader["traitement_suiv"].ToString();
                    patient.Memo = reader["memo"].ToString();
                }
            }
            reader.Close();
            conn.Close();
            return patient;
        }

        public static List<String> getListIdPatient()
        {
            List<String> list = new List<string>();
            foreach(Patients patient in getAll())
            {
                list.Add(patient.Id);
            }
            return list;
        }

        public static List<String> getListCompById(String id)
        {
            List<String> list = new List<string>();
            if (!String.IsNullOrEmpty(getById(id).CompagnieAssure))
            {
                foreach (String s in getById(id).CompagnieAssure.Split(','))
                {

                    if (AssurancesModel.isEncours(s))
                    {
                        list.Add(s);
                    }
                }
            }
           
            
            return list;

        }
        public static int countHomme()
        {
            int n = 0;
            foreach(Patients p in getAll())
            {
                if (p.Sexe.Equals("Masculin"))
                    n++;
            }
            return n;
        }
    }
}
