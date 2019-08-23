using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat_and_Mouse_game
{
    class Wall : StationaryObject
    {
        //##########################################################################################
        //Constructors.

        /// <summary>
        /// Initialises a new wall.
        /// </summary>
        /// <param name="x">The x position of the wall</param>
        /// <param name="y">The y position of the wall</param>
        /// <param name="width">The width of the wall</param>
        /// <param name="height">The height of the wall</param>
        public Wall(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
        }

        //##########################################################################################
        //Public Methods.

        /// <summary>
        /// Displays the wall.
        /// </summary>
        /// <param name="graphics">Where to display the wall</param>
        public override void Display(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(Color.Black), (int)X, (int)Y, Width, Height);
        }
    }
}
