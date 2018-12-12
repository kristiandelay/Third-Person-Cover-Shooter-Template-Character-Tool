using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverShooter.Tools
{
    [System.Serializable]
    public class TPCSTCharacterMotor  {

        #region Public fields

        /// <summary>
        /// Controls wheter the character is in a state of death. Dead characters have no collisions and ignore any input.
        /// </summary>
        [Tooltip("Controls wheter the character is in a state of death.")]
        public bool IsAlive = true;

        /// <summary>
        /// Speed multiplier for the movement speed. Adjusts animations.
        /// </summary>
        [Tooltip("Speed multiplier for the movement speed. Adjusts animations.")]
        public float Speed = 1.0f;

        /// <summary>
        /// Multiplies movement speed without adjusting animations.
        /// </summary>
        [Tooltip("Multiplies movement speed without adjusting animations.")]
        public float MoveMultiplier = 1.0f;

        /// <summary>
        /// Toggles character's ability to run. Used by the CharacterStamina.
        /// </summary>
        [Tooltip("Toggles character's ability to run. Used by the CharacterStamina.")]
        public bool CanRun = true;

        /// <summary>
        /// Toggles character's ability to run. Used by the CharacterStamina.
        /// </summary>
        [Tooltip("Toggles character's ability to run. Used by the CharacterStamina.")]
        public bool CanSprint = true;

        /// <summary>
        /// Distance below feet to check for ground.
        /// </summary>
        [Tooltip("Distance below feet to check for ground.")]
        [Range(0, 1)]
        public float GroundThreshold = 0.3f;

        /// <summary>
        /// Minimal height to trigger state of falling. It’s ignored when jumping over gaps.
        /// </summary>
        [Tooltip("Minimal height to trigger state of falling. It’s ignored when jumping over gaps.")]
        [Range(0, 10)]
        public float FallThreshold = 2.0f;

        /// <summary>
        /// Movement to obstacles closer than this is ignored. 
        /// It is mainly used to prevent character running into walls.
        /// </summary>
        [Tooltip("Movement to obstacles closer than this is ignored.")]
        [Range(0, 2)]
        public float ObstacleDistance = 0.05f;

        /// <summary>
        /// Gravity force applied to this character.
        /// </summary>
        [Tooltip("Gravity force applied to this character.")]
        public float Gravity = 10;

        /// <summary>
        /// Degrees recovered per second after a recoil.
        /// </summary>
        [Tooltip("Degrees recovered per second after a recoil.")]
        public float RecoilRecovery = 17;

        /// <summary>
        /// Sets the origin of bullet raycasts, either a camera or an end of a gun.
        /// </summary>
        [Tooltip("Sets the origin of bullet raycasts, either a camera or an end of a gun.")]
        public bool IsFiringFromCamera = true;

        /// <summary>
        /// Gun accuracy increase when zooming in. Multiplier gun error.
        /// </summary>
        [Tooltip("Gun accuracy increase when zooming in. Multiplier gun error.")]
        public float ZoomErrorMultiplier = 0.75f;

        /// <summary>
        /// Capsule height when crouching.
        /// </summary>
        [Tooltip("Capsule height when crouching.")]
        public float CrouchHeight = 1.5f;

        /// <summary>
        /// How long it takes for the animator to go from standing to full speed when issued a move command.
        /// </summary>
        [Tooltip("How long it takes for the animator to go from standing to full speed when issued a move command.")]
        public float AccelerationDamp = 1;

        /// <summary>
        /// How much the animator keeps moving after the character stops getting move commands.
        /// </summary>
        [Tooltip("How much the animator keeps moving after the character stops getting move commands.")]
        public float DeccelerationDamp = 3;

        /// <summary>
        /// Slope angle at which the character begins to scale the velocity down when moving up a cliff.
        /// </summary>
        public const float MinSlope = 26f;

        /// <summary>
        /// Slope angle at which the character's velocity reaches zero when moving up a cliff.
        /// </summary>
        [Tooltip("Slope angle at which the character's velocity reaches zero when moving up a cliff.")]
        [Range(MinSlope, 90)]
        public float MaxSlope = 60f;

        /// <summary>
        /// Damage multiplier for weapons.
        /// </summary>
        [Tooltip("Damage multiplier for weapons.")]
        public float DamageMultiplier = 1;

        /// <summary>
        /// Should the character hold the weapon in their hands. Change is not immediate.
        /// </summary>
        [Tooltip("Should the character hold the weapon in their hands. Change is not immediate.")]
        public bool IsEquipped = true;

        /// <summary>
        /// Weapon description of the weapon the character is to equip.
        /// </summary>
        [Tooltip("Weapon description of the weapon the character is to equip.")]
        public WeaponDescription Weapon = WeaponDescription.Default();

        /// <summary>
        /// Grenade settings.
        /// </summary>
        public GrenadeSettings Grenade = GrenadeSettings.Default();

        /// <summary>
        /// IK settings for the character.
        /// </summary>
        [Tooltip("IK settings for the character.")]
        public IKSettings IK = IKSettings.Default();

        /// <summary>
        /// Settings for cover behaviour.
        /// </summary>
        [Tooltip("Settings for cover behaviour.")]
        public CoverSettings CoverSettings = CoverSettings.Default();

        /// <summary>
        /// Settings for climbing.
        /// </summary>
        [Tooltip("Settings for climbing.")]
        public ClimbSettings ClimbSettings = ClimbSettings.Default();

        /// <summary>
        /// Settings for climbing.
        /// </summary>
        [Tooltip("Settings for climbing.")]
        public VaultSettings VaultSettings = VaultSettings.Default();

        /// <summary>
        /// Settings for jumping.
        /// </summary>
        [Tooltip("Settings for jumping.")]
        public JumpSettings JumpSettings = JumpSettings.Default();

        /// <summary>
        /// Settings for rolling.
        /// </summary>
        [Tooltip("Settings for rolling.")]
        public RollSettings RollSettings = RollSettings.Default();

        /// <summary>
        /// Settings for aiming.
        /// </summary>
        [Tooltip("Settings for aiming.")]
        public AimSettings AimSettings = AimSettings.Default();

        /// <summary>
        /// Settings for turning.
        /// </summary>
        [Tooltip("Settings for turning.")]
        public TurnSettings TurnSettings = TurnSettings.Default();

        /// <summary>
        /// Settings for camera pivot positions based on shoulders.
        /// </summary>
        [Tooltip("Settings for camera pivot positions based on shoulders.")]
        public ShoulderSettings ShoulderSettings = ShoulderSettings.Default();

        /// <summary>
        /// Settings for hit response IK.
        /// </summary>
        [Tooltip("Settings for hit response IK.")]
        public HitResponseSettings HitResponseSettings = HitResponseSettings.Default();

        #endregion
    }
}
