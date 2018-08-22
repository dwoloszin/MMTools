using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using MoreMountains.Tools;

namespace MoreMountains.ToolsForThirdParty
{
    public class MMAutoFocus : MonoBehaviour
    {
        // Array of targets
        public Transform[] focusTargets;

        // Current target
        public float focusTargetID;

        // Cache profile
        PostProcessVolume _volume;
        PostProcessProfile _profile;
        DepthOfField _depthOfField;

        // Adjustable aperture - used in animations within Timeline
        [Range(0.1f, 20f)] public float aperture;


        void Start()
        {
            _volume = GetComponent<PostProcessVolume>();
            _profile = _volume.profile;

            _profile.TryGetSettings<DepthOfField>(out _depthOfField);


        }

        void Update()
        {
            // Get distance from camera and target
            float dist = Vector3.Distance(transform.position, focusTargets[Mathf.FloorToInt(focusTargetID)].position);

            // Set variables
            _depthOfField.focusDistance.Override(dist);
            _depthOfField.aperture.Override(aperture);
        }
    }
}
