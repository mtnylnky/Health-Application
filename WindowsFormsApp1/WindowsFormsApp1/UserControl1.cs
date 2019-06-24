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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        private void UserControl1_Load(object sender, EventArgs e)
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=ProgressInformation.db;Version=3;");
            m_dbConnection.Open();
            string boy = "select boy from kisiselbilgi";
            string kilo = "select kilo from kisiselbilgi";
            string yas = "select yas from kisiselbilgi";
            string cinsiyet = "select cinsiyet from kisiselbilgi";
            string isim = "select isim from kisiselbilgi";
            string soyad = "select soyad from kisiselbilgi";
            SQLiteCommand command = new SQLiteCommand(boy, m_dbConnection);
            SQLiteCommand command2 = new SQLiteCommand(kilo, m_dbConnection);
            SQLiteCommand command3 = new SQLiteCommand(yas, m_dbConnection);
            SQLiteCommand command4 = new SQLiteCommand(cinsiyet, m_dbConnection);
            SQLiteCommand command5 = new SQLiteCommand(isim, m_dbConnection);
            SQLiteCommand command6 = new SQLiteCommand(soyad, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = (reader["boy"].ToString());
            }
            SQLiteDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                textBox3.Text = (reader2["kilo"].ToString());
            }
            SQLiteDataReader reader3 = command3.ExecuteReader();
            while (reader3.Read())
            {
                textBox2.Text = (reader3["yas"].ToString());
            }
            SQLiteDataReader reader4 = command4.ExecuteReader();
            while (reader4.Read())
            {
                string deger = (reader4["cinsiyet"].ToString());
                if (deger == "Kadın")
                {
                    radioButton2.Checked = true;
                }
                else
                {
                    radioButton1.Checked = true;
                }
            }
            SQLiteDataReader reader5 = command5.ExecuteReader();
            while (reader5.Read())
            {
                textBox4.Text = (reader5["isim"].ToString());
            }
            SQLiteDataReader reader6 = command6.ExecuteReader();
            while (reader6.Read())
            {
                textBox5.Text = (reader6["soyad"].ToString());
            }

            m_dbConnection.Close();
        }

        string boy;
        string kilo;
        string yas;
        string isim;
        string soyad;
        string cinsiyet;

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;//eğer rakamsa  yazdır.
            }

            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;//eğer basılan tuş backspace ise yazdır.
            }
            else
            {
                e.Handled = true;//bunların dışındaysa hiçbirisini yazdırma
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;//eğer rakamsa  yazdır.
            }

            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;//eğer basılan tuş backspace ise yazdır.
            }
            else
            {
                e.Handled = true;//bunların dışındaysa hiçbirisini yazdırma
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;//eğer rakamsa  yazdır.
            }

            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;//eğer basılan tuş backspace ise yazdır.
            }
            else
            {
                e.Handled = true;//bunların dışındaysa hiçbirisini yazdırma
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            boy = textBox1.Text;
            kilo = textBox3.Text;
            yas = textBox2.Text;
            isim = textBox4.Text;
            soyad = textBox5.Text;
            if (radioButton2.Checked == true)
            {
                cinsiyet = "Kadın";
            }
            else if (radioButton1.Checked == true)
            {
                cinsiyet = "Erkek";
            }
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=ProgressInformation.db;Version=3;");
            m_dbConnection.Open();
            SQLiteCommand command = new SQLiteCommand("update kisiselbilgi set boy= @deger1", m_dbConnection);
            SQLiteCommand command2 = new SQLiteCommand("update kisiselbilgi set kilo= @deger2", m_dbConnection);
            SQLiteCommand command3 = new SQLiteCommand("update kisiselbilgi set yas= @deger3", m_dbConnection);
            SQLiteCommand command4 = new SQLiteCommand("update kisiselbilgi set cinsiyet= @deger4", m_dbConnection);
            SQLiteCommand command5 = new SQLiteCommand("update kisiselbilgi set isim= @deger5", m_dbConnection);
            SQLiteCommand command6 = new SQLiteCommand("update kisiselbilgi set soyad= @deger6", m_dbConnection);
            command.Parameters.AddWithValue("@deger1", boy);
            command2.Parameters.AddWithValue("@deger2", kilo);
            command3.Parameters.AddWithValue("@deger3", yas);
            command4.Parameters.AddWithValue("@deger4", cinsiyet);
            command5.Parameters.AddWithValue("@deger5", isim);
            command6.Parameters.AddWithValue("@deger6", soyad);
            command.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            command3.ExecuteNonQuery();
            command4.ExecuteNonQuery();
            command5.ExecuteNonQuery();
            command6.ExecuteNonQuery();
            m_dbConnection.Close();
            Application.Restart();
        }
    }
}
