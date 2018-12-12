using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace CoverShooter.Tools
{
    [System.Serializable]
    public class AIFire {
        #region Public fields

        /// <summary>
        /// How should the character inventory (if there is one) be used.
        /// </summary>
        [Tooltip("How should the character inventory (if there is one) be used.")]
        public InventoryUsage InventoryUsage = InventoryUsage.autoFind;

        /// <summary>
        /// Weapon index inside the inventory to use when usage is set to 'index'.
        /// </summary>
        [Tooltip("Weapon index inside the inventory to use when usage is set to 'index'.")]
        public int InventoryIndex = 0;

        /// <summary>
        /// Weapon type to look for, if not present any other weapon will be picked. Used only when AutoFindIndex is enabled.
        /// </summary>
        [Tooltip("Weapon type to look for, if not present any other weapon will be picked. Used only when AutoFindIndex is enabled.")]
        public WeaponType AutoFindType = WeaponType.Pistol;

        /// <summary>
        /// Should the AI always be aiming.
        /// </summary>
        [Tooltip("Should the AI always be aiming.")]
        public bool AlwaysAim;

        /// <summary>
        /// Settings for bursts of fire when in a cover.
        /// </summary>
        [Tooltip("Settings for bursts of fire when in a cover.")]
        public Bursts Bursts = Bursts.Default();

        /// <summary>
        /// Settings for bursts of fire when in a cover.
        /// </summary>
        [Tooltip("Settings for bursts of fire when in a cover.")]
        public CoverBursts CoverBursts = CoverBursts.Default();

        #endregion
    }
}
