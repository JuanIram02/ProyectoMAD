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
            bg.BackgroundImage = File.OpenRead("Nominaa.jpg");

            page1.Artifacts.Add(bg);
            for (int i = 0; i < 6; i++)
            {
                if (i == 0)
                {

                    TextFragment txtOne = new TextFragment("texto texto");
                    txtOne.Position = new Position(80, 580);
                    txtOne.TextState.FontSize = 12;
                    txtOne.TextState.Font = FontRepository.FindFont("Arial");
                    txtOne.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextFragment txtTwo = new TextFragment("direccion");
                    txtTwo.Position = new Position(190, 580);
                    txtTwo.TextState.FontSize = 12;
                    txtTwo.TextState.Font = FontRepository.FindFont("Arial");
                    txtTwo.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextFragment txtThree = new TextFragment("curp");
                    txtThree.Position = new Position(320, 580);
                    txtThree.TextState.FontSize = 12;
                    txtThree.TextState.Font = FontRepository.FindFont("Arial");
                    txtThree.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextFragment txtFour = new TextFragment("totalLetras");
                    txtFour.Position = new Position(410, 580);
                    txtFour.TextState.FontSize = 12;
                    txtFour.TextState.Font = FontRepository.FindFont("Arial");
                    txtFour.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextFragment txtFive = new TextFragment("subtM.ToString()");
                    txtFive.Position = new Position(120, 520);
                    txtFive.TextState.FontSize = 12;
                    txtFive.TextState.Font = FontRepository.FindFont("Arial");
                    txtFive.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);




                    TextBuilder txtBuild = new TextBuilder(page1);
                    txtBuild.AppendText(txtOne);
                    txtBuild.AppendText(txtTwo);
                    txtBuild.AppendText(txtThree);
                    txtBuild.AppendText(txtFour);
                    txtBuild.AppendText(txtFive);
                }
                if (i == 1)
                {

                    TextFragment txtOne = new TextFragment("AAAAAAAAAAAAAAA");
                    txtOne.Position = new Position(250, 520);
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
    }
}
