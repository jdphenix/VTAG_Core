using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.ExceptionServices;

namespace VTAG_Attempt_2
{
    /// <summary>
    /// A area on the console which holds a given size. Text and labels can be printed to thse areas to keep aspects portioned off and organized.
    /// </summary>
    public class DisplayArea
    {
        public Point    Location    { get; private set; }
        public Size     Size        { get; private set; }

        private int ulIndex, urIndex, llIndex, lrIndex;

        private string box;
        private string 
         ulCorner = "╔",
         llCorner = "╚",
         urCorner = "╗",
         lrCorner = "╝",
         vertical = "║",
         horizontal = "═";

        

        internal DisplayArea(Point Location, Size Size)
        {
            this.Location = Location;
            this.Size = Size;
            ulIndex = 0;
            urIndex = Size.Width;
            
        }

        
        internal void Build()
        {
            
            if (Size.Width is 0) { throw new NullReferenceException("Size was uninitialized during method call of Build()"); }

            box += ulCorner;

            for (int i = 0; i < Size.Width - 2; i++)
                box += horizontal;

            box += urCorner;
            

            for (int i = 0; i < Size.Height; i++)
            {
                box += vertical;
                for (int j = 0; j < Size.Width - 2; j++)
                    box += " ";
                box += vertical;
                
            }
            box += llCorner;
            for (int i = 0; i < Size.Width - 2; i++)
                box += horizontal;
            box += lrCorner;

            llIndex = box.Length - Size.Width;
            lrIndex = box.Length - 1;
                
            

            
        }


        /// <summary>
        /// Displays the <see cref="DisplayArea"/> in the appropriate position.
        /// </summary>
        public void Show()
        {
            Console.SetCursorPosition(Location.X, Location.Y);
            Console.Write(box.Substring(0, Size.Width));
            for (int i = 0; i < Size.Height + 2; i++)
            {
                Console.SetCursorPosition(Location.X, Location.Y + i);
                Console.Write(box.Substring(i * Size.Width, Size.Width));
            }
        }

    }
}
