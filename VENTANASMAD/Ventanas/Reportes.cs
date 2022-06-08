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
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

            comboBox2.Items.Add("Todos");
            comboBox1.Items.Add("Todos");

            var dptos = db.gestionDepartamentos("X", "null", "null", "null", "null");

            for (int i = 0; dptos.Rows.Count > i; i++)
            {
                comboBox2.Items.Add(dptos.Rows[i][1]);
            }

            var puestos = db.gestionPuestos("X", "null", "null", "null", "null");

            for (int i = 0; puestos.Rows.Count > i; i++)
            {
                comboBox1.Items.Add(puestos.Rows[i][1]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

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

            string fechaI = "'" + dateTimePicker1.Value.Year.ToString() + mes + dia + "'";

            var reportes = db.gestionReportes("G", fechaI, "null", "null", "null");
            dataGridView1.DataSource = reportes;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            var db = new EnlaceDB();

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

            string fechaI = "'" + dateTimePicker1.Value.Year.ToString() + mes + dia + "'";

            if (comboBox1.Text == "")
            {
                if (comboBox2.Text != "")
                {
                    if (comboBox2.Text == "Todos")
                    {
                        var reportes = db.gestionReportes("H", fechaI, "null", "null", "null");
                        dataGridView1.DataSource = reportes;
                    }
                    else
                    {
                        var departamento = db.gestionDepartamentos("F", "null", comboBox2.Text, "null", "null").Rows[0][0].ToString();

                        var reportes = db.gestionReportes("H", fechaI, "0", departamento, "null");
                        dataGridView1.DataSource = reportes;
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione el filtro de los Departamentos");
                }

            }
            else
            {
                if (comboBox2.Text != "")
                {
                    if(comboBox2.Text == "Todos" && comboBox1.Text == "Todos")
                    {
                        var reportes = db.gestionReportes("H", fechaI, "1", "null", "null");
                        dataGridView1.DataSource = reportes;
                    }
                    if (comboBox2.Text == "Todos" && comboBox1.Text != "Todos")
                    {
                        var puesto = db.gestionPuestos("F", "null", comboBox1.Text, "null", "null").Rows[0][0].ToString();

                        var reportes = db.gestionReportes("H", fechaI, "2", "null", puesto);
                        dataGridView1.DataSource = reportes;
                    }
                    if (comboBox2.Text != "Todos" && comboBox1.Text != "Todos")
                    {
                        var puesto = db.gestionPuestos("F", "null", comboBox1.Text, "null", "null").Rows[0][0].ToString();
                        var departamento = db.gestionDepartamentos("F", "null", comboBox2.Text, "null", "null").Rows[0][0].ToString();


                        var reportes = db.gestionReportes("H", fechaI, "3", departamento, puesto);
                        dataGridView1.DataSource = reportes;
                    }

                }
                else
                {
                    MessageBox.Show("Seleccione el filtro de los Departamentos");
                }
            }
        }
    }
}
