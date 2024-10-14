using System;

namespace DN3 {
    public class Space {
        static void Main(string[] args) {
            Vector omegaEarth, omegaSun, omegaGalaxy;
            Vector rEarth, rSun, rGalaxy;

            InitOmegaVectors(out omegaEarth, out omegaSun, out omegaGalaxy);
            InitRVectors(out rEarth, out rSun, out rGalaxy);
            double speed = CalcSpeed(omegaEarth, omegaSun, omegaGalaxy, rEarth, rSun, rGalaxy);
            Console.WriteLine("Speed is " + speed + " km/s");
            Console.ReadLine();
        }

        // Initialisiere die Winkelgeschwindigkeitsvektoren
        public static void InitOmegaVectors(out Vector omegaEarth, out Vector omegaSun, out Vector omegaGalaxy) {
            // Setze die erwarteten Werte für die Winkelgeschwindigkeiten
            omegaEarth = new Vector(0, 7.27220521664304E-05, 0);    // Erde: 7.27220521664304 × 10^-5 rad/s
            omegaSun = new Vector(0, 1.991021277657232E-07, 0);     // Sonne: 1.991021277657232 × 10^-7 rad/s
            omegaGalaxy = new Vector(0, 8.848983456254364E-16, 0);  // Galaxie: 8.848983456254364 × 10^-16 rad/s
        }

        // Initialisiere die Radiusvektoren
        public static void InitRVectors(out Vector rEarth, out Vector rSun, out Vector rGalaxy) {
            // Setze die erwarteten Werte für die Radien
            rEarth = new Vector(6370, 0, 0);                // Erde: Radius von 6370 km
            rSun = new Vector(1.496e8, 0, 0);               // Sonne: 1.496 × 10^8 km
            rGalaxy = new Vector(2.3650000000000003E+17, 0, 0); // Galaxie: 2.365 × 10^17 km
        }

        // Berechnung der Geschwindigkeit mit der Euler-Gleichung v = ω x r
        public static double CalcSpeed(Vector omegaEarth, Vector omegaSun, Vector omegaGalaxy, Vector rEarth, Vector rSun, Vector rGalaxy) {
            // Berechnung der Geschwindigkeitsvektoren durch Kreuzprodukt
            Vector vEarth = omegaEarth * rEarth;
            Vector vSun = omegaSun * rSun;
            Vector vGalaxy = omegaGalaxy * rGalaxy;

            // Berechnung der Beträge der resultierenden Geschwindigkeitsvektoren
            double speedEarth = (double)vEarth;
            double speedSun = (double)vSun;
            double speedGalaxy = (double)vGalaxy;

            // Summe der Beträge der Geschwindigkeiten
            double totalSpeed = speedEarth + speedSun + speedGalaxy;

            return totalSpeed;
        }
    }
}
