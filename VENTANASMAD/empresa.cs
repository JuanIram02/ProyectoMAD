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

            var query = "EXEC sp_GestionEmpresa @Op = 'I', @";

            var empresa = db.ConsultaTabla(query);
        }
    }
}
