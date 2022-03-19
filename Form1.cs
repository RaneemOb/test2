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
using Microsoft.VisualBasic.PowerPacks;

namespace Assi2
{
    public partial class Form1 : Form
    {
        string location;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Visible = false;

        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void ovalShape1_Click(object sender, EventArgs e)
        {

        }

        private void ovalShape2_Click(object sender, EventArgs e)
        {

        }

        private void ovalShape3_Click(object sender, EventArgs e)
        {

        }

        private void actionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        int x;
        int y;
        private void sTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "TextFile|*.txt|XMLFILE|*.xml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.FilterIndex == 1)
                {
                    StreamReader Reader = new StreamReader(dlg.FileName);
                    while (!Reader.EndOfStream)
                    {

                        location = Reader.ReadLine();

                    }

                    Reader.Close();
                }
            }
            string[] numbers = location.Split(new char[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < numbers.Length; i += 2)
            {
                x = Convert.ToInt32(numbers[i]);
                y = Convert.ToInt32(numbers[i + 1]);
            }
            pictureBox1.Location = new Point(x, y + menuStrip1.Height);
            pictureBox1.Visible = true;
            timer1.Enabled = true;
        }

        private void sTOPGAMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            int x = pictureBox1.Location.X;
            int y = pictureBox1.Location.Y;


            if (ovalShape1.Visible)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y);
                ovalShape1.Visible = false;
                ovalShape2.Visible = false;
                ovalShape3.Visible = true;



            }
            else if (ovalShape3.Visible)
            {
                ovalShape1.Visible = false;
                ovalShape2.Visible = true;
                ovalShape3.Visible = false;
                x = pictureBox1.Location.X + 150;

                pictureBox1.Location = new Point(x, y);
                if (pictureBox1.Location.X + pictureBox1.Width > this.Width - rectangleShape1.Width)
                    pictureBox1.Location = new Point(0, y);

            }
            else if (ovalShape2.Visible)
            {
                ovalShape1.Visible = true;
                ovalShape2.Visible = false;
                ovalShape3.Visible = false;

                x = pictureBox1.Location.X + 5;

                pictureBox1.Location = new Point(x, y);
                if (pictureBox1.Location.X + pictureBox1.Width > this.Width - rectangleShape1.Width)
                    pictureBox1.Location = new Point(0, y);
            }





        }
    }
}