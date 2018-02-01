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

	private bool isLeft;
	private bool isRight;
	private bool isUp;
	private bool isDown;

	public bool IsLeft
	{
		get { return isLeft; }
		set { isLeft = value; }
	}
	public bool IsRight
	{
		get { return isRight; }
		set { isRight = value; }
	}
	public bool IsUp
	{
		get { return isUp; }
		set { isUp = value; }
	}
	public bool IsDown
	{
		get { return isDown; }
		set { isDown = value; }
	}
}
