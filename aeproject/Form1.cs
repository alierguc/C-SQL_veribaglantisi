using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace aeproject
{
    public partial class Form1 : Form
    {
       SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OT2MSUA\SQLEXPRESS;Initial Catalog=logn;Integrated Security=True");
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mgetir();
            try
            { 
            con.Open();
            SqlCommand komut = new SqlCommand("select * from blogin where kadi='"+textBox1.Text+"'and sifre= '" + textBox2.Text + "'", con);
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                Form2 ali = new Form2();
                ali.Show();


            }
            else
            {
                    label3.Text = "Kullanıcı adı veya şifreyi eksiksiz kodlayınız.";
                    label3.ForeColor = Color.Red;

            }
            con.Close();
            }
            catch
            {
                MessageBox.Show("Beklenmedik bir hata oluştu.");
                label3.ForeColor = Color.Red;

            }


        }
        public static string isim;
        public static string soyisim;
        public void Mgetir()
        {
            con.Open();
            SqlCommand komut = new SqlCommand("select kadi from blogin where kadi='" + textBox1.Text + "'and sifre= '" + textBox2.Text + "'", con);
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                isim = dr[0].ToString();



            }
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("kullanıcı adı : alierguc şifre : 12345");
        }
    }
}
