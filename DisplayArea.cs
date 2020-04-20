using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.ExceptionServices;

namespace VTAG_Attempt_2
{
    /// <summary>
    /// A box with a position, and size, held in a list by the Display Area Manager class.
    /// </summary>
    public class DisplayArea
    {
        public Point    Location    { get; private set; }
        public Size     Size        { get; private set; }

        private string box;
        private string 
         ulCorner = "╔",
         llCorner = "╚",
         urCorner = "╗",
         lrCorner = "╝",
         vertical = "║",
         horizontal = "═";

         
        internal void Build()
        {
            if (Size.Width is 0) { throw new NullReferenceException("Size was uninitialized during method call of Build()"); }

            box += ulCorner;

            for (int i = 0; i < Size.Width; i++)
                box += horizontal;

            box += urCorner;
            box += "\n";

            for (int i = 0; i < Size.Height; i++)
            {
                box += vertical;
                for (int j = 0; j < Size.Width; j++)
                    box += " ";
                box += vertical;
                box += "\n";
            }

                //for (int i = 0; i < Size.Height; i++)



                Console.WriteLine(box);
            

            
        }
    }
}
