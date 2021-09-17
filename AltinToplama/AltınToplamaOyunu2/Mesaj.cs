using System.Windows.Forms;

namespace AltınToplamaOyunu2
{
    class Mesaj
    {
        public void mesajVer()
        {
            string message = "Geçersiz değer girişi!";
            string title = "Uyarı";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
        }
    }
}
