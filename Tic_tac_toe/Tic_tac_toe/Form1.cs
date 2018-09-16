using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_tac_toe.Properties;

namespace Tic_tac_toe
{
    public partial class Form1 : Form
    {

        Image crossImg = Resources.cross;
        Image naughtImg = Resources.naught;
        PictureBox[] pictureBoxes;
        int previousPlayer;
        public Form1()
        {
            InitializeComponent();

            DrawField();
        }

        private void DrawField()
        {
            SuspendLayout();


            pictureBoxes = new PictureBox[9];
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    PictureBox box = new PictureBox();
                    ((ISupportInitialize)box).BeginInit();
                    
                    
                    box.Location = new System.Drawing.Point(200 + i * 100, 30 + j * 100);
                    box.Name = "pictureBox" + i;
                    box.Size = new System.Drawing.Size(90, 90);
                    box.TabIndex = 13;
                    box.TabStop = false;
                    box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    box.SizeMode = PictureBoxSizeMode.StretchImage;
                    box.Click += new System.EventHandler(GamePlay);
                    this.Controls.Add(box);
                    
                    ((ISupportInitialize)box).EndInit();
                    pictureBoxes[count] = box;

                    count++;
                }
            }
        }

        private void GamePlay(object sender, EventArgs e)
        {
            int index = GetIndex((PictureBox)sender);
            bool checkVict;

            if (previousPlayer == 0)
            {
                previousPlayer = 1;

                ChangeImg(previousPlayer, index);
                CheckVictory();

            }

            else if (previousPlayer == 1)
            {
                previousPlayer = 0;

                ChangeImg(previousPlayer, index);
            }

            else
            {
                previousPlayer = 0;
                GamePlay(sender, e);
            }


        }

        private void ChangeImg (int player, int index)
        {
            if (player == 0)
            {
                pictureBoxes[index].Image = naughtImg;
            }

            else if (player == 1)
            {
                pictureBoxes[index].Image = crossImg;
            }

            else
                MessageBox.Show("Error");

        }

        private int GetIndex(PictureBox picBox)
        {
            for (int i = 0; i < pictureBoxes.Length; i++)
            {
                if (pictureBoxes[i] == picBox)
                {
                    return i;
                }
            }

            return -1;
        }

        private void CheckVictory()
        {
            if (pictureBoxes[0].Image == crossImg && pictureBoxes[1].Image == crossImg && pictureBoxes[2].Image == crossImg)
                MessageBox.Show("Победа");
            if (pictureBoxes[0].Image == naughtImg && pictureBoxes[1].Image == naughtImg && pictureBoxes[2].Image == naughtImg)
                MessageBox.Show("Победа");


            if (pictureBoxes[3].Image == crossImg && pictureBoxes[4].Image == crossImg && pictureBoxes[5].Image == crossImg)
                MessageBox.Show("Победа");
            if (pictureBoxes[3].Image == naughtImg && pictureBoxes[4].Image == naughtImg && pictureBoxes[5].Image == naughtImg)
                MessageBox.Show("Победа");


            if (pictureBoxes[6].Image == crossImg && pictureBoxes[7].Image == crossImg && pictureBoxes[8].Image == crossImg)
                MessageBox.Show("Победа");
            if (pictureBoxes[6].Image == naughtImg && pictureBoxes[7].Image == naughtImg && pictureBoxes[8].Image == naughtImg)
                MessageBox.Show("Победа");


            if (pictureBoxes[0].Image == crossImg && pictureBoxes[3].Image == crossImg && pictureBoxes[6].Image == crossImg)
                MessageBox.Show("Победа");
            if (pictureBoxes[0].Image == naughtImg && pictureBoxes[3].Image == naughtImg && pictureBoxes[6].Image == naughtImg)
                MessageBox.Show("Победа");


            if (pictureBoxes[1].Image == crossImg && pictureBoxes[4].Image == crossImg && pictureBoxes[7].Image == crossImg)
                MessageBox.Show("Победа");
            if (pictureBoxes[1].Image == naughtImg && pictureBoxes[4].Image == naughtImg && pictureBoxes[7].Image == naughtImg)
                MessageBox.Show("Победа");


            if (pictureBoxes[2].Image == crossImg && pictureBoxes[5].Image == crossImg && pictureBoxes[8].Image == crossImg)
                MessageBox.Show("Победа");
            if (pictureBoxes[2].Image == naughtImg && pictureBoxes[5].Image == naughtImg && pictureBoxes[8].Image == naughtImg)
                MessageBox.Show("Победа");


            if (pictureBoxes[0].Image == crossImg && pictureBoxes[4].Image == crossImg && pictureBoxes[8].Image == crossImg)
                MessageBox.Show("Победа");
            if (pictureBoxes[0].Image == naughtImg && pictureBoxes[4].Image == naughtImg && pictureBoxes[8].Image == naughtImg)
                MessageBox.Show("Победа");


            if (pictureBoxes[2].Image == crossImg && pictureBoxes[4].Image == crossImg && pictureBoxes[6].Image == crossImg)
                MessageBox.Show("Победа");

            if (pictureBoxes[2].Image == naughtImg && pictureBoxes[4].Image == naughtImg && pictureBoxes[6].Image == naughtImg)
                MessageBox.Show("Победа");


        }
        private void button1_Click(object sender, EventArgs e)
        {
            


        }
    }
}
