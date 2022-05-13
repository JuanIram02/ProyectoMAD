using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace VENTANASMAD
{
    public class EnlaceDB
    {

        static private string _Sesion;
        static private string _Empleado;

        static private SqlConnection _conexion;
        static private SqlDataAdapter _adaptador = new SqlDataAdapter();
        static private SqlCommand _comandosql = new SqlCommand();

        public string getSesion()
        {
            return _Sesion;         
        }
        public void setSesion(string sesion)
        {
            _Sesion = sesion;
        }

        public string getEmpleado()
        {
            return _Empleado;
        }
        public void setEmpleado(string empleado)
        {
            _Empleado = empleado;
        }

        private static void conectar()
        {
            //string cnn = ConfigurationManager.AppSettings["desarrollo1"];
            string cnn = ConfigurationManager.ConnectionStrings["SQL_Auth"].ToString();
            _conexion = new SqlConnection(cnn);
            _conexion.Open();
        }

        private static void desconectar()
        {
            _conexion.Close();
        }      
        public DataTable ConsultaTabla(string SP)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = SP;
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.Text;
                _comandosql.CommandTimeout = 1200;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable gestionDeducciones(string Op, string IDDeduccion, string Porcentaje, string Cantidad, string Descripcion)
        {

            string qry = "EXEC sp_GestionDeducciones @Op = '" + Op + "', @IDDeduccion = " + IDDeduccion + ", @Porcentaje = " + Porcentaje + ", @Cantidad = " + Cantidad + ", @Descripcion = '" + Descripcion + "'";
            
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.Text;
                _comandosql.CommandTimeout = 1200;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                var msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable gestionPercepciones(string Op, string IDPercepcion, string Porcentaje, string Cantidad, string Descripcion)
        {

            string qry = "EXEC sp_GestionPercepciones @Op = '" + Op + "', @IDPercepcion = " + IDPercepcion + ", @Porcentaje = " + Porcentaje + ", @Cantidad = " + Cantidad + ", @Descripcion = '" + Descripcion + "'";

            DataTable tabla = new DataTable();

            try
            {
                conectar();
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.Text;
                _comandosql.CommandTimeout = 1200;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                var msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable gestionEmpresa(string Op, string RFC, string RazonSocial, string RegistroPatronal, string Fecha_Inicio, string Domicilio, string Telefono)
        {

            string qry = "EXEC sp_GestionEmpresa @Op = '" + Op + "', @RFC = '" + RFC + "', @RazonSocial = '" + RazonSocial + "', @RegistroPatronal = '" + RegistroPatronal + "', @Fecha_Inicio = " + Fecha_Inicio + ", @Domicilio = " + Domicilio + ", @Telefono = " + Telefono + "";

            DataTable tabla = new DataTable();

            try
            {
                conectar();
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.Text;
                _comandosql.CommandTimeout = 1200;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                var msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable gestionTelefonos(string Op, string IDTelefonos, string Telefono1, string Telefono2, string Telefono3)
        {

            string qry = "EXEC sp_GestionTelefonos @Op = '" + Op + "', @IDTelefonos = " + IDTelefonos + ", @Telefono1 = '" + Telefono1 + "', @Telefono2 = '" + Telefono2 + "', @Telefono3 = '" + Telefono3 + "'";

            DataTable tabla = new DataTable();

            try
            {
                conectar();
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.Text;
                _comandosql.CommandTimeout = 1200;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                var msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable gestionDomicilios(string Op, string IDDomicilio, string Calle, string Numero, string Apartamento, string CodigoPostal, string Ciudad, string Pais)
        {

            string qry = "EXEC sp_GestionDomicilios @Op = '" + Op + "', @IDDomicilio = " + IDDomicilio + ", @Calle = '" + Calle + "', @Numero = '" + Numero + "', @Apartamento = '" + Apartamento + "', @CodigoPostal = '" + CodigoPostal + "', @Ciudad = '" + Ciudad + "', @Pais = '" + Pais + "'";

            DataTable tabla = new DataTable();

            try
            {
                conectar();
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.Text;
                _comandosql.CommandTimeout = 1200;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                var msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable gestionEmpleados(string Op, string NumeroEmpleado, string CURP, string NSS, string RFC, string NombreU, string Contraseña, string TipoUsuario, string Estatus, string Email, string Telefono, string Domicilio, string FechaNacimiento, string Nombres, string ApPaterno, string ApMaterno, string Departamento, string Puesto)
        {
           
            string qry = "EXEC sp_GestionEmpleados @Op = '" + Op + "', @NumeroEmpleado = " + NumeroEmpleado + ", @CURP = '" + CURP + "', @NSS = '" + NSS + "', @RFC = '" + RFC + "', @NombreU = '" + NombreU + "', @Contraseña = '" + Contraseña + "', @TipoUsuario = " + TipoUsuario + ", @Estatus = " + Estatus + ", @Email = '" + Email + "', @Telefono = " + Telefono + ", @Domicilio = " + Domicilio + ", @FechaNacimiento = " + FechaNacimiento + ", @Nombres = '" + Nombres + "', @ApPaterno = '" + ApPaterno + "', @ApMaterno = '" + ApMaterno + "', @Departamento = " + Departamento + ", @Puesto = " + Puesto + "";

            DataTable tabla = new DataTable();

            try
            {
                conectar();
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.Text;
                _comandosql.CommandTimeout = 1200;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                var msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable gestionDepartamentos(string Op, string IDDepartamento, string Nombre, string SueldoBase, string Estatus)
        {

            string qry = "EXEC sp_GestionDepartamentos @Op = '" + Op + "', @IDDepartamento = " + IDDepartamento + ", @Nombre = '" + Nombre + "', @SueldoBase = " + SueldoBase + ", @Estatus = " + Estatus + "";

            DataTable tabla = new DataTable();

            try
            {
                conectar();
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.Text;
                _comandosql.CommandTimeout = 1200;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                var msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable gestionPuestos(string Op, string IDPuesto, string Nombre, string NivelSalarial, string Estatus)
        {

            string qry = "EXEC sp_GestionPuestos @Op = '" + Op + "', @IDPuesto = " + IDPuesto + ", @Nombre = '" + Nombre + "', @NivelSalarial = " + NivelSalarial + ", @Estatus = " + Estatus + "";

            DataTable tabla = new DataTable();

            try
            {
                conectar();
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.Text;
                _comandosql.CommandTimeout = 1200;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                var msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

    }
}
