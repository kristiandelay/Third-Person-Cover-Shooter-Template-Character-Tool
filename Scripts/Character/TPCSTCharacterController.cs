using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CoverShooter.Tools
{
    [System.Serializable]
    public class TPCSTCharacterController  {

        #region Public fields

        /// <summary>
        /// Determines if the character takes cover automatically instead of waiting for player input.
        /// </summary>
        [Tooltip("Determines if the character takes cover automatically instead of waiting for player input.")]
        public bool AutoTakeCover = true;

        /// <summary>
        /// Time in seconds after a potential cover has been detected when the character automatically enters it.
        /// </summary>
        [Tooltip("Time in seconds after a potential cover has been detected when the character automatically enters it.")]
        public float CoverEnterDelay = 0.1f;

        /// <summary>
        /// Is the character always aiming in camera direction when not in cover.
        /// </summary>
        [Tooltip("Is the character always aiming in camera direction when not in cover.")]
        public bool AlwaysAim = false;

        /// <summary>
        /// Should the character aim when walking, if turned off it will only aim when zooming in.
        /// </summary>
        [Tooltip("Should the character aim when walking, if turned off it will only aim when zooming in.")]
        public bool AimWhenWalking = false;

        /// <summary>
        /// Should the character start crouching near closing in to a low cover.
        /// </summary>
        [Tooltip("Should the character start crouching near closing in to a low cover.")]
        public bool CrouchNearCovers = true;

        /// <summary>
        /// Will the character turn immediatelly when aiming.
        /// </summary>
        [Tooltip("Will the character turn immediatelly when aiming.")]
        public bool ImmediateTurns = true;

        /// <summary>
        /// Radius at which enemy actors are detected in melee mode.
        /// </summary>
        [Tooltip("Radius at which enemy actors are detected in melee mode.")]
        public float MeleeRadius = 4;

        /// <summary>
        /// Distance to maintain against melee targets.
        /// </summary>
        [Tooltip("Distance to maintain against melee targets.")]
        public float MinMeleeDistance = 1.5f;

        /// <summary>
        /// How long to continue aiming after no longer needed.
        /// </summary>
        [Tooltip("How long to continue aiming after no longer needed.")]
        public float AimSustain = 0.4f;

        /// <summary>
        /// Time in seconds to keep the gun down when starting to move.
        /// </summary>
        [Tooltip("Time in seconds to keep the gun down when starting to move.")]
        public float NoAimSustain = 0.14f;

        /// <summary>
        /// Cancel get hit animations upon player input.
        /// </summary>
        [Tooltip("Cancel get hit animations upon player input.")]
        public bool CancelHurt = true;

        /// <summary>
        /// Degrees to add when aiming a grenade vertically.
        /// </summary>
        [Tooltip("Degrees to add when aiming a grenade vertically.")]
        public float ThrowAngleOffset = 30;

        /// <summary>
        /// How high can the player throw the grenade.
        /// </summary>
        [Tooltip("How high can the player throw the grenade.")]
        public float MaxThrowAngle = 45;

        /// <summary>
        /// Time in seconds to wait after landing before AlwaysAim activates again.
        /// </summary>
        [Tooltip("Time in seconds to wait after landing before AlwaysAim activates again.")]
        public float PostLandAimDelay = 0.4f;

        /// <summary>
        /// Time in seconds to wait before lifting an arm when running with a pistol.
        /// </summary>
        [Tooltip("Time in seconds to wait before lifting an arm when running with a pistol.")]
        public float ArmLiftDelay = 1.5f;

        /// <summary>
        /// Prefab to instantiate to display grenade explosion preview.
        /// </summary>
        [Tooltip("Prefab to instantiate to display grenade explosion preview.")]
        public GameObject ExplosionPreview;

        /// <summary>
        /// Prefab to instantiate to display grenade path preview.
        /// </summary>
        [Tooltip("Prefab to instantiate to display grenade path preview.")]
        public GameObject PathPreview;

        /// <summary>
        /// Scope object and component that's enabled and maintained when using scope.
        /// </summary>
        [Tooltip("Scope object and component that's enabled and maintained when using scope.")]
        public Image Scope;

        #endregion
    }
}
