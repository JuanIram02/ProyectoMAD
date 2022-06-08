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
            var db = new EnlaceDB();

            var nomina = db.gestionNominas("S", numeroNomina, "null", "null", "null", "null", "null", "null", "null", "null");

            var empleado = db.gestionEmpleados("S", nomina.Rows[0][2].ToString(), "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null");

            var departamento = db.gestionDepartamentos("S", nomina.Rows[0][3].ToString(), "null", "null", "null");

            var puesto = db.gestionPuestos("S", nomina.Rows[0][4].ToString(), "null", "null", "null");

            var empresa = db.gestionEmpresa("S", nomina.Rows[0][5].ToString(), "null", "null", "null", "null", "null", "null");

            var percepciones = db.gestionListaP("N", "null", "null", "null", "null", "null", "null", numeroNomina);

            var deducciones = db.gestionListaD("N", "null", "null", "null", "null", "null", "null", numeroNomina);

            var fecha = nomina.Rows[0][6];

            int monthDays = DateTime.DaysInMonth(((System.DateTime)fecha).Year, ((System.DateTime)fecha).Month);

            float sueldoDiario = float.Parse(departamento.Rows[0][2].ToString()) * float.Parse(puesto.Rows[0][2].ToString()) / 100;

            string sD = String.Format("{0:C}", sueldoDiario);

            float sueldoNeto = float.Parse(nomina.Rows[0][8].ToString());

            string sN = String.Format("{0:C}", sueldoNeto);

            float sueldoBruto = float.Parse(nomina.Rows[0][7].ToString());

            string sB = String.Format("{0:C}", sueldoBruto);

            var conv = new Convertidor();

            var letras = conv.enletras(nomina.Rows[0][8].ToString());

            Document pdfDocument = new Document();
            Page page1 = pdfDocument.Pages.Add();
            BackgroundArtifact bg = new BackgroundArtifact();
            bg.BackgroundImage = File.OpenRead(".../.../Resources/RECIBO.jpg");

            page1.Artifacts.Add(bg);
            for (int i = 0; i < 6; i++)
            {
                if (i == 0)
                {
                    //Nombre
                    TextFragment txtOne = new TextFragment(empleado.Rows[0][13].ToString() + empleado.Rows[0][14].ToString() + empleado.Rows[0][15].ToString());
                    txtOne.Position = new Position(70, 580);
                    txtOne.TextState.FontSize = 12;
                    txtOne.TextState.Font = FontRepository.FindFont("Arial");
                    txtOne.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    //NSS
                    TextFragment txtTwo = new TextFragment(empleado.Rows[0][2].ToString());
                    txtTwo.Position = new Position(190, 580);
                    txtTwo.TextState.FontSize = 12;
                    txtTwo.TextState.Font = FontRepository.FindFont("Arial");
                    txtTwo.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    //CURP
                    TextFragment txtThree = new TextFragment(empleado.Rows[0][1].ToString());
                    txtThree.Position = new Position(310, 580);
                    txtThree.TextState.FontSize = 12;
                    txtThree.TextState.Font = FontRepository.FindFont("Arial");
                    txtThree.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    //RFC
                    TextFragment txtFour = new TextFragment(empleado.Rows[0][3].ToString());
                    txtFour.Position = new Position(410, 580);
                    txtFour.TextState.FontSize = 12;
                    txtFour.TextState.Font = FontRepository.FindFont("Arial");
                    txtFour.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    //Numero Empleado
                    TextFragment txtFive = new TextFragment(empleado.Rows[0][0].ToString());
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

                    //Puesto
                    TextFragment txtOne = new TextFragment(puesto.Rows[0][1].ToString());
                    txtOne.Position = new Position(250, 520);
                    txtOne.TextState.FontSize = 12;
                    txtOne.TextState.Font = FontRepository.FindFont("Arial");
                    txtOne.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    //Departamento
                    TextFragment txtTwo = new TextFragment(departamento.Rows[0][1].ToString());
                    txtTwo.Position = new Position(375, 520);
                    txtTwo.TextState.FontSize = 12;
                    txtTwo.TextState.Font = FontRepository.FindFont("Arial");
                    txtTwo.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    //Dias trabajados
                    TextFragment txtThree = new TextFragment(monthDays.ToString());
                    txtThree.Position = new Position(120, 470);
                    txtThree.TextState.FontSize = 12;
                    txtThree.TextState.Font = FontRepository.FindFont("Arial");
                    txtThree.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    //Sueldo Diario
                    TextFragment txtFour = new TextFragment(sD);
                    txtFour.Position = new Position(250, 460);
                    txtFour.TextState.FontSize = 12;
                    txtFour.TextState.Font = FontRepository.FindFont("Arial");
                    txtFour.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    //Fecha Alta
                    TextFragment txtFive = new TextFragment(empleado.Rows[0][11].ToString());
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
                //if (i == 2)
                //{
                //    TextFragment txtOne = new TextFragment("texto13");
                //    txtOne.Position = new Position(90, 365);
                //    txtOne.TextState.FontSize = 12;
                //    txtOne.TextState.Font = FontRepository.FindFont("Arial");
                //    txtOne.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                //    TextFragment txtTwo = new TextFragment("texto14");
                //    txtTwo.Position = new Position(165, 365);
                //    txtTwo.TextState.FontSize = 12;
                //    txtTwo.TextState.Font = FontRepository.FindFont("Arial");
                //    txtTwo.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                //    TextFragment txtThree = new TextFragment("texto15");
                //    txtThree.Position = new Position(90, 325);
                //    txtThree.TextState.FontSize = 12;
                //    txtThree.TextState.Font = FontRepository.FindFont("Arial");
                //    txtThree.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                //    TextFragment txtFour = new TextFragment("texto16");
                //    txtFour.Position = new Position(165, 325);
                //    txtFour.TextState.FontSize = 12;
                //    txtFour.TextState.Font = FontRepository.FindFont("Arial");
                //    txtFour.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                //    TextFragment txtFive = new TextFragment("texto17");
                //    txtFive.Position = new Position(90, 270);
                //    txtFive.TextState.FontSize = 12;
                //    txtFive.TextState.Font = FontRepository.FindFont("Arial");
                //    txtFive.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);


                //    TextBuilder txtBuild = new TextBuilder(page1);
                //    txtBuild.AppendText(txtOne);
                //    txtBuild.AppendText(txtTwo);
                //    txtBuild.AppendText(txtThree);
                //    txtBuild.AppendText(txtFour);
                //    txtBuild.AppendText(txtFive);
                //}
                //if (i == 3)
                //{
                //    TextFragment txtOne = new TextFragment("texto19");
                //    txtOne.Position = new Position(165, 270);
                //    txtOne.TextState.FontSize = 12;
                //    txtOne.TextState.Font = FontRepository.FindFont("Arial");
                //    txtOne.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                //    TextFragment txtTwo = new TextFragment("texto20");
                //    txtTwo.Position = new Position(90, 225);
                //    txtTwo.TextState.FontSize = 12;
                //    txtTwo.TextState.Font = FontRepository.FindFont("Arial");
                //    txtTwo.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                //    TextFragment txtThree = new TextFragment("texto21");
                //    txtThree.Position = new Position(165, 225);
                //    txtThree.TextState.FontSize = 12;
                //    txtThree.TextState.Font = FontRepository.FindFont("Arial");
                //    txtThree.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                //    TextFragment txtFour = new TextFragment("texto22");
                //    txtFour.Position = new Position(300, 355);
                //    txtFour.TextState.FontSize = 12;
                //    txtFour.TextState.Font = FontRepository.FindFont("Arial");
                //    txtFour.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                //    TextFragment txtFive = new TextFragment("texto23");
                //    txtFive.Position = new Position(385, 355);
                //    txtFive.TextState.FontSize = 12;
                //    txtFive.TextState.Font = FontRepository.FindFont("Arial");
                //    txtFive.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);


                //    TextBuilder txtBuild = new TextBuilder(page1);
                //    txtBuild.AppendText(txtOne);
                //    txtBuild.AppendText(txtTwo);
                //    txtBuild.AppendText(txtThree);
                //    txtBuild.AppendText(txtFour);
                //    txtBuild.AppendText(txtFive);

                //}
                if (i == 4)
                {
                    //TextFragment txtOne = new TextFragment("texto24");
                    //txtOne.Position = new Position(490, 355);
                    //txtOne.TextState.FontSize = 12;
                    //txtOne.TextState.Font = FontRepository.FindFont("Arial");
                    //txtOne.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    //TextFragment txtTwo = new TextFragment("texto25");
                    //txtTwo.Position = new Position(300, 315);
                    //txtTwo.TextState.FontSize = 12;
                    //txtTwo.TextState.Font = FontRepository.FindFont("Arial");
                    //txtTwo.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    //TextFragment txtThree = new TextFragment("texto26");
                    //txtThree.Position = new Position(385, 315);
                    //txtThree.TextState.FontSize = 12;
                    //txtThree.TextState.Font = FontRepository.FindFont("Arial");
                    //txtThree.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    //TextFragment txtFour = new TextFragment("texto27");
                    //txtFour.Position = new Position(490, 315);
                    //txtFour.TextState.FontSize = 12;
                    //txtFour.TextState.Font = FontRepository.FindFont("Arial");
                    //txtFour.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    //Sueldo Neto
                    TextFragment txtFive = new TextFragment(sN);
                    txtFive.Position = new Position(75, 110);
                    txtFive.TextState.FontSize = 12;
                    txtFive.TextState.Font = FontRepository.FindFont("Arial");
                    txtFive.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);


                    TextBuilder txtBuild = new TextBuilder(page1);
                    //txtBuild.AppendText(txtOne);
                    //txtBuild.AppendText(txtTwo);
                    //txtBuild.AppendText(txtThree);
                    //txtBuild.AppendText(txtFour);
                    txtBuild.AppendText(txtFive);

                }
                if (i == 5)
                {
                    //Sueldo Bruto
                    TextFragment txtOne = new TextFragment(sB);
                    txtOne.Position = new Position(170, 110);
                    txtOne.TextState.FontSize = 12;
                    txtOne.TextState.Font = FontRepository.FindFont("Arial");
                    txtOne.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    //Sueldo en Letras
                    TextFragment txtTwo = new TextFragment(letras);
                    txtTwo.Position = new Position(290, 110);
                    txtTwo.TextState.FontSize = 12;
                    txtTwo.TextState.Font = FontRepository.FindFont("Arial");
                    txtTwo.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);                  

                    TextBuilder txtBuild = new TextBuilder(page1);
                    txtBuild.AppendText(txtOne);
                    txtBuild.AppendText(txtTwo);                   

                    string pdfName = "RecibodeNomina.pdf";
                    pdfDocument.Save(pdfName);
                }

            }
        }
    }
}
