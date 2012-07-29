using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace TangleEdit
{
    public class User32
    {
        [DllImport("user32.dll")]
        public static extern void SetWindowPos(uint Hwnd, uint Level, int X,
            int Y, int W, int H, uint Flags);
    }

    /*
     *  [NC]Harlequin: the fuck is User32?
        Chronojam: public class User32
    {
        [DllImport("user32.dll")]
        public static extern void SetWindowPos(uint Hwnd, uint Level, int X,
            int Y, int W, int H, uint Flags);
    }
        [NC]Harlequin: Oh Jesus
    */

}

