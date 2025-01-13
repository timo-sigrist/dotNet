.assembly extern mscorlib {}

.assembly FactorialApp {}

.module FactorialApp.exe

.method static void Main() cil managed {
    .entrypoint
    // Lokale Variablen
    .locals init (
        [0] int32 n,   // Wert von n
        [1] int32 k    // Ergebnis
    )

    // Initialisierung
    ldc.i4.5            // Lade 5 auf den Stack
    stloc.0             // n = 5
    ldc.i4.1            // Lade 1 auf den Stack
    stloc.1             // k = 1

    // Schleife: while (n > 1)
    br.s loopCheck      // Springe zur Schleifenprüfung

loopStart:
    ldloc.1             // Lade k auf den Stack
    ldloc.0             // Lade n auf den Stack
    mul                 // k = k * n
    stloc.1             // Speichere das Ergebnis in k

    ldloc.0             // Lade n auf den Stack
    ldc.i4.1            // Lade 1 auf den Stack
    sub                 // n = n - 1
    stloc.0             // Speichere das Ergebnis in n

loopCheck:
    ldloc.0             // Lade n auf den Stack
    ldc.i4.1            // Lade 1 auf den Stack
    ble.s endLoop       // Wenn n <= 1, beende die Schleife

    br.s loopStart      // Springe zum Schleifenanfang

endLoop:
    ldloc.1             // Lade k auf den Stack
    call void [mscorlib]System.Console::WriteLine(int32) // Ausgabe von k

    ret                 // Beende das Programm
}
