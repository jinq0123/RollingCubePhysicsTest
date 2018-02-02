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

	// is called once per frame by Global
	public void Update()
	{
		// Local control input is sent to server, then received from server and applied.
		if (isRed)
		{
			// ASDW keys controls red client.
			if (Input.GetKeyDown(KeyCode.A)) Left(true);
			if (Input.GetKeyUp(KeyCode.A)) Left(false);
			if (Input.GetKeyDown(KeyCode.D)) Right(true);
			if (Input.GetKeyUp(KeyCode.D)) Right(false);
			if (Input.GetKeyDown(KeyCode.W)) Up(true);
			if (Input.GetKeyUp(KeyCode.W)) Up(false);
			if (Input.GetKeyDown(KeyCode.S)) Down(true);
			if (Input.GetKeyUp(KeyCode.S)) Down(false);
		}
		else
		{
			// Arrow keys controls blue client.
			if (Input.GetKeyDown(KeyCode.LeftArrow)) Left(true);
			if (Input.GetKeyUp(KeyCode.LeftArrow)) Left(false);
			if (Input.GetKeyDown(KeyCode.RightArrow)) Right(true);
			if (Input.GetKeyUp(KeyCode.RightArrow)) Right(false);
			if (Input.GetKeyDown(KeyCode.UpArrow)) Up(true);
			if (Input.GetKeyUp(KeyCode.UpArrow)) Up(false);
			if (Input.GetKeyDown(KeyCode.DownArrow)) Down(true);
			if (Input.GetKeyUp(KeyCode.DownArrow)) Down(false);
		}

		Global.HandleCtrlCmds(s2cChannel, HandleS2cMessage);
	}

	private void HandleS2cMessage(Message msg)
	{
		if (msg.isRedRoller)
			redCtrl.Update(msg.code, msg.yes);
		else
			blueCtrl.Update(msg.code, msg.yes);
	}

	// Control states are updated by s2c channel and control 2 rollers.
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

	private void Left(bool yes)
	{
		SendControlCode(ControlCode.Left, yes);
	}
	private void Right(bool yes)
	{
		SendControlCode(ControlCode.Right, yes);
	}
	private void Up(bool yes)
	{
		SendControlCode(ControlCode.Up, yes);
	}
	private void Down(bool yes)
	{
		SendControlCode(ControlCode.Down, yes);
	}

	private void SendControlCode(ControlCode code, bool yes)
	{
		Message msg;
		msg.isRedRoller = isRed;
		msg.code = code;
		msg.yes = yes;
		c2sChannel.SendMessage(msg);
	}
}
