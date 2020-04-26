using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace VTAG_Attempt_2
{
    /// <summary>
    /// A area on the console which holds a given size. Text and labels can be printed to thse areas to keep aspects portioned off and organized.
    /// </summary>
    public class DisplayArea
    {

        internal Size Size;
        internal Point Location;
        internal Point topLeft, topRight, bottomLeft, bottomRight;
        private char
         ulCorner = '╔',
         llCorner = '╚',
         urCorner = '╗',
         lrCorner = '╝',
         vertical = '║',
         horizontal = '═';

        internal char[,] Box;


        public DisplayArea(Point Location, Size Size)
        {
            this.Location = Location;
            this.Size = Size;

            topLeft = new Point(Location.X, Location.Y);
            topRight = new Point(Location.X + Size.Width, Location.Y);
            bottomLeft = new Point(Location.X, Location.Y + Size.Height);
            bottomRight = new Point(Location.X + Size.Width, Location.Y + Size.Height);

            Box = new char[Size.Width + 1, Size.Height + 1];



        }
        internal void Create() 
        {
            for(int h = 0; h <= Size.Height; h++)
            {
                for(int w = 0; w <= Size.Width; w++)
                {
                    if(w == 0 && h == 0)
                        continue;
                    if (w == Size.Width && h == 0)
                        continue;
                    if (w == 0 && h == Size.Height)
                        continue;
                    if (w == Size.Width && h == Size.Height)
                        continue;
                    if (h == 0 || h == Size.Height)
                    {
                        Box[w, h] = horizontal;
                        continue;
                    }
                    if (w == 0 || w == Size.Width)
                    {
                        Box[w, h] = vertical;
                        continue;
                    }
                    else { Box[w, h] = ' '; }

                }
            }
        }


        internal void SetCorners()
        {
            char[] corners = new char[4];
            corners = DisplayAreaManager.CheckCorners(this);
            Box[0, 0] = corners[0];
            Box[Size.Width, 0] = corners[1];
            Box[0, Size.Height] = corners[2];
            Box[Size.Width, Size.Height] = corners[3];
        }


        internal void Show()
        {
            StringBuilder sb = new StringBuilder(Size.Width + Size.Height);
            for (int h = 0; h <= Size.Height; h++)
            {
                for (int w = 0; w <= Size.Width; w++)
                {
                    sb.Append(Box[w, h]);
                }


                Console.SetCursorPosition(Location.X, Location.Y + h);
                Console.WriteLine(sb);
                sb.Clear();
            }
        }

    }
}
