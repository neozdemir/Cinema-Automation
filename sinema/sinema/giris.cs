using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sinema
{
    public partial class giris : Form
    {

        SqlConnection baglanti = new SqlConnection("Data Source=camelia;Initial Catalog=sinema;Integrated Security=true");
        public giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand emir = new SqlCommand("select Kullanici_id from Kullanici_Kayit where Kullanici_Mail= '" + textBox1.Text + "' and Kullanici_Sifre= '" + textBox2.Text + "'", baglanti);

            baglanti.Open();


            int id = Convert.ToInt32(emir.ExecuteScalar());

            if(id!=0)
            {


                Form1 a = new Form1();

                this.Hide();

                a.ShowDialog();







            }

            else
            {

                MessageBox.Show("Yalnış Kullanıcı adı veya şifre");




            }


            baglanti.Close();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            kaydol a = new kaydol();

            this.Hide();

            a.ShowDialog();
        }
    }
}
