using System;
using System.IO;

// partial -> Definition auf mehrere Dateien aufteilen -> hier auf aspx und aspx.cs
public partial class _CounterPage: System.Web.UI.Page {
    public int CounterValue() {
        FileStream s  = new FileStream("c:\\Data\\Counter.dat", FileMode.OpenOrCreate);

        n = r.ReadInt32();
        n++;

        return n;
    }
}
