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

        private void button3_Click(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

            var dptos = db.gestionDepartamentos("X", "null", "null", "null", "null");

            if (dptos.Rows.Count != 0)
            {
                var puestos = db.gestionPuestos("X", "null", "null", "null", "null");

                if (puestos.Rows.Count != 0)
                {
                    AÑADIREMPLEADO f5 = new AÑADIREMPLEADO();
                    f5.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Antes registe un Puesto", "Aviso");
                }
            }
            else
            {
                MessageBox.Show("Antes registe un Departamento", "Aviso");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

            var sl = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (sl == 0)
            {
                MessageBox.Show("Seleccione un empleado", "Aviso");
            }
            else
            {
                var p = db.gestionPercepciones("T", "null", "null", "null", "null");

                if(p.Rows.Count == 0)
                {
                    MessageBox.Show("Antes registre una percepcion", "Aviso");
                }
                else
                {
                    var empleado = dataGridView1.CurrentCell.Value.ToString();

                    db.setEmpleado(empleado);

                    this.Hide();
                    AgregarPercepcion f3 = new AgregarPercepcion();
                    f3.ShowDialog();
                }     
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

            var sl = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (sl == 0)
            {
                MessageBox.Show("Seleccione un empleado", "Aviso");
            }
            else
            {
                var d = db.gestionDeducciones("T", "null", "null", "null", "null");

                if (d.Rows.Count == 0)
                {
                    MessageBox.Show("Antes registre una deduccion", "Aviso");
                }
                else
                {
                    var empleado = dataGridView1.CurrentCell.Value.ToString();

                    db.setEmpleado(empleado);

                    this.Hide();
                    AgregarDeduccion f3 = new AgregarDeduccion();
                    f3.ShowDialog();
                }
            }         
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

            var empleados = db.gestionEmpleados("V", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null");
            dataGridView1.DataSource = empleados;

        }
    }
}
