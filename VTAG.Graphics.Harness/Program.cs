using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTAG.Graphics.Harness
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bitmapStream = new FileStream("./inputs/gradtest.png", FileMode.Open, FileAccess.Read)) 
            using (var splash = Splash.CreateInstance(bitmapStream))
            {
                splash.Render();
            }

            using (var bitmapStream = new FileStream("./inputs/epicrpg1.png", FileMode.Open, FileAccess.Read))
            using (var splash = Splash.CreateInstance(bitmapStream))
            {
                splash.Render();
            }

            using (var memoryStream = new MemoryStream())
            using (var splash = Splash.CreateInstance(memoryStream))
            {
                splash.Render();
            }
        }

    }
}
