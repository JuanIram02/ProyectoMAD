﻿using System;
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

        private void button1_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                var v = new Validaciones();

                if (v.vacio(textBox18.Text) & v.vacio(textBox17.Text) & v.vacio(textBox16.Text) & v.vacio(textBox4.Text) & v.vacio(textBox5.Text) & v.vacio(textBox7.Text) & v.vacio(textBox8.Text) & v.vacio(textBox3.Text) & v.vacio(textBox10.Text) & v.vacio(textBox11.Text) & v.vacio(comboBox1.Text) & v.vacio(comboBox2.Text) & v.vacio(comboBox3.Text) & v.vacio(textBox2.Text) & v.vacio(textBox13.Text))
                {
                    if (v.nombre(textBox19.Text)) 
                    if (v.telefono(textBox1.Text, true) & v.telefono(textBox9.Text, v.vacio(textBox9.Text)) & v.telefono(textBox15.Text, v.vacio(textBox15.Text)))
                    if (v.CURP(textBox12.Text, false))
                    if (v.RFC(textBox6.Text, false))
                    if (v.email(textBox14.Text))
                    {
                        var db = new EnlaceDB();

                        db.gestionDomicilios("I", "null", textBox4.Text, textBox7.Text, textBox8.Text, textBox11.Text, textBox3.Text, textBox10.Text);

                        var sl = db.gestionDomicilios("M", "null", "null", "null", "null", "null", "null", "null");
                        var rw = sl.Rows[0];
                        var domicilio = rw[0];

                        db.gestionTelefonos("I", "null", textBox1.Text, textBox9.Text, textBox15.Text);

                        var sl2 = db.gestionTelefonos("M", "null", "null", "null", "null");
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
                        if (dateTimePicker1.Value.Day < 10)
                        {
                            dia = "0" + dateTimePicker1.Value.Day.ToString();
                        }
                        else
                        {
                            dia = dateTimePicker1.Value.Day.ToString();
                        }

                        string fechaN = "'" + dateTimePicker1.Value.Year.ToString() + mes + dia + "'";

                        string tipoU;
                        if (ut)
                        {
                            tipoU = "1";
                        }
                        else
                        {
                            tipoU = "0";
                        }

                        var dp = db.gestionDepartamentos("F", "null", comboBox2.Text, "null", "null");
                        var departamento = dp.Rows[0][0];

                        var pt = db.gestionPuestos("F", "null", comboBox1.Text, "null", "null");
                        var puesto = pt.Rows[0][0];

                        db.gestionEmpleados("I", "null", textBox12.Text, textBox5.Text, textBox6.Text, textBox19.Text, textBox13.Text, tipoU, "1", textBox14.Text, telefonos.ToString(), domicilio.ToString(), fechaN, textBox18.Text, textBox17.Text, textBox16.Text, departamento.ToString(), puesto.ToString());

                        MessageBox.Show("Empleado registrado exitosamente", "Aviso");

                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Llene todos los campos");
                }
                    
            }
            else
            {
                var db = new EnlaceDB();

                db.gestionDomicilios("I", "null", textBox4.Text, textBox7.Text, textBox8.Text, textBox11.Text, textBox3.Text, textBox10.Text);

                var sl = db.gestionDomicilios("M", "null", "null", "null", "null", "null", "null", "null");
                var rw = sl.Rows[0];
                var domicilio = rw[0];

                db.gestionTelefonos("I", "null", textBox1.Text, textBox9.Text, textBox15.Text);

                var sl2 = db.gestionTelefonos("M", "null", "null", "null", "null");
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
                if (dateTimePicker1.Value.Day < 10)
                {
                    dia = "0" + dateTimePicker1.Value.Day.ToString();
                }
                else
                {
                    dia = dateTimePicker1.Value.Day.ToString();
                }

                string fechaN = "'" + dateTimePicker1.Value.Year.ToString() + mes + dia + "'";

                string tipoU;
                if (ut)
                {
                    tipoU = "1";
                }
                else
                {
                    tipoU = "0";
                }

                var dp = db.gestionDepartamentos("F", "null", comboBox2.Text, "null", "null");
                var departamento = dp.Rows[0][0];

                var pt = db.gestionPuestos("F", "null", comboBox1.Text, "null", "null");
                var puesto = pt.Rows[0][0];

                db.gestionEmpleados("I", "null", textBox12.Text, textBox5.Text, textBox6.Text, textBox19.Text, textBox13.Text, tipoU, "1", textBox14.Text, telefonos.ToString(), domicilio.ToString(), fechaN, textBox18.Text, textBox17.Text, textBox16.Text, departamento.ToString(), puesto.ToString());

                MessageBox.Show("Empleado registrado exitosamente", "Aviso");

                this.Close();
            }
                                         
        }

        private void AÑADIREMPLEADO_Load(object sender, EventArgs e)
        {
            var db = new EnlaceDB();

            var dptos = db.gestionDepartamentos("X", "null", "null", "null", "null");

            for (int i = 0; dptos.Rows.Count > i; i++)
            {
                comboBox2.Items.Add(dptos.Rows[i][1]);
            }

            var puestos = db.gestionPuestos("X", "null", "null", "null", "null");

            for (int i = 0; puestos.Rows.Count > i; i++)
            {
                comboBox1.Items.Add(puestos.Rows[i][1]);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
