using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
  public   class EN_Horario
    {

        private string _idhora;
        private DateTime _hoEntrada; // As Date
        private DateTime _HoTole; // As Date
        private DateTime _HoLimite; // As Date
        private DateTime _HoSalida; // As Date
        // Para Visual 2017 Adelante automatico
        //public string Idhora
        //{
        //    get => _idhora; set => _idhora = value; }
        //public DateTime HoEntrada
        //{
        //    get => _hoEntrada; set => _hoEntrada = value; }
        //public DateTime HoTole
        //{
        //    get => _HoTole; set => _HoTole = value; }
        //public DateTime HoLimite
        //{
        //    get => _HoLimite; set => _HoLimite = value; }
        //public DateTime HoSalida
        //{
        //    get => _HoSalida; set => _HoSalida = value; }
        //}

        public string Idhora
        {
            get { return _idhora; }
            set { _idhora = value; }
        }

        public DateTime HoEntrada
        {
            get { return _hoEntrada; }
            set { _hoEntrada = value; }
        }
        public DateTime HoTole
        {
            get { return _HoTole; }
            set { _HoTole = value; }
        }
        public DateTime HoLimite
        {
            get { return _HoLimite; }
            set { _HoLimite = value; }
        }
        public DateTime HoSalida
        {
            get { return _HoSalida; }
            set { _HoSalida = value; }
        }

    }

}
