using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace MoreMountains.Tools
{	
	[RequireComponent(typeof(Rect))]
	[RequireComponent(typeof(CanvasGroup))]
	/// <summary>
	/// Add this component to a GUI button to have it act as a proxy for a certain action on touch devices.
	/// Detects press down, press up, and continuous press. 
	/// These are really basic mobile/touch controls. I believe that for infinite runners they're sufficient. 
	/// </summary>
	public class MMTouchButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		[Header("Binding")]
		/// The method(s) to call when the button gets pressed down
		public UnityEvent ButtonDown;
		/// The method(s) to call when the button gets released
		public UnityEvent ButtonUp;
		/// The method(s) to call while the button is being pressed
		public UnityEvent ButtonPressed;

		[Header("Behaviour")]
		/// the new opacity to apply to the canvas group when the button is pressed
		public float PressedOpacity = 0.5f;


	    protected bool _zonePressed = false;
	    protected CanvasGroup _canvasGroup;
	    protected float _initialOpacity;

	    protected virtual void Start()
	    {
			_canvasGroup = GetComponent<CanvasGroup>();
			if (_canvasGroup!=null)
			{
				_initialOpacity = _canvasGroup.alpha;
			}
	    }

		/// <summary>
		/// Every frame, if the touch zone is pressed, we trigger the OnPointerPressed method, to detect continuous press
		/// </summary>
		protected virtual void Update()
	    {
	        if (_zonePressed)
	        {
	            OnPointerPressed();
	        }
	    }

		/// <summary>
		/// Triggers the bound pointer down action
		/// </summary>
		public virtual void OnPointerDown(PointerEventData data)
	    {
	        _zonePressed = true;
			if (_canvasGroup!=null)
			{
				_canvasGroup.alpha=PressedOpacity;
			}
			if (ButtonDown!=null)
	        {
				ButtonDown.Invoke();
	        }
	    }

		/// <summary>
		/// Triggers the bound pointer up action
		/// </summary>
		public virtual void OnPointerUp(PointerEventData data)
	    {
	        _zonePressed = false;
			if (_canvasGroup!=null)
			{
				_canvasGroup.alpha=_initialOpacity;
			}
			if (ButtonUp != null)
			{
				ButtonUp.Invoke();
	        }
	    }

		/// <summary>
		/// Triggers the bound pointer pressed action
		/// </summary>
		public virtual void OnPointerPressed()
	    {
			if (ButtonPressed != null)
			{
				ButtonPressed.Invoke();
	        }
	    }
	}
}
