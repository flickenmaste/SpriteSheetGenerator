using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SpriteSheetGen
{
    public class MyCanvas : Canvas
    {
        BitmapImage background = null;

        public void LoadImage(string filename)
        {
            background = new BitmapImage(new Uri(filename));
            this.InvalidateVisual();
        }

        public void GenSheet(string[] images)
        {
            BitmapFrame[] frames = null;
            int[] imageWidth = null;
            int[] imageHeight = null;
            int iW;
            int iH;
            // Load images and get sizes
            for (int i = 0; i < images.Length; i++)
            {
                frames[i] = BitmapDecoder.Create(new Uri(images[i]), BitmapCreateOptions.None, BitmapCacheOption.OnLoad).Frames.First();
                imageWidth[i] = frames[i].PixelWidth;
                imageHeight[i] = frames[i].PixelHeight;
            }
            iW = frames[0].PixelWidth;
            iH = frames[0].PixelHeight;
        }

        protected override void OnRender(DrawingContext dc)
        {
            if (background != null)
            {
                dc.DrawImage(background, new Rect(0, 0, background.PixelWidth,
               background.PixelHeight));
            }
        }
    }
}
