using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace tttPlayer
{
    class ClientPly
    {
        public static string serverMsg = "Nil";
        public static string playerNo = "Nil";
        BinaryFormatter bf = new BinaryFormatter();
        TcpClient cl = new TcpClient();
        //NetworkStream stream;
        public static string winner = "Nil";
        
        public ClientPly(string ipR,string port,string username)
        {
            Connect(ipR,port, username);
        }
        public void Connect(string ip,string port,string username)
        {
            //stream = cl.GetStream();
            int portNumber = int.Parse(port);
            //ipGlb = ip;
            //portGlb = portNumber;
            try
            {
                cl.Connect(ip,portNumber);
                //BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(cl.GetStream(), username);
                string msgRcv = (string) bf.Deserialize(cl.GetStream());
                serverMsg = ($"You are player {msgRcv}");
                playerNo = msgRcv;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void SendAction(string grid,string btnName)
        {
            //if(!cl.Connected)
            //{
            //    cl.Connect(ipGlb, portGlb);
            //}
            string msg = $"{btnName}:{grid}";
            bf.Serialize(cl.GetStream(), msg);
        }
        public string RecieveAction(ref string plName)
        {
            
            //if(!cl.Connected)
            //{
            //    cl.Connect(ipGlb, portGlb);
            //}
            string msg = (string)bf.Deserialize(cl.GetStream());

            string[] data = msg.Split(':');
            string btnName = data[0];
            plName = data[1];
            winner = data[2];
            return btnName;
        }
        
    }
}
