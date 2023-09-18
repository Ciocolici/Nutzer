using System.Diagnostics.Metrics;
using System;

namespace Nutzer;

internal class Program
{
    static void Main(string[] args)
    {
        //1.Erstellen Sie die Klasse Nutzer.  

        //Diese soll Vorname, Nachname und Geburtstag enthalten.  
        //Außerdem eine statische Liste für Nutzer. 
        //Die Klasse benötigt ebenfalls einen leeren Konstruktor und einen String-Override.
        //Die Klasse soll vollständig im Sinne der OOP erstellt sein.  

        //2.Erstellen Sie eine statische Klasse Menue.

        //Diese soll eine Methode Start() beinhalten in der dann die Menüauswahl aufgeführt ist. 
        //Weiter hin soll sie eine über das Startmenü aufrufbare Methode enthalten, die es einem Anwender gestattet, beliebig viele Nutzer der Nutzerliste hinzuzufügen

        Menue.Start();
    }
}