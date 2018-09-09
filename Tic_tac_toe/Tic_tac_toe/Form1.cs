﻿using System;
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
            string previousPlayer = "naught";

            if (previousPlayer == "naught")
            {
                previousPlayer = "cross";

                ChangeImg(previousPlayer, index);
            }

            else if (previousPlayer == "cross")
            {
                previousPlayer = "naught";

                ChangeImg(previousPlayer, index);
            }

            else
                MessageBox.Show("Error1");


        }

        private void ChangeImg (string player, int index)
        {
            if (player == "naught")
            {
                pictureBoxes[index].Image = naughtImg;
            }

            else if (player == "cross")
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
        private void button1_Click(object sender, EventArgs e)
        {
            


        }
    }
}