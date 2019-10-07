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

namespace Game_Form
{
    public partial class formGameForm : Form
    {
        Timer timer = new Timer();//timer to run gameLoop on set interval (frame rate)

        public formGameForm()
        {
            InitializeComponent();

            Repeat(1000);
        }

        private void btnStart_Click(object sender, EventArgs e)//Start Button
        {
            if(Map.round == 0)
            {
                Map.Randomize(int.Parse(tbNumUnits.Text));
                Map.DrawMap(lblMap);
            }
            
            timer.Enabled = true;
        }

        public void Repeat(int time)//repeatable interval
        {
            timer.Interval = time;
            timer.Tick += new EventHandler(Event);
        }

        public void Event(Object sender, System.EventArgs e)//repeatable method code
        {
            lblRound.Text = "Round: " + Map.round;
            Map.SimulateRound(tbUnitInfo);
            Map.DrawMap(lblMap);

            if(Map.timeToStop())
            {
                timer.Enabled = false;
            }

        }

        private void btnPause_Click(object sender, EventArgs e)//Pause Button
        {
            timer.Enabled = false;
        }
    }
}
