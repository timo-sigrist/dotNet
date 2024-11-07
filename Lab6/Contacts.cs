using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Concurrent;

namespace DN6 {
    public class Contacts : List<Contact> {
        private BlockingCollection<Contact> contactQueue = new BlockingCollection<Contact>();

        public void readCsv(string file) {
            Task.Run(() => {
                String[] lines = File.ReadAllLines(file);
                foreach (var line in lines) {
                    string[] split = line.Split(';');
                    contactQueue.Add(new Contact(split[0], split[1], "", "", "", "", ""));
                }
                contactQueue.CompleteAdding();
            });
        }

        public void writeCsv(string file) {
            StringBuilder b = new StringBuilder();
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 10; i++) {
                tasks.Add(Task.Run(() => {
                    foreach (Contact contact in this) {
                        b.Append(contact + "\n");
                    }
                }));
            }
            Task.WaitAll(tasks.ToArray());
            File.WriteAllText(file, b.ToString());
        }

        public void writeVcf(Contact c) {
            File.WriteAllText(c.Name + ".vcf", c.ToVcf());
        }
    }
}