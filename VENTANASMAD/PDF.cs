using Aspose.Pdf;
using Aspose.Pdf.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VENTANASMAD
{
    class PDF
    {

       public void generaPDF(string numeroNomina)
        {
            Document pdfDocument = new Document();
            Page page1 = pdfDocument.Pages.Add();
            BackgroundArtifact bg = new BackgroundArtifact();
            bg.BackgroundImage = File.OpenRead("bebe.jpg");
            page1.Artifacts.Add(bg);
            TextFragment txtOne = new TextFragment("texto texto");
            txtOne.Position = new Position(117, 712);
            txtOne.TextState.FontSize = 12;
            txtOne.TextState.Font = FontRepository.FindFont("Arial");
            txtOne.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);
            TextBuilder txtBuild = new TextBuilder(page1);
            txtBuild.AppendText(txtOne);
            string pdfName = "tempPDF1.pdf";
            pdfDocument.Save(pdfName);
        }
       
    }
}
