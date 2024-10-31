using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace DN6 {
    public class Contact : IComparable<Contact> {
        public String Name { get; set; }
        public String Kurz { get; set; }
        public String Standort { get; set; }
        public String Kategorie { get; set; }
        public String EMail { get; set; }
        public String Tel { get; set; }
        public String Departement { get; set; }

        public override String ToString() {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (String element in this) {
                stringBuilder.Append(element); 
                stringBuilder.Append(";"); 
            }
            return stringBuilder.ToString();
        }

        public String ToVcf() {
            string vcfString = "BEGIN:VCARD\n" +
              "VERSION:3.0\n" +
              "N;CHARSET=ISO-8859-1:" + Name + ";;;;\n" +
              "FN;CHARSET=ISO-8859-1:" + Name + "\n" +
              "ADR;TYPE=work,pref;CHARSET=ISO-8859-1:;/" + Standort + "\n" +
              "TEL;TYPE=work,voice,pref:+" + Tel + "\n" +
              "EMAIL;TYPE=INTERNET:natalie.lynch@pencloud.com\n" +
              "END:VCARD";
            return vcfString;

        }

        public IEnumerator<String> GetEnumerator() {
            yield return Name;
            yield return Kurz;
            yield return Standort;
            yield return Kategorie;
            yield return EMail;
            yield return Tel;
            yield return Departement;
        }

        public Contact(string name, string kurz, string standort, string kategorie, string eMail, string tel, string dep) {
            Name = name;
            Kurz = kurz;
            Standort = standort;
            Kategorie = kategorie;
            EMail = eMail;
            Tel = tel;
            Departement = dep;
        }

        public int CompareTo(Contact other) {
            return other.Name.CompareTo(Name);
        }

    }
}
