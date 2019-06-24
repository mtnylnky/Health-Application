using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using System.Globalization;

namespace WindowsFormsApp1
{
    public partial class UserControl2 : UserControl
    {
        int ekranikaplasure = 0;

        public UserControl2()
        {
            InitializeComponent();
            string pazartesi = "";
            string sali = "";
            string carsamba = "";
            string persembe = "";
            string cuma = "";
            string cumartesi = "";
            string pazar = "";
            SQLiteConnection sqlite = new SQLiteConnection("Data Source=ProgressInformation.db;Version=3;");
            try
            {
                sqlite.Open();
                SQLiteCommand cmd = sqlite.CreateCommand();
                cmd.CommandText = "select pazartesi from gunler where id=1";
                pazartesi = cmd.ExecuteScalar().ToString();

                SQLiteCommand cmd1 = sqlite.CreateCommand();
                cmd1.CommandText = "select sali from gunler where id=1";
                sali = cmd1.ExecuteScalar().ToString();

                SQLiteCommand cmd2 = sqlite.CreateCommand();
                cmd2.CommandText = "select carsamba from gunler where id=1";
                carsamba = cmd2.ExecuteScalar().ToString();

                SQLiteCommand cmd3 = sqlite.CreateCommand();
                cmd3.CommandText = "select persembe from gunler where id=1";
                persembe = cmd3.ExecuteScalar().ToString();

                SQLiteCommand cmd4 = sqlite.CreateCommand();
                cmd4.CommandText = "select cuma from gunler where id=1";
                cuma = cmd4.ExecuteScalar().ToString();

                SQLiteCommand cmd5 = sqlite.CreateCommand();
                cmd5.CommandText = "select cumartesi from gunler where id=1";
                cumartesi = cmd5.ExecuteScalar().ToString();

                SQLiteCommand cmd6 = sqlite.CreateCommand();
                cmd6.CommandText = "select pazar from gunler where id=1";
                pazar = cmd6.ExecuteScalar().ToString();
            }
            finally
            {
                sqlite.Close();
            }
            double pzt= Convert.ToInt32(pazartesi);
            double sli = Convert.ToInt32(sali);
            double crsmb = Convert.ToInt32(carsamba);
            double prsb = Convert.ToInt32(persembe);
            double cm = Convert.ToInt32(cuma);
            double cmrts = Convert.ToInt32(cumartesi);
            double pzr = Convert.ToInt32(pazar);
            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title="Pazartesi",
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0,1),
                        new ObservablePoint(pzt,1)
                    },
                    PointGeometrySize=24
                },
                new LineSeries
                {
                    Title="Salı",
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0,2),
                        new ObservablePoint(sli,2)
                    },
                    PointGeometrySize=24
                },
                new LineSeries
                {
                    Title="Çarşamba",
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0,3),
                        new ObservablePoint(crsmb,3)
                    },
                    PointGeometrySize=24
                },
                new LineSeries
                {
                    Title="Perşembe",
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0,4),
                        new ObservablePoint(prsb,4)
                    },
                    PointGeometrySize=24
                },
                new LineSeries
                {
                    Title="Cuma",
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0,5),
                        new ObservablePoint(cm,5)
                    },
                    PointGeometrySize=24
                },
                new LineSeries
                {
                    Title="Cumartesi",
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0,6),
                        new ObservablePoint(cmrts,6)
                    },
                    PointGeometrySize=24
                },
                new LineSeries
                {
                    Title="Pazar",
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0,7),
                        new ObservablePoint(pzr,7)
                    },
                    PointGeometrySize=24
                }
            };
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Günler",
                Labels = new[] {" "}
            });
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Kullanım Süresi"
            });
        }

        int durumsayi = 0;
        int artansayi = 1;

        private void UserControl2_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;
            timer1.Interval = 1000;
            timer2.Interval = 1000;
            timer3.Interval = 1000;
            label9.Hide();
            string boydegeri;
            string kilodegeri;
            string cinsiyetdegeri;
            double vkutle;
            double slitre;
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=ProgressInformation.db;Version=3;");
            m_dbConnection.Open();
            string boy = "select boy from kisiselbilgi";
            string kilo = "select kilo from kisiselbilgi";
            string cinsiyet = "select cinsiyet from kisiselbilgi";
            string isim = "select isim from kisiselbilgi";
            string surehesab = "select molasure from ayarlar";
            SQLiteCommand command = new SQLiteCommand(boy, m_dbConnection);
            SQLiteCommand command2 = new SQLiteCommand(kilo, m_dbConnection);
            SQLiteCommand command3 = new SQLiteCommand(cinsiyet, m_dbConnection);
            SQLiteCommand command4 = new SQLiteCommand(isim, m_dbConnection);
            SQLiteCommand command5 = new SQLiteCommand(surehesab, m_dbConnection);
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
                cinsiyetdegeri = (reader3["cinsiyet"].ToString());
                if (cinsiyetdegeri == "Kadın")
                {
                    pictureBox5.ImageLocation = @"heapp_RADS\\heapp_RESC\\userw.png";
                }
                else
                {
                    pictureBox5.ImageLocation = @"heapp_RADS\\heapp_RESC\\userm.png";
                }
            }
            SQLiteDataReader reader4 = command4.ExecuteReader();
            while (reader4.Read())
            {
                label10.Text = (reader4["isim"].ToString());
            }
            SQLiteDataReader reader5 = command5.ExecuteReader();
            while (reader5.Read())
            {
                String sure = (reader5["molasure"].ToString());
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
            double x = Convert.ToInt32(label6.Text);/*boy*/
            int y = Convert.ToInt32(label5.Text);/*kilo*/
            vkutle = x / 100;
            vkutle = vkutle * vkutle;
            vkutle = y/vkutle;
            vkutle = Math.Round(vkutle, 2);
            slitre = y * 0.033;
            slitre = Math.Round(slitre, 1);
            label6.Text = vkutle.ToString();
            label5.Text = slitre.ToString() + " Lt.";
            m_dbConnection.Close();
            if (vkutle < 18.5){
                label15.Text = "zayıf";
            } else if(vkutle>=18.5 && vkutle <= 24.9)
            {
                label15.Text = "Normal Kilolu";
            }else if (vkutle >= 25 && vkutle <= 29.9)
            {
                label15.Text = "Fazla Kilolu";
            }
            else if (vkutle >= 30 && vkutle <= 34.9)
            {
                label15.Text = "1. Derece Obez";
            }
            else if (vkutle >= 35 && vkutle <= 39.9)
            {
                label15.Text = "2. Derece Obez";
            }
            else if (vkutle >= 40)
            {
                label15.Text = "3. Derece Obez";
            }
            circularProgressBar1.Value = 0;
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = ekranikaplasure;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            durumsayi++;

            if (durumsayi == 1)
            {
                if (circularProgressBar1.Value == ekranikaplasure)
                {
                    circularProgressBar1.Value = 0;
                    circularProgressBar1.Update();
                    durumsayi = 0;
                }
                else
                {
                    circularProgressBar1.Value = circularProgressBar1.Value + artansayi;
                    circularProgressBar1.Update();
                    durumsayi = 0;
                }
            }
        }

        int saat = 0, dakika = 0, saniye = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (int.Parse(label4.Text) < 9)
            {
                label4.Text = "0" + (int.Parse(label4.Text) + 1).ToString();
            }
            else
            {
                label4.Text = (int.Parse(label4.Text) + 1).ToString();
            }
            if (int.Parse(label4.Text) == 60)
            {
                label4.Text = "00";
                if (int.Parse(label12.Text) < 9)
                {
                    label12.Text = "0" + (int.Parse(label12.Text) + 1).ToString();
                }
                else
                {
                    label12.Text = (int.Parse(label12.Text) + 1).ToString();
                }
            }
            if (int.Parse(label12.Text) == 60)
            {
                label12.Text = "00";
                if (int.Parse(label13.Text) < 9)
                {
                    label13.Text = "0" + (int.Parse(label13.Text) + 2).ToString();
                    if (int.Parse(label13.Text) == 2) {
                        label9.Show();
                    }
                }
                else
                {
                    label13.Text = (int.Parse(label13.Text) + 1).ToString();
                }
            }
        }

        int artansure;
        int eklenensure;

        private void timer3_Tick(object sender, EventArgs e)
        {
            artansure++;
            eklenensure++;
            if (artansure == 60)
            {
                gunekle(eklenensure);
                artansure = 0;
                eklenensure = 0;
            }
        }

        private static void gunekle(int x)
        {
            int bosdoldur = 0;
            string bugun = DateTime.Today.ToShortDateString();
            string bugunsayi = DateTime.Today.ToString("dd");
            int gdegr = x;
            int guna = (int)DateTime.Now.DayOfWeek;
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=ProgressInformation.db;Version=3;");
            m_dbConnection.Open();
            switch (guna)
            {
                case 1:
                    string gunubul = "select pazartesi from gunler where id=2";
                    SQLiteCommand command = new SQLiteCommand(gunubul, m_dbConnection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string bugg = (reader["pazartesi"].ToString());
                        if (bugunsayi == bugg)
                        {
                            string bugunuhes = "select pazartesi from gunler where id=1";
                            SQLiteCommand comman = new SQLiteCommand(bugunuhes, m_dbConnection);
                            SQLiteDataReader reader1 = comman.ExecuteReader();
                            while (reader1.Read())
                            {
                                string gununsaati = (reader1["pazartesi"].ToString());
                                int pazrts = Convert.ToInt32(gununsaati);
                                int ekle1 = gdegr + pazrts;
                                SQLiteCommand pzrtekl = new SQLiteCommand("update gunler set pazartesi= @deger1  where id=1", m_dbConnection);
                                pzrtekl.Parameters.AddWithValue("@deger1", ekle1);
                                pzrtekl.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            SQLiteCommand tarhdegs = new SQLiteCommand("update gunler set pazartesi=@deger1  where id=2", m_dbConnection);
                            tarhdegs.Parameters.AddWithValue("@deger1", bugun);
                            SQLiteCommand degersifirla = new SQLiteCommand("update gunler set pazartesi=@deger2 where id=1", m_dbConnection);
                            degersifirla.Parameters.AddWithValue("@deger2", bosdoldur);
                            tarhdegs.ExecuteNonQuery();
                            degersifirla.ExecuteNonQuery();
                        }
                    }
                    break;
                case 2:
                    string gunubul2 = "select sali from gunler where id=2";
                    SQLiteCommand command2 = new SQLiteCommand(gunubul2, m_dbConnection);
                    SQLiteDataReader reader2 = command2.ExecuteReader();
                    while (reader2.Read())
                    {
                        string bugg = (reader2["sali"].ToString());
                        if (bugunsayi == bugg)
                        {
                            string bugunuhes = "select sali from gunler where id=1";
                            SQLiteCommand comman = new SQLiteCommand(bugunuhes, m_dbConnection);
                            SQLiteDataReader reader1 = comman.ExecuteReader();
                            while (reader1.Read())
                            {
                                string gununsaati = (reader1["sali"].ToString());
                                int pazrts = Convert.ToInt32(gununsaati);
                                int ekle1 = gdegr + pazrts;
                                SQLiteCommand pzrtekl = new SQLiteCommand("update gunler set sali= @deger1 where id=1", m_dbConnection);
                                pzrtekl.Parameters.AddWithValue("@deger1", ekle1);
                                pzrtekl.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            SQLiteCommand tarhdegs = new SQLiteCommand("update gunler set sali=@deger1 where id=2", m_dbConnection);
                            tarhdegs.Parameters.AddWithValue("@deger1", bugun);
                            SQLiteCommand degersifirla = new SQLiteCommand("update gunler set sali=@deger2 where id=1", m_dbConnection);
                            degersifirla.Parameters.AddWithValue("@deger2", bosdoldur);
                            tarhdegs.ExecuteNonQuery();
                            degersifirla.ExecuteNonQuery();
                        }
                    }
                    break;
                case 3:
                    string gunubul3 = "select carsamba from gunler where id=2";
                    SQLiteCommand command3 = new SQLiteCommand(gunubul3, m_dbConnection);
                    SQLiteDataReader reader3 = command3.ExecuteReader();
                    while (reader3.Read())
                    {
                        string bugg = (reader3["carsamba"].ToString());
                        if (bugunsayi == bugg)
                        {
                            string bugunuhes = "select carsamba from gunler where id=1";
                            SQLiteCommand comman = new SQLiteCommand(bugunuhes, m_dbConnection);
                            SQLiteDataReader reader1 = comman.ExecuteReader();
                            while (reader1.Read())
                            {
                                string gununsaati = (reader1["carsamba"].ToString());
                                int pazrts = Convert.ToInt32(gununsaati);
                                int ekle1 = gdegr + pazrts;
                                SQLiteCommand pzrtekl = new SQLiteCommand("update gunler set carsamba=@deger1 where id=1", m_dbConnection);
                                pzrtekl.Parameters.AddWithValue("@deger1", ekle1);
                                pzrtekl.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            SQLiteCommand tarhdegs = new SQLiteCommand("update gunler set carsamba= @deger1 where id=2", m_dbConnection);
                            tarhdegs.Parameters.AddWithValue("@deger1", bugun);
                            SQLiteCommand degersifirla = new SQLiteCommand("update gunler set carsamba=@deger2 where id=1", m_dbConnection);
                            degersifirla.Parameters.AddWithValue("@deger2", bosdoldur);
                            tarhdegs.ExecuteNonQuery();
                            degersifirla.ExecuteNonQuery();
                        }
                    }
                    break;
                case 4:
                    string gunubul4 = "select persembe from gunler where id=2";
                    SQLiteCommand command4 = new SQLiteCommand(gunubul4, m_dbConnection);
                    SQLiteDataReader reader4 = command4.ExecuteReader();
                    while (reader4.Read())
                    {
                        string bugg = (reader4["persembe"].ToString());
                        if (bugunsayi == bugg)
                        {
                            string bugunuhes = "select persembe from gunler where id=1";
                            SQLiteCommand comman = new SQLiteCommand(bugunuhes, m_dbConnection);
                            SQLiteDataReader reader1 = comman.ExecuteReader();
                            while (reader1.Read())
                            {
                                string gununsaati = (reader1["persembe"].ToString());
                                int pazrts = Convert.ToInt32(gununsaati);
                                int ekle1 = gdegr + pazrts;
                                SQLiteCommand pzrtekl = new SQLiteCommand("update gunler set persembe=@deger1 where id=1", m_dbConnection);
                                pzrtekl.Parameters.AddWithValue("@deger1", ekle1);
                                pzrtekl.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            SQLiteCommand tarhdegs = new SQLiteCommand("update gunler set persembe= @deger1 where id=2", m_dbConnection);
                            tarhdegs.Parameters.AddWithValue("@deger1", bugun);
                            SQLiteCommand degersifirla = new SQLiteCommand("update gunler set persembe=@deger2 where id=1", m_dbConnection);
                            degersifirla.Parameters.AddWithValue("@deger2", bosdoldur);
                            tarhdegs.ExecuteNonQuery();
                            degersifirla.ExecuteNonQuery();
                        }
                    }
                    break;
                case 5:
                    string gunubul5 = "select cuma from gunler where id=2";
                    SQLiteCommand command5 = new SQLiteCommand(gunubul5, m_dbConnection);
                    SQLiteDataReader reader5 = command5.ExecuteReader();
                    while (reader5.Read())
                    {
                        string bugg = (reader5["cuma"].ToString());
                        if (bugunsayi == bugg)
                        {
                            string bugunuhes = "select cuma from gunler where id=1";
                            SQLiteCommand comman = new SQLiteCommand(bugunuhes, m_dbConnection);
                            SQLiteDataReader reader1 = comman.ExecuteReader();
                            while (reader1.Read())
                            {
                                string gununsaati = (reader1["cuma"].ToString());
                                int pazrts = Convert.ToInt32(gununsaati);
                                int ekle1 = gdegr + pazrts;
                                SQLiteCommand pzrtekl = new SQLiteCommand("update gunler set cuma= @deger1 where id=1", m_dbConnection);
                                pzrtekl.Parameters.AddWithValue("@deger1", ekle1);
                                pzrtekl.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            SQLiteCommand tarhdegs = new SQLiteCommand("update gunler set cuma= @deger1 where id=2", m_dbConnection);
                            tarhdegs.Parameters.AddWithValue("@deger1", bugun);
                            SQLiteCommand degersifirla = new SQLiteCommand("update gunler set cuma=@deger2 where id=1", m_dbConnection);
                            degersifirla.Parameters.AddWithValue("@deger2",bosdoldur);
                            tarhdegs.ExecuteNonQuery();
                            degersifirla.ExecuteNonQuery();
                        }
                    }
                    break;
                case 6:
                    string gunubul6 = "select cumartesi from gunler where id=2";
                    SQLiteCommand command6 = new SQLiteCommand(gunubul6, m_dbConnection);
                    SQLiteDataReader reader6 = command6.ExecuteReader();
                    while (reader6.Read())
                    {
                        string bugg = (reader6["cumartesi"].ToString());
                        if (bugunsayi == bugg)
                        {
                            string bugunuhes = "select cumartesi from gunler where id=1";
                            SQLiteCommand comman = new SQLiteCommand(bugunuhes, m_dbConnection);
                            SQLiteDataReader reader1 = comman.ExecuteReader();
                            while (reader1.Read())
                            {
                                string gununsaati = (reader1["cumartesi"].ToString());
                                int pazrts = Convert.ToInt32(gununsaati);
                                int ekle1 = gdegr + pazrts;
                                SQLiteCommand pzrtekl = new SQLiteCommand("update gunler set cumartesi= @deger1 where id=1", m_dbConnection);
                                pzrtekl.Parameters.AddWithValue("@deger1", ekle1);
                                pzrtekl.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            SQLiteCommand tarhdegs = new SQLiteCommand("update gunler set cumartesi=@deger1 where id=2", m_dbConnection);
                            tarhdegs.Parameters.AddWithValue("@deger1", bugun);
                            SQLiteCommand degersifirla = new SQLiteCommand("update gunler set cumartesi=@deger2 where id=1", m_dbConnection);
                            degersifirla.Parameters.AddWithValue("@deger2", bosdoldur);
                            tarhdegs.ExecuteNonQuery();
                            degersifirla.ExecuteNonQuery();
                        }
                    }
                    break;
                case 7:
                    string gunubul7 = "select pazar from gunler where id=2";
                    SQLiteCommand command7 = new SQLiteCommand(gunubul7, m_dbConnection);
                    SQLiteDataReader reader7 = command7.ExecuteReader();
                    while (reader7.Read())
                    {
                        string bugg = (reader7["pazar"].ToString());
                        if (bugunsayi == bugg)
                        {
                            string bugunuhes = "select pazar from gunler where id=1";
                            SQLiteCommand comman = new SQLiteCommand(bugunuhes, m_dbConnection);
                            SQLiteDataReader reader1 = comman.ExecuteReader();
                            while (reader1.Read())
                            {
                                string gununsaati = (reader1["pazar"].ToString());
                                int pazrts = Convert.ToInt32(gununsaati);
                                int ekle1 = gdegr + pazrts;
                                SQLiteCommand pzrtekl = new SQLiteCommand("update gunler set pazar=@deger1 where id=1", m_dbConnection);
                                pzrtekl.Parameters.AddWithValue("@deger1", ekle1);
                                pzrtekl.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            SQLiteCommand tarhdegs = new SQLiteCommand("update gunler set pazar=@deger1 where id=2", m_dbConnection);
                            tarhdegs.Parameters.AddWithValue("@deger1", bugun);
                            SQLiteCommand degersifirla = new SQLiteCommand("update gunler set pazar=@deger2 where id=1", m_dbConnection);
                            degersifirla.Parameters.AddWithValue("@deger2", bosdoldur);
                            tarhdegs.ExecuteNonQuery();
                            degersifirla.ExecuteNonQuery();
                        }
                    }
                    break;
            }
            m_dbConnection.Close();
        }
    }
}
