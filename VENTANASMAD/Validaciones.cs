using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VENTANASMAD
{
    class Validaciones
    {
        public bool nombre(string tb)
        {
            if (tb != "")
            {
                var db = new EnlaceDB();

                var usuarios = db.gestionEmpleados("M", "null", "null", "null", "null", tb, "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null");

                if (usuarios.Rows.Count != 0)
                {
                    MessageBox.Show("Nombre de usuario ya existente");
                    return false;
                }                
            }
            else
            {
                MessageBox.Show("Ingrese un nombre de usuario");
                return false;
            }

            return true;
        }

        public bool vacio(string tb)
        {
            if (tb == "")
            {              
                return false;
            }

            return true;
        }

        public bool email(string email)
        {
            if (email == "")
            {
                MessageBox.Show("Ingrese un email valido");

                return false;
            }
            if (new EmailAddressAttribute().IsValid(email))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Ingrese un email valido");
                return false;
            }
        }

        public bool telefono(string tb, bool n)
        {
            if (n)
            {
                var regex = new Regex("^[0-9]{10}$");

                if (!regex.IsMatch(tb))
                {
                    MessageBox.Show("Ingrese un numero de telefono valido");
                    return false;
                }
            }            
                    
            return true;
        }

        private bool CurpValida(string curp)
        {
            var re = @"^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$";
            Regex rx = new Regex(re, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var validado = rx.IsMatch(curp);

            if (!validado || !curp.EndsWith(DigitoVerificadorC(curp.ToUpper())))  //Coincide con el formato general?
            {
                return false;
            }

            return true; //Validado
        }
        private string DigitoVerificadorC(string curp17)
        {
            //Fuente https://consultas.curp.gob.mx/CurpSP/
            var diccionario = "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
            var suma = 0.0;
            var digito = 0.0;
            for (var i = 0; i < 17; i++)
                suma = suma + diccionario.IndexOf(curp17[i]) * (18 - i);
            digito = 10 - suma % 10;
            if (digito == 10) return "0";
            return digito.ToString();
        }
        private bool RfcValida(string rfc)
        {
            var re = @"^([A-Z\s]{4})\d{6}([A-Z\w]{3})$";
            Regex rx = new Regex(re, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var validado = rx.IsMatch(rfc);

            if (!validado)  //Coincide con el formato general?
            {
                return false;
            }

            return true; //Validado
        }
        
        public bool CURP(string tb, bool repite)
        {
            if (CurpValida(tb))
            {
                if (!repite)
                {
                    var db = new EnlaceDB();

                    var usuarios = db.gestionEmpleados("L", "null", tb, "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null");

                    if (usuarios.Rows.Count != 0)
                    {
                        MessageBox.Show("CURP invalido, ya esta en uso");
                        return false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Ingrese un CURP valido");
                return false;
            }
            return true;
        }

        public bool RFC(string tb, bool repite)
        {
            if (RfcValida(tb))
            {
                if (!repite)
                {
                    var db = new EnlaceDB();

                    var usuarios = db.gestionEmpleados("P", "null", "null", "null", tb, "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null", "null");

                    if (usuarios.Rows.Count != 0)
                    {
                        MessageBox.Show("RFC invalido, ya esta en uso");
                        return false;
                    }
                }               
            }
            else
            {
                MessageBox.Show("Ingrese un RFC valido");
                return false;
            }
            return true;
        }

    }
}
