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
    public partial class Empleados : Form
    {
        public Empleados()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            AÑADIREMPLEADO f5 = new AÑADIREMPLEADO();
            f5.ShowDialog();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = DateTime.Today;
            int month = date.Month;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = DateTime.Today;
            int month = date.Month;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            AgregarPercepcion f3 = new AgregarPercepcion();
            f3.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            AgregarDeduccion f3 = new AgregarDeduccion();
            f3.ShowDialog();
        }
    }
}
