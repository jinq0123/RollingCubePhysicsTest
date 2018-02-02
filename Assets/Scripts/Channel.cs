using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Simulate the delay between client and server.
public class Channel
{
	private float lag = 0;  // in seconds, half of ping time
	private Queue<TimeMessage> msgQueue;

	public Channel()
	{
		msgQueue = new Queue<TimeMessage>();
	}

	public void SendControlCode(ControlCode code, bool yes)
	{
		Message msg;
		msg.code = code;
		msg.yes = yes;
		SendMessage(msg);
	}

	public bool Receive(out Message msg)
	{
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
		timeMsg.time = Time.time + lag;
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

