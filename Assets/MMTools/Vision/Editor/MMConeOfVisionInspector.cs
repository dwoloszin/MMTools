using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using System.Collections.Generic;
using UnityEditor;

namespace MoreMountains.Tools
{
    [CustomEditor(typeof(MMConeOfVision))]
    public class MMConeOfVisionInspector : Editor
    {
        protected virtual void OnSceneGUI()
        {
            // draws a circle around the character to represent the cone of vision's radius
            MMConeOfVision coneOfVision = (MMConeOfVision)target;

            Handles.color = Color.yellow;
            Handles.DrawWireArc(coneOfVision.transform.position, Vector3.up, Vector3.forward, 360f, coneOfVision.VisionRadius);

            // draws two lines to mark the vision angle
            Vector3 visionAngleLeft = MMMaths.DirectionFromAngle(-coneOfVision.VisionAngle / 2f, coneOfVision.EulerAngles.y);
            Vector3 visionAngleRight = MMMaths.DirectionFromAngle(coneOfVision.VisionAngle / 2f, coneOfVision.EulerAngles.y);

            Handles.DrawLine(coneOfVision.transform.position, coneOfVision.transform.position + visionAngleLeft * coneOfVision.VisionRadius);
            Handles.DrawLine(coneOfVision.transform.position, coneOfVision.transform.position + visionAngleRight * coneOfVision.VisionRadius);

            foreach (Transform visibleTarget in coneOfVision.VisibleTargets)
            {
                Handles.color = Colors.Orange;
                Handles.DrawLine(coneOfVision.transform.position, visibleTarget.position);
            }
        }
    }
}
