/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatroom_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;

namespace Chatroom_System
{
    class Server
    {
        static void Main(string[] args)
        {
            if (true)
            {
                string ipString = "192.168.1.189";
                IPAddress ip = IPAddress.Parse(ipString);
                TcpListener serverSocket = new TcpListener(ip, 8080);
                int requestCount = 0;
                TcpClient clientSocket = default(TcpClient);
                serverSocket.Start();
                Console.WriteLine(" >> Server Started");
                clientSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine(" >> Accept connection from client");
                requestCount = 0;

                while (true)
                {
                    try
                    {
                        requestCount = requestCount + 1;
                        NetworkStream networkStream = clientSocket.GetStream();
                        byte[] bytesFrom = new byte[10025];
                        networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                        string dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                        dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                        Console.WriteLine(" >> Data from client - " + dataFromClient);
                        string serverResponse = "Last Message from client" + dataFromClient;
                        Byte[] sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                        networkStream.Write(sendBytes, 0, sendBytes.Length);
                        networkStream.Flush();
                        Console.WriteLine(" >> " + serverResponse);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                        break;
                    }
                }

                clientSocket.Close();
                serverSocket.Stop();
                Console.WriteLine(" >> exit");
                Console.ReadLine();
            }
            else
            {

            }
        }
    }
}