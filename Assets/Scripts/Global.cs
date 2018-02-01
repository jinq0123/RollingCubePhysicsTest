using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global {
	// Red side and blue side colors.
	public static Color redColor = Color.red;
	public static Color blueColor = Color.cyan;
	public static Color normalColor = Color.white;

	public static Client redClient = new Client(true);
	public static Client blueClient = new Client(false);
}
