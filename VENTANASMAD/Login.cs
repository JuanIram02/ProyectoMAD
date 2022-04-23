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

            string query = "SELECT * FROM Empleados WHERE NombreU LIKE '" + textBox18.Text + "' AND Contraseña LIKE '" + textBox12.Text + "'";

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
            Registrate f3 = new Registrate();
            f3.ShowDialog();
        }
    }
}
