namespace Zadania_ADWIM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = 2;
            int n = 100;
            var a = new bool[n + 1];
            for (var i = 0; i < a.Length; i++)
            {
                a[i] = true;
            }
            for (int i = start; i < Math.Sqrt(n); i++)
            {
                if (a[i])
                {
                    for (var j = 2*i; j <= n; j += i)
                    {
                        a[j] = false;
                    }
                }
            }
            Console.WriteLine("Liczby pierwsze z przedziału 2..100:");
            for (var i = 2; i <= n; i++)
            {
                if (a[i] == true)
                {
                    Console.WriteLine($"{i},");
                }
            }
        }
    }
}
