using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4_U4_11
{
    class Sakinys
    {
        public int SakinioPradziosEil { get; set; } //sakinio pradzios eilute
        public int SakinioPrSimolis { get; set; }
        public int IlgisSimboliais { get; set; } // zodzio simboliu kiekis
        public int IlgisZodziais { get; set; } // zodzio simboliu kiekis
        public Sakinys(int sakinioPradziosEil, int sakinioPabaigosEil, int sakinioPrSimolis, int sakinioPbSimbolis, int ilgisSimboliais, int ilgisZodziais)
        {
            SakinioPradziosEil = sakinioPradziosEil;
            SakinioPrSimolis = sakinioPrSimolis;
            IlgisSimboliais = ilgisSimboliais;
            IlgisZodziais = ilgisZodziais;
        }
    }
}
