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
    public partial class AÑADIREMPLEADO : Form
    {
        public AÑADIREMPLEADO()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            var db = new EnlaceDB();

            var query1 = "EXEC sp_GestionDomicilios @Op = 'I', @Calle = '" + textBox4.Text + "', @Numero = '" + textBox7.Text + "', @Apartamento = '" + textBox8.Text + "', @CodigoPostal = '" + textBox11.Text + "', @Ciudad = '" + textBox3.Text + "', @Pais = '" + textBox10.Text + "'";
            
            //db.ConsultaTabla(query1);

            var query2 = "SELECT MAX(IDDomicilio) FROM Domicilios";
            var sl = db.ConsultaTabla(query2);
            var rw = sl.Rows[0];
            var domicilio = rw[0];

            var query3 = "EXEC sp_GestionTelefonos @Op = 'I', @Telefono1 = '" + textBox1.Text + "', @Telefono2 = '" + textBox9.Text + "', @Telefono3 = '" + textBox15.Text + "'";

            //db.ConsultaTabla(query3);

            var query4 = "SELECT MAX(IDTelefonos) FROM Telefonos";
            var sl2 = db.ConsultaTabla(query4);
            var rw2 = sl2.Rows[0];
            var telefonos = rw2[0];

            bool ut = true;
            if (radioButton1.Checked)
            {
                ut = true;
            }
            if (radioButton2.Checked)
            {
                ut = false;
            }

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

            string fechaN = dateTimePicker1.Value.Year.ToString() + mes + dia;

            string tipoU;
            if (ut)
            {
                tipoU = "1";
            }
            else
            {
                tipoU = "0";
            }
            
            var query5 = "EXEC sp_GestionEmpleados @Op = 'I', @CURP = '" + textBox12.Text + "', @NSS = '" + textBox5.Text + "' , @RFC = '" + textBox6.Text + "' , @NombreU = '" + textBox19.Text + "', @Contraseña = '" + textBox13.Text + "', @TipoUsuario = '" + tipoU + "', @Estatus = '1', @Email = '" + textBox14.Text + "', @Telefono = " + telefonos.ToString() + ", @Domicilio = " + domicilio.ToString() + ", @FechaNacimiento = '" + fechaN + "', @Nombres = '" + textBox18.Text + "', @ApPaterno = '" + textBox17.Text + "', @ApMaterno = '" + textBox16.Text + "', @Departamento = " + comboBox2.Text + ", @Puesto = " + comboBox1.Text + ";";

            //db.ConsultaTabla(query5);

            this.Close();
        }
    }
}
