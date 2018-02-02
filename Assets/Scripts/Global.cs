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

	// Receive control cmds from input channel, update control state.
	// The server need to forward cmd to another s2c channel.
	public static void HandleCtrlCmds(Channel chFrom, ref ControlState ctrl, Channel chTo = null)
	{
		Message msg;
		while (chFrom.Receive(out msg))
		{
			UpdateControlState(msg, ref ctrl);
			if (chTo != null) chTo.SendMessage(msg);
		}
	}

	private static void UpdateControlState(Message msg, ref ControlState ctrl)
	{
		switch (msg.code)
		{
			case ControlCode.Left:
				ctrl.isLeft = msg.yes;
				break;
			case ControlCode.Right:
				ctrl.isRight = msg.yes;
				break;
			case ControlCode.Up:
				ctrl.isUp = msg.yes;
				break;
			case ControlCode.Down:
				ctrl.isDown = msg.yes;
				break;
			default:
				Debug.Log("Illegal control code.");
				break;
		}
	}

}
