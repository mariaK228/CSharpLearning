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

            double hX = x / 7;
            double hY = y / 7;
            double hZ = z / 7;

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
                z = Convert.ToDouble(hellX.Text);
            }

            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            double oX = x * 7;
            double oY = y * 7;
            double oZ = z * 7;

            owX.Text = oX.ToString();
            owY.Text = oY.ToString();
            owZ.Text = oZ.ToString();
        }
    }
}
