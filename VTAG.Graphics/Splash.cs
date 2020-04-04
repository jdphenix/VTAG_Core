using System;
using System.Drawing;
using System.IO;

namespace VTAG.Graphics
{
    public class Splash : IDisposable
    {
        /// <summary>
        /// Create a Splash from the given Stream. Doesn't assume ownership of the passed Stream.
        /// </summary>
        /// <param name="stream">Stream of a bitmap.</param>
        /// <returns>A Splash, or the null Splash if it can't be loaded.</returns>
        public static Splash CreateInstance(Stream stream)
        {
            if (stream is null)
            {
                return NullSplash.Instance;
            }

            try
            {
                var bitmap = new Bitmap(stream);
                return new Splash(bitmap);
            }
            catch (ArgumentException)
            {
                return NullSplash.Instance;
            }
        }

        public void Dispose()
        {
            _bitmap?.Dispose();
        }

        private readonly Bitmap _bitmap;

        internal Splash(Bitmap bitmap)
        {
            _bitmap = bitmap;
        }

        /// <summary>
        /// Render the splash to the console. Fills the whole window.
        /// </summary>
        public virtual void Render()
        {
            var heightScaleFactor = (double) _bitmap.Height / Console.WindowHeight;
            var widthScaleFactor = (double) _bitmap.Width / Console.WindowWidth;

            var originalColor = Console.ForegroundColor;

            for (double x = 0; x < _bitmap.Height; x += heightScaleFactor)
            {
                for (double y = 0; y < _bitmap.Width; y += widthScaleFactor)
                {
                    var px = _bitmap.GetPixel((int)y, (int)x);

                    var sum = px.R + px.G + px.B;

                    if (px.R >= sum / 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    if (px.G >= sum / 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    if (px.B >= sum / 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }

                    Console.Write('&');
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = originalColor;
        }
    }
}
