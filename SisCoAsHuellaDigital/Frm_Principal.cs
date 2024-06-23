using MicroSisPlani.Personal;
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
using MicroSisPlani.Informes;
using System.IO;
using System.Collections;
using MicroSisPlani.Usuario;

namespace MicroSisPlani
{
    public partial class Frm_Principal : Form
    {
        public Frm_Principal()
        {
            InitializeComponent();
        }

        private void Frm_Principal_Load(object sender, EventArgs e)
        {
            ConfigurarListview();
            ConfiguraListview_Asis();
            ConfiguraListview_Justifi();
            Verficar_Robot_de_Faltas();
            CargarHorarios();
            ConfigurarListviewUser();
         
        }

        private void Verficar_Robot_de_Faltas()
        {
            string tipo;
            tipo = RN_Utilitario.RN_Listar_TipoFalta(5);
            if (tipo.Trim() == "Si")
            {
                timerFalta.Start();
                rdb_ActivarRobot.Checked = true;
            }
            else if (tipo.Trim() == "No")
            {
                timerFalta.Stop();
                rdb_Desact_Robot.Checked = true;
            }
        }



        public void Cargar_Datos_usuario()
        {
            try
            {
                Frm_Filtro xfil = new Frm_Filtro();
                xfil.Show();
                MessageBox.Show("Bienvenido Sr: " + Cls_Libreria.Apellidos, "Bienvenido al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                xfil.Hide();

                Lbl_NomUsu.Text = Cls_Libreria.Apellidos;
                lbl_rolNom.Text = Cls_Libreria.Rol;



                if (lbl_rolNom.Text == "Administrador")
                {

                }
                else if (lbl_rolNom.Text == "Cajera")
                {
                    
                   
                    bt_exploJusti.Enabled = false;
                    bt_Config.Enabled = false;
                    elButtonUser.Enabled = false;


                }
                else if (lbl_rolNom.Text == "Secretaria")
                {
                    bt_exploJusti.Enabled = false;
                    bt_Config.Enabled = false;
                    elButtonUser.Enabled = false;

                }
                else if (lbl_rolNom.Text == "Jefe Personal")
                {
                   

                }



                if (Cls_Libreria.Foto.Trim().Length == 0 | Cls_Libreria.Foto == null) return;
                if (File.Exists(Cls_Libreria.Foto) == true)
                {
                    pic_user.Load(Cls_Libreria.Foto);
                }
                else
                {
                    pic_user.Image = Properties.Resources.user;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Revisa el Error.  " + ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utilitarios u = new Utilitarios();
                u.Mover_formulario(this);
            }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_mini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Explorador_Personal pers = new Frm_Explorador_Personal();
            pers.MdiParent = this;
            pers.Show();

        }

        private void bt_personal_Click(object sender, EventArgs e)
        {

            elTabPage2.Visible = true;
            elTab1.SelectedTabPageIndex = 1;
            Cargar_todo_Personal();

        }

        private void Frm_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Sino sino = new Frm_Sino();

            fil.Show();
            sino.Lbl_msm1.Text = "Estas Seguro de Salir del Sistema de Control de Asistencia";
            sino.ShowDialog();
            fil.Hide();
            if (Convert.ToString(sino.Tag) == "Si")
            {
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;
            }

        }

        private void btn_nuevoAsis_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Marcar_Asis_Manual asis = new Frm_Marcar_Asis_Manual();

            fil.Show();
            asis.ShowDialog();
            fil.Hide();
        }

        private void bt_Explo_Asis_Click(object sender, EventArgs e)
        {

            elTabPage3.Visible = true;
            elTab1.SelectedTabPageIndex = 2;
            Cargar_todasAsistencias_delDia(dtp_fechadeldia.Value);

        }

        private void Btn_Cerrar_TabPers_Click(object sender, EventArgs e)
        {
            elTabPage2.Visible = false;
            elTab1.SelectedTabPageIndex = 0;
        }

        private void btn_cerrarEx_Asis_Click(object sender, EventArgs e)
        {
            elTabPage3.Visible = false;
            elTab1.SelectedTabPageIndex = 0;
        }

     
        #region Persona
        private void ConfigurarListview()
        {
            var lis = lsv_person;
            lis.Columns.Clear();
            lis.Items.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            lis.Columns.Add("Id Persona", 0, HorizontalAlignment.Left);
            lis.Columns.Add("DOC", 115, HorizontalAlignment.Left);
            lis.Columns.Add("Nombres del Personal", 316, HorizontalAlignment.Left);
            lis.Columns.Add("Direccion", 100, HorizontalAlignment.Left);
            lis.Columns.Add("Correo", 0, HorizontalAlignment.Left);
            lis.Columns.Add("Sexo", 0, HorizontalAlignment.Left);
            lis.Columns.Add("Fe Nac", 110, HorizontalAlignment.Center);
            lis.Columns.Add("Nro Celular", 120, HorizontalAlignment.Left);
            lis.Columns.Add("Rol", 110, HorizontalAlignment.Left);
            lis.Columns.Add("Departamento", 0, HorizontalAlignment.Left);
            lis.Columns.Add("Estado", 100, HorizontalAlignment.Left);

        }


        private void Cargar_todo_Personal()
        {
            RN_Personal obj= new RN_Personal();
            DataTable dt= new DataTable();

            dt = obj.RN_Leer_todoPersona();
            if (dt.Rows.Count > 0)
            {
                LlenarListview(dt);
                
            }
        }


