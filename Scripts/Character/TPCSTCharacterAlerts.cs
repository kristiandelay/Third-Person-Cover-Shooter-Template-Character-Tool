using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverShooter.Tools
{
    [System.Serializable]
    public class TPCSTCharacterAlerts  {

        #region Public fields

        /// <summary>
        /// Distance at which step can be heard. Alert is not generated if value is zero or negative.
        /// </summary>
        [Tooltip("Distance at which step can be heard. Alert is not generated if value is zero or negative.")]
        public float Step = 10;

        /// <summary>
        /// Distance at which step can be heard. Alert is not generated if value is zero or negative.
        /// </summary>
        [Tooltip("Distance at which step can be heard. Alert is not generated if value is zero or negative.")]
        public float Hurt = 10;

        /// <summary>
        /// Distance at which step can be heard. Alert is not generated if value is zero or negative.
        /// </summary>
        [Tooltip("Distance at which step can be heard. Alert is not generated if value is zero or negative.")]
        public float Death = 10;

        /// <summary>
        /// Distance at which step can be heard. Alert is not generated if value is zero or negative.
        /// </summary>
        [Tooltip("Distance at which step can be heard. Alert is not generated if value is zero or negative.")]
        public float Jump = 10;

        /// <summary>
        /// Distance at which step can be heard. Alert is not generated if value is zero or negative.
        /// </summary>
        [Tooltip("Distance at which step can be heard. Alert is not generated if value is zero or negative.")]
        public float Land = 10;

        /// <summary>
        /// Distance at which character's resurrection will be heard.Alert is not generated if value is zero or negative.
        /// </summary>
        [Tooltip("Distance at which character's resurrection will be heard.Alert is not generated if value is zero or negative.")]
        public float Resurrect = 10;

        #endregion;

    }
}
