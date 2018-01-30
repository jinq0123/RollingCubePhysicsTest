using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roller : MonoBehaviour {
	public new Rigidbody rigidbody;
	public float rollThrust = 200.0f;
	public float jumpPower = 500.0F;
	public GameObject cubePrefab;

	// Use this for initialization
	void Start() {
		GetComponent<Renderer>().material.color = Color.red;
		SpawnCubes();
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

		Absorb();
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

	void SpawnCubes()
	{
		int width = 30;
		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < width; j++)
			{
				Instantiate(cubePrefab, new Vector3(i - width / 2f, 0.2501f, j - width / 2f), Quaternion.identity);
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
