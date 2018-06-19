using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace aeproject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-OT2MSUA\SQLEXPRESS;Initial Catalog=logn;Integrated Security=True");

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lognDataSet1.blogin' table. You can move, or remove it, as needed.
           
            

            this.bloginTableAdapter.Fill(this.lognDataSet1.blogin);
            label1.Text = Form1.isim.ToString();
           this.Text = "Hoşgeldiniz   |  " + Form1.isim.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            #region INSERT ISLEMLERI
            // insert işlemleri

            SqlCommand com = new SqlCommand();
            baglanti.Open();
            com.CommandText = "insert into blogin(kadi,sifre) values('" + textBox1.Text + "','" + textBox2.Text + "')";
            com.Connection = baglanti;
            com.ExecuteNonQuery();
            DataTable tablo = new DataTable();
            string tablogoster = "select * from blogin";
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand komutgoster = new SqlCommand();
            komutgoster.Connection = baglanti;
            komutgoster.CommandText = tablogoster;

            adapter.SelectCommand = komutgoster;
            adapter.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region DELETE KISMI

            SqlCommand com = new SqlCommand();
            baglanti.Open();
            com.CommandText = "delete blogin(kadi,sifre) values('" + textBox1.Text + "','" + textBox2.Text + "')";
            com.Connection = baglanti;
            com.ExecuteNonQuery();
            DataTable tablo = new DataTable();
            string tablogoster = "select * from blogin";
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand komutgoster = new SqlCommand();
            komutgoster.Connection = baglanti;
            komutgoster.CommandText = tablogoster;

            adapter.SelectCommand = komutgoster;
            adapter.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
            #endregion
        }
    }
}
