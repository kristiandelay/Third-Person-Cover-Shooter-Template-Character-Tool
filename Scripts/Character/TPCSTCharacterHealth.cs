using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverShooter.Tools
{
    [System.Serializable]
    public class TPCSTCharacterHealth  {
        #region Public fields

        /// <summary>
        /// Current health of the character.
        /// </summary>
        [Tooltip("Current health of the character.")]
        public float Health = 100f;

        /// <summary>
        /// Max health to regenerate to.
        /// </summary>
        [Tooltip("Max health to regenerate to.")]
        public float MaxHealth = 100f;

        /// <summary>
        /// Amount of health regenerated per second.
        /// </summary>
        [Tooltip("Amount of health regenerated per second.")]
        public float Regeneration = 0f;

        /// <summary>
        /// How much the incoming damage is multiplied by.
        /// </summary>
        [Tooltip("How much the incoming damage is multiplied by.")]
        public float DamageMultiplier = 1;

        /// <summary>
        /// Does the component reduce damage on hits. Usually used for debugging purposes to make immortal characters.
        /// </summary>
        [Tooltip("Does the component reduce damage on hits. Usually used for debugging purposes to make immortal characters.")]
        public bool IsTakingDamage = true;

        /// <summary>
        /// Are bullet hits done to the main collider registered as damage.
        /// </summary>
        [Tooltip("Are bullet hits done to the main collider registered as damage.")]
        public bool IsRegisteringHits = true;

        #endregion
    }
}
