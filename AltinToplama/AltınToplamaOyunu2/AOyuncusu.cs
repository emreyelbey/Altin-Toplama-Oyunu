using System;
using System.Collections.Generic;
using System.Drawing;

namespace AltınToplamaOyunu2
{
    public class AOyuncusu : Oyuncu
    {
        Log log;
        public AOyuncusu(Oyun oyun, string adi, int x, int y, int baslangic_altin_miktari, Color color, Log log) : base(oyun, adi, x, y, baslangic_altin_miktari, VarsayilanDegerler.A_HAMLE_MALIYETI, VarsayilanDegerler.A_HEDEF_MALIYETI)
        {
            this.color = color;
            this.log = log;
        }

        public override void HedefBelirle()
        {
            if (this.HedefBelirlemeMaliyetKontrolu())
            {
                int en_yakin_hedef_uzakligi = Int32.MaxValue;

                for (int i = 0; i < Altin.altinKonumlariMatrisi.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < Altin.altinKonumlariMatrisi.GetUpperBound(1) + 1; j++)
                    {
                        if (Altin.altinKonumlariMatrisi[i, j] == 1)
                        {
                            if (UzaklikHesapla(i, j) < en_yakin_hedef_uzakligi)
                            {
                                if (UzaklikHesapla(i, j) % VarsayilanDegerler.ADIM_SAYISI == 0)
                                {
                                    this.hedefe_uzaklik = UzaklikHesapla(i, j) / VarsayilanDegerler.ADIM_SAYISI;
                                }
                                else
                                {
                                    this.hedefe_uzaklik = UzaklikHesapla(i, j) / VarsayilanDegerler.ADIM_SAYISI + 1;
                                }

                                en_yakin_hedef_uzakligi = UzaklikHesapla(i, j);
                                this.hedef_x = i;
                                this.hedef_y = j;
                                Altin.altinHedeflenmislerMatrisi[i, j] = 3;
                                this.kac_hamlede_ulasir = this.hedefe_uzaklik;
                            }
                        }
                    }
                }
                this.altin_miktari -= VarsayilanDegerler.A_HEDEF_MALIYETI;
                this.harcanan_altin_miktari += VarsayilanDegerler.A_HEDEF_MALIYETI;
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
                this.altin_miktari -= VarsayilanDegerler.A_HAMLE_MALIYETI;
                this.harcanan_altin_miktari += VarsayilanDegerler.A_HAMLE_MALIYETI;
            }
            else
            {
                this.oyuncu_hayatta_mi = false;
            }
        }

    }
}
