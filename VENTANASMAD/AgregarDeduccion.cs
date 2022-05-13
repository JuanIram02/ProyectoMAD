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
            Form1 f7 = new Form1();
            f7.ShowDialog();
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
