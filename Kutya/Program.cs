using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kutya
{
    class Program
    {
        static List<KutyaNev> kutyaNevek = new List<KutyaNev>();
        static List<KutyaFajta> kutyaFajtak = new List<KutyaFajta>();
        static List<Kutya> kutyaLista = new List<Kutya>();

        static void KutyafajtaBeolvasas()
        {
            StreamReader be = new StreamReader("KutyaFajtak.csv");

            be.ReadLine();
            while (!be.EndOfStream)
            {
                string[] adat = be.ReadLine().Split(';');

                kutyaFajtak.Add(new KutyaFajta(Convert.ToInt32(adat[0]), adat[1], adat[2]));
            }
            be.Close();
        }

        static void KutyaNevekBeolvasas()
        {
            StreamReader be = new StreamReader("KutyaNevek.csv");

            be.ReadLine();

            while (!be.EndOfStream)
            {
                string[] adat = be.ReadLine().Split(';');

                kutyaNevek.Add(new KutyaNev(
                  Convert.ToInt32(adat[0]),
                  adat[1]
                ));
            }
            be.Close();
        }

        static void KutyaBeolvasas()
        {
            StreamReader be = new StreamReader("Kutyak.csv");

            be.ReadLine();
            while (!be.EndOfStream)
            {
                string[] adat = be.ReadLine().Split(';');
                kutyaLista.Add(new Kutya(
                    Convert.ToInt32(adat[0]),
                    Convert.ToInt32(adat[1]),
                    Convert.ToInt32(adat[2]),
                    Convert.ToInt32(adat[3]),
                    adat[4]));
            }
            be.Close();
        }

        static void Harmadik()
        {
            Console.WriteLine($"3. feladat: Kutyanevek száma: {kutyaNevek.Count}");
        }

        static void Hatodik()
        {
            double sum = 0;
            foreach (var k in kutyaLista)
            {
                sum += k.Eletkor;
            }

            Console.WriteLine($"6. feladat: Kutyák átlagéletkora: {sum / kutyaLista.Count:N2}");
        }

        static void Hetedik()
        {
            int max = kutyaLista[0].Eletkor;
            for (int i = 0; i < kutyaLista.Count; i++)
            {
                if (kutyaLista[i].Eletkor > max)
                {
                    max = kutyaLista[i].Eletkor;
                }
            }
            Console.WriteLine(max);

            int f = 0;
            int n = 0;
            for (int i = 0; i < kutyaLista.Count; i++)
            {
                if (kutyaLista[i].Eletkor == max)
                {
                    f = kutyaLista[i].Fajtaid;
                    n = kutyaLista[i].Nevid;
                }
            }

            string lf = "";
            string ln = "";

            for (int i = 0; i < kutyaFajtak.Count; i++)
            {
                if (f == kutyaFajtak[i].ID)
                {
                    lf = kutyaFajtak[i].Nev;
                }
            }

            for (int i = 0; i < kutyaNevek.Count; i++)
            {
                if (n == kutyaNevek[i].ID)
                {
                    ln = kutyaNevek[i].Nev;
                }
            }

            Console.WriteLine($"7. feladat: Legidősebb kutya neve és fajtája: {ln}, {lf}");
        }

        static void Nyolcadik()
        {
            Dictionary<string, int> kutyaDatum = new Dictionary<string, int>();
            List<int> datumFajtak = new List<int>();

            for (int i = 0; i < kutyaLista.Count; i++)
            {
                if (kutyaLista[i].Vizsgalat == "2018.01.10")
                {
                    datumFajtak.Add(kutyaLista[i].Fajtaid);
                }
            }

            int fajtaSzam;
            for (int i = 0; i < kutyaFajtak.Count; i++)
            {
                fajtaSzam = 0;
                if (datumFajtak.Contains(kutyaFajtak[i].ID))
                {
                    fajtaSzam++;
                    kutyaDatum.Add(kutyaFajtak[i].Nev, fajtaSzam);
                }
            }

            Console.WriteLine("8. feladat: Január 10.-én vizsgált kutya fajták: ");
            foreach (var k in kutyaDatum)
            {
                Console.WriteLine(k.Key + " " + k.Value + " kutya");
            }
        }
        static void Main(string[] args)
        {
            KutyafajtaBeolvasas();
            KutyaNevekBeolvasas();
            KutyaBeolvasas();
            Harmadik();
            Hatodik();
            Hetedik();
            Nyolcadik();

            Console.ReadKey();
        }
    }
}