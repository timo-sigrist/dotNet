// Eratosthenes Auswertung Lab 1

using System.Collections;
using System.Drawing;

namespace Test {
    public enum PrimeType { Prime, NotPrime };

    public class PlayClass {

        static void Main(string[] args) {
            Console.WriteLine("Test");
        }

    }


    [Serializable] // Klassen-Attribut -> Metadaten die zusätzlice Informationen geben

    public class MyClass {
        public int PropNumber { get; set; } // Property
        public bool ReadOnlyProp {  get; } // Read-only Prop

        public String FieldString; // Field

        public readonly int ReadonlyField = 42; // Readonly-Field

        public const int MyConst = 3; // Zur Kompilierzeit bekannt, unveränderlich
        
        // Override von Standart-Konstruktor -> hat keine parameter
        // this ruft den passenden Konstruktor auf
        public MyClass(): this("Test") {}

        public MyClass(String fieldstring) {
            FieldString = fieldstring;  
        }

        // Beispiel mit Pointer, kann mit unsafemethode oder unsafe-block verwendet werden
        // Kompilieren mit csc -unsafe MyTestClass.cs
        /*
        public unsafe void PointerExample() {
            int myInt = 42;
            int* myPointer = &myInt; // * = pointer,  & = Adresse

            int[] numbers = { 10, 20, 30, 40, 50 };
            fixed (int* pointer = numbers) { // Die Adresse des Arrays wird fixiert -> nicht von GC eingesammelt
                // Funktioniert auch mit eizenen feildern: fixed (int* pointer = &person.id) { }
            }
        } 
        */
        

    }


    public struct MyStruct {
        double myDouble;
        bool myBool;


        // Jeder Struct hat paramteterlosen Standartkonstruktor, der alle felder initalisiert
        /* Parameterloser konstruktor Nicht möglich!!!
        MyStruct() {

        }
        */

        // Ein Struct-Konstruktor muss alle Felder initalisieren
        public MyStruct(double myDouble) {
            this.myDouble = myDouble;
            myBool = true;
        }
    }
}


