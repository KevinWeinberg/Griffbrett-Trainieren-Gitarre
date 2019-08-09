/* Griffbrett einer Gitarre trainieren - Konsolenanwendung
 * Version 1.0
 *
 * Copyright (c) 2019 Kevin Weinberg
 * Repository: https://github.com/KevinWeinberg/
 * Homepage: https://kevin-weinberg.de/
 * It may be used under the terms of the MIT License.
 * For full terms see the file LICENSE or visit https://opensource.org/licenses/MIT
 */

using System;
using System.Text;

namespace GriffbrettTrainierenKonsole
{
    class GriffbrettClass
    {
        // Bundbezeichnung
        readonly string bundbezeichnung = "           | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |";

        // Saitennamen
        readonly string[] saitenname = new string[6] { "e-Saite:   ", "B-Saite:   ", "G-Saite:   ", "D-Saite:   ", "A-Saite:   ", "E-Saite:   "};

        // Variable für Griffbrett
        readonly string bund = "|   |   |   |   |   |   |   |   |   |";

        // Variablen für die Zufallsnote
        int zufallSaite;
        int zufallBund;
        string zuErmittelndeNote;

        // Eingabe des Benutzers
        string eingabeBenutzerNote;

        // Main-Funktion
        static void Main(string[] args)
        {
            // Instanz erstellen
            GriffbrettClass InstanzVomGriffbrettProgram = new GriffbrettClass();
            InstanzVomGriffbrettProgram.GriffbrettProgramm();
        }

        // Der Programmablauf
        private void GriffbrettProgramm()
        {
            Console.WriteLine("Griffbrett trainieren - Konsolenanwendung\n");

            // Saite und Bund durch Zufall bestimmen
            zufallSaite = ZufallsZahl(7);
            zufallBund = ZufallsZahl(10);

            // Zufallszahlen in eine Note umwandeln
            zuErmittelndeNote = ZufallInNote(zufallSaite, zufallBund);

            // Griffbrett zeichnen
            GriffbrettZeichnen();

            // Dem Benutzer mögliche Notennamen anzeigen
            NotennamenAnzeigen();

            // Benutzer abfragen, zur Sicherheit untersuchen und Wert ausgeben
            eingabeBenutzerNote = EingabeBenutzer();

            // Eingabe mit der Note vergleichen und Ergebnis ausgeben
            EingabeVergleichen();

            // Programm erneut starten oder beenden
            Console.WriteLine("\nProgramm [e]rneut starten oder [b]eenden?");

            // Abfragen, ob das Programm Programm neugestartet oder beendet werden soll
            NeustartenOderBeenden();
        }

        // Dem Benutzer die existierenden Notennamen anzeigen
        private void NotennamenAnzeigen()
        {
            Console.WriteLine("\nMögliche Notennamen:");
            Console.WriteLine("c, cis, d, dis, e, f, fis, g, gis, a, ais, b");
        }

        private void NeustartenOderBeenden()
        {
            // Eingabe des Benutzer in Varaiable speichern
            ConsoleKeyInfo neuOderBeenden = Console.ReadKey(true);

            // Je nach gedrückter Taste reagieren
            if (neuOderBeenden.Key == ConsoleKey.E)
            {
                // Neue Runde starten
                Console.Clear();
                GriffbrettProgramm();
            }
            else if (neuOderBeenden.Key == ConsoleKey.B)
            {
                // Programm beenden
                Environment.Exit(0);
            }
            else
            {
                // Nochmal nach Benutzereingabe fragen
                NeustartenOderBeenden();
            }
        }

        private void EingabeVergleichen()
        {
            // Für die Formatierung des Textes
            ClearLine(2);

            // Die Zufallsnote mit der eingegebenden Note des Benutzers vergleichen
            if (zuErmittelndeNote == eingabeBenutzerNote)
            {
                // Benutzereingabe war richtig
                Console.WriteLine("Die Note \"" + eingabeBenutzerNote + "\" war richtig!");
            }
            else
            {
                // Benutzereingabe war falsch
                Console.WriteLine("Die eingegebene Note \"" + eingabeBenutzerNote + "\" war falsch. Es wäre \"" + zuErmittelndeNote + "\" gewesen!");
            }
        }
        
        // Die beiden Zufallszahlen in den Notennamen umwandeln
        private string ZufallInNote(int s, int b)
        {
            // Variable für die Notennamen (noch zu kürzen)
            string[] notennamen = new string[27] { "e", "f", "fis", "g", "gis", "a", "ais", "b", "c", "cis", "d", "dis", "e", "f", "fis", "g", "gis", "a", "ais", "b", "c", "cis", "d", "dis", "e", "f", "fis"};

            // Offset der Saiten
            int[] offsetSaiten = new int[7] {0, 0 ,7, 3, 10, 5, 0};

            // Notennamen unter Berücksichtigung der Saite und des Bundes bestimmen
            string ermittelteNote = notennamen[b+offsetSaiten[s]];

            return ermittelteNote;
        }

        private string EingabeBenutzer()
        {
            // Variable für die Benutzereingabe
            string benutzereingabe;

            // Benutzer um Eingabe bitten
            Console.WriteLine("\nWelche Note wurde markiert?");

            // Eingabe des Benutzers
            benutzereingabe = Console.ReadLine();

            // Hat die Benutzereingabe mehr als 3 Zeichen?
            bool bereitsDurchlaufen = false;
            while (benutzereingabe.Length > 3)
            {
                // Für die Formatierung des Textes
                if (!bereitsDurchlaufen)
                {
                    ClearLine(2);
                }
                bereitsDurchlaufen = true;

                // Den Benutzer erneut um eine Eingabe bitten
                Console.WriteLine("Welche Note wurde markiert? (maximal 3 Zeichen)");
                benutzereingabe = Console.ReadLine();
                ClearLine(2);
            }
            return benutzereingabe;
        }

        private void GriffbrettZeichnen()
        {
            // Bundbezeichnung zeichnen
            Console.WriteLine(bundbezeichnung +"\n");

            // Saiten zeichnen und dabei die Note markieren
            for (int i = 1; i < 7; i++)
{
                string aktuelleSaite = saitenname[i-1];

                if (zufallSaite != i)
                {
                    // Die Saiten zeichen, auf denen die Note sich nicht befindet
                    Console.WriteLine(aktuelleSaite + bund);
                }
                else if (zufallSaite == i)
                {
                    // Saite zeichen, auf welcher sich die Zufallsnote befindet
                    Console.WriteLine(aktuelleSaite + NoteMarkieren(zufallBund));
                }
            }
        }

        // Zufallszahlen für den Bund und die Saite generieren
        private int ZufallsZahl(int input)
        {
            // Zufallszahl generieren (Bund 0 entsteht aktuell nicht als Ergebnis)
            Random random = new Random();
            int randomNumber = random.Next(1, input);
            return (randomNumber);
        }

        private string NoteMarkieren(int bundposition)
        {
            // Bundposition für die richtige Stelle umrechnen
            int bundposition_angepasst = bundposition + ((bundposition - 1) * 3) + 1;

            // Note mit "X" markieren
            string bund_markiert = bund;
            StringBuilder sb = new StringBuilder(bund_markiert);
            sb[bundposition_angepasst] = 'X';
            bund_markiert = sb.ToString();
            return (bund_markiert);
        }

        // Zum Bereinigen einzelner Zeilen
        public static void ClearLine(int lines = 1)
        {
            for (int i = 1; i <= lines; i++)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }
        }
    }
}