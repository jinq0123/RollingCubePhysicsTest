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
		Global.UpdateClientsAndServer();
	}

	void InstantiateCubes()
	{
		int rowCount = 30;
		int colCount = 30;
		float cubeSize = 0.1f;
		float rs = cubeSize * 3;  // row space
		float cs = cubeSize * 2;  // col space
		for (int r = -rowCount / 2; r <= rowCount / 2; r++)
			for (int c = -colCount / 2; c < colCount / 2; c++)
				for (int x = -100; x <= 100; x = x + 100)  // plane.x
					Instantiate(cubePrefab, new Vector3(
						x + rs * c, cubeSize, cs * r),
						Quaternion.identity);
	}
}
