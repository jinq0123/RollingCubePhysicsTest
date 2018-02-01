using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {
	public GameObject cubePrefab;

	// Use this for initialization
	void Start () {
		SpawnCubes();
	}

	// Update is called once per frame
	void Update () {
		
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
}
