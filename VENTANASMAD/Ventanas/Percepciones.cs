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
    public partial class Percepciones : Form
    {
        public Percepciones()
        {
            InitializeComponent();
        }

        private void Percepciones_Load(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

            var sl = db.gestionPercepciones("M", "null", "null", "null", "null");
            var rw = sl.Rows[0];
            var id = rw[0].ToString();

            if (id == "")
            {
                textBox12.Text = "1";
            }
            else
            {
                textBox12.Text = (Int32.Parse(id) + 1).ToString();
            }

            var deducciones = db.gestionPercepciones("V", "null", "null", "null", "null");
            dataGridView1.DataSource = deducciones;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

            int cp = 3;

            if (radioButton1.Checked)
            {
                cp = 1;

            }
            if (radioButton2.Checked)
            {
                cp = 0;
            }

            if (cp == 3)
            {
                MessageBox.Show("Seleccione un tipo de Deduccion", "Aviso");
            }
            else
            {
                if (cp == 1)
                {
                    db.gestionPercepciones("I", "null", "null", textBox6.Text, textBox17.Text);
                }
                else
                {
                    db.gestionPercepciones("I", "null", textBox6.Text, "null", textBox17.Text);
                }

                var sl = db.gestionPercepciones("M", "null", "null", "null", "null");
                var rw = sl.Rows[0];
                var id = rw[0].ToString();

                if (id == "")
                {
                    textBox12.Text = "1";
                }
                else
                {
                    textBox12.Text = (Int32.Parse(id) + 1).ToString();
                }

                textBox6.Clear();
                textBox17.Clear();

            }

            var percepciones = db.gestionPercepciones("V", "null", "null", "null", "null");
            dataGridView1.DataSource = percepciones;

        }
    }
}
