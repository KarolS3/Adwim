using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie4
{

    
    public class Przedmiot
    {

        public int Id { get; set; }
        public string Nazwa { get; set; }
        public int  Waga { get; set; }
        public int Cena { get; set; }

        public double Wartosc {  get => Cena / (double)Waga; }
    }
}
