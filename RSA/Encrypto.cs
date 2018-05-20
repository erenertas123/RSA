using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA
{
    public class Encrypto
    {
        int[] dizi = new int[3];
        String value = "";
        RSA RSAnesnesi;
        public Encrypto(String value,int []dizi,RSA RSAnesnesi){
            this.value = value;
            this.dizi = dizi;
            this.RSAnesnesi = RSAnesnesi;
        }

        public List<char> metincozme(String mesaj, int n, int d, int e)
        {
            
            String gelenmesaj;
            Crypto Cryptonesnesi = new Crypto(value, dizi,RSAnesnesi);
            List<String> cozulecekmetin = new List<String>();
            List<int> altmetinler = new List<int>();
            List<double> cozulmusmetin = new List<double>();

            gelenmesaj = Cryptonesnesi.sifrele();

            cozulecekmetin = Cryptonesnesi.modalma(gelenmesaj, e, n);

            //for (int i = 0; i < cozulecekmetin.Count; i++)
            //{
            //    RSAnesnesi.Txt_4.Text = RSAnesnesi.Txt_4.Text + cozulecekmetin[i];
            //}

            //MessageBox.Show(gelenmesaj);

            for (int i = 0; i < cozulecekmetin.Count; i++)
            {
                altmetinler.Add(Convert.ToInt32(cozulecekmetin[i]));
            }
            for (int i = 0; i < altmetinler.Count; i++)
            {
                RSAnesnesi.Txt_5.Text = RSAnesnesi.Txt_5.Text + altmetinler[i].ToString()+" ";
            }

            //for (int i = 0; i < altmetinler.Count; i++)
            //{
            //    MessageBox.Show(altmetinler[i].ToString());
            //}

            List<double> ikilisistem = new List<double>();
            List<double> fragment = new List<double>();
            List<double> tutucu = new List<double>();
            double gecici = 0,son=1;
            double sayi = 0,temp=1,parca=1;
            gecici = Convert.ToDouble(d);
            ikilisistem = ikili(d);

            for (int i = 0; i < altmetinler.Count; i++)
            {
                sayi = altmetinler[i];
                //MessageBox.Show(sayi.ToString());
                for (int j = 0; j < ikilisistem.Count; j++)
                {
                    //MessageBox.Show(sayi.ToString());
                    if (ikilisistem[j] > 4)
                    {
                        gecici = ikilisistem[j]/2;
                        for (int k = 0; k < gecici; k++)
                        {   
                            temp = Math.Pow(sayi, 2) % n;
                            parca *= temp;
                        }
                        parca = parca % n;
                        //MessageBox.Show(parca.ToString());
                        fragment.Add(parca);
                        parca = 1;
                    }
                    else
                    {
                        gecici = ikilisistem[j];
                        for (int k = 0; k < 1; k++)
                        {
                            temp = Math.Pow(sayi, ikilisistem[j]) % n;
                            parca *= temp;
                        }
                        parca = parca % n;
                       // MessageBox.Show(parca.ToString());
                        fragment.Add(parca);
                        parca = 1;
                        temp = 1;gecici = 1;
                    } 
                }
                for (int a = 0; a < fragment.Count; a++)
                {
                    son *= fragment[a];
                }
                son = son % n;
                //MessageBox.Show(son.ToString());
                tutucu.Add(son);
                son = 1;
                fragment.Clear();

            }
            for (int i = 0; i < tutucu.Count; i++)
            {
                RSAnesnesi.Txt_8.Text = RSAnesnesi.Txt_8.Text + tutucu[i];
            }
           
            //for (int m = 0; m < tutucu.Count; m++)
            //{
            //    MessageBox.Show(altmetinler[m] + " " + tutucu[m].ToString());
            //}

            //MessageBox.Show(ikilisistem.Count.ToString());

            //for (int i = 0; i < tutucu.Count; i++)
            //{
            //    MessageBox.Show(tutucu[i].ToString());
            //}

            String toplananmesaj = "";

            for (int i = 0; i < tutucu.Count; i++)
            {
                //MessageBox.Show(tutucu[i].ToString());
                if (basamak(Convert.ToInt32(tutucu[i]))==1) { 
                    toplananmesaj = toplananmesaj + "0" + tutucu[i].ToString();
                    
                }
                else
                {
                    toplananmesaj  += tutucu[i];
                    //MessageBox.Show(toplananmesaj);
                }
                
            }
            //MessageBox.Show(toplananmesaj);
            

            int basamaksayısı=basamak(n);
            List<string> parcalananmesaj = new List<string>();
            String parcalimesaj="",geridonenmesaj="",convert=" ";
            int space = 0;
            List<char> charlistesi = new List<char>();
            char q = ' ';
            int tut = 0;
            for (int i = 0; i < toplananmesaj.Length; i++)
            {
                geridonenmesaj = geridonenmesaj + toplananmesaj[i];
            }
            

            //MessageBox.Show("Toplanan mesaj: "+geridonenmesaj.ToString());
            //for (int i = 0; i < geridonenmesaj.Length; i++)
            //{
            //    MessageBox.Show("Geri donen " + geridonenmesaj);
            //}

            for (int i = 0; i < geridonenmesaj.Length; i++)                                                 //     --------->>> Sorunlu 
            {
                if (space%(basamaksayısı)==0)
                {
                   // MessageBox.Show(parcalimesaj.ToString());             // basamak sayısına bölünmüş metin
                    if (parcalimesaj.Any()) {
                        convert = parcalimesaj; 
                        tut = Int32.Parse(convert);
                        q = Convert.ToChar(tut);
                        charlistesi.Add(q);
                        //MessageBox.Show(q.ToString());            // Basamak Sayısına bölünmüş sayı dizesinin harf karşıtı
                    }    
                    parcalimesaj = " ";
                    space = 0;
                }
                parcalimesaj = parcalimesaj + geridonenmesaj[i];
                space++;
            }
            for (int i = 0; i < charlistesi.Count; i++)
            {
                RSAnesnesi.Txt_6.Text = RSAnesnesi.Txt_6.Text + charlistesi[i].ToString();
            }


            return charlistesi;

        }

        public List<double> ikili(int d) {
            double gecici = 0,depo=0;
            double temp = 0;
            int sayac = 0;
            List<double> ikilisistem = new List<double>();
            gecici = Convert.ToDouble(d);

            while (gecici > 0)
            {
                depo = Math.Pow(2, sayac);
                if (depo > gecici)
                {
                    temp = sayac - 1;
                    ikilisistem.Add(Math.Pow(2,temp));
                    gecici = gecici - Math.Pow(2, temp);
                    sayac = 0;
                }
                else
                {
                    sayac++;
                }
            }
            //MessageBox.Show(ikilisistem.Count.ToString()+"+");
            //for (int i = 0; i < ikilisistem.Count; i++)
            //{
            //    MessageBox.Show(ikilisistem[i].ToString()+" Burası karışık");
            //}
            return ikilisistem;
        }

        public int basamak(int n)
        {
            int basamak = 0;
            while (n >= 1)
            {
                basamak++;
                n = n / 10;
            }
            return basamak;
        }


    }
}
