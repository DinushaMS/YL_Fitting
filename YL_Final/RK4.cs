using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;

namespace YL_Final
{
    public class RK4
    {
        //density of water = 997 kg/m^3
        //density of air = 1.2 kg/m^3
        //interfacial tension of water-air : 0.07199 N/m
        //gravitational acceleration = 9.81 m/s^2
        //q = (997-1.2)*9.81/0.07199 = 137523.8
        public static double R = 1.5; // apex radius
        public static double q = 1.0; // liquid coeff
        public static double yo = 0.0; // drop apex y
        public static double xo = 0.0; // drop apex x
        public static double h = 2.0; // drop height
        public static List<double> YL_X = new List<double>();
        public static List<double> YL_Y = new List<double>();        
        public static List<double> YL_Theta = new List<double>();
        public static List<double> YL_XF = new List<double>();
        public static List<double> YL_YF = new List<double>();
        public static List<double> YL_ThetaF = new List<double>();

        public static void GenerateProfile(double hs)
        {
            double[] param = { 0, 0, 0 };
            YL_X.Clear();
            YL_Y.Clear();
            YL_Theta.Clear();
            //Console.WriteLine("Process started");
            while (param[2] < Math.PI && param[1]+yo <= h)
            {
                param = Solve(param[0], param[1], param[2], hs);
                YL_X.Add(param[0] + xo);
                YL_Y.Add(param[1] + yo);
                YL_Theta.Add(param[2]);                
            }
        }

        public static void GenerateFullProfile(double hs)
        {
            YL_XF.Clear();
            YL_YF.Clear();
            YL_ThetaF.Clear();
            GenerateProfile(hs);
            for (int i = 0; i < YL_X.Count; i++)
            {
                YL_XF.Add(2*xo - YL_X[YL_X.Count - i - 1]);
                YL_YF.Add(YL_Y[YL_Y.Count - i - 1]);
            }

            for (int i = 0; i < YL_X.Count; i++)
            {
                YL_XF.Add(YL_X[i]);
                YL_YF.Add(YL_Y[i]);
            }
        }

        private static double[] Solve(double a, double b, double c, double hs)
        {
            double[] val = {0,0,0};
            double a1 = fa(a, b, c) * hs;
            double b1 = fb(a, b, c) * hs;
            double c1 = fc(a, b, c) * hs;
            double ak = a + a1 * 0.5;
            double bk = b + b1 * 0.5;
            double ck = c + c1 * 0.5;
            double a2 = fa(ak, bk, ck) * hs;
            double b2 = fb(ak, bk, ck) * hs;
            double c2 = fc(ak, bk, ck) * hs;
            ak = a + a2 * 0.5;
            bk = b + b2 * 0.5;
            ck = c + c2 * 0.5;
            double a3 = fa(ak, bk, ck) * hs;
            double b3 = fb(ak, bk, ck) * hs;
            double c3 = fc(ak, bk, ck) * hs;
            ak = a + a3;
            bk = b + b3;
            ck = c + c3;
            double a4 = fa(ak, bk, ck) * hs;
            double b4 = fb(ak, bk, ck) * hs;
            double c4 = fc(ak, bk, ck) * hs;
            val[0] = a + (a1 + 2 * (a2 + a3) + a4) / 6;
            val[1] = b + (b1 + 2 * (b2 + b3) + b4) / 6;
            val[2] = c + (c1 + 2 * (c2 + c3) + c4) / 6;
            return val;
        }

        private static double fa(double a, double b, double c)
        {
            return Math.Cos(c);
        }

        private static double fb(double a, double b, double c)
        {
            return Math.Sin(c);
        }

        private static double fc(double a, double b, double c)
        {
            if (a == 0)
                return (2.0 / R) + q * b;
            else
                return (2.0 / R) + q * b - (Math.Sin(c) / a);
        }
    }
}
