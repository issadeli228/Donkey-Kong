using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace Donkey_Kong
{
    public partial class Form1 : Form
    {
        #region global variables
        Image ladderImage;
        Image barrelImage;
        Image dkImage;
        Image marioImage;
        Image princessImage;
        Image princessLeftImage;
        Image heartImage;
        Image oilDrumImage;
        Image marioLeft1Image;
        Image marioLeft2Image;
        Image marioLeft3Image;
        Image marioRight1Image;
        Image marioRight2Image;
        Image marioRight3Image;
        Image marioClimb1Image;
        Image marioClimb2Image;
        Image dkGrabbingBarrelImage;
        Image dkHoldingBarrelImage;
        Image dkThrowingBarrelImage;
        Image dkIdle1Image;
        Image dkIdle2Image;
        Image dkBarrelImage;
        Image marioGameOverImage;
        Image marioJumpingRightimage;
        Image marioJumpingLeftimage;

        int animationCounter = 1;
        int climbAnimationCounter = 1;
        int dkAnimationCounter = 1;
        int jumpCounter = 1;

        int playerX = 150;
        int playerY = 505;

        int playerWidth = 30;
        int playerHeight = 40;

        int playerXSpeed = 3;
        int playerYSpeed = 2;
        int barrelXSpeed = 3;
        int barrelYSpeed = 0;

        int score = 0;

        bool leftDown = false;
        bool rightDown = false;
        bool upDown = false;
        bool spaceDown = false;
        bool mDown = false;
        bool downDown = false;

        bool jumpOk = true;

        string gameState = "waiting";

        List<int> barrelXList = new List<int>();
        List<int> barrelYList = new List<int>();
        List<int> barrelWidthList = new List<int>();
        List<int> barrelHeightList = new List<int>();
        List<int> barrelXSpeedList = new List<int>();
        List<int> barrelYSpeedList = new List<int>();

        Pen redPen = new Pen(Color.Red, 10);
        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);

        SoundPlayer jumping = new SoundPlayer(Properties.Resources.jump);
        SoundPlayer intro = new SoundPlayer(Properties.Resources.intro);
        SoundPlayer death = new SoundPlayer(Properties.Resources.death);
        SoundPlayer win = new SoundPlayer(Properties.Resources.win);
        #endregion

        public Form1()
        {
            Form2 f2 = new Form2();
            f2.Show();
            InitializeComponent();
        }


        public void GameInitialize()
        {
            #region game initialize
            titleLabel.Text = "";
            escapeLabel.Text = "";

            playerX = 150;
            playerY = 505;

            gameTimer.Enabled = true;

            gameState = "running";

            score = 0;

            animationCounter = 1;
            climbAnimationCounter = 1;

            startButton.Visible = false;
            controlsButton.Visible = false;

            ladderImage = Properties.Resources.ladder;
            barrelImage = Properties.Resources.barrel;
            dkImage = Properties.Resources.dk;
            marioImage = Properties.Resources.mario;
            princessImage = Properties.Resources.princess;
            princessLeftImage = Properties.Resources.princessLeft;
            heartImage = Properties.Resources.heart;
            oilDrumImage = Properties.Resources.oildrum;
            marioLeft1Image = Properties.Resources.marioLeft1;
            marioLeft2Image = Properties.Resources.marioLeft2;
            marioLeft3Image = Properties.Resources.marioLeft3;
            marioRight1Image = Properties.Resources.marioRight1;
            marioRight2Image = Properties.Resources.marioRight2;
            marioRight3Image = Properties.Resources.marioRight3;
            marioClimb1Image = Properties.Resources.marioClimb1;
            marioClimb2Image = Properties.Resources.marioClimb2;
            dkGrabbingBarrelImage = Properties.Resources.dkGrabbingBarrel;
            dkHoldingBarrelImage = Properties.Resources.dkHoldingBarrel;
            dkThrowingBarrelImage = Properties.Resources.dkThrowingBarrel;
            dkIdle1Image = Properties.Resources.dkIdle1;
            dkIdle2Image = Properties.Resources.dkIdle2;
            dkBarrelImage = Properties.Resources.dkBarrel;
            marioGameOverImage = Properties.Resources.marioGameOver;
            marioJumpingRightimage = Properties.Resources.marioJumpingRight;
            marioJumpingLeftimage = Properties.Resources.marioJumpingLeft;

            intro.Play();
            Thread.Sleep(5500);

            this.Focus();

            #endregion
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            #region keyDown
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;
                case Keys.Up:
                    upDown = true;
                    break;
                case Keys.Down:
                    downDown = true;
                    break;
                case Keys.Escape:
                    if (gameState == "waiting")
                    {
                        Application.Exit();
                    }
                    break;
                case Keys.M:
                    mDown = true;
                    if (gameState == "overLose" && mDown == true)
                    {
                        gameState = "waiting";
                        titleLabel.Text = "Donkey Kong";
                        escapeLabel.Text = "Press Escape to Exit";
                        startButton.Visible = true;
                        controlsButton.Visible = true;
                        startButton.Enabled = true;
                        controlsButton.Enabled = true;
                        Refresh();
                    }

                    if (gameState == "controls" && mDown == true)
                    {
                        gameState = "waiting";
                        titleLabel.Text = "Donkey Kong";
                        escapeLabel.Text = "Press Escape to Exit";
                        startButton.Visible = true;
                        controlsButton.Visible = true;
                        startButton.Enabled = true;
                        controlsButton.Enabled = true;
                        controlsLabel.Text = $"";
                    }

                    if (gameState == "overWin" && mDown == true)
                    {
                        gameState = "waiting";
                        titleLabel.Text = "Donkey Kong";
                        escapeLabel.Text = "Press Escape to Exit";
                        startButton.Visible = true;
                        controlsButton.Visible = true;
                        startButton.Enabled = true;
                        controlsButton.Enabled = true;
                        GameInitialize();
                    }
                    break;
                case Keys.Space:
                    if (jumpOk == true)
                    {
                        jumping.Play();
                        jumpOk = false;
                    }
                    spaceDown = true;
                    break;
            }
            #endregion
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            #region keyUp
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftDown = false;
                    marioImage = marioLeft1Image;
                    animationCounter = 1;
                    break;
                case Keys.Right:
                    rightDown = false;
                    marioImage = marioRight1Image;
                    animationCounter = 1;
                    break;
                case Keys.Up:
                    upDown = false;
                    marioImage = marioClimb1Image;
                    climbAnimationCounter = 1;
                    break;
                case Keys.Down:
                    downDown = false;
                    break;
                case Keys.M:
                    mDown = false;
                    break;
            }
            #endregion
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            #region graphics
            if (gameState == "running")
            {
                //platforms
                e.Graphics.DrawLine(redPen, 50, 550, 650, 550);
                e.Graphics.DrawLine(redPen, 50, 470, 650, 470);
                e.Graphics.DrawLine(redPen, 50, 390, 650, 390);
                e.Graphics.DrawLine(redPen, 50, 310, 650, 310);
                e.Graphics.DrawLine(redPen, 50, 230, 650, 230);
                e.Graphics.DrawLine(redPen, 50, 150, 650, 150);
                e.Graphics.DrawLine(redPen, 250, 70, 400, 70);

                //ladders
                e.Graphics.DrawImage(ladderImage, 580, 475, 25, 70);

                e.Graphics.DrawImage(ladderImage, 220, 395, 25, 70);
                e.Graphics.DrawImage(ladderImage, 100, 395, 25, 70);

                e.Graphics.DrawImage(ladderImage, 590, 315, 25, 70);
                e.Graphics.DrawImage(ladderImage, 450, 315, 25, 70);

                e.Graphics.DrawImage(ladderImage, 60, 235, 25, 70);
                e.Graphics.DrawImage(ladderImage, 190, 235, 25, 70);

                e.Graphics.DrawImage(ladderImage, 550, 155, 25, 70);

                e.Graphics.DrawImage(ladderImage, 360, 75, 25, 70);

                //player
                e.Graphics.DrawImage(marioImage, playerX, playerY, playerWidth, playerHeight);

                //top barrels
                e.Graphics.DrawImage(barrelImage, 50, 65, 60, 80);

                //dk
                e.Graphics.DrawImage(dkImage, 125, 27, 120, 120);

                //princess
                e.Graphics.DrawImage(princessImage, 260, 2, 50, 70);

                //oil drum
                e.Graphics.DrawImage(oilDrumImage, 55, 477, 50, 70);

            }

            //add barrels
            if (dkAnimationCounter == 40)
            {
                barrelXList.Add(230);
                barrelYList.Add(116);
                barrelWidthList.Add(30);
                barrelHeightList.Add(30);
                barrelXSpeedList.Add(3);
                barrelYSpeedList.Add(2);
                dkAnimationCounter = 41;
            }

            //draw barrels
            for (int i = 0; i < barrelXList.Count(); i++)
            {
                //if (dkAnimationCounter > 40)
                {
                    e.Graphics.DrawImage(dkBarrelImage, barrelXList[i], barrelYList[i], barrelWidthList[i], barrelHeightList[i]);
                }
            }

            //game states
            //win
            if (gameState == "overWin")
            {
                gameTimer.Enabled = false;

                e.Graphics.DrawImage(marioRight1Image, 190, 400, 100, 120);
                e.Graphics.DrawImage(princessLeftImage, 390, 400, 190, 130);
                e.Graphics.DrawImage(heartImage, 180, 250, 360, 240);

                titleLabel.Text = $"Congratulations!";
                escapeLabel.Text = $"Press M to Reutrn";
            }

            //controls
            if (gameState == "controls")
            {
                titleLabel.Text = $"Controls";
                startButton.Visible = false;
                controlsButton.Visible = false;
                escapeLabel.Text = "Press M to Return";
                startButton.Enabled = false;
                controlsButton.Enabled = false;
            }

            //waiting
            if (gameState == "waiting")
            {
                titleLabel.Text = "Donkey Kong";
                escapeLabel.Text = "Press Escape to Exit";
                startButton.Visible = true;
                controlsButton.Visible = true;
                startButton.Enabled = true;
                controlsButton.Enabled = true;
            }

            //lose
            if (gameState == "overLose")
            {
                gameTimer.Enabled = false;
                titleLabel.Text = $"You Lose";
                escapeLabel.Text = "Press M to Exit";
                e.Graphics.DrawImage(marioGameOverImage, 80, 200, 550, 250);
            }

            #endregion
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            #region startbutton
            if (gameState == "waiting")
            {
                GameInitialize();
            }
            #endregion
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {

            #region move player
            if (leftDown == true && playerX > 50)
            {
                playerX -= playerXSpeed;
                if (animationCounter < 4)
                {
                    marioImage = marioLeft1Image;
                }
                else if (animationCounter < 7)
                {
                    marioImage = marioLeft2Image;
                }
                else if (animationCounter < 10)
                {
                    marioImage = marioLeft3Image;
                }

                animationCounter++;

                if (animationCounter == 11)
                {
                    animationCounter = 1;
                }
            }

            if (rightDown == true && playerX < 620)
            {
                playerX += playerXSpeed;
                if (animationCounter < 4)
                {
                    marioImage = marioRight1Image;
                }
                else if (animationCounter < 7)
                {
                    marioImage = marioRight2Image;
                }
                else if (animationCounter < 10)
                {
                    marioImage = marioRight3Image;
                }

                animationCounter++;

                if (animationCounter == 11)
                {
                    animationCounter = 1;
                }
            }

            if (jumpOk == false)
            {

                if (jumpCounter <= 8)
                {
                    marioImage = marioJumpingRightimage;
                    playerY -= 4;
                }
                else if (jumpCounter <= 16)
                {
                    marioImage = marioJumpingRightimage;
                    playerY += 4;
                }
                else
                {
                    jumpCounter = 0;
                    jumpOk = true;
                }

                if (leftDown == true)
                {
                    marioImage = marioJumpingLeftimage;
                }
                if (rightDown == true)
                {
                    marioImage = marioJumpingRightimage;
                }

                jumpCounter++;
            }
            #endregion

            #region ladder collision
            Rectangle playerRec = new Rectangle(playerX, playerY, playerWidth, playerHeight);
            Rectangle ladder1Rec = new Rectangle(580, 465, 25, 75);

            Rectangle ladder2Rec = new Rectangle(220, 385, 25, 70);
            Rectangle ladder3Rec = new Rectangle(100, 385, 25, 70);

            Rectangle ladder4Rec = new Rectangle(590, 305, 25, 70);
            Rectangle ladder5Rec = new Rectangle(450, 305, 25, 70);

            Rectangle ladder6Rec = new Rectangle(60, 225, 25, 70);
            Rectangle ladder7Rec = new Rectangle(190, 225, 25, 70);

            Rectangle ladder8Rec = new Rectangle(550, 145, 25, 70);

            Rectangle ladder9Rec = new Rectangle(360, 65, 25, 70);

            if (playerRec.IntersectsWith(ladder1Rec) && upDown == true)
            {
                playerY -= playerXSpeed - 2;
                if (climbAnimationCounter < 4)
                {
                    marioImage = marioClimb1Image;
                }
                else if (climbAnimationCounter < 7)
                {
                    marioImage = marioClimb2Image;
                }
                climbAnimationCounter++;

                if (climbAnimationCounter == 7)
                {
                    climbAnimationCounter = 1;
                }
            }
            if (playerRec.IntersectsWith(ladder2Rec) && upDown == true)
            {
                playerY -= playerXSpeed - 2;
                if (climbAnimationCounter < 4)
                {
                    marioImage = marioClimb1Image;
                }
                else if (climbAnimationCounter < 7)
                {
                    marioImage = marioClimb2Image;
                }
                climbAnimationCounter++;

                if (climbAnimationCounter == 7)
                {
                    climbAnimationCounter = 1;
                }
            }
            if (playerRec.IntersectsWith(ladder3Rec) && upDown == true)
            {
                playerY -= playerXSpeed - 2;
                if (climbAnimationCounter < 4)
                {
                    marioImage = marioClimb1Image;
                }
                else if (climbAnimationCounter < 7)
                {
                    marioImage = marioClimb2Image;
                }
                climbAnimationCounter++;

                if (climbAnimationCounter == 7)
                {
                    climbAnimationCounter = 1;
                }
            }
            if (playerRec.IntersectsWith(ladder4Rec) && upDown == true)
            {
                playerY -= playerXSpeed - 2;
                if (climbAnimationCounter < 4)
                {
                    marioImage = marioClimb1Image;
                }
                else if (climbAnimationCounter < 7)
                {
                    marioImage = marioClimb2Image;
                }
                climbAnimationCounter++;

                if (climbAnimationCounter == 7)
                {
                    climbAnimationCounter = 1;
                }
            }
            if (playerRec.IntersectsWith(ladder5Rec) && upDown == true)
            {
                playerY -= playerXSpeed - 2;
                if (climbAnimationCounter < 4)
                {
                    marioImage = marioClimb1Image;
                }
                else if (climbAnimationCounter < 7)
                {
                    marioImage = marioClimb2Image;
                }
                climbAnimationCounter++;

                if (climbAnimationCounter == 7)
                {
                    climbAnimationCounter = 1;
                }
            }
            if (playerRec.IntersectsWith(ladder6Rec) && upDown == true)
            {
                playerY -= playerXSpeed - 2;
                if (climbAnimationCounter < 4)
                {
                    marioImage = marioClimb1Image;
                }
                else if (climbAnimationCounter < 7)
                {
                    marioImage = marioClimb2Image;
                }
                climbAnimationCounter++;

                if (climbAnimationCounter == 7)
                {
                    climbAnimationCounter = 1;
                }
            }
            if (playerRec.IntersectsWith(ladder7Rec) && upDown == true)
            {
                playerY -= playerXSpeed - 2;
                if (climbAnimationCounter < 4)
                {
                    marioImage = marioClimb1Image;
                }
                else if (climbAnimationCounter < 7)
                {
                    marioImage = marioClimb2Image;
                }
                climbAnimationCounter++;

                if (climbAnimationCounter == 7)
                {
                    climbAnimationCounter = 1;
                }
            }
            if (playerRec.IntersectsWith(ladder8Rec) && upDown == true)
            {
                playerY -= playerXSpeed - 2;
                if (climbAnimationCounter < 4)
                {
                    marioImage = marioClimb1Image;
                }
                else if (climbAnimationCounter < 7)
                {
                    marioImage = marioClimb2Image;
                }
                climbAnimationCounter++;

                if (climbAnimationCounter == 7)
                {
                    climbAnimationCounter = 1;
                }
            }
            if (playerRec.IntersectsWith(ladder9Rec) && upDown == true)
            {
                playerY -= playerXSpeed - 2;
                if (climbAnimationCounter < 4)
                {
                    marioImage = marioClimb1Image;
                }
                else if (climbAnimationCounter < 7)
                {
                    marioImage = marioClimb2Image;
                }
                climbAnimationCounter++;

                if (climbAnimationCounter == 7)
                {
                    climbAnimationCounter = 1;
                }
            }



            if (playerRec.IntersectsWith(ladder1Rec) && downDown == true)
            {
                playerY += playerXSpeed - 2;
                if (climbAnimationCounter < 4)
                {
                    marioImage = marioClimb1Image;
                }
                else if (climbAnimationCounter < 7)
                {
                    marioImage = marioClimb2Image;
                }
                climbAnimationCounter++;

                if (climbAnimationCounter == 7)
                {
                    climbAnimationCounter = 1;
                }
            }
            if (playerRec.IntersectsWith(ladder2Rec) && downDown == true)
            {
                playerY += playerXSpeed - 2;
                if (climbAnimationCounter < 4)
                {
                    marioImage = marioClimb1Image;
                }
                else if (climbAnimationCounter < 7)
                {
                    marioImage = marioClimb2Image;
                }
                climbAnimationCounter++;

                if (climbAnimationCounter == 7)
                {
                    climbAnimationCounter = 1;
                }
            }
            if (playerRec.IntersectsWith(ladder3Rec) && downDown == true)
            {
                playerY += playerXSpeed - 2;
                if (climbAnimationCounter < 4)
                {
                    marioImage = marioClimb1Image;
                }
                else if (climbAnimationCounter < 7)
                {
                    marioImage = marioClimb2Image;
                }
                climbAnimationCounter++;

                if (climbAnimationCounter == 7)
                {
                    climbAnimationCounter = 1;
                }
            }
            if (playerRec.IntersectsWith(ladder4Rec) && downDown == true)
            {
                playerY += playerXSpeed - 2;
                if (climbAnimationCounter < 4)
                {
                    marioImage = marioClimb1Image;
                }
                else if (climbAnimationCounter < 7)
                {
                    marioImage = marioClimb2Image;
                }
                climbAnimationCounter++;

                if (climbAnimationCounter == 7)
                {
                    climbAnimationCounter = 1;
                }
            }
            if (playerRec.IntersectsWith(ladder5Rec) && downDown == true)
            {
                playerY += playerXSpeed - 2;
                if (climbAnimationCounter < 4)
                {
                    marioImage = marioClimb1Image;
                }
                else if (climbAnimationCounter < 7)
                {
                    marioImage = marioClimb2Image;
                }
                climbAnimationCounter++;

                if (climbAnimationCounter == 7)
                {
                    climbAnimationCounter = 1;
                }
            }
            if (playerRec.IntersectsWith(ladder6Rec) && downDown == true)
            {
                playerY += playerXSpeed - 2;
                if (climbAnimationCounter < 4)
                {
                    marioImage = marioClimb1Image;
                }
                else if (climbAnimationCounter < 7)
                {
                    marioImage = marioClimb2Image;
                }
                climbAnimationCounter++;

                if (climbAnimationCounter == 7)
                {
                    climbAnimationCounter = 1;
                }
            }
            if (playerRec.IntersectsWith(ladder7Rec) && downDown == true)
            {
                playerY += playerXSpeed - 2;
                if (climbAnimationCounter < 4)
                {
                    marioImage = marioClimb1Image;
                }
                else if (climbAnimationCounter < 7)
                {
                    marioImage = marioClimb2Image;
                }
                climbAnimationCounter++;

                if (climbAnimationCounter == 7)
                {
                    climbAnimationCounter = 1;
                }
            }
            if (playerRec.IntersectsWith(ladder8Rec) && downDown == true)
            {
                playerY += playerXSpeed - 2;
                if (climbAnimationCounter < 4)
                {
                    marioImage = marioClimb1Image;
                }
                else if (climbAnimationCounter < 7)
                {
                    marioImage = marioClimb2Image;
                }
                climbAnimationCounter++;

                if (climbAnimationCounter == 7)
                {
                    climbAnimationCounter = 1;
                }
            }
            if (playerRec.IntersectsWith(ladder9Rec) && downDown == true)
            {
                playerY += playerXSpeed - 2;
                if (climbAnimationCounter < 4)
                {
                    marioImage = marioClimb1Image;
                }
                else if (climbAnimationCounter < 7)
                {
                    marioImage = marioClimb2Image;
                }
                climbAnimationCounter++;

                if (climbAnimationCounter == 7)
                {
                    climbAnimationCounter = 1;
                }
            }
            #endregion

            #region barrel collision

            for (int i = 0; i < barrelXList.Count(); i++)
            {
                Rectangle barrelRec = new Rectangle(barrelXList[i] + 12, barrelYList[i] + 12, 4, 4);

                if (playerRec.IntersectsWith(barrelRec))
                {
                    death.Play();
                    gameState = "overLose";
                    gameTimer.Enabled = false;
                    barrelXList.Clear();
                    barrelYList.Clear();
                    barrelWidthList.Clear();
                    barrelHeightList.Clear();
                    barrelXSpeedList.Clear();
                    barrelYSpeedList.Clear();
                    
                }
            }

            #endregion

            #region dk

            dkAnimationCounter++;

            if (dkAnimationCounter < 20)
            {
                dkImage = dkGrabbingBarrelImage;
            }
            else if (dkAnimationCounter < 40)
            {
                dkImage = dkHoldingBarrelImage;
            }
            else if (dkAnimationCounter < 60)
            {
                dkImage = dkThrowingBarrelImage;
            }
            else if (dkAnimationCounter < 80)
            {
                dkImage = dkIdle1Image;
            }
            else if (dkAnimationCounter < 90)
            {
                dkImage = dkIdle2Image;
            }
            else if (dkAnimationCounter < 100)
            {
                dkImage = dkIdle1Image;
            }
            else if (dkAnimationCounter < 110)
            {
                dkImage = dkIdle2Image;
            }

            if (dkAnimationCounter == 130)
            {
                dkAnimationCounter = 1;
            }
            #endregion

            #region move barrels
            for (int i = 0; i < barrelXList.Count(); i++)
            {
                barrelXList[i] += barrelXSpeedList[i];

                if (barrelXList[i] > 680)
                {
                    barrelXSpeedList[i] *= -1;
                }
                if (barrelXList[i] < 4)
                {
                    barrelXSpeedList[i] *= -1;
                }

                if (barrelXList[i] > 622)
                {
                    barrelYList[i] += barrelYSpeedList[i];
                }
                if (barrelXList[i] < 60)
                {
                    barrelYList[i] += barrelYSpeedList[i];
                }
            }
            #endregion

            #region removing barrels
            for (int i = 0; i < barrelXList.Count(); i++)
            {
                if (barrelYList[i] >= 500 && barrelXList[i] <= 70)
                {
                    barrelXList.RemoveAt(i);
                    barrelYList.RemoveAt(i);
                    barrelWidthList.RemoveAt(i);
                    barrelHeightList.RemoveAt(i);
                    break;
                }
            }


            #endregion

            #region scoring
            for (int i = 0; i < barrelYList.Count(); i++)
            {
                if (playerY < barrelYList[i] && jumpOk == false)
                {
                    score += 5;
                    scoreNumberLabel.Text = $"{score}";
                }
            }
            #endregion

            #region winning
            if (playerY < 28)
            {
                win.Play();
                gameState = "overWin";
            }
            #endregion

            Refresh();
        }

        private void controlsButton_Click(object sender, EventArgs e)
        {
            #region controls
            gameState = "controls";

            controlsLabel.Visible = true;
            controlsLabel.Text = $"Left Arrow = Move Left\n\nRight Arrow = Move Right\n\nUp Arrow = Climb Up Ladder\n\nDown Arrow = Cimb Down Ladder\n\nSpace = Jump";
            this.Focus();
            #endregion
        }
    }
}
