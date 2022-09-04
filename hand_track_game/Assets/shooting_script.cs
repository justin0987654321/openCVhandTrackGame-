using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
public class shooting_script : MonoBehaviour
{
    Thread receiveThread;
    UdpClient client;
    public int port = 5234;
    public bool startRecieving = true;
    public bool printToConsole = false;
    public string data;
    private bool Is_shooting = false;
    string DataBuffer;
    public Transform spacecraftPostion;
    public GameObject[] prefab;
    public float shootSpeed = 1f;
    public int numberOfbulletLeft = 30;
    bool dashing = false;
  //  public Rigidbody bulletPrefab;


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
        if (Is_shooting)
            shoot_bullet_(); //  StartCoroutine(shoot_bullet_()); //  shoot_bullet_();
        else
            Debug.Log("not shooting");

        if (dashing)
            Debug.Log("Dashing");



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
                if (data == "['true']")
                    Is_shooting = true;
                if (data == "['false']")
                    Is_shooting = false;
              /*  if(data == "['is_dashing']")
                    dashing = true;
                if (data == "['not_dashing']")
                    dashing = false;
                /* if (printToConsole)
                       Debug.Log(data);*/
            }
            catch (Exception err)
            {
                // Debug.Log(err.ToString());
            }

        }

    }
     void shoot_bullet_()
    {

            Vector3 shoot_dir = prefab[2].GetComponent<Player_control_script>().v_diff;
            // Transform  rot = prefab[1].GetComponent<Player_control_script>().rot;
            // print(rot.rotation);
            //yield return new WaitForSeconds(0.5f);
            GameObject Bullet_transform = Instantiate(prefab[0], prefab[1].transform.position, prefab[2].GetComponent<Player_control_script>().rot.rotation);
            Destroy(Bullet_transform, 5f);
            // Bullet_transform.GetComponent<Rigidbody>().velocity = transform.right * shootSpeed;

            Bullet_transform.GetComponent<Rigidbody>().AddRelativeForce(-transform.right * shootSpeed);

            // GameObject Bullet_transform = Instantiate(prefab[0], spacecraftPostion.position, Quaternion.identity);
            //Bullet_transform.GetComponent<bullet>().setup(shoot_dir);
            Is_shooting = false;
        
    }
}
