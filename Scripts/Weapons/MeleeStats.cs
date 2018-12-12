using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CoverShooter.Tools
{
    [System.Serializable]
    public class MeleeStats 
    {
        #region Public fields

        /// <summary>
        /// Animations and related assets to be used with this weapon.
        /// </summary>
        [Tooltip("Animations and related assets to be used with this weapon.")]
        public WeaponType Type = WeaponType.Pistol;

        /// <summary>
        /// Damage done by a melee attack.
        /// </summary>
        [Tooltip("Damage done by a melee attack.")]
        public float Damage = 20;

        /// <summary>
        /// Time in seconds for to wait for another melee hit.
        /// </summary>
        [Tooltip("Time in seconds for to wait for another melee hit.")]
        public float Cooldown = 0.5f;

        /// <summary>
        /// Time in seconds between hits that the character will respond to with hurt animations.
        /// </summary>
        [Tooltip("Time in seconds between hits that the character will respond to with hurt animations.")]
        public float DamageResponseWaitTime = 0;

        #endregion

    }
}
