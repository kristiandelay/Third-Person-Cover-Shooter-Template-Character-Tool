using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace CoverShooter.Tools
{
    [System.Serializable]
    public class AIMovement
    {
        #region Public fields

        /// <summary>
        /// The AI will roll if it is ordered to sprint from a position closer than this property.
        /// </summary>
        [Tooltip("The AI will roll if it is ordered to sprint from a position closer than this property.")]
        public float RollTriggerDistance = 2;

        /// <summary>
        /// Seconds to wait before changing the direction of circling.
        /// </summary>
        [Tooltip("Seconds to wait before changing the direction of circling.")]
        public float CircleDelay = 2;

        /// <summary>
        /// The AI will move out of the way of other actors that are closer than the threshold.
        /// </summary>
        [Tooltip("The AI will move out of the way of other actors that are closer than the threshold.")]
        public float ObstructionRadius = 1.5f;

        /// <summary>
        /// Should a line to destination be drawn in the editor.
        /// </summary>
        [Tooltip("Should a line to destination be drawn in the editor.")]
        public bool DebugDestination = false;

        /// <summary>
        /// Should a path to destination be drawn in the editor.
        /// </summary>
        [Tooltip("Should a path to destination be drawn in the editor.")]
        public bool DebugPath = false;

        #endregion
    }
}
