using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prj_Capa_Negocio;

namespace MicroSisPlani.Informes
{
    public partial class Frm_PrintAsis_deldia : Form
    {
        public Frm_PrintAsis_deldia()
        {
            InitializeComponent();
        }
        public string tipoinfo = "";
        private void Frm_PrintAsis_deldia_Load(object sender, EventArgs e)
        {
            if (tipoinfo == "deldia")
            {
                Generar_informedelDia();

            }
            else if (tipoinfo == "delmes")
            {

                Generar_informedelMes();
            }
                    
        }


        private void Generar_informedelDia()
        {

            lbl_Titulo.Text = "Impresión de Dia";

            RN_Asistencia obj = new RN_Asistencia();
            DataTable data = new DataTable();

            data = obj.RN_Ver_Todas_Asistencia_DelDia(Convert.ToDateTime(this.Tag));
            if (data.Rows.Count > 0)
            {
                Rpte_AsistenciasDeldia rpte = new Rpte_AsistenciasDeldia();
                vsr_infodia.ReportSource = rpte;
                rpte.SetDataSource(data);
                rpte.Refresh();
                vsr_infodia.ReportSource = rpte;
            }
        }

        private void Generar_informedelMes()
        {
            lbl_Titulo.Text = "Impresión de Mes";
            RN_Asistencia obj = new RN_Asistencia();
            DataTable data = new DataTable();
            data = obj.RN_Ver_Todas_Asistencia_DelMes(Convert.ToDateTime(this.Tag));
            if (data.Rows.Count > 0)
            {
                Rpte_Asistencia_delMes rpte = new Rpte_Asistencia_delMes();
                vsr_infodia.ReportSource = rpte;
                rpte.SetDataSource(data);
                rpte.Refresh();
                vsr_infodia.ReportSource = rpte;
            }
        }

        private void pnl_titulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utilitarios u = new Utilitarios();
                u.Mover_formulario(this);
            }
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            vsr_infodia.PrintReport();
        }

        private void btn_exportar_Click(object sender, EventArgs e)
        {
            vsr_infodia.ExportReport();

        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            vsr_infodia.RefreshReport();
        }
    }
}
