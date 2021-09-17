using System;
using System.Windows.Forms;

namespace AltınToplamaOyunu2
{
    public partial class Form1 : Form
    {
        Mesaj mesaj = new Mesaj();
        IntegerKontrol IntegerKontrol = new IntegerKontrol();

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void buttonBasla_Click(object sender, EventArgs e)
        {
            VarsayilanDegerler.KARE_SAY_X = IntegerKontrol.kontrolEt(textBoxOyunAlanıX.Text, VarsayilanDegerler.KARE_SAY_X);
            VarsayilanDegerler.KARE_SAY_Y = IntegerKontrol.kontrolEt(textBoxOyunAlanıY.Text, VarsayilanDegerler.KARE_SAY_Y);
            
            VarsayilanDegerler.ALTIN_ORANI = IntegerKontrol.kontrolEt(textBoxAltinOrani.Text, VarsayilanDegerler.ALTIN_ORANI);
            VarsayilanDegerler.GIZLI_ALTIN_ORANI = IntegerKontrol.kontrolEt(textBoxGizliAltinOrani.Text, VarsayilanDegerler.GIZLI_ALTIN_ORANI);
            VarsayilanDegerler.BASLANGIC_ALTIN_MIKTARI = IntegerKontrol.kontrolEt(textBoxBaslangicAltin.Text, VarsayilanDegerler.BASLANGIC_ALTIN_MIKTARI);
            VarsayilanDegerler.ADIM_SAYISI = IntegerKontrol.kontrolEt(textBoxAdimSayisi.Text, VarsayilanDegerler.ADIM_SAYISI);

            VarsayilanDegerler.A_HAMLE_MALIYETI = IntegerKontrol.kontrolEt(textBoxHamleMaliyetA.Text, VarsayilanDegerler.A_HAMLE_MALIYETI);
            VarsayilanDegerler.A_HEDEF_MALIYETI = IntegerKontrol.kontrolEt(textBoxHedefMaliyetA.Text, VarsayilanDegerler.A_HEDEF_MALIYETI);

            VarsayilanDegerler.B_HAMLE_MALIYETI = IntegerKontrol.kontrolEt(textBoxHamleMaliyetB.Text, VarsayilanDegerler.B_HAMLE_MALIYETI);
            VarsayilanDegerler.B_HEDEF_MALIYETI = IntegerKontrol.kontrolEt(textBoxHedefMaliyetB.Text, VarsayilanDegerler.B_HEDEF_MALIYETI);

            VarsayilanDegerler.C_HAMLE_MALIYETI = IntegerKontrol.kontrolEt(textBoxHamleMaliyetC.Text, VarsayilanDegerler.C_HAMLE_MALIYETI);
            VarsayilanDegerler.C_HEDEF_MALIYETI = IntegerKontrol.kontrolEt(textBoxHedefMaliyetC.Text, VarsayilanDegerler.C_HEDEF_MALIYETI);
            VarsayilanDegerler.C_ACILACAK_GIZLI = IntegerKontrol.kontrolEt(textBoxGizliAltinC.Text, VarsayilanDegerler.C_ACILACAK_GIZLI);

            VarsayilanDegerler.D_HAMLE_MALIYETI = IntegerKontrol.kontrolEt(textBoxHamleMaliyetD.Text, VarsayilanDegerler.D_HAMLE_MALIYETI);
            VarsayilanDegerler.D_HEDEF_MALIYETI = IntegerKontrol.kontrolEt(textBoxHedefMaliyetD.Text, VarsayilanDegerler.D_HEDEF_MALIYETI);

            if (VarsayilanDegerler.KARE_SAY_X != -1 && 
                VarsayilanDegerler.KARE_SAY_Y != -1 &&
                VarsayilanDegerler.ALTIN_ORANI != -1 &&
                VarsayilanDegerler.GIZLI_ALTIN_ORANI != -1 &&
                VarsayilanDegerler.BASLANGIC_ALTIN_MIKTARI != -1 &&
                VarsayilanDegerler.ADIM_SAYISI != -1 &&
                VarsayilanDegerler.A_HAMLE_MALIYETI != -1 &&
                VarsayilanDegerler.A_HEDEF_MALIYETI != -1 &&
                VarsayilanDegerler.B_HAMLE_MALIYETI != -1 &&
                VarsayilanDegerler.B_HEDEF_MALIYETI != -1 &&
                VarsayilanDegerler.C_HAMLE_MALIYETI != -1 &&
                VarsayilanDegerler.C_HEDEF_MALIYETI != -1 &&
                VarsayilanDegerler.C_ACILACAK_GIZLI != -1 &&
                VarsayilanDegerler.D_HAMLE_MALIYETI != -1 &&
                VarsayilanDegerler.D_HEDEF_MALIYETI != -1
               )
            {
                this.Controls.Clear();
                Oyun oyun = new Oyun(this.panelAcılısEkranı.Width, this.panelAcılısEkranı.Height);
                this.Controls.Add(oyun);
            }
            else
            {
                mesaj.mesajVer();
            }
        }

        private void buttonCıkıs_Click(object sender, EventArgs e)
        {
            Environment.Exit(-1);
        }
    }
}
