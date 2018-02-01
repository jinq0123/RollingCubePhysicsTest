using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roller : MonoBehaviour {
	public bool isServer;  // Is server roller?
	public bool isRedClient;  // Is red client? Red client has a blue roller.
	public bool isRedRoller;  // Is roller red or blue?
	public new Rigidbody rigidbody;  // of roller cube

	private float rollThrust = 200.0f;

	// Use this for initialization
	void Start() {
		GetComponent<Renderer>().material.color =
			isRedRoller ? Global.redColor : Global.blueColor;
	}

	void FixedUpdate() {
		AttractCubesAround();

		// Get my controller.
		RollerCtrlState ctrl = GetRollerCtrlState();

		// Roll my body.
		if (ctrl.IsLeft)
			rigidbody.AddTorque(Vector3.forward * rollThrust);
		if (ctrl.IsRight)
			rigidbody.AddTorque(-Vector3.forward * rollThrust);
		if (ctrl.IsUp)
			rigidbody.AddTorque(Vector3.right * rollThrust);
		if (ctrl.IsDown)
			rigidbody.AddTorque(-Vector3.right * rollThrust);
	}

	void AttractCubesAround()
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

	private RollerCtrlState GetRollerCtrlState()
	{
		if (isServer)
		{
			if (isRedRoller) return Global.server.ctrlStateRed;
			return Global.server.ctrlStateBlue;
		}
		if (isRedClient)
		{
			if (isRedRoller) return Global.redClient.ctrlStateRed;
			return Global.redClient.ctrlStateBlue;
		}
		if (isRedRoller) return Global.blueClient.ctrlStateRed;
		return Global.blueClient.ctrlStateBlue;
	}
}
