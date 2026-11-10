namespace Zadanie3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj łańcuch znaku");
            var lancuchZnakow = Console.ReadLine();
            Console.WriteLine(Narzedzia.ZliczSamogloski(lancuchZnakow));
            Console.WriteLine(Narzedzia.UsunPowtorzenia(lancuchZnakow));
        }

    }
}
