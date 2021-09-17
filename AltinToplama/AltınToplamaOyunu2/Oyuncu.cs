using System;
using System.Drawing;
using System.Windows.Forms;

namespace AltınToplamaOyunu2
{
    public abstract class Oyuncu
    {
        public Oyun oyun;
        public Color color;
        public string adi;
        public int x, y;
        public int width, heigth;
        public int altin_miktari;
        public int hedef_x;
        public int hedef_y;
        public int hedefe_uzaklik;
        public int kac_hamlede_ulasir;
        public bool oyuncu_hayatta_mi = true;
        public bool ilk_hedef_belirleme_durumu;
        public int hamle_maliyeti;
        public int hedef_maliyeti;
        public int atilan_adim_sayisi = 0;
        public int harcanan_altin_miktari = 0;
        public int toplanan_altin_miktari = 0;

        public Oyuncu(Oyun oyun, string adi, int x, int y, int altin_miktari, int hamle_maliyeti, int hedef_maliyeti)
        {
            this.adi = adi;
            this.x = x;
            this.y = y;
            this.altin_miktari = altin_miktari;
            this.oyun = oyun;
            this.ilk_hedef_belirleme_durumu = true;
            this.hamle_maliyeti = hamle_maliyeti;
            this.hedef_maliyeti = hedef_maliyeti;
        }

        public void OyuncuCizdir(PaintEventArgs g, Kare[,] kareler)
        {
            kareler[this.x, this.y].KareBoya(g, this.color);
            kareler[this.x, this.y].KareYazdir(g, Color.Black, this.adi);
        }

        public void HedefCizdir(PaintEventArgs g, Kare[,] kareler)
        {
            kareler[this.hedef_x, this.hedef_y].KareCizdir(g, color);
        }

        public void Oyna()
        {
            if (hedef_x > this.x)
            {
                this.x++;
                this.atilan_adim_sayisi++;
                return;
            }
            else if (hedef_x < this.x)
            {
                this.x--;
                this.atilan_adim_sayisi++;
                return;
            }

            if (hedef_y > this.y)
            {
                this.y++;
                this.atilan_adim_sayisi++;
                return;
            }
            else if (hedef_y < this.y)
            {
                this.y--;
                this.atilan_adim_sayisi++;
                return;
            }
        }

        public int UzaklikHesapla(int x, int y)
        {
            return Math.Abs(this.x - x) + Math.Abs(this.y - y);
        }

        public abstract void HedefBelirle();

        public virtual void HamleYap(OyunAlaniMatrisi oyunAlaniMatrisi)
        {
            if (this.ilk_hedef_belirleme_durumu == true)
            {
                this.HedefBelirle();
                for (int i = 0; i < VarsayilanDegerler.ADIM_SAYISI; i++)
                {
                    this.Oyna();
                    if (HedefeUlasildiMi() == true)
                    {
                        break;
                    }
                }
                this.ilk_hedef_belirleme_durumu = false;
            }
            else
            {
                if (Altin.altinKonumlariMatrisi[this.hedef_x, this.hedef_y] == 1)
                {
                    for (int i = 0; i < VarsayilanDegerler.ADIM_SAYISI; i++)
                    {
                        this.Oyna();
                        if (HedefeUlasildiMi() == true)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    this.HedefBelirle();
                    for (int i = 0; i < VarsayilanDegerler.ADIM_SAYISI; i++)
                    {
                        this.Oyna();
                        if (HedefeUlasildiMi() == true)
                        {
                            break;
                        }
                    }
                }
            }
        }

        public bool HedefeUlasildiMi()
        {
            if (this.x == this.hedef_x && this.y == hedef_y)
            {
                this.altin_miktari += Altin.altinMiktarlariMatrisi[this.hedef_x, this.hedef_y];
                this.toplanan_altin_miktari += Altin.altinMiktarlariMatrisi[this.hedef_x, this.hedef_y];
                Altin.altinKonumlariMatrisi[this.hedef_x, this.hedef_y] = 0;
                Altin.altinMiktarlariMatrisi[this.hedef_x, this.hedef_y] = 0;
                Altin.altinHedeflenmislerMatrisi[this.hedef_x, this.hedef_y] = 0;
                this.HedefBelirle();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HedefBelirlemeMaliyetKontrolu()
        {
            if(this.altin_miktari > this.hedef_maliyeti)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HamleYapmaMaliyetKontrolu()
        {
            if (this.altin_miktari > this.hamle_maliyeti)
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