using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionColor : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
	}

	//// Update is called once per frame
	//void Update()
	//{
	//}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name != "Roller" &&
			collision.gameObject.name != "Cube(Clone)")
		{
			return;
		}

		GetComponent<Renderer>().material.color = Color.red;
		CancelInvoke();
		Invoke("RecoverColor", 5f);
	}

	private void RecoverColor()
    {
		GetComponent<Renderer>().material.color = Color.white;
    }
}
