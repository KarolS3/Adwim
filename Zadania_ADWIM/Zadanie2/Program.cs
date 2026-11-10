using System.Reflection.Metadata.Ecma335;

namespace Zadanie2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            string gotoweHaslo = string.Empty;
            var male = "abcdefghijklmnoprstuwxyzq";
            var duze = "ABCDEFGHIJKLMNOPRSTUWXYZQ";
            var polskie = "ąęłńóśźżĄĘŁŃÓŚŹŻ";
            var specjalne = "!@#$%^&*()_+";
            var liczby = "0123456789";
            List<char> haslo = new List<char>();
            for (int i = 0; i < 3; i++) 
            {
                haslo.Add(male[rnd.Next(0,male.Length)]);
            }
            for (int i = 0; i < 3; i++)
            {
                haslo.Add(duze[rnd.Next(0, duze.Length)]);
            }
            for (int i = 0; i < 2; i++)
            {
                haslo.Add(polskie[rnd.Next(0, polskie.Length)]);
            }
            for (int i = 0; i < 2; i++)
            {
                haslo.Add(specjalne[rnd.Next(0, specjalne.Length)]);
            }
            for (int i = 0; i < 2; i++)
            {
                haslo.Add(liczby[rnd.Next(0, liczby.Length)]);
            }
            for (int i = 0; i < 12; i++)
            {
                var znak = haslo[rnd.Next(0, haslo.Count)];
                gotoweHaslo += znak;
                haslo.Remove(znak);
            }
            Console.WriteLine(gotoweHaslo);
        }
    }
}
