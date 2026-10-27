using System;
using System.Collections.Generic;
using System.Text;

namespace KontoNaMonety
{
    internal class KontoNaMonety
    {
        private decimal _saldo;
        private string _numer;
     
        public decimal Saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }

        public string Numer
        {
            get { return _numer; }
            set { _numer = value; }
        }
    }

}
