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

        static void Negyedik()
        {

        }

        static void Main(string[] args)
        {
            KutyafajtaBeolvasas();
            KutyaNevekBeolvasas();
            KutyaBeolvasas();
            Harmadik();


            Console.ReadKey();
        }
    }
}
