using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AltınToplamaOyunu2
{
    public class Oyun : Label
    {
        OyunAlaniMatrisi oyunAlaniMatrisi;
        Altin altin;
        AOyuncusu aoyuncusu;
        BOyuncusu boyuncusu;
        COyuncusu coyuncusu;
        DOyuncusu doyuncusu;
        List<Oyuncu> oyuncularListesi;
        private int pencere_yuksekligi;
        private int pencere_genisligi;
        System.Windows.Forms.Timer timer;
        private int turSayisi;
        OyunSonuPaneli oyunSonuPaneli;
        List<Log> logListesi;

        public Oyun(int pencere_genisligi, int pencere_yuksekligi)
        {
            this.oyunAlaniMatrisi = new OyunAlaniMatrisi(pencere_genisligi, pencere_yuksekligi, VarsayilanDegerler.KARE_SAY_X, VarsayilanDegerler.KARE_SAY_Y);
            this.pencere_genisligi = pencere_genisligi;
            this.pencere_yuksekligi = pencere_yuksekligi;
            this.Width = this.pencere_genisligi;
            this.Height = this.pencere_yuksekligi;
            this.Location = new Point(0, 0);

            this.Paint += new PaintEventHandler(this.OyunAlaniCizdir);

            logListesi = new List<Log>()
            {
                { new Log("A Log Dosyası") },
                { new Log("B Log Dosyası") },
                { new Log("C Log Dosyası") },
                { new Log("D Log Dosyası") }
            };

            this.altin = new Altin(VarsayilanDegerler.KARE_SAY_X, VarsayilanDegerler.KARE_SAY_Y, VarsayilanDegerler.ALTIN_ORANI, VarsayilanDegerler.GIZLI_ALTIN_ORANI);
            this.aoyuncusu = new AOyuncusu(this, "A", 0, 0, VarsayilanDegerler.BASLANGIC_ALTIN_MIKTARI, Color.Red, logListesi[0]);
            this.boyuncusu = new BOyuncusu(this, "B", 0, VarsayilanDegerler.KARE_SAY_Y - 1, VarsayilanDegerler.BASLANGIC_ALTIN_MIKTARI, Color.LightGreen, logListesi[1]);
            this.coyuncusu = new COyuncusu(this, "C", VarsayilanDegerler.KARE_SAY_X - 1, 0, VarsayilanDegerler.BASLANGIC_ALTIN_MIKTARI, Color.LightBlue, logListesi[2]);
            this.doyuncusu = new DOyuncusu(aoyuncusu, boyuncusu, coyuncusu,
                                           this, "D", VarsayilanDegerler.KARE_SAY_X - 1, VarsayilanDegerler.KARE_SAY_Y - 1, VarsayilanDegerler.BASLANGIC_ALTIN_MIKTARI, Color.MediumPurple, logListesi[3]);

            timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(this.TurOyna);
            timer.Interval = 100;
            timer.Start();
            turSayisi = 0;

            oyuncularListesi = new List<Oyuncu>();
            oyuncularListesi.Add(aoyuncusu);
            oyuncularListesi.Add(boyuncusu);
            oyuncularListesi.Add(coyuncusu);
            oyuncularListesi.Add(doyuncusu);
        }

        public void OyunAlaniCizdir(object sender, PaintEventArgs g)
        {
            oyunAlaniMatrisi.OyunAlaniCizdir(g);
            altin.AltinlariCizdir(g, oyunAlaniMatrisi.kareler);
            altin.GizliAltinlariCizdir(g, oyunAlaniMatrisi.kareler);
            altin.AltinMiktarlariniCizdir(g, oyunAlaniMatrisi.kareler);
            foreach(var oyuncu in oyuncularListesi)
            {
                oyuncu.OyuncuCizdir(g, oyunAlaniMatrisi.kareler);
                oyuncu.HedefCizdir(g, oyunAlaniMatrisi.kareler);
            }
        }

        public void TurOyna(Object sender, EventArgs e)
        {
            if (turSayisi % 4 == 0 && aoyuncusu.oyuncu_hayatta_mi == true)
            {
                aoyuncusu.HamleYap(oyunAlaniMatrisi);
                this.Refresh();
            }

            if (turSayisi % 4 == 1 && boyuncusu.oyuncu_hayatta_mi == true)
            {
                boyuncusu.HamleYap(oyunAlaniMatrisi);
                this.Refresh();
            }

            if (turSayisi % 4 == 2 && coyuncusu.oyuncu_hayatta_mi == true)
            {
                coyuncusu.HamleYap(oyunAlaniMatrisi);
                this.Refresh();
            }

            if (turSayisi % 4 == 3 && doyuncusu.oyuncu_hayatta_mi == true)
            {
                doyuncusu.HamleYap(oyunAlaniMatrisi);
                this.Refresh();
            }

            turSayisi++;
            if (aoyuncusu.oyuncu_hayatta_mi == false &&
                boyuncusu.oyuncu_hayatta_mi == false &&
                coyuncusu.oyuncu_hayatta_mi == false &&
                doyuncusu.oyuncu_hayatta_mi == false)
            {
                timer.Stop();
                this.Controls.Clear();
                this.oyunSonuPaneli = new OyunSonuPaneli(this.Width, this.Height, aoyuncusu, boyuncusu, coyuncusu, doyuncusu);
                this.Controls.Add(oyunSonuPaneli);

                foreach(var log in logListesi)
                {
                    log.sw.Close();
                    log.fs.Close();
                }
            }
        }
    }
}
