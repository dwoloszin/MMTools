using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using MoreMountains.Tools;

namespace MoreMountains.ToolsForThirdParty
{
    public class MMLensDistortion : MonoBehaviour
    {
        protected LensDistortion _lensDistortion;
        protected PostProcessVolume _volume;

        protected virtual void Awake()
        {
            _volume = this.gameObject.GetComponent<PostProcessVolume>();
            _volume.profile.TryGetSettings(out _lensDistortion);
        }

        public virtual void SetIntensity(float newIntensity)
        {
            _lensDistortion.intensity.Override(newIntensity);
        }
	}
}
