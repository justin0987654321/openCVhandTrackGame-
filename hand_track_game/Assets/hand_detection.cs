using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class hand_detection : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    Thread receiveThread;
    UdpClient client;
    public int port = 5052;
    public bool startRecieving = true;
    public bool printToConsole = false;
    public string data;

    void Start() {
       receiveThread = new Thread(
           new ThreadStart(ReceiveData));
       receiveThread.IsBackground = true;
       receiveThread.Start();

    }
    private void ReceiveData()
    {
        client = new UdpClient(port);
        while (startRecieving)
        {
            try {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] dataByte = client.Receive(ref anyIP);
                data = Encoding.UTF8.GetString(dataByte);
               // if (printToConsole)
                  //  Debug.Log(data); 
            }
            catch (Exception err){
              //  Debug.Log(err.ToString());
            }

        }


    }




}
