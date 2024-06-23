using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Prj_Capa_Entidad;

namespace Prj_Capa_Datos
{
    public class BD_Asistencia : Cls_Conexion
    {

        public DataTable BD_Ver_Todas_Asistencia()
        {
            SqlConnection xcn = new SqlConnection();
            try
            {
                xcn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Cargar_Todas_Asistencias", xcn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                // da.SelectCommand.Parameters.AddWithValue("@fecha", xdia);
                DataTable Dato = new DataTable();
                da.Fill(Dato);
                da = null;
                return Dato;
            }
            catch (Exception ex)
            {
                if (xcn.State == ConnectionState.Open)
                {
                    xcn.Close();
                    throw new Exception("Error" + ex.Message, ex);
                }
            }
            return null;
        }

        public DataTable BD_Ver_Todas_Asistencia_DelDia(DateTime xfecha)
        {
            SqlConnection xcn = new SqlConnection();
            try
            {
                xcn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Cargar_Asistencia_deldia", xcn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fecha", xfecha);
                DataTable Dato = new DataTable();
                da.Fill(Dato);
                da = null;
                return Dato;
            }
            catch (Exception ex)
            {
                if (xcn.State == ConnectionState.Open)
                {
                    xcn.Close();
                    throw new Exception("Error" + ex.Message, ex);
                }
            }
            return null;
        }


