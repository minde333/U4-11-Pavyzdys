using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace L4_U4_11
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] seperators = {' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t'};
            char[] seperators2 = {'.', '!', '?', ';'};
            ZodziuKonteineris allWords = new ZodziuKonteineris(100);
            ZodziuKonteineris knyga1Zodziai = new ZodziuKonteineris(100);
            ZodziuKonteineris knyga2Zodziai = new ZodziuKonteineris(100);
            ZodziuKonteineris ilgiausiZodziai = new ZodziuKonteineris(10);

           knyga1Zodziai = Nuskaitymas("Knyga1.txt",seperators, knyga1Zodziai);
           knyga2Zodziai = Nuskaitymas("Knyga2.txt", seperators, knyga2Zodziai);
           ilgiausiZodziai = IlgiausiZodziai(knyga1Zodziai, knyga2Zodziai);
            for (int i = 0; i < ilgiausiZodziai.Kiekis; i++)
            {
                Console.WriteLine(ilgiausiZodziai.PaimtiZodi(i).ToString() + "\n");
            }
            TrumpiausiasSakinys("Knyga1.txt",seperators2);
           Console.ReadKey();
        }
        static void TrumpiausiasSakinys(string file, char[] seperators)
        {
            int esamaEilute = 0;
            string text = File.ReadAllText(file);
            string[] sakiniai = text.Split('.');
            foreach (string sakinys in sakiniai)
            {
                string[] temp = sakinys.Split('\r', '\n');
                foreach (string t in temp)
                {
                    if (t == "")
                    {
                        esamaEilute++;
                    }
                }
            }

        }
        static ZodziuKonteineris Nuskaitymas(string file, char[] seperators,ZodziuKonteineris wordContainer)
        {
            int lineNum = 0;
            string[] lines = File.ReadAllLines(file, Encoding.UTF8);
            foreach (string line in lines)
            {
                string[] values = line.Split(seperators);
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i] != null && values[i] != "")
                    {
                        Zodis temp = new Zodis(values[i],0,lineNum,values[i].Length);
                        wordContainer.PridetiZodi(temp);
                    }
                }
                lineNum++;                
            }
            return wordContainer;
        }
        //yra faile1 nera faile2 amx 10 tokiu
        static ZodziuKonteineris IlgiausiZodziai(ZodziuKonteineris knyga1zodziai, ZodziuKonteineris knyga2zodziai)
        {
            bool jauYra = false;
            ZodziuKonteineris temp = new ZodziuKonteineris(30);
            ZodziuKonteineris pasikartojantis = new ZodziuKonteineris(10);
            for (int i = 0; i < knyga1zodziai.Kiekis; i++)
            {
                jauYra = false;
                for (int j = 0; j < knyga2zodziai.Kiekis; j++)
                {
                    if (knyga1zodziai.PaimtiZodi(i).Pavadinimas.ToLower() == knyga2zodziai.PaimtiZodi(j).Pavadinimas.ToLower())
                    {
                        jauYra = true;
                        break;
                    }
                }
                if (jauYra == false)
                {
                   int pasikartojaIndexas = temp.PasikartojancioIndexas(knyga1zodziai.PaimtiZodi(i));
                    if (pasikartojaIndexas < 0)
                    {
                        temp.PridetiZodi(knyga1zodziai.PaimtiZodi(i));
                        continue;
                    }
                    temp.PaimtiZodi(pasikartojaIndexas).Pasikartojimai += 1;
                }
            }
            temp = rikiavimas(temp);
            for (int i = 0; i <= temp.Kiekis; i++)
            {
                if (i >= 10)
                {
                    break;
                }
                pasikartojantis.PridetiZodi(temp.PaimtiZodi(i));
            }

            return pasikartojantis;

        }
        static ZodziuKonteineris rikiavimas(ZodziuKonteineris rikiojamas)
        {
            for (int i = 0; i < rikiojamas.Kiekis; i++)
            {
                for (int j = 0; j < rikiojamas.Kiekis-1; j++)
                {
                    if (rikiojamas.PaimtiZodi(j).Ilgis < rikiojamas.PaimtiZodi(j+1).Ilgis)
                    {
                        rikiojamas.Swap(j,j+1);
                    }
                }
            }
            return rikiojamas;
        }
    }
}
