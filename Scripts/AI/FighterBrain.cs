using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace CoverShooter.Tools
{
    [System.Serializable]
    public class FighterBrain
    {
        #region Public fields

        /// <summary>
        /// Enemy distance to trigger slow retreat.
        /// </summary>
        [Tooltip("Enemy distance to trigger slow retreat.")]
        public float AvoidDistance = 4;

        /// <summary>
        /// Enemy distance to trigger slow retreat.
        /// </summary>
        [Tooltip("AI will avoid standing to allies closer than this distance.")]
        public float AllySpacing = 1.2f;

        /// <summary>
        /// Duration in seconds to stand fighting before changing state.
        /// </summary>
        [Tooltip("Duration in seconds to stand fighting before changing state.")]
        public float StandDuration = 2;

        /// <summary>
        /// Duration in seconds to fight circling the enemy before changing state.
        /// </summary>
        [Tooltip("Duration in seconds to fight circling the enemy before changing state.")]
        public float CircleDuration = 2;

        /// <summary>
        /// Time in seconds for the AI to wait before switching to a better cover.
        /// </summary>
        [Tooltip("Time in seconds for the AI to wait before switching to a better cover.")]
        public float CoverSwitchWait = 10;

        /// <summary>
        /// Distance at which the AI guesses the position on hearing instead of knowing it precisely.
        /// </summary>
        [Tooltip("Distance at which the AI guesses the position on hearing instead of knowing it precisely.")]
        public float GuessDistance = 30;

        /// <summary>
        /// Chance the AI will take cover immediately after learning of existance of an enemy.
        /// </summary>
        [Tooltip("Chance the AI will take cover immediately after learning of existance of an enemy.")]
        [Range(0, 1)]
        public float TakeCoverImmediatelyChance = 0;

        /// <summary>
        /// AI won't go to cover if it is closer to the enemy than this value. Only used when the enemy has been known for awhile.
        /// </summary>
        [Tooltip("AI won't go to cover if it is closer to the enemy than this value. Only used when the enemy has been known for awhile.")]
        public float DistanceToGoToCoverFromStandOrCircle = 6;

        /// <summary>
        /// Should the AI attack threats immedietaly on seeing them.
        /// </summary>
        [Tooltip("Should the AI attack threats immedietaly on seeing them.")]
        public bool ImmediateThreatReaction = true;

        /// <summary>
        /// Should the AI switch to attacking enemies that deal damage to the AI.
        /// </summary>
        [Tooltip("Should the AI switch to attacking enemies that deal damage to the AI.")]
        public bool AttackAggressors = true;

        /// <summary>
        /// Settings for AI startup.
        /// </summary>
        [Tooltip("Settings for AI startup.")]
        public AIStartSettings Start = AIStartSettings.Default();

        /// <summary>
        /// Speed of the motor during various AI states.
        /// </summary>
        [Tooltip("Speed of the motor during various AI states.")]
        public FighterSpeedSettings Speed = FighterSpeedSettings.Default();

        /// <summary>
        /// How accurately the AI guesses the position of an enemy.
        /// </summary>
        [Tooltip("How accurately the AI guesses the position of an enemy.")]
        public AIApproximationSettings Approximation = new AIApproximationSettings(0, 10, 5, 30);

        /// <summary>
        /// Settings for AI retreats.
        /// </summary>
        [Tooltip("Settings for AI retreats.")]
        public FighterRetreatSettings Retreat = FighterRetreatSettings.Default();

        /// <summary>
        /// Settings for how long the AI waits before investigating.
        /// </summary>
        [Tooltip("Settings for how long the AI waits before investigating.")]
        public FighterInvestigationWaitSettings Investigation = FighterInvestigationWaitSettings.Default();

        /// <summary>
        /// Settings for how the fighter avoids other grenades.
        /// </summary>
        [Tooltip("Settings for how the fighter avoids other grenades.")]
        public FighterGrenadeAvoidSettings GrenadeAvoidance = FighterGrenadeAvoidSettings.Default();

        /// <summary>
        /// Settings for AI grenades.
        /// </summary>
        [Tooltip("Settings for AI fighting and aiming.")]
        public AIGrenadeSettings Grenades = AIGrenadeSettings.Default();

        /// <summary>
        /// Should a debug line be drawn towards the current threat.
        /// </summary>
        [Tooltip("Should a debug line be drawn towards the current threat.")]
        public bool DebugThreat = false;

        #endregion

    }
}