        public DataTable BD_Ver_Todas_Asistencia_DelMes(DateTime xfecha)
        {
            SqlConnection xcn = new SqlConnection();
            try
            {
                xcn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Cargar_Asistencia_xFecha", xcn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fecha", xfecha);
                DataTable Dato = new DataTable();
                da.Fill(Dato);
                da = null;
                return Dato;
            }
            catch (Exception ex)
            {
                if (xcn.State == ConnectionState.Open)
                {
                    xcn.Close();
                    throw new Exception("Error" + ex.Message, ex);
                }
            }
            return null;
        }

        public DataTable BD_Ver_Todas_Asistencia_ParaExplorador(string xvalor)
        {
            SqlConnection xcn = new SqlConnection();
            try
            {
                xcn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_Asistencia_paraExplorador", xcn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_Asis", xvalor);
                DataTable Dato = new DataTable();
                da.Fill(Dato);
                da = null;
                return Dato;
            }
            catch (Exception ex)
            {
                if (xcn.State == ConnectionState.Open)
                {
                    xcn.Close();
                    throw new Exception("Error" + ex.Message, ex);
                }
            }
            return null;
        }

        //por persona asistencia
        public DataTable BD_Ver_Asistencia_porPersona(string IdAsis, DateTime xfecha)
        {
            SqlConnection xcn = new SqlConnection();
            try
            {
                xcn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_Asistencia_xPersona_Reporte", xcn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_Asis", IdAsis);
                da.SelectCommand.Parameters.AddWithValue("@FechaMes", xfecha);
                DataTable Dato = new DataTable();
                da.Fill(Dato);
                da = null;
                return Dato;
            }
            catch (Exception ex)
            {
                if (xcn.State == ConnectionState.Open)
                {
                    xcn.Close();
                    throw new Exception("Error" + ex.Message, ex);
                }
            }
            return null;
        }




        public DataTable BD_Buscar_Asistencia_deEntrada(string idperso)
        {
            SqlConnection xcn = new SqlConnection();
            try
            {
                xcn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Leer_asistencia_reciente", xcn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idper", idperso);
                DataTable Dato = new DataTable();
                da.Fill(Dato);
                da = null;
                return Dato;
            }
            catch (Exception ex)
            {
                if (xcn.State == ConnectionState.Open)
                {
                    xcn.Close();
                   
                }
                MessageBox.Show("Algo malo paso" + ex.Message, "Adevertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;
        }





        public static bool  entrada=false ;
        public static bool salida = false;
        //salida
        public void BD_Registrar_Salida_Personal(string idAsis, string idPerso, string HoSalida, double totalHora)
        {
            SqlConnection cn = new SqlConnection(Conectar());
            SqlCommand cmd = new SqlCommand("Sp_Registrar_Salida", cn);

            try
            {
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdAsis", idAsis);
                cmd.Parameters.AddWithValue("@Id_Personal", idPerso);
                cmd.Parameters.AddWithValue("@HoSalida", HoSalida);
                cmd.Parameters.AddWithValue("@TotalHora", totalHora);
    


                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                salida = true;

            }
            catch (Exception ex)
            {
                salida = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();

                }
                MessageBox.Show("Algo malo paso" + ex.Message, "Adevertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //registro
        public void BD_Registrar_Entrada_Personal(string idAsis, string idPerso, string HoIngreso, double tarde, int totalHora, string justificado)
        {
            SqlConnection cn = new SqlConnection(Conectar());
            SqlCommand cmd = new SqlCommand("Sp_Registrar_Entrada", cn);

            try
            {
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdAsis", idAsis);
                cmd.Parameters.AddWithValue("@Id_Persol", idPerso);
                cmd.Parameters.AddWithValue("@Hoingre", HoIngreso);
                cmd.Parameters.AddWithValue("@tardanza", tarde);
                cmd.Parameters.AddWithValue("@TotalHora", totalHora);
                cmd.Parameters.AddWithValue("@justificado", justificado);


                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                entrada = true;

            }
            catch (Exception ex)
            {
                entrada = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();

                }
                MessageBox.Show("Algo malo paso" + ex.Message, "Adevertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //CHECAR YA MARCO ASISTENCIA
        public bool BD_Checar_SiPersonal_YaMarco_Asistencia(string xidPerso)
        {
            bool functionReturnValue = false;
            Int32 xfil = 0;

            SqlConnection Cn = new SqlConnection();
            SqlCommand Cmd = new SqlCommand();
            Cn.ConnectionString = Conectar();

            var _With1 = Cmd;

            _With1.CommandText = "Sp_Validar_RegistroAsistencia";
            _With1.Connection = Cn;
            _With1.CommandTimeout = 20;
            _With1.CommandType = CommandType.StoredProcedure;
            //Parametros de entrada
            _With1.Parameters.AddWithValue("@Id_Personal", xidPerso);
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



        public bool BD_Checar_SiPersonal_YaMarco_suEntrada(string xidPerso)
        {
            bool functionReturnValue = false;
            Int32 xfil = 0;

            SqlConnection Cn = new SqlConnection();
            SqlCommand Cmd = new SqlCommand();
            Cn.ConnectionString = Conectar();

            var _With1 = Cmd;

            _With1.CommandText = "Sp_verificar_IngresoAsis";
            _With1.Connection = Cn;
            _With1.CommandTimeout = 20;
            _With1.CommandType = CommandType.StoredProcedure;
            //Parametros de entrada
            _With1.Parameters.AddWithValue("@Id_Personal", xidPerso);
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


        public bool BD_Verificar_Justificacion_Aprobado(string idpers)
        {
            bool functionReturnValue = false;
            Int32 xfil = 0;

            SqlConnection Cn = new SqlConnection();
            SqlCommand Cmd = new SqlCommand();
            Cn.ConnectionString = Conectar();

            var _With1 = Cmd;

            _With1.CommandText = "SP_VerificarJustificacion_Aprobada";
            _With1.Connection = Cn;
            _With1.CommandTimeout = 20;
            _With1.CommandType = CommandType.StoredProcedure;
            //Parametros de entrada
            _With1.Parameters.AddWithValue("@Id_Personal", idpers);
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



        public bool BD_Checar_SiPersonal_TieneAsistencia_Registrada(string xidPerso)
        {


            bool functionReturnValue = false;
            Int32 xfil = 0;

            SqlConnection Cn = new SqlConnection();
            SqlCommand Cmd = new SqlCommand();
            Cn.ConnectionString = Conectar();

            var _With1 = Cmd;

            _With1.CommandText = "Sp_Ver_sihay_Registro";
            _With1.Connection = Cn;
            _With1.CommandTimeout = 20;
            _With1.CommandType = CommandType.StoredProcedure;
            //Parametros de entrada
            _With1.Parameters.AddWithValue("@Id_Personal", xidPerso);
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
     
        
        public bool BD_Checar_SiPersonal_YaMarco_suFalta(string xidPerso)
        {
            bool functionReturnValue = false;
            Int32 xfil = 0;

            SqlConnection Cn = new SqlConnection();
            SqlCommand Cmd = new SqlCommand();
            Cn.ConnectionString = Conectar();

            var _With1 = Cmd;

            _With1.CommandText = "Sp_Verificar_siMarco_Falta";
            _With1.Connection = Cn;
            _With1.CommandTimeout = 20;
            _With1.CommandType = CommandType.StoredProcedure;
            //Parametros de entrada
            _With1.Parameters.AddWithValue("@Id_Personal", xidPerso);
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

        public static bool faltasaved = false;
        public void BD_Registrar_Falta_Personal(string idAsis, string idPerso, string justifi)
        {

            SqlConnection cn = new SqlConnection(Conectar());
            SqlCommand cmd = new SqlCommand("Sp_Registrar_Falta", cn);

            try
            {
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdAsis", idAsis);
                cmd.Parameters.AddWithValue("@Id_Personal", idPerso);
                cmd.Parameters.AddWithValue("@justificacion", justifi);       

                 cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                faltasaved = true;

            }
            catch (Exception ex)
            {
                faltasaved = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();

                }
                MessageBox.Show("Falla en registrar falta" + ex.Message, "Adevertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        public static bool supresed = false;
        public void BD_Eliminar_Asistencia(string idasis)
        {
            SqlConnection cn = new SqlConnection(Conectar());
            SqlCommand cmd = new SqlCommand("Sp_Delete_Asistencia", cn);

            try
            {
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_Asis", idasis);


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
                MessageBox.Show("Algo malo paso" + ex.Message, "Adevertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}
