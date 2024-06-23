using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using System.Data;


namespace Prj_Capa_Negocio
{
    public  class RN_Usuario
    {

        public bool RN_Verificar_Acceso(string Usuario, string Contraseña)
        {
            BD_usuario obj = new BD_usuario();
            return obj.BD_Verificar_Acceso(Usuario, Contraseña);

        }

        public DataTable RN_Leer_Datos_Usuario(string Usuario)
        {
            BD_usuario obj = new BD_usuario();
            return obj.BD_Leer_Datos_Usuario(Usuario);

        }


        public bool RN_Verificar_UserUSUARIO(string USER)
        {
            BD_usuario obj = new BD_usuario();
            return obj.BD_Verificar_UserUSUARIO(USER);
        }




        public void RN_Registrar_Usuario(EN_Usuario user)
        {
            BD_usuario obj = new BD_usuario();
            obj.BD_Registrar_Usuario(user);
        }


        public DataTable RN_Leer_todoUsuario()
        {
            BD_usuario obj = new BD_usuario();
            return obj.BD_Leer_todoUsuario();
        }

        public DataTable RN_Buscar_Usuario_xValor(string valor)
        {
            BD_usuario obj = new BD_usuario();
            return obj.BD_Buscar_Usuario_xValor(valor);
        }

        public void RN_Editar_Usuario(EN_Usuario user)
        {
            BD_usuario obj = new BD_usuario();
            obj.BD_Editar_Usuario(user);
        }

        public void RN_Eliminar_Usuario(string ID)
        {
            BD_usuario obj = new BD_usuario();
            obj.BD_Eliminar_Usuario(ID);
        }
    }
}
