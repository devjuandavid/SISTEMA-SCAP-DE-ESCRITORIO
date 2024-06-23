using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;

using MicroSisPlani.Msm_Forms;


namespace MicroSisPlani.Personal
{
    public partial class Frm_Registro_Personal : Form
    {
        public Frm_Registro_Personal()
        {
            InitializeComponent();
        }

        public bool saveeditar = false;


        private void Frm_Registro_Personal_Load(object sender, EventArgs e)
        {
            if (saveeditar == false)
            {
                Cargar_rol();
                Cargar_Depto();
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


        private void Cargar_Depto()
        {
            RN_Depto obj = new RN_Depto();
            DataTable dt = new DataTable();
            try
            {
                dt = obj.RN_Buscar_Todos_Depto();
                if (dt.Rows.Count > 0)
                {
                    var cbo = cbo_Depto;
                    cbo.DataSource = dt;
                    cbo.DisplayMember = "Depto";
                    cbo.ValueMember = "Id_Depto";
                }
                cbo_Depto.SelectedIndex = -1;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Revisa el Error.  " + ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private bool ValidarCajasTexto()
        {
            Frm_Advertencia adv = new Frm_Advertencia();
            Frm_Filtro fil = new Frm_Filtro();

            if (txt_doc.Text.Trim().Length < 3) { fil.Show(); adv.Lbl_Msm1.Text = "Ingrese el Documento del Personal"; adv.ShowDialog(); fil.Hide(); txt_doc.Focus(); return false; }
         
            if (txt_nombres.Text.Trim().Length < 4) { fil.Show(); adv.Lbl_Msm1.Text = "Ingrese el Nombre del Personal"; adv.ShowDialog(); fil.Hide(); txt_nombres.Focus(); return false; }
            if (txt_NroCelular.Text.Trim().Length < 8) { fil.Show(); adv.Lbl_Msm1.Text = "El Nro de Celular debe tener 8 caracteres"; adv.ShowDialog(); fil.Hide(); txt_NroCelular.Focus(); return false; }
            if (txt_NroCelular.Text.Trim().Length < 8) { fil.Show(); adv.Lbl_Msm1.Text = "Ingrese el Nro de Celular del Personal"; adv.ShowDialog(); fil.Hide(); txt_NroCelular.Focus(); return false; }
            if (txt_IdPersona.Text.Trim().Length < 4) { fil.Show(); adv.Lbl_Msm1.Text = "El ID del Personal no fue Generado"; adv.ShowDialog(); fil.Hide(); txt_doc.Focus(); return false; }

            if (cbo_sexo.SelectedIndex==- 1) { fil.Show(); adv.Lbl_Msm1.Text = "Seleccione el Sexo del Personal"; adv.ShowDialog(); fil.Hide(); cbo_sexo.Focus(); return false; }
            if (cbo_rol.SelectedIndex == -1) { fil.Show(); adv.Lbl_Msm1.Text = "Seleccione el Rol del Personal"; adv.ShowDialog(); fil.Hide(); cbo_rol.Focus(); return false; }
            if (cbo_Depto.SelectedIndex == -1) { fil.Show(); adv.Lbl_Msm1.Text = "Seleccione el Departamento del Personal"; adv.ShowDialog(); fil.Hide(); cbo_Depto.Focus(); return false; }


            return true;
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            Frm_Advertencia ok = new Frm_Advertencia();
            Frm_Filtro fil = new Frm_Filtro();
            RN_Personal objper = new RN_Personal();
          
            if (xedit == false)
            {
                if (objper.RN_Verificar_DocPersonal(txt_doc.Text) == true) { MessageBox.Show("El Nro de DOCUMENTO ya Existe en la Base de Datos, Verifica ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }

                if (ValidarCajasTexto() == false) return;
                Guardar_Personal();
            }
            else
            {
                Editar_Personal();
            }
           

        }

        private void Guardar_Personal()
        {
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            Frm_Filtro fil = new Frm_Filtro();
            RN_Personal obj = new RN_Personal();
            EN_Persona per = new EN_Persona();
            try
            {
                per.Idpersonal = txt_IdPersona.Text;
                per.DOC = txt_doc.Text;
                per.Nombres = txt_nombres.Text;
                per.anoNacimiento = dtp_fecha.Value;
                per.Sexo = cbo_sexo.Text;
                per.Direccion = txt_direccion.Text;
                per.Correo = txt_correo.Text;
                per.Celular = Convert.ToInt32(txt_NroCelular.Text);
                per.IdRol = Convert.ToString(cbo_rol.SelectedValue);
                per.xImagen = xFotoruta;
                per.IdDepto = Convert.ToString(cbo_Depto.SelectedValue);

                obj.RN_Registrar_Personal(per);

                if (BD_Personal.save == true)
                {
                    fil.Show();
                    ok.Lbl_msm1.Text = "Los Datos del Personal se han guardado correctamente";
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

        private void Editar_Personal()
        {
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            Frm_Filtro fil = new Frm_Filtro();
            RN_Personal obj = new RN_Personal();
            EN_Persona per = new EN_Persona();
            try
            {
                per.Idpersonal = txt_IdPersona.Text;
                per.DOC = txt_doc.Text;
                per.Nombres = txt_nombres.Text;
                per.anoNacimiento = dtp_fecha.Value;
                per.Sexo = cbo_sexo.Text;
                per.Direccion = txt_direccion.Text;
                per.Correo = txt_correo.Text;
                per.Celular = Convert.ToInt32(txt_NroCelular.Text);
                per.IdRol = Convert.ToString(cbo_rol.SelectedValue);
                per.xImagen = xFotoruta;
                per.IdDepto = Convert.ToString(cbo_Depto.SelectedValue);

                obj.RN_Editar_Personal(per);

                if (BD_Personal.edit == true)
                {
                    fil.Show();
                    ok.Lbl_msm1.Text = "Los Datos del Personal se han Editado correctamente";
                    ok.ShowDialog();
                    fil.Hide();

                    this.Tag = "A";
                    this.Close();


                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Revisa el Error.  "+ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    Pic_persona.Load(xFotoruta);
                }
            }
            catch (Exception )
            {
                xFotoruta = Application.StartupPath + @"\user.png";
                Pic_persona.Load(Application.StartupPath + @"\user.png");
            }

        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void pnl_titulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utilitarios u = new Utilitarios();
                u.Mover_formulario(this);
            }
        }
        public bool xedit = false;
     

        private void txt_NroCelular_OnValueChanged(object sender, EventArgs e)
        {
            string xcar1, xcar2;
            if (xedit == false)
            {
                if (txt_doc.Text.Length == 0) return;
                if (txt_nombres.Text.Length == 0) return;
                xcar1 = Convert.ToString(txt_doc.Text).Substring(2, 3);
                xcar2 = Convert.ToString(txt_nombres.Text).Substring(1, 3);
                txt_IdPersona.Text = xcar1 + "-" + xcar2;
            }
        }


        public void Buscar_Personal_ParaEditar(string idpersonal)
        {
            try
            {
                RN_Personal obj = new RN_Personal();
                DataTable data = new DataTable();

                Cargar_rol();
                Cargar_Depto();

                data = obj.RN_Buscar_Personal_xValor(idpersonal);
                if (data.Rows.Count ==0) return;
                {
                    txt_doc.Text = Convert.ToString(data.Rows[0]["DOC"]);
                    txt_nombres.Text = Convert.ToString(data.Rows[0]["Nombre_Completo"]);
                    txt_direccion.Text = Convert.ToString(data.Rows[0]["Domicilio"]);
                    txt_correo.Text = Convert.ToString(data.Rows[0]["Correo"]);
                    txt_NroCelular.Text = Text = Convert.ToString(data.Rows[0]["Celular"]);
                    dtp_fechaNaci.Value = Convert.ToDateTime(data.Rows[0]["Fec_Naci"]);
                    cbo_sexo.Text = Convert.ToString(data.Rows[0]["Sexo"]);
                    cbo_rol.SelectedValue = Convert.ToString(data.Rows[0]["Id_rol"]);
                    cbo_Depto.SelectedValue = Convert.ToString(data.Rows[0]["Id_Depto"]);
                    txt_IdPersona.Text = Convert.ToString(data.Rows[0]["Id_Pernl"]);
                    xFotoruta = Convert.ToString(data.Rows[0]["Foto"]);
                }

                xedit = true;
                btn_aceptar.Enabled = true;
                Pic_persona.Load(xFotoruta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Revisa el Error.  " + ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_doc_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cbo_rol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
