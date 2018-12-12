using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace CoverShooter.Tools
{
    [System.Serializable]
    public class AIListener  {
        #region Public fields

        /// <summary>
        /// Fraction of an alert distance at which the AI hears it. 0 means no hearing, 1 means perfect.
        /// </summary>
        [Tooltip("Fraction of an alert distance at which the AI hears it. 0 means no hearing, 1 means perfect.")]
        public float Hearing = 1.0f;

        #endregion

    }
}
