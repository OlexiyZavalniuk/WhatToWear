using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WhatToWear.Core
{
    public class DrawService
    {
        public void DrawImage(string name)
        {
            var r = new Random();
            Image image = Image.FromFile("../WhatToWear.Database/Data/Clear.jpg");

            Graphics g = Graphics.FromImage(image);

            LinearGradientBrush linGrBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(0, 1000),
                Color.FromArgb(r.Next(125, 255), r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)),
                Color.FromArgb(r.Next(125, 255), r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));

            g.FillRectangle(linGrBrush, 0, 0, 1000, 1000);

            var i = r.Next(13, 100);
            for (int k = 0; k < i; k++)
            {
                DrawEmoji(g, 45f);
            }

            i = r.Next(5, 25);
            for (int k = 0; k < i; k++)
            {
                DrawEmoji(g, 70f);
            }

            using (Font fnt = new("Arial", 80f, FontStyle.Bold, GraphicsUnit.Pixel))
            {
                g.DrawString("Happy " + name + "'s Day!", fnt,
                    new SolidBrush(Color.White),
                    50, 50, StringFormat.GenericDefault);
            }

            using (Font fnt = new("Segoe UI emoji", 275f, FontStyle.Bold))
            {
                var emoji = r.Next(0x1F601, 0x1F609);
                g.DrawString(char.ConvertFromUtf32(emoji), fnt,
                    new SolidBrush(Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255))),
                    200, 389, StringFormat.GenericDefault);
            }

            image.Save("../WhatToWear.Database/Data/Result.jpg");          
        }

        private static void DrawEmoji(Graphics g, float f)
        {
            var rnd = new Random();
            var emoji = rnd.Next(0x1F000, 0x1F999);

            using (Font fnt = new("Segoe UI emoji", f))
            {
                g.DrawString(char.ConvertFromUtf32(emoji), fnt,
                    new SolidBrush(Color.FromArgb(rnd.Next(100, 255), rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255))),
                    rnd.Next(0, 1000), rnd.Next(200, 1000), StringFormat.GenericDefault);
            }
        }
    }
}
