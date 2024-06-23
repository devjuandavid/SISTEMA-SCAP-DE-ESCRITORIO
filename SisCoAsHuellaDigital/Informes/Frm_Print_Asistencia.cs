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
    public partial class Frm_Print_Asistencia : Form
    {
        public Frm_Print_Asistencia()
        {
            InitializeComponent();
        }


        public DateTime FechaConsult;

        public string CualImprimir = "";


        private void Frm_Print_Asistencia_Load(object sender, EventArgs e)
        {

            RN_Asistencia obj = new RN_Asistencia();
            DataTable data = new DataTable();

            data = obj.RN_Ver_Asistencia_porPersona(Convert.ToString(this.CualImprimir), Convert.ToDateTime(this.Tag));
            if (data.Rows.Count > 0)
            {
                Rpte_Asistencia_porPersona rpte = new Rpte_Asistencia_porPersona();
                Vsr_Asis.ReportSource = rpte;
                rpte.SetDataSource(data);
                rpte.Refresh();
                Vsr_Asis.ReportSource = rpte;
            }

        }




        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnl_titulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button ==MouseButtons.Left )
            {
                Utilitarios u = new Utilitarios();
                u.Mover_formulario(this);
            }
        }

        private void btn_exportar_Click(object sender, EventArgs e)
        {
            Vsr_Asis.ExportReport();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            Vsr_Asis.RefreshReport();
        }

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            Vsr_Asis.PrintReport();
        }
    }
}
