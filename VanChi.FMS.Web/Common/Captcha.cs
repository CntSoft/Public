using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Web;

namespace VanChi.FMS.Web.Common
{
    public class Captcha
    {
        /// <summary>
        /// Chiều rộng
        /// </summary>
        public const int Width = 200;

        /// <summary>
        /// Chiều cao
        /// </summary>
        public const int Height = 60;

        public string CaptchaBase64(string plainText, bool noisy = true)
        {
            var rand = new Random((int)DateTime.Now.Ticks);
            using (var mem = new MemoryStream())
            {
                using (var bmp = new Bitmap(Width, Height))
                {
                    using (var gfx = Graphics.FromImage(bmp))
                    {
                        gfx.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                        gfx.SmoothingMode = SmoothingMode.AntiAlias;
                        gfx.FillRectangle(Brushes.White, new Rectangle(0, 0, bmp.Width, bmp.Height));
                        if (noisy)
                        {
                            int i;
                            var pen = new Pen(Color.Yellow);
                            for (i = 1; i < 10; i++)
                            {
                                pen.Color = Color.FromArgb((rand.Next(0, 255)), (rand.Next(0, 255)), (rand.Next(0, 255)));
                                int r = rand.Next(0, (Width / 3));
                                int x = rand.Next(0, Width);
                                int y = rand.Next(0, Height);
                                gfx.DrawEllipse(pen, x - r, y - r, r, r);
                            }
                        }
                        gfx.DrawString(plainText, new Font("Tahoma", 19), Brushes.Gray, 2, 3);
                        bmp.Save(mem, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] byteImage = mem.ToArray();
                        return Convert.ToBase64String(byteImage);
                    }
                }
            }
        }
    }
}