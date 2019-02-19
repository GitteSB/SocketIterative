using System;
using System.Net;
using System.Net.Sockets;

namespace SocketIterative1
{
    class Program
    {
        static void Main(string[] args)
        {
            // IPAddress ip = new IPAddress("127.0.0.1");

            IPAddress ip = IPAddress.Parse("127.0.0.1");

            TcpListener serverSocket = new TcpListener(ip, 6789);

            //Alternatively but deprecated
            //TcpListener serverSocket = new TcpListener(6789);

            serverSocket.Start();
            Console.WriteLine("Server started");

            while (true)
            {
                TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                TCPEchoServer echoServer = new TCPEchoServer(connectionSocket);
                echoServer.DoIt();
            }
            
        }
    }
}
