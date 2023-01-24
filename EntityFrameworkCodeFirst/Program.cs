using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Document doc = new Document(PageSize.A4);
            doc.SetMargins(40, 40, 40, 80);
            doc.AddCreationDate();
            string caminho = @"C:\pdf\" + "relatorio.pdf";

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));
            
            doc.Open();

            Paragraph titulo = new Paragraph();
            titulo.Font = new Font(Font.FontFamily.COURIER, 40);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.Add("Testeee");
            doc.Add(titulo);

            Paragraph paragrafo = new Paragraph("", new Font(Font.NORMAL,12));
            string conteudo = "Lorem Ipsum is simply dummy text of printing.\n\n";
            paragrafo.Add(conteudo);
            doc.Add(paragrafo);

            PdfPTable table = new PdfPTable(3);

            table.AddCell("Linha 1 ,Coluna 1");
            table.AddCell("Linha 1 ,Coluna 2");
            table.AddCell("Linha 1 ,Coluna 3");

            table.AddCell("Linha 2 ,Coluna 1");
            table.AddCell("Linha 2 ,Coluna 2");
            table.AddCell("Linha 2 ,Coluna 3");

            doc.Add(table);

            doc.Close();

            System.Diagnostics.Process.Start(caminho);

        }
    }
}
