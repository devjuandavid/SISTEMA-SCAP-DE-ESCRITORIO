using MicroSisPlani.Msm_Forms;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroSisPlani.Usuario
{
    public partial class Form_Usuario : Form
    {
        public Form_Usuario()
        {
            InitializeComponent();
        }
        public bool saveeditar = false;
        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void Form_Usuario_Load(object sender, EventArgs e)
        {
            if (saveeditar == false)
            {
                Cargar_rol();
               
            }
        }
        private void Cargar_rol()
        {
            RN_Rol obj = new RN_Rol();
            DataTable dt = new DataTable();
            try
            {
                dt = obj.RN_Buscar_Todos_Roles();
                if (dt.Rows.Count > 0)
                {
                    var cbo = cbo_rol;
                    cbo.DataSource = dt;
                    cbo.DisplayMember = "NomRol";
                    cbo.ValueMember = "Id_Rol";
                }
                cbo_rol.SelectedIndex = -1;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCajasTexto()
        {
            Frm_Advertencia adv = new Frm_Advertencia();
            Frm_Filtro fil = new Frm_Filtro();

        
            if (txt_nombres.Text.Trim().Length < 4) { fil.Show(); adv.Lbl_Msm1.Text = "Ingrese el Nombre del Personal"; adv.ShowDialog(); fil.Hide(); txt_nombres.Focus(); return false; }
             if (txt_Usuario.Text.Trim().Length < 2) { fil.Show(); adv.Lbl_Msm1.Text = "Ingrese un Usuario "; adv.ShowDialog(); fil.Hide(); txt_Usuario.Focus(); return false; }
            if (txt_Contraseña.Text.Trim().Length < 2) { fil.Show(); adv.Lbl_Msm1.Text = "Ingrese una Contraseña"; adv.ShowDialog(); fil.Hide(); txt_Contraseña.Focus(); return false; }


            if (cbo_rol.SelectedIndex == -1) { fil.Show(); adv.Lbl_Msm1.Text = "Seleccione el Rol del Personal"; adv.ShowDialog(); fil.Hide(); cbo_rol.Focus(); return false; }
        
            return true;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }
        public bool xedit = false;
        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            Frm_Advertencia ok = new Frm_Advertencia();
            Frm_Filtro fil = new Frm_Filtro();
            RN_Usuario objUSer = new RN_Usuario();

            if (xedit == false)
            {
                if (objUSer.RN_Verificar_UserUSUARIO(txt_Usuario.Text) == true) { MessageBox.Show("El Usuario ya Existe en la Base de Datos, Verifica ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

                if (ValidarCajasTexto() == false) return;
                Guardar_Usuario();
            }
            else
            {
               Editar_Usuario();
            }
        }




        private void Editar_Usuario()
        {
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            Frm_Filtro fil = new Frm_Filtro();
            RN_Usuario obj = new RN_Usuario();
            EN_Usuario user = new EN_Usuario();
            try
            {
                user.Idusu = lbl_IdAsis.Text;
                user.Namecomplete = txt_nombres.Text;
                user.Avatar = xFotoruta;
                user.UsuName = txt_Usuario.Text;
                user.Password = txt_Contraseña.Text;          
                user.IdRol = Convert.ToString(cbo_rol.SelectedValue);             
              

                obj.RN_Editar_Usuario(user);

                if (BD_usuario.edit == true)
                {
                    fil.Show();
                    ok.Lbl_msm1.Text = "Los Datos del Usuario se han Editado Correctamente";
                    ok.ShowDialog();
                    fil.Hide();

                    this.Tag = "A";
                    this.Close();


                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Revisa el Error.  " + ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Guardar_Usuario()
        {
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            Frm_Filtro fil = new Frm_Filtro();
            RN_Usuario obj = new RN_Usuario();
            EN_Usuario User = new EN_Usuario();
            try
            {  
                lbl_IdAsis.Text = RN_Utilitario.RN_NroDoc(6);

                User.Idusu = lbl_IdAsis.Text;
                User.Namecomplete = txt_nombres.Text;
                User.Avatar = xFotoruta;
                User.UsuName = txt_Usuario.Text;
                User.Password = txt_Contraseña.Text;           
                User.IdRol = Convert.ToString(cbo_rol.SelectedValue);

             

                obj.RN_Registrar_Usuario(User);

                if (BD_usuario.save == true)
                {

                    RN_Utilitario.RN_Actualiza_Tipo_Doc(6);
                    fil.Show();
                    ok.Lbl_msm1.Text = "Los Datos del Usuario se han guardado correctamente";
                    ok.ShowDialog();
                    fil.Hide();

                    this.Tag = "A";
                    this.Close();


                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Revisa el Error guardar Usuario.  " + ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        string xFotoruta;
        private void Pic_persona_Click(object sender, EventArgs e)
        {
            var filepath = string.Empty;
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    xFotoruta = openFileDialog1.FileName;
                    Pic_User.Load(xFotoruta);
                }
            }
            catch (Exception)
            {
                xFotoruta = Application.StartupPath + @"\user.png";
                Pic_User.Load(Application.StartupPath + @"\user.png");
            }

        }




        public void Buscar_Usuario_ParaEditar(string idUsuario)
        {
            try
            {
                RN_Usuario obj = new RN_Usuario();
                DataTable data = new DataTable();

                Cargar_rol();


                data = obj.RN_Buscar_Usuario_xValor(idUsuario);
                if (data.Rows.Count == 0) return;
                {
                    lbl_IdAsis.Text = Convert.ToString(data.Rows[0]["Id_Usu"]);
                    txt_nombres.Text = Convert.ToString(data.Rows[0]["Nombre_Completo"]);
                    xFotoruta = Convert.ToString(data.Rows[0]["Avatar"]);
                    txt_Usuario.Text = Convert.ToString(data.Rows[0]["Nom_Usuario"]);
                    txt_Contraseña.Text = Convert.ToString(data.Rows[0]["Password"]);
                    cbo_rol.SelectedValue = Convert.ToString(data.Rows[0]["Id_Rol"]);
                    
                }

                xedit = true;
                btn_aceptar.Enabled = true;
                Pic_User.Load(xFotoruta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Revisa el Error.  " + ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cbo_rol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
