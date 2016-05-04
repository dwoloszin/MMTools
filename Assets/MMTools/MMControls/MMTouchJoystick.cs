using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using UnityEngine.EventSystems;

namespace MoreMountains.MultiplayerEngine 
{

	/// <summary>
	/// Joystick input class.
	/// In charge of the behaviour of the joystick mobile touch input.
	/// </summary>
	[RequireComponent(typeof(Rect))]
	[RequireComponent(typeof(CanvasGroup))]
	public class MMTouchJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
	{

		[Header("Axis allowed")]
		/// <summary>
		/// Is horizontal axis allowed
		/// </summary>
		public bool Horizontal = true;
		/// <summary>
		/// Is vertical axis allowed
		/// </summary>
		public bool Vertical = true;

		/// <summary>
		/// Store neutral position of the stick
		/// </summary>
		protected Vector2 _neutralPosition;

		/// <summary>
		/// The max range allowed
		/// </summary>
		public float _maxRange = 40f;

		/// <summary>
		/// Current horizontal axis value (from -1 to +1)
		/// </summary>
		protected float x = 0f;

		/// <summary>
		/// Current vertical axis value (from -1 to +1)
		/// </summary>
		protected float y = 0f;

		/// <summary>
		/// Start this instance.
		/// </summary>
		protected virtual void Start () {
			_neutralPosition = GetComponent<RectTransform>().transform.position;
		}
		
		/// <summary>
		/// Update this instance.
		/// </summary>
		void Update () 
		{
			// We send InputManager positions when axis are allowed
			if (Horizontal) 
			{
				//InputManager.Instance.SendMessage("HorizontalPosition", x);
			}
			if (Vertical) 
			{
				//InputManager.Instance.SendMessage("VerticalPosition", y);
			}
		}

		/// <summary>
		/// When draging stick (finger sliding on the touch surface).
		/// </summary>
		public virtual void OnDrag(PointerEventData data) 
		{
			Vector2 newTargetPosition = Input.mousePosition;
			Vector2 convertedTargetPosition = GUIUtility.ScreenToGUIPoint(newTargetPosition);
			MMDebug.DebugDrawArrow(transform.position,newTargetPosition,Color.yellow);
			// We clamp stick position to let it moves only inside the joystick circle
			Vector2 newClampedPosition = Vector2.ClampMagnitude(convertedTargetPosition - _neutralPosition, _maxRange);

			if (!Horizontal) {
				newClampedPosition.x = 0;
			}
			if (!Vertical) {
				newClampedPosition.y = 0;
			}
			// For each axis, we evaluation its lerped value (-1...1)
			x = EvaluateInputValue(newClampedPosition.x);
			y = EvaluateInputValue(newClampedPosition.y);

			transform.position = _neutralPosition + newClampedPosition;
		}

		public virtual void OnPointerDown(PointerEventData data)
	    {
	        MMDebug.DebugLogTime("on pointer down");
	    }

		/// <summary>
		/// Raises the pointer up event.
		/// Called when finger is up and doesn't touch the surface anymore.
		/// We reset stick position
		/// </summary>
		public virtual void OnPointerUp(PointerEventData data)
		{
			MMDebug.DebugLogTime("on pointer up");
			// We neutral position and axis values
			transform.position = _neutralPosition;
			x = 0f;
			y = 0f;
		}

		/// <summary>
		/// We calculate axis value from the interval between neutral position, current stick position (vectorPosition) and max range
		/// </summary>
		/// <returns>The axis value, a float between -1 and 1</returns>
		/// <param name="vectorPosition">stick position.</param>
		protected virtual float EvaluateInputValue(float vectorPosition) 
		{
			return Mathf.InverseLerp(0, _maxRange, Mathf.Abs(vectorPosition)) * Mathf.Sign(vectorPosition);
		}
	}
}