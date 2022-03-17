using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FocusLab_L3_S2.Model;
using FocusLab_L3_S2.Views.Assurances;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;

namespace FocusLab_L3_S2.Views.Assurances
{
    public partial class AssurancesView : Form
    {
        public static Panel p;
        public static Button ajout, affich;

        private void ajouter_Click(object sender, EventArgs e)
        {
            utils.Utils.loadform(container, new AssurancesRegister(null));
            ajouter.Visible = false;
            btnAfficher.Visible = true;
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            utils.Utils.loadform(container, new ShowAssurances());
            ajouter.Visible = true;
            btnAfficher.Visible = false;
        }

        private void print_Click(object sender, EventArgs e)
        {
            if(AssurancesModel.getAll().Count > 0)
            {
                printCompagnies();
            }
            else
            {
                MessageBox.Show("Pas de compagnies disponibles!", "Rien a imprimer");
            }
        }

        public AssurancesView()
        {
            InitializeComponent();
            utils.Utils.loadform(container, new ShowAssurances());
            p = container;
            ajout = ajouter;
            affich = btnAfficher;
        }


        private void printCompagnies()
        {
            //creation du document
            Random random = new Random();
            String name = "..\\Debug\\Files\\contrats\\liste-compagnie-assurance -" + random.Next() + ".pdf";
            Document docPdf = new Document(PageSize.LEGAL.Rotate(), 20f, 20f, 30f, 30f);
            PdfWriter pdfWriter = PdfWriter.GetInstance(docPdf, new FileStream(name, FileMode.Create));
            System.Drawing.Image pImage = System.Drawing.Image.FromFile("..\\Debug\\logo.png");
            iTextSharp.text.Image pIma = iTextSharp.text.Image.GetInstance(pImage, System.Drawing.Imaging.ImageFormat.Png);
            pIma.Alignment = Element.ALIGN_CENTER;

            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font1 = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font3 = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);
            Paragraph title = new Paragraph(new Chunk("Hopital Espoir / Compagnies assurances", font));
            title.Alignment = Element.ALIGN_CENTER;

            docPdf.Open();
            docPdf.Add(pIma);
            docPdf.Add(title);
            docPdf.Add(new Paragraph(new Chunk(new LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1))));
            docPdf.Add(new Phrase("\n"));
           
            //creation tableau
            PdfPTable table = new PdfPTable(11);
            table.WidthPercentage = 100;
            //Cellule du tableau
            utils.FileGenerate.addCellToTabHeader("Id contrat", table);
            utils.FileGenerate.addCellToTabHeader("Nom compagnie", table);
            utils.FileGenerate.addCellToTabHeader("Sigle ", table);
            utils.FileGenerate.addCellToTabHeader("Nom Directeur", table);
            utils.FileGenerate.addCellToTabHeader("Adresse", table);
            utils.FileGenerate.addCellToTabHeader("Téléphone", table);
            utils.FileGenerate.addCellToTabHeader("Email", table);
            utils.FileGenerate.addCellToTabHeader("%consultation", table);
            utils.FileGenerate.addCellToTabHeader("%chambre", table);
            utils.FileGenerate.addCellToTabHeader("%hospitalisation", table);
            utils.FileGenerate.addCellToTabHeader("Etat", table);

            foreach (src.Assurances assurance in AssurancesModel.getAll())
            {
                
                utils.FileGenerate.addCellToTabBody(assurance.Id, table);
                utils.FileGenerate.addCellToTabBody(assurance.NomCompagnie, table);
                utils.FileGenerate.addCellToTabBody(assurance.Sigle, table);
                utils.FileGenerate.addCellToTabBody(assurance.NomDirecteur, table);
                utils.FileGenerate.addCellToTabBody(assurance.Adresse, table);
                utils.FileGenerate.addCellToTabBody(assurance.Telephone, table);
                utils.FileGenerate.addCellToTabBody(assurance.Email, table);
                utils.FileGenerate.addCellToTabBody(assurance.PercentPaimentCons+"", table);
                utils.FileGenerate.addCellToTabBody(assurance.PercentPaimentCh + "", table);
                utils.FileGenerate.addCellToTabBody(assurance.PercentPaimentHosp + "", table);
                utils.FileGenerate.addCellToTabBody(assurance.Etat, table);
            }

            docPdf.Add(table);
            docPdf.Close();
            MessageBox.Show("Le fichier se trouve dans: " + Path.GetFullPath(name), "Emplacement du fichier");
            System.Diagnostics.Process.Start(@"cmd.exe", @"/c" + name);
        }
    }

}
