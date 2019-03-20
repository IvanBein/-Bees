using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApplication13
{
    class Program
    {
        public static double Beer()
        {
            double a;
            int M = 50;
            bgg[,] klet = new bgg[M, M];
            bgg pure = new bgg();
            pure.R = 0;
            pure.X0 = 0;
            pure.Y0 = 0;
            pure.vid = false;
            int[] shX = new int[10];
            int[] shY = new int[10];
            Random rand = new Random();
            int tempX = 0;
            int tempY = 0;
            int temp = 0;
            double R = 0;

            int m = 0;
            while (m < 8)
            {

                for (int i = 0; i < 10; i++)
                {

                    if (m == 0)
                    {
                        tempX = rand.Next(10, 40);
                        tempY = rand.Next(10, 40);
                        while (klet[tempX, tempY].vid == true)
                        {
                            tempX = rand.Next(10, 40);
                            tempY = rand.Next(10, 40);
                        }
                        klet[tempX, tempY].vid = true;
                        klet[tempX, tempY].X0 = tempX;
                        klet[tempX, tempY].Y0 = tempY;
                        shX[i] = tempX;
                        shY[i] = tempY;
                    }

                    temp = rand.Next(3);
                    switch (temp)
                    {
                        case 0:
                            if (klet[(shX[i] - 1 + M) % M, shY[i]].vid == false)
                            {
                                klet[(shX[i] - 1 + M) % M, shY[i]] = klet[shX[i], shY[i]];
                                klet[shX[i], shY[i]] = pure;
                                shX[i] = (shX[i] - 1 + M) % M;

                            }
                            break;
                        case 1:
                            if (klet[(shX[i] + 1 + M) % M, shY[i]].vid == false)
                            {
                                klet[(shX[i] + 1 + M) % M, shY[i]] = klet[shX[i], shY[i]];
                                klet[shX[i], shY[i]] = pure;
                                shX[i] = (shX[i] + 1 + M) % M;
                            }
                            break;
                        case 2:
                            if (klet[shX[i], (shY[i] - 1 + M) % M].vid == false)
                            {
                                klet[shX[i], (shY[i] - 1 + M) % M] = klet[shX[i], shY[i]];
                                klet[shX[i], shY[i]] = pure;
                                shY[i] = (shY[i] - 1 + M) % M;
                            }
                            break;
                        case 3:
                            if (klet[shX[i], (shY[i] + 1 + M) % M].vid == false)
                            {
                                klet[shX[i], (shY[i] + 1 + M) % M] = klet[shX[i], shY[i]];
                                klet[shX[i], shY[i]] = pure;
                                shY[i] = (shY[i] + 1 + M) % M;
                            }
                            break;
                    }
                }
                m++;
            }
            for (int i = 0; i < 10; i++)
            {
                klet[shX[i], shY[i]].R = Math.Sqrt((shX[i] - klet[shX[i], shY[i]].X0) * (shX[i] - klet[shX[i], shY[i]].X0) + (shY[i] - klet[shX[i], shY[i]].Y0) * (shY[i] - klet[shX[i], shY[i]].Y0));
                R = klet[shX[i], shY[i]].R + R;
            }
            a = R / 10;
            return a;
        }
        public struct bgg
        {
            public int X0;
            public int Y0;
            public double R;
            public bool vid;
            public bgg(int X0, int Y0,  double R, bool vid)
            {
                this.X0 = X0;
                this.Y0 = Y0;
                this.R = R;
                this.vid = vid;
            }
        }
        static void Main(string[] args)
        {
            double a=0;
            double aMax = 4.70;
            double aMin = 2.30;
            int n = 30;
            double[] mas = new double[n];
            double[] Amas = new double[n];
            for (int i = 0; i < 100000; i++)
            {
                a = Beer();
                if ((a < aMax) && (a > aMin))
                {
                    mas[(int)(((a - aMin) / (aMax - aMin)) * n)]++;
                }
              /*  if (i == 0)
                    aMin = a;
                if (a > aMax)
                    aMax = a;
                if (a < aMin)
                    aMin = a;*/
            }
            for(int i=0;i< n; i++)
            {
                Amas[i] = (i / (double)n) * (aMax - aMin) + aMin;
                Console.Write(Amas[i]+" || ");
                Console.WriteLine(mas[i]);

                string file1111 = @"C:\\labamat\\Пчелки\\labatest21.txt";
                StreamWriter writer1111 = new StreamWriter(file1111, true, System.Text.Encoding.Default);
                writer1111.Write(Amas[i].ToString() + "< ");
                writer1111.Close();

                string file1115 = @"C:\\labamat\\Пчелки\\labatest21.txt";
                StreamWriter writer1115 = new StreamWriter(file1115, true, System.Text.Encoding.Default);
                writer1115.Write(mas[i].ToString() + " ");
                writer1115.Close();

                string file11111 = @"C:\\labamat\\Пчелки\\labatest21.txt";
                StreamWriter writer11111 = new StreamWriter(file11111, true, System.Text.Encoding.Default);
                writer11111.WriteLine();
                writer11111.Close();
            }

            Console.ReadLine();
        }
    }
}
