using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

namespace Poligon_3R
{
    class Program
    {
        class Ravan
        {
            public static double ugao_duz(Duz a, Duz b)
            {
                Vektor prvi = new Vektor(a.A, a.B);
                return 0;
            }
            
            public static int Sis(Duz a, Tacka C, Tacka D)
            {
                Vektor AB = new Vektor(a.A, a.B);
                Vektor AC = new Vektor(a.A, C);
                double a_C = Vektor.vektorski(AB, AC);
                Vektor AD = new Vektor(a.A, D);
                double a_D = Vektor.vektorski(AB, AD);
                /* if (a_C * a_D > 0) return true;
                else return false;*/
                return Math.Sign(a_C * a_D);
            }
        }
        class Vektor
        {
		// sa dva reda je 1.71 i ona je pobedila - postaje master
            public double x;
            public double y;
            public Vektor(double _x, double _y)
            {
		// 
                x = _x;
                y = _y;
            }
            public Vektor(Duz a)
            {
                Tacka A = a.A;
                Tacka B = a.B;
                x = B.x - A.x;
                y = B.y - A.y;
            }
            public Vektor(Tacka A, Tacka B)
            {
                x = B.x - A.x;
                y = B.y - A.y;
            }
            static public Vektor jedinicni_i()
            {
                Vektor x_osa = new Vektor(1, 0);
                return x_osa;
            }
            public static double vektorski(Vektor a, Vektor b)
            {
                return a.x * b.y - b.x * a.y;
            }
            public static double skalarni(Vektor a, Vektor b)
            {
                return 0;
            }
            public static double Ugao(Vektor a, Vektor b)
            {
                double ugao_a = Math.Atan2(a.y, a.x) * 180 / Math.PI;
                double ugao_b = Math.Atan2(b.y, b.x) * 180 / Math.PI;

                // Console.WriteLine("u1=" + ugao_a + " u2=" + ugao_b );

                if (ugao_b - ugao_a < -180) return ugao_b - ugao_a + 360;
                if (ugao_b - ugao_a > 180) return ugao_b - ugao_a - 360;
                return ugao_b - ugao_a;
            }
        }
        class Duz
        {
            public Tacka A;
            public Tacka B;
            public Duz(Tacka _A, Tacka _B)
            {
                A = _A;
                B = _B;
            }
            public bool Sece(Duz b){
                if ((Ravan.Sis(this, b.A, b.B) == 1) ||  (Ravan.Sis(b, A, B) == 1) ) return false;
            	else return true;
            }
        }
        class Tacka
        {
            public double x;
            public double y;
            public Tacka(double _x, double _y)
            {
                x = _x;
                y = _y;
            }
            public Tacka(Tacka _a)
            {
                x = _a.x;
                y = _a.y;
            }
        }
        class Poligon
        {
            Tacka[] Temena;

