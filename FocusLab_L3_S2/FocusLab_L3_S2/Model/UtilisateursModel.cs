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
    class UtilisateursModel
    {
        public static int enregistrer(Utilisateurs utilisateur)
        {
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            int n = 0;
            try
            {

                String sql = "INSERT INTO UTILISATEURS(id_Emp, pseudo, pass_word, etat, modules)" +
                    "VALUES(@idEm, @pseud, @pass, @et, @mod)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //MySqlParameter mp = new MySqlParameter();
                cmd.Parameters.AddWithValue("@pseud", utilisateur.Pseudo);
                cmd.Parameters.AddWithValue("@pass", utilisateur.PassWord);
                cmd.Parameters.AddWithValue("@et", utilisateur.Etat);
                cmd.Parameters.AddWithValue("@mod", utilisateur.Modules);
                cmd.Parameters.AddWithValue("@idEm", utilisateur.IdEmp);

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

        public static int update( Utilisateurs utilisateur)
        {
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            int n = 0;
            try
            {

                String sql = "UPDATE UTILISATEURS SET id_emp=@idEm, pseudo=@pseud, pass_word=@pass, etat=@et, modules=@mod " +
                    "WHERE id=@i";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //MySqlParameter mp = new MySqlParameter();
                cmd.Parameters.AddWithValue("@idEm", utilisateur.IdEmp);
                cmd.Parameters.AddWithValue("@pseud", utilisateur.Pseudo);
                cmd.Parameters.AddWithValue("@pass", utilisateur.PassWord);
                cmd.Parameters.AddWithValue("@et", utilisateur.Etat);
                cmd.Parameters.AddWithValue("@mod", utilisateur.Modules);
                cmd.Parameters.AddWithValue("@i", utilisateur.Id);

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
            string sql = "DELETE FROM UTILISATEURS WHERE id=@i";
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

        public static List<Utilisateurs> getAll()
        {
            List<Utilisateurs> utilisateurs = new List<Utilisateurs>();
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            String sql = "SELECT * FROM UTILISATEURS";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            DbDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Utilisateurs utilisateur = new Utilisateurs();
                    utilisateur.Id = reader["id"].ToString();
                    utilisateur.Pseudo = reader["pseudo"].ToString();
                    utilisateur.PassWord = reader["pass_word"].ToString();
                    utilisateur.Etat = reader["etat"].ToString();
                    utilisateur.Modules = reader["modules"].ToString();
                    utilisateur.IdEmp = reader["id_emp"].ToString();
                    utilisateurs.Add(utilisateur);
                }
            }
            reader.Close();
            conn.Close();

            return utilisateurs;
        }
        public static string getPassWordById(string id)
        {   
            return getById(id).PassWord;
        }
        public static Utilisateurs getById(String id)
        {
            MySqlConnection conn = Utils.GetDBConnection();
            conn.Open();
            Utilisateurs utilisateur = new Utilisateurs();
            String sql = "SELECT * FROM UTILISATEURS WHERE id=@i";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@i", id);
            DbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    utilisateur.Id = reader["id"].ToString();
                    utilisateur.Pseudo = reader["pseudo"].ToString();
                    utilisateur.PassWord = reader["pass_word"].ToString();
                    utilisateur.Etat = reader["etat"].ToString();
                    utilisateur.Modules = reader["modules"].ToString();
                    utilisateur.IdEmp = reader["id_emp"].ToString();
                }
            }
            reader.Close();
            conn.Close();
            return utilisateur;
        }
        public static bool empHaveAccount(string idEmp)
        {
            foreach(Utilisateurs utilisateur in getAll())
            {
                if (utilisateur.IdEmp.Equals(idEmp))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool userActif(String id)
        {
            if (getById(id).Etat.Equals("Inactif"))
            {
                return false;
            }
            return true;
        }
        public static int countUserActif()
        {
            int n = 0;
            foreach(Utilisateurs utilisateur in getAll())
            {
                if (utilisateur.Etat.Equals("Actif"))
                    n++;
            }
            return n;
        }
        public static Utilisateurs getByPseudoAndPass(String pseudo, String password)
        {
            foreach(Utilisateurs utilisateur in getAll())
            {
                if (utilisateur.PassWord.Equals(password) && utilisateur.Pseudo.Equals(pseudo))
                    return utilisateur;
            }
            return null;
        }
    }
}
