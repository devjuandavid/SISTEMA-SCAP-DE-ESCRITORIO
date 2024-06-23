using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Datos
{
   public class Cls_Conexion
    {

        public string Conectar()
        {
            return @"Data Source=JUANCOMPU\SQL2022; Initial Catalog=BDAsistenciaHuellaDigital;Integrated Security=True";
            //return @"Data Source=PC-ADMIN\SQLEXPRESS; Initial Catalog=BDAsistenciaHuellaDigital;uid=sa;pwd=admin"; ;
        }

        public static string Conectar2()
        {
            return @"Data Source=JUANCOMPU\SQL2022; Initial Catalog=BDAsistenciaHuellaDigital;Integrated Security=True";
            //return @"Data Source=PC-ADMIN\SQLEXPRESS; Initial Catalog=BDAsistenciaHuellaDigital;uid=sa;pwd=admin"; ;
        }

    } 
}
