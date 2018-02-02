using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Simulate the delay between client and server.
public class Channel
{
	public void SendControlCode(ControlCode code, bool yes)
	{
		// XXX
	}

	public bool Receive(out Message msg)
	{
		msg.code = ControlCode.Illegal;
		msg.yes = false;
		return false;  // XXX
	}

	public void SendMessage(Message msg)
	{
		// XXX
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

