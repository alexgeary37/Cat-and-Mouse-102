using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Cat_and_Mouse_game
{
    class HidingPlace : StationaryObject
    {
        //##########################################################################################
        //Private Instance Variables.

        /// <summary>
        /// The width and height of each hiding place.
        /// </summary>
        private const int SIZE = 40;

        //##########################################################################################
        //Constructors.

        /// <summary>
        /// Initialises a new hiding place.
        /// </summary>
        /// <param name="x">The x position of the hiding place</param>
        /// <param name="y">The y position of the hiding place</param>
        public HidingPlace(int x, int y)
            : base(x, y, SIZE, SIZE)
        {
        }

        //##########################################################################################
        //Public Methods.

        /// <summary>
        /// Displays the hiding place.
        /// </summary>
        /// <param name="graphics">Where to display the hiding place</param>
        public override void Display(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(Color.SaddleBrown), (int)X, (int)Y, Width, Height);
            graphics.DrawRectangle(new Pen(Color.Black, 2), (int)X, (int)Y, Width, Height);
        }
    }
}
