﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Simulate the delay between client and server.
public class Channel
{
	private float lagSec = 0;  // in seconds, half of ping time
	private Queue<TimeMessage> msgQueue;

	public Channel()
	{
		msgQueue = new Queue<TimeMessage>();
	}

	public void SetLagInMs(uint lagMs)
	{
		lagSec = lagMs / 1000f;
	}

	public bool Receive(out Message msg)
	{
		msg.isRedRoller = false;
		msg.code = ControlCode.Illegal;
		msg.yes = false;
		if (msgQueue.Count == 0)
			return false;
		TimeMessage timeMsg = msgQueue.Peek();
		if (timeMsg.time >= Time.time)
			return false;

		msgQueue.Dequeue();
		msg = timeMsg.msg;
		return true;
	}

	public void SendMessage(Message msg)
	{
		TimeMessage timeMsg;
		timeMsg.time = Time.time + lagSec;
		timeMsg.msg = msg;
		msgQueue.Enqueue(timeMsg);
	}
}

public class ChannelS2c : Channel
{
}

// Client send  user input to server.
// Todo: Send status snapshot to server, if the server has no physics.
public class ChannelC2s : Channel
{
}

