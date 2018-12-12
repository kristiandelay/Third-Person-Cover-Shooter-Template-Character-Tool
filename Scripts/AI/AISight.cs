using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace CoverShooter.Tools
{
    [System.Serializable]
    public class AISight  {
        #region Public fields

        /// <summary>
        /// Distance for AI to see objects in the world.
        /// </summary>
        [Tooltip("Distance for AI to see objects in the world.")]
        public float Distance = 25;

        /// <summary>
        /// Distance at which the AI ignores closer obstacles preventing it from seeing something.
        /// </summary>
        [Tooltip("Distance at which the AI ignores closer obstacles preventing it from seeing something.")]
        public float ObstacleIgnoreDistance = 1;

        /// <summary>
        /// Field of sight to notice changes in the world.
        /// </summary>
        [Tooltip("Field of sight to notice changes in the world.")]
        public float FieldOfView = 160;

        /// <summary>
        /// Time in seconds between each visibility update.
        /// </summary>
        [Tooltip("Time in seconds between each visibility update.")]
        public float UpdateDelay = 0.1f;

        /// <summary>
        /// Should a debug graphic be drawn to show the field of view.
        /// </summary>
        [Tooltip("Should a debug graphic be drawn to show the field of view.")]
        public bool DebugFOV = false;

        #endregion

    }
}
