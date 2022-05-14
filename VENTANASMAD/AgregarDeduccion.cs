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
    public partial class AgregarDeduccion : Form
    {
        public AgregarDeduccion()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var db = new EnlaceDB();           

            var sl = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            var cantidad = "";

            if (sl == 0)
            {
                MessageBox.Show("Seleccione una deduccion", "Aviso");
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

                string fecha = "'" + dateTimePicker1.Value.Year.ToString() + mes + dia + "'";

                var deduccion = dataGridView1.CurrentCell.Value.ToString();

                var d = db.gestionDeducciones("S", deduccion, "null", "null", "null");

                if(d.Rows[0][1].ToString() == "")
                {
                    cantidad = d.Rows[0][2].ToString();
                }
                if (d.Rows[0][2].ToString() == "")
                {
                    cantidad = "." + d.Rows[0][1].ToString();
                }

                db.gestionListaD("I", "null", db.getEmpleado(), deduccion, fecha, cantidad, "null");

                MessageBox.Show("Deduccion asignada correctamente", "Aviso");

                this.Hide();
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AgregarDeduccion_Load(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

            var deducciones = db.gestionDeducciones("V", "null", "null", "null", "null");
            dataGridView1.DataSource = deducciones;
        }
    }
}
