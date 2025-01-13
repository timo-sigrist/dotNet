using System.Collections;
using System.Drawing;

using System.Threading;

namespace Test {
    public class ThreadExample {

        private static readonly object lockObject = new object(); // Sperr-Objekt

        static void MainMethode(string[] args) {
            Thread t0 = new Thread(RunT0);
            t0.Start();

            t0.Join(); // Wartet und blockiert den Thread, bis dieser Fertig ist
                       // Ohne Join kann es sein, dass der mainthread vor dem Workthread beendet wird


            Thread t1 = new Thread(() => Console.WriteLine("Inter"));
            t1.Start();
            
            t1.Abort(); // Bricht den Thread ab und wirft eine Fehlermeldung
                        // -> kann mit catch bezw. finaly gehandelt werden im ThreadStart-Delegate

            // Lock von Instanz
            Counter c = new Counter();
            Thread t2 = new Thread(c.Increment); // inceremt locked das gesamte objekt
            t2.Start();

            // Lock einer Collection 
            ArrayList list = new ArrayList();
            list.Add("1");
            Thread t3 = new Thread(() => AddItems(list)); 
            t3.Start();
            t3.IsBackground = true; // Setzt den Thread auf Background, wird beendet wenn der Main-Thread beendet wird

        }

        // Ausprogrammierung Thread-Start implementation
        public static void RunT0() {
            for (int i = 0; i < 1000; i++) {


                // Locken des Objektes -> um raceconditions zu verhindern
                lock (lockObject) { 
                    lockObject.ToString();
                }

                Console.WriteLine("Whatever");
                Thread.Sleep(1000);
            } 
        }


        // Lock von Collection mithilfe von Collection interface
        static void AddItems(ArrayList list) {
            if (!list.IsSynchronized) { // überprüft das Collection-Objekt
                lock (list.SyncRoot) // Verwende SyncRoot zur Synchronisation
                {
                    Console.WriteLine("Hinzufügen von Elementen...");
                    for (int i = 4; i <= 6; i++) {
                        list.Add(i);
                        Thread.Sleep(100); // Simuliere Arbeit
                    }
                }
            }
        }

        // Monitor ist wie lock aber mit mehr Kontrolle
        public void IncrementWithMonitor() {
            // Montiro Enter
            try {
                Monitor.Enter(lockObject); // Sperrt das Objekt, blockiert Thread falls nicht erfolgreich bis Sperung geht
                lockObject.ToString();
            } finally {
                Monitor.Exit(this); // Freigabe
            }

            // Montior TryEnter
            if (Monitor.TryEnter(lockObject)) // Sperrt das Objekt, blockiert aber nicht Thread falls nicht erfolgreich
            {
                try {
                    lockObject.ToString();
                } finally {
                    Monitor.Exit(lockObject); // Sperre freigeben
                }
            }
        }



    }

    class Counter {
        private int _count = 0;

        public void Increment() {
            lock (this) // Sperrt die aktuelle Instanz um ein feld zu manipulieren, nicht 100 sicherer weg
            {
                _count++;
                Console.WriteLine($"Count: {_count}");
            }
        }

    }


}


