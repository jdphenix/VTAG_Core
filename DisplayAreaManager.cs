using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace VTAG_Attempt_2
{
    /// <summary>
    /// The manager of display areas. A <see cref="DisplayArea"/> should not be instantiated directly; it will not be added to the <seealso cref="DisplayAreaManager"/>'s list.
    /// </summary>
    public static class DisplayAreaManager 
    {
        private static Dictionary<string, DisplayArea> DisplayAreas = new Dictionary<string, DisplayArea>();
        private static List<DisplayArea> DisplayAreaList = new List<DisplayArea>();
        private static int GenericIndex = 0;
        /// <summary>
        /// Create <see cref="DisplayArea "/> and adds it to the <see cref="DisplayAreaManager"/>
        /// </summary>
        /// <returns></returns>
        public static DisplayArea CreateDisplay(Point Location, Size Size)
        {
            DisplayArea displayArea = new DisplayArea(Location, Size);
            displayArea.Build();
            GenericIndex++;
            DisplayAreas.Add(GenericIndex.ToString(), displayArea);
            return displayArea;
        }
        /// <summary>
        /// Takes four parameters that create the location and size of the box, but also gives a generic index.
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static DisplayArea CreateDisplay(Rectangle rect)
        {
            Point Location = new Point(rect.X, rect.Y);
            Size Size = new Size(rect.Width, rect.Height);
            DisplayArea displayArea = new DisplayArea(Location, Size);
            displayArea.Build();
            GenericIndex++;
            DisplayAreas.Add(GenericIndex.ToString(), displayArea);
            return displayArea;
        }
        /// <summary>
        /// Displays all <see cref="DisplayArea"/> objects.
        /// </summary>
        public static void ShowAreas()
        {
            foreach (var Area in DisplayAreas)
            {
                Area.Value.Show();
            }
        }

        internal static void Fancify()
        {
            List<Point> UpperRightCorners = new List<Point>();
            List<Point> LowerRightCorners = new List<Point>();
            List<Point> LowerLeftCorners  = new List<Point>();
            List<Point> UpperLeftCorners  = new List<Point>();

            DisplayAreaList = DisplayAreas.Values.ToList();
            for(int i = 0; i < DisplayAreas.Count; i++)
            {
                UpperRightCorners.Add(new Point(DisplayAreaList[i].Location.X + DisplayAreaList[i].Size.Width, DisplayAreaList[i].Location.Y));
                LowerRightCorners.Add(new Point(DisplayAreaList[i].Location.X + DisplayAreaList[i].Size.Width, DisplayAreaList[i].Location.Y + DisplayAreaList[i].Size.Height));
                LowerLeftCorners.Add(new Point(DisplayAreaList[i].Location.X, DisplayAreaList[i].Location.Y + DisplayAreaList[i].Size.Height - 1));
                UpperLeftCorners.Add(new Point(DisplayAreaList[i].Location.X, DisplayAreaList[i].Location.Y));

            }

            for(int i = 1; i < DisplayAreaList.Count; i++)
            {
                if(UpperRightCorners[i].X == UpperLeftCorners[i].X - 1)
                {
                    Console.Write("Heck");
                }
            }




        }



    }
}
