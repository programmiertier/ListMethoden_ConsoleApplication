using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.ConsoleColor;

namespace ListMethoden_ConsoleApplication
{
    class Program
    {
        // LKW kann 7.5 Tonnen laden
        class LKW_Ladung
        {
            private List<double> frachtliste = new List<double>();        // mit den einzelnen Gewichten
            private double maxGewicht = 7.5;
            private double _momentanGewicht = 0;

            public void entladen()      // letztes Teil, wieder abladen
            {
                WriteLine("Letztes Gewicht muss entfernt werden!");
                
                frachtliste.RemoveAt(frachtliste.Count() - 1);
                WriteLine("Momentangewicht\t{0}", momentanGewicht());
                WriteLine("-----");
            }

            public void beladen(double einzelStueckGewicht)
            {
                frachtliste.Add(einzelStueckGewicht);
                WriteLine("-----");
                WriteLine("Aktuelle Ladeliste");
                Ladeliste();
                WriteLine("Es wurde ein Teil mit {0} Tonnen hinzugefügt", einzelStueckGewicht);
                if ( momentanGewicht() <= maxGewicht )
                {
                    
                    WriteLine("beladen mit {0}", momentanGewicht());
                }
                else
                {
                    entladen();
                }
            }

            public void userEntladen(double entladen)
            {
                frachtliste.RemoveAt(frachtliste.Count() - 1);
                WriteLine("Momentangewicht\t{0}", momentanGewicht());
                WriteLine("-----");
            }

            public double momentanGewicht()
            {
                _momentanGewicht = 0;
                foreach (double einzel in frachtliste)
                { _momentanGewicht += einzel; }
                return _momentanGewicht;
            }

            public void Ladeliste()
            {
                int zaehler = 0;
                foreach (double einzel in frachtliste)
                {
                    WriteLine("ID: {0}\t{1}", zaehler++, einzel);
                }
            }
        }

        static void Main(string[] args)
        {
            /* LKW_Ladung M_nach_F = new LKW_Ladung();
            M_nach_F.beladen(1.00);
            M_nach_F.beladen(2.00);
            M_nach_F.beladen(3.00);
            M_nach_F.beladen(2.10);     // ist zu viel, wird wieder abgezogen
            M_nach_F.beladen(1.00);     // darf wieder aufgeladen werden */

            // 1. Aufgabe
            // eingabe von Frachtstücken durch Anwender
            // wenn Gesamtgewicht überschritten -> soll er eine Angabe machen können

            // Entweder Stück entfernen

            // oder er nennt ein Gewicht, das abgeladen werden soll
            // Frachtstück, das mindestens x wiegt

            LKW_Ladung kuchenLadung = new LKW_Ladung();
            WriteLine("Bitte Ladegewicht eingeben (in Form 0,00)");
            WriteLine("MaximalGewicht sind 7,5 Tonnen");
            double eingabe;
            while (double.TryParse(ReadLine(), out eingabe))
            {
                kuchenLadung.beladen(eingabe);
                kuchenLadung.Ladeliste();
            }

            ReadLine();
            WriteLine("Danke und weiter geht es");
            ReadLine();
            WriteLine("Die aktuelle Ladeliste");
            kuchenLadung.Ladeliste();
            WriteLine("Welchen Wert wollen sie entfernen?, bitte id angeben");

            double entfernen;
            while (double.TryParse(ReadLine(), out entfernen))
            {
                kuchenLadung.userEntladen(entfernen);
                kuchenLadung.Ladeliste();
            }
            ReadLine();
        }
    }
}
