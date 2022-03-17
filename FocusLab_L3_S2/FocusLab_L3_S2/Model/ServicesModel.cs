using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using FocusLab_L3_S2.src;
using FocusLab_L3_S2.utils;
using System.Windows.Forms;
using System.Data.Common;


namespace FocusLab_L3_S2.Model
{
    class ServicesModel
    {
        public static int enregistrer(Services service)
        {
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            int n = 0;
            try
            {

                String sql = "INSERT INTO SERVICES(nom, prix_consultation, nom_chef_service," +
                    "description, couvrir_par_assurance, etat)" +
                    "VALUES(@n, @p, @ncs, @d, @cpa, @e)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //MySqlParameter mp = new MySqlParameter();
                cmd.Parameters.Add(new MySqlParameter("@n", service.Nom));
                cmd.Parameters.Add(new MySqlParameter("@p", service.PrixConsultation));
                cmd.Parameters.Add(new MySqlParameter("@ncs", service.NomChefDeService));
                cmd.Parameters.Add(new MySqlParameter("@d", service.Description));
                cmd.Parameters.Add(new MySqlParameter("@cpa", service.CouvrirParAssurance));
                cmd.Parameters.Add(new MySqlParameter("@e", service.Etat));

                n = cmd.ExecuteNonQuery();
                conn.Close();
                return n;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return n;
        }

        public static int update(Services service)
        {
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            int n = 0;
            try
            {
                string sql = "UPDATE SERVICES SET nom=@n, prix_consultation=@p, nom_chef_service=@ncs," +
                    "description=@d, couvrir_par_assurance=@cpa, etat=@e WHERE id=@i";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add(new MySqlParameter("@n", service.Nom));
                cmd.Parameters.Add(new MySqlParameter("@p", service.PrixConsultation));
                cmd.Parameters.Add(new MySqlParameter("@ncs", service.NomChefDeService));
                cmd.Parameters.Add(new MySqlParameter("@d", service.Description));
                cmd.Parameters.Add(new MySqlParameter("@cpa", service.CouvrirParAssurance));
                cmd.Parameters.Add(new MySqlParameter("@e", service.Etat));
                cmd.Parameters.Add(new MySqlParameter("@i", service.Id));
               
                n = cmd.ExecuteNonQuery();
                conn.Close();
                return n;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return n;
        }

        public static int delete(string id)
        {
            int n = 0;
            MySqlConnection conn = Utils.GetDBConnection();
            string sql = "DELETE FROM SERVICES WHERE id=@i";
            conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add(new MySqlParameter("@i", id));
                n = cmd.ExecuteNonQuery();
                conn.Close();
                return n;


            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }

            return n;
        }

        public static List<Services> getAll()
        {
            List<Services> services = new List<Services>();
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            String sql = "SELECT * FROM SERVICES";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            DbDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Services service = new Services();
                    service.Id = reader["id"].ToString();
                    service.Nom = reader["nom"].ToString();
                    service.PrixConsultation = Double.Parse(reader["prix_consultation"].ToString());
                    service.NomChefDeService = reader["nom_chef_service"].ToString();
                    service.Description = reader["description"].ToString();
                    service.CouvrirParAssurance = reader["couvrir_par_assurance"].ToString();
                    service.Etat = reader["etat"].ToString();
                    services.Add(service);
                }
            }
            reader.Close();
            conn.Close();

            return services;
        }

        public static Services getById(String id)
        {
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            Services service = new Services();
            String sql = "SELECT * FROM SERVICES WHERE id=@i";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@i", id);
            DbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    service.Id = reader["id"].ToString();
                    service.Nom = reader["nom"].ToString();
                    service.PrixConsultation = Double.Parse(reader["prix_consultation"].ToString());
                    service.NomChefDeService = reader["nom_chef_service"].ToString();
                    service.Description = reader["description"].ToString();
                    service.CouvrirParAssurance = reader["couvrir_par_assurance"].ToString();
                    service.Etat = reader["etat"].ToString();
                }
            }
            reader.Close();
            conn.Close();
            return service;
        }

        public static List<String> getListServices()
        {
            List<String> str = new List<string>();
            foreach(Services service in getAll())
            {
                if(Utils.isEqualsString(service.Etat, "d"))
                {
                    str.Add(service.Nom);
                }
            }
            return str;
        } 
    }
}