        private void LlenarListview(DataTable data)
        {
            lsv_person.Items.Clear();
            for(int i = 0;i < data.Rows.Count;i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_pernl"].ToString());
                list.SubItems.Add(dr["DOC"].ToString());
                list.SubItems.Add(dr["Nombre_Completo"].ToString());
                list.SubItems.Add(dr["Domicilio"].ToString());
                list.SubItems.Add(dr["Correo"].ToString());
                list.SubItems.Add(dr["Sexo"].ToString());
                list.SubItems.Add(dr["Fec_Naci"].ToString());
                list.SubItems.Add(dr["Celular"].ToString());
                list.SubItems.Add(dr["NomRol"].ToString());

                list.SubItems.Add(dr["Id_Depto"].ToString());
                list.SubItems.Add(dr["Estado_Per"].ToString());
                lsv_person.Items.Add(list);
            }
            Lbl_total.Text = Convert.ToString(lsv_person.Items.Count);
        }
       

        private void Buscar_Personal_PorValor(string xvalor)
        {
            RN_Personal obj = new RN_Personal();
            DataTable dt = new DataTable();
            dt = obj.RN_Buscar_Personal_xValor(xvalor);
            if (dt.Rows.Count > 0)
            {
                LlenarListview(dt);
            }
            else
            {
                lsv_person.Items.Clear();
            }
        }

        private void txt_Buscar_OnValueChanged(object sender, EventArgs e)
        {
            if (txt_Buscar.Text.Trim().Length > 2)
            {
                Cargar_todasAsistencias_porValor(txt_Buscar.Text.Trim());

            }
        }

        private void bt_mostrarTodoElPersonal_Click(object sender, EventArgs e)
        {
            Cargar_todo_Personal();
        }


     
        #endregion

