using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		Client clt;
		clt = Global.redClient;
		if (Input.GetKeyDown(KeyCode.A)) clt.IsLeft = true;
		if (Input.GetKeyUp(KeyCode.A)) clt.IsLeft = false;
		if (Input.GetKeyDown(KeyCode.D)) clt.IsRight = true;
		if (Input.GetKeyUp(KeyCode.D)) clt.IsRight = false;
		if (Input.GetKeyDown(KeyCode.W)) clt.IsUp = true;
		if (Input.GetKeyUp(KeyCode.W)) clt.IsUp = false;
		if (Input.GetKeyDown(KeyCode.S)) clt.IsDown = true;
		if (Input.GetKeyUp(KeyCode.S)) clt.IsDown = false;

		clt = Global.blueClient;
		if (Input.GetKeyDown(KeyCode.LeftArrow)) clt.IsLeft = true;
		if (Input.GetKeyUp(KeyCode.LeftArrow)) clt.IsLeft = false;
		if (Input.GetKeyDown(KeyCode.RightArrow)) clt.IsRight = true;
		if (Input.GetKeyUp(KeyCode.RightArrow)) clt.IsRight = false;
		if (Input.GetKeyDown(KeyCode.UpArrow)) clt.IsUp = true;
		if (Input.GetKeyUp(KeyCode.UpArrow)) clt.IsUp = false;
		if (Input.GetKeyDown(KeyCode.DownArrow)) clt.IsDown = true;
		if (Input.GetKeyUp(KeyCode.DownArrow)) clt.IsDown = false;
	}

	void InstantiateCubes()
	{
		int width = 30;
		for (int i = 0; i < width; i++)
			for (int j = 0; j < width; j++)
				for (int x = -100; x <= 100; x = x + 100)
					Instantiate(cubePrefab, new Vector3(
						x + i - width / 2f, 0.2501f, j - width / 2f),
						Quaternion.identity);
	}
}
