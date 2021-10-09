﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkTest : MonoBehaviour {

	string ip = "192.168.3.2";
	string port = "16543";

	void OnGUI() {

		switch (Network.peerType) {
		case NetworkPeerType.Disconnected:
			GUILayout.Label ("尚未建立任何连接。");

			ip = GUILayout.TextField (ip);
			port = GUILayout.TextField (port);

			if (GUILayout.Button ("连接")) {
				Network.Connect (ip, int.Parse (port));
			}

			if (GUILayout.Button ("使用上述端口开设服务器")) {
				Network.InitializeServer (32, int.Parse (port), false);
			}
			break;

		case NetworkPeerType.Connecting:
			GUILayout.Label ("正在连接...");
			break;
		
		case NetworkPeerType.Server:
			GUILayout.Label ("服务器已开设。地址：" + ip + ":" + port);
			GUILayout.Label ("有" + Network.connections.Length.ToString () + "个客户端与这个服务器建立了连接。");
			if (GUILayout.Button ("断开连接/终止服务器")) {
				Network.Disconnect ();
			}
			break;

		case NetworkPeerType.Client:
			GUILayout.TextField ("已连接。");
			if (GUILayout.Button ("断开连接/终止服务器")) {
				Network.Disconnect ();
			}
			break;
		}
	}
}
