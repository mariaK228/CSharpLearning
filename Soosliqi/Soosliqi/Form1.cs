using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soosliqi
{
    public partial class Form1 : Form
    {
        PictureBox[] holes = new PictureBox[16];
        public Form1()
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
        Random rnd = new Random();
        private void startGame_Click(object sender, EventArgs e)
        {
            int count = 0;
            timer1.Interval = 30000;
            timer1.Enabled = true;
            timer2.Interval = 3000;
            while (timer1.Enabled == true )
            {
                PictureBox pict = holes[rnd.Next(0, holes.Length)];
                pict.Image = System.Drawing.Image.FromFile("C:/Users/Мария/Desktop/Pawya_holesusl.png");
                timer2.Enabled = true;
                timer2.Start();

                
            }
            }
    }
}
