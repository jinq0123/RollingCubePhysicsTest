using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client {
	private bool isRed = false;

	public Client(bool bRed)
	{
		isRed = bRed;
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
