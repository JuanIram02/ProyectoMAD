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
                    var empleado = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                    db.setEmpleado(empleado);
                   
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
                    var empleado = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                    db.setEmpleado(empleado);
                   
                    AgregarDeduccion f3 = new AgregarDeduccion();
                    f3.ShowDialog();
                }
            }         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

            if (radioButton1.Checked)
            {
                var empleados = db.gestionEmpleados("Y", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", textBox17.Text, "null", "null", "null", "null");
                dataGridView1.DataSource = empleados;
            }
            else if (radioButton2.Checked)
            {
                if(textBox18.Text != "")
                {
                    var empleados = db.gestionEmpleados("W", textBox18.Text, "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null");
                    dataGridView1.DataSource = empleados;
                }
                else
                {
                    MessageBox.Show("Ingrese un numero de empleado");
                }
                
            }
            else
            {
                MessageBox.Show("Seleccione un metodo de busqueda");
            }
        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

            var empleados = db.gestionEmpleados("V", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null");
            dataGridView1.DataSource = empleados;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

            var id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

            db.gestionEmpleados("B", id, "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null");

            var empleados = db.gestionEmpleados("V", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null");
            dataGridView1.DataSource = empleados;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sl = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (sl == 0)
            {
                MessageBox.Show("Seleccione un empleado", "Aviso");
            }
            else
            {
                var db = new EnlaceDB();

                var empleado = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                db.setEmpleado(empleado);

                this.Hide();
                EDITAREMPLEADO f5 = new EDITAREMPLEADO();
                f5.ShowDialog();
            }
        }

    }
}
