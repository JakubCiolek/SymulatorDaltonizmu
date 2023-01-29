﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;
using System.Diagnostics;
using System.Threading;
using System.Diagnostics.Metrics;
using System.Windows.Forms;
using System.Data;
using System.Runtime.CompilerServices;

namespace SymulatorDaltonizmu1
{
    internal class Simulator
    {
        private Bitmap image;
        private Bitmap blindImage;
        private bool library = true;
        int threadsNo = 1;

        private int range;
        // Run-time values Deuteranopia conversion coefficients 
        private float cpu = 0.753f;
        private float cpv = 0.265f;
        private float am = 1.273463f;
        private float ayi = -0.073894f;

        //compile-time constants.
        private const float cb_gamma = 2.2f;
        private const float wx = 0.312713f;
        private const float wy = 0.329016f;
        private const float wz = 0.358271f;
        private const float v = 1.75f;
        private const float d = v + 1.0f;


        private List<float> powGammaLookup;
        private Color[,] pixelArray;
        List<Thread> threads = new List<Thread>();

        //private object __lockObj;
        //private bool __lockWasTaken = false;
        public Simulator(Bitmap image)
        {
            this.image = image;
            this.blindImage = image;
            //this.range = Bitmap.GetPixelFormatSize(image.PixelFormat);
            this.range = 255;
            powGammaLookup = create_Gamma_Lookup();
            pixelArray = new Color[blindImage.Width, blindImage.Height];
            //__lockObj = this.blindImage;
        }

        [DllImport("E:\\StudiaWszystkiePliki\\studia\\JA\\projekt\\Symulator\\x64\\Debug\\SimAsm.dll")]
        static extern void SimulatorAsm(float[] xyz);

