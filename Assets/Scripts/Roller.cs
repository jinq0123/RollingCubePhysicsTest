using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roller : MonoBehaviour {
	public bool isRed = true;  // Red client or blue client
	public new Rigidbody rigidbody;  // of roller cube

	private float rollThrust = 200.0f;

	// Use this for initialization
	void Start() {
		GetComponent<Renderer>().material.color =
			isRed ? Global.redColor : Global.blueColor;
	}

	void FixedUpdate() {
		Attract();

		Client clt = isRed ? Global.redClient : Global.blueClient;
		if (clt.IsLeft)
			rigidbody.AddTorque(Vector3.forward * rollThrust);
		if (clt.IsRight)
			rigidbody.AddTorque(-Vector3.forward * rollThrust);
		if (clt.IsUp)
			rigidbody.AddTorque(Vector3.right * rollThrust);
		if (clt.IsDown)
			rigidbody.AddTorque(-Vector3.right * rollThrust);
	}

	void Attract()
	{
		float radius = transform.localScale.x * 0.75f;
		Vector3 c = transform.position;
		Collider[] colliders = Physics.OverlapSphere(c, radius);
		foreach (Collider hit in colliders)
		{
			Rigidbody rb = hit.GetComponent<Rigidbody>();

			if (rb != null && rb != rigidbody)
			{
				Vector3 f = c - hit.transform.position;
				rb.AddForce(f*10 / f.sqrMagnitude);
			}
		}
	}
}
