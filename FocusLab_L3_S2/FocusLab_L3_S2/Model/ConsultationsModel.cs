using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FocusLab_L3_S2.src;
using FocusLab_L3_S2.utils;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Windows.Forms;

namespace FocusLab_L3_S2.Model
{
    class ConsultationsModel
    {
        public static int enregistrer(Consultations consultation)
        {
            int n = 0;
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            String sql = "INSERT INTO CONSULTATIONS(no_dossier_patient, consultations_pr_services, consultation_pay_ass,"+
                "motif_consultation, necessite_hospita, hospitalisation_sur_ass, id_chambre, duree_hospital, medecin_en_charge, " 
                + "date_cons_or_hosp) VALUES(@no_doss, @consulta_pr_srv, @consuta_pay, @motif, @necessite, @hospit_sur_ass" +
                ", @id_ch, @duree, @medecin, @date_cons )";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add(new MySqlParameter("@no_doss", consultation.NoDossierPatient));
                cmd.Parameters.Add(new MySqlParameter("@consulta_pr_srv", consultation.ConsultationPrServices));
                cmd.Parameters.Add(new MySqlParameter("@consuta_pay", consultation.ConsultationPayAss));
                cmd.Parameters.Add(new MySqlParameter("@motif", consultation.MotifConsultation));
                cmd.Parameters.Add(new MySqlParameter("@necessite", consultation.NecessiteHospita));
                cmd.Parameters.Add(new MySqlParameter("@hospit_sur_ass", consultation.HospitalisationSurAss));
               
                cmd.Parameters.AddWithValue("@id_ch", consultation.IdChambre);
                cmd.Parameters.AddWithValue("@duree", consultation.DureeHospital);
                cmd.Parameters.AddWithValue("@medecin", consultation.MedecinEnCharge);
                cmd.Parameters.AddWithValue("@date_cons", consultation.DateConsOrHosp);

                n = cmd.ExecuteNonQuery();
                conn.Close();
                return n;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }

            return n;
        }

        public static int update(Consultations consultation)
        {
            int n = 0;
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            String sql = "UPDATE CONSULTATIONS SET no_dossier_patient=@no_doss," +
                "consultations_pr_services=@consulta_pr_srv, consultation_pay_ass=@consuta_pay," +
                "motif_consultation=@motif, necessite_hospita=@necessite, hospitalisation_sur_ass=@hospit_sur_ass," +
                "id_chambre=@id_ch, duree_hospital=@duree, medecin_en_charge=@medecin, date_cons_or_hosp=@date_cons " +
                "WHERE id=@i";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@no_doss", consultation.NoDossierPatient);
                cmd.Parameters.AddWithValue("@consulta_pr_srv", consultation.ConsultationPrServices);
                cmd.Parameters.AddWithValue("@consuta_pay", consultation.ConsultationPayAss);
                cmd.Parameters.AddWithValue("@motif", consultation.MotifConsultation);
                cmd.Parameters.AddWithValue("@necessite", consultation.NecessiteHospita);
                cmd.Parameters.AddWithValue("@hospit_sur_ass", consultation.HospitalisationSurAss);
                cmd.Parameters.AddWithValue("@id_ch", consultation.IdChambre);
                cmd.Parameters.AddWithValue("@duree", consultation.DureeHospital);
                cmd.Parameters.AddWithValue("@medecin", consultation.MedecinEnCharge);
                cmd.Parameters.AddWithValue("@date_cons", consultation.DateConsOrHosp);
                cmd.Parameters.AddWithValue("@i", consultation.Id);

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

        public static int delete(String id)
        {
            int n = 0;
            MySqlConnection conn = Utils.GetDBConnection();
            string sql = "DELETE FROM CONSULTATIONS WHERE id=@i";
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

        public static List<Consultations> getAll()
        {
            List<Consultations> consultations = new List<Consultations>();
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            String sql = "SELECT * FROM CONSULTATIONS";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            DbDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Consultations consultation = new Consultations();
                    consultation.Id = reader["id"].ToString();
                    consultation.NoDossierPatient = reader["no_dossier_patient"].ToString();
                    consultation.ConsultationPrServices = reader["consultations_pr_services"].ToString();
                    consultation.ConsultationPayAss = reader["consultation_pay_ass"].ToString();
                    consultation.MotifConsultation = reader["motif_consultation"].ToString();
                    consultation.NecessiteHospita = reader["necessite_hospita"].ToString();
                    consultation.HospitalisationSurAss = reader["hospitalisation_sur_ass"].ToString();
                    consultation.IdChambre = reader["id_chambre"].ToString();
                    consultation.DureeHospital = int.Parse(reader["duree_hospital"].ToString());
                    consultation.MedecinEnCharge = reader["medecin_en_charge"].ToString();
                    consultation.DateConsOrHosp = reader["date_cons_or_hosp"].ToString();
                    consultations.Add(consultation);
                }
            }
            reader.Close();
            conn.Close();
            return consultations;
        }

        public static Consultations getById(String id)
        {
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            Consultations consultation = new Consultations();
            String sql = "SELECT * FROM CONSULTATIONS WHERE id=@i";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@i", id);
            DbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    consultation.Id = reader["id"].ToString();
                    consultation.NoDossierPatient = reader["no_dossier_patient"].ToString();
                    consultation.ConsultationPrServices = reader["consultations_pr_services"].ToString();
                    consultation.ConsultationPayAss = reader["consultation_pay_ass"].ToString();
                    consultation.MotifConsultation = reader["motif_consultation"].ToString();
                    consultation.NecessiteHospita = reader["necessite_hospita"].ToString();
                    consultation.HospitalisationSurAss = reader["hospitalisation_sur_ass"].ToString();
                    consultation.IdChambre = reader["id_chambre"].ToString();
                    consultation.DureeHospital = int.Parse(reader["duree_hospital"].ToString());
                    consultation.MedecinEnCharge = reader["medecin_en_charge"].ToString();
                    consultation.DateConsOrHosp = reader["date_cons_or_hosp"].ToString();
                }
            }
            reader.Close();
            conn.Close();
            return consultation;
        }
        public static int countHospitalisation()
        {
            int n = 0;
            foreach (Consultations consultation in getAll())
            {
                if (consultation.NecessiteHospita.Equals("Oui"))
                    n++;
            }
            return n;
        }
        public static List<String> getListIdHos()
        {
            List<String> list = new List<string>();
            foreach(Consultations consultation in getAll())
            {
                if (consultation.NecessiteHospita.Equals("Oui"))
                    list.Add(consultation.Id);
            }
            return list;
        }
    }
}
