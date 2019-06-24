using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }

        private void UserControl3_Load(object sender, EventArgs e)
        {
        }

        private void UserControl3_Load_1(object sender, EventArgs e)
        {
            string boydegeri;
            string kilodegeri;
            string yasdegeri;
            string cinsiyetdegeri;
            double karbonhidrat;
            double protein;
            double kalori;
            double seker;
            double llf=0;
            double yag;
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=ProgressInformation.db;Version=3;");
            m_dbConnection.Open();
            string boy = "select boy from kisiselbilgi";
            string kilo = "select kilo from kisiselbilgi";
            string yas = "select yas from kisiselbilgi";
            string cinsiyet = "select cinsiyet from kisiselbilgi";
            SQLiteCommand command = new SQLiteCommand(boy, m_dbConnection);
            SQLiteCommand command2 = new SQLiteCommand(kilo, m_dbConnection);
            SQLiteCommand command3 = new SQLiteCommand(yas, m_dbConnection);
            SQLiteCommand command4 = new SQLiteCommand(cinsiyet, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                boydegeri = (reader["boy"].ToString());
                label6.Text = boydegeri;
            }
            SQLiteDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                kilodegeri = (reader2["kilo"].ToString());
                label5.Text = kilodegeri;
            }
            SQLiteDataReader reader3 = command3.ExecuteReader();
            while (reader3.Read())
            {
                yasdegeri = (reader3["yas"].ToString());
                label7.Text = yasdegeri;
            }
            SQLiteDataReader reader4 = command4.ExecuteReader();
            while (reader4.Read())
            {
                cinsiyetdegeri = (reader4["cinsiyet"].ToString());
                label9.Text = cinsiyetdegeri;
            }
            double x = Convert.ToInt32(label6.Text);/*boy*/
            int y = Convert.ToInt32(label5.Text);/*kilo*/
            int z = Convert.ToInt32(label7.Text);/*yas*/
            string w = label9.Text;/*cinsiyet*/
            protein = y * 0.8;
            protein = Math.Round(protein, 1);
            karbonhidrat = y * 2.5;
            karbonhidrat = Math.Round(karbonhidrat, 1);
            if (w == "Kadın")
            {
                kalori = 665 + (9.6 * y) + (1.7 * x) - (4.7 * z);
                kalori = kalori * 1.2;
                kalori= Math.Round(kalori, 1);
            }
            else
            {
                kalori = 66 + (13.75 * y) + (5 * x) - (6.8 * z);
                kalori = kalori * 1.2;
                kalori = Math.Round(kalori, 1);
            }
            if (w == "Kadın")
            {
                seker = 20;
            }
            else
            {
                seker = 35;
            }
            if (w == "Kadın")
            {
                if (z <= 3)
                {
                    llf = 19;
                }
                else if (z <= 8)
                {
                    llf = 25;
                }
                else if (z <= 13)
                {
                    llf = 26;
                }
                else if (z <= 18)
                {
                    llf = 26;
                }
                else if (z <= 49)
                {
                    llf = 25;
                }
                else if (z >= 50)
                {
                    llf = 21;
                }
            }
            else
            {
                if (z <= 3)
                {
                    llf = 19;
                }
                else if (z <= 8)
                {
                    llf = 25;
                }
                else if (z <= 13)
                {
                    llf = 31;
                }
                else if (z <= 18)
                {
                    llf = 38;
                }
                else if (z <= 49)
                {
                    llf = 38;
                }
                else if (z >= 50)
                {
                    llf = 30;
                }
            }
            yag = kalori / 30;
            yag = Math.Round(yag, 0);
            label5.Text = protein.ToString() + " gr.";
            label6.Text = karbonhidrat.ToString() + " gr.";
            label7.Text = yag.ToString() + " gr.";
            label9.Text = llf.ToString() + " gr.";
            label11.Text = seker.ToString() + " gr.";
            label13.Text = kalori.ToString() + " kcal";
            m_dbConnection.Close();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "Protein Zengini Besinler";
            toolTip1.Show("Kırmızı Et \n Beyaz Et \n Baklagiller \n Süt \n Yumurta \n Kabak Çekirdeği",pictureBox1);
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "Karbonhidrat Zengini Besinler";
            toolTip1.Show("Kuru Baklagiller \n Patates \n Yoğurt \n Süt \n Meyveler \n Pirinç", pictureBox1);
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "Yağ Zengini Besinler";
            toolTip1.Show("Brezilya Cevizi \n Balık \n Hindi \n Tavuk \n Yumurta \n Süzme Peynir", pictureBox1);
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "Lif Zengini Besinler";
            toolTip1.Show("Kayısı \n Elma \n Muz \n Böğürtlen \n Buğday Kepeği \n Fıstık", pictureBox1);
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "Şeker Zengini Besinler";
            toolTip1.Show("Brokoli \n Bal \n Pekmez \n Helva \n Reçel \n Papaya", pictureBox1);
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "Kalori Zengini Besinler";
            toolTip1.Show("Tereyağı \n Muz \n Balık \n Avokado \n Yumurta \n Kabak Çekirdeği", pictureBox1);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(pictureBox1);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(pictureBox1);
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(pictureBox1);
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(pictureBox1);
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(pictureBox1);
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(pictureBox1);
        }
    }
}
