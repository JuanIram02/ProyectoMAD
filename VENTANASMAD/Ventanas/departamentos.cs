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
    public partial class departamentos : Form
    {
        public departamentos()
        {
            InitializeComponent();
        }

        private void departamentos_Load(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

            var departamentos = db.gestionDepartamentos("V", "null", "null", "null", "null");
            dataGridView1.DataSource = departamentos;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

            db.gestionDepartamentos("I", "null", textBox1.Text, numericUpDown1.Value.ToString(), "1");

            textBox1.Clear();
            numericUpDown1.Value = 0;

            var departamentos = db.gestionDepartamentos("V", "null", "null", "null", "null");
            dataGridView1.DataSource = departamentos;
        }
    }
}
