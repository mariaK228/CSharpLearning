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

namespace Soosliqi
{
    public partial class RecordSaver : Form
    {
        const char separator = '|';
        int newScore;
        List<string> playerList;
        private const string saveRecordFile = "save.txt"; 
        

        public RecordSaver(int score)
        {
            InitializeComponent();

            newScore = score; 
        }

        private void RecordSaver_Load(object sender, EventArgs e)
        {
            playerList = new List<string>();
            string[] lines;
            
            if (File.Exists(saveRecordFile))
            {
                lines = File.ReadAllLines(saveRecordFile);
                playerList.AddRange(lines);

                Sort();
                Print();
            }
        }

        class PlayerListComporator : IComparer<string>
        {
            public int Compare (string a, string b)
            {
                string[] partsA = a.Split(separator);
                string[] partsB = b.Split(separator);

                int scoreA = Int32.Parse(partsA[1]);
                int scoreB = Int32.Parse(partsB[1]);

                if (scoreA > scoreB)
                    return 1;

                else if (scoreA < scoreB)
                    return -1;

                else
                    return 0; 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string playerName = gamerName.Text;

            int index = IndexOf(playerName);

            if (index == -1)
            {
                playerList.Add(playerName + separator + newScore);
            }

            else
            {
                ReplaceScore(index);
            }

            Sort();
            Print();
            SaveFile();
            button1.Enabled = false; 
        }

        private void ReplaceScore(int index)
        {
            string[] parts = playerList[index].Split(separator);
            if (Int32.Parse(parts[1]) < newScore)
            {
                parts[1] = newScore.ToString();

                playerList[index] = parts[0] + separator + parts[1];
            }
        }

        private int IndexOf(string name)
        {
            for (int i = 0; i < playerList.Count; i++)
            {
                string[] parts = playerList[i].Split(separator);
                if (parts[0] == name)
                    return i; 
            }
            return -1; 
        }

        private void Print ()
        {
            top10.Clear();
            foreach (string player in playerList)
            {
                top10.Text += player.Replace(separator.ToString(), " - ") + '\n';
            }
        }

        private void Sort()
        {
            playerList.Sort(new PlayerListComporator());
            playerList.Reverse();
        }

        private void SaveFile()
        {
            File.WriteAllLines(saveRecordFile, playerList);
        }
    }
}
