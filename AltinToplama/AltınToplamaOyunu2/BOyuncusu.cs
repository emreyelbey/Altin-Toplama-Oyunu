using System;
using System.Drawing;

namespace AltınToplamaOyunu2
{
    public class BOyuncusu : Oyuncu
    {
        Log log;
        public BOyuncusu(Oyun oyun, string adi, int x, int y, int baslangic_altin_miktari, Color color, Log log) : base(oyun, adi, x, y, baslangic_altin_miktari, VarsayilanDegerler.B_HAMLE_MALIYETI, VarsayilanDegerler.B_HEDEF_MALIYETI)
        {
            this.color = color;
            this.log = log;
        }

        public override void HedefBelirle()
        {
            if (this.HedefBelirlemeMaliyetKontrolu())
            {
                int kar_miktari = Int32.MinValue;

                for (int i = 0; i < Altin.altinKonumlariMatrisi.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < Altin.altinKonumlariMatrisi.GetUpperBound(1) + 1; j++)
                    {
                        if (Altin.altinKonumlariMatrisi[i, j] == 1)
                        {
                            if (UzaklikHesapla(i, j) % VarsayilanDegerler.ADIM_SAYISI == 0)
                            {
                                this.hedefe_uzaklik = UzaklikHesapla(i, j) / VarsayilanDegerler.ADIM_SAYISI;
                            }
                            else
                            {
                                this.hedefe_uzaklik = UzaklikHesapla(i, j) / VarsayilanDegerler.ADIM_SAYISI + 1;
                            }

                            if (Altin.altinMiktarlariMatrisi[i, j] - (this.hedefe_uzaklik * VarsayilanDegerler.B_HAMLE_MALIYETI) > kar_miktari)
                            {
                                kar_miktari = Altin.altinMiktarlariMatrisi[i, j] - (this.hedefe_uzaklik * VarsayilanDegerler.B_HAMLE_MALIYETI);
                                this.hedef_x = i;
                                this.hedef_y = j;
                                Altin.altinHedeflenmislerMatrisi[i, j] = 3;
                                this.kac_hamlede_ulasir = this.hedefe_uzaklik;
                            }
                        }
                    }
                }
                this.altin_miktari -= VarsayilanDegerler.B_HEDEF_MALIYETI;
                this.harcanan_altin_miktari += VarsayilanDegerler.B_HEDEF_MALIYETI;
            }
            else
            {
                this.oyuncu_hayatta_mi = false;
            }
        }

        public override void HamleYap(OyunAlaniMatrisi oyunAlaniMatrisi)
        {
            if (this.HamleYapmaMaliyetKontrolu())
            {
                base.HamleYap(oyunAlaniMatrisi);
                this.altin_miktari -= VarsayilanDegerler.B_HAMLE_MALIYETI;
                this.harcanan_altin_miktari += VarsayilanDegerler.B_HAMLE_MALIYETI;
            }
            else
            {
                this.oyuncu_hayatta_mi = false;
            }
        }
    }
}
