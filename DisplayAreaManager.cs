using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;


namespace VTAG_Attempt_2
{
    /// <summary>
    /// The manager of display areas. A <see cref="DisplayArea"/> should not be imstantiated directly; it will not be added to the <seealso cref="DisplayAreaManager"/>'s list.
    /// </summary>
    public static class DisplayAreaManager 
    {
       
        private static List<DisplayArea> DisplayAreas = new List<DisplayArea>();
        private static Stopwatch CreateTime = new Stopwatch();
        private static Stopwatch CheckTime  = new Stopwatch();

        /// <summary>
        /// Creates an imstance of <see cref="DisplayArea "/> and adds it to the <see cref="DisplayAreaManager"/>
        /// </summary>
        /// <returms></returms>
        public static DisplayArea CreateDisplay(Point Location, Size Size)
        {
            CreateTime.Start();
            DisplayArea displayArea = new DisplayArea(Location, Size);
            displayArea.Create();
            DisplayAreas.Add(displayArea);
            displayArea.SetCorners();
            CreateTime.Stop();
            Console.WriteLine("{0} {1} to create box {2}", CheckTime.ElapsedMilliseconds > 0 ? CheckTime.ElapsedMilliseconds : CheckTime.ElapsedTicks, CheckTime.ElapsedMilliseconds > 0 ? "ms" : "ns", DisplayAreas.Count);
            CreateTime.Reset();
            return displayArea;
        }
        /// <summary>
        /// Takes four parameters that create the location and size of the box, but also gives a generic index.
        /// </summary>
        /// <param name="rect"></param>
        /// <returms></returms>
        public static DisplayArea CreateDisplay(Rectangle rect)
        {
            Point Location = new Point(rect.X, rect.Y);
            Size Size = new Size(rect.Width, rect.Height);
            DisplayArea displayArea = new DisplayArea(Location, Size);
            displayArea.Create();
            DisplayAreas.Add(displayArea);
            displayArea.SetCorners();
            return displayArea;
        }
        /// <summary>
        /// Displays all <see cref="DisplayArea"/> objects in their proper places.
        /// </summary>
        public static void ShowAreas()
        {
            foreach (var Area in DisplayAreas)
            {
                Area.Show();
            }
        }



        internal static char[] CheckCorners(DisplayArea displayArea)
        {
            CheckTime.Start();
            char[] returnChar = { '╔', '╗', '╚', '╝' };

            bool hasNorth = false, hasSouth = false, hasEast = false, hasWest = false;

            //Top Left, Top Right, Bottom Left, Bottom Right

            #region TopLeft

            foreach (var corner in DisplayAreas)
            {
                if (corner == displayArea)
                    continue;
                if (corner.bottomLeft == displayArea.topLeft) hasNorth = true;
                if (corner.bottomRight == displayArea.topLeft) { hasWest = true; hasNorth = true; }
                if (corner.topRight == displayArea.topLeft) hasWest = true;

            }

            if (hasWest) returnChar[0] = '╦';
            if (hasNorth) returnChar[0] = '╠';
            if (hasWest && hasNorth) returnChar[0] = '╬';

            hasNorth = false; hasSouth = false; hasEast = false; hasWest = false;
            #endregion TopLeft

            #region TopRight

            foreach (var corner in DisplayAreas)
            {
                if (corner == displayArea)
                    continue;
                if (corner.bottomLeft == displayArea.topRight) hasNorth = true;
                if (corner.bottomRight == displayArea.topRight) hasNorth = true;
                if (corner.topLeft == displayArea.topRight) hasEast = true;

            }

            if (hasNorth) returnChar[1] = '╣';
            if (hasEast) returnChar[1] = '╦';
            if (hasNorth && hasEast) returnChar[1] = '╬';

            hasNorth = false; hasSouth = false; hasEast = false; hasWest = false;
            #endregion TopRight



            #region BottomLeft

            foreach (var corner in DisplayAreas)
            {
                if (corner == displayArea)
                    continue;
                if (corner.topLeft == displayArea.bottomLeft) hasSouth = true;
                if (corner.topRight == displayArea.bottomLeft) hasSouth = true;
                if (corner.bottomRight == displayArea.bottomLeft) hasWest = true;

            }
            if (hasWest) returnChar[2] = '╩';
            if (hasSouth) returnChar[2] = '╠';
            if (hasWest && hasSouth) returnChar[2] = '╬';
            hasNorth = false; hasSouth = false; hasEast = false; hasWest = false;

            #endregion BottomLeft

            #region BottomRight

            foreach (var corner in DisplayAreas)
            {
                if (corner == displayArea)
                    continue;
                if (corner.topRight == displayArea.bottomRight) hasEast = true;
                if (corner.bottomRight == displayArea.bottomRight) hasEast = true;
                if (corner.topLeft == displayArea.bottomRight || corner.topRight == displayArea.bottomRight) { hasSouth = true;  }

            }
          
            
            if (hasSouth) returnChar[3] = '╣';
            if (hasEast) returnChar[3] = '╦';
            if (hasSouth && hasEast) returnChar[3] = '╬';
            hasNorth = false; hasSouth = false; hasEast = false; hasWest = false;

            #endregion BottomRight



            #region SideCheck

            #region LeftSide
   
            foreach(var display in DisplayAreas)
            {
                if (display == displayArea) continue;
                if (display.Location.X + display.Size.Width == displayArea.Location.X 
                    && display.Size.Height > displayArea.Size.Height 
                    && displayArea.Location.Y + displayArea.Size.Height > display.Location.Y)
                {
                    returnChar[2] = '╠';
                }

                if(display.Location.Y > displayArea.Location.Y 
                   && display.Location.X + display.Size.Width == displayArea.Location.X)
                {
                    displayArea.Box[0, display.Location.Y - displayArea.Location.Y] = '╣';
                }
            }

            #endregion LeftSide 

            #endregion SideCheck
            CheckTime.Stop();
            Console.WriteLine("{0} {1} to check all boxes", CheckTime.ElapsedMilliseconds > 0 ? CheckTime.ElapsedMilliseconds : CheckTime.ElapsedTicks, CheckTime.ElapsedMilliseconds > 0 ? "ms" : "ns");
            CheckTime.Reset();

            return returnChar;

        }





    }
}
