using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;

public class dash : MonoBehaviour
{
    Thread receiveThread;
    UdpClient client;
    public int port = 5244;
    public bool startRecieving = true;
    public bool printToConsole = false;
    public string data;
    string DataBuffer;
    //public Transform spacecraftPostion;
   // public GameObject[] prefab;
   // public float shootSpeed = 1f;
    public int numberOfbulletLeft = 30;
    bool dashing = false;
    //  public Rigidbody bulletPrefab;

    public Rigidbody rb;
    public float speed =3f;
    public float dashPower = 2f;
    public bool iSdashing = false;
    public float dashTime = 1f;
    public bool canDash = false;
    void Start()
    {
        receiveThread = new Thread(
            new ThreadStart(ReceiveShootingData));
        receiveThread.IsBackground = true;
        receiveThread.Start();

    }


    // Update is called once per frame
    void Update()
    {
        if (dashing) {

            StartCoroutine(ddash());
        }

    }
    private void ReceiveShootingData()
    {
        client = new UdpClient(port);
        while (startRecieving)
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] dataByte = client.Receive(ref anyIP);
                data = Encoding.UTF8.GetString(dataByte);
                //Debug.Log(data);
             
                 if(data == "['dashing']")
                      dashing = true;
                 if (data == "['not_dashing']")
                      dashing = false;
                 if (printToConsole)
                         Debug.Log(data);
            }
            catch (Exception err)
            {
                // Debug.Log(err.ToString());
            }

        }

    }
    private IEnumerator ddash() {
        //iSdashing = false;
        //rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        canDash = false;
        //rb.velocity = new Vector2(-transform.right.x * dashPower, -transform.right.y);
        rb.AddRelativeForce(transform.right * dashPower);
        iSdashing = true;
        yield return new WaitForSeconds(dashTime);
        iSdashing = false;
        rb.velocity = new Vector2(0, 0);
        canDash = true;

    }
    
}
