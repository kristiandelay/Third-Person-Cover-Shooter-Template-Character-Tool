using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverShooter.Tools
{
    [System.Serializable]
    public class TPCSTCrosshair {

        #region Public fields

        /// <summary>
        /// Settings to use when aiming a weapon of a type not covered by other properties.
        /// </summary>
        [Tooltip("Settings to use when aiming a weapon of a type not covered by other properties.")]
        public CrosshairSettings Default = CrosshairSettings.Default();

        /// <summary>
        /// Settings to use when aiming a pistol.
        /// </summary>
        [Tooltip("Settings to use when aiming a pistol.")]
        public CrosshairSettings Pistol = CrosshairSettings.Default();

        /// <summary>
        /// Settings to use when aiming a rifle.
        /// </summary>
        [Tooltip("Settings to use when aiming a rifle.")]
        public CrosshairSettings Rifle = CrosshairSettings.Default();

        /// <summary>
        /// Settings to use when aiming a shotgun.
        /// </summary>
        [Tooltip("Settings to use when aiming a shotgun.")]
        public CrosshairSettings Shotgun = CrosshairSettings.Default();

        /// <summary>
        /// Settings to use when aiming a sniper.
        /// </summary>
        [Tooltip("Settings to use when aiming a sniper.")]
        public CrosshairSettings Sniper = CrosshairSettings.Default();

        #endregion
    }
}
