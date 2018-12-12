using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace CoverShooter.Tools
{
    [System.Serializable]
    public class AICommunication  {
        #region Public fields

        /// <summary>
        /// Distance in any direction for AI to communicate between each other.
        /// </summary>
        [Tooltip("Distance in any direction for AI to communicate between each other.")]
        public float Distance = 12;

        /// <summary>
        /// Time in seconds between each contact update.
        /// </summary>
        [Tooltip("Time in seconds between each contact update.")]
        public float UpdateDelay = 0.2f;

        /// <summary>
        /// Should lines between friends be drawn in the editor.
        /// </summary>
        [Tooltip("Should lines between friends be drawn in the editor.")]
        public bool DebugFriends = false;
        #endregion
    }
}
