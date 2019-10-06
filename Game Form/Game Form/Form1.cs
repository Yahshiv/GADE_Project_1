using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Form
{
    public partial class formGameForm : Form
    {
        public formGameForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Map.Randomize(int.Parse(tbNumUnits.Text));
            lblMap = Map.DrawMap(lblMap);

            while(Map.remUnits > 1)
            {
                tbUnitInfo = Map.SimulateRound(tbUnitInfo);
                lblMap = Map.DrawMap(lblMap);
                lblRound.Text = "Round: " + Map.round;
                System.Threading.Thread.Sleep(1000);
            }
            Map.DrawMap(lblMap);
        }
    }
}
