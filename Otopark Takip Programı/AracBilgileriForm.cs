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
    public partial class AracBilgileriForm : Form
    {
        public AracBilgileriForm()
        {
            InitializeComponent();
        }

        int deger = 1; string cumle;
        public static string[] kullanicilar = new string[20];public static int boyut; int r = 0;
        public static string[] konum = new string[20];
        public static string[] plakalar = new string[20];

        private void AracBilgileriForm_Load(object sender, EventArgs e)
        {
  
                boyut = Form1.boyut;

                for (int i = 0; i < boyut; i++)
                {
                    kullanicilar[i] = Form1.kayitlar[i];
                }

            oku();
            textBox7.Text = "/" + boyut;

            if (AracYerleri.bilgi != null)
            {
                cumle = AracYerleri.bilgi;
                deger = yazdir()+1;
                bilgileriDoldur(yazdir());
                
                textBox7.Text = deger + "/" + boyut;
            }

        }

        int yazdir()
        {
            for (int i = 0; i < boyut; i++)
            {
                if(cumle == konum[i])
                {
                    return i;
                }
            }
            return 0;
        }

        bool ileri = false, geri = false, sil = false;
        private void button4_Click(object sender, EventArgs e)
        {
            if (deger <= boyut)
            {
                ileri = true;
                sil = true;
                if (ileri == true && geri == true)
                {
                    geri = false;
                    deger += 2;
                }
                textBox7.Text = deger + "/" + boyut;
                bilgileriDoldur(deger-1);
                deger++;
                button3.Enabled = true;
            }
            else
            {
                deger--;
                ileri = false;
                geri = false;
                MessageBox.Show("Son Araca Ulaştınız." , "Harmaner" , MessageBoxButtons.OK , MessageBoxIcon.Information);
                textBox7.Text = deger-- + "/" + boyut;
                button4.Enabled = false;
                
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (deger >= 1)
            {
                sil = true;
                geri = true;
                if (ileri == true && geri == true)
                {
                    ileri = false;
                    deger -= 2;
                }
                textBox7.Text = deger + "/" + boyut;
                bilgileriDoldur(deger-1);
                deger--;
                button4.Enabled = true;
            }
            else
            {
                geri = false;
                deger++;
                MessageBox.Show("İlk Araca Ulaştınız." , "Harmaner" , MessageBoxButtons.OK , MessageBoxIcon.Information);
                    textBox7.Text = deger++ + "/" + boyut;
                    button3.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sil = true;
            button4.Enabled = true;
            button3.Enabled = false;
            ileri = false; geri = false;
            deger = 1;
            bilgileriDoldur(deger-1);
            textBox7.Text = deger++ + "/" + boyut;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sil = true;
            button3.Enabled = true;
            button4.Enabled = false;
            ileri = false; geri = false;
            deger = boyut;
            bilgileriDoldur(deger-1);
            textBox7.Text = deger-- + "/" + boyut;
        }

        void degerleriBosalt()
        {
            maskedTextBox1.Text = ""; ;
            textBox1.Text = "";
            textBox2.Text = "";
            maskedTextBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Text = "";
            label10.Text = "";

        }
        public void oku()
        {
            Array.Resize(ref konum, boyut);
                for (int i = 0; i < boyut; i++)
                {                   
                    char[] array = kullanicilar[i].ToCharArray();
                    konum[i] = array[array.Length - 2].ToString() + array[array.Length - 1].ToString();
                    r++;

                }          
            
        }
  

        public void bilgileriDoldur(int bilgi)
        {

            int islem = 1;
            degerleriBosalt();
            Array.Resize(ref kullanicilar, boyut +1);
            char[] array = kullanicilar[bilgi].ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '#')
                {
                    islem++;
                    continue;
                }
                switch (islem)
                {
                    case 1:
                        label10.Text = label10.Text + array[i];
                        break;
                    case 2:
                        maskedTextBox1.Text = maskedTextBox1.Text + array[i];
                        break;
                    case 3:
                        textBox1.Text += array[i];
                        break;
                    case 4:
                        textBox2.Text += array[i];
                        break;
                    case 5:
                        maskedTextBox2.Text += array[i];
                        break;
                    case 6:
                        textBox4.Text += array[i];
                        break;
                    case 7:
                        textBox3.Text += array[i];
                        break;
                    case 8:
                        textBox5.Text += array[i];
                        break;
                    case 9:
                        textBox6.Text += array[i];
                        break;
                    case 10:
                        comboBox1.Text += array[i];
                        break;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AracYerleri.formGecis = true;
            AracYerleri pencere = new AracYerleri();
            Array.Resize(ref konum, boyut);
            Array.Resize(ref AracYerleri.konum, boyut+1);
            AracYerleri.boyut = boyut;

            for (int i = 0; i < boyut; i++ )
            {
                AracYerleri.kullanicilar[i] = kullanicilar[i];
                AracYerleri.konum[i] = konum[i];
            }
            pencere.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
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

        private void aracGirisi_Click(object sender, EventArgs e)
        {
            try
            {
                bool yerKontrol = false, dolulukKontrol = false;
                for (int i = 0; i < r; i++)
                {
                    if (comboBox1.Text == konum[i])
                    {
                        MessageBox.Show(konum[i] + " Konumumuz Doludur, Lütfen Araç Yerleri Menüsünden Kontrol Ediniz." , "Otopark Takip" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                        yerKontrol = true;
                    }
                }

                if (boyut >= 20)
                {
                    MessageBox.Show("Özür Dileriz Parkımızda Boş Yer Bulunmamaktadır, İlginiz İçin Teşekkür Ederiz." , "Otopark Takip" , MessageBoxButtons.OK , MessageBoxIcon.Information);
                    dolulukKontrol = true;
                }

                if (yerKontrol == false && dolulukKontrol == false)
                {
                    Array.Resize(ref kullanicilar, boyut + 1);
                    Array.Resize(ref konum, boyut + 1);
                     kullanicilar[boyut] = (boyut + 1) + "#" + maskedTextBox1.Text + "#" +
                     textBox1.Text + "#" + textBox2.Text + "#" + maskedTextBox2.Text + "#" +
                     textBox4.Text + "#" + textBox3.Text + "#" + textBox5.Text + "#" +
                     textBox6.Text + "#" + comboBox1.Text;
                   
                    konum[boyut-1] = comboBox1.Text;
                    r++;
                    boyut++;
                    MessageBox.Show("Araç Girişi Başarılı.", "Otopark Kontrol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox7.Text = "/" + boyut;
                    sil = true; 
                }
               
            }
            catch (FormatException)
            {
                MessageBox.Show("Eksik Yada Hatali Bilgi Girdiniz." , "Otopark Takip" , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        string plaka;
        private void aracCikisi_Click(object sender, EventArgs e)
        {
            plaka = textBox4.Text;
            if (sil)
            {
                boyut--;
                for (int i = deger-2 ; i < boyut; i++)
                {
                    
                      kullanicilar[i] = kullanicilar[i + 1];
                 

                }

                    Array.Resize(ref kullanicilar, boyut); deger++;
                groupBox3.Enabled = true;
            }
            else
            {
                MessageBox.Show("Lütfen Çıkış Yapacak Kullanıcıyı Seçin.", "Otopark Takip" , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void degis(int bilgi)
        {
            bool c = false;
            char[] array = kullanicilar[bilgi].ToCharArray();

            for (int i = 0; array[i] != '#'; i++)
            {
                if (c)
                {
                    array[i-1] = Convert.ToChar(array[i] - 1);
                    array[i] = Convert.ToChar(array[i] + 1);
                }
                c = true;
                array[i] = Convert.ToChar(array[i] + 1); 
            }
            MessageBox.Show(Convert.ToString(array));
            kullanicilar[bilgi] = array.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int hesap = 0;

            if (checkBox1.Checked == true)
                hesap +=  10;
            if (checkBox2.Checked == true)
                hesap += 10;

            switch(comboBox2.SelectedIndex)
            {
                case 1 :
                    hesap += 2;
                    break;
                case 2 :
                    hesap += 3;
                    break;
                case 3 :
                    hesap += 5;
                    break;
                case 4 :
                    hesap += 10;
                    break;                  
                case 5 :
                    hesap += 15;
                    break;
                case 6:
                    hesap += 25;
                    break;
            }
            MessageBox.Show(plaka + " " + hesap + " TL Ödeme İçin Teşekkür Ederiz.\n Yine Bekleriz, Güle Güle", "Otopark Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            comboBox2.Text = "";
            groupBox3.Enabled = false;
            bilgileriDoldur(--deger);

            textBox7.Text = deger + "/" + boyut;
            
        }





    }
}
