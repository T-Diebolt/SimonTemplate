using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimonSays
{
    public partial class GameOverScreen : UserControl
    {
        public GameOverScreen()
        {
            InitializeComponent();
        }

        private void GameOverScreen_Load(object sender, EventArgs e)
        {
            Form1.gameScore = Form1.pattern.Count() - 1;

            if (Form1.scores.Count() == 3)
            {
                if(Form1.gameScore != 0)
                {
                    Form1.scores.Insert(0, Form1.gameScore);
                    scoreboard.Text = $"First: >{Form1.scores[0]}<\nSecond: {Form1.scores[1]}" +
                            $"\nThird: {Form1.scores[2]}";
                }
                else
                {
                    Form1.scores.Add(0);
                    scoreboard.Text = $"First: {Form1.scores[0]}\nSecond: {Form1.scores[1]}" +
                        $"\nThird: {Form1.scores[2]}\n4: >{Form1.scores[3]}<";
                }
                
            }
            else
            {
                int i = 0;
                int ii = Form1.scores.Count();

                while(i < Form1.scores.Count() - 1 && ii == Form1.scores.Count())
                {
                    if (Form1.scores[i] < Form1.gameScore)
                    {
                        Form1.scores.Insert(i, Form1.gameScore);
                    }
                    else if (Form1.gameScore == 0)
                    {
                        Form1.scores.Add(Form1.gameScore);
                        i = Form1.scores.Count - 1;
                    }
                    else
                    {
                        i++;
                    }

                }
                
                switch(i)
                {
                    case 0:
                        scoreboard.Text = $"First: >{Form1.scores[0]}<\nSecond: {Form1.scores[1]}" +
                        $"\nThird: {Form1.scores[2]}";
                        break;
                    case 1:
                        scoreboard.Text = $"First: {Form1.scores[0]}\nSecond: >{Form1.scores[1]}<" +
                        $"\nThird: {Form1.scores[2]}";
                        break;
                    case 2:
                        scoreboard.Text = $"First: {Form1.scores[0]}\nSecond: {Form1.scores[1]}" +
                        $"\nThird: >{Form1.scores[2]}<";
                        break;
                    default:
                        scoreboard.Text = $"First: {Form1.scores[0]}\nSecond: {Form1.scores[1]}" +
                        $"\nThird: {Form1.scores[2]}\n{i}: >{Form1.scores[i]}<";
                        break;
                }

            }

            
            lengthLabel.Text = $"{Form1.pattern.Count() - 1}";

            Refresh();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            
            Form1.ChangeScreen(this, new MenuScreen());
        }

        private void scoreboardButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
