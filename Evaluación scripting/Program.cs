using System;
using System.Diagnostics;

namespace Evaluación_scripting
{
    class Program
    {
        static Stopwatch watch = new Stopwatch();
        static void Main(string[] args)
        {
            SearchPath search = new SearchPath();
            watch.Start();
            search.create();
            search.BFS();
            search.CreatePath();
            search.solution();
            watch.Stop();
            Console.ReadKey();
            Console.WriteLine("el tiempo usado fue: " + watch.ElapsedMilliseconds+ " milisegundos");
            

        }
    }
}
