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
        public static string serverMsg = "No Msg Recieved";
        public bool Connect(string ip,string port,string username)
        {
            TcpClient cl = new TcpClient();
            int portNumber = int.Parse(port);
            try
            {
                cl.Connect(ip,portNumber);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(cl.GetStream(), username);
                serverMsg = (string) bf.Deserialize(cl.GetStream());
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
