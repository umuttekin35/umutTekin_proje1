using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace umutTekin_proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listele()
        {
            SQLiteConnection baglanti =
                new SQLiteConnection("Data Source=C:\\Users\\PC\\Music\\adresdefteri.db;version=3");
            baglanti.Open();
            SQLiteDataAdapter da =
                new SQLiteDataAdapter("SELECT * FROM adresDefteri", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds, "adresDefteri");
            dataGridView1.DataSource = ds.Tables["adresDefteri"];
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible=false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection baglanti =
                    new SQLiteConnection("Data Source=C:\\Users\\PC\\Music\\adresdefteri.db;version=3");
                baglanti.Open();
                SQLiteCommand komut = new SQLiteCommand();
                komut.Connection = baglanti;
                komut.CommandText =
                    "INSERT INTO adresDefteri VALUES('" + textBox1.Text + "','" +
                    textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                komut.ExecuteNonQuery();
                baglanti.Close();
                listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA " + ex.Message);
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection baglanti =
                    new SQLiteConnection("Data Source=C:\\Users\\PC\\Music\\adresdefteri.db;version=3");
                baglanti.Open();
                SQLiteCommand komut = new SQLiteCommand();
                komut.Connection = baglanti;
                komut.CommandText =
                    "DELETE FROM adresDefteri WHERE Ad='" + textBox1.Text + "'";
                komut.ExecuteNonQuery();
                baglanti.Close();
                listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA : " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection baglanti =
                    new SQLiteConnection("Data Source=C:\\Users\\PC\\Desktop\\Yazılım\\kisirehberi.db;version=3");
                baglanti.Open();
                SQLiteCommand komut = new SQLiteCommand();
                komut.Connection = baglanti;
                komut.CommandText =
                    "UPTADE * FROM adresDefteri WHERE Ad='" + textBox1.Text + "'";
                komut.ExecuteNonQuery();
                baglanti.Close();
                listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA : " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }
    }
}
