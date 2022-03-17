using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using FocusLab_L3_S2.Model;

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;

namespace FocusLab_L3_S2.Views.Patients
{
    public partial class ShowPatients : Form
    {
        public ShowPatients()
        {
            InitializeComponent();
            foreach (src.Patients patient in PatientsModel.getAll())
            {
                this.dataGridView1.Rows.Add(patient.Id, patient.Nom, patient.Prenom, patient.Sexe, patient.DateNaissance,
                    patient.Age, patient.CompagnieAssure, patient.PersonneResponsable, patient.TelPersonResp,
                    patient.Adresse, patient.Telephone, patient.Email, patient.TraitementSuiv, patient.Memo);
            }

            utils.Utils.btnInDataGrid(dataGridView1, "edit");
            utils.Utils.btnInDataGrid(dataGridView1, "print");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int line = dataGridView1.CurrentCell.RowIndex;
            String id = "" + dataGridView1.Rows[line].Cells[0].Value;
            //edit
            if (e.ColumnIndex == 14)
            {
                if(ServicesModel.getListServices().Count > 0)
                {
                    utils.Utils.loadform(PatientsView.p, new PatientsRegister(PatientsModel.getById(id)));
                }
                else
                {
                    MessageBox.Show("Pas de traitement disponible", "Traitement");
                }
            }

            //supprime
            if (e.ColumnIndex == 15)
            {
                Random random = new Random();
                src.Patients p = PatientsModel.getById(id);
                String name = "..\\Debug\\Files\\dossier\\" + p.Prenom + "-" + p.Nom + "-" + random.Next() + ".pdf"; 
                Document docPdf = new Document(PageSize.LETTER, 20f, 20f, 30f, 30f);
                PdfWriter pdfWriter = PdfWriter.GetInstance(docPdf, new FileStream(name, FileMode.Create));
                System.Drawing.Image pImage = System.Drawing.Image.FromFile("..\\Debug\\logo.png");
                iTextSharp.text.Image pIma = iTextSharp.text.Image.GetInstance(pImage, System.Drawing.Imaging.ImageFormat.Png);
                pIma.Alignment = Element.ALIGN_CENTER;

                BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font font1 = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font font3 = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);
                Paragraph title = new Paragraph(new Chunk("Hopital Espoir / Dossier patient", font));
                title.Alignment = Element.ALIGN_CENTER;
                Paragraph pa1 = new Paragraph(new Chunk("No Dossier: .................................................................................  " + p.Id));
                Paragraph pa2 = new Paragraph("Nom: ................................................................................................. " +  p.Nom);
                Paragraph pa3 = new Paragraph("Prenom: ....................................................................................... " + p.Prenom);
                Paragraph pa = new Paragraph("Telephone: ............................................................................... " + p.Telephone);
                Paragraph pa4 = new Paragraph("Sexe: ............................................................................... " + p.Sexe);
                Paragraph pa5 = new Paragraph("Date Naissance: ............................................................................... " + p.DateNaissance);
                Paragraph pa6 = new Paragraph("Age: ......................................................................................." + p.Age);
                Paragraph pa7 = new Paragraph("Comp Ass: ..............................................................................." + p.CompagnieAssure);
                Paragraph pa8 = new Paragraph("Personne responsable: ..............................................................................." + p.PersonneResponsable);
                Paragraph pa9 = new Paragraph("Tel pers Resp: ............................................................................... " + p.TelPersonResp);
                Paragraph pa10 = new Paragraph("Adresse: ............................................................................................. " + p.Adresse);
                Paragraph pa11 = new Paragraph("E-mail: ............................................................................... " + p.Email);
                Paragraph pa12 = new Paragraph("Traitement suivis: ............................................................................... " + p.TraitementSuiv);
                Paragraph pa13 = new Paragraph("Memo: ............................................................................... " + p.Memo);
                
                docPdf.Open();
                docPdf.Add(pIma);
                docPdf.Add(title);
                docPdf.Add(new Paragraph(new Chunk(new LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1))));
                docPdf.Add(pa1);
                docPdf.Add(pa2);
                docPdf.Add(pa);
                docPdf.Add(pa3);
                docPdf.Add(pa4);
                docPdf.Add(pa5);
                docPdf.Add(pa6);
                docPdf.Add(pa7);
                docPdf.Add(pa8);
                docPdf.Add(pa9);
                docPdf.Add(pa10);
                docPdf.Add(pa11);
                docPdf.Add(pa12);
                docPdf.Add(pa13);

                

                docPdf.Close();
                MessageBox.Show("Le fichier se trouve dans: " + Path.GetFullPath(name), "Emplacement du fichier");
                System.Diagnostics.Process.Start(@"cmd.exe", @"/c" + name);

            }
        }


       
    }
}
