using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Gade_Assignment_1
{
    public partial class BattleForm : Form
    {
        public BattleForm()
        {
            InitializeComponent();
        }
        Map map = new Map(20,12);
        GameEngine gameengine = new GameEngine();

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DisplayBox_Enter(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MapTextBox.Text = gameengine.Updatedisplay();//updating map
            lblRound.Text = gameengine.RoundsCompleted.ToString();//changng round text
            textDisplayBox.Text = gameengine.Updateunit();//unit info
            textDisplayBox.Text = gameengine.Updatebuilding();//building info
            gameengine.startround();//calling start round method
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            gametimer.Enabled = true;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            gametimer.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            gameengine.Save();  
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            gameengine.Read();
        }

        private void MapTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
