

namespace Nutzer;

public class Nutzer
{
    public string Vorname { get; set; }
    public string Nachname { get; set; }
    public string Geburtstag { get; set; }
    public static List<Nutzer> nutzerListe { get => NutzerListe; set => NutzerListe = value; }

    private static List<Nutzer> NutzerListe = new List<Nutzer>();

    public Nutzer() { }

    public Nutzer(string vorname, string nachname, string geburtstag)
    {
        Vorname = vorname;
        Nachname = nachname;
        Geburtstag = geburtstag;
    }

    public override string ToString()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        return ($"\nVorname: {Vorname}\nNachname: {Nachname}\nGeburtstag: {Geburtstag}\n\n");
    }
}
