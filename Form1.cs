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

namespace prakt15_rep
{
    public partial class Form1 : Form
    {
        public Dictionary<int, string> pages = new Dictionary<int, string>();
        StringBuilder currentText = new StringBuilder();
        int currentPage = 1;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader("txt.txt"))
            {
                string line;
                int tempPage = 1;
                while ((line = sr.ReadLine()) != null)
                {
                    if (int.TryParse(line, out int pageNumber))
                    {
                        if (currentText.Length > 0)
                        {
                            pages[tempPage] = currentText.ToString().Trim();
                            currentText.Clear();
                        }
                        tempPage = pageNumber;
                    }
                    else
                    {
                        currentText.AppendLine(line);
                    }
                }

                if (currentText.Length > 0)
                {
                    pages[tempPage] = currentText.ToString().Trim();
                }
            }

            if (pages.Count > 0)
            {
                currentPage = pages.Keys.Min();
                listBox1.Items.Clear();
                listBox1.Items.Add($"Страница {currentPage}:");
                listBox1.Items.AddRange(pages[currentPage].Split('\n'));
            }
            button1.Enabled = false;
            button2.Enabled = pages.ContainsKey(currentPage + 1);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pages.ContainsKey(currentPage - 1))
            {
                currentPage--;
                listBox1.Items.Clear();
                listBox1.Items.Add($"Страница {currentPage}:");
                listBox1.Items.AddRange(pages[currentPage].Split('\n'));
                button1.Enabled = pages.ContainsKey(currentPage - 1);
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pages.ContainsKey(currentPage + 1))
            {
                currentPage++;
                listBox1.Items.Clear();
                listBox1.Items.Add($"Страница {currentPage}:");
                listBox1.Items.AddRange(pages[currentPage].Split('\n'));

                button2.Enabled = pages.ContainsKey(currentPage + 1);
                button1.Enabled = true;
            }
        }

        private void найтиСловоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string word = textBox1.Text;
            if (word == null)
            {
                MessageBox.Show("Вы не ввели слово");
            }
            else
            {
                Predmet predmet = new Predmet(pages, word);
                string result = predmet.Search();
                MessageBox.Show(result);
            }
        }

    }
}
