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

	private static Client redClient = new Client(true, chRed2Svr, chSvr2Red);
	private static Client blueClient = new Client(false, chBlue2Svr, chSvr2Blue);

	private static Server server = new Server(chRed2Svr, chSvr2Red, chBlue2Svr, chSvr2Blue);

	public static void Configure(uint redPingInMs, uint bluePingInMs)
	{
		chRed2Svr.SetLagInMs(redPingInMs / 2);
		chSvr2Red.SetLagInMs(redPingInMs / 2);

		chBlue2Svr.SetLagInMs(bluePingInMs / 2);
		chSvr2Blue.SetLagInMs(bluePingInMs / 2);
	}

	// UpdateClientsAndServer is called once per frame
	public static void UpdateClientsAndServer()
	{
		redClient.Update();
		blueClient.Update();
		server.Update();
	}

	public static ControlState GetControlState(bool isServer, bool isRedClient, bool isRedRoller)
	{
		if (isServer)
		{
			if (isRedRoller) return server.RedCtrl;
			return server.BlueCtrl;
		}
		if (isRedClient)
		{
			if (isRedRoller) return redClient.RedCtrl;
			return redClient.BlueCtrl;
		}
		if (isRedRoller) return blueClient.RedCtrl;
		return blueClient.BlueCtrl;
	}

	public delegate void MessageHandler(Message msg);

	// Receive control messages from input channel and dispose them.
	public static void HandleCtrlCmds(Channel chFrom, MessageHandler handler)
	{
		Message msg;
		while (chFrom.Receive(out msg))
		{
			handler(msg);
		}
	}
}
