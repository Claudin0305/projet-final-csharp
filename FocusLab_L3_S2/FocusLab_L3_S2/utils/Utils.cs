using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using FocusLab_L3_S2.Model;
using FocusLab_L3_S2.src;
using System.Net.Mail;

namespace FocusLab_L3_S2.utils
{
    class Utils
    {
        public static void loadform(Panel panel, object Form)
        {
            if (panel.Controls.Count > 0)
            {
                panel.Controls.RemoveAt(0);
            }
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            panel.Controls.Add(f);
            panel.Tag = f;
            f.Show();

        }

        public static MySqlConnection GetDBConnection()
        {
            MySqlConnection conn = null;
            conn = new MySqlConnection("server=127.0.0.1;uid=root;" + "pwd=;database=hopital_espoir; SSL Mode=None");

            return conn;
        }

        public static bool isEqualsString(string str1, string str2)
        {
            if (str1.ToUpper().Equals(str2.ToUpper()))
            {
                return true;
            }

            return false;
        }

        /**
         * Pour verifier que l'utilisateur a choisi un des option des boutons radio
         */
        public static bool radioButtonChooser(bool btn1, bool btn2, string name)
        {
            if(!(btn1 || btn2))
            {
                MessageBox.Show("Vous devez choisir un des options!", name);
                return false;
            }
            return true;
        }

        public static bool stringOnly(String str, string name)
        {
            if (!Regex.IsMatch(str, @"^[\p{L}\W]+( )?$"))
            {
                MessageBox.Show("Ce champs doit contenir que des lettres", name);
                return false;
            }
            return true;
        }

        public static bool stringAndNumber(String str, string name)
        {
            if (!Regex.IsMatch(str, @"^[\p{L}\W]+( -)?([0-9]+)?$"))
            {
                MessageBox.Show("Ce champs doit contenir que des lettres et des chiffres", name);
                return false;
            }
            return true;
        }

        public static bool numberOnly(string str, string name)
        {
            if(str == null ||!Regex.IsMatch(str, @"^[0-9]+(\.[0-9]{1,2})?$"))
            {

                MessageBox.Show("Ce champs doit contenir que des chiffres", name);
                return false;
            }
            return true;
        }

        public static bool serviceExiste(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                foreach (Services service in ServicesModel.getAll())
                {
                    if (isEqualsString(service.Nom, name))
                    {
                        MessageBox.Show("Ce service existe deja!", name);
                        return false;
                    }

                }
            }
            else
            {
                MessageBox.Show("Ce champ ne peut etre null", "Nom service");
                return false;
            }
            
            return true;
        }

