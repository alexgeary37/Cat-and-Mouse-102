using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Cat_and_Mouse_game
{
    class Cat : Sprite
    {
        //##########################################################################################
        //Private Instance Variables.

        /// <summary>
        /// Whether the cat is moving or not.
        /// </summary>
        private bool isMoving_;
        /// <summary>
        /// Whether the left legs of the cat are stretched out or not.
        /// </summary>
        private bool isLeftStretched_;

        /// <summary>
        /// Constants for the size of the head, body and tail of the cat.
        /// </summary>
        private const int HEAD_WIDTH = 36;
        private const int HEAD_HEIGHT = 40;
        private const int BODY_WIDTH = 40;
        private const int BODY_HEIGHT = 88;
        private const int TAIL_WIDTH = 8;
        private const int TAIL_HEIGHT = BODY_HEIGHT / 2;
        /// <summary>
        /// The colour of the cat.
        /// </summary>
        private Color catColour_ = Color.Black;
        /// <summary>
        /// The initial running speed of the cat.
        /// </summary>
        private const int INITIAL_SPEED = 5;
        /// <summary>
        /// The walking speed of the cat.
        /// </summary>
        private const int WALKING_SPEED = 3;


        //##########################################################################################
        //Constructors.

        /// <summary>
        /// Initialises the cat object.
        /// </summary>
        /// <param name="screenWidth">The width of the screen</param>
        /// <param name="screenHeight">The height of the screen</param>
        /// <param name="runningSpeed">The running speed of the cat</param>
        public Cat(int screenWidth, int screenHeight)
            : base(screenWidth, screenHeight, INITIAL_SPEED, BODY_WIDTH, BODY_HEIGHT) {
            X = 0.2 * screenWidth;
            Y = 0.2 * screenHeight;
            isMoving_ = false;
        }

        //##########################################################################################
        //Public Properties.

        /// <summary>
        /// Gets and sets whether the cat is moving or not.
        /// </summary>
        public bool IsMoving {
            get { return isMoving_; }
            set { isMoving_ = value; }
        }

        /// <summary>
        /// Gets and sets whether the left legs of the cat are stretched out or not.
        /// </summary>
        public bool IsLeftStretched {
            get { return isLeftStretched_; }
            set { isLeftStretched_ = value; }
        }

        //##########################################################################################
        //Public Methods.

        /// <summary>
        /// Displays the cat.
        /// </summary>
        /// <param name="graphics">Where to display the cat</param>
        public void Display(Graphics graphics) {
            SolidBrush br = new SolidBrush(catColour_);
            Pen pen = new Pen(catColour_, TAIL_WIDTH);

            //IF the cat is moving THEN
            if (isMoving_) {
                //IF the direction of travel for the cat is UP THEN
                if (Direction == Direction.UP) {
                    //Draw cat legs
                    if (isLeftStretched_) {
                        graphics.DrawEllipse(pen, (int)X, (int)Y, TAIL_WIDTH, TAIL_WIDTH);
                        graphics.DrawEllipse(pen, (int)X, (int)Y + BodyHeight - 10, TAIL_WIDTH, TAIL_WIDTH);
                        graphics.DrawEllipse(pen, (int)X + BodyWidth - TAIL_WIDTH,
                            (int)Y + BodyHeight / 2 - TAIL_WIDTH, TAIL_WIDTH, TAIL_WIDTH);
                        graphics.DrawEllipse(pen, (int)X + BodyWidth - TAIL_WIDTH,
                            (int)Y + BodyHeight / 2, TAIL_WIDTH, TAIL_WIDTH);
                    } else {
                        graphics.DrawEllipse(pen, (int)X, (int)Y + BodyHeight / 2 - TAIL_WIDTH, TAIL_WIDTH, TAIL_WIDTH);
                        graphics.DrawEllipse(pen, (int)X, (int)Y + BodyHeight / 2, TAIL_WIDTH, TAIL_WIDTH);
                        graphics.DrawEllipse(pen, (int)X + BodyWidth - TAIL_WIDTH, (int)Y, TAIL_WIDTH, TAIL_WIDTH);
                        graphics.DrawEllipse(pen, (int)X + BodyWidth - TAIL_WIDTH,
                            (int)Y + BodyHeight - 10, TAIL_WIDTH, TAIL_WIDTH);
                    }
                    //Draw cat head
                    graphics.FillEllipse(br, (int)X + (BodyWidth / 2) - (HEAD_WIDTH / 2),
                        (int)Y - 10, HEAD_WIDTH, HEAD_HEIGHT);
                    //Draw cat ears
                    graphics.FillEllipse(br, (int)X - 1, (int)Y - 15, HEAD_WIDTH / 3, HEAD_HEIGHT / 2);
                    graphics.FillEllipse(br, (int)X + BodyWidth - 10, (int)Y - 15, HEAD_WIDTH / 3, HEAD_HEIGHT / 2);
                    // Draw cat body
                    graphics.FillEllipse(br, (int)X, (int)Y, BodyWidth, BodyHeight);
                    // Draw cat tail
                    graphics.FillRectangle(br, (int)X + (BodyWidth / 2) - (TAIL_WIDTH / 2),
                        (int)Y + BodyHeight, TAIL_WIDTH, TAIL_HEIGHT);
                    graphics.DrawArc(pen, (int)X + (BodyWidth / 2), (int)Y + (BodyHeight + TAIL_HEIGHT) - 12,
                        BodyWidth / 2, BodyWidth / 2, 0.0F, 180.0F);

                    //IF the direction of travel for the cat is DOWN THEN
                } else if (Direction == Direction.DOWN) {
                    //Draw cat legs
                    if (isLeftStretched_) {
                        graphics.DrawEllipse(pen, (int)X, (int)Y, TAIL_WIDTH, TAIL_WIDTH);
                        graphics.DrawEllipse(pen, (int)X, (int)Y + BodyHeight - 10, TAIL_WIDTH, TAIL_WIDTH);
                        graphics.DrawEllipse(pen, (int)X + BodyWidth - TAIL_WIDTH,
                            (int)Y + BodyHeight / 2 - TAIL_WIDTH, TAIL_WIDTH, TAIL_WIDTH);
                        graphics.DrawEllipse(pen, (int)X + BodyWidth - TAIL_WIDTH,
                            (int)Y + BodyHeight / 2, TAIL_WIDTH, TAIL_WIDTH);
                    } else {
                        graphics.DrawEllipse(pen, (int)X, (int)Y + BodyHeight / 2 - TAIL_WIDTH, TAIL_WIDTH, TAIL_WIDTH);
                        graphics.DrawEllipse(pen, (int)X, (int)Y + BodyHeight / 2, TAIL_WIDTH, TAIL_WIDTH);
                        graphics.DrawEllipse(pen, (int)X + BodyWidth - TAIL_WIDTH, (int)Y, TAIL_WIDTH, TAIL_WIDTH);
                        graphics.DrawEllipse(pen, (int)X + BodyWidth - TAIL_WIDTH,
                            (int)Y + BodyHeight - 10, TAIL_WIDTH, TAIL_WIDTH);
                    }
                    //Draw cat head
                    graphics.FillEllipse(br, (int)X + (BodyWidth / 2) - (HEAD_WIDTH / 2),
                        (int)Y + (BodyHeight - HEAD_HEIGHT) + 10, HEAD_WIDTH, HEAD_HEIGHT);
                    //Draw cat ears
                    graphics.FillEllipse(br, (int)X - 1,
                        (int)Y + (BodyHeight - HEAD_HEIGHT / 2) + 15, HEAD_WIDTH / 3, HEAD_HEIGHT / 2);
                    graphics.FillEllipse(br, (int)X + BodyWidth - 10,
                        (int)Y + (BodyHeight - HEAD_HEIGHT / 2) + 15, HEAD_WIDTH / 3, HEAD_HEIGHT / 2);
                    // Draw cat body
                    graphics.FillEllipse(br, (int)X, (int)Y, BodyWidth, BodyHeight);
                    // Draw cat tail
                    graphics.FillRectangle(br, (int)X + (BodyWidth / 2) - (TAIL_WIDTH / 2),
                        (int)Y - (TAIL_HEIGHT - 1), TAIL_WIDTH, TAIL_HEIGHT);
                    graphics.DrawArc(pen, (int)X, (int)(Y - TAIL_HEIGHT) - 9, BodyWidth / 2, BodyWidth / 2, 0.0F, -180.0F);

                    //IF the direction of travel for the cat is LEFT THEN
                } else if (Direction == Direction.LEFT) {
                    //Draw cat legs
                    if (isLeftStretched_) {
                        graphics.DrawEllipse(pen, (int)X - BodyHeight / 2 + BodyWidth / 2,
                            (int)Y + BodyHeight / 2 + BodyWidth / 2 - TAIL_WIDTH, TAIL_WIDTH, TAIL_WIDTH);
                        graphics.DrawEllipse(pen, (int)X + BodyWidth + BodyHeight / 2 - BodyWidth / 2 - 10,
                            (int)Y + BodyHeight / 2 + BodyWidth / 2 - TAIL_WIDTH, TAIL_WIDTH, TAIL_WIDTH);
                        graphics.DrawEllipse(pen, (int)X + BodyWidth / 2 - TAIL_WIDTH,
                            (int)Y + BodyHeight / 2 - BodyWidth / 2, TAIL_WIDTH, TAIL_WIDTH);
                        graphics.DrawEllipse(pen, (int)X + BodyWidth / 2,
                            (int)Y + BodyHeight / 2 - BodyWidth / 2, TAIL_WIDTH, TAIL_WIDTH);
                    } else {
                        graphics.DrawEllipse(pen, (int)X + BodyWidth / 2 - TAIL_WIDTH,
                            (int)Y + BodyHeight / 2 + BodyWidth / 2 - TAIL_WIDTH, TAIL_WIDTH, TAIL_WIDTH);
                        graphics.DrawEllipse(pen, (int)X + BodyWidth / 2,
                            (int)Y + BodyHeight / 2 + BodyWidth / 2 - TAIL_WIDTH, TAIL_WIDTH, TAIL_WIDTH);
                        graphics.DrawEllipse(pen, (int)X - BodyHeight / 2 + BodyWidth / 2,
                            (int)Y + BodyHeight / 2 - BodyWidth / 2, TAIL_WIDTH, TAIL_WIDTH);
                        graphics.DrawEllipse(pen, (int)X + BodyWidth + BodyHeight / 2 - BodyWidth / 2 - 10,
                            (int)Y + BodyHeight / 2 - BodyWidth / 2, TAIL_WIDTH, TAIL_WIDTH);
                    }
                    //Draw cat head
                    graphics.FillEllipse(br, (int)X - BodyHeight / 2 + BodyWidth / 4,
                        (int)Y + BodyHeight / 2 - HEAD_WIDTH / 2, HEAD_HEIGHT, HEAD_WIDTH);
                    //Draw cat ears
                    graphics.FillEllipse(br, (int)X - BodyHeight / 2 + 5, (int)Y + BodyHeight / 2 - 21,
                        HEAD_HEIGHT / 2, HEAD_WIDTH / 3);
                    graphics.FillEllipse(br, (int)X - BodyHeight / 2 + 5, (int)Y + BodyHeight / 2 + BodyWidth / 4,
                        HEAD_HEIGHT / 2, HEAD_WIDTH / 3);
                    // Draw cat body
                    graphics.FillEllipse(br, (int)X - (BodyHeight / 2) + (BodyWidth / 2),
                        (int)Y + (BodyHeight / 2) - (BodyWidth / 2), BodyHeight, BodyWidth);
                    // Draw cat tail
                    graphics.FillRectangle(br, (int)X + BodyWidth / 2 + BodyHeight / 2,
                        (int)Y + (BodyHeight / 2) - TAIL_WIDTH / 2, TAIL_HEIGHT, TAIL_WIDTH);
                    graphics.DrawArc(pen, (int)X + BodyWidth + BodyHeight / 2 + 13, (int)Y + (BodyHeight / 2) - (BodyWidth / 2),
                        BodyWidth / 2, BodyWidth / 2, 270.0F, 180.0F);

                    //IF the direction of travel for the cat is RIGHT THEN
                } else {
                    //Draw cat legs
                    if (isLeftStretched_) {
                        graphics.DrawEllipse(pen, (int)X + BodyWidth / 2 - TAIL_WIDTH,
                            (int)Y + BodyHeight / 2 + BodyWidth / 2 - TAIL_WIDTH, TAIL_WIDTH, TAIL_WIDTH);
                        graphics.DrawEllipse(pen, (int)X + BodyWidth / 2,
                            (int)Y + BodyHeight / 2 + BodyWidth / 2 - TAIL_WIDTH, TAIL_WIDTH, TAIL_WIDTH);
                        graphics.DrawEllipse(pen, (int)X - BodyHeight / 2 + BodyWidth / 2,
                            (int)Y + BodyHeight / 2 - BodyWidth / 2, TAIL_WIDTH, TAIL_WIDTH);
                        graphics.DrawEllipse(pen, (int)X + BodyWidth + BodyHeight / 2 - BodyWidth / 2 - 10,
                            (int)Y + BodyHeight / 2 - BodyWidth / 2, TAIL_WIDTH, TAIL_WIDTH);
                    } else {
                        graphics.DrawEllipse(pen, (int)X - BodyHeight / 2 + BodyWidth / 2, 
                            (int)Y + BodyHeight / 2 + BodyWidth / 2 - TAIL_WIDTH, TAIL_WIDTH, TAIL_WIDTH);
                        graphics.DrawEllipse(pen, (int)X + BodyWidth + BodyHeight / 2 - BodyWidth / 2 - 10, 
                            (int)Y + BodyHeight / 2 + BodyWidth / 2 - TAIL_WIDTH, TAIL_WIDTH, TAIL_WIDTH);
                        graphics.DrawEllipse(pen, (int)X + BodyWidth / 2 - TAIL_WIDTH, 
                            (int)Y + BodyHeight / 2 - BodyWidth / 2, TAIL_WIDTH, TAIL_WIDTH);
                        graphics.DrawEllipse(pen, (int)X + BodyWidth / 2, 
                            (int)Y + BodyHeight / 2 - BodyWidth / 2, TAIL_WIDTH, TAIL_WIDTH);
                    }
                    //Draw cat head
                    graphics.FillEllipse(br, (int)X + (BodyHeight / 2) - (BodyWidth / 2) + 10,
                        (int)Y + (BodyHeight / 2) - (HEAD_WIDTH / 2), HEAD_HEIGHT, HEAD_WIDTH);
                    //Draw cat ears
                    graphics.FillEllipse(br, (int)X + BodyWidth + BodyHeight / 2 - BodyWidth / 2 - 5,
                        (int)Y + (BodyHeight / 2) - 21, HEAD_HEIGHT / 2, HEAD_WIDTH / 3);
                    graphics.FillEllipse(br, (int)X + BodyWidth + BodyHeight / 2 - BodyWidth / 2 - 5,
                        (int)Y + BodyHeight / 2 + BodyWidth / 4, HEAD_HEIGHT / 2, HEAD_WIDTH / 3);
                    // Draw cat body
                    graphics.FillEllipse(br, (int)X - (BodyHeight / 2) + (BodyWidth / 2),
                        (int)Y + (BodyHeight / 2) - (BodyWidth / 2), BodyHeight, BodyWidth);
                    // Draw cat tail
                    graphics.FillRectangle(br, (int)X - (BodyHeight - 1) + (BodyWidth / 2),
                        (int)Y + (BodyHeight / 2) - TAIL_WIDTH / 2, TAIL_HEIGHT, TAIL_WIDTH);
                    graphics.DrawArc(pen, (int)X - BodyHeight + (BodyWidth / 2) - 6, (int)Y + (BodyHeight / 2),
                        BodyWidth / 2, BodyWidth / 2, -270.0F, 180.0F);
                }
                //IF cat is not moving THEN draw the cat sitting in position
            } else {
                //Draw cat head
                graphics.FillEllipse(br, (int)X + 10, (int)Y + 10, 40, 40);
                //Draw cat ears
                graphics.FillEllipse(br, (int)X + 7, (int)Y + 5, HEAD_WIDTH / 3, HEAD_HEIGHT / 2);
                graphics.FillEllipse(br, (int)X + 41, (int)Y + 5, HEAD_WIDTH / 3, HEAD_HEIGHT / 2);
                //Draw cat body
                graphics.FillEllipse(br, (int)X, (int)Y + BodyHeight / 4, 60, 60);
                //Draw cat tail
                graphics.DrawArc(pen, (int)X + 27, (int)Y + 40, 40, 50, -15.0F, 180.0F);
                graphics.FillEllipse(br, (int)X + 62, (int)Y + 55, TAIL_WIDTH, TAIL_WIDTH);
            }
        }

        /// <summary>
        /// Resets the state of the cat for the next level.
        /// </summary>
        /// <param name="screenWidth">The width of the screen</param>
        /// <param name="screenHeight">The height of the screen</param>
        public void ResetCat(int screenWidth, int screenHeight) {
            X = 0.2 * screenWidth;
            Y = 0.2 * screenHeight;
            isMoving_ = false;
        }

        /// <summary>
        /// Sets the speed of the cat based on whether it's running or not.
        /// </summary>
        /// <param name="isRunning">Whether the cat is running or not</param>
        public void IsRunning(bool isRunning) {
            if (!isRunning) Speed = WALKING_SPEED;
        }
    }
}
