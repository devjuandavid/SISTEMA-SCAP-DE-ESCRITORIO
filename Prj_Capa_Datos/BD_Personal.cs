using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Prj_Capa_Entidad;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Prj_Capa_Datos
{
  public class BD_Personal : Cls_Conexion 
    {
        public static bool save = false;
        public static bool edit = false;
        public static bool huella = false;
        public void BD_Registrar_Personal(EN_Persona per)
        {
            SqlConnection cn = new SqlConnection(Conectar());
            SqlCommand cmd = new SqlCommand("Sp_Insert_Personal",cn);
            try
            {
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Person", per.Idpersonal);
                cmd.Parameters.AddWithValue("@DOC", per.DOC);
                cmd.Parameters.AddWithValue("@nombreComplto", per.Nombres);
                cmd.Parameters.AddWithValue("@FechaNacmnto", per.anoNacimiento);
                cmd.Parameters.AddWithValue("@Sexo", per.Sexo);
                cmd.Parameters.AddWithValue("@Domicilio", per.Direccion);
                cmd.Parameters.AddWithValue("@Correo", per.Correo);
                cmd.Parameters.AddWithValue("@Celular", per.Celular);
                cmd.Parameters.AddWithValue("@Id_rol", per.IdRol);
                cmd.Parameters.AddWithValue("@Foto", per.xImagen);
                cmd.Parameters.AddWithValue("@Id_Depto", per.IdDepto);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                save = true;

            }
            catch (Exception ex)
            {
                save = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();

                }
                MessageBox.Show("Algo malo paso" + ex.Message, "Adevertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }   //FIN   

        //MEtodo para Editar personal
        public void BD_Editar_Personal(EN_Persona per)
        {
            SqlConnection cn = new SqlConnection(Conectar());
            SqlCommand cmd = new SqlCommand("Sp_Update_Personal", cn);
            try
            {
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Person", per.Idpersonal);
                cmd.Parameters.AddWithValue("@DOC", per.DOC);
                cmd.Parameters.AddWithValue("@nombreComplto", per.Nombres);
                cmd.Parameters.AddWithValue("@FechaNacmnto", per.anoNacimiento);
                cmd.Parameters.AddWithValue("@Sexo", per.Sexo);
                cmd.Parameters.AddWithValue("@Domicilio", per.Direccion);
                cmd.Parameters.AddWithValue("@Correo", per.Correo);
                cmd.Parameters.AddWithValue("@Celular", per.Celular);
                cmd.Parameters.AddWithValue("@Id_rol", per.IdRol);
                cmd.Parameters.AddWithValue("@Foto", per.xImagen);
                cmd.Parameters.AddWithValue("@Id_Depto", per.IdDepto);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                edit = true;

            }
            catch (Exception ex)
            {
                edit = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();

                }
                MessageBox.Show("Algo malo paso" + ex.Message, "Adevertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }   //FIN   

        //Metodo para registrar la huella dactilar del personal
        public void BD_Registrar_Huella_Personal(string idper, object finguer)
        {
            SqlConnection cn = new SqlConnection(Conectar());
            SqlCommand cmd = new SqlCommand("Sp_Actualizar_FinguerPrint", cn);
            try
            {
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPersona", idper);
                cmd.Parameters.AddWithValue("@finguerPrint", finguer);          

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                huella = true;

            }
            catch (Exception ex)
            {
                huella = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();

                }
                MessageBox.Show("Error al Ejecutar el SP: " + ex.Message, "Adevertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Metodo para leer a todo el personal

      public DataTable BD_Leer_todoPersona()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("SP_Listar_Personal", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dato = new DataTable();

                da.Fill(dato);
                da = null;
                return dato;

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();

                }
                MessageBox.Show("Error al Ejecutar el SP: " + ex.Message, "Adevertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return null;
        }
        //Metodo para buscar por el ID
        public DataTable BD_Buscar_Personal_xValor(string valor)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Cargar_PersonalxDOC", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@DOC", valor);
                DataTable dato = new DataTable();

                da.Fill(dato);
                da = null;
                return dato;

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();

                }
                MessageBox.Show("Error al Ejecutar el SP: " + ex.Message, "Adevertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return null;
        }



        public bool BD_Verificar_DocPersonal(string DOC)
        {
            bool functionReturnValue = false;
            Int32 xfil = 0;

            SqlConnection Cn = new SqlConnection();
            SqlCommand Cmd = new SqlCommand();
            Cn.ConnectionString = Conectar();

            var _With1 = Cmd;

            _With1.CommandText = "Sp_Validar_DOC";
            _With1.Connection = Cn;
            _With1.CommandTimeout = 20;
            _With1.CommandType = CommandType.StoredProcedure;
            //Parametros de entrada
            _With1.Parameters.AddWithValue("@DOC", DOC);
            try
            {
                Cn.Open();
                xfil = (Int32)Cmd.ExecuteScalar();
                if (xfil > 0)
                {
                    functionReturnValue = true;
                }
                else
                {
                    functionReturnValue = false;
                }
                Cmd.Parameters.Clear();
                Cmd.Dispose();
                Cmd = null;
                Cn.Close();
                Cn = null;
            }

            catch (Exception ex)
            {
                if (Cn.State == ConnectionState.Open)
                    Cn.Close();
                Cmd.Dispose();
                Cmd = null;
                Cn.Close();
                Cn = null;
                MessageBox.Show("Algo malo paso: " + ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return functionReturnValue;
        }



        public static bool supresed = false;
        public void BD_Eliminar_Personal(string DOC)
        {
            SqlConnection cn = new SqlConnection(Conectar());
            SqlCommand cmd = new SqlCommand("Sp_Eliminar_Personal", cn);

            try
            {
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DOC", DOC);


                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                supresed = true;

            }
            catch (Exception ex)
            {
                supresed = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();

                }
                MessageBox.Show("Algo malo paso al eliminar" + ex.Message, "Adevertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}
