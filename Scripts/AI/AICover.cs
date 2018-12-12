using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace CoverShooter.Tools
{
    [System.Serializable]
    public class AICover
    {

        #region Public fields

        /// <summary>
        /// Maximum angle of a low cover relative to the enemy.
        /// </summary>
        [Tooltip("Maximum angle of a low cover relative to the enemy.")]
        public float MaxLowCoverThreatAngle = 60;

        /// <summary>
        /// Maximum angle of a tall cover relative to the enemy.
        /// </summary>
        [Tooltip("Maximum angle of a tall cover relative to the enemy.")]
        public float MaxTallCoverThreatAngle = 40;

        /// <summary>
        /// Maximum angle of a cover relative to the defense position.
        /// </summary>
        [Tooltip("Maximum angle of a cover relative to the defense position.")]
        public float MaxDefenseAngle = 85;

        /// <summary>
        /// If an enemy is on the same cover side as the AI, the cover will be taken if only the distance is greater than this value.
        /// </summary>
        [Tooltip("If an enemy is on the same cover side as the AI, the cover will be taken if only the distance is greater than this value.")]
        public float MinDefenselessDistance = 30;

        /// <summary>
        /// Maximum distance of a cover for AI to take.
        /// </summary>
        [Tooltip("Maximum distance of a cover for AI to take.")]
        public float MaxCoverDistance = 30;

        /// <summary>
        /// AI won't switch to cover positions closer than this distance.
        /// </summary>
        [Tooltip("AI won't switch to cover positions closer than this distance.")]
        public float MinSwitchDistance = 6;

        /// <summary>
        /// AI avoids taking covers that are closer to the enemy.
        /// </summary>
        [Tooltip("AI avoids taking covers that are closer to the enemy.")]
        public float AvoidDistance = 6;

        #endregion

    }
}
