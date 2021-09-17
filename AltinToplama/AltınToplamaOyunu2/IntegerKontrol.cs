using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltınToplamaOyunu2
{
    class IntegerKontrol
    {
        public int kontrolEt(string str, int varsayilanDeger)
        {
            int deger;
            if (str == "")
            {
                return varsayilanDeger;
            }
            else
            {
                if (int.TryParse(str, out deger))
                {
                    return deger;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}
