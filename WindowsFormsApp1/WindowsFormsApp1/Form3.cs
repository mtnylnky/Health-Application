using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            var backRoot = @"heapp_RADS\\heapp_GIF";
            var rand = new Random();
            var picfiles = Directory.GetFiles(backRoot, "*.gif");
            var playedpic = picfiles[rand.Next(0, picfiles.Length)];
            pictureBox1.ImageLocation = playedpic;
            /*panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.BackgroundImage = System.Drawing.Image.FromFile(playedpic);*/
        }
    }
}