        public static bool serviceExisteForUpdate(string id, string name)
        {
            if (id != null)
            {
                if (!String.IsNullOrEmpty(name))
                {
                    foreach (Services service in ServicesModel.getAll())
                    {
                        if ((!isEqualsString(id, service.Id) && isEqualsString(name, service.Nom)))
                        {
                            MessageBox.Show("Ce service existe deja!", name);
                            return false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ce champ ne peut etre null", "Nom service");
                    return false;

                }


            }
           
            return true;
        }


        //For existe chambre

        public static bool chambreeExiste(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                foreach (Chambres chambre in ChambresModel.getAll())
                {
                    if (isEqualsString(chambre.Nom, name))
                    {
                        MessageBox.Show("Cette chambre existe deja!", name);
                        return false;
                    }

                }
            }
            else
            {
                MessageBox.Show("Ce champ ne peut etre null", "Nom chambre");
                return false;
            }

            return true;
        }

        public static bool chambreExisteForUpdate(string id, string name)
        {
            if (id != null)
            {
                if (!String.IsNullOrEmpty(name))
                {
                    foreach (Chambres chambre in ChambresModel.getAll())
                    {
                        if ((!isEqualsString(id, chambre.Id) && isEqualsString(name, chambre.Nom)))
                        {
                            MessageBox.Show("Cette chambre existe deja!", name);
                            return false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ce champ ne peut etre null", "Nom chambre");
                    return false;

                }


            }

            return true;
        }

        public static void btnInDataGrid(DataGridView dataGridView, String type)
        {
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.HeaderText = "Edit.";
            btnEdit.Name = "btnEdit";
            btnEdit.Text = "Editer";
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.CellTemplate.Style.BackColor = Color.FromArgb(142, 193, 250);
            btnEdit.CellTemplate.Style.ForeColor = Color.White;
            btnEdit.UseColumnTextForButtonValue = true;
            

            DataGridViewButtonColumn btnSup = new DataGridViewButtonColumn();
            btnSup.HeaderText = "Sup.";
            btnSup.Name = "btnSup";
            btnSup.Text = "Supr.";
            btnSup.CellTemplate.Style.BackColor = Color.FromArgb(253, 104, 106);
            btnSup.CellTemplate.Style.ForeColor = Color.White;
            btnSup.FlatStyle = FlatStyle.Flat;
            btnSup.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn btnPrint = new DataGridViewButtonColumn();
            btnPrint.HeaderText = "Print";
            btnPrint.Name = "btnPrint";
            btnPrint.Text = "Print";
            btnPrint.CellTemplate.Style.BackColor = Color.FromArgb(150, 193, 250);
            btnPrint.CellTemplate.Style.ForeColor = Color.White;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.UseColumnTextForButtonValue = true;
            if (isEqualsString(type, "edit"))
            {
                dataGridView.Columns.Add(btnEdit);
            }else if(isEqualsString(type, "print"))
            {
                dataGridView.Columns.Add(btnPrint);

            }
            else
            {
                dataGridView.Columns.Add(btnSup);

            }
        }

        public static string chekedListToString(CheckedListBox checkedListBox)
        {
            String str = null;
            foreach (String s in checkedListBox.CheckedItems)
            {
                str += s + ",";

            }
            if(str != null)
            {
                return str.Trim(',');
            }
            return null;
        }

        public static void selectedChekedlistBox(CheckedListBox checkedList, String str)
        {
            str = str.Trim(',');
            String[] strTable = str.Split(',');
            if (strTable.Length == 1)
            {
                if (checkedList.FindStringExact(strTable[0]) != -1)
                    checkedList.SetItemChecked(checkedList.FindStringExact(strTable[0]), true);
            }else if(strTable.Length > 1)
            {
                foreach (string s in strTable)
                {
                    if (checkedList.FindStringExact(s) != -1)
                        checkedList.SetItemChecked(checkedList.FindStringExact(s), true);
                }
            }
        }
        //For the password user
        public static String createSalt(int size)
        {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public static String generateSha256Has(String input, String salt)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input + salt);
            System.Security.Cryptography.SHA256Managed sha256string =
                new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sha256string.ComputeHash(bytes);

            return null; //ByteArrayToHexString(hash);
        }

        public static bool isSelectedOnList(CheckedListBox checkedListBox, String name)
        {
            if (String.IsNullOrEmpty(chekedListToString(checkedListBox)))
            {
                MessageBox.Show("Vous devez choisir au moins une des options", name);
                return false;
            }
            
            return true;
        }



        public static void reesetselectedChekedlistBox(CheckedListBox checkedList, String str)
        {
           
            if (str != null)
            {
                String[] strTable = str.Split(',');
                foreach (string s in strTable)
                {
                    if (checkedList.FindStringExact(s) != -1)
                        checkedList.SetItemChecked(checkedList.FindStringExact(s), false);
                }
            }
        }

        public static bool comboSelected(ComboBox combo, String name)
        {
            if(combo.SelectedIndex == -1)
            {
                MessageBox.Show("Vous devez choisir une des options", name);
                return false;
            }
            return true;
        }


        public static bool pseudoExiste(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                foreach (Utilisateurs utilisateur in UtilisateursModel.getAll())
                {
                    if (isEqualsString(utilisateur.Pseudo, name))
                    {
                        MessageBox.Show("Ce pseudo existe deja!", name);
                        return false;
                    }

                }
            }
            else
            {
                MessageBox.Show("Ce champ ne peut etre null", "Nom utilisateur");
                return false;
            }

            return true;
        }

        public static bool pseudoExisteForUpdate(string id, string name)
        {
            if (id != null)
            {
                if (!String.IsNullOrEmpty(name))
                {
                    foreach (Utilisateurs utilisateur in UtilisateursModel.getAll())
                    {
                        if ((!isEqualsString(id, utilisateur.Id) && isEqualsString(name, utilisateur.Pseudo)))
                        {
                            MessageBox.Show("Ce Pseudo existe deja!", name);
                            return false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ce champ ne peut etre null", "Nom service");
                    return false;

                }


            }

            return true;
        }

        public static void loadStringInChecked(CheckedListBox checkedList, List<string> list)
        {
            foreach (String str in list)
            {
                checkedList.Items.Add(str);
            }
        }

        //For existe Sigle

        public static bool sigleExiste(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                foreach (Assurances assurance in AssurancesModel.getAll())
                {
                    if (isEqualsString(assurance.Sigle, name))
                    {
                        MessageBox.Show("Ce Sigle existe deja!", name);
                        return false;
                    }

                }
            }
            else
            {
                MessageBox.Show("Ce champ ne peut etre null", "Nom chambre");
                return false;
            }

            return true;
        }

        public static bool sigleExisteForUpdate(string id, string name)
        {
            if (id != null)
            {
                if (!String.IsNullOrEmpty(name))
                {
                    foreach (Assurances assurance in AssurancesModel.getAll())
                    {
                        if ((!isEqualsString(id, assurance.Id) && isEqualsString(name, assurance.Sigle)))
                        {
                            MessageBox.Show("Ce Sigle existe deja!", name);
                            return false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ce champ ne peut etre null", "Nom chambre");
                    return false;

                }


            }

            return true;
        }

        //For existe chambre

        public static bool nomCompExiste(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                foreach (Assurances assurance in AssurancesModel.getAll())
                {
                    if (isEqualsString(assurance.NomCompagnie, name))
                    {
                        MessageBox.Show("Cette compagnie existe deja!", name);
                        return false;
                    }

                }
            }
            else
            {
                MessageBox.Show("Ce champ ne peut etre null", "Nom chambre");
                return false;
            }

            return true;
        }

        public static bool nomCompExisteForUpdate(string id, string name)
        {
            if (id != null)
            {
                if (!String.IsNullOrEmpty(name))
                {
                    foreach (Assurances assurance in AssurancesModel.getAll())
                    {
                        if ((!isEqualsString(id, assurance.Id) && isEqualsString(name, assurance.NomCompagnie)))
                        {
                            MessageBox.Show("Cette compagnie existe deja!", name);
                            return false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ce champ ne peut etre null", "Nom chambre");
                    return false;

                }


            }

            return true;
        }

        //Add on combo
        public static void addToCombo(ComboBox comboBox, List<String> list)
        {
            foreach(String s in list)
            {
                comboBox.Items.Add(s);
            }
        }

        //Valide %
        public static bool correctPercent(double percent, String name)
        {
            if(percent < 0 || percent > 100)
            {
                MessageBox.Show("La valeur doit etre comprise entre 0 et 100");
                return false;
            }
            return true;
        }

        //user have account
        public static bool userHaveAccount(String id)
        {
            foreach(Utilisateurs utilisateur in UtilisateursModel.getAll())
            {
                if (utilisateur.IdEmp.Equals(id))
                {
                    MessageBox.Show("Le personnel a deja un compte", "Compte existe");
                    return true;
                }
            }
            return false;
        }

        // for Mail
        public static bool isValidMail(string emailaddress)
        {
            if (!String.IsNullOrEmpty(emailaddress))
            {
                try
                {
                    MailAddress m = new MailAddress(emailaddress);

                    return true;
                }
                catch (FormatException)
                {
                    MessageBox.Show("Email non valide", "Email");
                    return false;
                }
            }
            
            return false;
        }

        //[A-Za-z0-9]+(?:\s[A - Za - z0 - 9'_-]+)+
        public static bool adresseCorrect(string str)
        {
            if (str == null || !Regex.IsMatch(str, @"^([0-9])+, ([a-zA-Z0-9 \-])+, ([a-zA-Z0-9 \-])+, ([a-zA-Z0-9 \-])+$"))
            {

                MessageBox.Show("L'adresse est invalide (numero, rue, ville, pays)", "Adresse");
                return false;
            }
            return true;
        }

        public static bool nifOrCinValid(string str)
        {
            if (str == null || !Regex.IsMatch(str, @"^[0-9]{3}\-[0-9]{3}\-[0-9]{3}\-[0-9]{1}$") && !Regex.IsMatch(str, @"\d{10}"))
                
            {

                MessageBox.Show("NIF(xxx-xxx-xxx-x) ou CIN(xxxxxxxxxx) invalide", "NIF ou CIN");
                return false;
            }
            return true;
        }
        
        public static bool haveAge(string age)
        {
            String[] array = age.Split('/');
            double year = Double.Parse(array[2]);
            String []date = DateTime.Now.ToString("MM/dd/yyyy").Split('/');
            double yearNow = Double.Parse(date[2]);
            if(yearNow - year < 18 || (yearNow - year) > 60)
            {
                MessageBox.Show("Vous n'etes pas assez majeur pour ce poste (Age < 18 ou age > 60). ", "Age invalide");
                return false;
            }
            return true;
        }

        //phone number
        public static bool phoneCorrect(string str)
        {
            if (str == null || !Regex.IsMatch(str, @"^[2-4]{1}[0-9]{3}\-[0-9]{4}$"))
            {

                MessageBox.Show("Le numero de telephone est invalide(xxxx-xxxx)", "Telephone");
                return false;
            }
            return true;
        }
        //cleanup
        public static String cleanUp(String str)
        {
            str = str.Trim(' ');
            return str;
        }

        
    }
}
