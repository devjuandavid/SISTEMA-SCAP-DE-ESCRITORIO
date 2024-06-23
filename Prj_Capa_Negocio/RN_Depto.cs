using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Prj_Capa_Entidad;
using Prj_Capa_Datos;
using System.Data.SqlClient;
namespace Prj_Capa_Negocio
{
  public   class RN_Depto
    {

        public DataTable RN_Buscar_Todos_Depto()
        {
            BD_Depto obj = new BD_Depto();
            return obj.BD_Buscar_Todos_Deptos();
        }

    }
}
