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
    public class ChambresModel
    {
        public static int enregistrer(Chambres chambre)
        {
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            int n = 0;
            try
            {

                String sql = "INSERT INTO CHAMBRES(nom, type_chambre, couvrir_par_assurance, prix_location, etat, constituants, description)" +
                    "VALUES(@n, @type, @couvrir, @prix,  @et, @const, @desc)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //MySqlParameter mp = new MySqlParameter();
                cmd.Parameters.AddWithValue("@n", chambre.Nom);
                cmd.Parameters.AddWithValue("@type", chambre.Type);
                cmd.Parameters.AddWithValue("@couvrir", chambre.CouvrirParAssurance);
                cmd.Parameters.AddWithValue("@et", chambre.Etat);
                cmd.Parameters.AddWithValue("@prix", chambre.PrixLocation);
                cmd.Parameters.AddWithValue("@const", chambre.Constituants);
                cmd.Parameters.AddWithValue("@desc", chambre.Description);

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

        public static int update(Chambres chambre)
        {
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            int n = 0;
            try
            {

                String sql = "UPDATE CHAMBRES SET nom=@n, type_chambre=@type, couvrir_par_assurance=@couvrir, prix_location=@prix," +
                    "etat=@et, constituants=@const, description=@desc WHERE id=@i";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //MySqlParameter mp = new MySqlParameter();
                cmd.Parameters.AddWithValue("@n", chambre.Nom);
                cmd.Parameters.AddWithValue("@type", chambre.Type);
                cmd.Parameters.AddWithValue("@couvrir", chambre.CouvrirParAssurance);
                cmd.Parameters.AddWithValue("@et", chambre.Etat);
                cmd.Parameters.AddWithValue("@prix", chambre.PrixLocation);
                cmd.Parameters.AddWithValue("@const", chambre.Constituants);
                cmd.Parameters.AddWithValue("@desc", chambre.Description);
                cmd.Parameters.AddWithValue("@i", chambre.Id);

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
            string sql = "DELETE FROM CHAMBRES WHERE id=@i";
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

        public static List<Chambres> getAll()
        {
            List<Chambres> chambres = new List<Chambres>();
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            String sql = "SELECT * FROM CHAMBRES";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            DbDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Chambres chambre = new Chambres();
                    chambre.Id = reader["id"].ToString();
                    chambre.Nom = reader["nom"].ToString();
                    chambre.Type = reader["type_chambre"].ToString();
                    chambre.CouvrirParAssurance = reader["couvrir_par_assurance"].ToString();
                    chambre.PrixLocation = Double.Parse(reader["prix_location"].ToString());
                    chambre.Etat = reader["etat"].ToString();
                    chambre.Constituants = reader["constituants"].ToString();
                    chambre.Description = reader["description"].ToString();
                    
                    chambres.Add(chambre);
                }
            }
            reader.Close();
            conn.Close();

            return chambres;
        }
        
        public static Chambres getById(String id)
        {
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            Chambres chambre = new Chambres();
            String sql = "SELECT * FROM CHAMBRES WHERE id=@i";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@i", id);
            DbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    chambre.Id = reader["id"].ToString();
                    chambre.Nom = reader["nom"].ToString();
                    chambre.Type = reader["type_chambre"].ToString();
                    chambre.CouvrirParAssurance = reader["couvrir_par_assurance"].ToString();
                    chambre.PrixLocation = Double.Parse(reader["prix_location"].ToString());
                    chambre.Etat = reader["etat"].ToString();
                    chambre.Constituants = reader["constituants"].ToString();
                    chambre.Description = reader["description"].ToString();
                }
            }
            reader.Close();
            conn.Close();
            return chambre;
        }

        public static List<String> getListIdChDisponible()
        {
            List<String> list = new List<String>();
            foreach(Chambres chambre in getAll())
            {
                if (chambre.Etat.Equals("Disponible"))
                {
                    list.Add(chambre.Id);
                }
            }
            return list;
        }
    }
}
