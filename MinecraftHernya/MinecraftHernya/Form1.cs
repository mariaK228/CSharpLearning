using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinecraftHernya
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            double x, y, z;
            try
            {
                x = Convert.ToDouble(owX.Text);
                y = Convert.ToDouble(owY.Text);
                z = Convert.ToDouble(owX.Text);
            }

            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            double mult = Convert.ToDouble(multiply.Text);
            double hX = x / mult;
            double hY = y / mult;
            double hZ = z / mult;

            hellX.Text = hX.ToString();
            hellY.Text = hY.ToString();
            hellZ.Text = hZ.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double x, y, z;
            try
            {
                x = Convert.ToDouble(hellX.Text);
                y = Convert.ToDouble(hellY.Text);
                z = Convert.ToDouble(hellZ.Text);
            }

            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            double mult = Convert.ToDouble(multiply.Text);
            double oX = x * mult;
            double oY = y * mult;
            double oZ = z * mult;

            owX.Text = oX.ToString();
            owY.Text = oY.ToString();
            owZ.Text = oZ.ToString();
        }
    }
}