        private void txt_Buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Buscar_Personal_PorValor(txt_Buscar.Text.Trim());
            }
        }

        private void bt_nuevoPersonal_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Registro_Personal per = new Frm_Registro_Personal();

            fil.Show();
            per.xedit = false;
            per.ShowDialog();

            fil.Hide();
            if (Convert.ToString(per.Tag) == "") return;
            {
                Cargar_todo_Personal();
            }

        }

        private void Bt_NewPerso_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Registro_Personal per = new Frm_Registro_Personal();

            fil.Show();
            per.xedit = false;
            per.ShowDialog();

            fil.Hide();
            if (Convert.ToString(per.Tag) == "") return;
            {
                Cargar_todo_Personal();
            }
        }

        private void bt_editarPersonal_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Registro_Personal per = new Frm_Registro_Personal();

            if (lsv_person.SelectedIndices.Count == 0)
            {
                fil.Show();
                MessageBox.Show("Selecciona un Personal para Editar ", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                fil.Hide();
            }
            else
            {
                var lsv = lsv_person.SelectedItems[0];
                string idpersona = lsv.SubItems[0].Text;
                fil.Show();
                per.saveeditar = true;
                per.Buscar_Personal_ParaEditar(idpersona);
                per.ShowDialog();
                fil.Hide();
                if (Convert.ToString(per.Tag) == "A")
                {
                    Cargar_todo_Personal();
                }
            }
        }

        private void btn_SaveHorario_Click(object sender, EventArgs e)
        {
            //Hora Ingreso 7:30
            //Hora tolerancia 7:15 es decir de 15 minutos, cuenta la hora de atraso desde 7:45 
            //Hora de ingreso 7:30
            //Tolerancia 7:20 quiere decir que desde 7:50 adelante marcara con atraso con minutos
            //8:00 ingreso 8:05 adelante cuenta falta y se cierra 9:00
            try
            {
                RN_Horario hor = new RN_Horario();
                EN_Horario por = new EN_Horario();
                Frm_Filtro fis = new Frm_Filtro();
                Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
                Frm_Advertencia adver = new Frm_Advertencia();

                por.Idhora = lbl_idHorario.Text;
                por.HoEntrada = dtp_horaIngre.Value;
                por.HoTole = dtp_hora_tolercia.Value;
                por.HoLimite = Dtp_Hora_Limite.Value;
                por.HoSalida = dtp_horaSalida.Value;
                hor.RN_Actulizar_Horario(por);
                if (BD_Horario.saved == true)
                {
                    fis.Show();
                    ok.Lbl_msm1.Text = "El Horario fue Actulizado";
                    ok.ShowDialog();
                    fis.Hide();

                    elTabPage4.Visible = false;
                    elTab1.SelectedTabPageIndex = 0;


                }
            }
            catch
            {

            }
        }

        private void CargarHorarios()
        {
            RN_Horario obj = new RN_Horario();
            DataTable data = new DataTable();

            data = obj.RN_Leer_Horario();
            if (data.Rows.Count == 0) return;
            lbl_idHorario.Text = Convert.ToString(data.Rows[0]["Id_Hor"]);
            dtp_horaIngre.Value = Convert.ToDateTime(data.Rows[0]["HoEntrada"]);
            dtp_horaSalida.Value = Convert.ToDateTime(data.Rows[0]["HoSalida"]);
            dtp_hora_tolercia.Value = Convert.ToDateTime(data.Rows[0]["MiTolrncia"]);
            Dtp_Hora_Limite.Value = Convert.ToDateTime(data.Rows[0]["HoLimite"]);


        }

        private void bt_Config_Click(object sender, EventArgs e)
        {
            elTabPage4.Visible = true;
            elTab1.SelectedTabPageIndex = 3;
            CargarHorarios();
        }


        #region ASISTENCIA

        private void ConfiguraListview_Asis()
        {
            var lis = lsv_asis;
            lis.Columns.Clear();
            lis.Items.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            lis.Columns.Add("Id Asis", 0, HorizontalAlignment.Left);
            lis.Columns.Add("DOC", 80, HorizontalAlignment.Left);
            lis.Columns.Add("Nombres del Personal", 316, HorizontalAlignment.Left);
            lis.Columns.Add("Fecha", 90, HorizontalAlignment.Left);
            lis.Columns.Add("Dia", 80, HorizontalAlignment.Left);
            lis.Columns.Add("Ho Ingreso", 90, HorizontalAlignment.Left);
            lis.Columns.Add("Tardnza", 70, HorizontalAlignment.Left);
            lis.Columns.Add("Ho Salida", 90, HorizontalAlignment.Left);
            lis.Columns.Add("Adelante", 90, HorizontalAlignment.Left);
            lis.Columns.Add("Justificacion", 0, HorizontalAlignment.Left);
            lis.Columns.Add("Estado", 100, HorizontalAlignment.Left);


        }

        private void LlenarListview_Asis(DataTable data)
        {
            lsv_asis.Items.Clear();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_asis"].ToString());
                list.SubItems.Add(dr["DOC"].ToString());
                list.SubItems.Add(dr["Nombre_Completo"].ToString());
                list.SubItems.Add(dr["FechaAsis"].ToString());
                list.SubItems.Add(dr["Nombre_dia"].ToString());
                list.SubItems.Add(dr["Hoingreso"].ToString());
                list.SubItems.Add(dr["Tardanzas"].ToString());
                list.SubItems.Add(dr["HoSalida"].ToString());
                list.SubItems.Add(dr["Adelanto"].ToString());

                list.SubItems.Add(dr["Justifacion"].ToString());
                list.SubItems.Add(dr["EstadoAsis"].ToString());
                lsv_asis.Items.Add(list);
            }
            Lbl_total.Text = Convert.ToString(lsv_asis.Items.Count);
        }


        private void Cargar_todasAsistencias()
        {
            RN_Asistencia obj = new RN_Asistencia();
            DataTable dt = new DataTable();
            dt = obj.RN_Ver_Todas_Asistencia();
            if (dt.Rows.Count > 0)
            {
                LlenarListview_Asis(dt);
            }
        }


        private void Cargar_todasAsistencias_delDia(DateTime fechas)
        {
            RN_Asistencia obj = new RN_Asistencia();
            DataTable dt = new DataTable();
            dt = obj.RN_Ver_Todas_Asistencia_DelDia(fechas);
            if (dt.Rows.Count > 0)
            {
                LlenarListview_Asis(dt);
            }
        }

        private void Cargar_todasAsistencias_delMes(DateTime fechas)
        {
            RN_Asistencia obj = new RN_Asistencia();
            DataTable dt = new DataTable();
            dt = obj.RN_Ver_Todas_Asistencia_DelMes(fechas);
            if (dt.Rows.Count > 0)
            {
                LlenarListview_Asis(dt);
            }
        }


        private void Cargar_todasAsistencias_porValor(string xvalor)
        {
            RN_Asistencia obj = new RN_Asistencia();
            DataTable dt = new DataTable();
            dt = obj.RN_Ver_Todas_Asistencia_ParaExplorador(xvalor);
            if (dt.Rows.Count > 0)
            {
                LlenarListview_Asis(dt);
            }
        }


        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Cargar_todasAsistencias();
        }

        private void txt_buscarAsis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
                Cargar_todasAsistencias_porValor(txt_buscarAsis.Text);
            }
        }

        private void lbl_lupaAsis_Click(object sender, EventArgs e)
        {
            Cargar_todasAsistencias();
        }


      


        #endregion

        private void bt_registrarHuellaDigital_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Regis_Huella per = new Frm_Regis_Huella();

            //Obtener el ID personal
            if (lsv_person.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Selecciona al Personal para Registrar su Huella ", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                var lsv = lsv_person.SelectedItems[0];
                string xidsocio = lsv.SubItems[0].Text;

                fil.Show();
                per.Buscar_Personal_ParaEditar(xidsocio);
                per.ShowDialog();
                fil.Hide();

                if (Convert.ToString(per.Tag) == "")
                    return;
                {
                    Cargar_todo_Personal();
                }

           
            }
        }

        private void btn_Savedrobot_Click(object sender, EventArgs e)
        {
            RN_Utilitario uti = new RN_Utilitario();
            if (rdb_ActivarRobot.Checked==true)
            {
                uti.RN_Actulizar_RobotFalta(5, "Si");
                if(BD_Utilitario.falta==true)
                {
                    Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
                    ok.Lbl_msm1.Text = "El Robot fue Actulizado";
                    ok.ShowDialog();

                    elTab1.SelectedTabPageIndex = 0;
                    elTabPage4.Visible = false;
                }
            }
            else if(rdb_Desact_Robot.Checked==true)
            {
                uti.RN_Actulizar_RobotFalta(5, "No");

                if (BD_Utilitario.falta == true)
                {
                    Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
                    ok.Lbl_msm1.Text = "El Robot fue Actulizado";
                    ok.ShowDialog();

                    elTab1.SelectedTabPageIndex = 0;
                    elTabPage4.Visible = false;
                }

            }
        }

        private void btn_Asis_With_Huella_Click(object sender, EventArgs e)
        {
            Frm_Filtro fis = new Frm_Filtro();
            Frm_Marcar_Asistencia asis = new Frm_Marcar_Asistencia();
            fis.Show();
            asis.ShowDialog();
            fis.Hide();
        }

        private void timerFalta_Tick(object sender, EventArgs e)
        {
            RN_Asistencia obj = new RN_Asistencia();
            Frm_Filtro fis = new Frm_Filtro();
            Frm_Advertencia adver = new Frm_Advertencia();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            DataTable dataper = new DataTable();
            RN_Personal objper = new RN_Personal();

            int Holimite = Dtp_Hora_Limite.Value.Hour;
            int MiLimite = Dtp_Hora_Limite.Value.Minute;

            int horaCaptu = DateTime.Now.Hour;
            int minutoCaptu = DateTime.Now.Minute;
            string Docper = "";
            int Cant = 0;
            int TotalItem = 0;
            string xidpersona = "";
            string IdAsistencia = "";
            string xjustificacion = "";

            if (horaCaptu>=Holimite)
            {
                if(minutoCaptu>MiLimite)
                {
                    dataper = objper.RN_Leer_todoPersona();
                    if (dataper.Rows.Count <= 0) return;
                    TotalItem = dataper.Rows.Count;
                    foreach(DataRow Registro in dataper.Rows)
                    {
                        Docper = Convert.ToString(Registro["DOC"]);
                        xidpersona = Convert.ToString(Registro["Id_Pernl"]);
                        if(obj.RN_Checar_SiPersonal_TieneAsistencia_Registrada(xidpersona.Trim())==false)
                        {
                            if(obj.RN_Checar_SiPersonal_YaMarco_suFalta(xidpersona.Trim())==false)
                            {
                                RN_Asistencia objA = new RN_Asistencia();
                                EN_Asistencia asi = new EN_Asistencia();

                                IdAsistencia = RN_Utilitario.RN_NroDoc(3);

                                if(objA.RN_Verificar_Justificacion_Aprobado(xidpersona)==true)
                                {
                                    xjustificacion = "Falta tiene Justificacion";

                                }
                                else
                                {
                                    xjustificacion = "No tiene justificacion";

                                }
                                obj.RN_Registrar_Falta_Personal(IdAsistencia, xidpersona, xjustificacion);
                                if(BD_Asistencia.faltasaved==true)
                                {
                                    RN_Utilitario.RN_Actualiza_Tipo_Doc(3);
                                    Cant += 1;
                                }


                            }

                        }
                    }
                    if(Cant>1)
                    {
                        timerFalta.Stop();
                        fis.Show();
                        ok.Lbl_msm1.Text = "Un Total de: " + Cant.ToString() + "/" + TotalItem + " Faltas se ha Registrado Exitosamente";
                        ok.ShowDialog();
                        fis.Hide();
                    }
                    else
                    {
                        timerFalta.Stop();
                        fis.Show();
                        ok.Lbl_msm1.Text = "El dia de Hoy no Falo nadie al trabajo, Las " + TotalItem + " Personas Marcaron su Asitencia";
                        ok.ShowDialog();
                        fis.Hide();
                    }
                }
            }

        }

 

        private void bt_imprimirAsistenciaDelMes_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_PrintAsis_deldia asis = new Frm_PrintAsis_deldia();

            Frm_Solo_Fecha solo = new Frm_Solo_Fecha();

            fil.Show();
            solo.ShowDialog();
            fil.Hide();

            if (solo.Tag.ToString() == "") return;

            DateTime xdia = solo.dtp_fecha.Value;

            fil.Show();

            asis.tipoinfo = "delmes";
            asis.Tag = xdia;
            asis.ShowDialog();
            fil.Hide();
        }

        private void bt_imprimirAsistenciaPorPersonal_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Print_Asistencia asis = new Frm_Print_Asistencia();

            Frm_Solo_Personal_Fecha solo = new Frm_Solo_Personal_Fecha();
                    

            fil.Show();
            solo.ShowDialog();
            fil.Hide();                             
        
            string idper =  Convert.ToString(solo.cbo_person.SelectedValue);

            if (solo.Tag.ToString() == "") return;
  
            DateTime xdia = solo.dtp_fecha.Value;           
            

            fil.Show();
            asis.CualImprimir = idper;
            asis.Tag = xdia;
            asis.ShowDialog();
            fil.Hide();
        }


       




        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_PrintAsis_deldia asis = new Frm_PrintAsis_deldia();

            Frm_Solo_Fecha solo = new Frm_Solo_Fecha();

            fil.Show();
            solo.ShowDialog();
            fil.Hide();

            if (solo.Tag.ToString() == "") return;

            DateTime xdia = solo.dtp_fecha.Value;

            fil.Show();

            asis.tipoinfo = "deldia";
            asis.Tag = xdia;
            asis.ShowDialog();
            fil.Hide();
        }

        private void bt_cerrarjusti_Click(object sender, EventArgs e)
        {
            elTabPage5.Visible = false;
            elTabPage1.Visible = true;
            elTab1.SelectedTabPageIndex = 0;
        }

        private void btn_cancel_horio_Click(object sender, EventArgs e)
        {
            elTabPage4.Visible = false;
            elTab1.SelectedTabPageIndex = 0;
        }


        #region TODO DE JUASTIFICACION
        private void ConfiguraListview_Justifi()
        {
            var lis = lsv_justifi;
            lis.Columns.Clear();
            lis.Items.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;

            lis.Columns.Add("Idjusti", 0, HorizontalAlignment.Left);
            lis.Columns.Add("IdPerso", 0, HorizontalAlignment.Left);
            lis.Columns.Add("Nombres del Personal", 316, HorizontalAlignment.Left);
            lis.Columns.Add("Motivo",110, HorizontalAlignment.Left);
            lis.Columns.Add("Fecha", 120, HorizontalAlignment.Left);
            lis.Columns.Add("Fecha", 120, HorizontalAlignment.Left);
            lis.Columns.Add("Estado", 120, HorizontalAlignment.Left);
            lis.Columns.Add("Detalle Justifi", 0, HorizontalAlignment.Left);
        }

        private void LlenarListview_Justi(DataTable data)
        {
            lsv_justifi.Items.Clear();
            for (int i=0;i<data.Rows.Count;i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_justi"].ToString());
                list.SubItems.Add(dr["Id_Pernl"].ToString());
                list.SubItems.Add(dr["Nombre_Completo"].ToString());
                list.SubItems.Add(dr["PrincipalMotivo"].ToString());
                list.SubItems.Add(dr["FechaEmi"].ToString());
                list.SubItems.Add(dr["FechaJusti"].ToString());
                list.SubItems.Add(dr["EstadoJus"].ToString());
                list.SubItems.Add(dr["Detalle_Justi"].ToString());

                lsv_justifi.Items.Add(list);

            }
            lbl_totaljusti.Text = Convert.ToString(lsv_justifi.Items.Count);
        }

        private void Cargar_todas_Justificaciones()
        {
            RN_Justificacion obj = new RN_Justificacion();
            DataTable dt = new DataTable();

            dt = obj.RN_Cargar_Todos_Justificacion();
            if (dt.Rows.Count > 0)
            {
                LlenarListview_Justi(dt);

            }
            else
            {
                lsv_justifi.Items.Clear();
            }

        }

        private void Buscar_Justificacio_porValor(string xvalor)
        {
            RN_Justificacion obj = new RN_Justificacion();
            DataTable dt = new DataTable();
            dt = obj.RN_BuscarJustificacion_porValor(xvalor.Trim());
            if (dt.Rows.Count>0)
            {
                LlenarListview_Justi(dt);

            }
            else { lsv_justifi.Items.Clear(); }
        }
        


        private void bt_mostrarJusti_Click(object sender, EventArgs e)
        {
            Cargar_todas_Justificaciones();
        }

        private void bt_editJusti_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Reg_Justificacion per = new Frm_Reg_Justificacion();

            if (lsv_justifi.SelectedIndices.Count==0)
            {
                fil.Show();
                MessageBox.Show("Selecciona un Item por Favor ", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                fil.Hide();
            }
            else
            {
                var lsv = lsv_justifi.SelectedItems[0];
                string xidsocio = lsv.SubItems[1].Text;
                string xidJusti = lsv.SubItems[0].Text;
                string xnombre= lsv.SubItems[2].Text;

                fil.Show();
                per.xedit = false;
                per.txt_IdPersona.Text = xidsocio;
                per.txt_nompersona.Text = xnombre;
                per.txt_idjusti.Text = xidJusti;
                per.BuscarJustificacion(xidJusti);
                per.ShowDialog();
                fil.Hide();
                if (Convert.ToString(per.Tag) == "")
                    return;
                {
                    Cargar_todas_Justificaciones();
                    elTab1.SelectedTabPageIndex = 4;
                    elTabPage5.Visible = true;

                } 
            }
        }
        #endregion

        private void bt_solicitarJustificacion_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Reg_Justificacion per = new Frm_Reg_Justificacion();

            if (lsv_person.SelectedIndices.Count == 0)
            {
                fil.Show();
                MessageBox.Show("Selecciona un Personal para Solicitar una Justificacion por Favor ", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                fil.Hide();
            }
            else
            {
                var lsv = lsv_person.SelectedItems[0];
                string xidsocio = lsv.SubItems[0].Text;             
                string xnombre = lsv.SubItems[2].Text;

                fil.Show();
                per.xedit = false;
                per.txt_IdPersona.Text = xidsocio;
                per.txt_nompersona.Text = xnombre;
                per.txt_idjusti.Text = RN_Utilitario.RN_NroDoc(4);         
                per.ShowDialog();
                fil.Hide();
                if (Convert.ToString(per.Tag) == "")
                    return;
                {
                    Cargar_todas_Justificaciones();
                    elTab1.SelectedTabPageIndex = 4;
                    elTabPage5.Visible = true;

                }
            }
        }

        private void bt_aprobarJustificacion_Click(object sender, EventArgs e)
        {
            Frm_Advertencia adver = new Frm_Advertencia();
            Frm_Sino sino = new Frm_Sino();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            Frm_Filtro fil = new Frm_Filtro();
            RN_Justificacion obj = new RN_Justificacion();

            if (lsv_justifi.SelectedIndices.Count == 0)
            {
                fil.Show();
                adver.Lbl_Msm1.Text = "Seleccione el Item que Desea Aprobar";
                adver.ShowDialog();
                fil.Hide();return;
            }
            else
            {
                var lsv = lsv_justifi.SelectedItems[0];
                string xidjus = lsv.SubItems[0].Text;
                string xidper = lsv.SubItems[1].Text;
                string xstadojus = lsv.SubItems[6].Text;
                if (xstadojus.Trim() == "Aprobado") { fil.Show();
                    adver.Lbl_Msm1.Text = "La Justificacion Selecionada, ya Fue Aprobada";
                    adver.ShowDialog();
                    fil.Hide();
                    return; 
                }
                sino.Lbl_msm1.Text = "Estas Seguro de Aprobar la Justificacion?";
                fil.Show();
                sino.ShowDialog();
                fil.Hide();

                if(Convert.ToString(sino.Tag)=="Si")
                {
                    obj.RN_Aprobar_Justificacion(xidjus, xidper);
                    if(BD_Justificacion.tryed==true)
                    {
                        fil.Show();
                        ok.Lbl_msm1.Text = "Justifiacion Aprobada";
                        ok.ShowDialog();
                        fil.Hide();
                        Buscar_Justificacio_porValor(xidjus);
                    }
                }
            }
            }

        private void bt_desaprobarJustificacion_Click(object sender, EventArgs e)
        {
            Frm_Advertencia adver = new Frm_Advertencia();
            Frm_Sino sino = new Frm_Sino();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            Frm_Filtro fil = new Frm_Filtro();
            RN_Justificacion obj = new RN_Justificacion();

            if (lsv_justifi.SelectedIndices.Count == 0)
            {
                fil.Show();
                adver.Lbl_Msm1.Text = "Seleccione el Item que Desea Desaprobar";
                adver.ShowDialog();
                fil.Hide(); return;
            }
            else
            {
                var lsv = lsv_justifi.SelectedItems[0];
                string xidjus = lsv.SubItems[0].Text;
                string xidper = lsv.SubItems[1].Text;
                string xstadojus = lsv.SubItems[6].Text;
                if (xstadojus.Trim() == "Falta Aprobar")
                {
                    fil.Show();
                    adver.Lbl_Msm1.Text = "La Justificacion Selecionada, aun no Fue Aprobada";
                    adver.ShowDialog(); 
                    fil.Hide();
                    return;
                }
                sino.Lbl_msm1.Text = "Estas Seguro de Desaprobar la Justificacion?"+"\n\r"+" - Recuerda que este proceso es bajo su entera Responsabilidad";
                fil.Show();
                sino.ShowDialog();
                fil.Hide();

                if (Convert.ToString(sino.Tag) == "Si")
                {
                    obj.RN_Desaprobar_Justificacion(xidjus, xidper);
                    if (BD_Justificacion.tryed == true)
                    {
                        fil.Show();
                        ok.Lbl_msm1.Text = "Justifiacion Pendiente de Aprobacion";
                        ok.ShowDialog();
                        fil.Hide();
                        Buscar_Justificacio_porValor(xidjus);
                    }
                }
            }
        }

        private void bt_ElimiJusti_Click(object sender, EventArgs e)
        {
            Frm_Advertencia adver = new Frm_Advertencia();
            Frm_Sino sino = new Frm_Sino();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            Frm_Filtro fil = new Frm_Filtro();
            RN_Justificacion obj = new RN_Justificacion();

            if (lsv_justifi.SelectedIndices.Count == 0)
            {
                fil.Show();
                adver.Lbl_Msm1.Text = "Seleccione el Item que Deseas Eliminar";
                adver.ShowDialog();
                fil.Hide(); return;
            }
            else
            {
                var lsv = lsv_justifi.SelectedItems[0];
                string xidjus = lsv.SubItems[0].Text;

                sino.Lbl_msm1.Text = "Estas Seguro de Eliminar la Justificacion?" + "\n\r" + " - Recuerda que este proceso es bajo su entera Responsabilidad";
                fil.Show();
                sino.ShowDialog();
                fil.Hide();

              

                if (Convert.ToString(sino.Tag) == "Si")
                {
                    obj.RN_Eliminar_Justificacion(xidjus);
                    if (BD_Justificacion.tryed == true)
                    {
                        fil.Show();
                        ok.Lbl_msm1.Text = "Justifiacion Eliminada";
                        ok.ShowDialog();
                        fil.Hide();
                        Buscar_Justificacio_porValor(xidjus);
                    }
                }
            }
        }

        private void bt_CopiarNroJusti_Click(object sender, EventArgs e)
        {
            Frm_Advertencia adver = new Frm_Advertencia();
            Frm_Filtro fis = new Frm_Filtro();

            if (lsv_justifi.SelectedIndices.Count == 0)
            {
                fis.Show();
                adver.Lbl_Msm1.Text = "Seleccione el Item que Deseas Copiar";
                adver.ShowDialog();
                fis.Hide();
                return;

            }
            else
            {
                var lsv = lsv_justifi.SelectedItems[0];
                string xci = lsv.SubItems[0].Text;

                Clipboard.Clear();
                Clipboard.SetText(xci.Trim());

            }
        }

        private void txt_buscarjusti_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if (txt_buscarjusti.Text.Trim().Length>1)
                {
                    Buscar_Justificacio_porValor(txt_buscarjusti.Text);
                }
                else
                {
                    Cargar_todas_Justificaciones();
                }
               
            }
        }

        private void lsv_justifi_MouseClick(object sender, MouseEventArgs e)
        {
            var lsv = lsv_justifi.SelectedItems[0];
            string xnombre = lsv.SubItems[7].Text;

            lbl_Detalle.Text = xnombre.Trim();
        }

        private void bt_exploJusti_Click(object sender, EventArgs e)
        {
            elTab1.SelectedTabPageIndex = 4;
            elTabPage5.Visible = true;
            Cargar_todas_Justificaciones();
        }

        private void Btn_EditPerso_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Registro_Personal per = new Frm_Registro_Personal();

            if (lsv_person.SelectedIndices.Count == 0)
            {
                fil.Show();
                MessageBox.Show("Selecciona un Personal para Editar ", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                fil.Hide();
            }
            else
            {
                var lsv = lsv_person.SelectedItems[0];
                string idpersona = lsv.SubItems[0].Text;
                fil.Show();
                per.saveeditar = true;
                per.Buscar_Personal_ParaEditar(idpersona);
                per.ShowDialog();
                fil.Hide();
                if (Convert.ToString(per.Tag) == "A")
                {
                    Cargar_todo_Personal();
                }
            }
        }

        private void btn_VerTodoPerso_Click(object sender, EventArgs e)
        {
            Cargar_todo_Personal();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Frm_Advertencia adver = new Frm_Advertencia();
            Frm_Filtro fis = new Frm_Filtro();

            if (lsv_asis.SelectedIndices.Count == 0)
            {
                fis.Show();
                adver.Lbl_Msm1.Text = "Seleccione el Item que Deseas Copiar";
                adver.ShowDialog();
                fis.Hide();
                return;

            }
            else
            {
                var lsv = lsv_asis.SelectedItems[0];
                string xci = lsv.SubItems[1].Text;

                Clipboard.Clear();
                Clipboard.SetText(xci.Trim());

            }
        }
             

        private void bt_eliminarPersonal_Click(object sender, EventArgs e)
        {
            Frm_Advertencia adver = new Frm_Advertencia();
            Frm_Sino sino = new Frm_Sino();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            Frm_Filtro fil = new Frm_Filtro();
            RN_Personal obj = new RN_Personal();

            if (lsv_person.SelectedIndices.Count == 0)
            {
                fil.Show();
                adver.Lbl_Msm1.Text = "Seleccione al Personal que Deseas Eliminar";
                adver.ShowDialog();
                fil.Hide(); return;
            }
            else
            {
                var lsv = lsv_person.SelectedItems[0];
                string xDoc = lsv.SubItems[1].Text;

                sino.Lbl_msm1.Text = "Estas Seguro de Eliminar al Personal?" + "\n\r" + " - Recuerda que este proceso es bajo su entera Responsabilidad";
                fil.Show();
                sino.ShowDialog();
                fil.Hide();



                if (Convert.ToString(sino.Tag) == "Si")
                {
                    obj.RN_Eliminar_Personal(xDoc);
                    if (BD_Personal.supresed == true)
                    {
                        fil.Show();
                        ok.Lbl_msm1.Text = "Personal Eliminado";
                        ok.ShowDialog();
                        fil.Hide();
                        Cargar_todo_Personal();
                    }
                }
            }
        }

        private void verAsistenciaDelDia_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Solo_Fecha solo = new Frm_Solo_Fecha();

            fil.Show();
            solo.ShowDialog();
            fil.Hide();

            if (Convert.ToString(solo.Tag) == "") return;
            DateTime xfecha = solo.dtp_fecha.Value;
            Cargar_todasAsistencias_delDia(xfecha);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Frm_Advertencia adver = new Frm_Advertencia();
            Frm_Sino sino = new Frm_Sino();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            Frm_Filtro fil = new Frm_Filtro();
            RN_Asistencia obj = new RN_Asistencia();

            if (lsv_asis.SelectedIndices.Count == 0)
            {
                fil.Show();
                adver.Lbl_Msm1.Text = "Seleccione el Item que Deseas Eliminar";
                adver.ShowDialog();
                fil.Hide(); return;
            }
            else
            {
                var lsv = lsv_asis.SelectedItems[0];
                string xidAsis = lsv.SubItems[0].Text;

                sino.Lbl_msm1.Text = "Estas Seguro de Eliminar la Asistencia?" + "\n\r" + " - Recuerda que este proceso es bajo su entera Responsabilidad";
                fil.Show();
                sino.ShowDialog();
                fil.Hide();



                if (Convert.ToString(sino.Tag) == "Si")
                {
                    obj.RN_Eliminar_Asistencia(xidAsis);
                    if (BD_Asistencia.supresed == true)
                    {
                        fil.Show();
                        ok.Lbl_msm1.Text = "Asistencia Eliminada";
                        ok.ShowDialog();
                        fil.Hide();
                        Cargar_todasAsistencias_delDia(dtp_fechadeldia.Value);
                    }
                }
            }
        }

        private void bt_regFalta_Click(object sender, EventArgs e)
        {
            RN_Asistencia obj = new RN_Asistencia();
            Frm_Filtro fis = new Frm_Filtro();
            Frm_Advertencia adver = new Frm_Advertencia();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            DataTable dataper = new DataTable();
            RN_Personal objper = new RN_Personal();

            int Holimite = Dtp_Hora_Limite.Value.Hour;
            int MiLimite = Dtp_Hora_Limite.Value.Minute;

            int horaCaptu = DateTime.Now.Hour;
            int minutoCaptu = DateTime.Now.Minute;
            string Docper = "";
            int Cant = 0;
            int TotalItem = 0;
            string xidpersona = "";
            string IdAsistencia = "";
            string xjustificacion = "";

            if (horaCaptu >= Holimite)
            {
                if (minutoCaptu > MiLimite)
                {
                    dataper = objper.RN_Leer_todoPersona();
                    if (dataper.Rows.Count <= 0) return;
                    TotalItem = dataper.Rows.Count;
                    foreach (DataRow Registro in dataper.Rows)
                    {
                        Docper = Convert.ToString(Registro["DOC"]);
                        xidpersona = Convert.ToString(Registro["Id_Pernl"]);
                        if (obj.RN_Checar_SiPersonal_TieneAsistencia_Registrada(xidpersona.Trim()) == false)
                        {
                            if (obj.RN_Checar_SiPersonal_YaMarco_suFalta(xidpersona.Trim()) == false)
                            {
                                RN_Asistencia objA = new RN_Asistencia();
                                EN_Asistencia asi = new EN_Asistencia();

                                IdAsistencia = RN_Utilitario.RN_NroDoc(3);

                                if (objA.RN_Verificar_Justificacion_Aprobado(xidpersona) == true)
                                {
                                    xjustificacion = "Falta tiene Justificacion";

                                }
                                else
                                {
                                    xjustificacion = "No tiene justificacion";

                                }
                                obj.RN_Registrar_Falta_Personal(IdAsistencia, xidpersona, xjustificacion);
                                if (BD_Asistencia.faltasaved == true)
                                {
                                    RN_Utilitario.RN_Actualiza_Tipo_Doc(3);
                                    Cant += 1;
                                }


                            }

                        }
                    }
                    if (Cant >= 1)
                    {
                        timerFalta.Stop();
                        fis.Show();
                        ok.Lbl_msm1.Text = "Un Total de: " + Cant.ToString() + "/" + TotalItem + " Faltas se ha Registrado Exitosamente";
                        ok.ShowDialog();
                        fis.Hide();

                        lbl_Cont.Text = Cant.ToString();
                        lbl_totalPer.Text =Convert.ToString(TotalItem);

                    }
                    else
                    {
                        timerFalta.Stop();
                        fis.Show();
                        ok.Lbl_msm1.Text = "El dia de Hoy no Falo nadie al trabajo, Las " + TotalItem + " Personas Marcaron su Asitencia";
                        ok.ShowDialog();
                        fis.Hide();
                    }
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Marcar_Asis_Manual asis = new Frm_Marcar_Asis_Manual();

            fil.Show();
            asis.ShowDialog();
            fil.Hide();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Frm_Filtro fis = new Frm_Filtro();
            Frm_Marcar_Asistencia asis = new Frm_Marcar_Asistencia();
            fis.Show();
            asis.ShowDialog();
            fis.Hide();
        }

     


        private void Cargar_todo_Usuario()
        {
            RN_Usuario obj = new RN_Usuario();
            DataTable dt = new DataTable();

            dt = obj.RN_Leer_todoUsuario();
            if (dt.Rows.Count > 0)
            {
                LlenarListviewUser(dt);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            elTabPage6.Visible = false;
            elTab1.SelectedTabPageIndex = 0;
          
        }

        private void bt_copiarNroDoc_Click(object sender, EventArgs e)
        {
            Frm_Advertencia adver = new Frm_Advertencia();
            Frm_Filtro fis = new Frm_Filtro();

            if (lsv_person.SelectedIndices.Count == 0)
            {
                fis.Show();
                adver.Lbl_Msm1.Text = "Seleccione el Item que Deseas Copiar";
                adver.ShowDialog();
                fis.Hide();
                return;

            }
            else
            {
                var lsv = lsv_person.SelectedItems[0];
                string xDOC = lsv.SubItems[1].Text;

                Clipboard.Clear();
                Clipboard.SetText(xDOC.Trim());

            }
        }




        private void LlenarListviewUser(DataTable data)
        {
            listViewUsuario.Items.Clear();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_Usu"].ToString());
                list.SubItems.Add(dr["Nombre_Completo"].ToString());
                list.SubItems.Add(dr["Avatar"].ToString());
                list.SubItems.Add(dr["Nom_Usuario"].ToString());
                list.SubItems.Add(dr["Password"].ToString());           
                list.SubItems.Add(dr["Estado_USu"].ToString());            
                list.SubItems.Add(dr["NomRol"].ToString());
                listViewUsuario.Items.Add(list);
            }
            labeltotal.Text = Convert.ToString(listViewUsuario.Items.Count);
        }



        private void ConfigurarListviewUser()
        {
            var lis = listViewUsuario;
            lis.Columns.Clear();
            lis.Items.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            lis.Columns.Add("Id Persona", 0, HorizontalAlignment.Left);       
            lis.Columns.Add("Nombres del Usuario", 260, HorizontalAlignment.Left);
            lis.Columns.Add("Avatar", 0, HorizontalAlignment.Left);
            lis.Columns.Add("Usuario", 115, HorizontalAlignment.Left);
            lis.Columns.Add("Contraseña",115, HorizontalAlignment.Left);
            lis.Columns.Add(" Estado", 100, HorizontalAlignment.Center);
            lis.Columns.Add("Privilegio", 130, HorizontalAlignment.Center);

        }

    

        private void buttonUserMod_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Form_Usuario user = new Form_Usuario();

            if (listViewUsuario.SelectedIndices.Count == 0)
            {
                fil.Show();
                MessageBox.Show("Selecciona un Usuario para Editar ", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                fil.Hide();
            }
            else
            {
                var lsv = listViewUsuario.SelectedItems[0];
                string idUsuarios = lsv.SubItems[0].Text;
                fil.Show();
                user.saveeditar = true;
                user.Buscar_Usuario_ParaEditar(idUsuarios);
                user.ShowDialog();
                fil.Hide();
                if (Convert.ToString(user.Tag) == "A")
                {
                    Cargar_todo_Usuario();
                }
            }
        }

      
    

        private void buttonUserAdd_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Form_Usuario per = new Form_Usuario();

            fil.Show();
            per.xedit = false;
            per.ShowDialog();

            fil.Hide();
            if (Convert.ToString(per.Tag) == "") return;
            {
                Cargar_todo_Usuario();
            }
        }

        private void toolStripNuevoUsuario_Click(object sender, EventArgs e)
        {
            Frm_Filtro fil = new Frm_Filtro();
            Form_Usuario Usuario = new Form_Usuario();

            fil.Show();

            Usuario.ShowDialog();

            fil.Hide();
            if (Convert.ToString(Usuario.Tag) == "") return;
            {
                Cargar_todo_Usuario();
            }
        }

        private void toolStripIEditarUsuario_Click(object sender, EventArgs e)
        {

            Frm_Filtro fil = new Frm_Filtro();
            Form_Usuario user = new Form_Usuario();

            if (listViewUsuario.SelectedIndices.Count == 0)
            {
                fil.Show();
                MessageBox.Show("Selecciona un Personal para Editar ", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                fil.Hide();
            }
            else
            {
                var lsv = listViewUsuario.SelectedItems[0];
                string idUsuarios = lsv.SubItems[0].Text;
                fil.Show();
                user.saveeditar = true;
                user.Buscar_Usuario_ParaEditar(idUsuarios);
                user.ShowDialog();
                fil.Hide();
                if (Convert.ToString(user.Tag) == "A")
                {
                    Cargar_todo_Usuario();
                }
            }
        }

        private void toolStripActualizarUsuario_Click(object sender, EventArgs e)
        {
            Cargar_todo_Usuario();
        }

        private void buttonActulizar_Click(object sender, EventArgs e)
        {
            Cargar_todo_Usuario();

        }

        private void toolStripEliminarUsuario_Click(object sender, EventArgs e)
        {
            Frm_Advertencia adver = new Frm_Advertencia();
            Frm_Sino sino = new Frm_Sino();
            Frm_Msm_Bueno ok = new Frm_Msm_Bueno();
            Frm_Filtro fil = new Frm_Filtro();
            RN_Usuario obj = new RN_Usuario();

            if (listViewUsuario.SelectedIndices.Count == 0)
            {
                fil.Show();
                adver.Lbl_Msm1.Text = "Seleccione al Usuario que Deseas Eliminar";
                adver.ShowDialog();
                fil.Hide(); return;
            }
            else
            {
                var lsv = listViewUsuario.SelectedItems[0];
                string xid = lsv.SubItems[0].Text;

                sino.Lbl_msm1.Text = "Estas Seguro de Eliminar al Usuario?" + "\n\r" + " - Recuerda que este proceso es bajo su entera Responsabilidad";
                fil.Show();
                sino.ShowDialog();
                fil.Hide();



                if (Convert.ToString(sino.Tag) == "Si")
                {
                    obj.RN_Eliminar_Usuario(xid);
                    if (BD_usuario.supresed == true)
                    {
                        fil.Show();
                        ok.Lbl_msm1.Text = "Usuario Eliminado";
                        ok.ShowDialog();
                        fil.Hide();
                        Cargar_todo_Usuario();
                    }
                }
            }
        }

        private void elButtonUser_Click(object sender, EventArgs e)
        {
            elTabPage6.Visible = true;
            elTab1.SelectedTabPageIndex = 5;
            Cargar_todo_Usuario();
        }

        private void elTabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void elTab1_Click(object sender, EventArgs e)
        {

        }

        private void pic_user_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_NomUsu_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_rolNom_Click(object sender, EventArgs e)
        {

        }
    }
}
