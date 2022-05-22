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

    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
    

            var db = new EnlaceDB();

            var usuario = db.gestionEmpleados("N", "null", "null", "null", "null", textBox18.Text, textBox12.Text, "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null");

            if(usuario.Rows.Count == 0)
            {
                MessageBox.Show("Contraseña o Usuario incorrecto", "Error");
            }
            else
            {
                db.setSesion(usuario.Rows[0][0].ToString());

                this.Hide();
                Form1 f2 = new Form1();
                f2.ShowDialog();

            }

        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            var PDF = new PDF();
            string ola = "ola";
            PDF.generaPDF(ola);

        }
    }
}
