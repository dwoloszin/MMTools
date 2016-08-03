﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace MoreMountains.Tools
{	
	[System.Serializable]
	public class AxisEvent : UnityEvent<float> {}

	[RequireComponent(typeof(Rect))]
	[RequireComponent(typeof(CanvasGroup))]
	/// <summary>
	/// Add this component to a GUI Image to have it act as an axis. 
	/// Bind pressed down, pressed continually and released actions to it from the inspector
	/// Handles mouse and multi touch
	/// </summary>
	public class MMTouchAxis : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		[Header("Binding")]
		/// The method(s) to call when the axis gets pressed down
		public UnityEvent AxisPressedFirstTime;
		/// The method(s) to call when the axis gets released
		public UnityEvent AxisReleased;
		/// The method(s) to call while the axis is being pressed
		public AxisEvent AxisPressed;

		[Header("Pressed Behaviour")]
		[Information("Here you can set the opacity of the button when it's pressed. Useful for visual feedback.",InformationAttribute.InformationType.Info,false)]
		/// the new opacity to apply to the canvas group when the axis is pressed
		public float PressedOpacity = 0.5f;
		/// the value to send the bound method when the axis is pressed
		public float AxisValue;

	    protected bool _zonePressed = false;
	    protected CanvasGroup _canvasGroup;
	    protected float _initialOpacity;

	    /// <summary>
	    /// On Start, we get our canvasgroup and set our initial alpha
	    /// </summary>
	    protected virtual void Awake()
	    {
			_canvasGroup = GetComponent<CanvasGroup>();
			if (_canvasGroup!=null)
			{
				_initialOpacity = _canvasGroup.alpha;
			}
			ResetButton();
	    }

		/// <summary>
		/// Every frame, if the touch zone is pressed, we trigger the bound method if it exists
		/// </summary>
		protected virtual void Update()
	    {
			if (AxisPressed != null)
			{
				if (_zonePressed)
		        {
					AxisPressed.Invoke(AxisValue);
		        }
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
			if (AxisPressedFirstTime!=null)
	        {
				AxisPressedFirstTime.Invoke();
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
			if (AxisReleased != null)
			{
				AxisReleased.Invoke();
			}
			AxisPressed.Invoke(0);
	    }

		/// <summary>
	    /// OnEnable, we reset our button state
	    /// </summary>
		protected virtual void OnEnable()
	    {
			ResetButton();
	    }

	    /// <summary>
	    /// Resets the button's state and opacity
	    /// </summary>
	    protected virtual void ResetButton()
	    {
			_zonePressed=false;
			_canvasGroup.alpha = _initialOpacity;
	    }
	}
}