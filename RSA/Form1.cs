using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA
{
    public partial class RSA : Form
    {
        public RSA()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Txt_4.Text = "";
            Txt_5.Text = "";
            Txt_6.Text = "";
            Txt_7.Text = "";
            Txt_8.Text = "";
            Txt_9.Text = "";
            String  value3;
            value3 = textBox3.Text;

            int Asal1, Asal2;
            //Asal1 = Convert.ToInt32(value1);
            //Asal2 = Convert.ToInt32(value2);

            Asal1 = 3;
            Asal2 = 37;
            
            KeyMani nesne = new KeyMani(Asal1, Asal2);
            int[] dizi = nesne.KeyUret();
            List<char> harflistesi = new List<char>();
            String donecekmesaj = "";

            String mesaj="";
            //Crypto metin = new Crypto(value3, dizi);
            Encrypto sifrelimetin = new Encrypto(value3,dizi,this);
            //mesaj=metin.sifrele();
            //metin.metincozme(mesaj,5,29,111);
            harflistesi=sifrelimetin.metincozme(mesaj,111,29,5);

            for (int i = 0; i < harflistesi.Count; i++)
            {
                donecekmesaj += harflistesi[i];
            }
           // MessageBox.Show(donecekmesaj);
            textBox5.Text = donecekmesaj;

            textBox4.Text = dizi[0] + " " + dizi[1] + " " + dizi[2];


        }
    }
}
