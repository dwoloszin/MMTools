using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace MoreMountains.MultiplayerEngine 
{
	[System.Serializable]
	public class JoystickEvent : UnityEvent<Vector2> {}

	/// <summary>
	/// Joystick input class.
	/// In charge of the behaviour of the joystick mobile touch input.
	/// </summary>
	[RequireComponent(typeof(Rect))]
	[RequireComponent(typeof(CanvasGroup))]
	public class MMTouchJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
	{

		[Header("Enabled Axis")]
		/// The method(s) to call when the button gets pressed down
		public JoystickEvent JoystickValue;

		/// Is horizontal axis allowed
		public bool HorizontalEnabled = true;
		/// Is vertical axis allowed
		public bool VerticalEnabled = true;

		/// Store neutral position of the stick
		protected Vector2 _neutralPosition;
		/// The max range allowed
		public float _maxRange = 40f;
		/// Current horizontal and vertical values of the joystick (from -1 to 1)
		protected Vector2 _joystickValue;


		protected RectTransform _canvasRectTransform;

		/// <summary>
		/// Start this instance.
		/// </summary>
		protected virtual void Start () 
		{
			_neutralPosition = GetComponent<RectTransform>().transform.position;
			_canvasRectTransform = GetComponentInParent<Canvas>().transform as RectTransform;
		}
		
		/// <summary>
		/// Update this instance.
		/// </summary>
		void Update () 
		{
			// We send InputManager positions when axis are allowed
			if (HorizontalEnabled || VerticalEnabled) 
			{
				JoystickValue.Invoke(_joystickValue);
			}
		}

		/// <summary>
		/// When draging stick (finger sliding on the touch surface).
		/// </summary>
		public virtual void OnDrag(PointerEventData data) 
		{
			Vector2 newTargetPosition;

			if (data.pressEventCamera!=null)
			{
				newTargetPosition = data.pressEventCamera.ScreenToWorldPoint(Input.mousePosition);
			}
			else
			{
				newTargetPosition = Input.mousePosition;
			}

			// We clamp stick position to let it moves only inside the joystick circle
			Vector2 newClampedPosition = Vector2.ClampMagnitude(newTargetPosition - _neutralPosition, _maxRange);

			if (!HorizontalEnabled) 
			{
				newClampedPosition.x = 0;
			}
			if (!VerticalEnabled) 
			{
				newClampedPosition.y = 0;
			}
			// For each axis, we evaluation its lerped value (-1...1)
			_joystickValue.x = EvaluateInputValue(newClampedPosition.x);
			_joystickValue.y = EvaluateInputValue(newClampedPosition.y);

			transform.position = _neutralPosition + newClampedPosition;
		}

		public virtual void OnPointerDown(PointerEventData data)
	    {
	        //MMDebug.DebugLogTime("on pointer down");
	    }

		/// <summary>
		/// Raises the pointer up event.
		/// Called when finger is up and doesn't touch the surface anymore.
		/// We reset stick position
		/// </summary>
		public virtual void OnPointerUp(PointerEventData data)
		{
			//MMDebug.DebugLogTime("on pointer up");
			// We neutral position and axis values
			transform.position = _neutralPosition;
			_joystickValue.x = 0f;
			_joystickValue.y = 0f;
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

		Vector2 ClampToWindow (PointerEventData data) 
		{
        Vector2 rawPointerPosition = data.position;

        Vector3[] canvasCorners = new Vector3[4];
        _canvasRectTransform.GetWorldCorners (canvasCorners);
        
        float clampedX = Mathf.Clamp (rawPointerPosition.x, canvasCorners[0].x, canvasCorners[2].x);
        float clampedY = Mathf.Clamp (rawPointerPosition.y, canvasCorners[0].y, canvasCorners[2].y);

        Vector2 newPointerPosition = new Vector2 (clampedX, clampedY);
        return newPointerPosition;
   		 }
	}
}