        //static extern int MyProc1(int a, int b);
        public Bitmap GetImage()
        {
            return image;
        }
        public Bitmap GetBlindImage()
        {
            return blindImage;
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
        public void setThreads(int n)
        {
            this.threadsNo = n;
        }

        public long simulate()
        {
            int imageX = pixelArray.GetLength(0);
            int imageY = pixelArray.GetLength(1);
            MakePixelArray();
            int counter = 0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (threadsNo > 1) // THREADS TO DO
            {
                //Parallel.For(0, imageX, new ParallelOptions { MaxDegreeOfParallelism = threadsNo }, x => { Threads(x); });
                //int rest = imageX % threadsNo;
                //int loop = (imageX - rest) / threadsNo;
                //int Xpos = 0;
                //for (int x = 0; x < loop; x++)
                //{
                //    for(int t=0;t<threadsNo;t++)
                //    {
                //        threads.Add(new Thread(() => Threads(Xpos)));
                //        threads[t].Start();
                //        Xpos++;
                //    }
                //    foreach (Thread t in threads)
                //    {
                //        t.Join();
                //    }
                //    threads.Clear();
                //}
                //for(int i = imageX - rest; i< imageX;i++)
                //{
                //    threads.Add(new Thread(() => Threads(Xpos)));
                //    threads[counter].Start();
                //    counter++;
                //    Xpos++;
                //}
                //foreach (Thread t in threads)
                //{
                //    t.Join();
                //}
                //threads.Clear();
                //for (int x = 0; x < imageX; x++)
                //{
                //    for(int y = 0; y<imageY; y++)
                //    {
                //        threads.Add(new Thread(() => convert_colorblind(pixelArray[x,y],x,y)));
                //        counter++;
                //        if (threads.Count == threadsNo)
                //        {
                //            foreach(Thread t in threads)
                //            {
                //                t.Start();
                //            }
                //            foreach (Thread t in threads)
                //            {
                //                t.Join();
                //            }
                //            threads.Clear();
                //            counter = 0;
                //        }
                //    }
                //    foreach (Thread t in threads)
                //    {
                //        t.Start();
                //    }
                //    foreach (Thread t in threads)
                //    {
                //        t.Join();
                //    }
                //    threads.Clear();
                //    counter = 0;
                //}
                for (int x = 0; x < imageX; x++)
                {
                    //Color pixelColor = blindImage.GetPixel(x, y);
                    threads.Add(new Thread(() => Threads(x)));
                    threads[counter].Start();
                    counter++;
                    if (threads.Count == threadsNo)
                    {
                        for (int i = 0; i < threads.Count; i++)
                        {
                            threads[i].Join();
                        }
                        threads.Clear();
                        counter = 0;
                    }
                }
                for (int i = 0; i < threads.Count; i++)
                {
                    threads[i].Join();
                }
                threads.Clear();
                counter = 0;
            }
            else
            {
                for (int x = 0; x < blindImage.Width; x++)
                {
                    for (int y = 0; y < blindImage.Height; y++)
                    {
                        Color pixelColor = blindImage.GetPixel(x, y);
                        convert_colorblind(pixelColor, x, y);
                    }
                }
            }
            stopwatch.Stop();
            //pixelArayyToImage();
            return stopwatch.ElapsedMilliseconds;
        }
        void Threads(int col)
        {
           // if (col < pixelArray.GetLength(0))
           // {
                for (int y = 0; y < pixelArray.GetLength(1); y++)
                {
                    convert_colorblind(pixelArray[col, y], col, y);
                }
           // }
        }
        void MakePixelArray()
        {
            for (int x = 0; x < pixelArray.GetLength(0); x++)
            {
                for (int y = 0; y < pixelArray.GetLength(1); y++)
                {
                    pixelArray[x, y] = blindImage.GetPixel(x, y);
                }
            }
        }
        void pixelArayyToImage()
        {
            for (int x = 0; x < pixelArray.GetLength(0); x++)
            {
                for (int y = 0; y < pixelArray.GetLength(1); y += threadsNo)
                {
                    blindImage.SetPixel(x, y, pixelArray[x, y]);
                }
            }
        }
        void convert_colorblind(Color pixelColor, int x, int y)
        {

            float cr = powGammaLookup[pixelColor.R];
            float cg = powGammaLookup[pixelColor.G];
            float cb = powGammaLookup[pixelColor.B];

            float cx = (0.430574f * cr + 0.341550f * cg + 0.178325f * cb);
            float cy = (0.222015f * cr + 0.706655f * cg + 0.071330f * cb);
            float cz = (0.020183f * cr + 0.129553f * cg + 0.939180f * cb);

            float sum_xyz = cx + cy + cz;
            float cu = 0.0f;
            float cv = 0.0f;

            if (sum_xyz != 0.0f)
            {
                cu = cx / sum_xyz;
                cv = cy / sum_xyz;
            }

            float nx = wx * cy / wy;
            float nz = wz * cy / wy;

            float clm = 0.0f;
            const float dy = 0.0f;

            if (cu < cpu)
            {
                clm = (cpv - cv) / (cpu - cu);
            }
            else
            {
                clm = (cv - cpv) / (cu - cpu);
            }
            float clyi = cv - cu * clm;
            float du = (ayi - clyi) / (clm - am);
            float dv = (clm * du) + clyi;

            float sx = du * cy / dv;
            float sy = cy;
            float sz = (1.0f - (du + dv)) * cy / dv;

            float dx = nx - sx;
            float dz = nz - sz;
            // Convert xyz to rgb.

            //========================= ASM ========================
            float sr = 0;
            float sg = 0;
            float sb = 0;
            float dr = 0;
            float dg = 0;
            float db = 0;
            if (library)
            {
                sr = (3.063218f * sx - 1.393325f * sy - 0.475802f * sz);
                sg = (-0.969243f * sx + 1.875966f * sy + 0.041555f * sz);
                sb = (0.067871f * sx - 0.228834f * sy + 1.069251f * sz);


                // Convert xyz to rgb.
                dr = (3.063218f * dx - 1.393325f * dy - 0.475802f * dz);
                dg = (-0.969243f * dx + 1.875966f * dy + 0.041555f * dz);
                db = (0.067871f * dx - 0.228834f * dy + 1.069251f * dz);
            }
            else
            {
                float[] asm = { sx, sy, sz, 0.0f };
                SimulatorAsm(asm);
                sr = asm[0];
                sg = asm[1];
                sb = asm[2];
                float[] asm1 = {dx,dy,dz, 0.0f };
                SimulatorAsm(asm1);
                dr = asm1[0];
                dg = asm1[1];
                db = asm1[2];
                //int retval = MyProc1(5,7);
            }


            //========================= ASM END ========================

            float adjr = dr > 0 ? ((sr < 0 ? 0 : 1) - sr) / dr : 0;
            float adjg = dg > 0 ? ((sg < 0 ? 0 : 1) - sg) / dg : 0;
            float adjb = db > 0 ? ((sb < 0 ? 0 : 1) - sb) / db : 0;

            float[] list = {
                   (float)( adjr > 1.0 || adjr < 0.0 ? 0.0 : adjr ),
                   (float)( adjg > 1.0 || adjg < 0.0 ? 0.0 : adjg ),
                   (float)( adjb > 1.0 || adjb < 0.0 ? 0.0 : adjb ),
             };

            float adjust = list.Max();

            sr = sr + (adjust * dr);
            sg = sg + (adjust * dg);
            sb = sb + (adjust * db);

            Color newColor = Color.FromArgb(inversePow(sr), inversePow(sg), inversePow(sb));

            lock (blindImage)
            {
                blindImage.SetPixel(x, y, newColor);
            }
            //lock (pixelArray)
            //{
            //    pixelArray[x, y] = newColor;
            //}
            
            return;
        }
        List<float> create_Gamma_Lookup()
        {
            List<float> powGammaLookupTemp = new List<float>();
            double doubleRange = (double)range;
            for (int i = 0; i <= range + 1; ++i)
            {
                powGammaLookupTemp.Add(0.0f);
            }
            for (int i = 0; i <= range; ++i)
            {
                double idouble = (double)i;
                powGammaLookupTemp[i] = (float)(Math.Pow(idouble / doubleRange, 2.2));
            }
            return powGammaLookupTemp;
        }

        int inversePow(double x)
        {
            double drange = (double)range;
            return (int)Math.Round(drange * (x <= 0.0 ? 0.0 : (x >= 1.0 ? 1.0 : Math.Pow(x, 1.0 / 2.2))));
        }


        public String start()
        {
            if (this.library)
            {
                //run c#
                return simulate().ToString();
            }
            else
            {
                //run asm
                return simulate().ToString();
            }
        }

    }
}
