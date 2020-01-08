using SendInputLib.CSharp;
using System;

namespace SendInputFramework.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            SendInputBindings.PressKey(SendInputBindings.KeyCodes.KEY_A);

            Console.ReadLine();
        }
    }
}
