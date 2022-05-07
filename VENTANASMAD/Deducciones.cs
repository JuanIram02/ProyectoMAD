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
    public partial class Deducciones : Form
    {
        public Deducciones()
        {
            InitializeComponent();
        }

        private void Deducciones_Load(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

            var query = "SELECT MAX(IDDeduccion) FROM Deducciones";
            var sl = db.ConsultaTabla(query);
            var rw = sl.Rows[0];
            var id = rw[0].ToString();
            
            if(id == "")
            {
                textBox12.Text = "0";
            }
            else
            {
                textBox12.Text = (Int32.Parse(id) + 1).ToString();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

            string query = "";

            int cp = 3;
            
            if (radioButton1.Checked)
            {
                cp = 1;
                
            }
            if (radioButton2.Checked)
            {
                cp = 0;
            }        

            if(cp == 3)
            {
                MessageBox.Show("Seleccione un tipo de Deduccion", "Aviso");
            }
            else
            {
                if(cp == 1)
                {
                    query = "EXEC sp_GestionDeducciones @Op = 'I', @Cantidad = " + textBox6.Text + ", @Descripcion = '" + textBox17.Text + "';";
                }
                else
                {
                    query = "EXEC sp_GestionDeducciones @Op = 'I', @Porcentaje = " + textBox6.Text + ", @Descripcion = '" + textBox17.Text + "';";
                }

                db.ConsultaTabla(query);

                var query2 = "SELECT MAX(IDDeduccion) FROM Deducciones";
                var sl = db.ConsultaTabla(query2);
                var rw = sl.Rows[0];
                var id = rw[0].ToString();

                if (id == "")
                {
                    textBox12.Text = "0";
                }
                else
                {
                    textBox12.Text = (Int32.Parse(id) + 1).ToString();
                }

            }

            
            
        }
    }
}
