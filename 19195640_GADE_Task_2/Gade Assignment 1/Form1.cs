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

            BinaryFormatter BF = new BinaryFormatter();
            FileStream FS = new FileStream("MapInfo.dat", FileMode.Open, FileAccess.Read, FileShare.None);

            try
            {
                using (FS)
                {
                    BF.Serialize(FS, map);
                    gameengine.Updateunit();
                    gameengine.Updatebuilding();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //StreamWriter savestream;
            //savestream = File.CreateText("c:AllBattlInfo.txt");
            //savestream.WriteLine(textDisplayBox.Text = gameengine.Updateunit());
            //savestream.Close();
            //Console.WriteLine("Created File!");

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            //String line;
            //try
            //{
            //    StreamReader sr = new StreamReader("C:AllBattleInfo.txt");   
                
            //    //reading first line
            //    line = sr.ReadLine();

            //    //continuing reading until end of file
            //    while (line != null)
            //    {
            //        textDisplayBox.Text=line;
            //        //Readng following line until there are no more lines to read
            //        line = sr.ReadLine();
            //    }

            //    //close the file
            //    sr.Close();

            //}
            //catch (Exception E)
            //{
            //    textDisplayBox.Text = (E.Message);
            //}
        }

        private void MapTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
