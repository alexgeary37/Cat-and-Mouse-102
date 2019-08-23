using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Cat_and_Mouse_game
{
    /// <summary>
    /// Enum for the direction for sprites to travel in.
    /// </summary>
    public enum Direction { UP, DOWN, LEFT, RIGHT }

    public abstract class Sprite
    {
        //##########################################################################################
        //Private Instance Variables.

        /// <summary>
        /// The x and y positions of the sprite.
        /// </summary>
        private double x_;
        private double y_;
        /// <summary>
        /// The direction the sprite is facing.
        /// </summary>
        private Direction direction_;
        /// <summary>
        /// The speed the sprite travels at.
        /// </summary>
        private int speed_;
        /// <summary>
        /// The body width and height of the sprite.
        /// </summary>
        private int bodyWidth_;
        private int bodyHeight_;

        //##########################################################################################
        //Constructors.

        /// <summary>
        /// Initialises a new sprite object.
        /// </summary>
        /// <param name="x">The x position of the sprite</param>
        /// <param name="y">The y position of the sprite</param>
        /// <param name="speed">The speed the sprite travels at</param>
        /// <param name="bodyWidth">The body width of the sprite</param>
        /// <param name="bodyHeight">The body height of the sprite</param>
        public Sprite(double x, double y, int speed, int bodyWidth, int bodyHeight)
        {
            x_ = x;
            y_ = y;
            speed_ = speed;
            bodyWidth_ = bodyWidth;
            bodyHeight_ = bodyHeight;
        }

        //##########################################################################################
        //Public Properties.

        /// <summary>
        /// Gets and sets the x position of the sprite.
        /// </summary>
        public double X
        {
            get { return x_; }
            set { x_ = value; }
        }

        /// <summary>
        /// Gets and sets the y position of the sprite.
        /// </summary>
        public double Y
        {
            get { return y_; }
            set { y_ = value; }
        }

        /// <summary>
        /// Gets and sets the direction of the sprite.
        /// </summary>
        public Direction Direction
        {
            get { return direction_; }
            set { direction_ = value; }
        }

        /// <summary>
        /// Gets and sets the speed the sprite travels at.
        /// </summary>
        public int Speed
        {
            get { return speed_; }
            set { speed_ = value; }
        }
        
        /// <summary>
        /// Gets the body width of the sprite.
        /// </summary>
        public int BodyWidth
        {
            get { return bodyWidth_; }
        }

        /// <summary>
        /// Gets the body height of the sprite.
        /// </summary>
        public int BodyHeight
        {
            get { return bodyHeight_; }
        }

        /// <summary>
        /// Gets the location of the sprite.
        /// </summary>
        public Rectangle SpriteLocation
        {
            get { return new Rectangle((int)x_, (int)y_, bodyWidth_, bodyHeight_); }
        }
        
        //##########################################################################################
        //Public Methods.

        /// <summary>
        /// Moves the sprite in the correct direction and within the screen parameters.
        /// </summary>
        /// <param name="screenWidth">The width of the screen</param>
        /// <param name="screenHeight">The height of the screen</param>
        public virtual void Move(int screenWidth, int screenHeight) {
            if (this is Cat) {
                if (Direction == Direction.UP && Y > 50)
                    Y -= Speed;
                else if (Direction == Direction.DOWN && (Y + BodyHeight) < screenHeight - 50)
                    Y += Speed;
                else if (Direction == Direction.LEFT && X > 50)
                    X -= Speed;
                else if (Direction == Direction.RIGHT && (X + BodyWidth) < screenWidth - 50)
                    X += Speed;
            }
        }

        /// <summary>
        /// Checks whether there has been a collision between this and another sprite.
        /// </summary>
        /// <param name="otherSprite">The other sprite which is being checked for a collision</param>
        /// <returns>Whether there has been a collision or not</returns>
        public bool HasCollided(Sprite otherSprite)
        {
            Rectangle myLocation = SpriteLocation;
            Rectangle otherLocation = otherSprite.SpriteLocation;
            if (myLocation.IntersectsWith(otherLocation))
                return true;
            else
                return false;
        }
    }
}
