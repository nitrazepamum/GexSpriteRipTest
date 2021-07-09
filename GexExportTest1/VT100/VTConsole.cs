using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace VT100
{
    static class VTConsole
    {

        // ONLY FOR WINDOWS 10 SHELL
        public static bool enable()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)){
                return Compability.VTWindows.enable();
            }
            else {
                throw new NotSupportedException();
            }
            return false;
        }
        // Console Colors
        public static void setTextColor(byte r, byte g, byte b)
        {
            Console.Write("\x1b[38;2;{0};{1};{2}m", r, g, b);
        }
        public static void setTextColor(Color color)
        {
            setTextColor(color.R, color.G, color.B);
        }
        public static void setBackgroundColor(byte r, byte g, byte b)
        {
            Console.Write("\x1b[48;2;{0};{1};{2}m", r, g, b);
        }
        public static void setBackgroundColor(Color color)
        {
            setBackgroundColor(color.R, color.G, color.B);
        }
        public static void resetColor()
        {
            Console.ResetColor();
        }
        public static void resetTextColor()
        {
            Console.Write("\x1b[39m");
        }
        public static void resetBackgroundColor()
        {
            Console.Write("\x1b[49m");
        }
        public static void clear()
        {
            Console.Clear();
        }

    }
}
