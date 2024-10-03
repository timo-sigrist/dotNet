using System;

namespace DN2 {
    class MainClass {
        const int STEPS = 100;
        const double EPS = 1E-5;

        public static void Main(string[] args) {
            Console.WriteLine("Linear fixed [0..10]: " + Integrator.Integrate(x => x, 0, 10, STEPS) + " steps: " + Integrator.Steps);
            Console.WriteLine("Linear fixed [5..15]: " + Integrator.Integrate(x => x, 5, 15, STEPS) + " steps: " + Integrator.Steps);
            Console.WriteLine("Linear adapt [0..10]: " + Integrator.Integrate(x => x, 0, 10, EPS) + " steps: " + Integrator.Steps);
            Console.WriteLine("Square fixed [0..10]: " + Integrator.Integrate(x => x * x, 0, 10, STEPS) + " steps: " + Integrator.Steps);
            Console.WriteLine("Square adapt [0..10]: " + Integrator.Integrate(x => x * x, 0, 10, EPS) + " steps: " + Integrator.Steps);
            Console.ReadLine();
        }
    }

    public class Integrator {
        public static int Steps;

        public static double Integrate(Func<double, double> f, double start, double end, int steps) {
          Steps = steps;
        double d = (end - start) / steps;
        double sum = 0.0;

        // Trapezregel: Fläche der Trapeze summieren
        for (int i = 0; i < steps; i++)
        {
            double x1 = start + i * d;
            double x2 = start + (i + 1) * d;
            sum += (f(x1) + f(x2)) * d / 2;  // (f(x1) + f(x2)) / 2 * d
        }

        return sum;
        }

        public static double Integrate(Func<double, double> f, double start, double end, double eps) {
            Steps = 1;

            double integral1 = Integrate(f, start, end, 1);
            double integral2 = Integrate(f, start, end, 2); 

            while (Math.Abs(integral2 - integral1) > eps) {
                integral1 = integral2;
                Steps *= 2;
                integral2 = Integrate(f, start, end, Steps); 
            }

            return integral2; 
        }
    }

}