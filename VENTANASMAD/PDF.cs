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
            bg.BackgroundImage = File.OpenRead("Recibo.jpg");

            page1.Artifacts.Add(bg);
            for (int i = 0; i < 6; i++)
            {
                if (i == 0)
                {

                    TextFragment txtOne = new TextFragment("texto1");
                    txtOne.Position = new Position(80, 580);
                    txtOne.TextState.FontSize = 12;
                    txtOne.TextState.Font = FontRepository.FindFont("Arial");
                    txtOne.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextFragment txtTwo = new TextFragment("texto3");
                    txtTwo.Position = new Position(190, 580);
                    txtTwo.TextState.FontSize = 12;
                    txtTwo.TextState.Font = FontRepository.FindFont("Arial");
                    txtTwo.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextFragment txtThree = new TextFragment("texto4");
                    txtThree.Position = new Position(320, 580);
                    txtThree.TextState.FontSize = 12;
                    txtThree.TextState.Font = FontRepository.FindFont("Arial");
                    txtThree.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextFragment txtFour = new TextFragment("texto5");
                    txtFour.Position = new Position(410, 580);
                    txtFour.TextState.FontSize = 12;
                    txtFour.TextState.Font = FontRepository.FindFont("Arial");
                    txtFour.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextFragment txtFive = new TextFragment("texto7");
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

                    TextFragment txtOne = new TextFragment("texto8");
                    txtOne.Position = new Position(250, 520);
                    txtOne.TextState.FontSize = 12;
                    txtOne.TextState.Font = FontRepository.FindFont("Arial");
                    txtOne.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextFragment txtTwo = new TextFragment("texto9");
                    txtTwo.Position = new Position(375, 520);
                    txtTwo.TextState.FontSize = 12;
                    txtTwo.TextState.Font = FontRepository.FindFont("Arial");
                    txtTwo.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextFragment txtThree = new TextFragment("texto10");
                    txtThree.Position = new Position(120, 470);
                    txtThree.TextState.FontSize = 12;
                    txtThree.TextState.Font = FontRepository.FindFont("Arial");
                    txtThree.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextFragment txtFour = new TextFragment("texto11");
                    txtFour.Position = new Position(250, 460);
                    txtFour.TextState.FontSize = 12;
                    txtFour.TextState.Font = FontRepository.FindFont("Arial");
                    txtFour.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextFragment txtFive = new TextFragment("texto12");
                    txtFive.Position = new Position(375, 460);
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
                if (i == 2)
                {
                    TextFragment txtOne = new TextFragment("texto13");
                    txtOne.Position = new Position(90, 365);
                    txtOne.TextState.FontSize = 12;
                    txtOne.TextState.Font = FontRepository.FindFont("Arial");
                    txtOne.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextFragment txtTwo = new TextFragment("texto14");
                    txtTwo.Position = new Position(165, 365);
                    txtTwo.TextState.FontSize = 12;
                    txtTwo.TextState.Font = FontRepository.FindFont("Arial");
                    txtTwo.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextFragment txtThree = new TextFragment("texto15");
                    txtThree.Position = new Position(90, 325);
                    txtThree.TextState.FontSize = 12;
                    txtThree.TextState.Font = FontRepository.FindFont("Arial");
                    txtThree.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextFragment txtFour = new TextFragment("texto16");
                    txtFour.Position = new Position(165, 325);
                    txtFour.TextState.FontSize = 12;
                    txtFour.TextState.Font = FontRepository.FindFont("Arial");
                    txtFour.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextFragment txtFive = new TextFragment("texto17");
                    txtFive.Position = new Position(90, 270);
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
                if (i == 3)
                {
                    TextFragment txtOne = new TextFragment("texto19");
                    txtOne.Position = new Position(165, 270);
                    txtOne.TextState.FontSize = 12;
                    txtOne.TextState.Font = FontRepository.FindFont("Arial");
                    txtOne.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextFragment txtTwo = new TextFragment("texto20");
                    txtTwo.Position = new Position(90, 225);
                    txtTwo.TextState.FontSize = 12;
                    txtTwo.TextState.Font = FontRepository.FindFont("Arial");
                    txtTwo.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextFragment txtThree = new TextFragment("texto21");
                    txtThree.Position = new Position(165, 225);
                    txtThree.TextState.FontSize = 12;
                    txtThree.TextState.Font = FontRepository.FindFont("Arial");
                    txtThree.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextFragment txtFour = new TextFragment("texto22");
                    txtFour.Position = new Position(300, 355);
                    txtFour.TextState.FontSize = 12;
                    txtFour.TextState.Font = FontRepository.FindFont("Arial");
                    txtFour.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextFragment txtFive = new TextFragment("texto23");
                    txtFive.Position = new Position(385, 355);
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
                if (i == 4)
                {
                    TextFragment txtOne = new TextFragment("texto24");
                    txtOne.Position = new Position(490, 355);
                    txtOne.TextState.FontSize = 12;
                    txtOne.TextState.Font = FontRepository.FindFont("Arial");
                    txtOne.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextFragment txtTwo = new TextFragment("texto25");
                    txtTwo.Position = new Position(300, 315);
                    txtTwo.TextState.FontSize = 12;
                    txtTwo.TextState.Font = FontRepository.FindFont("Arial");
                    txtTwo.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextFragment txtThree = new TextFragment("texto26");
                    txtThree.Position = new Position(385, 315);
                    txtThree.TextState.FontSize = 12;
                    txtThree.TextState.Font = FontRepository.FindFont("Arial");
                    txtThree.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextFragment txtFour = new TextFragment("texto27");
                    txtFour.Position = new Position(490, 315);
                    txtFour.TextState.FontSize = 12;
                    txtFour.TextState.Font = FontRepository.FindFont("Arial");
                    txtFour.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextFragment txtFive = new TextFragment("texto28");
                    txtFive.Position = new Position(75, 110);
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
                if (i == 5)
                {
                    TextFragment txtOne = new TextFragment("texto29");
                    txtOne.Position = new Position(170, 110);
                    txtOne.TextState.FontSize = 12;
                    txtOne.TextState.Font = FontRepository.FindFont("Arial");
                    txtOne.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextFragment txtTwo = new TextFragment("texto30");
                    txtTwo.Position = new Position(290, 110);
                    txtTwo.TextState.FontSize = 12;
                    txtTwo.TextState.Font = FontRepository.FindFont("Arial");
                    txtTwo.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextFragment txtThree = new TextFragment("texto31");
                    txtThree.Position = new Position(385, 315);
                    txtThree.TextState.FontSize = 12;
                    txtThree.TextState.Font = FontRepository.FindFont("Arial");
                    txtThree.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextFragment txtFour = new TextFragment("texto32");
                    txtFour.Position = new Position(490, 315);
                    txtFour.TextState.FontSize = 12;
                    txtFour.TextState.Font = FontRepository.FindFont("Arial");
                    txtFour.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextFragment txtFive = new TextFragment("texto33");
                    txtFive.Position = new Position(75, 110);
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
    }
}
