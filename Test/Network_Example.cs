using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Test {
    public class Network_Example {
        public void DNS_Methode() {
            IPHostEntry hostEntry = Dns.Resolve("www.google.com");
            foreach (IPAddress ip in hostEntry.AddressList) {
                Console.WriteLine(ip.ToString());
            }
        }
    }

    public class ServerExample {
        static void Main() {
            // IP-Adresse und Port definieren
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 5000);

            // Socket erstellen
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try {
                // Socket an Endpunkt binden und lauschen
                serverSocket.Bind(localEndPoint);
                serverSocket.Listen(10); // Bis zu 10 Verbindungen in der Warteschlange

                Console.WriteLine("Server gestartet und wartet auf Verbindungen...");

                while (true) {
                    // Eingehende Verbindung akzeptieren
                    Socket clientSocket = serverSocket.Accept();
                    Console.WriteLine("Ein Client hat sich verbunden!");

                    // Daten empfangen
                    byte[] buffer = new byte[1024];
                    int bytesRead = clientSocket.Receive(buffer);
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Empfangene Nachricht: {message}");

                    // Antwort senden
                    string response = $"Echo: {message}";
                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    clientSocket.Send(responseBytes);

                    clientSocket.Shutdown(SocketShutdown.Both);

                    // Verbindung schließen
                    clientSocket.Close();
                }
            } catch (Exception ex) {
                Console.WriteLine($"Fehler: {ex.Message}");
            } finally {
                serverSocket.Close();
            }
        }
    }


    class ClientExample {
        static void Main() {
            // IP-Adresse und Port des Servers definieren
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEndPoint = new IPEndPoint(ipAddress, 5000);

            // Socket erstellen
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try {
                // Verbindung zum Server herstellen
                clientSocket.Connect(remoteEndPoint);
                Console.WriteLine("Verbunden mit dem Server.");

                // Nachricht senden
                string message = "Hallo, Server!";
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                clientSocket.Send(messageBytes);
                Console.WriteLine($"Gesendete Nachricht: {message}");

                // Antwort empfangen
                byte[] buffer = new byte[1024];
                int bytesRead = clientSocket.Receive(buffer);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Antwort vom Server: {response}");

                clientSocket.Shutdown(SocketShutdown.Both);

                // Verbindung schließen
                clientSocket.Close();
            } catch (Exception ex) {
                Console.WriteLine($"Fehler: {ex.Message}");
            }
        }
    }
}
