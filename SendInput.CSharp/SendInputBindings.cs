using System.Runtime.InteropServices;

namespace SendInputLib.CSharp
{
    public static class SendInputBindings
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct MOUSEINPUT
        {
            public int dx { get; }
            public int dy { get; }
            public uint mouseData { get; }
            public uint dwFlags { get; }
            public uint time { get; }
            public int dwExtraInfo { get; }

            public MOUSEINPUT(int _dx, int _dy, uint _mouseData, uint _dwFlags, uint _time, int _dwExtraInfo)
            {
                dx = _dx;
                dy = _dy;
                mouseData = _mouseData;
                dwFlags = _dwFlags;
                time = _time;
                dwExtraInfo = _dwExtraInfo;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct KEYBDINPUT
        {
            public ushort wVk { get; }
            public ushort wScan { get; }
            public uint dwFlags { get; }
            public uint time { get; }
            public int dwExtraInfo { get; }

            public KEYBDINPUT(ushort _wVk, ushort _wScan, uint _dwFlags, uint _time, int _dwExtraInfo)
            {
                wVk = _wVk;
                wScan = _wScan;
                dwFlags = _dwFlags;
                time = _time;
                dwExtraInfo = _dwExtraInfo;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct HARDWAREINPUT
        {
            public uint uMsg { get; }
            public ushort wParamL { get; }
            public ushort wParamH { get; }

            public HARDWAREINPUT(uint _uMsg, ushort _wParamL, ushort _wParamH)
            {
                uMsg = _uMsg;
                wParamL = _wParamL;
                wParamH = _wParamH;
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct LPINPUT
        {
            [FieldOffset(0)]
            public int @type; // 1 is keyboard

            [FieldOffset(4)]
            public MOUSEINPUT mi;

            [FieldOffset(4)]
            public KEYBDINPUT ki;

            [FieldOffset(4)]
            public HARDWAREINPUT hi;
        }

        private static class InputModes
        {
            public const int INPUT_MOUSE = 0;
            public const int INPUT_KEYBOARD = 1;
            public const int INPUT_HARDWARE = 2;
        }

        private static class Dwords
        {
            public const uint KEYEVENTF_KEYDOWN = 0x0000;
            public const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
            public const uint KEYEVENTF_KEYUP = 0x0002;
            public const uint KEYEVENTF_UNICODE = 0x0004;
            public const uint KEYEVENTF_SCANCODE = 0x0008;
        }

        private static class KeyCodes
        {
            public const int VK_CONTROL = 162;
            public const int VK_TAB = 9;
            public const int VK_LWIN = 91;
            public const int VK_RIGHT = 39;
            public const int VK_UP = 38;
            public const int VK_DOWN = 40;
            public const int VK_LEFT = 37;
            public const int VK_SHIFT = 160;
            public const int VK_ESCAPE = 27;

            // These are left and right alt
            public const int VK_LMENU = 164;
            public const int VK_RMENU = 165;

            public const int KEY_A = 65;
            public const int KEY_H = 72;
            public const int KEY_J = 74;
            public const int KEY_K = 75;
            public const int KEY_L = 76;
        }

        private static class NativeMethods
        {
            [DllImport("user32.dll", SetLastError = true)]
            public static extern unsafe uint SendInput(uint nInputs, LPINPUT* pInputs, int cbSize);
        }

        public const int appSignature = 0xA8969;

        private static LPINPUT createPressInput(int code) 
            => new LPINPUT() { type = InputModes.INPUT_KEYBOARD, ki = new KEYBDINPUT((ushort)code, 0, Dwords.KEYEVENTF_KEYDOWN, 0, appSignature) };

        private static LPINPUT createReleaseInput(int code) 
            => new LPINPUT() { type = InputModes.INPUT_KEYBOARD, ki = new KEYBDINPUT((ushort)code, 0, Dwords.KEYEVENTF_KEYUP, 0, appSignature) };

        public unsafe static void PressKey(int code)
        {
            var input = createPressInput(code);
            NativeMethods.SendInput(1, &input, Marshal.SizeOf(input));
        }

        public unsafe static void ReleaseKey(int code)
        {
            var input = createReleaseInput(code);
            NativeMethods.SendInput(1, &input, Marshal.SizeOf(input));
        }
    }
}
