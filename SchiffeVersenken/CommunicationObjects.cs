using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/**
 * Namespace definiert die Objekte,
 * die zur Kommunikation verwendet werden.
 * 
 Client fragt „host“ nach Spieldaten

Spielinformationsobjekt:
- Spielfeld-Objekt
- Spielsteine: n Steine der Länge x
- Spielername

...warten

Client sagt ob er spielen will:
ja/nein
Spielername

...warten

Schiffe verteilt Antwort

Sende an alle:

Alle Spieler als List von name auf ip.
Zugreihenfolge = Reihenfolge in der Liste.

Spielschleife:

Bombe:
Feld(int/int)

Trefferantwort: 
Feld(int/int)
Treffer
Versenkt
Vernichtet

Optional: Chatnachricht (String)

Ich bin dran, wen der vor mir keinen Treffer gemacht hat (berücksichtige auch ob ein Spieler besiegst).

 */
namespace SchiffeVersenken
{   
    /**
     * Angabe der Spielfeldgröße
     */ 
    public class PlayField
    {
        private int width;

        /**
         * Breite des Feldes
         */ 
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        private int height;

        /**
         * Höhe des Feldes
         */ 
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        
    }

    /**
     * Ein Steintype mit einer Länge und der Anzahl der
     * Steine des Types die im Spielfeld verhanden sein sollen.
     */ 
    public class StoneType
    {
        private int length;

        /**
         * Länge des Steintypes
         */ 
        public int Length
        {
            get { return length; }
            set { length = value; }
        }


        private int amount;

        /**
         * Anzahl der Steine dieses Types im Spielfeld
         */ 
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        
    }

    /**
     * Informationen zu einem Spiel
     */ 
    public class GameInfo
    {
        private PlayField field;

        /**
         * Das Spielfeld auf dem Gespielt werden soll
         */ 
        public PlayField Field
        {
            get { return field; }
            set { field = value; }
        }

        private List<StoneType> ships;

        /**
         * Liste mit den verschiedenen Steintypen
         * die auf dem Feld verteilt werden sollen.
         */ 
        public List<StoneType> Ships
        {
            get { return ships; }
            set { ships = value; }
        }

        private String name;

        /**
         * Name des Einladenden Spielers
         */ 
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
    }

    /**
     * Antwort auf die GameInfo.
     * Gibt an, ob am Spiel teilgenommen wird.
     * und informiert den Host über den Spielernamen
     */ 
    public class GameInfoAnswer
    {
        private bool accepted;

        /**
         * true => Einladung angenommen
         */
        public bool Accepted
        {
            get { return accepted; }
            set { accepted = value; }
        }

        private String name;

        /**
         * Names des Spielers, der die Einladung angenommen hat.
         */ 
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
    }

    /**
     * Objekt wird gesendet um den
     * Host zu informieren, dass alle Schiffe verteilt sind.
     */ 
    public class ShipsPlacedAnswer
    {
        private String message;

        /**
         * Optionale Nachricht.
         */ 
        public String Message
        {
            get { return message; }
            set { message = value; }
        }
    }

    /**
     * Klasse kapselt Daten eines Spielers
     */
    public class Player
    {
        private String name;

        /**
         * Der Name des Spielers
         */
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private String ip;

        /**
         * Die IP des Spielers
         */ 
        public String Ip
        {
            get { return ip; }
            set { ip = value; }
        }
    }

    /**
     * Objekt startet das Spiel.
     * Informiert die Clienten über die 
     * Zugreihenfolge der Spieler.
     * Sowie die Spielernamen und IPs
     */
    public class GameStart
    {
        private List<Player> playerOrder;

        public List<Player> PlayerOrder
        {
            get { return playerOrder; }
            set { playerOrder = value; }
        }
    }

    /**
     * Bombe greift ein Feld x/y des Spielers an,
     * an den die Bombe gesendet wird.
     */ 
    public class Bomb
    {
        private int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        private int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }

    /**
     * Antwort auf die Bombe.
     * Informiert über den Ausgang des Angriffes.
     * Sollte an alle Clienten gesendet werden,
     * damit diese das Spielfeld updaten können.
     */ 
    public class HitAnswer
    {
        /**
         * Typ gibt an, was passiert ist nach dem Einschlag der Bombe.
         */ 
        public enum Type
        {
            /**
             * Daneben
             */
            MISS,
            /**
             * Treffer
             */ 
            HIT,
            /**
             * Versenkt
             */ 
            KILL, 
            /**
             * Spieler besiegt
             */ 
            DESTROYED
        }
        private int x;

        /**
         * X-Position des Angriffes
         */ 
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        private int y;

        /**
         * Y-POsition des Angriffes
         */ 
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        private Type hitType;

        /**
         * Ergebniss des Angriffes
         */ 
        public Type HitType
        {
            get { return hitType; }
            set { hitType = value; }
        }
    }

    /**
     * Textnachricht von einem zu einem anderen Clienten.
     * Wie diese verarbeitet wird (ob überhaup) steht den Clienten frei.
     */
    public class ChatMessage
    {
        private String message;

        public String Message
        {
            get { return message; }
            set { message = value; }
        }
        
    }
}
