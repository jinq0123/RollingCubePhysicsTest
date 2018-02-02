using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Server {
	private ChannelC2s chRed2Svr;
	private ChannelS2c chSvr2Red;
	private ChannelC2s chBlue2Svr;
	private ChannelS2c chSvr2Blue;

	public Server(ChannelC2s red2Svr, ChannelS2c svr2Red,
		ChannelC2s blue2Svr, ChannelS2c svr2Blue)
	{
		chRed2Svr = red2Svr;
		chSvr2Red = svr2Red;
		chBlue2Svr = blue2Svr;
		chSvr2Blue = svr2Blue;
	}

	// is called once per frame by Global
	public void Update()
	{
		// Receive control cmds from c2s channel, update control state,
		// and send to another s2c channel.
		Global.HandleCtrlCmds(chRed2Svr, ref redCtrl, chSvr2Blue);
		Global.HandleCtrlCmds(chBlue2Svr, ref blueCtrl, chSvr2Red);
	}

	// Control states are updated by c2s channels and control 2 rollers.
	private ControlState redCtrl;
	private ControlState blueCtrl;
	public ControlState RedCtrl
	{
		get { return redCtrl; }
	}
	public ControlState BlueCtrl
	{
		get { return blueCtrl; }
	}
}
