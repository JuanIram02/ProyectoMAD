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
            if(textBox1.Text == "")
            {
                MessageBox.Show("Ingrese un nombre para el departamento");
            }
            else
            {
                var db = new EnlaceDB();

                db.gestionDepartamentos("I", "null", textBox1.Text, numericUpDown1.Value.ToString(), "1");

                textBox1.Clear();
                numericUpDown1.Value = 0;

                var departamentos = db.gestionDepartamentos("V", "null", "null", "null", "null");
                dataGridView1.DataSource = departamentos;
            }          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

            var id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

            DialogResult sn = MessageBox.Show("Seguro de que desea eliminar el puesto numero " + id + "?", "Aviso", MessageBoxButtons.YesNo);
            if (sn == DialogResult.Yes)
            {
                db.gestionDepartamentos("B", id, "null", "null", "null");

                var departamentos = db.gestionDepartamentos("V", "null", "null", "null", "null");
                dataGridView1.DataSource = departamentos;
            }
        }
    }
}
