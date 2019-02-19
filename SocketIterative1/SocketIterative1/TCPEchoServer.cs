using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace SocketIterative1
{
    public class TCPEchoServer
    {
        private TcpClient _connectionSocket;

        public TCPEchoServer(TcpClient client)
        {
            _connectionSocket = client;
                                           
        }
        public void DoIt()
        {
            NetworkStream ns = _connectionSocket.GetStream();

            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);

            sw.AutoFlush = true;

            string message = sr.ReadLine();

            while (message != "stop")
            {
                Console.WriteLine(message);
                sw.WriteLine(message.ToUpper());
                message = sr.ReadLine();
            }
            ns.Close();
            _connectionSocket.Close();




        }
    }
}