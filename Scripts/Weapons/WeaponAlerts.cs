using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverShooter.Tools
{
    [System.Serializable]
    public class WeaponAlerts
    {
        #region Public fields
        /// <summary>
        /// Distance at which fire can be heard. Alert is not generated if value is zero or negative.
        /// </summary>
        [Tooltip("Distance at which fire can be heard. Alert is not generated if value is zero or negative.")]
        public float Fire = 20;

        /// <summary>
        /// Distance at which a failed fire attempt can be heard.
        /// </summary>
        [Tooltip("Distance at which a failed fire attempt can be heard.")]
        public float EmptyFire = 20;

        /// <summary>
        /// Distance at which reloads can be heard. Alert is not generated if value is zero or negative.
        /// </summary>
        [Tooltip("Distance at which reloads can be heard. Alert is not generated if value is zero or negative.")]
        public float Reload = 10;
        #endregion

    }
}
