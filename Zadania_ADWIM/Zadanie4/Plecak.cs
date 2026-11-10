using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie4
{
    internal class Plecak
    {
        public int MaxPojemnosc = 12000;
        public int Pojemnosc = 0;
        public List<Przedmiot> Wynik = new List<Przedmiot>();

        public void DodajDoListy(Przedmiot przedmiot)
        {
            Wynik.Add(przedmiot);
        }
    }
}
