using System;
using System.Drawing;
using System.Windows.Forms;

namespace AltınToplamaOyunu2
{
    class OyunSonuPaneli : Panel
    {
        public string oyuncu_adi_a = "A Oyuncusu";
        public string oyuncu_adi_b = "B Oyuncusu";
        public string oyuncu_adi_c = "C Oyuncusu";
        public string oyuncu_adi_d = "D Oyuncusu";

        public string atilan_adim_sayisi = "Adım sayısı";
        public string harcanan_altin_miktari = "Harcanan Altın";
        public string toplanan_altin_miktari = "Toplanan Altın";
        public string sahip_olunan_altin_miktari = "Oyun Sonu Altın";

        public string A_atilan_adim_sayisi;
        public string A_harcanan_altin_miktari;
        public string A_toplanan_altin_miktari;
        public string A_sahip_olunan_altin_miktari;

        public string B_atilan_adim_sayisi;
        public string B_harcanan_altin_miktari;
        public string B_toplanan_altin_miktari;
        public string B_sahip_olunan_altin_miktari;

        public string C_atilan_adim_sayisi;
        public string C_harcanan_altin_miktari;
        public string C_toplanan_altin_miktari;
        public string C_sahip_olunan_altin_miktari;

        public string D_atilan_adim_sayisi;
        public string D_harcanan_altin_miktari;
        public string D_toplanan_altin_miktari;
        public string D_sahip_olunan_altin_miktari;

        public Label[,] tabloLabel;
        int x = 3, y = 174;
        int w = 242, h = 84;
        public string[] stringler;

        public OyunSonuPaneli(int width, int height, Oyuncu aoyuncusu, Oyuncu boyuncusu, Oyuncu coyuncusu, Oyuncu doyuncusu)
        {
            this.A_atilan_adim_sayisi = Convert.ToString(aoyuncusu.atilan_adim_sayisi);
            this.A_harcanan_altin_miktari = Convert.ToString(aoyuncusu.harcanan_altin_miktari);
            this.A_toplanan_altin_miktari = Convert.ToString(aoyuncusu.toplanan_altin_miktari);
            this.A_sahip_olunan_altin_miktari = Convert.ToString(aoyuncusu.altin_miktari);

            this.B_atilan_adim_sayisi = Convert.ToString(boyuncusu.atilan_adim_sayisi);
            this.B_harcanan_altin_miktari = Convert.ToString(boyuncusu.harcanan_altin_miktari);
            this.B_toplanan_altin_miktari = Convert.ToString(boyuncusu.toplanan_altin_miktari);
            this.B_sahip_olunan_altin_miktari = Convert.ToString(boyuncusu.altin_miktari);

            this.C_atilan_adim_sayisi = Convert.ToString(coyuncusu.atilan_adim_sayisi);
            this.C_harcanan_altin_miktari = Convert.ToString(coyuncusu.harcanan_altin_miktari);
            this.C_toplanan_altin_miktari = Convert.ToString(coyuncusu.toplanan_altin_miktari);
            this.C_sahip_olunan_altin_miktari = Convert.ToString(coyuncusu.altin_miktari);

            this.D_atilan_adim_sayisi = Convert.ToString(doyuncusu.atilan_adim_sayisi);
            this.D_harcanan_altin_miktari = Convert.ToString(doyuncusu.harcanan_altin_miktari);
            this.D_toplanan_altin_miktari = Convert.ToString(doyuncusu.toplanan_altin_miktari);
            this.D_sahip_olunan_altin_miktari = Convert.ToString(doyuncusu.altin_miktari);

            stringler = new string[25];

            stringler[0] = "";
            stringler[1] = oyuncu_adi_a;
            stringler[2] = oyuncu_adi_b;
            stringler[3] = oyuncu_adi_c;
            stringler[4] = oyuncu_adi_d;

            stringler[5] = atilan_adim_sayisi;
            stringler[6] = A_atilan_adim_sayisi;
            stringler[7] = B_atilan_adim_sayisi;
            stringler[8] = C_atilan_adim_sayisi;
            stringler[9] = D_atilan_adim_sayisi;

            stringler[10] = harcanan_altin_miktari;
            stringler[11] = A_harcanan_altin_miktari;
            stringler[12] = B_harcanan_altin_miktari;
            stringler[13] = C_harcanan_altin_miktari;
            stringler[14] = D_harcanan_altin_miktari;

            stringler[15] = toplanan_altin_miktari;
            stringler[16] = A_toplanan_altin_miktari;
            stringler[17] = B_toplanan_altin_miktari;
            stringler[18] = C_toplanan_altin_miktari;
            stringler[19] = D_toplanan_altin_miktari;

            stringler[20] = sahip_olunan_altin_miktari;
            stringler[21] = A_sahip_olunan_altin_miktari;
            stringler[22] = B_sahip_olunan_altin_miktari;
            stringler[23] = C_sahip_olunan_altin_miktari;
            stringler[24] = D_sahip_olunan_altin_miktari;

            this.Width = width;
            this.Height = height;
            this.Location = new Point(0, 0);
            this.BackColor = Color.FromArgb(252, 251, 223);

            tabloLabel = new Label[5, 5];

            int indis = 0;
            for (int i = 0; i < tabloLabel.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < tabloLabel.GetUpperBound(1) + 1; j++)
                {
                    Console.WriteLine(this.Width);
                    Console.WriteLine(this.Height);
                    tabloLabel[i, j] = new Label();
                    tabloLabel[i, j].Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(162)));
                    tabloLabel[i, j].ForeColor = Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(63)))), ((int)(((byte)(46)))));
                    tabloLabel[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    tabloLabel[i, j].Size = new Size(w, h);
                    tabloLabel[i, j].AutoSize = false;
                    tabloLabel[i, j].Location = new Point(x, y);
                    tabloLabel[i, j].Text = stringler[indis];
                    indis++;
                    this.Controls.Add(tabloLabel[i, j]);
                    x += w;
                }
                x = 3;
                y += h;
            }
        }
    }
}
