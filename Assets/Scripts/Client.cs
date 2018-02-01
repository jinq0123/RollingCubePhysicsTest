using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client {
	private bool isRed;
	private ChannelC2s c2sChannel;
	private ChannelS2c s2cChannel;

	public Client(bool bRed, ChannelC2s c2s, ChannelS2c s2c)
	{
		isRed = bRed;
		c2sChannel = c2s;
		s2cChannel = s2c;
	}

	public RollerCtrlState ctrlStateRed = new RollerCtrlState();
	public RollerCtrlState ctrlStateBlue = new RollerCtrlState();
}
