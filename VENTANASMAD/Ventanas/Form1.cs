using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace VENTANASMAD
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }


        private void btnCerrar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true; 
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new empresa());
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void AbrirFormHija(object formhija)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
                this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();

        }

        private void btninicio_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Inicio());
        }

        private void btnDepartamentos_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new departamentos());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Empleados());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Nomina());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Puesto());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Percepciones());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AbrirFormHija(new Deducciones());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AbrirFormHija(new Reportes());
        }
    }
}
