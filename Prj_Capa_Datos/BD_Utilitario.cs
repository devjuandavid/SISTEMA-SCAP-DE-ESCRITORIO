using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Prj_Capa_Datos
{
   public  class BD_Utilitario : Cls_Conexion 
    {

     public static string BD_NroDoc(int Id_Tipo)
        {
            SqlConnection Cn = new SqlConnection();
            try
            {
                Cn.ConnectionString = Conectar2();
                SqlCommand cmd = new SqlCommand("Sp_Listado_Tipo", Cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Tipo", Id_Tipo);

                string NroDoc;
                Cn.Open();
                NroDoc = Convert.ToString(cmd.ExecuteScalar());
                Cn.Close();
                return NroDoc;
            
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (Cn.State == ConnectionState.Open) Cn.Close();
                Cn.Dispose();
                Cn = null;
                return null;
            }
        }


        public static void BD_Actualiza_Tipo_Doc(int Id_Tipo)
        {
            SqlConnection Cn = new SqlConnection(Conectar2());
            SqlCommand cmd = new SqlCommand("Sp_Actualiza_Tipo_Doc", Cn);
            try
            {
                cmd.CommandTimeout = 20;          
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Tipo", Id_Tipo);
                              
                Cn.Open();

                cmd.ExecuteNonQuery();
                Cn.Close();

                cmd.Dispose();
                cmd = null;
                Cn = null;

            }
            catch (Exception ex)
            {

                if (Cn.State == ConnectionState.Open) Cn.Close();
                Cn.Dispose();
                Cn = null;
                MessageBox.Show("Error: " + ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
            }
        }

        //Listar tipo robot
        public static string BD_Listar_TipoFalta(int Id_Tipo)
        {
            SqlConnection Cn = new SqlConnection();
            try
            {
                Cn.ConnectionString = Conectar2();
                SqlCommand cmd = new SqlCommand("Sp_Listado_TipoFalta", Cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Tipo", Id_Tipo);
                string NroDoc;

                Cn.Open();
                NroDoc = Convert.ToString(cmd.ExecuteScalar());
                Cn.Close();
                return NroDoc;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (Cn.State == ConnectionState.Open) Cn.Close();
                Cn.Dispose();
                Cn = null;
                return null;
            }
        }

        public static bool falta = false;
        public void BD_Actulizar_RobotFalta(int IdTipo, string serie)
        {
            SqlConnection Cn = new SqlConnection(Conectar());
            SqlCommand cmd = new SqlCommand("Sp_Activar_Desac_RobotFalta", Cn);
            try
            {
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdTipo", IdTipo);
                cmd.Parameters.AddWithValue("@serie", serie);
                Cn.Open();

                cmd.ExecuteNonQuery();

                Cn.Close();

                falta = true;

            }
            catch (Exception ex)
            {

                falta = false;
                MessageBox.Show("Error: " + ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (Cn.State == ConnectionState.Open) { Cn.Close(); }
            }
        }

    }
}
