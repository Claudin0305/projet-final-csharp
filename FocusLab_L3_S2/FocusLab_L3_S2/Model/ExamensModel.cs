using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FocusLab_L3_S2.src;
using FocusLab_L3_S2.utils;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data.Common;

namespace FocusLab_L3_S2.Model
{
    class ExamensModel
    {
        public static int enregistrer(Examens examen)
        {
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            int n = 0;
            try
            {

                String sql = "INSERT INTO EXAMENS(id_patient, date_examen, nom_examen, resultat," +
                    "technicien_lab, signature_medecin, remarque)" +
                    "VALUES(@id_p, @date_ex, @nom_ex, @result, @tech, @signature, @rem)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //MySqlParameter mp = new MySqlParameter();
                cmd.Parameters.AddWithValue("@id_p", examen.IdPatient);
                cmd.Parameters.AddWithValue("@date_ex", examen.DateExamen);
                cmd.Parameters.AddWithValue("@nom_ex", examen.NomExamen);
                cmd.Parameters.AddWithValue("@result", examen.Resultat);
                cmd.Parameters.AddWithValue("@tech", examen.TechnicienLab);
                cmd.Parameters.AddWithValue("@signature", examen.SignatureMedecin);
                cmd.Parameters.AddWithValue("@rem", examen.Remarque);

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

        public static int update(Examens examen)
        {
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            int n = 0;
            try
            {

                String sql = "UPDATE EXAMENS SET id_patient=@id_p, date_examen=@date_ex, nom_examen=@nom_ex," +
                    "resultat=@result, technicien_lab=@tech, signature_medecin=@signature, remarque=@rem" +
                    " WHERE id=@i";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //MySqlParameter mp = new MySqlParameter();
                cmd.Parameters.AddWithValue("@id_p", examen.IdPatient);
                cmd.Parameters.AddWithValue("@date_ex", examen.DateExamen);
                cmd.Parameters.AddWithValue("@nom_ex", examen.NomExamen);
                cmd.Parameters.AddWithValue("@result", examen.Resultat);
                cmd.Parameters.AddWithValue("@tech", examen.TechnicienLab);
                cmd.Parameters.AddWithValue("@signature", examen.SignatureMedecin);
                cmd.Parameters.AddWithValue("@rem", examen.Remarque);
                cmd.Parameters.AddWithValue("@i", examen.Id);

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
            string sql = "DELETE FROM EXAMENS WHERE id=@i";
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

        public static List<Examens> getAll()
        {
            List<Examens> examens = new List<Examens>();
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            String sql = "SELECT * FROM EXAMENS";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            DbDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Examens examen = new Examens();
                    examen.Id = reader["id"].ToString();
                    examen.IdPatient = reader["id_patient"].ToString();
                    examen.DateExamen = reader["date_examen"].ToString();
                    examen.NomExamen = reader["nom_examen"].ToString();
                    examen.Resultat = reader["resultat"].ToString();
                    examen.TechnicienLab = reader["technicien_lab"].ToString();
                    examen.SignatureMedecin = reader["signature_medecin"].ToString();
                    examen.Remarque = reader["remarque"].ToString();
                    examens.Add(examen);
                }
            }
            reader.Close();
            conn.Close();

            return examens;
        }

        public static Examens getById(String id)
        {
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            Examens examen = new Examens();
            String sql = "SELECT * FROM EXAMENS WHERE id=@i";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@i", id);
            DbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    examen.Id = reader["id"].ToString();
                    examen.IdPatient = reader["id_patient"].ToString();
                    examen.DateExamen = reader["date_examen"].ToString();
                    examen.NomExamen = reader["nom_examen"].ToString();
                    examen.Resultat = reader["resultat"].ToString();
                    examen.TechnicienLab = reader["technicien_lab"].ToString();
                    examen.SignatureMedecin = reader["signature_medecin"].ToString();
                    examen.Remarque = reader["remarque"].ToString();
                }
            }
            reader.Close();
            conn.Close();
            return examen;
        }
    }
}
