using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using Prj_Capa_Negocio;
using System.Data;

namespace Prj_Capa_Negocio
{
  public   class RN_Horario
    {

        public void RN_Actulizar_Horario(EN_Horario P)
        {
            BD_Horario obj = new BD_Horario();
            obj.BD_Actulizar_Horario(P);
        }

        public DataTable RN_Leer_Horario()
        {
            BD_Horario obj = new BD_Horario();
            return obj.BD_Leer_Horario();
        }
    }
}
