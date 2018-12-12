using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverShooter.Tools
{
    [System.Serializable]
    public class TPCSTCharacterEffects  {

        #region Public fields
        /// <summary>
        /// Effect prefab to instantiate on each character step.
        /// </summary>
        [Tooltip("Effect prefab to instantiate on each character step.")]
        public GameObject Step;

        /// <summary>
        /// Effect prefab to instantiate when the character lands on ground.
        /// </summary>
        [Tooltip("Effect prefab to instantiate when the character lands on ground.")]
        public GameObject Land;

        /// <summary>
        /// Effect prefab to instantiate when the character dies.
        /// </summary>
        [Tooltip("Effect prefab to instantiate when the character dies.")]
        public GameObject Death;

        /// <summary>
        /// Effect prefab to instantiate when the character resurrects.
        /// </summary>
        [Tooltip("Effect prefab to instantiate when the character resurrects.")]
        public GameObject Resurrection;

        /// <summary>
        /// Effect prefab to instantiate at the beginning of a jump.
        /// </summary>
        [Tooltip("Effect prefab to instantiate at the beginning of a jump.")]
        public GameObject Jump;

        /// <summary>
        /// Effect prefab to instantiate when the character is hurt.
        /// </summary>
        [Tooltip("Effect prefab to instantiate when the character is hurt.")]
        public GameObject Hurt;

        /// <summary>
        /// Effect prefab to instantiate when the character blocks a melee attack.
        /// </summary>
        [Tooltip("Effect prefab to instantiate when the character blocks a melee attack.")]
        public GameObject Block;

        /// <summary>
        /// Effect prefab to instantiate when the character is hit.
        /// </summary>
        [Tooltip("Effect prefab to instantiate when the character is hit.")]
        public GameObject Hit;

        /// <summary>
        /// Effect prefab to instantiate when the character is dealt a lot of damage by a hit.
        /// </summary>
        [Tooltip("Effect prefab to instantiate when the character is dealt a lot of damage by a hit.")]
        public GameObject BigHit;

        /// <summary>
        /// Damage that has to be dealt to play big hit effect.
        /// </summary>
        [Tooltip("Damage that has to be dealt to play big hit effect.")]
        public float BigDamageThreshold = 50;
        #endregion

    }
}
