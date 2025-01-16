using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test {
    internal class Compare_Example {

        static void ComparableExample() {
            Person[] people = {
                new Person("Alice", 25),
                new Person("Bob", 30),
                new Person("Charlie", 20)
            };

            // Sortieren mit IComparable (nach Alter)
            Array.Sort(people);
        }

        static void ComparerExample() {
            Person[] people = {
                new Person("Alice", 25),
                new Person("Bob", 30),
                new Person("Charlie", 20)
            };

            // Sortieren mit IComparer (nach Name)
            Array.Sort(people, new PersonComparer());
        }
    }

    // Implementierung von IComparable
    public class Person : IComparable<Person> {
        public string Name { get; set; }
        public int Age { get; set; }

        // Konstruktor
        public Person(string name, int age) {
            Name = name;
            Age = age;
        }

        // Vergleich nach Alter für die Sortierung
        public int CompareTo(Person other) {
            // Vergleich basierend auf dem Alter
            return this.Age.CompareTo(other.Age);
        }
    }


    // Implementierung von IComparer
    public class PersonComparer : IComparer {
        // Vergleichsmethode für Personen nach dem Namen
        public int Compare(object x, object y) {
            Person p1 = (Person)x;
            Person p2 = (Person)y;

            // Vergleich basierend auf dem Namen
            return string.Compare(p1.Name, p2.Name);
        }
    }

    // Regex-Matcher Example
    static void Regex_Example() {
        // Beispieltext
        string input = "Heute ist der 16. Januar 2025.";

        string pattern = @"\b\d{1,2}\. [a-zA-ZäöüÄÖÜß]+ \d{4}\b";
        Regex regex = new Regex(pattern);
        Match match = regex.Match(input);

        if (match.Success) {
            Console.WriteLine($"Gefundenes Datum: {match.Value}");
        } else {
            Console.WriteLine("Kein Datum gefunden.");
        }
    }


}
