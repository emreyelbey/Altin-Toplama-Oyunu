using System;
using System.Drawing;

namespace AltınToplamaOyunu2
{
    public class COyuncusu : Oyuncu
    {
        public bool gizli_altin_acma_ilk_adim = false;
        public int[] gizli_altin_uzakliklari;
        public int[] en_yakin_gizli_altin_indisleri;
        Log log;
        public COyuncusu(Oyun oyun, string adi, int x, int y, int baslangic_altin_miktari, Color color, Log log) : base(oyun, adi, x, y, baslangic_altin_miktari, VarsayilanDegerler.C_HAMLE_MALIYETI, VarsayilanDegerler.C_HEDEF_MALIYETI)
        {
            this.color = color;
            this.log = log;
        }

        public override void HedefBelirle()
        {
            if (this.HedefBelirlemeMaliyetKontrolu())
            {
                if (Altin.gizliAltinSayisi > 0)
                {
                    GizliAltinAc();
                }

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

                            if (Altin.altinMiktarlariMatrisi[i, j] - (this.hedefe_uzaklik * VarsayilanDegerler.C_HAMLE_MALIYETI) > kar_miktari)
                            {
                                kar_miktari = Altin.altinMiktarlariMatrisi[i, j] - (this.hedefe_uzaklik * VarsayilanDegerler.C_HAMLE_MALIYETI);
                                this.hedef_x = i;
                                this.hedef_y = j;
                                Altin.altinHedeflenmislerMatrisi[i, j] = 3;
                                this.kac_hamlede_ulasir = this.hedefe_uzaklik;
                            }
                        }
                    }
                }
                this.altin_miktari -= VarsayilanDegerler.C_HEDEF_MALIYETI;
                this.harcanan_altin_miktari += VarsayilanDegerler.C_HEDEF_MALIYETI;
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
                this.altin_miktari -= VarsayilanDegerler.C_HAMLE_MALIYETI;
                this.harcanan_altin_miktari += VarsayilanDegerler.C_HAMLE_MALIYETI;
            }
            else
            {
                this.oyuncu_hayatta_mi = false;
            }
        }

        public void GizliAltinAc()
        {
            this.gizli_altin_uzakliklari = new int[Altin.gizliAltinSayisi];
            this.en_yakin_gizli_altin_indisleri = new int[VarsayilanDegerler.C_ACILACAK_GIZLI];

            int index_gizli_altin_uzakliklari = 0;
            for (int i = 0; i < Altin.altinKonumlariMatrisi.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < Altin.altinKonumlariMatrisi.GetUpperBound(1) + 1; j++)
                {
                    if (Altin.altinKonumlariMatrisi[i, j] == 2)
                    {
                        gizli_altin_uzakliklari[index_gizli_altin_uzakliklari] = UzaklikHesapla(i, j);
                        index_gizli_altin_uzakliklari++;
                    }
                }
            }
            //for(int i=0; i<gizli_altin_uzakliklari.Length; i++)
            //{
            //    Console.WriteLine(gizli_altin_uzakliklari[i]);
            //}
            int en_yakin_gizli_altin_uzakligi = Int32.MaxValue;
            int anlik_en_yakin_gizli_altin = Int32.MaxValue;

            for (int indis = 0; indis < VarsayilanDegerler.C_ACILACAK_GIZLI; indis++)
            {
                for (int i = 0; i < gizli_altin_uzakliklari.Length; i++)
                {
                    if (gizli_altin_uzakliklari[i] < en_yakin_gizli_altin_uzakligi)
                    {
                        en_yakin_gizli_altin_uzakligi = gizli_altin_uzakliklari[i];
                        en_yakin_gizli_altin_indisleri[indis] = i;
                        anlik_en_yakin_gizli_altin = i;
                    }
                }
                gizli_altin_uzakliklari[anlik_en_yakin_gizli_altin] = Int32.MaxValue;
                en_yakin_gizli_altin_uzakligi = Int32.MaxValue;
            }
            //Console.WriteLine();
            //for(int i=0; i<en_yakin_gizli_altin_indisleri.Length; i++)
            //{
            //    Console.WriteLine(en_yakin_gizli_altin_indisleri[i]);
            //}
            int sayac = 0;

            for (int i = 0; i < Altin.altinKonumlariMatrisi.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < Altin.altinKonumlariMatrisi.GetUpperBound(1) + 1; j++)
                {
                    if (Altin.altinKonumlariMatrisi[i, j] == 2)
                    {
                        for (int k = 0; k < en_yakin_gizli_altin_indisleri.Length; k++)
                        {
                            if (en_yakin_gizli_altin_indisleri[k] == sayac)
                            {
                                Altin.altinKonumlariMatrisi[i, j] = 1;
                                Altin.gizliAltinSayisi--;
                            }
                        }
                        sayac++;
                    }
                }
            }

        }
    }
}
