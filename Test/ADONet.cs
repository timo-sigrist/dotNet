using System;
using System.Data;
using System.Data.OleDb;
using System.Transactions;
using System.Xml;

namespace Test {
    internal class ADO_NET {

        static void VerbingungsOrientiert() {
            string connStr = "provid=SQLOLEDB;data source=(local)\\NetSDK; " +
                "initial catalog=Northwind; user id=sa; password=; ";
            IDbConnection con = null;
            IDbTransaction trans = null;

            try {
                con = new OleDbConnection(connStr);
                con.Open();

                // Transaction falls nötig
                trans = con.BeginTransaction(IsolationLevel.ReadCommitted);

                // SQL Befehl
                IDbCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Customers WHERE id = ? ";

                // Parameter hinzufügen
                ((IDataParameter)cmd.Parameters["?"]).Value = "1";

                // cmd der Transaktion hinzufügen
                cmd.Transaction = trans;

                //SQL Command ausführen und lesen
                IDataReader reader = cmd.ExecuteReader();
                object[] dataRow = new object[reader.FieldCount];

                // Daten zeilenweise lesen und verarbeiten
                while (reader.Read()) {
                    reader.GetValues(dataRow);
                    object name = reader["Name"]; // Zugriff mit index auf spalte,  geht auch mit nr auf zeile
                    foreach (object value in dataRow) {
                        Console.Write(value + "\t");
                    }
                    Console.WriteLine();
                }

                trans.Commit();

                reader.Close();
            } catch (Exception e) {
                Console.WriteLine(e.Message);

            } finally {
                try {
                    if (con != null) {
                        // Transaction rollback
                        trans.Rollback();

                        // Verbindung schliessen
                        con.Close();
                    }
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            }
        }

        static void Verbindungslos() {

            /**
             * Schema definieren
             * Braucht man zb für temporäre Datenverarbeitung, dynamische schemen, Databindung im Gui 
             */

            // Dataset & Table definieren
            DataSet ds = new DataSet("PersonContacts");
            DataTable personTable = new DataTable("Person");

            // Column hinzufügem
            DataColumn col = new DataColumn();
            col.DataType = typeof(System.Int64);
            col.ColumnName = "ID";
            // Bis hier auch für normale felder
            col.ReadOnly = true;
            col.Unique = true;
            col.AutoIncrement = true;
            col.AutoIncrementSeed = -1; // first key starts with -1
            col.AutoIncrementStep = -1; // decrement by 1

            // Column hinzufügen
            personTable.Columns.Add(col);
            personTable.PrimaryKey = new DataColumn[] { col };

            // Tabele zum Dataset hizufügen
            ds.Tables.Add(personTable);

            // Relation definieren
            DataColumn parentCol = ds.Tables["Person"].Columns["ID"];
            DataColumn childCol = ds.Tables["Person"].Columns["PersonID"];

            DataRelation rel = new DataRelation("PersonHasContacts", parentCol, childCol);
            ds.Relations.Add(rel);


            // Datarow hinzufügen
            DataRow personRow = personTable.NewRow();
            personRow["ID"] = 1;
            personRow["Name"] = "Timo";
            personTable.Rows.Add(personRow);
            DataRow contactRow = ds.Tables["Contact"].NewRow(); // eigentlich contactTable wenn exisitieren würde
            contactRow["PersonID"] = (long)personRow["ID"]; // Relation zwischen Person und Contact

            // Schema akzeptieren
            ds.AcceptChanges();


            /**
            *  Datenzugriff
            */
            foreach(DataRow person in personTable.Rows) {
                // Row-Zugriff
                Console.WriteLine(person["Name"]);

                // Über Relation auf Contact zugreifen
                foreach (DataRow contact in person.GetChildRows("PersonHasContacts") {
                    Console.WriteLine(contact["Name"]);
                }
            }

            // Änderungen speichern -> Änderungen werden erst mit Accept gespeichert    
            if (ds.HasErrors) {
                ds.RejectChanges();
            } else {
                ds.AcceptChanges();
            }


            /**
             * Dataview für Sicht auf einzelne Datatable (Kein JOIN!) ohne die zu Grunde liegenden Daten zu verändern
             */
            DataView view = new DataView(personTable); // oder = dataset1.Tables["Person"].DefaultView;
            view.RowFilter = "Name >= 'K' AND NAME <= 'T'"; // Filtern
            view.Sort = "Name DESC"; // Sortieren
            DataRowView drv = view[0]; // Zugriff auf einzelne Zeile
            drv["Name"] = "Timo"; // Änderung


            /**
             * Databinding mit GUI-Elementen
             */
            txtBox.Databinding.Add("Text", personTable, "Name"); // simple
            CurrencyManager cm = (CurrencyManager)this.BindingContext[dsCust, "Customers"];
            long rowPosition = (long)cm.Position; // Position in der Tabelle


            /**
             * DATA-Adapter 
             * Verbindung von Dataset zur DB, Um Daten in Datenbank zu schreiben mit Select, Insert, Update & Delete
             */
            //Setup
            IDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = new OleDbConnection("provider=SQLOLEDB;....");
            cmd.CommandText = "SELECT * FROM Customers";
            adapter.SelectCommand = cmd;

            //Bei fehlenden Schema (Spalten, Primärschlüssel und Einschränkungen) in Dataset
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey; // wird übernommen -> Add übernimmt ohne Primarykey, ....
            
            
            // Daten aus Db lesen und in Datatable abfüllen
            ((DbDataAdapter)adapter).Fill(ds, "Customers");

            // CommandBuilder für Insert, Update, Delete um Daten automatisch zu aktualisieren
            // Arbeitet im Hintergrund wenn z.B. adapter.InsertCommand verwendet wird
            OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);


            // Update und konflikte behandeln
            try {
                adapter.Update(ds, "Customer");
            } catch (DBConcurrencyException) { }

            //Änderung speichern und zurückschreiben
            if (ds.HasErrors) {
                ds.RejectChanges();
            } else {
                ds.AcceptChanges();
            }
            if(adapter is IDisposable) ((IDisposable)apapter).Dispose(); // Löschen des Adapters


            /**
             * Datasets mit XML-DOM
             */
            XmlDataDocument xmlDoc = new XmlDataDocument(ds);
            DataTable table = ds.Tables["Person"];
            table.Rows.Find(3)["Name"] = "changed Name";

            //Änderung ist im XML-Zugriff ebenfalls sichtbar
            XmlElement root = xmlDoc.DocumentElement;
            XmlNode person = root.SelectSingleNode("descendant::Person[ID='3']");
            Console.WriteLine("Access via XML: \n" + person.OuterXml); // Hier kommt 'changed Name' heraus

            // Schreiben von XML
            ds.WriteXml("personContact.xml");
            //lesen von XML
            DataSet xmlDs = new DataSet();
            xmlDs.ReadXml("personContact.xml", XmlReadMode.Auto);
        }
    }
}

