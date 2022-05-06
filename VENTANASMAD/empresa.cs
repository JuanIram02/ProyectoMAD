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
    public partial class empresa : Form
    {
        public empresa()
        {
            InitializeComponent();
        }

        private void empresa_Load(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

            var query = "EXEC sp_GestionEmpresa @Op = 'T'";

            var empresa = db.ConsultaTabla(query);

            if(empresa.Rows.Count == 0)
            {
                MessageBox.Show("Registre una empresa", "Aviso");

                button1.Text = "Agregar";

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

            var query1 = "EXEC sp_GestionDomicilios @Op = 'I', @Calle = '" + textBox4.Text + "', @Numero = '" + textBox7.Text + "', @Apartamento = '" + textBox8.Text + "', @CodigoPostal = '" + textBox11.Text + "', @Ciudad = '" + textBox9.Text + "', @Pais = '" + textBox10.Text + "'";

            //db.ConsultaTabla(query1);

            var query2 = "SELECT MAX(IDDomicilio) FROM Domicilios";
            var sl = db.ConsultaTabla(query2);
            var rw = sl.Rows[0];
            var domicilio = rw[0];

            var query3 = "EXEC sp_GestionTelefonos @Op = 'I', @Telefono1 = '" + textBox6.Text + "'";

            //db.ConsultaTabla(query3);

            var query4 = "SELECT MAX(IDTelefonos) FROM Telefonos";
            var sl2 = db.ConsultaTabla(query4);
            var rw2 = sl2.Rows[0];
            var telefonos = rw2[0];

            string mes;
            if (dateTimePicker1.Value.Month < 10)
            {
                mes = "0" + dateTimePicker1.Value.Month.ToString();
            }
            else
            {
                mes = dateTimePicker1.Value.Month.ToString();
            }

            string dia;
            if (dateTimePicker1.Value.Month < 10)
            {
                dia = "0" + dateTimePicker1.Value.Day.ToString();
            }
            else
            {
                dia = dateTimePicker1.Value.Day.ToString();
            }

            string fechaI = dateTimePicker1.Value.Year.ToString() + mes + dia;

            string query5;

            if(button1.Text == "Agregar")
            {
                query5 = "EXEC sp_GestionEmpresa @Op = 'I', @RFC = '" + textBox3.Text + "', @RazonSocial = '" + textBox1.Text + "', @RegistroPatronal = '" + textBox2.Text + "', @Fecha_Inicio = '" + fechaI + "', @Domicilio = " + domicilio + ", @Telefono = " + telefonos + ");";
            }
            else
            {
                query5 = "EXEC sp_GestionEmpresa @Op = 'U', @RFC = '" + textBox3.Text + "', @RazonSocial = '" + textBox1.Text + "', @RegistroPatronal = '" + textBox2.Text + "', @Fecha_Inicio = '" + fechaI + "', @Domicilio = " + domicilio + ", @Telefono = " + telefonos + ");";
            }

            db.ConsultaTabla(query5);

        }
    }
}
