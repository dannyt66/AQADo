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
    public partial class diceDialog : Form
    {
        Random spaces;
        string p1 { get; set; }
        string p2 { get; set; }
        public int dieResult;
        gameWindow gameW;
        public diceDialog(gameWindow parent)
        {
            InitializeComponent();
            gameW = parent;
            spaces = new Random();
            p1 = parent.p1Name;
            p2 = parent.p2Name;
            diceOutput.Text = "";
            resultLabel.Text = " Click Roll";
            youMay.Text = p1 + " may:";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(gameW.gameState);
            // Check whether a valid state for a die roll
            if (gameW.gameState == gameWindow.gameStatePlayer1DieRoll || gameW.gameState == gameWindow.gameStatePlayer2DieRoll)
            {
                dieResult = spaces.Next(5) + 1;
                diceOutput.Text = dieResult.ToString();
                switch (dieResult)
                {
                    case 1:
                        resultLabel.Text = "Move one piece one space forwards";
                        break;
                    case 2:
                        resultLabel.Text = "Move one piece two spaces forwards";
                        break;
                    case 3:
                        resultLabel.Text = "Move one piece three spaces forwards";
                        break;
                    case 4:
                        resultLabel.Text = "Move one piece one space backwards";
                        break;
                    case 5:
                        resultLabel.Text = "Select one piece and move it to the next available space";
                        break;
                }
                gameW.incrementGameState();
                switch (gameW.gameState)
                {
                    case 1:
                        youMay.Text = p1 + " may:";
                        break;
                    case 3:
                        youMay.Text = p2 + " may:";
                        break;
                }
                // gameW.blah();
        }

        }

    }
}
