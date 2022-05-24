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
    public partial class empresa : Form
    {
        public empresa()
        {
            InitializeComponent();
        }

        private void empresa_Load(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

            var empresa = db.gestionEmpresa("T", "null", "null", "null", "null", "null", "null");

            if(empresa.Rows.Count == 0)
            {
                MessageBox.Show("Registre una empresa", "Aviso");

                button1.Text = "Agregar";

            }
            else
            {
                var d = db.gestionDomicilios("S", empresa.Rows[0][4].ToString(), "null", "null", "null", "null", "null", "null");
                var t = db.gestionTelefonos("S", empresa.Rows[0][5].ToString(), "null", "null", "null");
                textBox1.Text = empresa.Rows[0][1].ToString();
                textBox2.Text = empresa.Rows[0][2].ToString();
                textBox3.Text = empresa.Rows[0][0].ToString();
                dateTimePicker1.Text = empresa.Rows[0][3].ToString();
                textBox4.Text = d.Rows[0][1].ToString();
                textBox7.Text = d.Rows[0][2].ToString();
                textBox8.Text = d.Rows[0][3].ToString();
                textBox9.Text = d.Rows[0][5].ToString();
                textBox10.Text = d.Rows[0][6].ToString();
                textBox11.Text = d.Rows[0][4].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

            db.gestionDomicilios("I", "null", textBox4.Text, textBox7.Text, textBox8.Text, textBox11.Text, textBox9.Text, textBox10.Text);

            var sl = db.gestionDomicilios("M", "null", "null", "null", "null", "null", "null", "null");
            var rw = sl.Rows[0];
            var domicilio = rw[0];
           
            db.gestionTelefonos("I", "null", textBox6.Text, "null", "null");
          
            var sl2 = db.gestionTelefonos("M", "null", "null", "null", "null");
            var rw2 = sl2.Rows[0];
            var telefonos = rw2[0];

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

            if(button1.Text == "Agregar")
            {
                db.gestionEmpresa("I", textBox3.Text, textBox1.Text, textBox2.Text, fechaI, domicilio.ToString(), telefonos.ToString());
                MessageBox.Show("Empresa registrada exitosamente", "Aviso");
            }
            else
            {
                db.gestionEmpresa("U", textBox3.Text, textBox1.Text, textBox2.Text, fechaI, domicilio.ToString(), telefonos.ToString());
                MessageBox.Show("Empresa editada exitosamente", "Aviso");
            }

        }
    }
}
