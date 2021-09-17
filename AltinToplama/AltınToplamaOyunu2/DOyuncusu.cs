using System;
using System.Collections.Generic;
using System.Drawing;

namespace AltınToplamaOyunu2
{
    public class DOyuncusu : Oyuncu
    {
        List<Oyuncu> oyuncularListesi;
        public bool kapkac_mode;
        Log log;
        public DOyuncusu(AOyuncusu aoyuncusu, BOyuncusu boyuncusu, COyuncusu coyuncusu,
        Oyun oyun, string adi, int x, int y, int baslangic_altin_miktari, Color color, Log log) : base(oyun, adi, x, y, baslangic_altin_miktari, VarsayilanDegerler.D_HAMLE_MALIYETI, VarsayilanDegerler.D_HEDEF_MALIYETI)
        {
            this.color = color;
            oyuncularListesi = new List<Oyuncu>();
            oyuncularListesi.Add(aoyuncusu);
            oyuncularListesi.Add(boyuncusu);
            oyuncularListesi.Add(coyuncusu);
            this.log = log;
        }

        public override void HedefBelirle()
        {
            if (this.HedefBelirlemeMaliyetKontrolu())
            {
                this.kapkac_mode = false;
                CalinabilirAltinVarMi();
                if (kapkac_mode == false)
                {
                    int kar_miktari = Int32.MinValue;

                    for (int i = 0; i < Altin.altinKonumlariMatrisi.GetUpperBound(0) + 1; i++)
                    {
                        for (int j = 0; j < Altin.altinKonumlariMatrisi.GetUpperBound(1) + 1; j++)
                        {
                            if (Altin.altinKonumlariMatrisi[i, j] == 1 && Altin.altinHedeflenmislerMatrisi[i, j] != 3)
                            {
                                if (UzaklikHesapla(i, j) % VarsayilanDegerler.ADIM_SAYISI == 0)
                                {
                                    this.kac_hamlede_ulasir = UzaklikHesapla(i, j) / VarsayilanDegerler.ADIM_SAYISI;
                                }
                                else
                                {
                                    this.kac_hamlede_ulasir = UzaklikHesapla(i, j) / VarsayilanDegerler.ADIM_SAYISI + 1;
                                }

                                if (Altin.altinMiktarlariMatrisi[i, j] - (this.kac_hamlede_ulasir * VarsayilanDegerler.D_HAMLE_MALIYETI) > kar_miktari)
                                {
                                    kar_miktari = Altin.altinMiktarlariMatrisi[i, j] - (this.kac_hamlede_ulasir * VarsayilanDegerler.D_HAMLE_MALIYETI);
                                    this.hedef_x = i;
                                    this.hedef_y = j;
                                }
                            }
                        }
                    }
                    this.altin_miktari -= VarsayilanDegerler.D_HEDEF_MALIYETI;
                    this.harcanan_altin_miktari += VarsayilanDegerler.D_HEDEF_MALIYETI;
                }
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
                this.altin_miktari -= VarsayilanDegerler.D_HAMLE_MALIYETI;
                this.harcanan_altin_miktari += VarsayilanDegerler.D_HAMLE_MALIYETI;
            }
            else
            {
                this.oyuncu_hayatta_mi = false;
            }
        }

        public void CalinabilirAltinVarMi()
        {
            int gelir = Int32.MinValue;

            for (int i = 0; i < Altin.altinHedeflenmislerMatrisi.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < Altin.altinHedeflenmislerMatrisi.GetUpperBound(1) + 1; j++)
                {
                    if (Altin.altinHedeflenmislerMatrisi[i, j] == 3)
                    {
                        foreach (var oyuncu in oyuncularListesi)
                        {
                            if (i == oyuncu.hedef_x && j == oyuncu.hedef_y)
                            {
                                if (UzaklikHesapla(i, j) % VarsayilanDegerler.ADIM_SAYISI == 0)
                                {
                                    this.hedefe_uzaklik = UzaklikHesapla(i, j) / VarsayilanDegerler.ADIM_SAYISI;
                                }
                                else
                                {
                                    this.hedefe_uzaklik = UzaklikHesapla(i, j) / VarsayilanDegerler.ADIM_SAYISI + 1;
                                }

                                if (this.hedefe_uzaklik < oyuncu.kac_hamlede_ulasir)
                                {
                                    if (Altin.altinMiktarlariMatrisi[i, j] - (this.hedefe_uzaklik * VarsayilanDegerler.D_HEDEF_MALIYETI) > gelir)
                                    {
                                        gelir = Altin.altinMiktarlariMatrisi[i, j] - (this.hedefe_uzaklik * VarsayilanDegerler.D_HEDEF_MALIYETI);
                                        this.hedef_x = i;
                                        this.hedef_y = j;
                                        this.kapkac_mode = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (kapkac_mode == true)
            {
                this.altin_miktari -= VarsayilanDegerler.D_HEDEF_MALIYETI;
                this.harcanan_altin_miktari += VarsayilanDegerler.D_HEDEF_MALIYETI;
            }
        }

    }
}
