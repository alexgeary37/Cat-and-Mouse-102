using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cat_and_Mouse_game {
	
    public partial class Form : System.Windows.Forms.Form {
        //Private Instance Variables
		
        Random random = new Random();
        private int screenWidth_;
        private int screenHeight_;
		
        /// <summary>
        /// Counters used in the timer tick event handler which control
        /// when the cat direction is to change, and when the time limit
        /// counter is to change to a new number
        /// </summary>
        private int catDirectionCounter_;
        private int secondCounter_;
        private int displayCounter_;

        private int playerScore_;
        private int level_;
        private int catRunningSpeed_;
        
        // The number of pieces of cheese to collect.
        private int cheesePiecesToCollect_;
		
        // Booleans for whether a specific key has been pressed or not.
        private bool isUpPressed_;
        private bool isDownPressed_;
        private bool isLeftPressed_;
        private bool isRightPressed_;
		
        private MouseDen mouseDen_;
        private CatBowl catBowl_;
        private Mouse mouse_;
        private Cat cat_;
        private List<StationaryObject> safetyZoneList_;
        private List<Wall> wallList_;
        private List<Cheese> cheeseList_;
		
        private const int WALL_THICKNESS = 40;


        public Form() {
            InitializeComponent();
            //Prevents the form size from being adjusted
            MinimumSize = Size;
            MaximumSize = Size;
            screenWidth_ = pictureBoxDisplay.Width;
            screenHeight_ = pictureBoxDisplay.Height;
            playerScore_ = 0;
            cat_ = new Cat(screenWidth_, screenHeight_);
            mouse_ = new Mouse(screenWidth_, screenHeight_);
            catRunningSpeed_ = 5;
            level_ = 1;
            LoadForm();
        }
		
		
        //##########################################################################################
        //Private Methods.

        /// <summary>
        /// Loads the form.
        /// </summary>
        private void LoadForm() {
            catDirectionCounter_ = 20;
            secondCounter_ = 0;
            displayCounter_ = 60;

            safetyZoneList_ = new List<StationaryObject>();
            wallList_ = new List<Wall>();
            cheeseList_ = new List<Cheese>();

            catBowl_ = new CatBowl(screenWidth_ / 5, screenHeight_ / 10);
            mouseDen_ = new MouseDen(screenWidth_ - WALL_THICKNESS, 3 * screenHeight_ / 4);
            cat_.ResetCat(screenWidth_, screenHeight_);
            mouse_.ResetMouse(screenWidth_, screenHeight_);

            //ADD objects to the lists
            safetyZoneList_.Add(mouseDen_);
            safetyZoneList_.Add(new HidingPlace(4 * screenWidth_ / 10, 0));
            safetyZoneList_.Add(new HidingPlace(7 * screenWidth_ / 10, 0));
            safetyZoneList_.Add(new HidingPlace(screenWidth_ - WALL_THICKNESS, WALL_THICKNESS + screenHeight_ / 3));
            safetyZoneList_.Add(new HidingPlace(screenWidth_ - screenWidth_ / 2, screenHeight_ - WALL_THICKNESS));
            safetyZoneList_.Add(new HidingPlace(0, screenWidth_ / 4));
            safetyZoneList_.Add(new HidingPlace(0, screenWidth_ / 2));
            safetyZoneList_.Add(new HidingPlace(screenWidth_ / 5, screenHeight_ - WALL_THICKNESS));
            mouse_.GetList(safetyZoneList_);

            wallList_.Add(new Wall(0, 0, screenWidth_, WALL_THICKNESS));
            wallList_.Add(new Wall(0, screenHeight_ - WALL_THICKNESS, screenWidth_, WALL_THICKNESS));
            wallList_.Add(new Wall(0, 0, WALL_THICKNESS, screenHeight_ - WALL_THICKNESS));
            wallList_.Add(new Wall(screenWidth_ - WALL_THICKNESS, 0, WALL_THICKNESS, 3 * screenHeight_ / 4));
            wallList_.Add(new Wall(screenWidth_ - WALL_THICKNESS, 3 * screenHeight_ / 4 + 60, WALL_THICKNESS,
                screenHeight_ - 3 * screenHeight_ / 4 + 60));

            /*ADD pieces of cheese to the cheese list with coordinates that
             are not within in the boundaries of the mouse den*/
            while (cheeseList_.Count < 6) {
                int cheeseX = random.Next(40, screenWidth_ - 80);
                int cheeseY = random.Next(40, screenHeight_ - 75);
                Rectangle cheeseBounds = new Rectangle(cheeseX, cheeseY, 200, 200);
                if (!mouseDen_.GeneralLocation.IntersectsWith(cheeseBounds)) {
                    cheeseList_.Add(new Cheese(cheeseX, cheeseY));
                }
            }

            /*Set the number of pieces of cheese to collect to the number of
            pieces which has been displayed*/
            cheesePiecesToCollect_ = cheeseList_.Count;
            //Set booleans to false so the mouse doesn't move
            isUpPressed_ = false;
            isDownPressed_ = false;
            isLeftPressed_ = false;
            isRightPressed_ = false;
            //Start the timer tick event method
            gameTimer_.Start();
        }
		
        private void GameOver(string result) {
            gameTimer_.Enabled = false;
            string status = "";
            string points = " points!";
			
            if (result == "Win!") {
                level_++;
                catRunningSpeed_++;
                if (level_ == 6) {
                    status = "      You're amazing!";
                } else if (level_ == 11) {
                    status = "      You're a star!";
                } else if (level_ == 16) {
                    status = "      You're a legend!!";
                }
                MessageBox.Show("You " + result + "     Current points = " + playerScore_ + status);
            } else {
                MessageBox.Show("You " + result + "     Total score:  " + playerScore_.ToString() + points);
				saveHighScore(playerScore);
                catRunningSpeed_ = 5;
                playerScore_ = 0;
                level_ = 1;
            }
			
            /*Refresh the picture box and reset all lists and objects to
             their original empty or null state and load the form*/
            pictureBoxDisplay.Refresh();
            cheeseList_.Clear();
            mouseDen_ = null;
            catBowl_ = null;
            LoadForm();
        }
		
		private void saveHighScore(int playerScore) {
			String directory = Environment.CurrentDirectory;
			
			try {
				using (StreamWriter w = File.AppendText(directory)) {
					w.WriteLine(playerScore.ToString());
				}
			} catch (Exception e) {
				Console.WriteLine(e);
			}
		}
		
        private void DisplayMice(Graphics graphics) {
            int x = screenWidth_ - WALL_THICKNESS + 15;
            int y = 3 * screenHeight_ / 4 + 2;
            const int SIZE = 8;
            const int EAR_SIZE = 4;

            Pen pen = new Pen(Color.Black);
            SolidBrush br = new SolidBrush(Color.Gray);
            for (int i = 1; i < 5; i++) {
                for (int j = 1; j < 3; j++) {
                    //Draw ears
                    graphics.FillEllipse(br, x - 2, y - 2, EAR_SIZE, EAR_SIZE);
                    graphics.FillEllipse(br, x + SIZE - EAR_SIZE + 2, y - 2, EAR_SIZE, EAR_SIZE);
                    graphics.DrawEllipse(pen, x - 2, y - 2, EAR_SIZE, EAR_SIZE);
                    graphics.DrawEllipse(pen, x + SIZE - EAR_SIZE + 2, y - 2, EAR_SIZE, EAR_SIZE);
                    //Draw body
                    graphics.FillEllipse(br, x, y, SIZE, SIZE);
                    graphics.DrawEllipse(pen, x, y, SIZE, SIZE);
                    x += SIZE + 2;
                }
                x = screenWidth_ - WALL_THICKNESS + 15;
                y += SIZE + 3;
            }
        }

        //##########################################################################################
        //Event Handlers.
		
        private void pictureBoxDisplay_Paint(object sender, PaintEventArgs e) {
            Graphics graphics = e.Graphics;
            pictureBoxDisplay.BackColor = Color.SaddleBrown;
            //Display all individual objects
            mouseDen_.Display(graphics);
            catBowl_.Display(graphics);
            DisplayMice(graphics);
            mouse_.Display(graphics);
            foreach (Cheese c in cheeseList_) {
                c.Display(graphics);
            }
            cat_.Display(graphics);
            //Display each object in the all the lists
            foreach (Wall w in wallList_) {
                w.Display(graphics);
            }
            for (int i = 1; i < safetyZoneList_.Count; i++) {
                safetyZoneList_[i].Display(graphics);
            }
        }
		
        // Event handler for refreshing the graphics in the picturebox in real time.
        private void gameTimer_Tick(object sender, EventArgs e) {
            Text = "Cat & Mouse                " + "Level " + level_ + 
                "                Time remaining: " + displayCounter_.ToString() + "              " +
                "Score: " + playerScore_.ToString();
            //IF there have been 20 ticks THEN change the direction of the cat
            if (catDirectionCounter_ == 20) {
                double distanceUp;
                double distanceDown;
                double distanceLeft;
                double distanceRight;
                //List to hold the distance values of distance between the cat and its target
                List<double> distanceList = new List<double>();
                if (!mouse_.IsSafe) {
                    //Distances between the cat and the mouse
                    distanceUp = cat_.Y - (mouse_.Y + mouse_.BodyHeight);
                    distanceDown = (mouse_.Y - mouse_.BodyHeight) - cat_.Y;
                    distanceLeft = cat_.X - (mouse_.X + mouse_.BodyWidth);
                    distanceRight = (mouse_.X - mouse_.BodyWidth) - cat_.X;
                    cat_.Speed = catRunningSpeed_;
                } else {
                    //Distances between the cat and its catbowl
                    distanceUp = cat_.Y - ((int)catBowl_.Y + catBowl_.Height);
                    distanceDown = ((int)catBowl_.Y - catBowl_.Height) - cat_.Y;
                    distanceLeft = cat_.X - ((int)catBowl_.X + catBowl_.Width);
                    distanceRight = ((int)catBowl_.X - catBowl_.Width) - cat_.X;
                    cat_.IsRunning(false);
                }
                distanceList.Add(distanceUp);
                distanceList.Add(distanceDown);
                distanceList.Add(distanceLeft);
                distanceList.Add(distanceRight);
                distanceList.Sort();
                double greatestDistanceToCat = distanceList[distanceList.Count - 1];
                //Set the direction of the cat to whichever is the greatest distance
                if (greatestDistanceToCat == distanceUp) {
                    cat_.Direction = Direction.UP;
                } else if (greatestDistanceToCat == distanceDown) {
                    cat_.Direction = Direction.DOWN;
                } else if (greatestDistanceToCat == distanceLeft) {
                    cat_.Direction = Direction.LEFT;
                } else if (greatestDistanceToCat == distanceRight) {
                    cat_.Direction = Direction.RIGHT;
                }
                catDirectionCounter_ = 0;
            }

            /*Change the legs positions of the cat every certain number of ticks
             and based on whether the cat is chasing the mouse or not*/
            if (cat_.IsMoving && !mouse_.IsSafe) {
                if (catDirectionCounter_ >= 0 && catDirectionCounter_ <= 5 ||
                    catDirectionCounter_ >= 11 && catDirectionCounter_ <= 15) {
                    cat_.IsLeftStretched = true;
                } else if (catDirectionCounter_ >= 6 && catDirectionCounter_ <= 10 ||
                    catDirectionCounter_ >= 16 && catDirectionCounter_ <= 20) {
                    cat_.IsLeftStretched = false;
                }
            } else if (cat_.IsMoving && mouse_.IsSafe) {
                if (catDirectionCounter_ >= 0 && catDirectionCounter_ <= 10) {
                    cat_.IsLeftStretched = true;
                } else if (catDirectionCounter_ >= 11 && catDirectionCounter_ <= 20) {
                    cat_.IsLeftStretched = false;
                }
            }

            /*IF the cats location does not intersect with the catbowl OR IF
            the cats location does intersect with the catbowl and the mouse is unsafe THEN
            the cat moves.*/
            if (!cat_.SpriteLocation.IntersectsWith(catBowl_.GeneralLocation) ||
                cat_.SpriteLocation.IntersectsWith(catBowl_.GeneralLocation) && !mouse_.IsSafe) {
                /*IF the cat intersects the mouse den THEN the cat 
                * direction is changed to the opposite direction*/
                if (cat_.SpriteLocation.IntersectsWith(mouseDen_.GeneralLocation)) {
                    switch (cat_.Direction) {
                        case Direction.UP:
                            cat_.Direction = Direction.DOWN;
                            break;
                        case Direction.DOWN:
                            cat_.Direction = Direction.UP;
                            break;
                        case Direction.LEFT:
                            cat_.Direction = Direction.RIGHT;
                            break;
                        case Direction.RIGHT:
                            cat_.Direction = Direction.LEFT;
                            break;
                    }
                }
                cat_.Move(screenWidth_, screenHeight_);
                cat_.IsMoving = true;
            } else {
                cat_.IsMoving = false;
            }

            //Move the mouse in the direction specified by the key pressed
            if (isUpPressed_ == true) {
                mouse_.Direction = Direction.UP;
                mouse_.Move(screenWidth_, screenHeight_);
            } else if (isDownPressed_ == true) {
                mouse_.Direction = Direction.DOWN;
                mouse_.Move(screenWidth_, screenHeight_);
            } else if (isLeftPressed_ == true) {
                mouse_.Direction = Direction.LEFT;
                mouse_.Move(screenWidth_, screenHeight_);
            } else if (isRightPressed_ == true) {
                mouse_.Direction = Direction.RIGHT;
                mouse_.Move(screenWidth_, screenHeight_);
            }

            /*IF the mouse does not have cheese THEN IF the mouse intersects a piece
            of cheese THEN REMOVE the piece of cheese from the cheese list and draw the 
            mouse with a piece of cheese in its mouth*/
            if (!mouse_.HasCheese) {
                for (int i = cheeseList_.Count - 1; i >= 0; i--) {
                    Cheese cheesePiece = cheeseList_[i];
                    if (mouse_.SpriteLocation.IntersectsWith(cheesePiece.GeneralLocation)) {
                        cheeseList_.Remove(cheesePiece);
                        mouse_.HasCheese = true;
                        break;
                    }
                }
            }

            /*IF the mouse intersects the mouse den and has cheese in its mouth
             THEN the mouse is redrawn without cheese in its mouth and the amount
             of cheese in the mouse den increases by 1 and the player score increases
             by 50. IF the amount of cheese in the den = number of pieces to collect
             THEN the player wins, ELSE IF the display counter reaches 0 or the cat
             collides with the mouse THEN the player loses*/
            if (mouse_.SpriteLocation.IntersectsWith(mouseDen_.GeneralLocation)) {
                if (mouse_.HasCheese) {
                    mouse_.HasCheese = false;
                    mouseDen_.AmountOfCheese++;
                    playerScore_ += 50;
                    if (mouseDen_.AmountOfCheese == cheesePiecesToCollect_) {
                        GameOver("Win!");
                        return;
                    }
                }
            }
            if (displayCounter_ == 0 || cat_.HasCollided(mouse_)) {
                GameOver("Lose!");
                return;
            }

            catDirectionCounter_++;
            secondCounter_++;
            if (secondCounter_ == 30) {
                displayCounter_--;
                secondCounter_ = 0;
            }
            pictureBoxDisplay.Refresh();
        }
		
        // Indicates which keys are held down.
        private void Form_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Up) {
                isUpPressed_ = true;
            } else if (e.KeyCode == Keys.Down) {
                isDownPressed_ = true;
            } else if (e.KeyCode == Keys.Left) {
                isLeftPressed_ = true;
            } else if (e.KeyCode == Keys.Right) {
                isRightPressed_ = true;
            }
        }
		
        // Indicates which keys are NOT held down.
        private void Form_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Up) {
                isUpPressed_ = false;
            } else if (e.KeyCode == Keys.Down) {
                isDownPressed_ = false;
            } else if (e.KeyCode == Keys.Left) {
                isLeftPressed_ = false;
            } else if (e.KeyCode == Keys.Right) {
                isRightPressed_ = false;
            }
        }
    }
}
