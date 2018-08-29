using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Soosliqi.Properties;

namespace Soosliqi
{
    public partial class MainForm : Form
    {
        // Array of pictureBoxes representing clickable holes
        PictureBox[] holes = new PictureBox[16];

        // Instance of Randomizer
        Random rnd = new Random();

        // Image of soosliq looking out of the hole
        private Image soosliqImage = Resources.soosel;
        
        // Empty image of a hole
        private Image noraImage = Resources.nora_soosliqa;

        public MainForm()
        {
            InitializeComponent();

            holes[0] = pictureBox1;
            holes[1] = pictureBox2;
            holes[2] = pictureBox3;
            holes[3] = pictureBox4;
            holes[4] = pictureBox5;
            holes[5] = pictureBox6;
            holes[6] = pictureBox7;
            holes[7] = pictureBox8;
            holes[8] = pictureBox9;
            holes[9] = pictureBox10;
            holes[10] = pictureBox11;
            holes[11] = pictureBox12;
            holes[12] = pictureBox13;
            holes[13] = pictureBox14;
            holes[14] = pictureBox15;
            holes[15] = pictureBox16;
            
        }

        private int GetHoleIndex(PictureBox picBox)
        {
            for (int i = 0; i < holes.Length; i++)
            {
                if (holes[i] == picBox)
                {
                    return i;
                }
            }

            return -1;
        }
        

        private void startGame_Click(object sender, EventArgs e)
        {
            
        }

        // Catches click event
        private void ImageClick(object sender, EventArgs e)
        {
            int index = GetHoleIndex((PictureBox) sender);

            MessageBox.Show("Index: " + index);
        }

    }
}
