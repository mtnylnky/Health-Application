using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using Tulpep.NotificationWindow;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        int saatsure = 0;
        int ekranikaplasure = 0;

        public Form1()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(8000);
            InitializeComponent();
            t.Abort();
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer2.Enabled = true;
            timer2.Interval = 1000;
            timer1.Start();
            timer2.Start();
            userControl11.Hide();
            userControl21.Show();
            userControl31.Hide();
            userControl41.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=ProgressInformation.db;Version=3;");
            m_dbConnection.Open();
            SQLiteCommand command = new SQLiteCommand("select molasure from ayarlar", m_dbConnection);
            SQLiteCommand command2 = new SQLiteCommand("select bildirimsure from ayarlar", m_dbConnection);
            /*string sql = "select bilgi from subilgi where id=@deger1";*/
            /*SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);*/
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                String sure = (reader["molasure"].ToString());
                switch (sure)
                {
                    case "00:15":
                        ekranikaplasure = 900;
                        break;
                    case "00:30":
                        ekranikaplasure = 1800;
                        break;
                    case "00:45":
                        ekranikaplasure = 2700;
                        break;
                    case "01:00":
                        ekranikaplasure = 3600;
                        break;
                    case "01:15":
                        ekranikaplasure = 4500;
                        break;
                    case "01:30":
                        ekranikaplasure = 5400;
                        break;
                    case "01:45":
                        ekranikaplasure = 6300;
                        break;
                    case "02:00":
                        ekranikaplasure = 7200;
                        break;
                    case "02:15":
                        ekranikaplasure = 8100;
                        break;
                    case "02:30":
                        ekranikaplasure = 9000;
                        break;
                    case "02:45":
                        ekranikaplasure = 9900;
                        break;
                    case "03:00":
                        ekranikaplasure = 10800;
                        break;
                }
            }
            SQLiteDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                String sure = (reader2["bildirimsure"].ToString());
                switch (sure)
                {
                    case "00:15":
                        saatsure = 900;
                        break;
                    case "00:30":
                        saatsure = 1800;
                        break;
                    case "00:45":
                        saatsure = 2700;
                        break;
                    case "01:00":
                        saatsure = 3600;
                        break;
                    case "01:15":
                        saatsure = 4500;
                        break;
                    case "01:30":
                        saatsure = 5400;
                        break;
                    case "01:45":
                        saatsure = 6300;
                        break;
                    case "02:00":
                        saatsure = 7200;
                        break;
                    case "02:15":
                        saatsure = 8100;
                        break;
                    case "02:30":
                        saatsure = 9000;
                        break;
                    case "02:45":
                        saatsure = 9900;
                        break;
                    case "03:00":
                        saatsure = 10800;
                        break;
                }
            }
        }

        /* Yukleme ekranini gosterme */
        public void StartForm()
        {
            Application.Run(new Form2());
        }

        /* Formu Tasima panel uzerinde */
        int move;
        int Mouse_X;
        int Mouse_Y;

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        /* Hayalet ekrani */
        int saat = 0;
        int ekranikapla = 0;
        public void hayalet()
        {
            var soundsRoot = @"heapp_RADS\\heapp_WAV";
            var rand = new Random();
            var soundfiles = Directory.GetFiles(soundsRoot, "*.wav");
            var playedsound = soundfiles[rand.Next(0, soundfiles.Length)];
            System.Media.SoundPlayer Player = new System.Media.SoundPlayer(playedsound);
            /*Player.SoundLocation = "play_song_1.wav";*/
            Player.Play();
            Thread t = new Thread(new ThreadStart(hayaletekrani));
            t.Start();
            Thread.Sleep(12000);
            Player.Stop();
            t.Abort();
        }

        private void hayaletekrani()
        {
            Application.Run(new Form3());
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            saat++;

            if (saat == saatsure)
            {
                bildiri();
                saat = 0;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            ekranikapla++;
            if (ekranikapla == ekranikaplasure)
            {
                hayalet();
                ekranikapla = 0;
            }
        }

        /* Bildirim alanı icerisinde yazacaklar. */
        private static void bildiri()
        {
            Random rastgele = new Random();
            int sayi = rastgele.Next(13);
            /*Veri Tabani cagirma islemi */
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=ProgressInformation.db;Version=3;");
            m_dbConnection.Open();
            SQLiteCommand command = new SQLiteCommand("select bilgi from subilgi where id=@deger1", m_dbConnection);
            /*string sql = "select bilgi from subilgi where id=@deger1";*/
            command.Parameters.AddWithValue("@deger1", sayi);
            /*SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);*/
            SQLiteDataReader reader = command.ExecuteReader();

            /*Popup cikarma alani */
            PopupNotifier popup = new PopupNotifier();
            popup.TitleText = "Önemli Bir Bilgi!!!";
            while (reader.Read())
            {
                popup.ContentText = (reader["bilgi"].ToString());
            }
            popup.Popup();
        }

        /* Gizli Simgeleri Göster Bölümü */
        private void Form1_Move(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.ShowBalloonTip(1000, "HeApp hâlâ çalışıyor!", 
                    "Programı Gizli Simgeleri Göster bölümünden tekrar görüntüleyebilirsiniz.", 
                    ToolTipIcon.Info);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void gösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.notifyIcon1.Dispose();
        }


        /* Buton Görevleri */
        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            userControl21.Show();
            userControl21.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            userControl31.Show();
            userControl31.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            userControl11.Show();
            userControl11.BringToFront();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            userControl41.Show();
            userControl41.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "file:HeApp.chm");
        }
    }
}
