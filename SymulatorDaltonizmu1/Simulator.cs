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

        private void simulate()
        { 

            //=============================  https://github.com/jkulesza/peacock/blob/master/cpp/src/CB_Converter.hpp
            uint range;
            // Run-time values
            float cpu = 0.753f;
            float cpv = 0.265f;
            float am= 1.273463f;
            float ayi= -0.073894f;

            //compile-time constants.
            const float cb_gamma = 2.2f;
            const float wx = 0.312713f;
            const float wy = 0.329016f;
            const float wz = 0.358271f;
            const float v = 1.75f;
            const float d = v + 1.0f;
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
