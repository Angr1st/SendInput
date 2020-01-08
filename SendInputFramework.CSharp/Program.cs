using SendInputLib.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
