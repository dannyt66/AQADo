using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace AQADo
{
    public partial class gameWindow : Form
    {
        public string p1Name;
        public string p2Name;
        public int counterIncrement = 48;
        diceDialog die;
        int[] counterPositions = new int[4] { 1, 1, 1, 1 };
        public static int gameStatePlayer1DieRoll = 0;
        public static int gameStatePlayer1CounterMove = 1;
        public static int gameStatePlayer2DieRoll = 2;
        public static int gameStatePlayer2CounterMove = 3;
        public int gameState;
        int turnCount;
        int countOneUpMovement;
        bool checkFourMove;
        public gameWindow(Form1 parent)
        {
            //48 is the initial pre-extra calcs incremement
            InitializeComponent();
            playerOneLabel.Text = "Player one (black):  " + parent.p1Name;
            playerTwoLabel.Text = "Player two (red):  " + parent.p2Name;
            p1Name = parent.p1Name;
            p2Name = parent.p2Name;
            p1Count1.Location = new Point(p1Count1.Left, p1Count1.Top - counterIncrement);
            die = new diceDialog(this);
            die.Show();
            gameState = gameStatePlayer1DieRoll;
            p1Count2.Location = new Point(p1Count2.Left, p1Count2.Top - counterIncrement);
            p2Count1.Location = new Point(p2Count1.Left, p2Count1.Top - counterIncrement);
            p2Count2.Location = new Point(p2Count2.Left, p2Count2.Top - counterIncrement);
            turnCount = 1;
        }
        public void incrementGameState()
        {
            if (counterPositions[0] == 1 && counterPositions[1] == 1 && die.dieResult == 4 && turnCount == 1)
            {
                gameState = gameStatePlayer1DieRoll;
            }
            else if (counterPositions[2] == 1 && counterPositions[3] == 1 && die.dieResult == 4 && turnCount == 2)
            {
                gameState = gameStatePlayer2DieRoll;
            }
            else if (counterPositions[0] == 1 && counterPositions[1] == 1 && die.dieResult == 4 && turnCount > 1)
            {
                MessageBox.Show(p1Name + " cannot make a move, transferring move to " + p2Name);
                gameState = gameStatePlayer2DieRoll;
            }
            else if (counterPositions[2] == 1 && counterPositions[3] == 1 && die.dieResult == 4 && turnCount > 2)
            {
                MessageBox.Show(p2Name + " cannot make a move, transferring move to " + p1Name);
                gameState = gameStatePlayer1DieRoll;
            }
            else
            {                
                gameState = (gameState + 1) % 4;
                //Debug.WriteLine(gameState);
               // Debug.WriteLine(counterPositions[0]);
                //Debug.WriteLine(counterPositions[1]);
                //Debug.WriteLine(counterPositions[2]);
                //Debug.WriteLine(counterPositions[3]);
            }
            if (counterPositions[0] == 11 && counterPositions[1] == 11)
            {
                MessageBox.Show(p1Name + " Wins!");
                die.Close();
                this.Close();
            }
            if (counterPositions[2] == 11 && counterPositions[3] == 11)
            {
                MessageBox.Show(p2Name + " Wins!");
                die.Close();
                this.Close();
            }
        }
        public void checkFour()
        {
            if (counterPositions[0] == 1 && counterPositions[1] == 1 && die.dieResult == 4 && turnCount == 1)
            {
                gameState = gameStatePlayer1DieRoll;
                checkFourMove = false;
            }
            else if (counterPositions[2] == 1 && counterPositions[3] == 1 && die.dieResult == 4 && turnCount == 2)
            {
                gameState = gameStatePlayer2DieRoll;
                checkFourMove = false;
            }
            else if (counterPositions[0] == 1 && counterPositions[1] == 1 && die.dieResult == 4 && turnCount > 1)
            {
                MessageBox.Show(p1Name + " cannot make a move, transferring move to " + p2Name);
                gameState = gameStatePlayer2DieRoll;
                checkFourMove = false;
            }
            else if (counterPositions[2] == 1 && counterPositions[3] == 1 && die.dieResult == 4 && turnCount > 2)
            {
                MessageBox.Show(p2Name + " cannot make a move, transferring move to " + p1Name);
                gameState = gameStatePlayer1DieRoll;
                checkFourMove = false;
            }
            else
            {
                checkFourMove = true;
            }
        }
        private void p1Count1_Click(object sender, EventArgs e)
        {
            if (gameState == gameStatePlayer1CounterMove)
            {
                if (die.dieResult >= 1 && die.dieResult <= 3 && counterPositions[0] + die.dieResult  <= 11 && counterPositions[0] < 11)
                {
                    if ((counterPositions[0] + die.dieResult) == counterPositions[1] && counterPositions[1] != 1 && counterPositions[1] != 5 && counterPositions[1] != 11)
                    {
                        MessageBox.Show(p1Name + " you cannot make this move, please move your other counter");
                        gameState = gameStatePlayer1CounterMove;
                    }
                    else
                    {
                        int upMovement = die.dieResult * counterIncrement;
                        p1Count1.Location = new Point(p1Count1.Left, p1Count1.Top - upMovement);
                        counterPositions[0] += die.dieResult;
                        incrementGameState();
                    }

                }
                else if (die.dieResult != 4 && counterPositions[0] + die.dieResult > 11 && die.dieResult != 5)
                {
                    p1Count1.Location = new Point(p1Count1.Left, p1Count1.Top - (11 - counterPositions[0]) * counterIncrement);
                    counterPositions[0] = 11;
                    incrementGameState();
                }
                if ((die.dieResult == 4 && counterPositions[0] > 1 && counterPositions[1] != (counterPositions[0] - 1) && counterPositions[1] != 1 && counterPositions[1] != 5 && counterPositions[1] != 11) || (die.dieResult == 4 && counterPositions[0] > 1 && (counterPositions[1] == 1 || counterPositions[1] == 5 || counterPositions[1] == 11)))
                {
                    checkFour();
                    if (checkFourMove == true)
                    {
                    p1Count1.Location = new Point(p1Count1.Left, p1Count1.Top + counterIncrement);
                    counterPositions[0]--;
                    incrementGameState();
                    }
                }
                else if (die.dieResult == 4 && counterPositions[1] == (counterPositions[0] - 1) && counterPositions[1] != 1 && counterPositions[1] != 5 && counterPositions[1] != 11)
                {
                    MessageBox.Show(p1Name + " you cannot make this move, please move your other counter");
                    gameState = gameStatePlayer1CounterMove;
                }
                if (die.dieResult == 5)
                {
                    for (int i = counterPositions[0] + 1; i <= 11; i++)
                    {
                        if (counterPositions[1] != i && counterPositions[2] != i && counterPositions[3] != i)
                        {
                            countOneUpMovement = (i - counterPositions[0]) * counterIncrement;
                            Debug.WriteLine(i);
                            Debug.WriteLine(counterPositions[0]);
                            Debug.WriteLine(countOneUpMovement); 
                            p1Count1.Location = new Point(p1Count1.Left, p1Count1.Top - countOneUpMovement);
                            counterPositions[0] = i;
                            Debug.WriteLine(counterPositions[0]);
                            incrementGameState();
                            break;
                        }
                    }
                }
                //the value isnt set right here because debug
                turnCount++;
                if (counterPositions[0] == 1 || counterPositions[0] == 5 || counterPositions[0] == 11)
                {
                    p1Count1.BackColor = Color.Lime;
                }
                else
                {
                    p1Count1.BackColor = Color.White;
                }
                if (counterPositions[0] == counterPositions[2] && counterPositions[0] != 1 && counterPositions[0] != 5 && counterPositions[0] != 11)
                {
                    p2Count1.Location = new Point(p2Count1.Left, p2Count1.Top + (counterPositions[2] - 1) * counterIncrement);
                    counterPositions[2] = 1;
                    p2Count1.BackColor = Color.Lime;
                }
                if (counterPositions[0] == counterPositions[3] && counterPositions[0] != 1 && counterPositions[0] != 5 && counterPositions[0] != 11)
                {
                    p2Count2.Location = new Point(p2Count2.Left, p2Count2.Top + (counterPositions[3] - 1) * counterIncrement);
                    counterPositions[3] = 1;
                    p2Count2.BackColor = Color.Lime;
                }
            }
        }


        private void p1Count2_Click(object sender, EventArgs e)
        {
            if (gameState == gameStatePlayer1CounterMove)
            {
                if (die.dieResult >= 1 && die.dieResult <= 3 && counterPositions[1] + die.dieResult <= 11 && counterPositions[1] < 11)
                {
                    if ((counterPositions[1] + die.dieResult) == counterPositions[0] && counterPositions[0] != 1 && counterPositions[0] != 5 && counterPositions[0] != 11)
                    {
                        MessageBox.Show(p1Name + " you cannot make this move, please move your other counter");
                        gameState = gameStatePlayer1CounterMove;
                    }
                    else
                    {
                        int upMovement = die.dieResult * counterIncrement;
                        p1Count2.Location = new Point(p1Count2.Left, p1Count2.Top - upMovement);
                        counterPositions[1] += die.dieResult;
                        incrementGameState();
                    }
                }
                else if (die.dieResult != 4 && counterPositions[1] + die.dieResult > 11 && die.dieResult != 5)
                {
                    p1Count2.Location = new Point(p1Count2.Left, p1Count2.Top - (11 - counterPositions[1]) * counterIncrement);
                    counterPositions[1] = 11;
                    incrementGameState();
                }
                if ((die.dieResult == 4 && counterPositions[1] > 1 && counterPositions[0] != (counterPositions[1] - 1) && counterPositions[0] != 1 && counterPositions[0] != 5 && counterPositions[0] != 11) || (die.dieResult == 4 && counterPositions[1] > 1 && (counterPositions[0] == 1 || counterPositions[0] == 5 || counterPositions[0] == 11)))
                {
                    checkFour();
                    if (checkFourMove == true)
                    {
                        p1Count2.Location = new Point(p1Count2.Left, p1Count2.Top + counterIncrement);
                        counterPositions[1]--;
                        incrementGameState();
                    }
                }
                else if (die.dieResult == 4 && counterPositions[0] == (counterPositions[1] - 1) && counterPositions[0] != 1 && counterPositions[0] != 5 && counterPositions[0] != 11)
                {
                    MessageBox.Show(p1Name + " you cannot make this move, please move your other counter");
                    gameState = gameStatePlayer1CounterMove;
                }
                if (die.dieResult == 5)
                {
                    for (int i = counterPositions[1] + 1; i <= 11; i++)
                    {
                        if (counterPositions[0] != i && counterPositions[2] != i && counterPositions[3] != i)
                        {
                            countOneUpMovement = (i - counterPositions[1]) * counterIncrement;
                            Debug.WriteLine(i);
                            Debug.WriteLine(counterPositions[1]);
                            Debug.WriteLine(countOneUpMovement); 
                            p1Count2.Location = new Point(p1Count2.Left, p1Count2.Top - countOneUpMovement);
                            counterPositions[1] = i;
                            Debug.WriteLine(counterPositions[1]);
                            incrementGameState();
                            break;
                        }
                    }
                }
                //the value isnt set right here because debug
                turnCount++;
                if (counterPositions[1] == 1 || counterPositions[1] == 5 || counterPositions[1] == 11)
                {
                    p1Count2.BackColor = Color.Lime;
                }
                else
                {
                    p1Count2.BackColor = Color.White;
                }
                if (counterPositions[1] == counterPositions[2] && counterPositions[1] != 1 && counterPositions[1] != 5 && counterPositions[1] != 11)
                {
                    p2Count1.Location = new Point(p2Count1.Left, p2Count1.Top + (counterPositions[2] - 1) * counterIncrement);
                    counterPositions[2] = 1;
                    p2Count1.BackColor = Color.Lime;
                }
                if (counterPositions[1] == counterPositions[3] && counterPositions[1] != 1 && counterPositions[1] != 5 && counterPositions[1] != 11)
                {
                    p2Count2.Location = new Point(p2Count2.Left, p2Count2.Top + (counterPositions[3] - 1) * counterIncrement);
                    counterPositions[3] = 1;
                    p2Count2.BackColor = Color.Lime;
                }
                }
        }

        private void p2Count1_Click(object sender, EventArgs e)
        {
            if (gameState == gameStatePlayer2CounterMove)
            {
                if (die.dieResult >= 1 && die.dieResult <= 3 && counterPositions[2] + die.dieResult <= 11 && counterPositions[2] < 11)
                {
                    if ((counterPositions[2] + die.dieResult) == counterPositions[3] && counterPositions[3] != 1 && counterPositions[3] != 5 && counterPositions[3] != 11)
                    {
                        MessageBox.Show(p2Name + " you cannot make this move, please move your other counter");
                        gameState = gameStatePlayer2CounterMove;
                    }
                    else
                    {
                        int upMovement = die.dieResult * counterIncrement;
                        p2Count1.Location = new Point(p2Count1.Left, p2Count1.Top - upMovement);
                        counterPositions[2] += die.dieResult;
                        incrementGameState();
                    }
                }
                else if (die.dieResult != 4 && counterPositions[2] + die.dieResult > 11 && die.dieResult != 5)
                {
                    p2Count1.Location = new Point(p2Count1.Left, p2Count1.Top - (11 - counterPositions[2]) * counterIncrement);
                    counterPositions[2] = 11;
                    incrementGameState();
                }
                if ((die.dieResult == 4 && counterPositions[3] > 1 && counterPositions[3] != (counterPositions[2] - 1) && counterPositions[3] != 1 && counterPositions[3] != 5 && counterPositions[3] != 11) || (die.dieResult == 4 && counterPositions[2] > 1 && (counterPositions[3] == 1 || counterPositions[3] == 5 || counterPositions[3] == 11)))
                {
                    checkFour();
                    if (checkFourMove == true)
                    {
                        p2Count1.Location = new Point(p2Count1.Left, p2Count1.Top + counterIncrement);
                        counterPositions[2]--;
                        incrementGameState();
                    }
                }
                else if (die.dieResult == 4 && counterPositions[3] == (counterPositions[2] - 1) && counterPositions[3] != 1 && counterPositions[3] != 5 && counterPositions[3] != 11)
                {
                    MessageBox.Show(p1Name + " you cannot make this move, please move your other counter");
                    gameState = gameStatePlayer1CounterMove;
                }
                if (die.dieResult == 5)
                {
                    for (int i = counterPositions[2] + 1; i <= 11; i++)
                    {
                        if (counterPositions[1] != i && counterPositions[0] != i && counterPositions[3] != i)
                        {
                            countOneUpMovement = (i - counterPositions[2]) * counterIncrement;
                            Debug.WriteLine(i);
                            Debug.WriteLine(counterPositions[2]);
                            Debug.WriteLine(countOneUpMovement); 
                            p2Count1.Location = new Point(p2Count1.Left, p2Count1.Top - countOneUpMovement);
                            counterPositions[2] = i;
                            Debug.WriteLine(counterPositions[2]);
                            incrementGameState();
                            break;
                        }
                    }
                }
                turnCount++;
                if (counterPositions[2] == 1 || counterPositions[2] == 5 || counterPositions[2] == 11)
                {
                    p2Count1.BackColor = Color.Lime;
                }
                else
                {
                    p2Count1.BackColor = Color.White;
                }
                if (counterPositions[0] == counterPositions[2] && counterPositions[0] != 1 && counterPositions[0] != 5 && counterPositions[0] != 11)
                {
                    p1Count1.Location = new Point(p1Count1.Left, p1Count1.Top + (counterPositions[0] - 1) * counterIncrement);
                    counterPositions[0] = 1;
                    p1Count1.BackColor = Color.Lime;
                }
                if (counterPositions[1] == counterPositions[2] && counterPositions[1] != 1 && counterPositions[1] != 5 && counterPositions[1] != 11)
                {
                    p1Count2.Location = new Point(p1Count2.Left, p1Count2.Top + (counterPositions[1] - 1) * counterIncrement);
                    counterPositions[1] = 1;
                    p1Count2.BackColor = Color.Lime;
                }
            }
        }

        private void p2Count2_Click(object sender, EventArgs e)
        {
            if (gameState == gameStatePlayer2CounterMove)
            {
                if (die.dieResult >= 1 && die.dieResult <= 3 && counterPositions[3] + die.dieResult <= 11 && counterPositions[3] < 11)
                {
                    if ((counterPositions[3] + die.dieResult) == counterPositions[2] && counterPositions[2] != 1 && counterPositions[2] != 5 && counterPositions[2] != 11)
                    {
                        MessageBox.Show(p2Name + " you cannot make this move, please move your other counter");
                        gameState = gameStatePlayer2CounterMove;
                    }
                    else
                    {
                        int upMovement = die.dieResult * counterIncrement;
                        p2Count2.Location = new Point(p2Count2.Left, p2Count2.Top - upMovement);
                        counterPositions[3] += die.dieResult;
                        incrementGameState();
                    }
                }
                else if (die.dieResult != 4 && counterPositions[3] + die.dieResult > 11 && die.dieResult != 5)
                {
                    p2Count2.Location = new Point(p2Count2.Left, p2Count2.Top - (11 - counterPositions[3]) * counterIncrement);
                    counterPositions[3] = 11;
                    incrementGameState();
                }
                if ((die.dieResult == 4 && counterPositions[3] > 1 && counterPositions[2] != (counterPositions[3] - 1) && counterPositions[2] != 1 && counterPositions[2] != 5 && counterPositions[2] != 11) || (die.dieResult == 4 && counterPositions[3] > 1 && (counterPositions[2] == 1 || counterPositions[2] == 5 || counterPositions[2] == 11)))
                {
                    checkFour();
                    if (checkFourMove == true)
                    {
                        p2Count2.Location = new Point(p2Count2.Left, p2Count2.Top + counterIncrement);
                        counterPositions[3]--;
                        incrementGameState();
                    }
                }

                else if (die.dieResult == 4 && counterPositions[0] == (counterPositions[1] - 1) && counterPositions[0] != 1 && counterPositions[0] != 5 && counterPositions[0] != 11)
                {
                    MessageBox.Show(p1Name + " you cannot make this move, please move your other counter");
                    gameState = gameStatePlayer1CounterMove;
                }
                if (die.dieResult == 5)
                {
                    for (int i = counterPositions[3] + 1; i <= 11; i++)
                    {
                        if (counterPositions[1] != i && counterPositions[2] != i && counterPositions[0] != i)
                        {
                            countOneUpMovement = (i - counterPositions[3]) * counterIncrement;
                            Debug.WriteLine(i);
                            Debug.WriteLine(counterPositions[3]);
                            Debug.WriteLine(countOneUpMovement); 
                            p2Count2.Location = new Point(p2Count2.Left, p2Count2.Top - countOneUpMovement);
                            counterPositions[3] = i;
                            Debug.WriteLine(counterPositions[3]);
                            incrementGameState();
                            break;
                        }
                    }
                }
                //the value isnt set right here because debug
                turnCount++;
                if (counterPositions[3] == 1 || counterPositions[3] == 5 || counterPositions[3] == 11)
                {
                    p2Count2.BackColor = Color.Lime;
                }
                else
                {
                    p2Count2.BackColor = Color.White;
                }
                if (counterPositions[0] == counterPositions[3] && counterPositions[0] != 1 && counterPositions[0] != 5 && counterPositions[0] != 11)
                {
                    p1Count1.Location = new Point(p1Count1.Left, p1Count1.Top + (counterPositions[0] - 1) * counterIncrement);
                    counterPositions[0] = 1;
                    p1Count1.BackColor = Color.Lime;
                }
                if (counterPositions[1] == counterPositions[3] && counterPositions[1] != 1 && counterPositions[1] != 5 && counterPositions[1] != 11)
                {
                    p1Count2.Location = new Point(p1Count2.Left, p1Count2.Top + (counterPositions[1] - 1) * counterIncrement);
                    counterPositions[1] = 1;
                    p1Count2.BackColor = Color.Lime;
                }
            }
        }

    }
}