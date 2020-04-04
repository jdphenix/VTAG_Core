using System;
using System.Drawing;

namespace VTAG.Graphics
{
    internal class NullSplash : Splash
    {
        internal static Splash Instance => new NullSplash(null);

        internal NullSplash(Bitmap bitmap) : base(bitmap) { }

        public override void Render()
        {
            Console.WriteLine("Null image.");
        }
    }
}
