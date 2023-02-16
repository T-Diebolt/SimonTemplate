using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Xml.Schema;
using SimonSays.Properties;

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        int guess = 0;
        int guessCount = 0;
        SoundPlayer green = new SoundPlayer(Resources.green);
        SoundPlayer red = new SoundPlayer(Resources.red);
        SoundPlayer yellow = new SoundPlayer(Resources.yellow);
        SoundPlayer blue = new SoundPlayer(Resources.blue);
        SoundPlayer mistake = new SoundPlayer(Resources.mistake);
        Random randGen = new Random();

        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {

            Form1.pattern.Clear();
            guess = 0;
            guessCount = 0;
            Refresh();
            Thread.Sleep(1000);
            ComputerTurn();
        }

        private void ComputerTurn()
        {
            
            Form1.pattern.Add(randGen.Next(1, 5));
            
            for(int i = 0; i < Form1.pattern.Count(); i++)
            {
                Thread.Sleep(250);
                switch (Form1.pattern[i])
                {
                    case 1:
                        greenButton.BackColor = Color.Lime;
                        Refresh();
                        green.Play();
                        Thread.Sleep(250);
                        greenButton.BackColor = Color.DarkGreen;
                        Refresh();
                        break;
                    case 2:
                        redButton.BackColor = Color.Red;
                        Refresh();
                        red.Play();
                        Thread.Sleep(250);
                        redButton.BackColor = Color.DarkRed;
                        Refresh();
                        break;
                    case 3:
                        yellowButton.BackColor = Color.Gold;
                        Refresh();
                        yellow.Play();
                        Thread.Sleep(250);
                        yellowButton.BackColor = Color.Goldenrod;
                        Refresh();
                        break;
                    case 4:
                        blueButton.BackColor = Color.Blue;
                        Refresh();
                        blue.Play();
                        Thread.Sleep(250);
                        blueButton.BackColor = Color.MidnightBlue;
                        Refresh();
                        break;
                }
            }
            
            guess = 0;
            guessCount = 0;
        }

        //TODO: create one of these event methods for each button
        private void greenButton_Click(object sender, EventArgs e)
        {
            
            Guess(1);
            if(guessCount == Form1.pattern.Count)
            {
                ComputerTurn();
            }
            
            
        }

        private void Guess(int guess)
        {
            if(guess == Form1.pattern[guessCount])
            {
                switch (guess)
                {
                    case 1:
                        greenButton.BackColor = Color.Lime;
                        Refresh();
                        green.Play();
                        Thread.Sleep(250);
                        greenButton.BackColor = Color.DarkGreen;
                        Refresh();
                        break;
                    case 2:
                        redButton.BackColor = Color.Red;
                        Refresh();
                        red.Play();
                        Thread.Sleep(250);
                        redButton.BackColor = Color.DarkRed;
                        Refresh();
                        break;
                    case 3:
                        yellowButton.BackColor = Color.Gold;
                        Refresh();
                        yellow.Play();
                        Thread.Sleep(250);
                        yellowButton.BackColor = Color.Goldenrod;
                        Refresh();
                        break;
                    case 4:
                        blueButton.BackColor = Color.Blue;
                        Refresh();
                        blue.Play();
                        Thread.Sleep(250);
                        blueButton.BackColor = Color.MidnightBlue;
                        Refresh();
                        break;
                }
                guessCount++;
            }
            else
            {
                GameOver();
            }
            

        }

        public void GameOver()
        {
            
            mistake.Play();
            Thread.Sleep(500);
            Form1.gameScore = Form1.pattern.Count();
            
            Form1.ChangeScreen(this, new GameOverScreen());
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            Guess(2);
            if (guessCount == Form1.pattern.Count)
            {
                ComputerTurn();
            }
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            Guess(3);
            if (guessCount == Form1.pattern.Count)
            {
                ComputerTurn();
            }
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            Guess(4);
            if (guessCount == Form1.pattern.Count)
            {
                ComputerTurn();
            }
        }

        
    }
}
