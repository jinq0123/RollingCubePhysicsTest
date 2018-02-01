using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global {
	// Red side and blue side colors.
	public static Color redColor = Color.red;
	public static Color blueColor = Color.cyan;
	public static Color normalColor = Color.white;

	private static ChannelC2s chRed2Svr = new ChannelC2s();
	private static ChannelS2c chSvr2Red = new ChannelS2c();
	private static ChannelC2s chBlue2Svr = new ChannelC2s();
	private static ChannelS2c chSvr2Blue = new ChannelS2c();

	public static Client redClient = new Client(true, chRed2Svr, chSvr2Red);
	public static Client blueClient = new Client(false, chBlue2Svr, chSvr2Blue);

	public static Server server = new Server(chRed2Svr, chSvr2Red, chBlue2Svr, chSvr2Blue);
}
