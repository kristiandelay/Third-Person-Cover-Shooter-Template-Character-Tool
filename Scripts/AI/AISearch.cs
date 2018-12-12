using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace CoverShooter.Tools
{
    [System.Serializable]
    public class AISearch  {
        #region Public fields

        /// <summary>
        /// At which height the AI confirms the point as investigated.
        /// </summary>
        [Tooltip("At which height the AI confirms the point as investigated.")]
        public float VerifyHeight = 0.7f;

        /// <summary>
        /// Field of sight to register the search position.
        /// </summary>
        [Tooltip("Field of sight to register the search position.")]
        public float FieldOfView = 90;

        /// <summary>
        /// Distance at which AI turns from running to walking to safely investigate the position.
        /// </summary>
        [Tooltip("Distance at which AI turns from running to walking to safely investigate the position.")]
        public float WalkDistance = 8;

        /// <summary>
        /// Should a line to the intended search point be drawn in the editor.
        /// </summary>
        [Tooltip("Should a line to the intended search point be drawn in the editor.")]
        public bool DebugTarget = false;

        /// <summary>
        /// Should information about search points be displayed.
        /// </summary>
        [Tooltip("Should information about search points be displayed.")]
        public bool DebugPoints = false;

        #endregion
	}
}
