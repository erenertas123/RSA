using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA
{
    class Crypto
    {
        String metin = "";
        int[] dizi = new int[3];
        RSA Formnesnesi;
        public Crypto(String metin,int [] dizi,RSA Formnesnesi) {
            this.metin = metin;
            this.dizi = dizi;
            this.Formnesnesi = Formnesnesi;
        }
        int Lclear = 0;

        public String sifrele() {

            Formnesnesi.Txt_1.Text = metin;
            String message = "", temp = "",crypto="";
            Char c = ' ';
            int a = 0, bas = 0;

            for (int i = 0; i < metin.Length; i++)
            {
                c = metin[i];
                a = System.Convert.ToInt32(c);
                message = a.ToString();
                if (message.Length < 3) {
                    message = 0 + message;
                }
              
                temp += message;
            }
            //MessageBox.Show(temp);
            Formnesnesi.Txt_2.Text = temp;
             int space = 0;
             bas = basamak(dizi[0]);
             Lclear = bas - 1;           

            for (int i = 0; i < temp.Length; i++)
            {  
                if (space%Lclear==0 && space!=0) {
                    crypto += " ";
                    space = 0;
                }
                crypto += temp[i];
                space++;
            }

            if (crypto.Length%Lclear!=0) {
                crypto=crypto+0;
            }

            // MessageBox.Show(crypto);
            //MessageBox.Show(crypto.Length.ToString());
            
            return crypto;

        }
        public List<String> modalma(String mesaj,int e,int n) {
            String altmetin = "",holder="";
            int sayac = 1;
            int Lclear = basamak(n)-1;

            //for (int i = 0; i < mesaj.Length; i++)
            //{
            //    Formnesnesi.Txt_7.Text = Formnesnesi.Txt_7.Text + mesaj[i];
            //}
            //MessageBox.Show(mesaj.Length.ToString());

            for (int i = 0; i < mesaj.Length; i++)
            {
                altmetin = altmetin + mesaj[i];

            }
            Formnesnesi.Txt_3.Text = altmetin;

            //MessageBox.Show(altmetin);        //Eski haline getirdik


            
            List<int> list = new List<int>();
            String sayi = "",tutucu="";
            int number = 0;
            sayac = 1;

            for (int i = 0; i < altmetin.Length; i++)
            {
                if (i%basamak(n)==2) {
                    sayi = tutucu;
                    number = Convert.ToInt32(sayi);
                    Formnesnesi.Txt_4.Text = Formnesnesi.Txt_4.Text + number;
                    //MessageBox.Show("Sayi"+sayi);
                    list.Add(number);
                    tutucu = "";
                }
                else
                {
                    tutucu = tutucu + altmetin[i];
                    //MessageBox.Show(altmetin[i].ToString());

                    if (i==altmetin.Length-1) {
                        sayi = tutucu;
                        number = Convert.ToInt32(sayi);
                        Formnesnesi.Txt_4.Text = Formnesnesi.Txt_4.Text +sayi;
                        //MessageBox.Show("Sayi" + sayi);
                        list.Add(number);
                    }
                }

            }

            for (int i = 0; i < list.Count; i++)
            {
                Formnesnesi.Txt_7.Text = Formnesnesi.Txt_7.Text + list[i] + " ";
            }

            //MessageBox.Show(list.Count.ToString());

            //MessageBox.Show(n.ToString());

            double cryptodeger = 0;String eklenme = "";
            List<int> cipherlistesi = new List<int>();
            List<String> yollanacakmesaj = new List<string>();
            //MessageBox.Show(list.Count.ToString());
            for (int i = 0; i < list.Count; i++)
            {
                cryptodeger = Math.Pow(list[i], e);
                cryptodeger = cryptodeger % n;
                cipherlistesi.Add(Convert.ToInt16(cryptodeger));
                cryptodeger = 0;
            }
            for (int i = 0; i < cipherlistesi.Count; i++)
            {
                MessageBox.Show(basamak(cipherlistesi[i]).ToString());
                if (basamak(cipherlistesi[i])<basamak(n)) {
                    for (int j = basamak(cipherlistesi[i]); j < basamak(n); j++)
                    {
                        eklenme = "0" + eklenme;
                    }
                    eklenme = eklenme + cipherlistesi[i];
                    yollanacakmesaj.Add(eklenme); 
                }
                else
                {
                    yollanacakmesaj.Add(cipherlistesi[i].ToString());
                }
                eklenme = "";
            }
            //for (int i = 0; i < yollanacakmesaj.Count; i++)
            //{
            //    Formnesnesi.Txt_4.Text = Formnesnesi.Txt_4.Text + yollanacakmesaj[i];
            //}
            for (int i = 0; i < yollanacakmesaj.Count; i++)
            {
                Formnesnesi.Txt_9.Text = Formnesnesi.Txt_9.Text + yollanacakmesaj[i]+" ";
            }
            return yollanacakmesaj;

        }
        
        public int basamak(int n) {
            int basamak = 0;
            if (n == 0) { basamak = 1; return basamak; }
            while (n>=1)
            {
               
                basamak++;
                n = n / 10;
            }
           
            return basamak;
        }

    }
}
