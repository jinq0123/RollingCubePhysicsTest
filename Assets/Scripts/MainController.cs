using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Init the scene and get user input.
public class MainController : MonoBehaviour {
	public Camera serverCamera;
	public Camera redClientCamera;
	public Camera blueClientCamera;

	public GameObject cubePrefab;

	// Use this for initialization
	void Start () {
		InstantiateCubes();

		// Set server view on the top,
		// red client view on the bottom left,
		// blue client view on the bottom rigth.
		int w = Screen.width;
		int h = Screen.height;
		serverCamera.pixelRect = new Rect(0, h / 2 + 1, w, h / 2 - 1);
		redClientCamera.pixelRect = new Rect(0, 0, w / 2 - 1, h / 2 - 1);
		blueClientCamera.pixelRect = new Rect(w / 2 + 1, 0, w / 2 - 1, h / 2 - 1);
	}

	// Update is called once per frame
	void Update () {
		// ASDW keys controls red client.
		Client red = Global.redClient;
		if (Input.GetKeyDown(KeyCode.A)) red.Left(true);
		if (Input.GetKeyUp(KeyCode.A)) red.Left(false);
		if (Input.GetKeyDown(KeyCode.D)) red.Right(true);
		if (Input.GetKeyUp(KeyCode.D)) red.Right(false);
		if (Input.GetKeyDown(KeyCode.W)) red.Up(true);
		if (Input.GetKeyUp(KeyCode.W)) red.Up(false);
		if (Input.GetKeyDown(KeyCode.S)) red.Down(true);
		if (Input.GetKeyUp(KeyCode.S)) red.Down(false);

		// Arrow keys controls blue client.
		Client blue = Global.blueClient;
		if (Input.GetKeyDown(KeyCode.LeftArrow)) blue.Left(true);
		if (Input.GetKeyUp(KeyCode.LeftArrow)) blue.Left(false);
		if (Input.GetKeyDown(KeyCode.RightArrow)) blue.Right(true);
		if (Input.GetKeyUp(KeyCode.RightArrow)) blue.Right(false);
		if (Input.GetKeyDown(KeyCode.UpArrow)) blue.Up(true);
		if (Input.GetKeyUp(KeyCode.UpArrow)) blue.Up(false);
		if (Input.GetKeyDown(KeyCode.DownArrow)) blue.Down(true);
		if (Input.GetKeyUp(KeyCode.DownArrow)) blue.Down(false);
	}

	void InstantiateCubes()
	{
		int width = 30;
		for (int i = 0; i < width; i++)
			for (int j = 0; j < width; j++)
				for (int x = -100; x <= 100; x = x + 100)  // plane.x
					Instantiate(cubePrefab, new Vector3(
						x + i - width / 2f, 0.2501f, j - width / 2f),
						Quaternion.identity);
	}
}
