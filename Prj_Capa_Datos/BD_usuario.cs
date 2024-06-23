using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Prj_Capa_Entidad;
using System.Windows.Forms;


namespace Prj_Capa_Datos
{
   public  class BD_usuario : Cls_Conexion 
    {
        public bool BD_Verificar_Acceso(string Usuario, string Contraseña)
        {
            bool functionReturnValue = false;
            Int32 xfil = 0;

            SqlConnection Cn = new SqlConnection();
            SqlCommand Cmd = new SqlCommand ();
            Cn.ConnectionString = Conectar();

            var _With1 = Cmd;

            _With1.CommandText = "Sp_Login";
            _With1.Connection = Cn;
            _With1.CommandTimeout = 20;
            _With1.CommandType = CommandType.StoredProcedure;
            //Parametros de entrada
            _With1.Parameters.AddWithValue("@Usuario",Usuario);
            _With1.Parameters.AddWithValue("@Contraseña", Contraseña);
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


        public DataTable BD_Leer_Datos_Usuario(string Usuario)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Usuario_Login", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Usuario", Usuario);
                DataTable dato = new DataTable();
                da.Fill(dato);
                da = null;
                return dato;

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                cn.Close();
                cn = null;
                MessageBox.Show("Algo malo paso " + ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return null;
        }



        public static bool save = false;
        public static bool edit = false;
        public static bool huella = false;
        public void BD_Registrar_Usuario(EN_Usuario user)
        {
            SqlConnection cn = new SqlConnection(Conectar());
            SqlCommand cmd = new SqlCommand("Sp_Insert_Usuario", cn);
            try
            {
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Usu", user.Idusu);
                cmd.Parameters.AddWithValue("@nombreComplto", user.Namecomplete);
                cmd.Parameters.AddWithValue("@Avatar", user.Avatar);
                cmd.Parameters.AddWithValue("@NomUsuario", user.UsuName);
                cmd.Parameters.AddWithValue("@Password", user.Password);
               
                cmd.Parameters.AddWithValue("@Id_rol", user.IdRol);
       

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
                MessageBox.Show("Algo malo paso Usuario" + ex.Message, "Adevertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }   //FIN   

        //MEtodo para Editar Usuario
        public void BD_Editar_Usuario(EN_Usuario user)
        {
            SqlConnection cn = new SqlConnection(Conectar());
            SqlCommand cmd = new SqlCommand("Sp_Update_Usuario", cn);
            try
            {
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Usu", user.Idusu);
                cmd.Parameters.AddWithValue("@nombreComplto", user.Namecomplete);
                cmd.Parameters.AddWithValue("@Avatar", user.Avatar);
                cmd.Parameters.AddWithValue("@Nom_Usuario", user.UsuName);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Id_rol", user.IdRol);
             

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

     

        //Metodo para leer a todo el usuario

        public DataTable BD_Leer_todoUsuario()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("SP_Listar_Usuario", cn);
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
                MessageBox.Show("Error al Ejecutar el SP Listar: " + ex.Message, "Adevertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return null;
        }
        //Metodo para buscar por el ID
        public DataTable BD_Buscar_Usuario_xValor(string valor)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Cargar_UsuarioxUSER", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@USER", valor);
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
                MessageBox.Show("Error al Ejecutar el SP: Cargar Usario por Valor " + ex.Message, "Adevertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return null;
        }



        public bool BD_Verificar_UserUSUARIO(string USER)
        {
            bool functionReturnValue = false;
            Int32 xfil = 0;

            SqlConnection Cn = new SqlConnection();
            SqlCommand Cmd = new SqlCommand();
            Cn.ConnectionString = Conectar();

            var _With1 = Cmd;

            _With1.CommandText = "Sp_Validar_USUARIO";
            _With1.Connection = Cn;
            _With1.CommandTimeout = 20;
            _With1.CommandType = CommandType.StoredProcedure;
            //Parametros de entrada
            _With1.Parameters.AddWithValue("@Nom_Usuario", USER);
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
        public void BD_Eliminar_Usuario(string ID)
        {
            SqlConnection cn = new SqlConnection(Conectar());
            SqlCommand cmd = new SqlCommand("Sp_Eliminar_Usuario", cn);

            try
            {
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_Usu", ID);


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
