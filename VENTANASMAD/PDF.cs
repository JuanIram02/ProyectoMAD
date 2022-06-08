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
            bg.BackgroundImage = File.OpenRead(".../.../Resources/ORECIBONOMI.jpg");

            page1.Artifacts.Add(bg);
            for (int i = 0; i < 6; i++)
            {
                if (i == 0)
                {
                    //Nombre
                    TextFragment txtOne = new TextFragment(empleado.Rows[0][13].ToString() + " " + empleado.Rows[0][14].ToString() + " " + empleado.Rows[0][15].ToString());
                    txtOne.Position = new Position(50, 580);
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
                    txtThree.Position = new Position(275, 580);
                    txtThree.TextState.FontSize = 10;
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

                    //Periodo de Pago
                    TextFragment txtFive = new TextFragment(empleado.Rows[0][11].ToString());
                    txtFive.Position = new Position(390, 475);
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

                    float sumatoria = 0;

                    for (int y = 0; y < percepciones.Rows.Count; y++)
                    {
                        TextFragment txtOne = new TextFragment(percepciones.Rows[y][0].ToString());
                        txtOne.Position = new Position(50, 365 - (y * 40));
                        txtOne.TextState.FontSize = 12;
                        txtOne.TextState.Font = FontRepository.FindFont("Arial");
                        txtOne.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                        TextFragment txtTwo = new TextFragment(percepciones.Rows[y][1].ToString());
                        txtTwo.Position = new Position(105, 365 - (y * 40));
                        txtTwo.TextState.FontSize = 12;
                        txtTwo.TextState.Font = FontRepository.FindFont("Arial");
                        txtTwo.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                        string p = percepciones.Rows[y][2].ToString();
                        string importe;                       

                        if (p.StartsWith("0."))
                        {
                            float porcentaje = float.Parse(p);

                            sumatoria = sumatoria + (sueldoBruto * porcentaje);

                            p = p.Remove(0, 2);
                            if (p.Length == 1)
                            {
                                importe = "%" + p + "0";
                            }
                            else
                            {
                                importe = "%" + p;
                            }
                        }
                        else
                        {
                            float cantidad = float.Parse(p);

                            sumatoria = sumatoria + cantidad;

                            importe = "$" + p + ".00";
                        }

                        TextFragment txtThree = new TextFragment(importe);
                        txtThree.Position = new Position(185, 365 - (y * 40));
                        txtThree.TextState.FontSize = 12;
                        txtThree.TextState.Font = FontRepository.FindFont("Arial");
                        txtThree.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                        

                        TextBuilder txtBuilds = new TextBuilder(page1);
                        txtBuilds.AppendText(txtOne);
                        txtBuilds.AppendText(txtTwo);
                        txtBuilds.AppendText(txtThree);
                       
                    }

                    TextFragment txtFour = new TextFragment(String.Format("{0:C}", sumatoria));
                    txtFour.Position = new Position(185, 195);
                    txtFour.TextState.FontSize = 12;
                    txtFour.TextState.Font = FontRepository.FindFont("Arial");
                    txtFour.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextBuilder txtBuild = new TextBuilder(page1);
                    txtBuild.AppendText(txtFour);

                }
                if (i == 3)
                {

                    float sumatoria = 0;

                    for (int y = 0; y < deducciones.Rows.Count; y++)
                    {
                        TextFragment txtOne = new TextFragment(deducciones.Rows[y][0].ToString());
                        txtOne.Position = new Position(300, 355 - (y * 40));
                        txtOne.TextState.FontSize = 12;
                        txtOne.TextState.Font = FontRepository.FindFont("Arial");
                        txtOne.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                        TextFragment txtTwo = new TextFragment(deducciones.Rows[y][1].ToString());
                        txtTwo.Position = new Position(385, 355 - (y * 40));
                        txtTwo.TextState.FontSize = 12;
                        txtTwo.TextState.Font = FontRepository.FindFont("Arial");
                        txtTwo.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                        string p = deducciones.Rows[y][2].ToString();
                        string importe;

                        if (p.StartsWith("0."))
                        {
                            float porcentaje = float.Parse(p);

                            sumatoria = sumatoria + (sueldoBruto * porcentaje);

                            p = p.Remove(0, 2);
                            if(p.Length == 1)
                            {
                                importe = "%" + p + "0";
                            }
                            else
                            {
                                importe = "%" + p;
                            }                           
                          
                        }
                        else
                        {
                            float cantidad = float.Parse(p);

                            sumatoria = sumatoria + cantidad;

                            importe = "$" + p + ".00";
                        }

                        TextFragment txtThree = new TextFragment(importe);
                        txtThree.Position = new Position(490, 355 - (y * 40));
                        txtThree.TextState.FontSize = 12;
                        txtThree.TextState.Font = FontRepository.FindFont("Arial");
                        txtThree.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);                      

                        TextBuilder txtBuilds = new TextBuilder(page1);
                        txtBuilds.AppendText(txtOne);
                        txtBuilds.AppendText(txtTwo);
                        txtBuilds.AppendText(txtThree);
                        
                    }

                    TextFragment txtFour = new TextFragment(String.Format("{0:C}", sumatoria));
                    txtFour.Position = new Position(490, 195);
                    txtFour.TextState.FontSize = 12;
                    txtFour.TextState.Font = FontRepository.FindFont("Arial");
                    txtFour.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    TextBuilder txtBuild = new TextBuilder(page1);
                    txtBuild.AppendText(txtFour);

                }
                if (i == 4)
                {
                    //Sueldo Neto
                    TextFragment txtOne = new TextFragment(sN);
                    txtOne.Position = new Position(170, 110);
                    txtOne.TextState.FontSize = 12;
                    txtOne.TextState.Font = FontRepository.FindFont("Arial");
                    txtOne.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);

                    //Sueldo Bruto
                    TextFragment txtFive = new TextFragment(sB);
                    txtFive.Position = new Position(75, 110);
                    txtFive.TextState.FontSize = 12;
                    txtFive.TextState.Font = FontRepository.FindFont("Arial");
                    txtFive.TextState.ForegroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.Black);


                    TextBuilder txtBuild = new TextBuilder(page1);    
                    txtBuild.AppendText(txtFive);

                }
                if (i == 5)
                {
                    //Sueldo Neto
                    TextFragment txtOne = new TextFragment(sN);
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
