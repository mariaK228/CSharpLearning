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
        const int empty = 0;
        const int cross = 1;
        const int naught = 2;

        int victoryLength = 3;
        Image crossImg = Resources.cross;
        Image naughtImg = Resources.naught;
        PictureBox[] pictureBoxes;
        int[,] matrix = new int[3, 3];
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

        private void ConvertToMatrix(int index, out int x, out int y)
        {
            y = index / matrix.GetLength(0);
            x = index - y * matrix.GetLength(0);    
        }

        private void GamePlay(object sender, EventArgs e)
        {
            int index = GetIndex((PictureBox)sender);
            int x, y;
            bool victory = false;
            ConvertToMatrix(index, out x, out y);

            if (previousPlayer == cross)
            {
                previousPlayer = naught;
                ChangeImg(previousPlayer, index);
                matrix[x, y] = previousPlayer;
                victory = CheckVictory(x,y);

            }

            else if (previousPlayer == naught)
            {
                previousPlayer = cross;
                ChangeImg(previousPlayer, index);
                matrix[x, y] = previousPlayer;
                victory = CheckVictory(x, y);
            }

            else
            {
                previousPlayer = cross;
              //  GamePlay(sender, e);
                ChangeImg(previousPlayer, index);
                matrix[x, y] = previousPlayer;
            }

            if (victory == true)
            MessageBox.Show("Победил игрок с номером " + previousPlayer);
           
        }

        private void ChangeImg (int player, int index)
        {
            if (player == naught)
            {
                pictureBoxes[index].Image = naughtImg;
            }

            else if (player == cross)
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

        private bool CheckVictory(int x, int y)
        {
            int verticalCount = 0;
            int horizontalCount = 0;
            int leftDiagonalCount = 0;
            int rightDiagonalCount = 0;
            for(int i = y; i >= 0; i--)
            {
                if (matrix[x, i] == previousPlayer)
                {
                    verticalCount++;
                }
                else
                    break;
            }

            for (int i = y+1; i < matrix.GetLength(1); i++)
            {
                if (matrix[x, i] == previousPlayer)
                {
                    verticalCount++;
                }
                else
                    break;
            }

            for (int i = x; i >= 0; i--)
            {
                if (matrix[i, y] == previousPlayer)
                {
                    horizontalCount++;
                }
                else
                    break;
            }

            for (int i = x+1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, y] == previousPlayer)
                {
                    horizontalCount++;
                }
                else
                    break;
            }

            for (int i = x, j = y; i >=0 && j >= 0; i--, j--)
            {
                if (matrix[i, j] == previousPlayer)
                {
                    rightDiagonalCount++;
                }
                else
                    break;
            }

            for (int i = x+1, j = y+1; i < matrix.GetLength(0) && j < matrix.GetLength(1); i++, j++)
            {
                if (matrix[i, j] == previousPlayer)
                {
                    rightDiagonalCount++;
                }
                else
                    break;
            }

            for (int i = x, j = y; i >= 0 && j < matrix.GetLength(1); i--, j++)
            {
                if (matrix[i, j] == previousPlayer)
                {
                    leftDiagonalCount++;
                }
                else
                    break;
            }

            for (int i = x+1, j = y-1; i < matrix.GetLength(0) && j >= 0; i++, j--)
            {
                if (matrix[i, j] == previousPlayer)
                {
                    leftDiagonalCount++;
                }
                else
                    break;
            }

            return verticalCount >= victoryLength || horizontalCount >= victoryLength || rightDiagonalCount >= victoryLength || leftDiagonalCount >= victoryLength;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            


        }
    }
}
