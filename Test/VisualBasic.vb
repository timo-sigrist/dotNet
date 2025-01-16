Imports System
Namespace TestNamespace

    Public Class TestClass


        Enum TestEnum
            EnumVal1 = 10
            EnumVal2 = 20
            [Stop] ' Reservierte Wörter mit [ ]
        End Enum

        Public Shared Sub Main(ByVal args() As String)
            Dim testString As String = "This is a test string."
            Console.WriteLine(testString)
            Dim testEnum As TestEnum = TestEnum.EnumVal1

            'Arrays
            ' Bis VB5 fängt Array mit Index 1 ah
            Dim testArray(10) As Integer
            Dim Kunden() As String = {"Kunde1", "Kunde2", "Kunde3"}
            Dim MehrDimensional(,) As Integer = {{1, 2}, {3, 4}, {5, 6}})

            ' Konstanten
            Const TestConst As Integer = 10
            ReadOnly TestReadOnly As Integer = 20
            Const b = Nothing ' Reference
        End Sub

        Public Sub KontrollStrukturen()
            Dim a As Integer = 12
            If a > 12 Then
                Console.WriteLine("a ist größer als 12")
            ElseIf a > 15 Then
                Console.WriteLine("a ist grösser als 15")
            Else
                Console.WriteLine("a ist kleiner oder gleich 12")
            End If

            Select Case a ' Muss primitiver Type sein
                Case 1
                    Console.WriteLine("a ist 1")
                Case 2
                    Console.WriteLine("a ist 2")
                Case Else
                    Console.WriteLine("a ist weder 1 noch 2")
            End Select

            For i As Integer = 0 To 5
                Console.Wirte(i)
            Next

            Dim names As String() = {"Tom", "Max"}
            For Each s As String In names
                Console.WriteLine(s)
            Next

            Dim c As Integer = 0
            While c < 5 ' oder Do Until
                c += 1
            End While ' oder Loop 

            Do
                c += 1
                If c == 2 Then Exit Do ' break anweisung
            Loop While c < 10 ' oder Loop Until

            ' GoTo
            GoTo Label1
            Console.WriteLine("Hier wird nicht ausgegeben")
Label1:     Console.WriteLine("Hier wird ausgegeben")


            ' Errorhandling
            On Error GoTo Fehlerbehandlung
            'code
Fehlerbehandlung:
            Console.WriteLine("Fehlerbehandlung")

            'Try
            Try
                Dim x As Integer = 10
                Dim y As Integer = 0
                Dim z As Integer = x / y
            Catch ex As Exception
                Console.WriteLine("Fehler: " & ex.Message)
                Throw New Exception("Fehler")
            Finally
                Console.WriteLine("Finally")
            End Try

        End Sub

        Sub SubWithOptionalParam(ByVal valParam As Integer, ByRef refParam As Integer, Optional c As String)

        End Sub

        Function MethodeMitRueckgabe(ByVal a As Integer) As Integer
            Return a + 1
        End Function
    End Class

    Module MyModul ' Für Hilfsklassen und globale Variablen, Können nicht instanziert werden

        Sub Main()
            Dim test As New TestClass
            test.KontrollStrukturen()
        End Sub
    End Module

    Public Class Person Inherits PersonBase
        Private _name As String

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property

        'Konstruktor
        Public Sub New()
            _name = "StandartName"
            PersonBase.New() ' Aufruf des Base Konstruktor
        End Sub

        'Konstruktor
        Public Sub New(ByVal name As String)
            Me._name = name
        End Sub


        ' Destructor
        Protected Overrides Sub Finalize()
            Console.WriteLine("Objekt wird gelöscht")
        End Sub

        ' Überladen von Methode von BasePerson
        Public Overloads Sub Test()
            Console.WriteLine("Test")
        End Sub

        'Shadows
        Public Shadows Sub Test2()
            Console.WriteLine("Test2")
        End Sub

    End Class

    Public Class EventExample

        Public Event MyEvent As EventHandler

        Public Sub RaiseEvent()
            RaiseEvent MyEvent(Me, EventArgs.Empty)
        End Sub

    End Class

    Public NotInheritable Class NichtVererbareKlasse
    End Class

    Public MustInherit Class AbstrakteClass
    End Class

End Namespace