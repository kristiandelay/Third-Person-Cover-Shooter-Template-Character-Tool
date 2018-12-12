using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace CoverShooter.Tools
{
    [System.Serializable]
    public class AIInvestigation  {
        #region Public fields

        /// <summary>
        /// Distance to the investigation position for it to be marked as investigated.
        /// </summary>
        [Tooltip("Distance to the investigation position for it to be marked as investigated.")]
        public float VerifyDistance = 10;

        /// <summary>
        /// At which height the AI confirms the point as investigated.
        /// </summary>
        [Tooltip("At which height the AI confirms the point as investigated.")]
        public float VerifyHeight = 0.3f;

        /// <summary>
        /// Radius of an investigation point when it's close to a cover. AI tries to verify all of it is clear of enemies when investigating. Aiming is done at the central point so keep the radius small.
        /// </summary>
        [Tooltip("Radius of an investigation point when it's close to a cover. AI tries to verify all of it is clear of enemies when investigating. Aiming is done at the central point so keep the radius small.")]
        [HideInInspector]
        public float VerifyRadius = 1;

        /// <summary>
        /// Field of view when checking an investigation position.
        /// </summary>
        [Tooltip("Field of view when checking an investigation position.")]
        public float FieldOfView = 90;

        /// <summary>
        /// Distance to a cover to maintain when approaching to see behind it.
        /// </summary>
        [Tooltip("Distance to a cover to maintain when approaching to see behind it.")]
        public float CoverOffset = 2;

        /// <summary>
        /// Cover search radius around an investigation point. Closest cover will be checked when investigating.
        /// </summary>
        [Tooltip("Cover search radius around an investigation point. Closest cover will be checked when investigating.")]
        [HideInInspector]
        public float CoverSearchDistance = 3;

        #endregion

    }
}
