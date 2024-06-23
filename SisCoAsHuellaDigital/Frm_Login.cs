using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MicroSisPlani.Msm_Forms;
using Prj_Capa_Negocio;

namespace MicroSisPlani
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {
            txt_usu.Text = "admin";
            txt_pass.Text = "admin";
        }

      

        private bool ValidarTextbox()
        {
            if (txt_usu.Text.Trim().Length == 0) { MessageBox.Show("Ingresa tu Usuario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); txt_usu.Focus(); return false;}
            if (txt_pass.Text.Trim().Length == 0) { MessageBox.Show("Ingresa tu Contraseña", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); txt_pass.Focus(); return false; }

            return true;
        }

        private void AccederAlSistema()
        {
            RN_Usuario obj = new RN_Usuario();
            DataTable dt = new DataTable();
            int veces = 0;
            if (ValidarTextbox() == false) return;

            string usu, pass;
            usu = txt_usu.Text.Trim();
            pass = txt_pass.Text.Trim();
            if (obj.RN_Verificar_Acceso(usu, pass) == true)
            {
                //Los datos son Correctos
                //Llleanar el datatable con los datos del usuario
                //MessageBox.Show("Bienvenidos al Sistema", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cls_Libreria.Usuario = usu;

                dt = obj.RN_Leer_Datos_Usuario(usu);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    Cls_Libreria.IdRol = Convert.ToString(dr["Id_Usu"]);
                    Cls_Libreria.Apellidos = dr["Nombre_Completo"].ToString();
                    Cls_Libreria.IdRol = Convert.ToString(dr["Id_Rol"]);
                    Cls_Libreria.Rol = dr["NomRol"].ToString();
                    Cls_Libreria.Foto = dr["Avatar"].ToString();
                }


                this.Hide();
                Frm_Principal xMenuPrincipal =new Frm_Principal();
                xMenuPrincipal.Show();
                xMenuPrincipal.Cargar_Datos_usuario();
            }


            else
            {
                // Si no son Correctos
                MessageBox.Show("Usuario o Contraseña no son validos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_usu.Text = "";
                txt_pass.Text = "";
                txt_usu.Focus();
                veces += 1;
                if (veces == 3)
                {
                    MessageBox.Show("El Nro Maximo de intentos fue superado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Application.Exit();
                }
            }
        }
        
        private void btn_Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pnl_titulo_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            {
                Utilitarios u = new Utilitarios();
                u.Mover_formulario(this);

            }
        }

        private void txt_usu_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                txt_pass.Focus();
            }
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            AccederAlSistema();
        }

        private void txt_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Aceptar_Click(sender,e);
            }
        }

        private void btn_Asis_Manual_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Marcar_Asis_Manual asis = new Frm_Marcar_Asis_Manual();

            fil.Show();
            asis.ShowDialog();
            fil.Hide();
        }

        private void btn_Asis_With_Huella_Click(object sender, EventArgs e)
        {
            Frm_Filtro fis = new Frm_Filtro();
            Frm_Marcar_Asistencia asis = new Frm_Marcar_Asistencia();
            fis.Show();
            asis.ShowDialog();
            fis.Hide();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PicLogo_Click(object sender, EventArgs e)
        {

        }
    }
}
