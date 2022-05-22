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
            bg.BackgroundImage = File.OpenRead("Nomina.jpg");

            page1.Artifacts.Add(bg);

            TextFragment txtOne = new TextFragment("texto texto");
            txtOne.Position = new Position(117, 712);
            txtOne.TextState.FontSize = 12;
            txtOne.TextState.Font = FontRepository.FindFont("Arial");
            txtOne.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

            TextFragment txtTwo = new TextFragment("direccion");
            txtTwo.Position = new Position(117, 682);
            txtTwo.TextState.FontSize = 12;
            txtTwo.TextState.Font = FontRepository.FindFont("Arial");
            txtTwo.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

            TextFragment txtThree = new TextFragment("recibo.TotalPagar.ToString()");
            txtThree.Position = new Position(400, 700);
            txtThree.TextState.FontSize = 12;
            txtThree.TextState.Font = FontRepository.FindFont("Arial");
            txtThree.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

            TextFragment txtFour = new TextFragment("totalLetras");
            txtFour.Position = new Position(400, 688);
            txtFour.TextState.FontSize = 12;
            txtFour.TextState.Font = FontRepository.FindFont("Arial");
            txtFour.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

            TextFragment txtFive = new TextFragment("subtM.ToString()");
            txtFive.Position = new Position(520, 279);
            txtFive.TextState.FontSize = 12;
            txtFive.TextState.Font = FontRepository.FindFont("Arial");
            txtFive.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);



            TextBuilder txtBuild = new TextBuilder(page1);
            txtBuild.AppendText(txtOne);
            txtBuild.AppendText(txtTwo);
            txtBuild.AppendText(txtThree);
            txtBuild.AppendText(txtFour);
            txtBuild.AppendText(txtFive);



            string pdfName = "tempPDF1.pdf";
            pdfDocument.Save(pdfName);
        }
       
    }
}
