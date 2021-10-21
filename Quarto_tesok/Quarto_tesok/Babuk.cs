using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarto_tesok
{
    class Babuk
    {
        private string alak;
        private string szin;
        private string méret;
        private string lyukas;

        public Babuk(string alak, string szin, string méret, string lyukas)
        {
            Alak = alak;
            Szin = szin;
            Méret = méret;
            Lyukas = lyukas;
        }

        public string Alak { get => alak; set => alak = value; }
        public string Szin { get => szin; set => szin = value; }
        public string Méret { get => méret; set => méret = value; }
        public string Lyukas { get => lyukas; set => lyukas = value; }
    }
}
