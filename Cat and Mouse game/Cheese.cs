using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Cat_and_Mouse_game
{
    class Cheese : StationaryObject
    {
        //##########################################################################################
        //Private Instance Variables.

        /// <summary>
        /// Constants for the width and height of the cheese.
        /// </summary>
        private const int WIDTH = 30;
        private const int HEIGHT = 25;
        /// <summary>
        /// The colour of the cheese.
        /// </summary>
        private Color cheeseColour_ = Color.Gold;

        //##########################################################################################
        //Constructors.

        /// <summary>
        /// Initialises a new piece of cheese.
        /// </summary>
        /// <param name="x">The x position of the cheese</param>
        /// <param name="y">The y position of the cheese</param>
        public Cheese(int x, int y)
            : base(x, y, WIDTH, HEIGHT)
        {
        }

        //##########################################################################################
        //Public Methods.

        /// <summary>
        /// Displays the piece of cheese.
        /// </summary>
        /// <param name="graphics">Where to display the piece of cheese</param>
        public override void Display(Graphics graphics)
        {
            SolidBrush br = new SolidBrush(cheeseColour_);
            Pen pen = new Pen(Color.Black);
            Point p1 = new Point((int)X, (int)Y);
            Point p2 = new Point((int)X + Width / 2, (int)Y + Height);
            Point p3 = new Point((int)X + Width, (int)Y + Height - 10);
            PointF[] p = { p1, p2, p3 };
            graphics.DrawPolygon(pen, p);
            graphics.FillPolygon(br, p);
        }
    }
}
