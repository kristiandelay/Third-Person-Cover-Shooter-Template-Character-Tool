using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace CoverShooter.Tools
{
    [System.Serializable]
    public class AIForget  {

        #region Public fields

        /// <summary>
        /// Time in seconds it takes for the AI to forget about the enemy. Time is measured from the moment the last information about the enemy was received.
        /// </summary>
        [Tooltip("Time in seconds it takes for the AI to forget about the enemy. Time is measured from the moment the last information about the enemy was received.")]
        public float Duration = 30;

        #endregion
    }
}
