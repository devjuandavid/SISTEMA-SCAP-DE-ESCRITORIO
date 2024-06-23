﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prj_Capa_Datos;
using System.Data;

namespace Prj_Capa_Negocio
{
    public class RN_Asistencia
    {

        public DataTable RN_Ver_Todas_Asistencia()
        {
            BD_Asistencia obj = new BD_Asistencia();
            return obj.BD_Ver_Todas_Asistencia();
        }

        public DataTable RN_Ver_Todas_Asistencia_DelDia(DateTime xfecha)
        {
            BD_Asistencia obj = new BD_Asistencia();
            return obj.BD_Ver_Todas_Asistencia_DelDia(xfecha);
        }
        public DataTable RN_Ver_Todas_Asistencia_DelMes(DateTime xfecha)
        {
            BD_Asistencia obj = new BD_Asistencia();
            return obj.BD_Ver_Todas_Asistencia_DelMes(xfecha);
        }

        public DataTable RN_Ver_Todas_Asistencia_ParaExplorador(string xvalor)
        {
            BD_Asistencia obj = new BD_Asistencia();
            return obj.BD_Ver_Todas_Asistencia_ParaExplorador(xvalor);
        }


        public DataTable RN_Buscar_Asistencia_deEntrada(string idperso)
        {
            BD_Asistencia obj = new BD_Asistencia();
            return obj.BD_Buscar_Asistencia_deEntrada(idperso);
        }



        public void RN_Registrar_Entrada_Personal(string idAsis, string idPerso, string HoIngreso, double tarde, int totalHora, string justificado)
        {
            BD_Asistencia obj = new BD_Asistencia();
            obj.BD_Registrar_Entrada_Personal(idAsis, idPerso, HoIngreso, tarde, totalHora, justificado);
        }

        public void RN_Registrar_Salida_Personal(string idAsis, string idPerso, string HoSalida, double totalHora)
        {
            BD_Asistencia obj = new BD_Asistencia();
            obj.BD_Registrar_Salida_Personal(idAsis, idPerso, HoSalida, totalHora);
        }

        public bool RN_Checar_SiPersonal_YaMarco_Asistencia(string xidPerso)
        {
            BD_Asistencia obj = new BD_Asistencia();
            return obj.BD_Checar_SiPersonal_YaMarco_Asistencia(xidPerso);
        }

        public bool RN_Checar_SiPersonal_YaMarco_suEntrada(string xidPerso)
        {
            BD_Asistencia obj = new BD_Asistencia();
            return obj.BD_Checar_SiPersonal_YaMarco_suEntrada(xidPerso);
        }


        public bool RN_Verificar_Justificacion_Aprobado(string idpers)
        {
            BD_Asistencia obj = new BD_Asistencia();
            return obj.BD_Verificar_Justificacion_Aprobado(idpers);
        }

        public bool RN_Checar_SiPersonal_TieneAsistencia_Registrada(string xidPerso)
        {
            BD_Asistencia obj = new BD_Asistencia();
            return obj.BD_Checar_SiPersonal_TieneAsistencia_Registrada(xidPerso);
        }

        public bool RN_Checar_SiPersonal_YaMarco_suFalta(string xidPerso)
        {
            BD_Asistencia obj = new BD_Asistencia();
            return obj.BD_Checar_SiPersonal_YaMarco_suFalta(xidPerso);
        }

        public void RN_Registrar_Falta_Personal(string idAsis, string idPerso, string justifi)
        {
            BD_Asistencia obj = new BD_Asistencia();
            obj.BD_Registrar_Falta_Personal(idAsis,idPerso,justifi);
        }


        public DataTable RN_Ver_Asistencia_porPersona(string IdAsis, DateTime xfecha)
        {
            BD_Asistencia obj = new BD_Asistencia();
            return obj.BD_Ver_Asistencia_porPersona(IdAsis, xfecha);
        }


        public void RN_Eliminar_Asistencia(string idasis)
        {
            BD_Asistencia obj = new BD_Asistencia();
            obj.BD_Eliminar_Asistencia(idasis);

        }

    }
}
