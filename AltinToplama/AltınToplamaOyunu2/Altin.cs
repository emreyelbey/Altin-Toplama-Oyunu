using System;
using System.Drawing;
using System.Windows.Forms;

namespace AltınToplamaOyunu2
{
    public class Altin
    {
        private int kare_sayisi_x;
        private int kare_sayisi_y;
        private int altinSayisi;
        public static int gizliAltinSayisi;
        public static int[,] altinKonumlariMatrisi;
        public static int[,] altinMiktarlariMatrisi;
        public static int[,] altinHedeflenmislerMatrisi;
        Random random;
        KonumKontrol konumKontrol;
        
        public Altin(int kare_sayisi_x, int kare_sayisi_y, int altin_orani, int gizli_altin_orani)
        {
            this.kare_sayisi_x = kare_sayisi_x;
            this.kare_sayisi_y = kare_sayisi_y;
            this.altinSayisi = (int)(kare_sayisi_x * kare_sayisi_y * (altin_orani / 100.0f));
            gizliAltinSayisi = (int)(altinSayisi * (gizli_altin_orani / 100.0f));
            altinKonumlariMatrisi = new int[kare_sayisi_x, kare_sayisi_y];
            altinMiktarlariMatrisi = new int[kare_sayisi_x, kare_sayisi_y];
            altinHedeflenmislerMatrisi = new int[kare_sayisi_x, kare_sayisi_y];
            konumKontrol = new KonumKontrol(kare_sayisi_x, kare_sayisi_y);
            random = new Random();
            AltinlariDagit();
            GizliAltinlariDagit();
            AltinMiktarlariniDagit();
        }

        public void AltinlariDagit()
        {
            int x, y;
            for (int i=0; i<altinSayisi; i++)
            {
                x = random.Next(kare_sayisi_x);
                y = random.Next(kare_sayisi_y);
                if(altinKonumlariMatrisi[x, y] == 0 && !konumKontrol.OyuncuKonumuMu(x, y))
                {
                    altinKonumlariMatrisi[x, y] = 1;
                }
                else
                {
                    while(altinKonumlariMatrisi[x, y] == 1 || konumKontrol.OyuncuKonumuMu(x, y))
                    {
                        x = random.Next(kare_sayisi_x);
                        y = random.Next(kare_sayisi_y);
                        if (altinKonumlariMatrisi[x, y] == 0 && !konumKontrol.OyuncuKonumuMu(x, y))
                        {
                            altinKonumlariMatrisi[x, y] = 1;
                            break;
                        }
                    }
                }
            }
        }

        public void GizliAltinlariDagit()
        {
            int x, y;
            for (int i = 0; i <gizliAltinSayisi; i++)
            {
                x = random.Next(kare_sayisi_x);
                y = random.Next(kare_sayisi_y);
                if ((altinKonumlariMatrisi[x, y] == 1))
                {
                    altinKonumlariMatrisi[x, y] = 2;
                }
                else
                {
                    while (true)
                    {
                        x = random.Next(kare_sayisi_x);
                        y = random.Next(kare_sayisi_y);
                        if (altinKonumlariMatrisi[x, y] == 1)
                        {
                            altinKonumlariMatrisi[x, y] = 2;
                            break;
                        }
                    }
                }
            }
        }

        public void AltinMiktarlariniDagit()
        {
            int altin_miktari;
            for(int i=0; i<kare_sayisi_x; i++)
            {
                for(int j=0; j<kare_sayisi_y; j++)
                {
                    if(altinKonumlariMatrisi[i,j] == 1 || altinKonumlariMatrisi[i, j] == 2)
                    {
                        altin_miktari = (1 + random.Next(4)) * 5;
                        altinMiktarlariMatrisi[i, j] = altin_miktari;
                    }
                }
            }
        }

        public void AltinlariCizdir(PaintEventArgs g, Kare[,] kareler)
        {
            for(int k=0; k<altinSayisi; k++)
            {
                for(int i=0; i<kare_sayisi_x; i++)
                {
                    for(int j=0; j<kare_sayisi_y; j++)
                    {
                        if(altinKonumlariMatrisi[i, j] == 1)
                        {
                            kareler[i, j].KareBoya(g, Color.Yellow);
                        }
                        
                    }
                }
            }
        }

        public void GizliAltinlariCizdir(PaintEventArgs g, Kare[,] kareler)
        {
            for (int k = 0; k<gizliAltinSayisi; k++)
            {
                for (int i = 0; i < kare_sayisi_x; i++)
                {
                    for (int j = 0; j < kare_sayisi_y; j++)
                    {
                        if (altinKonumlariMatrisi[i, j] == 2)
                        {
                            kareler[i, j].KareBoya(g, Color.Orange);
                        }

                    }
                }
            }
        }

        public void AltinMiktarlariniCizdir(PaintEventArgs g, Kare[,] kareler)
        {
            for(int i=0; i<kare_sayisi_x; i++)
            {
                for(int j=0; j<kare_sayisi_y; j++)
                {
                    if(altinKonumlariMatrisi[i,j] == 1 || altinKonumlariMatrisi[i, j] == 2)
                    {
                        kareler[i, j].KareYazdir(g, Color.Black, altinMiktarlariMatrisi[i,j].ToString());
                    }
                }
            }
        }
    }
}
