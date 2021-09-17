using System;

namespace AltınToplamaOyunu2
{
    class KonumKontrol
    {
        int kare_sayisi_x;
        int kare_sayisi_y;

        public KonumKontrol(int kare_sayisi_x, int kare_sayisi_y)
        {
            this.kare_sayisi_x = kare_sayisi_x;
            this.kare_sayisi_y = kare_sayisi_y;
        }

        public bool OyuncuKonumuMu(int x, int y)
        {
            if(x == 0 && y == 0)
            {
                return true;
            }else if(x == kare_sayisi_x-1 && y == 0)
            {
                return true;
            }else if(x == 0 && y == kare_sayisi_y-1)
            {
                return true;
            }else if(x == kare_sayisi_x-1 && y == kare_sayisi_y-1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
