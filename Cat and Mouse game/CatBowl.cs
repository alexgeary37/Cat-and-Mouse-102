using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat_and_Mouse_game
{
    class CatBowl : StationaryObject
    {
        //##########################################################################################
        //Private Instance Variables.

        /// <summary>
        /// The width and height of the cat bowl.
        /// </summary>
        private const int SIZE = 70;
        /// <summary>
        /// The size of each cat biscuit.
        /// </summary>
        private const int BISCUIT_SIZE = 8;
        /// <summary>
        /// The colour of the cat bowl.
        /// </summary>
        private Color catBowlColour_ = Color.Red;

        //##########################################################################################
        //Constructors.

        /// <summary>
        /// Initialises the cat bowl.
        /// </summary>
        /// <param name="x">The x position of the cat bowl</param>
        /// <param name="y">The y position of the cat bowl</param>
        public CatBowl(int x, int y)
            : base(x, y, SIZE, SIZE)
        {
        }

        //##########################################################################################
        //Public Methods.

        /// <summary>
        /// Displays the cat bowl.
        /// </summary>
        /// <param name="graphics">Where to display the cat bowl/param>
        public override void Display(Graphics graphics)
        {
            SolidBrush br = new SolidBrush(catBowlColour_);
            Pen pen = new Pen(Color.Black, 2);
            //Draw the cat bowl
            graphics.FillEllipse(br, (int)X, (int)Y, SIZE, Height);
            graphics.DrawEllipse(pen, (int)X, (int)Y, SIZE, Height);
            br.Color = Color.DarkRed;
            graphics.FillEllipse(br, (int)X + SIZE / 8, (int)Y + Height / 8,
                (int)(SIZE / 1.275), (int)(Height / 1.275));

            int biscuitX = (int)X + SIZE / 4 + 1;
            int biscuitY = (int)Y + Height / 4 + 1;
            br.Color = Color.Brown;
            //Draw cat biscuits in the cat bowl
            graphics.FillRectangle(br, biscuitX, biscuitY, BISCUIT_SIZE, BISCUIT_SIZE);
            graphics.FillRectangle(br, biscuitX + BISCUIT_SIZE + 3, biscuitY - 3, BISCUIT_SIZE, BISCUIT_SIZE);
            graphics.FillRectangle(br, biscuitX + 2 * BISCUIT_SIZE + 6, biscuitY, BISCUIT_SIZE, BISCUIT_SIZE);
            graphics.FillRectangle(br, biscuitX - 3, biscuitY + BISCUIT_SIZE + 3, BISCUIT_SIZE, BISCUIT_SIZE);
            graphics.FillRectangle(br, biscuitX + BISCUIT_SIZE, biscuitY + BISCUIT_SIZE + 3, BISCUIT_SIZE, BISCUIT_SIZE);
            graphics.FillRectangle(br, biscuitX + 2 * BISCUIT_SIZE + 3, biscuitY + BISCUIT_SIZE + 3, BISCUIT_SIZE, BISCUIT_SIZE);
            graphics.FillRectangle(br, biscuitX + 3 * BISCUIT_SIZE + 6, biscuitY + BISCUIT_SIZE + 3, BISCUIT_SIZE, BISCUIT_SIZE);
            graphics.FillRectangle(br, biscuitX + 3, biscuitY + 3 * BISCUIT_SIZE, BISCUIT_SIZE, BISCUIT_SIZE);
            graphics.FillRectangle(br, biscuitX + BISCUIT_SIZE + 6, biscuitY + 3 * BISCUIT_SIZE + 3, BISCUIT_SIZE, BISCUIT_SIZE);
            graphics.FillRectangle(br, biscuitX + 2 * BISCUIT_SIZE + 9, biscuitY + 3 * BISCUIT_SIZE, BISCUIT_SIZE, BISCUIT_SIZE);
        }
    }
}
