using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace WindowsFormsApp1
{
    public partial class UserControl4 : UserControl
    {
        public UserControl4()
        {
            InitializeComponent();
        }

        private void UserControl4_Load(object sender, EventArgs e)
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=ProgressInformation.db;Version=3;");
            m_dbConnection.Open();
            string molasure = "select molasure from ayarlar";
            string bildirimsure = "select bildirimsure from ayarlar";
            string baslangic = "select baslangic from ayarlar";
            SQLiteCommand command = new SQLiteCommand(molasure, m_dbConnection);
            SQLiteCommand command2 = new SQLiteCommand(bildirimsure, m_dbConnection);
            SQLiteCommand command3 = new SQLiteCommand(baslangic, m_dbConnection);

            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                String molasuresi = (reader["molasure"].ToString());
                switch (molasuresi)
                {
                    case "00:15":
                        comboBox1.SelectedIndex = 0;
                        break;
                    case "00:30":
                        comboBox1.SelectedIndex = 1;
                        break;
                    case "00:45":
                        comboBox1.SelectedIndex = 2;
                        break;
                    case "01:00":
                        comboBox1.SelectedIndex = 3;
                        break;
                    case "01:15":
                        comboBox1.SelectedIndex = 4;
                        break;
                    case "01:30":
                        comboBox1.SelectedIndex = 5;
                        break;
                    case "01:45":
                        comboBox1.SelectedIndex = 6;
                        break;
                    case "02:00":
                        comboBox1.SelectedIndex = 7;
                        break;
                    case "02:15":
                        comboBox1.SelectedIndex = 8;
                        break;
                    case "02:30":
                        comboBox1.SelectedIndex = 9;
                        break;
                    case "02:45":
                        comboBox1.SelectedIndex = 10;
                        break;
                    case "03:00":
                        comboBox1.SelectedIndex = 11;
                        break;
                }
            }
            SQLiteDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                String bildirimsuresi = (reader2["bildirimsure"].ToString());
                switch (bildirimsuresi)
                {
                    case "00:15":
                        comboBox2.SelectedIndex = 0;
                        break;
                    case "00:30":
                        comboBox2.SelectedIndex = 1;
                        break;
                    case "00:45":
                        comboBox2.SelectedIndex = 2;
                        break;
                    case "01:00":
                        comboBox2.SelectedIndex = 3;
                        break;
                    case "01:15":
                        comboBox2.SelectedIndex = 4;
                        break;
                    case "01:30":
                        comboBox2.SelectedIndex = 5;
                        break;
                    case "01:45":
                        comboBox2.SelectedIndex = 6;
                        break;
                    case "02:00":
                        comboBox2.SelectedIndex = 7;
                        break;
                    case "02:15":
                        comboBox2.SelectedIndex = 8;
                        break;
                    case "02:30":
                        comboBox2.SelectedIndex = 9;
                        break;
                    case "02:45":
                        comboBox2.SelectedIndex = 10;
                        break;
                    case "03:00":
                        comboBox2.SelectedIndex = 11;
                        break;
                }
            }
            SQLiteDataReader reader3 = command3.ExecuteReader();
            while (reader3.Read())
            {
                String baslangictipi = (reader3["baslangic"].ToString());
                switch (baslangictipi)
                {
                    case "Evet (Önerilir)":
                        comboBox3.SelectedIndex = 0;
                        break;
                    case "Hayır (Önerilmez)":
                        comboBox3.SelectedIndex = 1;
                        break;
                }
            }
            m_dbConnection.Close();
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=ProgressInformation.db;Version=3;");
            m_dbConnection.Open();
            SQLiteCommand command = new SQLiteCommand("update ayarlar set molasure= @deger1", m_dbConnection);
            SQLiteCommand command2 = new SQLiteCommand("update ayarlar set bildirimsure= @deger2", m_dbConnection);
            SQLiteCommand command3 = new SQLiteCommand("update ayarlar set baslangic= @deger2", m_dbConnection);
            command.Parameters.AddWithValue("@deger1", comboBox1.SelectedItem);
            command2.Parameters.AddWithValue("@deger2", comboBox2.SelectedItem);
            command3.Parameters.AddWithValue("@deger3", comboBox2.SelectedItem);
            command.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            command3.ExecuteNonQuery();
            m_dbConnection.Close();
            Application.Restart();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