            public Poligon(Tacka[] Niz_temena)
            {
                Temena = new Tacka[Niz_temena.Length];
                for (int i = 0; i < Temena.Length; i++)
                {
                    Temena[i] = new Tacka(Niz_temena[i]);
                }
            }
            public double Povrsina()
            {
                // Domaci 1 - uradi povrsinu
		// hoce li neko ovo uraditi?

                return 0;
            }
            public double Obim()
            {
                // Domaci 2 - uradi obim

                return 0;
            }
            public void Stampaj()
            {
                Console.WriteLine("Poligon sa temenima:");
                for (int i = 0; i < Temena.Length; i++)
                {
                    Console.WriteLine("T["+i+"]="+Temena[i].x + ", "+Temena[i].y);
                }
                // Domaci 3 - stampaj sva temena
            }
            public bool Prost()
            {
                // domaci 4 - proveri da li je prost
                int Br_temena;
                Br_temena = Temena.Length;
                Duz[] Stranice = new Duz[Br_temena];
                for (int i = 0; i < Br_temena - 1; i++)
                {
                    Stranice[i] = new Duz(Temena[i], Temena[i + 1]);
                }
                Stranice[Br_temena - 1] = new Duz(Temena[Br_temena - 1], Temena[0]);
                // Da li se stranice seku: s0 
                for (int i = 0; i < Br_temena - 2; i++)
                {
                    for (int j = i+2; j < Br_temena - (i==0 ? 1 : 0); j++)
			        {
                        // ovo moze i ovako da izgleda: if (Duz.Sece(Stranice[i], Stranice[j])) return false;
                        // samo onda metoda mora da bude drugacije deklarisana
                        if (Stranice[i].Sece(Stranice[j]))
                        {
                            Console.WriteLine("problematicno " + i + ", " + j);
                            return false;
                        }
			        }
                }
                return true;
            }
            public Poligon Omotac()
            {
                // Domaci 5 - formiraj konveksni omotac
               
                List<Tacka> Omotac_lista = new List<Tacka>();
                
                List<Tacka> Kandidati = new List<Tacka>();
                for (int i = 0; i < Temena.Length; i++)
                {
                    Kandidati.Add(Temena[i]);
                }

                //trazimo ekstremnu tacku
                double minx = Kandidati[0].x;
                double miny = Kandidati[0].y;
                int MinTackaIndeks = 0;
                for (int i = 1; i < Kandidati.Count; i++)
                {
                    if (Kandidati[i].x <= minx)
                        if (Kandidati[i].y <= miny)
                        {
                            minx = Kandidati[i].x;
                            miny = Kandidati[i].y;
                            MinTackaIndeks = i;
                        }
                }
                // nasli smo ekstremnu tacku 
                Console.WriteLine("ekstremna tacka" + MinTackaIndeks  + ":" + Kandidati[MinTackaIndeks].x + " " + Kandidati[MinTackaIndeks].y);
                Omotac_lista.Add(Kandidati[MinTackaIndeks]);
                Tacka pocetna = Kandidati[MinTackaIndeks];

                Kandidati.Remove(Kandidati[MinTackaIndeks]);
                Console.WriteLine("Kandidati pre:");
                for (int i = 0; i < Kandidati.Count; i++)
                {
                    Console.WriteLine(Kandidati[i].x + " - " + Kandidati[i].y);
                }

                // od preostalih tacaka nadji onu sa najmanjim uglom sa x osom => A1
                double Min_ugao = 200;
                int ind_Min_ugao=0;
                Vektor prvi= Vektor.jedinicni_i();
                Vektor drugi;
                for (int i = 0; i < Kandidati.Count ; i++)
                {
                    Tacka polazna = Omotac_lista[Omotac_lista.Count - 1];
                    Tacka krajnja = new Tacka(Kandidati[i]);
                    drugi = new Vektor(polazna, krajnja);     
                    double Ugao = Vektor.Ugao(prvi, drugi);
                    if (Ugao < Min_ugao)
                    {
                        Min_ugao = Ugao;
                        ind_Min_ugao = i;
                    }
                }
                // Dodaj Temena[i] u Omotac

                Tacka dodajem = Kandidati[ind_Min_ugao];
                Kandidati.RemoveAt(ind_Min_ugao);
                Kandidati.Add(pocetna);
                
                Console.WriteLine("Kandidati posle:");
                for (int i = 0; i < Kandidati.Count; i++)
                {
                    Console.WriteLine(Kandidati[i].x + " - " + Kandidati[i].y);
                }
                
                Console.WriteLine("ind min ugao = " + ind_Min_ugao);
                
                // U odnosu na poslednje dve dodate tacke
                while (dodajem != pocetna)
                {
                    Console.WriteLine("Dodajem:" + dodajem.x  +" " + dodajem.y);
                    Omotac_lista.Add(dodajem);
                    // uzmi poslednje dve tacke u omotacu i napravi vektor v_1
                    Tacka Poslednja_u_Om = (Tacka)Omotac_lista[Omotac_lista.Count - 1];
                    Tacka Pretposlednja_u_Om = (Tacka)Omotac_lista[Omotac_lista.Count - 2];
                    Vektor v_1 = new Vektor(Pretposlednja_u_Om, Poslednja_u_Om);
                    // napravi vektor iz poslednje tacke omotaca sa preostalim tackama
                    Min_ugao = 200;
                    for (int i = 0; i < Kandidati.Count; i++ )
                    {
                        Console.WriteLine(Poslednja_u_Om.x + "/" + Poslednja_u_Om.y + "   K:"+Kandidati[i].x + " "+ Kandidati[i].y);
                        Vektor v_2 = new Vektor(Poslednja_u_Om, Kandidati[i]);
                        double Ugao = Vektor.Ugao(v_1, v_2);
                        Console.WriteLine(" Ostali " + Ugao);
                        if (Ugao < Min_ugao)
                        {
                            Min_ugao = Ugao;
                            ind_Min_ugao = i;
                        }
                    }
                    Console.WriteLine("Pobedio " + ind_Min_ugao);
                    dodajem = Kandidati[ind_Min_ugao];
                    Kandidati.RemoveAt(ind_Min_ugao);
                }

                Tacka[] Omotac_niz = new Tacka[Omotac_lista.Count];
                for (int i = 0; i < Omotac_lista.Count ; i++)
                {
                    Omotac_niz[i] = new Tacka((Tacka) Omotac_lista[i]);
                }
                Poligon Omotac = new Poligon(Omotac_niz);
                return Omotac;
            }
        }
        static void Main(string[] args)
        {
            Tacka[] ulaz = new Tacka[3];
            /* Primer prostog poligona */
            /*
            ulaz[0] = new Tacka(2, 2);
            ulaz[1] = new Tacka(2, 1);
            ulaz[2] = new Tacka(1, 1);
            ulaz[3] = new Tacka(1, 2);
            */

            ulaz[0] = new Tacka(1, 2);
            ulaz[1] = new Tacka(1, 1);
            ulaz[2] = new Tacka(2, 1);
            // ulaz[3] = new Tacka(2, 2);

            /* prost
            ulaz[0] = new Tacka(-5.5, 0.5);
            ulaz[1] = new Tacka(-3.5, -1.5);
            ulaz[2] = new Tacka(-2, 0.0);
            ulaz[3] = new Tacka(-0.2, -1.4);
            ulaz[4] = new Tacka(0.5, 3.9);
            ulaz[5] = new Tacka(-3.0, 4.2);
            ulaz[6] = new Tacka(-3.3, 2.0);
             */

            /* nije prost
            ulaz[0] = new Tacka(-5.5, 0.5);
            ulaz[1] = new Tacka(-3.5, -1.5);
            ulaz[2] = new Tacka(1, 0.0);
            ulaz[3] = new Tacka(-0.2, -1.4);
            ulaz[4] = new Tacka(0.5, 3.9);
            ulaz[5] = new Tacka(-3.0, 4.2);
            ulaz[6] = new Tacka(-3.3, 2.0);
            */

            Poligon poli = new Poligon(ulaz);
            poli.Stampaj();
            if (poli.Prost()) Console.WriteLine("Prost");
            else Console.WriteLine("Nije");
            
            Poligon dva = poli.Omotac();
            dva.Stampaj();

            Console.WriteLine("Poligon");
        }
    }
}
