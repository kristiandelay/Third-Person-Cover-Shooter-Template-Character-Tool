using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CoverShooter.Tools
{
    [System.Serializable]
    public class WeaponSounds 
    {
        #region Public fields

        /// <summary>
        /// Sound to play when ejecting a magazine.
        /// </summary>
        [Tooltip("Sound to play when ejecting a magazine.")]
        public AudioClip[] Eject;

        /// <summary>
        /// Sound to play when a magazine is put inside the gun.
        /// </summary>
        [Tooltip("Sound to play when a magazine is put inside the gun.")]
        public AudioClip[] Rechamber;

        /// <summary>
        /// Possible sounds to play when pumping a shotgun.
        /// </summary>
        [Tooltip("Possible sounds to when pumping a shotgun.")]
        public AudioClip[] Pump;

        /// <summary>
        /// Possible sounds to play on each bullet fire.
        /// </summary>
        [Tooltip("Possible sounds to play on each bullet fire.")]
        public AudioClip[] Fire;

        /// <summary>
        /// Possible sounds to play on each fire attempt on empty magazine.
        /// </summary>
        [Tooltip("Possible sounds to play on each fire attempt on empty magazine.")]
        public AudioClip[] EmptyFire;

        #endregion
    }
}
