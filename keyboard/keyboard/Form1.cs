using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace keyboard
{
    public partial class Form1 : Form
    {
        char[] rusletters = new char[32];

        public Form1()
        {
            InitializeComponent();

            int count = 0;
            for (char i = 'а'; i <= 'я'; i++)
            {
                rusletters[count] = i;
                count++;
            }
        }

        Random rnd = new Random();

        private char getRandLetter()
        {           
            char letter = rusletters[rnd.Next(0, rusletters.Length)];

            return letter;
        }
        int lastTime;
        private void button1_Click(object sender, EventArgs e)
        {

            timer1.Interval = 5000;
            progressBar1.Value = 0;
            lastTime = 10000;
            yourText.Focus(); 
            startFunction();    
        }
       private void startFunction()
        {
            if (timer1.Interval > 1000)
            {
                timer1.Interval = lastTime - 1000;
                lastTime = timer1.Interval;
                timer1.Enabled = true;
                timer1.Stop();
                timer1.Start();
                yourText.Enabled = true;
                showAnyLetter.Text = getRandLetter().ToString();
            }
            else
            {
                yourText.Enabled = false;
                timer1.Enabled = false;
                MessageBox.Show("Капец ты мощный. Роботам не победить");
            }
            
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            MessageBox.Show("Ты проиграл");
            
            yourText.Enabled = false;
        }
        private void checkLetter ()
        {

            string savetext = yourText.Text;
            char lastletter = savetext[yourText.TextLength-1];
            string nowrow = showAnyLetter.Text;
            char nowLetter = nowrow[showAnyLetter.TextLength-1];


            if (lastletter != nowLetter && timer1.Enabled == true && progressBar1.Value < 3)
            { 
                progressBar1.Value++;
                if (timer1.Interval > 0)
                    startFunction();
               
            }
            else if (lastletter != nowLetter && timer1.Enabled == true && progressBar1.Value == 3)
            {
                 timer1.Enabled = false;
                MessageBox.Show("Ты проиграл");
                yourText.Enabled = false;
                
            }
            else 
            {
                if (timer1.Interval > 0)
                startFunction();
            }
        }

        private void yourText_TextChanged(object sender, EventArgs e)
        {            
                checkLetter();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showAnyLetter.Enabled = false;           
        }       
    }
}
