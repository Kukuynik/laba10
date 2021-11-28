using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba10
{
    public partial class Form1 : Form
    {
        BankAccount account1 = new BankAccount(3000, TypeOfAccount.DEBIT);
        BankAccount account2 = new BankAccount(1400, TypeOfAccount.DEBIT);
        List<BankAccount> listAccoutnt = new List<BankAccount>();
        
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add(account1.accountNumber);
            comboBox1.Items.Add(account2.accountNumber);
            comboBox2.Items.Add(account1.accountNumber);
            comboBox2.Items.Add(account2.accountNumber);
            listAccoutnt.Add(account1);
            listAccoutnt.Add(account2);
            richTextBox1.Text = File.ReadAllText("Ex5.txt");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == account1.accountNumber-1)
            {
                textBox2.Text = Convert.ToString(account1.accountType);
                textBox3.Text = Convert.ToString(account1.accountBalance);
            }
            else if(comboBox1.SelectedIndex == account2.accountNumber-1)
            {
                textBox2.Text = Convert.ToString(account2.accountType);
                textBox3.Text = Convert.ToString(account2.accountBalance);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == account1.accountNumber-1)
            {                
                textBox1.Text = Convert.ToString(account1.accountBalance);
            }
            else if (comboBox2.SelectedIndex == account2.accountNumber-1)
            {
                textBox1.Text = Convert.ToString(account2.accountBalance);
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != comboBox2.SelectedIndex)
            {
                switch (comboBox1.Text)
                {
                    case "1":
                        account2.TransferMoney(ref account1, Convert.ToInt32(textBox4.Text));
                        textBox3.Text = Convert.ToString(account1.accountBalance);
                        textBox1.Text = Convert.ToString(account2.accountBalance);
                        break;
                    case "2":
                        account1.TransferMoney(ref account2, Convert.ToInt32(textBox4.Text));
                        textBox3.Text = Convert.ToString(account2.accountBalance);
                        textBox1.Text = Convert.ToString(account1.accountBalance);
                        break;
                }
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 127)
            {
                e.Handled = true;
            }
        }

        // zadanie 2 
        static string Reverse(string str)
        {
            char[] reverse = str.ToCharArray();
            Array.Reverse(reverse);
            return new string(reverse);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox5.Text = Reverse(textBox5.Text);
        }
        // zadanie 4

        const string outputFileName = "ResultFile.txt";

        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox6.Text))
            {
                File.WriteAllText(outputFileName, File.ReadAllText(textBox6.Text, Encoding.UTF8).ToUpper());
                MessageBox.Show("Результат успешно записан в файл");
            }
            else
            {
                MessageBox.Show($"Файл с именем \"{textBox6.Text}\" не найден!");
            }
        }
        // zadanie 5
        public void SearchMail(ref string s)
        {
            string[] email = s.Split(new char[] { '#' });
            s = email[1];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (File.Exists("ResultEx5.txt"))
            {
                File.Delete("ResultEx5.txt");
            }
            richTextBox2.Clear();
            List<string> filestring = new List<string>();
            filestring = File.ReadAllLines("Ex5.txt").ToList();
            for (int count = 0; count < filestring.Count; count++)
            {
                string s = filestring[count];
                SearchMail(ref s);
                richTextBox2.Text += s+'\r';
            }
            File.WriteAllText("ResultEx5.txt", richTextBox2.Text);
        }
        
        private void button5_Click(object sender, EventArgs e)
        {

        }
        // zadanie 6
        private void AllSongs()
        {
            Song[] songs = new Song[5];
            string[] authors = new string[5] { "Sabaton", "Powerwolf", "Мельница", "Gloryhummer", "Любэ" };
            string[] names = new string[5] { "Panzerkampf", "We drink your blood", "Рукописи", "Gloryhummer", "Атас" };
            songs[0] = new Song();
            songs[0].songAuthor = authors[0];
            songs[0].songName = names[0];
            richTextBox3.Text = $"{songs[0].Title()}\n";
            for (int songId = 1; songId < songs.Length; songId++)
            {
                songs[songId] = new Song();
                songs[songId].songAuthor = authors[songId];
                songs[songId].songName = authors[songId];
                songs[songId].setPrev(songs[songId - 1]);
                richTextBox3.Text += $"{songs[songId].Title()}\n";
            }
            songs[0].setPrev(songs[songs.Length - 1]);
            richTextBox4.Text = $"{songs[0].Title()} == {songs[1].Title()} ? : {songs[0].Equals(songs[1])}";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AllSongs();
        }

        // zadanie 4

    }
}
