using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorDaltonizmu1
{
    internal class Simulator
    {
        private Bitmap image;
        private bool library = true;

        [DllImport("C:\\Users\\Kubotronic\\source\\repos\\SymulatorDaltonizmu\\x64\\Debug\\SymulatorCpp.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int test();
        public Bitmap GetImage()
        {
            return image;
        }
        public bool getLibrary()
        {
            return library;
        }
        public void setImage(Bitmap Image)
        {
            this.image = Image;
        }
        public void setLibrary(bool lib)
        {
            this.library = lib;
        }


        public void start()
        {
            if (this.library)
            {
                //run c++
                //simulate();
                test();
            }
            else
            {
                //run asm
            }
        }
    }
}
