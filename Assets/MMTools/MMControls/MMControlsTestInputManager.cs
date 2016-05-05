using UnityEngine;
using System.Collections;
using MoreMountains.Tools;

namespace MoreMountains.CorgiEngine
{	
	/// <summary>
	/// This persistent singleton handles the inputs and sends commands to the player
	/// </summary>
	public class MMControlsTestInputManager : MonoBehaviour
	{

		public virtual void Movement(Vector2 movement)
		{
			MMDebug.DebugOnScreen("horizontal movement",movement);
		}
		
		public virtual void Jump()
		{
			MMDebug.DebugLogTime("Jump");
		}
		
		public virtual void Dash()
		{
			MMDebug.DebugLogTime("Dash");
		}
		
		public virtual void Jetpack()
		{
			MMDebug.DebugLogTime("Jetpack");
		}
		
		public virtual void Run()
		{
			MMDebug.DebugLogTime("Run");
		}
	}
}