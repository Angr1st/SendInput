using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using SendInputLib.CSharp;

namespace SendInputCore.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            SendInputBindings.PressKey(SendInputBindings.KeyCodes.KEY_A);
            var error = new Win32Exception(Marshal.GetLastWin32Error());

            Console.WriteLine($"{error.Message}; ErrorCode: {error.NativeErrorCode}");
        }
    }
}
