using System;

namespace HyperjoAPI.CSharpWrapper.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            HyperjoAPIWrapper hyperjoApi = new HyperjoAPIWrapper();

            var s = hyperjoApi.GetFarming();
            
            Console.ReadLine();
        }
    }
}
