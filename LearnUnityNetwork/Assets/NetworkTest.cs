using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkTest : MonoBehaviour {

	int myPort = 16543;//端口号
	string serverIP = "192.168.3.2";//服务器ip
	string yourState = "";
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnGUI() {
		if (GUILayout.Button("Creat Server")) {
			/*创建一个服务器
             * 3个参数
             * 1、允许的入站连接或玩家数量
             * 2、监听的端口
             * 3、设置穿透功能
             */
			Network.InitializeServer(32, myPort,false);
		}
		if (GUILayout.Button("Connect Server")) {
			/*客户端连接服务器*/
			Network.Connect(serverIP, myPort);
		}
		GUILayout.TextArea(yourState);
		switch (Network.peerType) { 
		case NetworkPeerType.Server:
			yourState = "You are Server, The server has Created!";
			GUILayout.TextField("Had "+Network.connections.Length.ToString()+" Connected");
			break;
		case NetworkPeerType.Client:
			yourState = "You are Client";
			break;
		case NetworkPeerType.Connecting:
			yourState = "Connecting...";
			break;
		case NetworkPeerType.Disconnected:
			yourState = "You had not connected the server";
			break;
		}
	}
}
