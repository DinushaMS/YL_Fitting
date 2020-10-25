using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace YL_Final
{
    public partial class Form1 : Form
    {
        Image img = Properties.Resources._1;
        List<Point> needleL = new List<Point>();
        List<Point> needleR = new List<Point>();
        List<Point> dropL = new List<Point>();
        List<Point> dropR = new List<Point>();
        int avg_needle_xl = 0;
        int avg_needle_xr = 0;
        int pxPerM = 1;
        int BLyR = 0;
        int BLyL = 0;
        Point RCR;
        double radiusR = 0;
        double thetaR = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
            Bitmap img = new Bitmap(pictureBox1.Image);
            Point xl_o = new Point(0, 0);
            Point xr_o = new Point(0, 0);
            
            //Find left top contact point
            for (int x = 0; x < img.Width; x++)
            {
                if (img.GetPixel(x, 0).R < 50)
                {
                    //Black pixel found
                    xl_o = new Point(x, 0);
                    avg_needle_xl = xl_o.X-1;
                    break;
                }
            }

            //Find right top contact point
            for (int x = xl_o.X+1; x < img.Width; x++)
            {
                if (img.GetPixel(x, 0).R > 50)
                {
                    //white pixel found
                    xr_o = new Point(x, 0);
                    avg_needle_xr = xr_o.X;
                    break;
                }
            }

            //iterate for needle contour: left
            bool isDone = false;
            for (int y = xl_o.Y; y < img.Height; y++)
            {
                for (int x = xl_o.X; x > 0; x--)
                {
                    if(img.GetPixel(x,y).R > 50)
                    {
                        //white pixel found
                        int tol = 10;
                        if (x < avg_needle_xl+tol && x > avg_needle_xl-tol)
                        {
                            needleL.Add(new Point(x, y));
                            avg_needle_xl = AVG(needleL);
                        }
                        else
                        {
                            isDone = true;
                        }
                        break;
                    }
                }
                if (isDone)
                {
                    //remove unwanted points
                    int len = needleL.Count;
                    for (int i = 1; i < 10; i++)
                    {
                        if (needleL[len - i].X < avg_needle_xl)
                        {
                            needleL.RemoveAt(needleL.Count-1);
                        }
                        else
                            break;
                    }
                    
                    break;
                }
            }

            //Set scale variable
            pxPerM = Convert.ToInt32((avg_needle_xr - avg_needle_xl) / 0.000337);
            Debug.WriteLine(pxPerM.ToString());
            //iterate for needle contour: right
            isDone = false;
            for (int y = xr_o.Y; y < img.Height; y++)
            {
                for (int x = xr_o.X-5; x < img.Width; x++)
                {
                    if (img.GetPixel(x, y).R > 50)
                    {
                        //white pixel found
                        int tol = 10;
                        if (x < avg_needle_xr + tol && x > avg_needle_xr - tol)
                        {
                            needleR.Add(new Point(x, y));
                            avg_needle_xr = AVG(needleR);
                        }
                        else
                        {
                            isDone = true;
                        }
                        break;
                    }
                }
                if (isDone)
                {
                    //remove unwanted points
                    int len = needleR.Count;
                    for (int i = 1; i < 10; i++)
                    {
                        if (needleR[len - i].X > avg_needle_xr)
                        {
                            needleR.RemoveAt(needleR.Count-1);
                        }
                        else
                            break;
                    }

                    break;
                }
            }

            //left drop contour
            isDone = false;
            dropL.Add(new Point(needleL[needleL.Count - 1].X, needleL[needleL.Count - 1].Y));
            int x_ = needleL[needleL.Count - 1].X;
            for (int y = needleL[needleL.Count-1].Y+1; y < img.Height; y++)
            {
                for (int i = 0; i < 50; i++)
                {
                    if(img.GetPixel(x_,y).R > 50)
                    {
                        //white pixel found
                        if (Math.Abs(dropL[dropL.Count - 1].X - x_) < 10 || dropL.Count == 1)
                        {
                            dropL.Add(new Point(x_, y));
                            x_ += 10;
                        }
                        else
                        {
                            isDone = true;
                        }
                        break;
                    }
                    x_--;
                    if(x_ < 0)
                    {
                        isDone = true;
                        break;
                    }
                }
                if (isDone) break;
            }

            //right drop contour
            isDone = false;
            x_ = needleR[needleR.Count - 1].X;
            dropR.Add(new Point(needleR[needleR.Count - 1].X, needleR[needleR.Count - 1].Y));
            for (int y = needleR[needleR.Count - 1].Y + 1; y < img.Height; y++)
            {
                for (int i = 0; i < 50; i++)
                {
                    if (img.GetPixel(x_, y).R > 50)
                    {
                        //white pixel found
                        if (Math.Abs(dropR[dropR.Count - 1].X - x_) < 10 || dropR.Count == 1)
                        {
                            dropR.Add(new Point(x_, y));
                            x_ -= 10;
                        }
                        else
                        {
                            isDone = true;
                        }
                        break;
                    }
                    x_++;
                    if (x_ >= img.Width)
                    {
                        isDone = true;
                        break;
                    }
                }
                if (isDone) break;
            }

            Point[] p = {dropR[0],dropR[5],dropR[10]};
            BLyR = dropR[dropR.Count - 1].Y;
            CircleFit.Fit(p, out radiusR, out RCR);

            drawCircle(RCR, (int)radiusR);

            //color found points
            foreach (var item in needleL)
            {
                img.SetPixel(item.X, item.Y,Color.Red);
            }
            foreach (var item in needleR)
            {
                img.SetPixel(item.X, item.Y, Color.Yellow);
            }
            foreach (var item in dropL)
            {
                img.SetPixel(item.X, item.Y, Color.Green);
            }
            foreach (var item in dropR)
            {
                img.SetPixel(item.X, item.Y, Color.Purple);
            }

            for (int y = 0; y < img.Height; y++)
            {
                //img.SetPixel(avg_needle_xl, y, Color.Blue);
            }
            for (int y = 0; y < img.Height; y++)
            {
                //img.SetPixel(avg_needle_xr, y, Color.Blue);
            }

            pictureBox1.Image = img;
        }

        private int AVG(List<Point> points)
        {
            int avg = 0;
            int N = points.Count();
            foreach (var item in points)
            {
                avg += item.X;
            }
            return avg/N;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Bitmap img = new Bitmap(pictureBox1.Image);
            var R = img.GetPixel(e.X, e.Y).R.ToString();
            var B = img.GetPixel(e.X, e.Y).B.ToString();
            var G = img.GetPixel(e.X, e.Y).G.ToString();
            label1.Text = $"X:{e.X}   Y:{e.Y}\nRed    :{R}\nGreen  :{G}\nBlue   :{B}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            update();
        }

        private void update()
        {
            pictureBox1.Refresh();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            RK4.xo = (double)RCR.X / pxPerM;
            RK4.yo = ((double)RCR.Y - radiusR) / pxPerM;
            RK4.R = radiusR * (tbR.Value / 1000.0) / pxPerM;
            RK4.q = 137523.8 * (tbq.Value / 1000.0);
            RK4.h = BLyR*(tbH.Value/1000.0) / pxPerM;
            RK4.GenerateFullProfile(0.000025);
            thetaR = RK4.YL_Theta[RK4.YL_Theta.Count - 1] * (180.0 / Math.PI);
            sw.Stop();
            //MessageBox.Show($"Process took {sw.Elapsed}");
            //for (int i = 0; i < RK4.YL_X.Count; i++)
            //{
            //    Debug.WriteLine($"X:{RK4.YL_X[i]*pxPerM} Y:{RK4.YL_Y[i]*pxPerM} Theta:{RK4.YL_Theta[i]*(180.0/Math.PI)}");
            //}

            for (int i = 0; i < RK4.YL_XF.Count; i++)
            {
                int x = (int)(RK4.YL_XF[i] * pxPerM);
                int y = (int)(RK4.YL_YF[i] * pxPerM);
                drawPoint(x, y);
            }

            label2.Text = $"CA  :{Math.Round(thetaR, 1)}°\n" +
                $"R   :{Math.Round(RK4.R*1000, 2)} ({Math.Round((tbR.Value/10.0)-100.0, 1)}%) mm\n" +
                $"q   :{Math.Round(RK4.q/10000.0, 2)} ({Math.Round((tbq.Value / 10.0) - 100.0, 1)}%) cm⁻²\n" +
                $"h   :{Math.Round(RK4.h*1000, 2)} ({Math.Round((tbH.Value / 10.0) - 100.0, 1)}%) mm\n" +
                $"SE  :{Math.Round((997.0 - 1.2) * 9.81 *1000.0 / RK4.q, 1)} mN/m";
        }

        public void drawPoint(int x, int y)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            SolidBrush brush = new SolidBrush(Color.Green);
            //Point dPoint = new Point(x, (pictureBox1.Height - y));
            Point dPoint = new Point(x, y);
            dPoint.X = dPoint.X - 1;
            dPoint.Y = dPoint.Y - 1;
            Rectangle rect = new Rectangle(dPoint, new Size(2, 2));
            g.FillRectangle(brush, rect);
            g.Dispose();
        }

        public void drawCircle(Point rc, int rad)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            Pen pen = new Pen(Color.Red);
            //Point dPoint = new Point(x, (pictureBox1.Height - y));
            Rectangle rect = new Rectangle(rc.X - rad, rc.Y - rad, 2 * rad, 2 * rad);
            g.DrawEllipse(pen, rect);
            g.Dispose();
        }

        private void tbR_Scroll(object sender, EventArgs e)
        {
            update();
        }

        private void tbq_Scroll(object sender, EventArgs e)
        {
            update();
        }

        private void tbH_Scroll(object sender, EventArgs e)
        {
            update();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.png, *.jpg, *.bmp, *.jpeg)|*.png;*.jpg;*.bmp;*.jpeg|All files (*.*)|*.*";
            //ofd.InitialDirectory = @"C:\";
            ofd.Title = "Please select an drop image file to analyze.";
            DialogResult res = ofd.ShowDialog();
            if (res == DialogResult.OK)
            {
                img = new Bitmap(ofd.FileName);
                Reset();
            }
        }

        private void Reset()
        {
            needleL = new List<Point>();
            needleR = new List<Point>();
            dropL = new List<Point>();
            dropR = new List<Point>();
            avg_needle_xl = 0;
            avg_needle_xr = 0;
            pxPerM = 1;
            BLyR = 0;
            BLyL = 0;
            radiusR = 0;
            thetaR = 0;
            pictureBox1.Image = img;
        }
    }
}
