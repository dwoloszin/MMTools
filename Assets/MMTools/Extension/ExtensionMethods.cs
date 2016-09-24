﻿using UnityEngine;
using System.Collections;

namespace MoreMountains.Tools
{	
	/// <summary>
	/// Contains all extension methods of the Corgi Engine and Infinite Runner Engine.
	/// </summary>
	public static class ExtensionMethods 
	{
		/// <summary>
		/// Determines if an animator contains a certain parameter, based on a type and a name
		/// </summary>
		/// <returns><c>true</c> if has parameter of type the specified self name type; otherwise, <c>false</c>.</returns>
		/// <param name="self">Self.</param>
		/// <param name="name">Name.</param>
		/// <param name="type">Type.</param>
		public static bool HasParameterOfType (this Animator self, string name, AnimatorControllerParameterType type) 
		{
			if (name == null || name == "") { return false; }
			AnimatorControllerParameter[] parameters = self.parameters;
			foreach (AnimatorControllerParameter currParam in parameters) 
			{
				if (currParam.type == type && currParam.name == name) 
				{
					return true;
				}
			}
			return false;
		}	


        public static bool Contains(this LayerMask mask, int layer) 
        {
             return ((mask.value & (1 << layer)) > 0);
        }
         
		public static bool Contains(this LayerMask mask, GameObject gameobject) 
        {
             return ((mask.value & (1 << gameobject.layer)) > 0);
        }
     
	}
}