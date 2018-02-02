using UnityEngine;  // for Debug

// To control the roller.
public struct ControlState {
	public bool isLeft;
	public bool isRight;
	public bool isUp;
	public bool isDown;

	public void Update(ControlCode code, bool yes)
	{
		switch (code)
		{
			case ControlCode.Left:
				isLeft = yes;
				break;
			case ControlCode.Right:
				isRight = yes;
				break;
			case ControlCode.Up:
				isUp = yes;
				break;
			case ControlCode.Down:
				isDown = yes;
				break;
			default:
				Debug.Log("Illegal control code.");
				break;
		}
	}
}
