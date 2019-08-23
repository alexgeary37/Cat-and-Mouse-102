using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Cat_and_Mouse_game
{
    class MouseDen : StationaryObject
    {
        //##########################################################################################
        //Private Instance Variables.

        /// <summary>
        /// The amount of cheese in the mouse den.
        /// </summary>
        private int amountOfCheese_;
                
        /// <summary>
        /// Constants for the width and height of the mouse den.
        /// </summary>
        private const int WIDTH = 40;
        private const int HEIGHT = 60;

        //##########################################################################################
        //Constructors.

        /// <summary>
        /// Initialises the mouse den.
        /// </summary>
        /// <param name="x">The x position of the mouse den</param>
        /// <param name="y">The y position of the mouse den</param>
        public MouseDen(int x, int y)
            : base(x, y, WIDTH, HEIGHT)
        {
        }

        //##########################################################################################
        //Public Properties.

        /// <summary>
        /// Gets and sets the amount of cheese in the mouse den.
        /// </summary>
        public int AmountOfCheese
        {
            get { return amountOfCheese_; }
            set { amountOfCheese_ = value; }
        }

        //##########################################################################################
        //Public Methods.

        /// <summary>
        /// Displays the mouse den.
        /// </summary>
        /// <param name="graphics">Where to display the mouse den</param>
        public override void Display(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(Color.SandyBrown), (int)X, (int)Y, Width, Height);
            graphics.DrawRectangle(new Pen(Color.Black), (int)X, (int)Y, Width, Height);
        }
    }
}
