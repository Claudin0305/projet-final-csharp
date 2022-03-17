using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FocusLab_L3_S2.Views.Chambres;
using FocusLab_L3_S2.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System.IO;

namespace FocusLab_L3_S2.Views.Chambres
{
    public partial class ChambresView : Form
    {
        public static Panel p;
        public static Button ajout, affich;
        public ChambresView()
        {
            InitializeComponent();
            utils.Utils.loadform(container, new ShowChambres());
            p = container;
            ajout = ajouter;
            affich = btnAfficher;
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {

            utils.Utils.loadform(container, new ShowChambres());
            ajouter.Visible = true;
            btnAfficher.Visible = false;
        }

        private void ajouter_Click(object sender, EventArgs e)
        {
            utils.Utils.loadform(container, new ChambresRegister(null));
            ajouter.Visible = false;
            btnAfficher.Visible = true;
        }

        private void print_Click(object sender, EventArgs e)
        {
            if(ChambresModel.getListIdChDisponible().Count > 0)
            {
                printChambreDisponible();
            }
            else
            {
                MessageBox.Show("Pas de chambre disponibles!", "Rien a imprimer");
            }
        }

        private void printChambreDisponible()
        {
            //creation du document
            Random random = new Random();
            String name = "..\\Debug\\Files\\chambres\\liste-chambre -" + random.Next() + ".pdf";
            Document docPdf = new Document(PageSize.LETTER.Rotate(), 20f, 20f, 30f, 30f);
            PdfWriter pdfWriter = PdfWriter.GetInstance(docPdf, new FileStream(name, FileMode.Create));
            System.Drawing.Image pImage = System.Drawing.Image.FromFile("..\\Debug\\logo.png");
            iTextSharp.text.Image pIma = iTextSharp.text.Image.GetInstance(pImage, System.Drawing.Imaging.ImageFormat.Png);
            pIma.Alignment = Element.ALIGN_CENTER;

            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font1 = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font3 = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);
            Paragraph title = new Paragraph(new Chunk("Hopital Espoir / Chambres disponibles", font));
            title.Alignment = Element.ALIGN_CENTER;

            docPdf.Open();
            docPdf.Add(pIma);
            docPdf.Add(title);
            docPdf.Add(new Paragraph(new Chunk(new LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1))));
            docPdf.Add(new Phrase("\n"));
            //creation tableau
            PdfPTable table = new PdfPTable(8);
            table.WidthPercentage = 100;
            //Cellule du tableau
            utils.FileGenerate.addCellToTabHeader("ID Chambre", table);
            utils.FileGenerate.addCellToTabHeader("Nom", table);
            utils.FileGenerate.addCellToTabHeader("Type Chambre", table);
            utils.FileGenerate.addCellToTabHeader("Couvrir par assurance", table);
            utils.FileGenerate.addCellToTabHeader("Prix Loc/jour", table);
            utils.FileGenerate.addCellToTabHeader("Etat", table);
            utils.FileGenerate.addCellToTabHeader("Constituant", table);
            utils.FileGenerate.addCellToTabHeader("Description", table);

            foreach(src.Chambres chambre in ChambresModel.getAll())
            {
               
                if (chambre.Etat.Equals("Disponible"))
                {
                    utils.FileGenerate.addCellToTabBody(chambre.Id, table);
                    utils.FileGenerate.addCellToTabBody(chambre.Nom, table);
                    utils.FileGenerate.addCellToTabBody(chambre.Type, table);
                    utils.FileGenerate.addCellToTabBody(chambre.CouvrirParAssurance, table);
                    utils.FileGenerate.addCellToTabBody(chambre.PrixLocation + "", table);
                    utils.FileGenerate.addCellToTabBody(chambre.Etat, table);
                    utils.FileGenerate.addCellToTabBody(chambre.Constituants, table);
                    utils.FileGenerate.addCellToTabBody(chambre.Description, table);
                    
                }
            }
            
            docPdf.Add(table);
            docPdf.Close();
            MessageBox.Show("Le fichier se trouve dans: " + Path.GetFullPath(name), "Emplacement du fichier");
            System.Diagnostics.Process.Start(@"cmd.exe", @"/c" + name);
        }
    }
}
