using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class Wireless : MonoBehaviour
{

    const string hostIP = "192.168.128.1";
    const int port = 80;

    private SocketClienttt socketClient;
    public bool isTrigger;
    public char cmd;



    private void Awake()
    {
        socketClient = new SocketClienttt(hostIP, port);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isTrigger = socketClient.isTrigger;
        cmd = socketClient.cmd;
    }

    void OnDestroy()
    {
        socketClient.Close();
    }
}
