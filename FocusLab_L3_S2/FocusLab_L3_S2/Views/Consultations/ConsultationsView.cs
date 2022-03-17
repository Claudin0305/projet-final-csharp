using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FocusLab_L3_S2.Model;
using FocusLab_L3_S2.Views;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System.IO;
namespace FocusLab_L3_S2.Views.Consultations
{
    public partial class ConsultationsView : Form
    {
        public static Panel p;
        public static Button ajout, affich;

        private void ajouter_Click(object sender, EventArgs e)
        {
            if(PatientsModel.getListIdPatient().Count > 0)
            {
                utils.Utils.loadform(container1, new ConsultationsRegister(null));
                ajouter.Visible = false;
                btnAfficher.Visible = true;
            }
            else
            {
                MessageBox.Show("Option indisponible, pas de patients!", "Ajouter consultation!");
            }
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {

            utils.Utils.loadform(container1, new ShowConsultations());
            ajouter.Visible = true;
            btnAfficher.Visible = false;
        }
        
        private void print_Click(object sender, EventArgs e)
        {
            if(comboIdHospi.SelectedIndex != -1)
            {
                printBilan();
            }
            else
            {
                MessageBox.Show("Vous devez Choisir l'id pour imprimer le bilan", "Bilan Hospitalisation");
            }
        }

        private void comboIdHospi_SelectedIndexChanged(object sender, EventArgs e)
        {
            print.Enabled = true;
        }

        public ConsultationsView()
        {
            InitializeComponent();
            if (comboIdHospi.SelectedIndex != -1)
                print.Enabled = true;
            utils.Utils.addToCombo(comboIdHospi, ConsultationsModel.getListIdHos());
            utils.Utils.loadform(container1, new ShowConsultations());
            p = container1;
            ajout = ajouter;
            affich = btnAfficher;
        }

        private void printBilan()
        {
            //creation du document
            Random random = new Random();
            String name = "..\\Debug\\Files\\hospitalisation\\bilan-hospitalisation-" + random.Next() + ".pdf";
            Document docPdf = new Document(PageSize.LETTER, 20f, 20f, 30f, 30f);
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
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            //Cellule du tableau
            src.Consultations consultations = new src.Consultations();
            if(comboIdHospi.SelectedIndex != -1)
            {
                consultations = ConsultationsModel.getById(comboIdHospi.SelectedItem.ToString());
                
                utils.FileGenerate.addCellToTabBody("ID consultation", table);
                utils.FileGenerate.addCellToTabBody(consultations.Id, table);
                utils.FileGenerate.addCellToTabBody("No Dossier Patient", table);
                utils.FileGenerate.addCellToTabBody(consultations.NoDossierPatient, table);
                utils.FileGenerate.addCellToTabBody("Consultation pour les services", table);
                utils.FileGenerate.addCellToTabBody(consultations.ConsultationPrServices, table);
                utils.FileGenerate.addCellToTabBody("Consultation payé sur assurance", table);
                utils.FileGenerate.addCellToTabBody(consultations.ConsultationPayAss, table);
                utils.FileGenerate.addCellToTabBody("Motif consultation", table);
                utils.FileGenerate.addCellToTabBody(consultations.MotifConsultation, table);
                utils.FileGenerate.addCellToTabBody("Nécessité d’hospitalisation", table);
                utils.FileGenerate.addCellToTabBody(consultations.NecessiteHospita, table);
                utils.FileGenerate.addCellToTabBody("Hospitalisation sur Assurance", table);
                utils.FileGenerate.addCellToTabBody(consultations.HospitalisationSurAss, table);
                utils.FileGenerate.addCellToTabBody("ID Chambre", table);
                utils.FileGenerate.addCellToTabBody(consultations.IdChambre, table);
                utils.FileGenerate.addCellToTabBody("Durée hospitalisation", table);
                utils.FileGenerate.addCellToTabBody(consultations.DureeHospital + "", table);
                utils.FileGenerate.addCellToTabBody("Médecins en charge", table);
                utils.FileGenerate.addCellToTabBody(consultations.MedecinEnCharge, table);
                utils.FileGenerate.addCellToTabBody("Date Consultation | Hospitalisation", table);
                utils.FileGenerate.addCellToTabBody(consultations.DateConsOrHosp, table);
            }



            docPdf.Add(table);
            docPdf.Close();
            MessageBox.Show("Le fichier se trouve dans: " + Path.GetFullPath(name), "Emplacement du fichier");
            System.Diagnostics.Process.Start(@"cmd.exe", @"/c" + name);
        }
    }
}
