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

            var query = "EXEC sp_GestionDepartamentos @Op = 'X'";

            var dptos = db.ConsultaTabla(query);

            if (dptos.Rows.Count != 0)
            {
                var query2 = "EXEC sp_GestionPuestos @Op = 'X'";

                var puestos = db.ConsultaTabla(query2);

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
            this.Hide();
            AgregarPercepcion f3 = new AgregarPercepcion();
            f3.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            AgregarDeduccion f3 = new AgregarDeduccion();
            f3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
