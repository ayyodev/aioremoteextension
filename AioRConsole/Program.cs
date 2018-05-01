using System;

namespace AioRConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new AIORClient.AioRemoteClient("https://localhost:44310/WorkersHub");
            client.Connect("test from .net core", "radufly@gmail.com");
            Console.ReadKey();
        }
    }
}
