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
    public partial class Puesto : Form
    {
        public Puesto()
        {
            InitializeComponent();
        }

        private void Puesto_Load(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

            var puestos = db.gestionPuestos("V", "null", "null", "null", "null");
            dataGridView1.DataSource = puestos;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

            db.gestionPuestos("I", "null", textBox12.Text, textBox6.Text, "1");

            textBox12.Clear();
            textBox6.Clear();
        }
    }
}
