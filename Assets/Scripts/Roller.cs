using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roller : MonoBehaviour {
	public bool isRed = true;  // Red client or blue client
	public new Rigidbody rigidbody;  // of roller cube

	private float rollThrust = 200.0f;
	private float jumpPower = 500.0F;

	// Use this for initialization
	void Start() {
		GetComponent<Renderer>().material.color =
			isRed ? Global.redColor : Global.blueColor;
	}

	void FixedUpdate() {
		if (Input.GetKey(KeyCode.A))
		{
			rigidbody.AddTorque(Vector3.forward * rollThrust);
		}
		if (Input.GetKey(KeyCode.D))
		{
			rigidbody.AddTorque(-Vector3.forward * rollThrust);
		}
		if (Input.GetKey(KeyCode.W))
		{
			rigidbody.AddTorque(Vector3.right * rollThrust);
		}
		if (Input.GetKey(KeyCode.S))
		{
			rigidbody.AddTorque(-Vector3.right * rollThrust);
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			ExplodeUp();
		}

		// Absorb();
	}

	void ExplodeUp()
	{
		float radius = 5.0F;

		Vector3 explosionPos = transform.position;
		explosionPos.y = 0;
		Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
		foreach (Collider hit in colliders)
		{
			Rigidbody rb = hit.GetComponent<Rigidbody>();

			if (rb != null)
			{
				rb.AddExplosionForce(jumpPower, explosionPos, radius, 3.0F);
			}
		}
	}

	void Absorb()
	{
		float radius = transform.localScale.x * 0.75f;
		Vector3 c = transform.position;
		Collider[] colliders = Physics.OverlapSphere(c, radius);
		foreach (Collider hit in colliders)
		{
			Rigidbody rb = hit.GetComponent<Rigidbody>();

			if (rb != null)
			{
				Vector3 f = c - hit.transform.position;
				rb.AddForce(f*10 / f.sqrMagnitude);
			}
		}
	}

}
