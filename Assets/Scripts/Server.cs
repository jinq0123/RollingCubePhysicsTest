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

	public RollerCtrlState ctrlStateRed = new RollerCtrlState();
	public RollerCtrlState ctrlStateBlue = new RollerCtrlState();
}
