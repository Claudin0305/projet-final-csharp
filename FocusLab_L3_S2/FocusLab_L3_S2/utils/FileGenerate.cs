using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusLab_L3_S2.utils
{
    public class FileGenerate
    {
        public static void addCellToTabHeader(String str, PdfPTable table)
        {
            PdfPCell cell = new PdfPCell(new Phrase(str));
            cell.Padding = 7;
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell.BorderColor = BaseColor.BLACK;
            table.AddCell(cell);
        }

        public static void addCellToTabBody(String str, PdfPTable table)
        {
            PdfPCell cell = new PdfPCell(new Phrase(str));
            cell.Padding = 7;
            table.AddCell(cell);

        }
    }
}
