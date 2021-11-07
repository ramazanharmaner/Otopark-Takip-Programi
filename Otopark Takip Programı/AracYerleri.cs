using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otopark_Takip_Programı
{
    public partial class AracYerleri : Form
    {
        public AracYerleri()
        {
            InitializeComponent();
        }

        public static string[] plakalar = new string[20];
        public static string[] konum = new string[20];
        public static string[] kullanicilar = new string[20];
        public static int boyut = 0; public static string bilgi;
        public static bool formGecis = false;

        private void button21_Click(object sender, EventArgs e)
        {


            Form1 pencere = new Form1();

           
            Form1.boyut = boyut;
            Array.Resize(ref Form1.kayitlar , boyut);
            for (int i = 0; i < boyut; i++)
            {
                Form1.kayitlar[i] = kullanicilar[i];
            }
            Form1.kontrol = true;
            pencere.Show();
            
           
            this.Hide();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            AracBilgileriForm pencere = new AracBilgileriForm();
            pencere.Show();
            this.Hide();

        }

        private void AracYerleri_Load(object sender, EventArgs e)
        {
 
            if (formGecis == true)
            {
                boyut = AracBilgileriForm.boyut;

                Array.Resize(ref plakalar, boyut);
                Array.Resize(ref konum, boyut);

                for (int i = 0; i < boyut; i++)
                {
                    kullanicilar[i] = AracBilgileriForm.kullanicilar[i];    
                    konum[i] = AracBilgileriForm.konum[i];
                }
                doldur();
                formGecis = false;
            }
           else
            {
                boyut = Form1.boyut;

                Array.Resize(ref plakalar, boyut);
                Array.Resize(ref konum, boyut);

                for (int i = 0; i < boyut; i++)
                {
                    kullanicilar[i] = Form1.kayitlar[i];           
                }
               
                formGecis = false;
                oku();
                doldur();
            } 
            

            buttonlariDoldur();
        }

        public void oku()
        {
            Array.Resize(ref konum, boyut);
            for (int i = 0; i < boyut; i++)
            {
                char[] array = kullanicilar[i].ToCharArray();
                konum[i] += array[array.Length - 2].ToString() + array[array.Length - 1].ToString();

            }

        }

        void doldur()
        {
            Array.Resize(ref plakalar, boyut + 1);
            int islem = 1;
            label2.Text = "";
            for (int i = 0; i < boyut; i++)
            {
                char[] array = kullanicilar[i].ToCharArray();
                islem = 1;
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j] == '#')
                    {
                        islem++;
                        j++;
                    }

                    if (islem == 6)
                    {
                        label2.Text = label2.Text + array[j];
                    }


                }
                plakalar[i] = label2.Text;
                label2.Text = "";
            }

        }


        void buttonlariDoldur()
        {
            for (int i = 0; i < boyut; i++)
            {

                if (konum[i] == a1Button.Text)
                {
                    a1Button.Text = plakalar[i];
                    a1Button.BackColor = Color.Red;
                }
                else if (konum[i] == a2Button.Text)
                {
                    a2Button.Text = plakalar[i];
                    a2Button.BackColor = Color.Red;
                }
                else if (konum[i] == a3Button.Text)
                {
                    a3Button.Text = plakalar[i];
                    a3Button.BackColor = Color.Red;
                }
                else if (konum[i] == a4Button.Text)
                {
                    a4Button.Text = plakalar[i];
                    a4Button.BackColor = Color.Red;
                }
                else if (konum[i] == a5Button.Text)
                {
                    a5Button.Text = plakalar[i];
                    a5Button.BackColor = Color.Red;
                }
                else if (konum[i] == b1Button.Text)
                {
                    b1Button.Text = plakalar[i];
                    b1Button.BackColor = Color.Red;
                }
                else if (konum[i] == b2Button.Text)
                {
                    b2Button.Text = plakalar[i];
                    b2Button.BackColor = Color.Red;
                }
                else if (konum[i] == b3Button.Text)
                {
                    b3Button.Text = plakalar[i];
                    b3Button.BackColor = Color.Red;
                }
                else if (konum[i] == b4Button.Text)
                {
                    b4Button.Text = plakalar[i];
                    b4Button.BackColor = Color.Red;

                }
                else if (konum[i] == b5Button.Text)
                {
                    b5Button.Text = plakalar[i];
                    b5Button.BackColor = Color.Red;
                }
                else if (konum[i] == c1Button.Text)
                {
                    c1Button.Text = plakalar[i];
                    c1Button.BackColor = Color.Red;
                }
                else if (konum[i] == c2Button.Text)
                {
                    c2Button.Text = plakalar[i];
                    c2Button.BackColor = Color.Red;
                }
                else if (konum[i] == c3Button.Text)
                {
                    c3Button.Text = plakalar[i];
                    c3Button.BackColor = Color.Red;
                }
                else if (konum[i] == c4Button.Text)
                {
                    c4Button.Text = plakalar[i];
                    c4Button.BackColor = Color.Red;
                }
                else if (konum[i] == c5Button.Text)
                {
                    c5Button.Text = plakalar[i];
                    c5Button.BackColor = Color.Red;
                }
                else if (konum[i] == d1Button.Text)
                {
                    d1Button.Text = plakalar[i];
                    d1Button.BackColor = Color.Red;
                }
                else if (konum[i] == d2Button.Text)
                {
                    d2Button.Text = plakalar[i];
                    d2Button.BackColor = Color.Red;
                }
                else if (konum[i] == d3Button.Text)
                {
                    d3Button.Text = plakalar[i];
                    d3Button.BackColor = Color.Red;
                }
                else if (konum[i] == d4Button.Text)
                {
                    d4Button.Text = plakalar[i];
                    d4Button.BackColor = Color.Red;
                }
                else if (konum[i] == d5Button.Text)
                {
                    d5Button.Text = plakalar[i];
                    d5Button.BackColor = Color.Red;
                }
            }
        }

        AracBilgileriForm form = new AracBilgileriForm();

        private void a5Button_Click(object sender, EventArgs e)
        {

            if (a5Button.BackColor == Color.Red)
            {
                bilgi = "A5";
                form.Show();
                this.Hide();
            }

        }

        private void b1Button_Click(object sender, EventArgs e)
        {
            if (b1Button.BackColor == Color.Red)
            {
                bilgi = "B1";
                form.Show();
                this.Hide();
            }
        }

        private void b2Button_Click(object sender, EventArgs e)
        {
            if (b2Button.BackColor == Color.Red)
            {
                bilgi = "B2";
                form.Show();
                this.Hide();
            }
        }

        private void b3Button_Click(object sender, EventArgs e)
        {
            if (b3Button.BackColor == Color.Red)
            {
                bilgi = "B3";
                form.Show();
                this.Hide();
            }
        }

        private void b4Button_Click(object sender, EventArgs e)
        {
            if (b4Button.BackColor == Color.Red)
            {
                bilgi = "B4";
                form.Show();
                this.Hide();
            }
        }

        private void b5Button_Click(object sender, EventArgs e)
        {
            if (b5Button.BackColor == Color.Red)
            {
                bilgi = "B5";
                form.Show();
                this.Hide();
            }
        }

        private void a1Button_Click(object sender, EventArgs e)
        {
            if (a1Button.BackColor == Color.Red)
            {
                bilgi = "A1";
                form.Show();
                this.Hide();
            }
        }

        private void a2Button_Click(object sender, EventArgs e)
        {
            if (a2Button.BackColor == Color.Red)
            {
                bilgi = "A2";
                form.Show();
                this.Hide();
            }
        }

        private void a3Button_Click(object sender, EventArgs e)
        {
            if (a3Button.BackColor == Color.Red)
            {
                bilgi = "A3";
                MessageBox.Show(bilgi);
                form.Show();
                
                this.Hide();
            }
        }

        private void a4Button_Click(object sender, EventArgs e)
        {
            if (a4Button.BackColor == Color.Red)
            {
                bilgi = "A4";
                form.Show();
                this.Hide();
            }
        }

        private void d2Button_Click(object sender, EventArgs e)
        {
            if (d2Button.BackColor == Color.Red)
            {
                bilgi = "D2";
                form.Show();
                this.Hide();
            }
        }

        private void d1Button_Click(object sender, EventArgs e)
        {
            if (d1Button.BackColor == Color.Red)
            {
                bilgi = "D1";
                form.Show();
                this.Hide();
            }
        }

        private void d3Button_Click(object sender, EventArgs e)
        {
            if (d3Button.BackColor == Color.Red)
            {
                bilgi = "D3";
                form.Show();
                this.Hide();
            }
        }

        private void d4Button_Click(object sender, EventArgs e)
        {
            if (d4Button.BackColor == Color.Red)
            {
                bilgi = "D4";
                form.Show();
                this.Hide();
            }
        }

        private void d5Button_Click(object sender, EventArgs e)
        {
            if (d5Button.BackColor == Color.Red)
            {
                bilgi = "D5";
                form.Show();
                this.Hide();
            }
        }

        private void c1Button_Click(object sender, EventArgs e)
        {
            if (c1Button.BackColor == Color.Red)
            {
                bilgi = "C1";
                form.Show();
                this.Hide();
            }
        }

        private void c2Button_Click(object sender, EventArgs e)
        {
            if (c2Button.BackColor == Color.Red)
            {
                bilgi = "C2";
                form.Show();
                this.Hide();
            }
        }

        private void c3Button_Click(object sender, EventArgs e)
        {
            if (c3Button.BackColor == Color.Red)
            {
                bilgi = "C3";
                form.Show();
                this.Hide();
            }
        }

        private void c4Button_Click(object sender, EventArgs e)
        {
            if (c4Button.BackColor == Color.Red)
            {
                bilgi = "C4";
                form.Show();
                this.Hide();
            }
        }

        private void c5Button_Click(object sender, EventArgs e)
        {
            if (c5Button.BackColor == Color.Red)
            {
                bilgi = "C5";
                form.Show();
                this.Hide();
            }
        }


    }
}
