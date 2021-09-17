using System.Drawing;
using System.Windows.Forms;

namespace AltınToplamaOyunu2
{
    public class OyunAlaniMatrisi
    {
        private int pencere_yuksekligi;
        private int pencere_genisligi;
        private int kare_sayisi_x, kare_sayisi_y;
        public Kare[,] kareler;

        public OyunAlaniMatrisi(int pencere_genisligi, int pencere_yuksekligi, int kare_sayisi_x, int kare_sayisi_y)
        {
            this.pencere_genisligi = pencere_genisligi;
            this.pencere_yuksekligi = pencere_yuksekligi;
            this.kare_sayisi_x = kare_sayisi_x;
            this.kare_sayisi_y = kare_sayisi_y;
            this.kareler = new Kare[kare_sayisi_x, kare_sayisi_y];
            OyunAlaniMatrisiOlustur();
        }

        private void OyunAlaniMatrisiOlustur()
        {
            int x = 0;
            int y = 0;
            int kare_kenarı;
            int artik_deger;

            if (kare_sayisi_x > kare_sayisi_y)
            {
                kare_kenarı = pencere_yuksekligi / kare_sayisi_x;
                artik_deger = (pencere_yuksekligi % kare_sayisi_x) / 2;
            }
            else
            {
                kare_kenarı = pencere_yuksekligi / kare_sayisi_y;
                artik_deger = (pencere_yuksekligi % kare_sayisi_y) / 2;
            }

            for (int i = 0; i < kare_sayisi_x; i++)
            {
                for (int j = 0; j < kare_sayisi_y; j++)
                {
                    kareler[i, j] = new Kare(x + artik_deger, y + artik_deger, kare_kenarı, kare_kenarı);
                    x += kare_kenarı;
                }
                x = 0;
                y += kare_kenarı;
            }
        }

        public void OyunAlaniCizdir(PaintEventArgs g)
        {
            for (int i = 0; i < kare_sayisi_x; i++)
            {
                for (int j = 0; j < kare_sayisi_y; j++)
                {
                    kareler[i, j].KareCizdir(g, Color.White);
                }
            }
        }
    }
}
