using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTAG_Attempt_2
{
    public class DisplayAreaManager
    {
        private static List<DisplayArea> displayAreas = new List<DisplayArea>();

        public static DisplayArea CreateDisplay(Point Location, Size Size)
        {

            return null;
        }

        public static DisplayArea CreateDisplay(int x, int y, int w, int h)
        {
            Point Location = new Point(x, y);
            Size Size = new Size(w, h);
            return null;
        }


    }
}
