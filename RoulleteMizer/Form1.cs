using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Diagnostics;
using System.IO;

using System.Windows.Forms;
using IWshRuntimeLibrary;
using System.Threading;

namespace RoulleteMizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pathSaver = "Ty for doing this";// this isnt used anywhere just thanks for downloading this and looking through this shit code

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                label1.Text = folderBrowserDialog1.SelectedPath;

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //hopefully this saves the extensions I wanna search for implementation will be added later
            Random RNGjesus = new Random();
            MethodClass classobj = new MethodClass();
            string[] supportedExtensions = new[] { "*.exe", "*.url", "*.lnk" };
            string pathsaver = label1.Text; // the MVP of this program


            //hopefully this makes the list I'll save all the files to
            List<string> files = new List<string>();
            //maybe filter through many extensions but bruh extremely bad way maybe will fix it lets be honest tho.
            files = Directory
               .EnumerateFiles(pathsaver)
               .Where(file => file.ToLower().EndsWith("exe") || file.ToLower().EndsWith("url") || file.ToLower().EndsWith("lnk"))
               .ToList();

            foreach (string file in files)
            {
                

                textBox1.AppendText(classobj.Getname(file));
                textBox1.AppendText(Environment.NewLine);
            }


            int RNGjesus2 = RNGjesus.Next(0, files.Count);



            textBox2.AppendText("You are now starting : " +classobj.Getname( files[RNGjesus2]) + " I hope you enjoy it");
            Thread.Sleep(2000);
            
            classobj.DetermineShit(files[RNGjesus2]);// 0 LNK 1 URL
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
