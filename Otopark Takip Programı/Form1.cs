using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Otopark_Takip_Programı
{
    public partial class Form1 : Form
    {
       public static string[] kayitlar = new string[20];
       public static int boyut = 0;
       public static bool kontrol = false,kaydetKontrol = false;
       public static string yol;
       


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (kontrol == true)
            {
                MessageBox.Show("Dosya Seçmiş Bulunmaktasınız !", "Otopark Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                
                openFileDialog1.ShowDialog();
                yol = openFileDialog1.FileName;
                openFileDialog1.RestoreDirectory = true;
                dosyadanOku(yol);
                kontrol = true;
            }
            
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (kontrol == true)
            {

                if (AracBilgileriForm.kullanicilar[0] == null)
                {
                    MessageBox.Show("Sistemede Hiçbir Değişiklik Yapmadınız !", "Otopark Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    kaydetKontrol = true;
                }
                else
                {

                    kaydetKontrol = true;
                    numaraKontrol();
                    dosyayaYaz();
                    boyut = d;
                    MessageBox.Show("Dosya Başarıyla Kaydedildi.", "Otopark Takip", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Lütfen Önce Dosya Okuma İşlemini Gerçekleştiriniz.", "Otopark Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (kontrol == true)
            {
                
                AracBilgileriForm form = new AracBilgileriForm();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Lütfen Önce Dosya Okuma İşlemini Gerçekleştiriniz.", "Otopark Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (kontrol == true)
            {
                AracYerleri.formGecis = false;
                AracYerleri form = new AracYerleri();

                AracYerleri.boyut = boyut;
                for (int i = 0; i < boyut; i++)
                {
                    AracYerleri.kullanicilar[i] = kayitlar[i];
                }

                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Lütfen Önce Dosya Okuma İşlemini Gerçekleştiriniz.", "Otopark Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (kontrol == true)
            {
                if (kaydetKontrol)
                {
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Bilgiler Kaydedilmedi Lütfen Programı Kapatmadan Önce Bilgileri Kaydediniz !" , "Otopark Takip Programı" , MessageBoxButtons.OK , MessageBoxIcon.Information);
                }
            }
            else
            {
                Application.Exit();
            }

        }

        void dosyadanOku(string dizin)
        {
            FileStream fs = new FileStream(dizin, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);
            string satir = sw.ReadLine();
            while (satir != null)
            {
                kayitlar[boyut] = satir;
                satir = sw.ReadLine();
                boyut++;

            }
            sw.Close();
            fs.Close();

            Array.Resize(ref kayitlar, boyut);
            
        }
        int d = 0;

        void sil()
        {
            System.IO.File.Delete(yol);
        }
        void numaraKontrol()
        {
            Array.Resize(ref kayitlar , boyut +1);
            int adet = 0;
            for (int i = 0; i < boyut; i++)
            {
                char[] array = kayitlar[i].ToCharArray();
                adet++;
                
                if (adet >= 10)
                {
                    if (adet == 10)
                    {

                    }
                    else
                    {
                        label3.Text = (adet - 10).ToString();
                        array[0] = '1';
                        array[1] = Convert.ToChar(label3.Text);
                        label3.Text = "";
                    }
                }
                else
                {                
                        label3.Text = (i + 1).ToString();
                        array[0] = Convert.ToChar(label3.Text);
                        label3.Text = "";

                }


                for (int k = 0; k < array.Length; k++)
                {
                    label2.Text = label2.Text + array[k];
                }

                kayitlar[i] = label2.Text;
                label2.Text = "";
                    
            }
        }


      void dosyayaYaz()
      {
          sil();
          FileStream fs = new FileStream(yol, FileMode.OpenOrCreate, FileAccess.Write);

          StreamWriter sw = new StreamWriter(fs);

          Array.Resize(ref kayitlar, AracBilgileriForm.kullanicilar.Length);
              for (int i = 0; i < boyut; i++)
              {
                  
                      kayitlar[i] = AracBilgileriForm.kullanicilar[i];
                      sw.WriteLine(kayitlar[i]);
                      d++;
                  
              }

          sw.Flush();
          sw.Close();
          fs.Close();

      }
   
    }
}
