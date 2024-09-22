// Eratosthenes Auswertung Lab 1

using System.Collections;
using System.Drawing;

namespace DN1 {
    public enum PrimeType { Prime, NotPrime };

    public class Eratosthenes {

        static void Main(string[] args) {
            int maxPrime = 100;
            Eratosthenes eratosthenes = new Eratosthenes();
            if (args.Length >= 1)
                maxPrime = Int32.Parse(args[0]);

            PrimeType[] primes = eratosthenes.Sieve(maxPrime);
            Console.WriteLine("Aufgabe 1");
            for (int i = 0; i < maxPrime; i++) {
                Console.Write(i + ":" + primes[i] + " ");
                if ((i + 1) % 5 == 0) Console.WriteLine();
            }
            Console.WriteLine("\nAufgabe 2");
            eratosthenes.printAll(eratosthenes.PrimesAsArray(primes));
            Console.WriteLine("\nAufgabe 3");
            eratosthenes.printAll(eratosthenes.PrimesAsList(primes));
            Console.WriteLine("\nAufgabe 4");
            eratosthenes.printAll(eratosthenes.PrimesAsDictionary(primes).Select(z => z.Value).ToArray());

            Console.ReadLine();
        }


        private int CountPrimeNumbers(PrimeType[] primes) {
            int counter = 0;
            foreach (PrimeType prime in primes) { 
                if (prime == PrimeType.Prime) {
                    counter++;
                }
            }
            return counter;
        }

        public PrimeType[] Sieve(int maxPrime) {
            PrimeType[] result = new PrimeType[maxPrime];
            for (int i = 0; i < maxPrime; i++) {
                  if (i < 2) {
                    result[i] = PrimeType.NotPrime;
                } else {  
                    result[i] = PrimeType.Prime;
                }
            }

            for (int i = 2; i < maxPrime; i++) {
                if (result[i] == PrimeType.NotPrime) {
                    continue;
                } else {
                    for (int j = i+1; j < maxPrime; j++) {
                        if (j % i == 0) {
                            result[j] = PrimeType.NotPrime;
                        }
                    }
                }
            }

            return result;
        }

        public int[] PrimesAsArray(PrimeType[] primes) {
            int[] Result = new int[CountPrimeNumbers(primes)];
            int ResultCounter = 0;
            for (int i = 0;i < primes.Length; i++) {
                if (primes [i] == PrimeType.Prime) {
                    Result[ResultCounter] = i;
                    ResultCounter++;
                }
            }    

            return Result;
        }

        public List<int> PrimesAsList(PrimeType[] primes) {
            List<int> Result = new List<int>();
            int ResultCounter = 0;
            for (int i = 0; i < primes.Length; i++) {
                if (primes[i] == PrimeType.Prime) {
                    Result.Add(i);
                    ResultCounter++;
                }
            }

            return Result;
        }

        public Dictionary<int, int> PrimesAsDictionary(PrimeType[] primes) {
            Dictionary<int, int> Result = new Dictionary<int, int>();
            int ResultCounter = 0;
            for (int i = 0; i < primes.Length; i++) {
                if (primes[i] == PrimeType.Prime) {
                    Result.Add(ResultCounter, i);
                    ResultCounter++;
                }
            }

            return Result;
        }
        public void printAll(IEnumerable<int> collection) {
            int i = 0;
            foreach (int p in collection) {
                Console.Write((i++) + "->" + p + " ");
                if ((i + 1) % 5 == 0) Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}


