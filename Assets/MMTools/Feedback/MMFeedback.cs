using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MoreMountains.NiceVibrations;

namespace MoreMountains.Tools
{
	[Serializable]
	public class MMFeedback 
	{
		public ParticleSystem Particles;
		public AudioClip Sfx;
		public MMCameraShakeProperties CameraShakeProperties;
		public HapticTypes HapticFeedback = HapticTypes.LightImpact;
		public bool TriggerFlash;
		public Color FlashColor = Color.white;

		public virtual void Stop()
		{
			//TODO
			if (Particles != null)
			{
				Particles.Stop();
			}
		}

		public virtual void Play()
		{
			//TODO
			if (Particles != null)
			{
				//Particles.Clear();
				Particles.Play();	
			}

			if (CameraShakeProperties.Duration > 0)
			{
				MMEventManager.TriggerEvent (new MMCameraShakeEvent (CameraShakeProperties.Duration, CameraShakeProperties.Amplitude, CameraShakeProperties.Frequency));
			}
		}
	}
}
