using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CoverShooter.Tools
{
    [CreateAssetMenu(menuName = "CoverShooter/Character", order = 0)]
    public class TPCSTScriptableCharacter : ScriptableObject
    {
        public TPCSTAnimatorController animatorController;
        public TPCSTRigidbody rigidbody;
        public TPCSTCapsuleCollider capsuleCollider;
        public TPCSTActor actor;
        public TPCSTCharacterMotor characterMotor;
        public TPCSTCharacterController characterController;
        public TPCSTInputController inputController;
        public TPCSTCharacterSounds characterSounds;
        public TPCSTCharacterEffects characterEffects;
        public TPCSTCharacterAlerts characterAlerts;
        public TPCSTCharacterHealth characterHealth;
        public float platformThreshold = 0.2f;
        public float resetOnDeathDelay = 3;
        public TPCSTCameraStates cameraStates;
        public TPCSTCrosshair crosshair;



    }

}