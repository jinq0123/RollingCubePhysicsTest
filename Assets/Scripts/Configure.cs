using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configure : MonoBehaviour {
	public uint redPingInMs = 50;
	public uint bluePingInMs = 50;

	// Use this for initialization
	void Start () {
		SetConfigure();
	}

	void SetConfigure()
	{
		Global.Configure(redPingInMs, bluePingInMs);
	}
	
	//// Update is called once per frame
	//void Update () {
		
	//}

#if UNITY_EDITOR

	void Reset()
	{
		Debug.Log("Configure脚本添加");
		SetConfigure();
	}


	void OnValidate()
	{
		Debug.Log("Configure数据发生改变");
		SetConfigure();
	}

#endif
}
