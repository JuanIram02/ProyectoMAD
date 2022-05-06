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

            string query = "EXEC sp_GestionEmpleados @Op = 'N', @NombreU = '" + textBox18.Text +  "', @Contraseña = '" + textBox12.Text + "';";

            var usuario = db.ConsultaTabla(query);

            if(usuario.Rows.Count == 0)
            {
                MessageBox.Show("Contraseña o Usuario incorrecto", "Error");
            }
            else
            {
                this.Hide();
                Form1 f2 = new Form1();
                f2.ShowDialog();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            var db = new EnlaceDB();

            var query = "EXEC sp_GestionDepartamentos @Op = 'X'";

            var dptos = db.ConsultaTabla(query);

            if (dptos.Rows.Count != 0)
            {
                var query2 = "EXEC sp_GestionPuestos @Op = 'X'";

                var puestos = db.ConsultaTabla(query2);

                if (puestos.Rows.Count != 0)
                {
                    AÑADIREMPLEADO f3 = new AÑADIREMPLEADO();
                    f3.ShowDialog();
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
    }
}
