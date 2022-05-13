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
    public partial class AÑADIREMPLEADO : Form
    {
        public AÑADIREMPLEADO()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var db = new EnlaceDB();

            db.gestionDomicilios("I", "null", textBox4.Text, textBox7.Text, textBox8.Text, textBox11.Text, textBox3.Text, textBox10.Text);

            var sl = db.gestionDomicilios("M", "null", "null", "null", "null", "null", "null", "null");
            var rw = sl.Rows[0];
            var domicilio = rw[0];

            db.gestionTelefonos("I", "null", textBox1.Text, textBox9.Text, textBox15.Text);

            var sl2 = db.gestionTelefonos("M", "null", "null", "null", "null");
            var rw2 = sl2.Rows[0];
            var telefonos = rw2[0];

            bool ut = true;
            if (radioButton1.Checked)
            {
                ut = true;
            }
            if (radioButton2.Checked)
            {
                ut = false;
            }

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

            string fechaN = "'" + dateTimePicker1.Value.Year.ToString() + mes + dia + "'";

            string tipoU;
            if (ut)
            {
                tipoU = "1";
            }
            else
            {
                tipoU = "0";
            }

            var dp = db.gestionDepartamentos("F", "null", comboBox2.Text, "null", "null");
            var departamento = dp.Rows[0][0];

            var pt = db.gestionPuestos("F", "null", comboBox1.Text, "null", "null");
            var puesto = pt.Rows[0][0];

            db.gestionEmpleados("I", "null", textBox12.Text, textBox5.Text, textBox6.Text, textBox19.Text, textBox13.Text, tipoU, "1", textBox14.Text, telefonos.ToString(), domicilio.ToString(), fechaN, textBox18.Text, textBox17.Text, textBox16.Text, departamento.ToString(), puesto.ToString());

            this.Close();
        }

        private void AÑADIREMPLEADO_Load(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
