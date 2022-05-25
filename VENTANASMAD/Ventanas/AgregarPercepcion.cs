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
    public partial class AgregarPercepcion : Form
    {
        public AgregarPercepcion()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            {
                var db = new EnlaceDB();

                var sl = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
                var cantidad = "";

                if (sl == 0)
                {
                    MessageBox.Show("Seleccione una percepcion", "Aviso");
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

                    var percepcion = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                    var p = db.gestionPercepciones("S", percepcion, "null", "null", "null");

                    if (p.Rows[0][1].ToString() == "")
                    {
                        cantidad = p.Rows[0][2].ToString();
                    }
                    if (p.Rows[0][2].ToString() == "")
                    {
                        cantidad = "." + p.Rows[0][1].ToString();
                    }

                    db.gestionListaP("I", "null", db.getEmpleado(), percepcion, fecha, "null", cantidad, "null");

                    MessageBox.Show("Percepcion asignada correctamente", "Aviso");

                    this.Hide();
                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void AgregarPercepcion_Load(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

            var percepciones = db.gestionPercepciones("V", "null", "null", "null", "null");
            dataGridView1.DataSource = percepciones;
        }
    }
}
