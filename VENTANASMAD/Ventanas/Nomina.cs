using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VENTANASMAD
{
    public partial class Nomina : Form
    {
        public Nomina()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

            var empresa = db.gestionEmpresa("T", "null", "null", "null", "null", "null", "null", "null");

            if (empresa.Rows.Count == 0)
            {
                MessageBox.Show("Registre una emrpesa antes de generar las nominas", "Aviso");
            }
            else
            {
                string mes;
                if (dateTimePicker1.Value.Month < 10)
                {
                    mes = "0" + dateTimePicker1.Value.Month.ToString();
                }
                else
                {
                    mes = dateTimePicker1.Value.Month.ToString();
                }

                string dia;
                if (dateTimePicker1.Value.Day < 10)
                {
                    dia = "0" + dateTimePicker1.Value.Day.ToString();
                }
                else
                {
                    dia = dateTimePicker1.Value.Day.ToString();
                }

                int monthDays = DateTime.DaysInMonth(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month);

                string numDias;
                if (monthDays < 10)
                {
                    numDias = "0" + monthDays.ToString();
                }
                else
                {
                    numDias = monthDays.ToString();
                }


                string fechaNomina = "'" + dateTimePicker1.Value.Year.ToString() + mes + dia + "'";
                string fecha = "'" + dateTimePicker1.Value.Year.ToString() + mes + "01'";
                string fechaAux = "'" + dateTimePicker1.Value.Year.ToString() + mes + numDias + "'";

                string RFCEmpresa = empresa.Rows[0][0].ToString();

                var nominados = db.gestionEmpleados("G", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", fechaNomina, "null", "null", "null", "null", "null");

                var numNominas = nominados.Rows.Count;

                for (int i = 0; i < nominados.Rows.Count; i++)
                {                  
                    float NivelSalarial = float.Parse(db.gestionDepartamentos("S", nominados.Rows[i][16].ToString(), "null", "null", "null").Rows[0][2].ToString());
                    float SueldoBase = float.Parse(db.gestionPuestos("S", nominados.Rows[i][17].ToString(), "null", "null", "null").Rows[0][2].ToString());

                    float sueldoBruto = monthDays * SueldoBase * NivelSalarial / 100;

                    float ISR = sueldoBruto * (30 / 100);

                    var deducciones = db.gestionListaD("F", "null", nominados.Rows[i][0].ToString(), "null", fecha, fechaAux, "null", "null");
                    var percepciones = db.gestionListaP("F", "null", nominados.Rows[i][0].ToString(), "null", fecha, fechaAux, "null", "null");

                    float sumatoria = 0;

                    for(int y = 0; y < deducciones.Rows.Count; y++)
                    {
                        string p = deducciones.Rows[y][4].ToString();

                        if (p.StartsWith("0."))
                        {
                            
                            float porcentaje = float.Parse(p);

                            sumatoria = sumatoria - (sueldoBruto * porcentaje);

                        }
                        else
                        {
                            float cantidad = float.Parse(p);

                            sumatoria = sumatoria - cantidad;
                        }                     
                    }

                    for (int y = 0; y < percepciones.Rows.Count; y++)
                    {
                        string p = percepciones.Rows[y][4].ToString();

                        if (p.StartsWith("."))
                        {

                            float porcentaje = float.Parse(p);

                            sumatoria = sumatoria + (sueldoBruto * porcentaje);

                        }
                        else
                        {
                            float cantidad = float.Parse(p);

                            sumatoria = sumatoria + cantidad;
                        }
                    }

                    float sueldoNeto = sueldoBruto + sumatoria - ISR - 350;

                    db.gestionNominas("I", "null", "abril", nominados.Rows[i][0].ToString(), nominados.Rows[i][16].ToString(), nominados.Rows[i][17].ToString(), RFCEmpresa, fechaNomina, sueldoBruto.ToString(), sueldoNeto.ToString());

                    /*          TRIGGER INSERT NOMINA                           
                    var nomina = db.gestionNominas("M", "null", "null", "null", "null", "null", "null", "null", "null", "null").Rows[0][0].ToString();
                             
                    for (int y = 0; y < deducciones.Rows.Count; y++)
                    {
                        db.gestionListaD("U", deducciones.Rows[y][0].ToString(), "null", "null", "null", "null", "null", nomina);
                    }

                    for (int y = 0; y < percepciones.Rows.Count; y++)
                    {
                        db.gestionListaD("U", deducciones.Rows[y][0].ToString(), "null", "null", "null", "null", "null", nomina);
                    }
                    */
                   
                }

                MessageBox.Show(numNominas +  " Nominas registradas", "Aviso");

                var nominas = db.gestionNominas("V", "null", "null", "null", "null", "null", "null", "null", "null", "null");
                dataGridView1.DataSource = nominas;
            }
        }

        private void Nomina_Load(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

            var nominas = db.gestionNominas("V", "null", "null", "null", "null", "null", "null", "null", "null", "null");
            dataGridView1.DataSource = nominas;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var sl = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (sl == 0)
            {
                MessageBox.Show("Seleccione una Nomina", "Aviso");
            }
            else
            {
                var PDF = new PDF();

                var nomina = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                PDF.generaPDF(nomina);

                MessageBox.Show("Recibo generado exitosamente", "Aviso");
            }
        }
    }
}
