using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Cat_and_Mouse_game
{
    class Mouse : Sprite {
        //##########################################################################################
        //Private Instance Variables.

        
        /// <summary>
        /// Whether the mouse is safe (in its den/a hiding place) or not.
        /// </summary>
        private bool isSafe_;
        /// <summary>
        /// Whether the mouse has cheese in its mouth or not.
        /// </summary>
        private bool hasCheese_;
        
        /// <summary>
        /// The speed of the mouse.
        /// </summary>
        private const int SPEED = 10;
        /// <summary>
        /// The width and height of the body of the mouse.
        /// </summary>
        private const int BODY_WIDTH = 28;
        private const int BODY_HEIGHT = 36;
        /// <summary>
        /// The colour of the mouse.
        /// </summary>
        private Color mouseColour_ = Color.DarkGray;

        /// <summary>
        /// The width and height of the cheese piece.
        /// </summary>
        private const int CHEESE_WIDTH = 30;
        private const int CHEESE_HEIGHT = 25;

        /// <summary>
        /// List of all mouse safety zones.
        /// </summary>
        private List<StationaryObject> safetyZoneList_ = new List<StationaryObject>();

        //##########################################################################################
        //Constructors.

        /// <summary>
        /// Initialises the mouse object.
        /// </summary>
        /// <param name="screenWidth">The width of the screen</param>
        /// <param name="screenHeight">The height of the screen</param>
        public Mouse(int screenWidth, int screenHeight)
            : base(screenWidth, screenHeight, SPEED, BODY_WIDTH, BODY_HEIGHT) {
            X = screenWidth - 45;
            Y = screenHeight - 150;
            isSafe_ = true;
        }

        //##########################################################################################
        //Public Properties.

        /// <summary>
        /// Gets whether the mouse is safe or not.
        /// </summary>
        public bool IsSafe {
            get { return isSafe_; }
        }

        /// <summary>
        /// Gets and sets whether the mouse has cheese in its mouth or not.
        /// </summary>
        public bool HasCheese {
            get { return hasCheese_; }
            set { hasCheese_ = value; }
        }

        //##########################################################################################
        //Public Methods.

        /// <summary>
        /// Displays the mouse.
        /// </summary>
        /// <param name="graphics">Where to display the mouse</param>
        public void Display(Graphics graphics) {
            SolidBrush mouseBrush = new SolidBrush(mouseColour_);
            SolidBrush cheeseBrush = new SolidBrush(Color.Gold);
            Pen pen = new Pen(Color.Black);

            //IF the direction the mouse is travelling is UP THEN
            if (Direction == Direction.UP) {
                if (HasCheese) {
                    //Draw cheese
                    Point p1 = new Point((int)X, (int)Y - BodyHeight / 2);
                    Point p2 = new Point((int)X + CHEESE_WIDTH / 2, (int)Y - BodyHeight / 2 + CHEESE_HEIGHT);
                    Point p3 = new Point((int)X + CHEESE_WIDTH, (int)Y - 7);
                    PointF[] p = { p1, p2, p3 };
                    graphics.DrawPolygon(pen, p);
                    graphics.FillPolygon(cheeseBrush, p);
                }
                //Draw mouse ears
                graphics.FillEllipse(mouseBrush, (int)X - 5, (int)Y - 7, BodyWidth / 2, BodyHeight / 2);
                graphics.FillEllipse(mouseBrush, (int)X + BodyWidth - 9, (int)Y - 7,
                    BodyWidth / 2, BodyHeight / 2);
                graphics.DrawEllipse(pen, (int)X - 5, (int)Y - 7, BodyWidth / 2, BodyHeight / 2);
                graphics.DrawEllipse(pen, (int)X + BodyWidth - 9, (int)Y - 7,
                    BodyWidth / 2, BodyHeight / 2);
                //Draw mouse body
                graphics.FillEllipse(mouseBrush, (int)X, (int)Y, BodyWidth, BodyHeight);
                graphics.DrawEllipse(pen, (int)X, (int)Y, BodyWidth, BodyHeight);
                //Draw mouse tail
                graphics.DrawLine(pen, (int)X + (BodyWidth / 2), (int)Y + BodyHeight,
                    (int)X + (BodyWidth / 2), (int)Y + BodyHeight + (BodyHeight / 4));
                graphics.DrawArc(pen, (int)X + (BodyWidth / 2), (int)Y + BodyHeight,
                    BodyWidth / 2, BodyHeight / 2, 0.0F, 180.0F);

                //IF the direction the mouse is travelling is DOWN THEN
            } else if (Direction == Direction.DOWN) {
                if (HasCheese) {
                    //Draw cheese
                    Point p1 = new Point((int)X + BodyWidth, (int)Y + BodyHeight + BodyHeight / 2);
                    Point p2 = new Point((int)X + BodyWidth - CHEESE_WIDTH / 2, (int)Y - BodyHeight / 2 + CHEESE_HEIGHT);
                    Point p3 = new Point((int)X + BodyWidth - CHEESE_WIDTH, (int)Y + BodyHeight + 7);
                    PointF[] p = { p1, p2, p3 };
                    graphics.DrawPolygon(pen, p);
                    graphics.FillPolygon(cheeseBrush, p);
                }
                //Draw mouse ears
                graphics.FillEllipse(mouseBrush, (int)X - 5, (int)Y + (BodyHeight - 15),
                BodyWidth / 2, BodyHeight / 2);
                graphics.FillEllipse(mouseBrush, (int)X + BodyWidth - 9, (int)Y + (BodyHeight - 15),
                    BodyWidth / 2, BodyHeight / 2);
                graphics.DrawEllipse(pen, (int)X - 5, (int)Y + (BodyHeight - 15),
                    BodyWidth / 2, BodyHeight / 2);
                graphics.DrawEllipse(pen, (int)(X + BodyWidth) - 9, (int)Y + (BodyHeight - 15),
                    BodyWidth / 2, BodyHeight / 2);
                //Draw mouse body
                graphics.FillEllipse(mouseBrush, (int)X, (int)Y, BodyWidth, BodyHeight);
                graphics.DrawEllipse(pen, (int)X, (int)Y, BodyWidth, BodyHeight);
                //Draw mouse tail
                graphics.DrawLine(pen, (int)X + (BodyWidth / 2), (int)Y - (BodyHeight / 4),
                    (int)X + (BodyWidth / 2), (int)Y);
                graphics.DrawArc(pen, (int)X, (int)Y - (BodyHeight / 2),
                    BodyWidth / 2, BodyHeight / 2, 0.0F, -180.0F);

                //IF the direction the mouse is travelling is LEFT THEN
            } else if (Direction == Direction.LEFT) {
                if (HasCheese) {
                    //Draw cheese
                    Point p1 = new Point((int)X - BodyHeight + BodyWidth / 2, (int)Y + BodyWidth);
                    Point p2 = new Point((int)X + CHEESE_WIDTH / 2, (int)Y + BodyWidth - CHEESE_WIDTH / 2);
                    Point p3 = new Point((int)X - BodyHeight / 2 + BodyWidth / 2 - 7, (int)Y + BodyWidth - CHEESE_WIDTH);
                    PointF[] p = { p1, p2, p3 };
                    graphics.DrawPolygon(pen, p);
                    graphics.FillPolygon(cheeseBrush, p);
                }
                //Draw mouse ears
                graphics.FillEllipse(mouseBrush, (int)X - (BodyHeight / 2) + (BodyWidth / 2) - 7,
                    (int)Y + (BodyHeight / 2) - (BodyWidth / 2) - 6, BodyHeight / 2, BodyWidth / 2);
                graphics.FillEllipse(mouseBrush, (int)X - (BodyHeight / 2) + (BodyWidth / 2) - 7,
                    (int)Y + (BodyHeight / 2) + (BodyWidth / 2) - 9, BodyHeight / 2, BodyWidth / 2);
                graphics.DrawEllipse(pen, (int)X - (BodyHeight / 2) + (BodyWidth / 2) - 7,
                    (int)Y + (BodyHeight / 2) - (BodyWidth / 2) - 6, BodyHeight / 2, BodyWidth / 2);
                graphics.DrawEllipse(pen, (int)X - (BodyHeight / 2) + (BodyWidth / 2) - 7,
                    (int)Y + (BodyHeight / 2) + (BodyWidth / 2) - 9, BodyHeight / 2, BodyWidth / 2);
                //Draw mouse body
                graphics.FillEllipse(mouseBrush, (int)X - (BodyHeight / 2) + (BodyWidth / 2),
                    (int)Y + (BodyHeight / 2) - (BodyWidth / 2), BodyHeight, BodyWidth);
                graphics.DrawEllipse(pen, (int)X - (BodyHeight / 2) + (BodyWidth / 2),
                   (int)Y + (BodyHeight / 2) - (BodyWidth / 2), BodyHeight, BodyWidth);
                //Draw mouse tail
                graphics.DrawLine(pen, (int)X + (BodyHeight / 2) + (BodyWidth / 2), (int)Y + (BodyHeight / 2),
                    (int)X + BodyHeight + (BodyWidth / 2) - (BodyHeight / 4), (int)Y + (BodyHeight / 2));
                graphics.DrawArc(pen, (int)X + (BodyHeight / 2) + (BodyWidth / 2),
                    (int)Y + (BodyHeight / 2) - (BodyWidth / 2), BodyHeight / 2, BodyWidth / 2, 270.0F, 180.0F);

                //IF the direction the mouse is travelling is RIGHT THEN
            } else {
                if (HasCheese) {
                    //Draw cheese
                    Point p1 = new Point((int)X + BodyWidth / 2 + BodyHeight, (int)Y);
                    Point p2 = new Point((int)X + CHEESE_WIDTH / 2, (int)Y + CHEESE_WIDTH / 2);
                    Point p3 = new Point((int)X + BodyHeight + 7, (int)Y + CHEESE_WIDTH);
                    PointF[] p = { p1, p2, p3 };
                    graphics.DrawPolygon(pen, p);
                    graphics.FillPolygon(cheeseBrush, p);
                }
                //Draw mouse ears
                graphics.FillEllipse(mouseBrush, (int)X + BodyHeight - 15,
                    (int)Y + (BodyHeight / 2) - (BodyWidth / 2) - 6, BodyHeight / 2, BodyWidth / 2);
                graphics.FillEllipse(mouseBrush, (int)X + BodyHeight - 15,
                    (int)Y + (BodyHeight / 2) + (BodyWidth / 2) - 9, BodyHeight / 2, BodyWidth / 2);
                graphics.DrawEllipse(pen, (int)X + BodyHeight - 15,
                    (int)Y + (BodyHeight / 2) - (BodyWidth / 2) - 6, BodyHeight / 2, BodyWidth / 2);
                graphics.DrawEllipse(pen, (int)X + BodyHeight - 15,
                    (int)Y + (BodyHeight / 2) + (BodyWidth / 2) - 9, BodyHeight / 2, BodyWidth / 2);
                //Draw mouse body
                graphics.FillEllipse(mouseBrush, (int)X - BodyHeight / 2 + BodyWidth / 2,
                    (int)Y + (BodyHeight / 2) - (BodyWidth / 2), BodyHeight, BodyWidth);
                graphics.DrawEllipse(pen, (int)X - (BodyHeight / 2) + (BodyWidth / 2),
                    (int)Y + (BodyHeight / 2) - (BodyWidth / 2), BodyHeight, BodyWidth);
                //Draw mouse tail
                graphics.DrawLine(pen, (int)X - (BodyHeight / 2) + (BodyWidth / 2) - (BodyHeight / 4),
                    (int)Y + (BodyHeight / 2), (int)X - (BodyHeight / 2) + (BodyWidth / 2), (int)Y + (BodyHeight / 2));
                graphics.DrawArc(pen, (int)X - BodyHeight + (BodyWidth / 2),
                    (int)Y + (BodyHeight / 2), BodyHeight / 2, BodyWidth / 2, -270.0F, 180.0F);
            }
        }

        /// <summary>
        /// Moves the mouse in the correct direction and within the correct boundaries.
        /// </summary>
        /// <param name="screenWidth">The width of the screen</param>
        /// <param name="screenHeight">The height of the screen</param>
        public override void Move(int screenWidth, int screenHeight) {
            //The limits for each direction the mouse can move in
            int upperLimit = 40;
            int lowerLimit = screenHeight - 40;
            int leftLimit = 40;
            int rightLimit = screenWidth - 40;

            /*FOREACH stationary object, if the mouse intersects with it THEN
            the movement of the mouse is limited based on whether the stationary
            object is located*/
            foreach (StationaryObject s in safetyZoneList_) {
                if (SpriteLocation.IntersectsWith(s.XLocation) || 
                    SpriteLocation.IntersectsWith(s.YLocation)) {
                    if (s.Y == 0 || s.Y == screenHeight - 40) {
                        upperLimit = 0;
                        lowerLimit = screenHeight;
                        leftLimit = (int)s.X;
                        rightLimit = (int)s.X + BodyHeight + 8;
                        if (Y < 2 || Y > (screenHeight-BodyHeight)-2)
                            isSafe_ = true;
                        break;
                    } else {
                        upperLimit = (int)s.Y - 5;
                        if (s is MouseDen) {
                            lowerLimit = (int)s.Y + BodyHeight + 22;
                        } else {
                            lowerLimit = (int)s.Y + BodyHeight + 8;
                        }
                        leftLimit = 0;
                        rightLimit = screenWidth;
                        if (X < 2 || X > (screenWidth-BodyHeight)-2) {
                            isSafe_ = true;
                        }
                        break;
                    }
                } else {
                    isSafe_ = false;
                }
            }
            if (Direction == Direction.UP && Y > upperLimit) {
                Y -= Speed;
            } else if (Direction == Direction.DOWN && Y + BodyHeight < lowerLimit) {
                Y += Speed;
            } else if (Direction == Direction.LEFT && X > leftLimit) {
                X -= Speed;
            } else if (Direction == Direction.RIGHT && X + BodyHeight < rightLimit) {
                X += Speed;
            }
        }

        //##########################################################################################
        //Public Methods.

        /// <summary>
        /// Gets the list of stationary objects from the form code which influence
        /// the boundary limits for the mouse and adds each object to the mouses list
        /// of safety zones.
        /// </summary>
        /// <param name="list">The list of stationary objects passed in from the form code</param>
        public void GetList(List<StationaryObject> list) {
            foreach (StationaryObject s in list) safetyZoneList_.Add(s);
        }

        /// <summary>
        /// Resets the state of the mouse for the next level.
        /// </summary>
        /// <param name="screenWidth">The width of the screen</param>
        /// <param name="screenHeight">The height of the screen</param>
        public void ResetMouse(int screenWidth, int screenHeight) {
            X = screenWidth - 45;
            Y = screenHeight - 150;
            isSafe_ = true;
            hasCheese_ = false;
        }
    }
}
