using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeamartApp
{
    class Zeamart
    {
        public string NamaBarang{ get; set; }
        public string JumlahBarang { get; set; }
        public object HargaBeli { get; internal set; }
        public object HargaJual { get; internal set; }

        public Zeamart(string namaBarang, string jumlahBarang, object hargaBeli, object hargaJual)
        {
            NamaBarang = namaBarang;
            JumlahBarang = jumlahBarang;
            HargaBeli = hargaBeli;
            HargaJual = hargaJual;
        }
    }


}
