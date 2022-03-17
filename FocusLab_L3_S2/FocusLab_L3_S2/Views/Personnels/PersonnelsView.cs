using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FocusLab_L3_S2.Views.Personnels;
using FocusLab_L3_S2.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System.IO;

namespace FocusLab_L3_S2.Views.Personnels
{
    public partial class PersonnelsView : Form
    {
        public static Panel p;
        public static Button ajout, affich;

        private void ajouter_Click(object sender, EventArgs e)
        {
            if(ServicesModel.getListServices().Count > 0)
            {
                utils.Utils.loadform(container, new PersonnelsRegister(null));
                ajouter.Visible = false;
                btnAfficher.Visible = true;
            }
            else
            {
                MessageBox.Show("Option indisponible, pas de services!", "Ajouter Personnels");
            }
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            utils.Utils.loadform(container, new ShowPersonnels());
            ajouter.Visible = true;
            btnAfficher.Visible = false;
        }

        private void print_Click(object sender, EventArgs e)
        {
            if (PersonnelsModel.getAll().Count > 0)
            {
                //print
                printPersonnels();
            }
            else
            {
                MessageBox.Show("Pas de personnels disponibles!", "Rien a imprimer");
            }
        }

        private void printLabel_Click(object sender, EventArgs e)
        {

        }

        public PersonnelsView()
        {
            InitializeComponent();
            utils.Utils.loadform(container, new ShowPersonnels());
            p = container;
            ajout = ajouter;
            affich = btnAfficher;
        }

        private void printPersonnels()
        {
            //creation du document
            Random random = new Random();
            String name = "..\\Debug\\Files\\personnels\\liste-personnel-" + random.Next() + ".pdf";
            Document docPdf = new Document(PageSize.LEGAL.Rotate(), 20f, 20f, 30f, 30f);
            PdfWriter pdfWriter = PdfWriter.GetInstance(docPdf, new FileStream(name, FileMode.Create));
            System.Drawing.Image pImage = System.Drawing.Image.FromFile("..\\Debug\\logo.png");
            iTextSharp.text.Image pIma = iTextSharp.text.Image.GetInstance(pImage, System.Drawing.Imaging.ImageFormat.Png);
            pIma.Alignment = Element.ALIGN_CENTER;

            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font1 = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font3 = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);
            Paragraph title = new Paragraph(new Chunk("Hopital Espoir / Personnels", font));
            title.Alignment = Element.ALIGN_CENTER;

            docPdf.Open();
            docPdf.Add(pIma);
            docPdf.Add(title);
            docPdf.Add(new Paragraph(new Chunk(new LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1))));
            docPdf.Add(new Phrase("\n"));
            /*
             * Nom, , Sexe (Masculin, Féminin), , , , , , Téléphone, ,  (liste de services),, ,
Etat(A :Actif, Q :Quitter).
             */
            //creation tableau
            PdfPTable table = new PdfPTable(16);
            table.WidthPercentage = 100;
            //Cellule du tableau
            utils.FileGenerate.addCellToTabHeader("ID", table);
            utils.FileGenerate.addCellToTabHeader("Catégorie", table);
            utils.FileGenerate.addCellToTabHeader("Nom ", table);
            utils.FileGenerate.addCellToTabHeader("Prénom", table);
            utils.FileGenerate.addCellToTabHeader("Sexe", table);
            utils.FileGenerate.addCellToTabHeader("Adresse", table);
            utils.FileGenerate.addCellToTabHeader("Domaine d’étude", table);
            utils.FileGenerate.addCellToTabHeader("Niveau d’étude", table);
            utils.FileGenerate.addCellToTabHeader("Spécialisation", table);
            utils.FileGenerate.addCellToTabHeader("Nb année exp.", table);
            utils.FileGenerate.addCellToTabHeader("Date de Naissance", table);
            utils.FileGenerate.addCellToTabHeader("Téléphone", table);
            utils.FileGenerate.addCellToTabHeader("Email", table);
            utils.FileGenerate.addCellToTabHeader("Services affectés", table);
            utils.FileGenerate.addCellToTabHeader("Nif/Cin", table);
            utils.FileGenerate.addCellToTabHeader("Etat", table);

            foreach (src.Personnels personnel in PersonnelsModel.getAll())
            {

                utils.FileGenerate.addCellToTabBody(personnel.Id, table);
                utils.FileGenerate.addCellToTabBody(personnel.Categorie, table);
                utils.FileGenerate.addCellToTabBody(personnel.Nom, table);
                utils.FileGenerate.addCellToTabBody(personnel.Prenom, table);
                utils.FileGenerate.addCellToTabBody(personnel.Sexe, table);
                utils.FileGenerate.addCellToTabBody(personnel.Adresse, table);
                utils.FileGenerate.addCellToTabBody(personnel.DomaineEtude, table);
                utils.FileGenerate.addCellToTabBody(personnel.NiveauEtude, table);
                utils.FileGenerate.addCellToTabBody(personnel.Specialisation, table);
                utils.FileGenerate.addCellToTabBody(personnel.NbAnneExpe+"", table);
                utils.FileGenerate.addCellToTabBody(personnel.DateNaissance, table);
                utils.FileGenerate.addCellToTabBody(personnel.Telephone, table);
                utils.FileGenerate.addCellToTabBody(personnel.Email, table);
                utils.FileGenerate.addCellToTabBody(personnel.ServicesAff, table);
                utils.FileGenerate.addCellToTabBody(personnel.NifOrCin, table);
                utils.FileGenerate.addCellToTabBody(personnel.Etat, table);
            }

            docPdf.Add(table);
            docPdf.Close();
            MessageBox.Show("Le fichier se trouve dans: " + Path.GetFullPath(name), "Emplacement du fichier");
            System.Diagnostics.Process.Start(@"cmd.exe", @"/c" + name);
        }
    }
}
