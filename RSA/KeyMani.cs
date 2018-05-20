using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA
{
    class KeyMani
    {
        int Asal1, Asal2;
        public KeyMani(int Asal1, int Asal2) {
            this.Asal1 = Asal1;
            this.Asal2 = Asal2;
        }

        Random rnd = new Random();

        public int[] KeyUret() {
            int [] dizi = new int[3];
            int n = 0,q=0,e=0,d=0;

            n = Asal2 * Asal1;
            q=((Asal1-1)*(Asal2-1));
            e=Oklid(q);
            d = GelismisOklid(q,e);

            dizi[0] = n;
            dizi[1] = e;
            dizi[2] = d;

            return dizi;
        }

        public int Oklid(int q) {
            int e = 0,kalan=0,ilk=q;
            e = rnd.Next(1,q);
            int tutulane = e;
            while (kalan!=1) {
                kalan = q % e;
                q = e;
                e = kalan;
                //MessageBox.Show(q.ToString()+" "+e.ToString());
                if (kalan==0) {
                    e = rnd.Next(1, ilk);
                    tutulane = e;
                    q = ilk;
                }
                if (kalan==1) {
                    break;
                }
            }
            //MessageBox.Show(q.ToString() + " "+e.ToString());

            return tutulane;

        }

        public int GelismisOklid(int q,int e) {
            int d = 0;
            d = rnd.Next(1,q);
            //MessageBox.Show(e.ToString()+" "+q.ToString());
            while ((e*d)%q!=1) {
                d = rnd.Next(1,q);   
            }
            //MessageBox.Show(test(q,d,e).ToString());

            return d;
        }

        public bool test(int q,int d,int e) {
            int sonuc = 0;
            sonuc = (e * d) % q;
            if (sonuc==1) {
                return true;
            }
            else
            {
                return false;
            }

        }



    }
}
