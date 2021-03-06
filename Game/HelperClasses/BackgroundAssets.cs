﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Brushes = System.Drawing.Brushes;
using Point = System.Drawing.Point;
using Size = System.Windows.Size;

namespace Game.HelperClasses
{
    public static class BackgroundAssets
    {
        public static string Start_Screen = "../../VisualAssets/Backgrounds/Start Screen.jpg";
        public static string Running_Background = "../../VisualAssets/Backgrounds/Blank_Background.png";
        public static string Clouds = "../../VisualAssets/Backgrounds/Clouds.png";
        public static string Foreground = "../../VisualAssets/Backgrounds/Foreground.png";
        public static string Store = "../../VisualAssets/Backgrounds/Store1.png";
        public static string High_Scores = "../../VisualAssets/Backgrounds/HighScores.png";
        public static string GameOver = "../../VisualAssets/Backgrounds/GameOver.png";

        public static string Background_Red = "../../VisualAssets/Backgrounds/Blank_Background_Red.png";
        public static string Background_DarkBlue = "../../VisualAssets/Backgrounds/Blank_Background_DarkBlue.png";
        public static string Background_Grey = "../../VisualAssets/Backgrounds/Blank_Background_Grey.png";
        public static string Background_Pink = "../../VisualAssets/Backgrounds/Blank_Background_Pink.png";
        public static string Background_Purple = "../../VisualAssets/Backgrounds/Blank_Background_Purple.png";
        public static string Background_Yellow = "../../VisualAssets/Backgrounds/Blank_Background_Yellow.png";

        public static readonly List<string> OctocatRed = new List<string>
        {
            ""
        };

        public static readonly List<string> OctocatBlue = new List<string>
        {
            ""
        };

        public static readonly List<string> OctocatGreen = new List<string>
        {
            ""
        };


        public static void WriteTextToBitmap(WriteableBitmap bm, List<Tuple<String, Point, int>> data)
        {

            Bitmap bmap;
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create((BitmapSource)bm));
                enc.Save(outStream);
                bmap = new System.Drawing.Bitmap(outStream);
            }

            using (Graphics g = Graphics.FromImage(bmap))
            {
                Font font;
                foreach (var item in data)
                {
                    font = new Font("Times New Roman", item.Item3);
                    g.DrawString(item.Item1, font, Brushes.Black, item.Item2);
                }
                
                IntPtr hBmap = bmap.GetHbitmap();

                try
                {
                    BitmapSource Bsource = Imaging.CreateBitmapSourceFromHBitmap(hBmap, IntPtr.Zero,
                        Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    WriteableBitmap NewBmap = new WriteableBitmap(Bsource);

                    bm.Blit(new System.Windows.Point(0,0), NewBmap, new Rect(new Size((double)NewBmap.PixelWidth,
                        (double)NewBmap.PixelHeight)), Colors.White, WriteableBitmapExtensions.BlendMode.Alpha);
                }
                finally { }
            }

            
        }

    }
}
