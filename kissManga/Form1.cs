using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace kissManga
{
    public partial class grabber : Form
    {
        public grabber()
        {
            InitializeComponent();
            names = new List<string>();
        }
        List<string> names;
        private void button1_Click(object sender, EventArgs e) //shitty code that works
        {
            string temp = "";
            string search = "";
            string output = "";
            if (radioButton1.Checked)
            {
                search = "kissanime.ru/Anime/";
                output = "anime.txt";
            }
            else
            {
                search = "kissmanga.com/Manga/";
                output = "manga.txt";
            }
            try
            {
                // var strLines = File.ReadLines(textBox1.Text);
                //foreach (var line in strLines)
                System.IO.StreamReader file = new StreamReader(textBox1.Text);
                while ((temp = file.ReadLine()) != null)
                {
                    {
                        //temp = line;
                        int index = temp.IndexOf(search);
                        if (index > -1)
                        {
                            temp = temp.Substring(index, temp.Length - index);
                            string[] arr = temp.Split('/', ',', '?','"');
                            arr[2] = arr[2].Replace('-', ' ');
                            if (!names.Contains(arr[2]))
                                names.Add(arr[2]);

                        }

                    }
                }
                    names.Sort();
                    TextWriter tw = new StreamWriter(output);

                    foreach (String s in names)
                        tw.WriteLine(s);

                tw.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://chrome.google.com/webstore/detail/export-chrome-history/dihloblpkeiddiaojbagoecedbfpifdj/related");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Browse for csv file";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fdlg.FileName;
            }
        }
    }
}
