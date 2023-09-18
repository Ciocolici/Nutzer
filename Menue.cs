

using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace Nutzer;

internal static class Menue
{
    public static void Start()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;   
        Console.WriteLine("\r\n _,  _, _, _,  ____,  ___,   ____,  ____, \r\n(-|\\ | (-|  \\ (-|    (- /   (-|_,  (-|__) \r\n _| \\|, _|__/  _|,    _/__,  _|__,  _|  \\,\r\n(      (      (      (      (      (      \r\n");
        while (true)
        {
            int antwort;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\nWas möchten Sie tun?");
            Console.WriteLine("\n(1) Add User");
            Console.WriteLine("\n(2) Zeig User");
            Console.WriteLine("\n(3) Speichern Liste");
            Console.WriteLine("\n(4) Liste Laden");

            Int32.TryParse(Console.ReadLine(), out antwort);
            switch (antwort)
            {
                case 1:
                    addNutzerRepeat();
                    break;
                case 2:
                    Ausgabe();
                    break;
                case 3:
                    SpeichernXml();
                    break;
                case 4:
                    LadenXml();
                    break;
                default:
                    Console.WriteLine("Eingabe nicht lesbar.");
                    break;
            }
        }
    }

    private static void Add()
    {
        Console.Clear();
        Nutzer nutzer = new Nutzer("", "", "");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Gib Vorname");
        nutzer.Vorname = Console.ReadLine();
        Console.WriteLine("Gib Nachname");
        nutzer.Nachname = Console.ReadLine();
        Console.WriteLine("Gib Geburtstag");
        nutzer.Geburtstag = Console.ReadLine();


        Nutzer.nutzerListe.Add(nutzer);
    }

    public static void addNutzerRepeat()
    {
        bool repeat;
        int auswahl;
        bool check;
        bool repeatAuswahl;

        do
        {
            repeat = false;
            Add();

            do
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Noch 1?");
                    Console.WriteLine("(1)Ja/(2)Nein");
                    check = int.TryParse(Console.ReadLine(), out auswahl);
                    Console.Clear();
                } while (check == false);
                if (auswahl == 1)
                {
                    repeatAuswahl = false;
                    repeat = true;
                }
                else if (auswahl == 2)
                {
                    repeatAuswahl = false;
                    repeat = false;
                }
                else
                {
                    repeatAuswahl = true;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("1 oder 2 bitte");
                }
            } while (repeatAuswahl == true);
        } while (repeat == true);
    }

    private static void Ausgabe()
    {
        Console.Clear();
        foreach (var nutzerlist in Nutzer.nutzerListe)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(nutzerlist);
        }
    }

    private static void SpeichernXml()
    {
        try
        {
            //Erstellen des XMLSerializers für die Nutzerliste
            XmlSerializer serializer = new XmlSerializer(Nutzer.nutzerListe.GetType());

            //Erstellung eines Streams um diesen dann zu serialisieren
            using (StreamWriter sw = new StreamWriter("nutzerListe.xml"))
            {
                //Aufruf der Methode und übergabe des StreamWriters und des Objekts das wir serialisieren möchten.
                serializer.Serialize(sw, Nutzer.nutzerListe);
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Clear();
            Console.WriteLine("Datei gespeichert.\n\n");
            Console.WriteLine("---------------");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Console.WriteLine(ex.Message);
        }
    }

    private static void LadenXml()
    {
        try
        {
            if (File.Exists("nutzerListe.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(Nutzer.nutzerListe.GetType());
                // Syntax um mittels eines StreamReaders die Daten der .xml Datei in  die Liste zu laden.
                using (StreamReader sr = new StreamReader("nutzerListe.xml"))
                {
                    Nutzer.nutzerListe = (List<Nutzer>)serializer.Deserialize(sr);
                }
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Clear();
                Console.WriteLine("Daten geladen.\n\n");
                Console.WriteLine("-------------");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                throw new FileNotFoundException("Datei nicht gefunden.\n\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine();
        }
    }
}


