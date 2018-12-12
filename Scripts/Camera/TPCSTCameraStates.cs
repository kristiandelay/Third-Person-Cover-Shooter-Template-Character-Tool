using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverShooter.Tools
{
    [System.Serializable]
    public class TPCSTCameraStates  {

        #region Public fields
        /// <summary>
        /// Is the camera adjusting itself so there are no colliders between it and the target.
        /// </summary>
        [Tooltip("Is the camera adjusting itself so there are no colliders between it and the target.")]
        public bool AvoidObstacles = true;

        /// <summary>
        /// Should the AvoidObstacles be ignored when the character is zooming in.
        /// </summary>
        [Tooltip("Should the AvoidObstacles be ignored when the character is zooming in.")]
        public bool IgnoreObstaclesWhenZooming = true;

        /// <summary>
        /// Reduction in field of view when zooming in without a scope.
        /// </summary>
        [Tooltip("Reduction in field of view when zooming in without a scope.")]
        public float Zoom = 10;

        /// <summary>
        /// Does camera shake affect aiming.
        /// </summary>
        [Tooltip("Does camera shake affect aiming.")]
        public bool ShakingAffectsAim = true;

        /// <summary>
        /// Should the camera ask for smoother rotation animations when zooming in.
        /// </summary>
        [Tooltip("Should the camera ask for smoother rotation animations when zooming in.")]
        public bool AskForSmoothRotations = true;

        /// <summary>
        /// Camera settings for all gameplay situations.
        /// </summary>
        [Tooltip("Camera settings for all gameplay situations.")]
        public CameraStates States = CameraStates.GetDefault();

        #endregion

    }
}
