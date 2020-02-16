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
    public partial class kaydol : Form
    {

        SqlConnection baglanti = new SqlConnection("Data Source=camelia; Initial Catalog=sinema;Integrated Security=true");
        public kaydol()
        {
            InitializeComponent();
        }

        private void kaydol_Load(object sender, EventArgs e)
        {


          






        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                SqlCommand emir = new SqlCommand("insert into Kullanici_Kayit values(@ad,@soyad,@mail,@sifre)", baglanti);

                emir.Parameters.AddWithValue("@ad", textBox1.Text);

                emir.Parameters.AddWithValue("@soyad", textBox2.Text);

                emir.Parameters.AddWithValue("@mail", textBox3.Text);


                if (textBox4.Text == textBox5.Text)
                {

                    emir.Parameters.AddWithValue("@sifre", textBox4.Text);


                }

                else
                {




                    MessageBox.Show("şifreler eşleşmiyor");
                }


                baglanti.Open();

                emir.ExecuteNonQuery();

                baglanti.Close();

                MessageBox.Show("Kaydınız Yapılmıştır");






            }

          catch(Exception)
            {


             


            }

        }
    }
}
