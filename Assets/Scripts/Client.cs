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

	// Controllers are updated by s2c channel and control 2 rollers.
	public RollerController redCtrl = new RollerController();
	public RollerController blueCtrl = new RollerController();

	public void Left(bool yes)
	{
		c2sChannel.SendControlCode(ControlCode.Left, yes);
	}

	public void Right(bool yes)
	{
		c2sChannel.SendControlCode(ControlCode.Right, yes);
	}

	public void Up(bool yes)
	{
		c2sChannel.SendControlCode(ControlCode.Up, yes);
	}

	public void Down(bool yes)
	{
		c2sChannel.SendControlCode(ControlCode.Down, yes);
	}

}
