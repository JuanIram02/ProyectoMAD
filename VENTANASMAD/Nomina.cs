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

            var empresa = db.gestionEmpresa("T", "null", "null", "null", "null", "null", "null");

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

                string fecha = "'" + dateTimePicker1.Value.Year.ToString() + mes + dia + "'";

                string RFCEmpresa = empresa.Rows[0][0].ToString();

                var nominados = db.gestionEmpleados("G", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", fecha, "null", "null", "null", "null", "null");

                for (int i = 0; i < nominados.Rows.Count; i++)
                {
                    int s = Int32.Parse(db.gestionDepartamentos("S", nominados.Rows[i][16].ToString(), "null", "null", "null").Rows[0][2].ToString());
                    int n = Int32.Parse(db.gestionPuestos("S", nominados.Rows[i][17].ToString(), "null", "null", "null").Rows[0][2].ToString());

                    float NivelSalarial = n;
                    float SueldoBase = s;

                    float sueldoBruto = (monthDays * SueldoBase * NivelSalarial / 100);                    

                    db.gestionNominas("I", "null", "abril", nominados.Rows[i][0].ToString(), nominados.Rows[i][16].ToString(), nominados.Rows[i][17].ToString(), RFCEmpresa, fecha, sueldoBruto.ToString(), "null");
                }
            }
        }
    }
}
