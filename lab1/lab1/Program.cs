// Eratosthenes Auswertung Lab 1

using System.IO;

namespace Lab1 {
    class EratosthenesGenerator {

        enum PrimeType {Prim, NotPrim};

        static void Main(string[] args) {

            Console.WriteLine("Geben Sie die Grösse des Siebs ein:");
            string userInput = Console.ReadLine();
            int siebSize = Int32.Parse(userInput);

            PrimeType[] result = Eratosthenes(siebSize);

            string OutputLine = "";
            for (int i = 0; i < result.Length; i++) { 
                if (i%10 == 0 && i != 0) {
                    
                    Console.WriteLine(OutputLine);
                    OutputLine = "";
                } else {
                    OutputLine += (i + 1) + "=" + result[i].ToString()+", ";
                }
            }
            Console.WriteLine(OutputLine);
        }

        static PrimeType[] Eratosthenes(int size) {
            PrimeType[] result = new PrimeType[size];
            for (int i = 0; i < size; i++) {
                result[i] = PrimeType.Prim;
            }

            for (int i = 1; i < size;i++) {
                int numberToCheck = i + 1;

                if (result[i] == PrimeType.NotPrim) {
                    continue;
                } else {
                    for (int j = numberToCheck; j < size; j++) {
                        if ((j+1) % numberToCheck == 0) {
                            result[j] = PrimeType.NotPrim;
                        }
                    }
                }
            }

            return result;
        }
        

    }
}


