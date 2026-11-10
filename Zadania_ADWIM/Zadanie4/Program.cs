using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.IO;


namespace Zadanie4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var WynikCena = 0;
            var lines = File.ReadAllLines("assets\\items.csv");
            List<Przedmiot> listaPrzedmiotow = new List<Przedmiot>();
            foreach (var line in lines.Skip(1))
            {
                string[] cols = line.Split(';');
                listaPrzedmiotow.Add(new Przedmiot()
                {
                    Id = int.Parse(cols[0]),
                    Nazwa = cols[1],
                    Waga = int.Parse(cols[2]),
                    Cena = int.Parse(cols[3])
                });
            }

            var posortowanaLista = listaPrzedmiotow.OrderByDescending(p => p.Wartosc).ToList();

            Plecak plecak = new Plecak();
            while(plecak.Pojemnosc <= plecak.MaxPojemnosc)
            {
                foreach(Przedmiot przedmiot in posortowanaLista)
                {
                    if (plecak.Pojemnosc + przedmiot.Waga <= plecak.MaxPojemnosc)
                    {
                        plecak.DodajDoListy(przedmiot);
                        plecak.Pojemnosc += przedmiot.Waga;
                        Console.WriteLine(przedmiot.Nazwa);
                        WynikCena += przedmiot.Cena;
                    }
                }
                break;
            }
            Console.WriteLine(WynikCena);
        }
    }
}
