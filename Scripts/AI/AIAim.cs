using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace CoverShooter.Tools
{
    [System.Serializable]
    public class AIAim  {
        #region Public fields

        /// <summary>
        /// Speed at which the AI turns.
        /// </summary>
        [Tooltip("Speed at which the AI turns.")]
        public float Speed = 6;

        /// <summary>
        /// Speed at which the AI turns when in slow mode.
        /// </summary>
        [Tooltip("Speed at which the AI turns when in slow mode.")]
        public float SlowSpeed = 2;

        /// <summary>
        /// Duration of sweeping in a single direction. Afterwards a new direction is picked.
        /// </summary>
        [Tooltip("Duration of sweeping in a single direction. Afterwards a new direction is picked.")]
        public float MinScanDuration = 3.5f;

        /// <summary>
        /// Duration of sweeping in a single direction. Afterwards a new direction is picked.
        /// </summary>
        [Tooltip("Duration of sweeping in a single direction. Afterwards a new direction is picked.")]
        public float MaxScanDuration = 5;

        /// <summary>
        /// Minimal unobstructed distance in a direction for it to be scanned.
        /// </summary>
        [Tooltip("Minimal unobstructed distance in a direction for it to be scanned.")]
        public float MinScanDistance = 6;

        /// <summary>
        /// Duration of a single sweep.
        /// </summary>
        [Tooltip("Duration of a single sweep.")]
        public float MinSweepDuration = 4;

        /// <summary>
        /// Duration of a single sweep.
        /// </summary>
        [Tooltip("Duration of a single sweep.")]
        public float MaxSweepDuration = 6;

        /// <summary>
        /// How wide is a single sweep in degrees.
        /// </summary>
        [Tooltip("How wide is a single sweep in degrees.")]
        public float SweepFOV = 30;

        /// <summary>
        /// Maximum degrees of error the AI can make when firing.
        /// </summary>
        [Tooltip("Maximum degrees of error the AI can make when firing.")]
        public float AccuracyError = 2;

        /// <summary>
        /// Position of the enemy the AI is aiming at.
        /// </summary>
        [Tooltip("Position of the enemy the AI is aiming at.")]
        public AITargetSettings Target = new AITargetSettings(0.5f, 0.8f);

        /// <summary>
        /// Should a debug rays be displayed.
        /// </summary>
        [Tooltip("Should a debug rays be displayed.")]
        public bool DebugAim = false;

        #endregion

    }
}
