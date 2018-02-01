using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionColor : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
		ResetColor();
	}

	//// Update is called once per frame
	//void Update()
	//{
	//}

	void OnCollisionEnter(Collision collision)
	{
		Material myMaterial = GetComponent<Renderer>().material;
		Color myColor = myMaterial.color;
		if (myColor == Global.redColor || myColor == Global.blueColor)
			return;

		Color hitColor = GetColorOf(collision.gameObject);
		if (hitColor != Global.redColor &&
			hitColor != Global.blueColor)
		{
			return;  // hit by ground or normal cube
		}

		// Change color to hit object.
		myMaterial.color = hitColor;
		CancelInvoke();
		Invoke("ResetColor", 5f);
	}

	// Get color of hit object.
	Color GetColorOf(GameObject hitObj)
	{
		string name = hitObj.name;
		if (name == "RollerRed")
			return Global.redColor;
		if (name == "RollerBlue")
			return Global.blueColor;
		if (name != "Cube(Clone)")
			return Global.normalColor;

		return hitObj.GetComponent<Renderer>().material.color;
	}

	private void ResetColor()
	{
		GetComponent<Renderer>().material.color = Global.normalColor;
	}
}
