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
using System.IO;



namespace MicroSisPlani
{
    public partial class Frm_Marcar_Asis_Manual : Form
    {
        public Frm_Marcar_Asis_Manual()
        {
            InitializeComponent();
        }

        private void Frm_Marcar_Asis_Manual_Load(object sender, EventArgs e)
        {

            CargarHorarios();
            txt_doc_Buscar.Focus();

        }

        private void CargarHorarios()
        {
            RN_Horario obj = new RN_Horario();
            DataTable data = new DataTable();

            data = obj.RN_Leer_Horario();
            if (data.Rows.Count == 0) return;

            dtp_horaIngre.Value = Convert.ToDateTime(data.Rows[0]["HoEntrada"]);
            Lbl_HoraEntrada.Text = dtp_horaIngre.Value.Hour.ToString() + ":" + dtp_horaIngre.Value.Minute.ToString();
            dtp_horaSalida.Value = Convert.ToDateTime(data.Rows[0]["HoSalida"]);
            dtp_hora_tolercia.Value = Convert.ToDateTime(data.Rows[0]["Mitolrncia"]);
            Dtp_Hora_Limite.Value = Convert.ToDateTime(data.Rows[0]["Holimite"]);
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            RN_Personal obj = new RN_Personal();
            RN_Asistencia objas = new RN_Asistencia();
            DataTable datosPersona = new DataTable();
            DataTable dataAsis = new DataTable();
            Frm_Filtro fil = new Frm_Filtro();
            Frm_Advertencia ver = new Frm_Advertencia();

            string NroIDPersona;
            //int cont = 1;
            string rutaFoto;

            int Holimite = Dtp_Hora_Limite.Value.Hour;
            int MiLimite = Dtp_Hora_Limite.Value.Minute;

            int horaCaptu = DateTime.Now.Hour;
            int minutoCaptu = DateTime.Now.Minute;
            try
            {
                datosPersona = obj.RN_Buscar_Personal_xValor(txt_doc_Buscar.Text.Trim());
                if (datosPersona.Rows.Count <= 0)
                {
                    lbl_msm.BackColor = Color.MistyRose;
                    lbl_msm.ForeColor = Color.Red;
                    lbl_msm.Text = "El Numero de Documento ingresado no Existe o el Personal esta dado de Baja";
                    tocar_timbreErroeno();
                    lbl_Cont.Text = "10";
                   
                    pnl_Msm.Visible = true;
                    tmr_Conta.Enabled = true;
                    return;
                }
                else
                {
                    var dt = datosPersona.Rows[0];
                    rutaFoto = Convert.ToString(dt["Foto"]);
                    lbl_nombresocio.Text = Convert.ToString(dt["NOmbre_Completo"]);
                    lbl_Doc.Text = Convert.ToString(dt["DOC"]);
                    NroIDPersona = Convert.ToString(dt["Id_Pernl"]);
                    Lbl_Idperso.Text = Convert.ToString(dt["Id_Pernl"]);

                    if (File.Exists(rutaFoto) == true)
                    {
                        picSocio.Load(rutaFoto.Trim());
                    }
                    else
                    {
                        picSocio.Load(Application.StartupPath + @"\user.png");
                    }
                    if (objas.RN_Checar_SiPersonal_YaMarco_Asistencia(Lbl_Idperso.Text)==true)
                    {
                        lbl_msm.BackColor = Color.MistyRose;
                        lbl_msm.ForeColor = Color.Red;
                        lbl_msm.Text = "El Sistemas Verifico, que el Personal ya marco su Entrada y Salida";
                        tocar_timbre();
                        lbl_Cont.Text = "10";

                        pnl_Msm.Visible = true;
                        tmr_Conta.Enabled = true;
                        return;
                    }
                    if (objas.RN_Checar_SiPersonal_YaMarco_suEntrada(Lbl_Idperso.Text.Trim()) == true)
                    {                      
                        //le toca marcar su salida
                        dataAsis = objas.RN_Buscar_Asistencia_deEntrada(Lbl_Idperso.Text);
                        if (dataAsis.Rows.Count < 1) return;

                        lbl_IdAsis.Text = Convert.ToString(dataAsis.Rows[0]["Id_asis"]);
                        dtp_HoraIng.Value= Convert.ToDateTime(dataAsis.Rows[0]["HoIngreso"]);
                        //sacar hora trabajada
                        calcular_Horas_Trabajadas();

                        calcular_Pago_por_Horas_Trabajadas();
                        //Solo se registrara en la salida de trabajo
                        //Tambien crear una tabla donde se coloque el pago por hora ejemplo 13 Bs
                        //Solo falta registrar a la base de datos cuanto se le pagara al dia por la hora trabajada ya registra las hora trabajada , ya da 
                        //calcular hora trabajada por plata ejemplo trabajo 8 * 13 bs total a pagar 104Bs dia por 5dias 520semnal 520*4semans mensual 2080bs
                       
                       objas.RN_Registrar_Salida_Personal(lbl_IdAsis.Text, Lbl_Idperso.Text, lbl_hora.Text,Convert.ToDouble(lbl_TotalHotrabajda.Text));

                        if(BD_Asistencia.salida==true)
                        {
                            
                            lbl_msm.BackColor = Color.YellowGreen;
                            lbl_msm.ForeColor = Color.White;
                            lbl_msm.Text = "La Salida del Personal Fue Registrado Correctamente";
                            tocar_timbreCarrectamente();

                            lbl_Cont.Text = "10";

                            pnl_Msm.Visible = true;
                            tmr_Conta.Enabled = true;


                        }

                    }
                    else
                    {
                        //toca marcar su entrada
                        if(horaCaptu>=Holimite)
                        {
                            lbl_msm.BackColor = Color.MistyRose;
                            lbl_msm.ForeColor = Color.Red;
                            lbl_msm.Text = "Ya no Puedes Marcar su Asistencia porque has llegado demasiado Tarde";
                            tocar_timbre();
                            lbl_Cont.Text = "10";

                            pnl_Msm.Visible = true;
                            tmr_Conta.Enabled = true;
                            return;

                        }
                        //ESta en el tiempo correcto
                        calcular_Minutos_Tardanza();
                        lbl_IdAsis.Text = RN_Utilitario.RN_NroDoc(3);
                       
                        objas.RN_Registrar_Entrada_Personal(lbl_IdAsis.Text, Lbl_Idperso.Text, lbl_hora.Text, Convert.ToDouble(lbl_totaltarde.Text),Convert.ToInt32(lbl_TotalHotrabajda.Text), lbl_justifi.Text);

                        if(BD_Asistencia.entrada==true)
                        {
                            RN_Utilitario.RN_Actualiza_Tipo_Doc(3);
                            lbl_msm.BackColor = Color.YellowGreen;
                            lbl_msm.ForeColor = Color.White;
                            lbl_msm.Text = "La Entrada del Personal Fue Registrado Correctamente";
                            tocar_timbreBienvenido();

                            lbl_Cont.Text = "10";

                            pnl_Msm.Visible = true;
                            tmr_Conta.Enabled = true;
                           
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo malo paso: " + ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }



        }

        private void tocar_timbre()
        {

            string ruta;
            ruta = Application.StartupPath;
            System.Media.SoundPlayer son;
            son = new System.Media.SoundPlayer(ruta + @"\timbre1.wav");
            son.Play();
        }
        //Pago por hora trabajada
        void calcular_Pago_por_Horas_Trabajadas() //TRABAJADO EN HORAS
        {
            RN_Asistencia obj = new RN_Asistencia();

            int horaTrabajada =Convert.ToInt32(lbl_TotalHotrabajda.Text); //
            double horaPago = Convert.ToDouble(labelpagoHora.Text);//                     

            double totalpago;

            totalpago = horaTrabajada * horaPago;

            labelTotalPago.Text = Convert.ToString(totalpago);
          

        } //Fin de calcular:
        void calcular_Horas_Trabajadas() //TRABAJADO EN HORAS
        {
            RN_Asistencia obj = new RN_Asistencia();

            int horaCaptu = DateTime.Now.Hour; //Form
                        
            int horaIn = dtp_HoraIng.Value.Hour;//                     

            int hora;

            hora = horaCaptu - horaIn;
                     
            lbl_TotalHotrabajda.Text = Convert.ToString(hora);

          
        } //Fin de calcular:



        void calcular_Minutos_Tardanza()
        {
            RN_Asistencia obj = new RN_Asistencia();

            int horaCaptu= DateTime.Now.Hour;
            int minutoCaptu = DateTime.Now.Minute;

            int horaIn = dtp_horaIngre.Value.Hour;
            int MinuIn = dtp_horaIngre.Value.Minute;

            int Mntotole = dtp_hora_tolercia.Value.Minute;

            int totalMinutofijo;
            int totaltardanza;

            //7:00+15=15:

            if(obj.RN_Verificar_Justificacion_Aprobado(Lbl_Idperso.Text)==true)
            {
                lbl_justifi.Text = "Tardanza Justificada";
            }
            else
            {
                lbl_justifi.Text = "Tardanza no Justificada";
                totalMinutofijo = MinuIn + Mntotole;//45

                if(horaCaptu== horaIn & minutoCaptu>totalMinutofijo)
                {
                    totaltardanza = minutoCaptu - totalMinutofijo;
                    lbl_totaltarde.Text = Convert.ToString(totaltardanza);

                }
                else if (horaCaptu>horaIn)
                {
                    int horaTarde;
                    horaTarde = horaCaptu - horaIn;
                    int HoraenMinuto;
                    HoraenMinuto = horaTarde * 60;
                    int totaltardexx = HoraenMinuto - totalMinutofijo;

                    totaltardanza = minutoCaptu + totaltardexx;
                    lbl_totaltarde.Text = Convert.ToString(totaltardanza);
                }
            }
        }

        private void tocar_timbreCarrectamente()
        {

            string ruta;
            ruta = Application.StartupPath;
            System.Media.SoundPlayer son;
            son = new System.Media.SoundPlayer(ruta + @"\bienvenido.wav");
            son.Play();

        }

        private void tocar_timbreBienvenido()
        {

            string ruta;
            ruta = Application.StartupPath;
            System.Media.SoundPlayer son;
            son = new System.Media.SoundPlayer(ruta + @"\bienvenido.wav");
            son.Play();

        }
        private void tocar_timbreErroeno()
        {

            string ruta;
            ruta = Application.StartupPath;
            System.Media.SoundPlayer son;
            son = new System.Media.SoundPlayer(ruta + @"\codigoerroneo.wav");
            son.Play();

        }




        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();

        }

        private void pnl_titulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {
                Utilitarios ui = new Utilitarios();
                ui.Mover_formulario(this);
            }
        }

        private void txt_doc_Buscar_KeyDown(object sender, KeyEventArgs e)
        {
             if(e.KeyCode==Keys.Enter)
            {
                btn_buscar_Click(sender, e);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_hora.Text = DateTime.Now.ToString("hh:mm:ss");
        }
        private int sec = 10;
        private void tmr_Conta_Tick(object sender, EventArgs e)
        {
            sec -= 1;
            lbl_Cont.Text = sec.ToString();
            lbl_Cont.Refresh();

            if (sec == 0)
            {
                LimpiarFormulario();
                sec = 10;
                tmr_Conta.Stop();
                pnl_Msm.Visible = false;
                //xVerificationControl.Enabled = true;
                lbl_Cont.Text = "10";
            }
        }


        private void LimpiarFormulario()
        {
            lbl_nombresocio.Text = "";
            lbl_totaltarde.Text = "0";
            lbl_TotalHotrabajda.Text = "0";
            lbl_Doc.Text = "";
            lbl_Cont.Text = "0";
            lbl_IdAsis.Text = "";
            Lbl_Idperso.Text = "";
            lbl_justifi.Text = "";
            lbl_msm.BackColor = Color.Transparent;
            lbl_msm.Text = "";
            picSocio.Image = null;
            txt_doc_Buscar.Text = "";
            //xVerificationControl.Enabled = true;

        }

    }
}
