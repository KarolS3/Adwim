using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie3
{
    public static class Narzedzia
    {
        public static int ZliczSamogloski(string tekst)
        {
            int wynik = 0;
            string samogloski = "aąeęiouóyAĄEĘIOUÓY";
            if (string.IsNullOrEmpty(tekst))
            {
                return 0;
            }
            else
            {
                foreach (var litera in tekst)
                {
                    if (samogloski.Contains(litera))
                    {
                        wynik += 1;
                    }
                }
            }
            return wynik;
        }

        public static string UsunPowtorzenia(string tekst)
        {
            string wynik = string.Empty;

            if (string.IsNullOrEmpty(tekst))
            {
                return wynik;
            }
            else
            {
                for (int n = 0; n < tekst.Length; n += 1)
                {
                    if(n == (tekst.Length - 1))
                    {
                        wynik += tekst[n];
                    }
                    else if (tekst[n] != tekst[n + 1])
                    {
                        wynik += tekst[n];
                    }
                }
            }

            return wynik;
        }
    }
}
