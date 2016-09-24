using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;

namespace MoreMountains.Tools
{	
	/// <summary>
	/// Various static methods used throughout the Infinite Runner Engine and the Corgi Engine.
	/// </summary>

	public static class MMAnimator 
	{
		// Adds an animator parameter name to a parameter list if that parameter exists.
		public static void AddAnimatorParamaterIfExists(Animator animator, string parameterName, AnimatorControllerParameterType type, List<string> parameterList)
		{
			if (animator.HasParameterOfType(parameterName, type))
			{
				parameterList.Add(parameterName);
			}
		}

		// <summary>
		/// Updates the animator bool.
		/// </summary>
		/// <param name="animator">Animator.</param>
		/// <param name="parameterName">Parameter name.</param>
		/// <param name="value">If set to <c>true</c> value.</param>
		public static void UpdateAnimatorBool(Animator animator, string parameterName,bool value, List<string> parameterList)
		{
			if (parameterList.Contains(parameterName))
			{
				animator.SetBool(parameterName,value);
			}
		}

		public static void UpdateAnimatorTrigger(Animator animator, string parameterName, List<string> parameterList)
		{
			if (parameterList.Contains(parameterName))
			{
				animator.SetTrigger(parameterName);
			}
		}

		/// <summary>
		/// Triggers an animator trigger.
		/// </summary>
		/// <param name="animator">Animator.</param>
		/// <param name="parameterName">Parameter name.</param>
		/// <param name="value">If set to <c>true</c> value.</param>
		public static void SetAnimatorTrigger(Animator animator, string parameterName, List<string> parameterList)
		{
			if (parameterList.Contains(parameterName))
			{
				animator.SetTrigger(parameterName);
			}
		}
		
		/// <summary>
		/// Updates the animator float.
		/// </summary>
		/// <param name="animator">Animator.</param>
		/// <param name="parameterName">Parameter name.</param>
		/// <param name="value">Value.</param>
		public static void UpdateAnimatorFloat(Animator animator, string parameterName,float value, List<string> parameterList)
		{
			if (parameterList.Contains(parameterName))
			{
				animator.SetFloat(parameterName,value);
			}
		}
		
		/// <summary>
		/// Updates the animator integer.
		/// </summary>
		/// <param name="animator">Animator.</param>
		/// <param name="parameterName">Parameter name.</param>
		/// <param name="value">Value.</param>
		public static void UpdateAnimatorInteger(Animator animator, string parameterName,int value, List<string> parameterList)
		{
			if (parameterList.Contains(parameterName))
			{
				animator.SetInteger(parameterName,value);
			}
		}	 




		// <summary>
		/// Updates the animator bool after checking the parameter's existence.
		/// </summary>
		/// <param name="animator">Animator.</param>
		/// <param name="parameterName">Parameter name.</param>
		/// <param name="value">If set to <c>true</c> value.</param>
		public static void UpdateAnimatorBool(Animator animator, string parameterName,bool value)
		{
			animator.SetBool(parameterName,value);
		}

		public static void UpdateAnimatorTrigger(Animator animator, string parameterName)
		{
			animator.SetTrigger(parameterName);
		}

		/// <summary>
		/// Triggers an animator trigger after checking for the parameter's existence.
		/// </summary>
		/// <param name="animator">Animator.</param>
		/// <param name="parameterName">Parameter name.</param>
		/// <param name="value">If set to <c>true</c> value.</param>
		public static void SetAnimatorTrigger(Animator animator, string parameterName)
		{
			animator.SetTrigger(parameterName);
		}
		
		/// <summary>
		/// Updates the animator float after checking for the parameter's existence.
		/// </summary>
		/// <param name="animator">Animator.</param>
		/// <param name="parameterName">Parameter name.</param>
		/// <param name="value">Value.</param>
		public static void UpdateAnimatorFloat(Animator animator, string parameterName,float value)
		{
			animator.SetFloat(parameterName,value);
		}
		
		/// <summary>
		/// Updates the animator integer after checking for the parameter's existence.
		/// </summary>
		/// <param name="animator">Animator.</param>
		/// <param name="parameterName">Parameter name.</param>
		/// <param name="value">Value.</param>
		public static void UpdateAnimatorInteger(Animator animator, string parameterName,int value)
		{
			animator.SetInteger(parameterName,value);
		}  
	}
}
