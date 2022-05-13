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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

            var num = db.getSesion();

            var empleado = db.gestionEmpleados("S", num, "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null");
            var departamento = db.gestionPuestos("S", empleado.Rows[0][16].ToString(), "null", "null", "null");
            var puesto = db.gestionPuestos("S", empleado.Rows[0][17].ToString(), "null", "null", "null");

            textBox1.Text = empleado.Rows[0][13].ToString() + " " + empleado.Rows[0][14].ToString() + " " + empleado.Rows[0][15].ToString();
            textBox2.Text = departamento.Rows[0][1].ToString();
            textBox3.Text = puesto.Rows[0][1].ToString();
            textBox4.Text = empleado.Rows[0][8].ToString();
        }
    }
}
