using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Cat_and_Mouse_game
{
    abstract class StationaryObject
    {
        //##########################################################################################
        //Private Instance Variables.
        
        /// <summary>
        /// The x and y positions of the stationary object.
        /// </summary>
        private double x_;
        private double y_;
        /// <summary>
        /// The width and height of the stationary object.
        /// </summary>
        private int width_;
        private int height_;

        //##########################################################################################
        //Constructors.

        /// <summary>
        /// Initialises a new stationary object.
        /// </summary>
        /// <param name="x">The x position of the stationary object</param>
        /// <param name="y">The y position of the stationary object</param>
        /// <param name="width">The width of the stationary object</param>
        /// <param name="height">The height of the stationary object</param>
        public StationaryObject(double x, double y, int width, int height)
        {
            x_ = x;
            y_ = y;
            width_ = width;
            height_ = height;
        }

        //##########################################################################################
        //Public Properties.

        /// <summary>
        /// Gets and sets the x position of the stationary object.
        /// </summary>
        public double X
        {
            get { return x_; }
            set { x_ = value; }
        }

        /// <summary>
        /// Gets and sets the y position of the stationary object.
        /// </summary>
        public double Y
        {
            get { return y_; }
            set { y_ = value; }
        }

        /// <summary>
        /// Gets and sets the width of the stationary object.
        /// </summary>
        public int Width
        {
            get { return width_; }
            set { width_ = value; }
        }

        /// <summary>
        /// Gets and sets the height of the stationary object.
        /// </summary>
        public int Height
        {
            get { return height_; }
            set { height_ = value; }
        }

        /// <summary>
        /// Gets the general location of the stationary object.
        /// </summary>
        /// <returns>The location of the object</returns>
        public Rectangle GeneralLocation
        {
            get { return new Rectangle((int)x_, (int)y_, width_, height_); }
        }

        /// <summary>
        /// Gets an adjusted location for all objects displayed on the sides of the screen.
        /// </summary>
        /// <returns>The location of the object</returns>
        public Rectangle XLocation
        {
            get { return new Rectangle((int)X - 8, (int)Y + Height / 2 - 4, Width + 16, 8); }
        }

        /// <summary>
        /// Gets an adjusted location for all objects lined up on the top or bottom of the screen.
        /// </summary>
        /// <returns>The location of the object</returns>
        public Rectangle YLocation
        {
            get { return new Rectangle((int)X + Width / 2 - 2, (int)Y - 8, 4, Height + 16); }
        }


        //##########################################################################################
        //Public Methods.

        /// <summary>
        /// Displays the stationary object.
        /// </summary>
        /// <param name="graphics">Where to display the stationary object</param>
        public abstract void Display(Graphics graphics);
    }
}
