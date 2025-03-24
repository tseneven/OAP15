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

namespace prakt15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Predmet predmet = new Predmet();

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void найтиСловоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            predmet.words = textBox1.Text;

            string fileName = "txt.txt";

            string fileContent = File.ReadAllText(fileName);

            string[] lines = fileContent.Split(new[] {"\r\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

            foreach(string line in lines) 
            {
                int lastSpace = line.LastIndexOf(' ');
                if (lastSpace == -1) continue;

                string text = line.Substring(0, lastSpace);
                string pageStr = line.Substring(lastSpace + 1);


            }

        }
    }
}
