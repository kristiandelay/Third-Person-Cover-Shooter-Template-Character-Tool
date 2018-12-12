using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverShooter.Tools
{
    [System.Serializable]
    public class TPCSTCharacterSounds {
        #region Public fields
        /// <summary>
        /// Possible sounds to play on each footstep.
        /// </summary>
        [Tooltip("Possible sounds to play on each footstep.")]
        public AudioClip[] Footstep;

        /// <summary>
        /// Possible sounds to play when the character dies.
        /// </summary>
        [Tooltip("Possible sounds to play when the character dies.")]
        public AudioClip[] Death;

        /// <summary>
        /// Possible sounds to play at the beginning of a jump.
        /// </summary>
        [Tooltip("Possible sounds to play at the beginning of a jump.")]
        public AudioClip[] Jump;

        /// <summary>
        /// Possible sounds to play when the character lands.
        /// </summary>
        [Tooltip("Possible sounds to play when the character lands.")]
        public AudioClip[] Land;

        /// <summary>
        /// Possible sounds to play when the character blocks a melee attack.
        /// </summary>
        [Tooltip("Possible sounds to play when the character blocks a melee attack.")]
        public AudioClip[] Block;

        /// <summary>
        /// Possible sounds to play when the character is hurt.
        /// </summary>
        [Tooltip("Possible sounds to play when the character is hurt.")]
        public AudioClip[] Hurt;

        /// <summary>
        /// Possible sounds to play when the character is hit.
        /// </summary>
        [Tooltip("Possible sounds to play when the character is hit.")]
        public AudioClip[] Hit;

        /// <summary>
        /// Possible sounds to play when the character is dealt a lot of damage by a hit.
        /// </summary>
        [Tooltip("Possible sounds to play when the character is dealt a lot of damage by a hit.")]
        public AudioClip[] BigHit;

        /// <summary>
        /// Damage that has to be dealt to play big hit sound.
        /// </summary>
        [Tooltip("Damage that has to be dealt to play big hit sound.")]
        public float BigDamageThreshold = 50;
        #endregion

    }
}
