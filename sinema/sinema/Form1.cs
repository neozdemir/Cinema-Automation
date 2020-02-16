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
    public partial class Form1 : Form
    {

        SqlConnection baglanti = new SqlConnection("Data Source=camelia; Initial Catalog=sinema;Integrated Security=true");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

           



            kolturdoldur();
            timer1.Start();
            label9.Text = DateTime.Now.ToLongTimeString();
            


        }



        private void kolturdoldur()
        {




            for( int i =83; i>-1 ;i--  )
            {

                Button b = new Button();

                b.Text = (i + 1).ToString();
                b.Name = i.ToString();

                b.Size = new Size(40, 40);
                b.Parent = flowLayoutPanel1;
                b.BackColor = Color.Green;
                b.Click += new EventHandler(yakala);

               

            }

          


        }

        private void yakala(object o,EventArgs a)
        {
            
            Button b = (Button)o;


            if(b.BackColor==Color.Green)
            {


                b.BackColor = Color.Yellow;
                textBox1.Text = b.Text;



            }

            else if(b.BackColor==Color.Red)
            {
                
               
                DialogResult sonuc = MessageBox.Show("Seçili Koltuğun iptalini gerçekleştirmek istiyormusunuz?", "satış iptal", MessageBoxButtons.YesNo);
                if(sonuc==DialogResult.Yes)
                {

                    SqlCommand emir = new SqlCommand("Delete from Biletsatis_Tablo where Koltuk_No=@koltuk and Tarih=@tar", baglanti);


                    emir.Parameters.AddWithValue("@koltuk",b.Text);
                    emir.Parameters.AddWithValue("@tar", dateTimePicker1.Value);
                    
                    baglanti.Open();
                    emir.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Satış İptali Gerçekleşti");

                }
              

               

            }

            else 


            {

 b.BackColor = Color.Green;

            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            label9.Text = DateTime.Now.ToLongTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(numericUpDown1.Value) * 10 + Convert.ToDouble(numericUpDown2.Value) * 8.5;
            label13.Visible = true;
            label13.Text = a.ToString() + " TL";

            if(numericUpDown1.Value==0 && numericUpDown2.Value==0)
            {

                MessageBox.Show(" Lütfen Bilet sayısını Giriniz");



            }

            else
            {

                foreach (Button gez in flowLayoutPanel1.Controls)
                {

                    if (gez.BackColor == Color.Yellow)
                    {
                        DialogResult sonuc = MessageBox.Show(gez.Text + " " + "nolu koltuğu satın almak istiyormusunuz??", "satış", MessageBoxButtons.YesNo);

                        textBox1.Text = gez.Text;
                        if (sonuc == DialogResult.Yes)
                        {

                            SqlCommand emir = new SqlCommand("insert into Biletsatis_Tablo values(@tam,@ogrenci,@tar,@seans,@koltuk)", baglanti);

                            emir.CommandType = CommandType.StoredProcedure;

                            emir.CommandText = "veriengelleme";


                            emir.Parameters.AddWithValue("@tam", numericUpDown1.Value);



                            emir.Parameters.AddWithValue("@ogrenci", numericUpDown2.Value);




                            emir.Parameters.AddWithValue("@tar", dateTimePicker1.Value);


                            emir.Parameters.AddWithValue("@seans", comboBox1.SelectedItem);

                            emir.Parameters.AddWithValue("@koltuk", textBox1.Text);




                            baglanti.Open();

                            emir.ExecuteNonQuery();

                            baglanti.Close();


                            MessageBox.Show("satın alma gerçekleştirildi");
                        }


                        if (sonuc == DialogResult.No)
                        {

                            MessageBox.Show("Satın alma iptal edildi");


                        }



                    }


                }
            

            }
             
         
            
            
       
     


        }

        private void button2_Click(object sender, EventArgs e)
        {
            yesert();
          
            SqlCommand emir = new SqlCommand("select Koltuk_No from Biletsatis_Tablo where Tarih = @tar and  Seans =@seans ", baglanti);
            emir.Parameters.AddWithValue("@tar", dateTimePicker1.Value);
            emir.Parameters.AddWithValue("@seans", comboBox1.SelectedItem);

            baglanti.Open();

            SqlDataReader oku = emir.ExecuteReader();

            while(oku.Read())
            {
                

                foreach(Button gez in flowLayoutPanel1.Controls)
                {

                    
                    if(gez.Text == oku.GetInt32(0).ToString())
                   {
                      
                      
                           gez.BackColor = Color.Red;

                          

                       
                      




                   }

               

                 


                }


            }


            baglanti.Close();

         
       

        }

        private void kapatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();

            this.Close();
        }

        private void kaydolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kaydol a = new kaydol();

            this.Hide();

            a.ShowDialog();
        }

        private void satışİptalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            giris g = new giris();

            this.Hide();

            g.ShowDialog();
        }

      private void yesert()
        {



          foreach(Button gez in flowLayoutPanel1.Controls)
          {

              if(gez.BackColor==Color.Red)
              {

                  gez.BackColor = Color.Green;
                  gez.Enabled = true;

              }



          }



        }

    }
}
