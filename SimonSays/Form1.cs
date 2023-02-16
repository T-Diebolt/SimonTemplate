using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Drawing.Drawing2D;
using System.Xml.Schema;

namespace SimonSays
{
    public partial class Form1 : Form
    {
        
        public static List<int> pattern = new List<int>();
        public static int gameScore = 0;
        public static List<int> scores = new List<int>();
        

        public Form1()
        {
            InitializeComponent();
            scores.Add(0);
            scores.Add(0);
            scores.Add(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MenuScreen ms = new MenuScreen();

            ms.Location = new Point((this.Width - ms.Width) / 2, (this.Height - ms.Height) / 2);

            this.Controls.Add(ms);
            ms.Focus();
        }

        public static void ChangeScreen(object sender, UserControl next)
        {
            Form f; 

            if (sender is Form)
            {
                f = (Form)sender;
            }

            else
            {
                UserControl current = (UserControl)sender;
                f = current.FindForm();
                f.Controls.Remove(current);
            }

            next.Location = new Point((f.ClientSize.Width - next.Width) / 2,
                (f.ClientSize.Height - next.Height) / 2);

            f.Controls.Add(next);
            next.Focus();
        }
    }
}
