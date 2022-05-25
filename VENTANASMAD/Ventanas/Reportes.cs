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

            var reportes = db.gestionReportes("G", fechaI);
            dataGridView1.DataSource = reportes;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
