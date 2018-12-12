using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace CoverShooter.Tools
{
    // TODO: Convert script values to scriptables to remove hardcoded values
    public class ThirdPersonCharacterGeneratorWindow : TPCSTEditorWindow
    {
        #region Variables

        // Character Objects
        public int selected_layer;
        public GameObject camera;
        public GameObject character;
        public Transform left_hand;
        public Transform right_hand;
        public GameObject character_face;
        public bool add_character_face = false;
        TPCSTScriptableCharacter character_defaults;

        // Camera 
        public string camera_tag = "MainCamera";

        // Animations
        Animator character_animator;
        public bool override_animation = true;

        static protected ThirdPersonCharacterGeneratorWindow window;

        string left_hand_weapon_holder_key = "LeftHandWeaponHolder";
        string right_hand_weapon_holder_key = "RightHandWeaponHolder";

        #endregion

        #region Setup Camera

        public virtual void SetupThirdPersonCameraDefaults(ThirdPersonCamera thirdPersonCamera)
        {
            if (thirdPersonCamera == false)
            {
                return;
            }
            AlertProgress("Setting Default ThirdPersonCamera values");

            TPCSTCameraStates cameraStates = character_defaults.cameraStates;
            thirdPersonCamera.tag = camera_tag;
            thirdPersonCamera.Target = character.GetComponent<CharacterMotor>();
            thirdPersonCamera.AvoidObstacles = cameraStates.AvoidObstacles;
            thirdPersonCamera.IgnoreObstaclesWhenZooming = cameraStates.IgnoreObstaclesWhenZooming;
            thirdPersonCamera.Zoom = cameraStates.Zoom ;
            thirdPersonCamera.ShakingAffectsAim = cameraStates.ShakingAffectsAim;
            thirdPersonCamera.AskForSmoothRotations = cameraStates.AskForSmoothRotations;
            thirdPersonCamera.States.Default = cameraStates.States.Default;
            thirdPersonCamera.States.Aim = cameraStates.States.Aim;
            thirdPersonCamera.States.Melee = cameraStates.States.Melee;
            thirdPersonCamera.States.Crouch = cameraStates.States.Crouch;
            thirdPersonCamera.States.LowCover = cameraStates.States.LowCover;
            thirdPersonCamera.States.LowCoverGrenade = cameraStates.States.LowCoverGrenade;
            thirdPersonCamera.States.TallCover = cameraStates.States.TallCover;
            thirdPersonCamera.States.TallCoverBack = cameraStates.States.TallCoverBack;
            thirdPersonCamera.States.Corner = cameraStates.States.Corner;
            thirdPersonCamera.States.Climb = cameraStates.States.Climb;
            thirdPersonCamera.States.Dead = cameraStates.States.Dead;
            thirdPersonCamera.States.Zoom = cameraStates.States.Zoom;
            thirdPersonCamera.States.LowCornerZoom = cameraStates.States.LowCornerZoom;
            thirdPersonCamera.States.TallCornerZoom = cameraStates.States.TallCornerZoom;



            AlertProgress("Setting Default ThirdPersonCamera values complete");
        }

        public virtual bool SetupThirdPersonCamera()
        {
            bool continute_setup = true;
            AlertProgress("Checking ThirdPersonCamera Dependencies");
            ThirdPersonCamera thirdPersonCamera = camera.GetComponent<ThirdPersonCamera>();

            if (thirdPersonCamera)
            {
                AlertProgress("ThirdPersonCamera Found");
                SetupThirdPersonCameraDefaults(thirdPersonCamera);
                continute_setup = true;
            }
            else
            {
                AlertProgress("ThirdPersonCamera not found");
                AlertProgress("Creating ThirdPersonCamera");
                thirdPersonCamera = camera.AddComponent<ThirdPersonCamera>();
                SetupThirdPersonCameraDefaults(thirdPersonCamera);
                continute_setup = true;
            }

            AlertProgress("ThirdPersonCamera Setup complete");
            return continute_setup;
        }


        public virtual void SetupCrossHairDefaults(Crosshair crossHair)
        {
            if (crossHair == false)
            {
                return;
            }
            AlertProgress("Setting Default Crosshair values");

            TPCSTCrosshair crosshair = character_defaults.crosshair;

            crossHair.Default = crosshair.Default;
            crossHair.Pistol = crosshair.Pistol;
            crossHair.Rifle = crosshair.Rifle;
            crossHair.Shotgun = crosshair.Shotgun;
            crossHair.Sniper = crosshair.Sniper;

            AlertProgress("Setting Default Crosshair values complete");
        }

        public virtual bool SetupCrossHair()
        {
            bool continute_setup = true;
            AlertProgress("Checking Crosshair Dependencies");
            Crosshair crosshair = camera.GetComponent<Crosshair>();

            if (crosshair)
            {
                AlertProgress("Crosshair Found");
                SetupCrossHairDefaults(crosshair);
                continute_setup = true;
            }
            else
            {
                AlertProgress("Crosshair not found");
                AlertProgress("Creating Crosshair");
                crosshair = camera.AddComponent<Crosshair>();
                SetupCrossHairDefaults(crosshair);
                continute_setup = true;
            }
            AlertProgress("Crosshair Setup complete");

            return continute_setup;
        }

        public virtual bool SetupMouseLock()
        {
            bool continute_setup = true;
            AlertProgress("Checking MouseLock Dependencies");
            MouseLock mouseLock = camera.GetComponent<MouseLock>();

            if (mouseLock)
            {
                AlertProgress("MouseLock Found");
                continute_setup = true;
            }
            else
            {
                AlertProgress("MouseLock not found");
                AlertProgress("Creating MouseLock");
                mouseLock = camera.AddComponent<MouseLock>();
                continute_setup = true;
            }
            AlertProgress("MouseLock Setup complete");

            return continute_setup;
        }


        public virtual bool CheckCameraDependencies()
        {
            bool continute_setup = false;
            AlertProgress("Checking Camera Dependencies");
            if (camera == null)
            {
                AlertProgress("Camera prefab unassigned shutting down character generator... I have failed you.");
                continute_setup = false;
                return continute_setup;
            }
            else
            {
                AlertProgress("Camera prefab assigned, checking for required scripts");

                continute_setup = SetupThirdPersonCamera();
                if (continute_setup == false)
                {
                    return continute_setup;
                }

                continute_setup = SetupCrossHair();
                if (continute_setup == false)
                {
                    return continute_setup;
                }

                continute_setup = SetupMouseLock();
                if (continute_setup == false)
                {
                    return continute_setup;
                }

            }

            return continute_setup;

        }

        #endregion

        #region Setup Character

        public virtual bool SetupRuntimeAnimatorController()
        {
            bool continute_setup = false;
            AlertProgress("Checking if Animator Exits");

            character_animator = character.GetComponent<Animator>();

            if (character_animator == false)
            {
                AlertProgress("Invalid prefab, must have animation controller to create life");
                continute_setup = false;
                return continute_setup;
            }
            else
            {
                if (character_animator.runtimeAnimatorController)
                {
                    AlertProgress("Character Runtime Animator Controller Found");
                    continute_setup = true;
                }
                else
                {
                    AlertProgress("Character Runtime Animator Controller not found");
                    AlertProgress("Assigning Runtime Animator Controller");

                    character_animator.runtimeAnimatorController = character_defaults.animatorController.runtimeAnimatorController;
                    continute_setup = true;
                    AlertProgress("Reanimation process is complete");

                }

                character_animator.applyRootMotion = character_defaults.animatorController.applyRootMotion; ;

                AlertProgress("Runtime Animator Controller name: " + character_animator.runtimeAnimatorController.name);
            }

            return continute_setup;
        }

        public virtual void SetRigidBodyDefaults(Rigidbody rigidbody)
        {
            if(rigidbody == false)
            {
                return;
            }

            AlertProgress("Setting Default Rigidbody values");

            TPCSTRigidbody rigidBody = character_defaults.rigidbody;
            rigidbody.mass = rigidBody.mass;
            rigidbody.drag = rigidBody.drag;
            rigidbody.angularDrag = rigidBody.angular_drag;
            rigidbody.useGravity = rigidBody.use_gravity;
            rigidbody.isKinematic = rigidBody.is_kinematic;
            rigidbody.interpolation = rigidBody.interpolation;
            rigidbody.collisionDetectionMode = rigidBody.collisionDetectionMode;
            rigidbody.constraints = rigidBody.constraints;

            AlertProgress("Setting Default Rigidbody values complete");

        }

        public virtual bool SetupRigidBody()
        {
            bool continute_setup = true;
            AlertProgress("Checking Rigidbody Dependencies");
            Rigidbody rigidbody = character.GetComponent<Rigidbody>();

            if (rigidbody)
            {
                AlertProgress("Character Rigidbody Found");
                SetRigidBodyDefaults(rigidbody);
                continute_setup = true;
            }
            else
            {
                AlertProgress(" RigidBody not found");
                AlertProgress("Creating Rigidbody");
                rigidbody = character.AddComponent<Rigidbody>();
                SetRigidBodyDefaults(rigidbody);
                continute_setup = true;
            }
            AlertProgress("Rigidbody Setup complete");

            return continute_setup;
        }

        public virtual void SetCapsuleColliderDefaults(CapsuleCollider capsuleCollider)
        {
            if (capsuleCollider == false)
            {
                return;
            }
            AlertProgress("Setting Default CapsuleCollider values");

            TPCSTCapsuleCollider capsule = character_defaults.capsuleCollider;
            capsuleCollider.isTrigger = capsule.is_trigger;
            capsuleCollider.material = capsule.physicMaterial;
            capsuleCollider.center = capsule.center;
            capsuleCollider.radius = capsule.radius;
            capsuleCollider.height = capsule.height;
            capsuleCollider.direction = (int)capsule.direction;
            
            AlertProgress("Setting Default CapsuleCollider values complete");
        }

        public virtual bool SetupCapsuleCollider()
        {
            bool continute_setup = false;
            AlertProgress("Checking Capsule Collider Dependencies");
            CapsuleCollider capsuleCollider = character.GetComponent<CapsuleCollider>();

            if (capsuleCollider)
            {
                AlertProgress("Character CapsuleCollider Found");
                SetCapsuleColliderDefaults(capsuleCollider);
                continute_setup = true;
            }
            else
            {
                AlertProgress(" CapsuleCollider not found");
                AlertProgress("Creating CapsuleCollider");
                capsuleCollider = character.AddComponent<CapsuleCollider>();
                SetCapsuleColliderDefaults(capsuleCollider);
                continute_setup = true;
            }
            AlertProgress("CapsuleCollider Setup complete");

            return continute_setup;
        }

        public virtual void SetupActorDefaults(Actor actor)
        {
            if (actor == false)
            {
                return;
            }
            AlertProgress("Setting Default Actor values");

            TPCSTActor tempActor = character_defaults.actor;
            actor.Side = tempActor.side;
            actor.IsAggressive = tempActor.is_aggressive;

            AlertProgress("Setting Default Actor values complete");
        }

        public virtual bool SetupActor()
        {
            bool continute_setup = false;
            AlertProgress("Checking Actor Dependencies");
            Actor actor = character.GetComponent<Actor>();

            if (actor)
            {
                AlertProgress("Character Actor Found");
                SetupActorDefaults(actor);
                continute_setup = true;
            }
            else
            {
                AlertProgress(" Actor not found");
                AlertProgress("Creating Actor");
                actor = character.AddComponent<Actor>();
                SetupActorDefaults(actor);
                continute_setup = true;
            }
            AlertProgress("Actor Setup complete");

            return continute_setup;
        }

        public virtual void SetupCharacterMotorDefaults(CharacterMotor characterMotor)
        {
            if (characterMotor == false)
            {
                return;
            }
            AlertProgress("Setting Default CharacterMotor values");

            TPCSTCharacterMotor motor = character_defaults.characterMotor;
            characterMotor.IsAlive = motor.IsAlive;
            characterMotor.Speed = motor.Speed;
            characterMotor.MoveMultiplier = motor.MoveMultiplier;
            characterMotor.CanRun = motor.CanRun;
            characterMotor.CanSprint = motor.CanSprint;
            characterMotor.GroundThreshold = motor.GroundThreshold;
            characterMotor.FallThreshold = motor.FallThreshold;
            characterMotor.ObstacleDistance = motor.ObstacleDistance;
            characterMotor.Gravity = motor.Gravity;
            characterMotor.RecoilRecovery = motor.RecoilRecovery;
            characterMotor.IsFiringFromCamera = motor.IsFiringFromCamera;
            characterMotor.ZoomErrorMultiplier = motor.ZoomErrorMultiplier;
            characterMotor.CrouchHeight = motor.CrouchHeight;
            characterMotor.AccelerationDamp = motor.AccelerationDamp;
            characterMotor.DeccelerationDamp = motor.DeccelerationDamp;
            characterMotor.MaxSlope = motor.MaxSlope;
            characterMotor.DamageMultiplier = motor.DamageMultiplier;
            characterMotor.IsEquipped = motor.IsEquipped;
            characterMotor.Weapon = motor.Weapon;
            characterMotor.Grenade = motor.Grenade;
            characterMotor.IK = motor.IK;
            characterMotor.CoverSettings = motor.CoverSettings;
            characterMotor.ClimbSettings = motor.ClimbSettings;
            characterMotor.VaultSettings = motor.VaultSettings;
            characterMotor.JumpSettings = motor.JumpSettings;
            characterMotor.RollSettings = motor.RollSettings;
            characterMotor.AimSettings = motor.AimSettings;
            characterMotor.TurnSettings = motor.TurnSettings;
            characterMotor.ShoulderSettings = motor.ShoulderSettings;
            characterMotor.HitResponseSettings = motor.HitResponseSettings;

            AlertProgress("Setting Default CharacterMotor values complete");
        }

        public virtual bool SetupCharacterMotor()
        {
            bool continute_setup = false;
            AlertProgress("Checking CharacterMotor Dependencies");
            CharacterMotor characterMotor = character.GetComponent<CharacterMotor>();

            if (characterMotor)
            {
                AlertProgress("Character CharacterMotor Found");
                SetupCharacterMotorDefaults(characterMotor);
                continute_setup = true;
            }
            else
            {
                AlertProgress("CharacterMotor not found");
                AlertProgress("Creating CharacterMotor");
                characterMotor = character.AddComponent<CharacterMotor>();
                SetupCharacterMotorDefaults(characterMotor);
                continute_setup = true;
            }
            AlertProgress("CharacterMotor Setup complete");

            return continute_setup;
        }

        public virtual void SetupThirdPersonControllerDefaults(ThirdPersonController thirdPersonController)
        {
            if (thirdPersonController == false)
            {
                return;
            }
            AlertProgress("Setting Default ThirdPersonController values");


            TPCSTCharacterController characterController = character_defaults.characterController;
            thirdPersonController.AutoTakeCover = characterController.AutoTakeCover;
            thirdPersonController.CoverEnterDelay = characterController.CoverEnterDelay;
            thirdPersonController.AlwaysAim = characterController.AlwaysAim;
            thirdPersonController.AimWhenWalking = characterController.AimWhenWalking;
            thirdPersonController.CrouchNearCovers = characterController.CrouchNearCovers;
            thirdPersonController.ImmediateTurns = characterController.ImmediateTurns;
            thirdPersonController.MeleeRadius = characterController.MeleeRadius;
            thirdPersonController.MinMeleeDistance = characterController.MinMeleeDistance;
            thirdPersonController.AimSustain = characterController.AimSustain;
            thirdPersonController.NoAimSustain = characterController.NoAimSustain;
            thirdPersonController.CancelHurt = characterController.CancelHurt;
            thirdPersonController.ThrowAngleOffset = characterController.ThrowAngleOffset;
            thirdPersonController.MaxThrowAngle = characterController.MaxThrowAngle;
            thirdPersonController.PostLandAimDelay = characterController.PostLandAimDelay;
            thirdPersonController.ArmLiftDelay = characterController.ArmLiftDelay;
            thirdPersonController.ExplosionPreview = characterController.ExplosionPreview;
            thirdPersonController.PathPreview = characterController.PathPreview;

            AlertProgress("Setting Default ThirdPersonController values complete");
        }

        public virtual bool SetupThirdPersonController()
        {
            bool continute_setup = false;
            AlertProgress("Checking ThirdPersonController Dependencies");
            ThirdPersonController thirdPersonController = character.GetComponent<ThirdPersonController>();

            if (thirdPersonController)
            {
                AlertProgress("Character ThirdPersonController Found");
                SetupThirdPersonControllerDefaults(thirdPersonController);
                continute_setup = true;
            }
            else
            {
                AlertProgress(" ThirdPersonInput not found");
                AlertProgress("Creating ThirdPersonInput");
                thirdPersonController = character.AddComponent<ThirdPersonController>();
                SetupThirdPersonControllerDefaults(thirdPersonController);
                continute_setup = true;
            }
            AlertProgress("ThirdPersonController Setup complete");

            return continute_setup;
        }

        public virtual void SetupThirdPersonInputDefaults(ThirdPersonInput thirdPersonInput)
        {
            if (thirdPersonInput == false)
            {
                return;
            }
            AlertProgress("Setting Default ThirdPersonInput values");

            TPCSTInputController inputController = character_defaults.inputController;
            thirdPersonInput.FastMovement = inputController.FastMovement;
            thirdPersonInput.WalkWhenZooming = inputController.WalkWhenZooming;
            thirdPersonInput.CameraOverride = inputController.CameraOverride;
            thirdPersonInput.HorizontalRotateSpeed = inputController.HorizontalRotateSpeed;
            thirdPersonInput.VerticalRotateSpeed = inputController.VerticalRotateSpeed;
            thirdPersonInput.ZoomRotateMultiplier = inputController.ZoomRotateMultiplier;
            thirdPersonInput.RotateWhenUnlocked = inputController.RotateWhenUnlocked;
            thirdPersonInput.DoubleTapDelay = inputController.DoubleTapDelay;
            thirdPersonInput.CustomActions = inputController.CustomActions;
            thirdPersonInput.Disabler = inputController.Disabler;

            AlertProgress("Setting Default ThirdPersonInput values complete");
        }

        public virtual bool SetupThirdPersonInput()
        {
            bool continute_setup = false;
            AlertProgress("Checking ThirdPersonInput Dependencies");
            ThirdPersonInput thirdPersonInput = character.GetComponent<ThirdPersonInput>();

            if (thirdPersonInput)
            {
                AlertProgress("Character ThirdPersonInput Found");
                SetupThirdPersonInputDefaults(thirdPersonInput);
                continute_setup = true;
            }
            else
            {
                AlertProgress("ThirdPersonInput not found");
                AlertProgress("Creating ThirdPersonInput");
                thirdPersonInput = character.AddComponent<ThirdPersonInput>();
                SetupThirdPersonInputDefaults(thirdPersonInput);
                continute_setup = true;
            }

            AlertProgress("ThirdPersonInput Setup complete");
            return continute_setup;
    }

        public virtual void SetupCharacterSoundsDefaults(CharacterSounds characterSounds)
        {
            if (characterSounds == false)
            {
                return;
            }
            AlertProgress("Setting Default CharacterSounds values");

            TPCSTCharacterSounds tempCharacterSounds = character_defaults.characterSounds;
            characterSounds.Footstep = tempCharacterSounds.Footstep;
            characterSounds.Death = tempCharacterSounds.Death;
            characterSounds.Jump = tempCharacterSounds.Jump;
            characterSounds.Land = tempCharacterSounds.Land;
            characterSounds.Block = tempCharacterSounds.Block;
            characterSounds.Hurt = tempCharacterSounds.Hurt;
            characterSounds.Hit = tempCharacterSounds.Hit;
            characterSounds.BigHit = tempCharacterSounds.BigHit;
            characterSounds.BigDamageThreshold = tempCharacterSounds.BigDamageThreshold;

            AlertProgress("Setting Default CharacterSounds values complete");
        }

        public virtual bool SetupCharacterSounds()
        {
            bool continute_setup = false;
            AlertProgress("Checking CharacterSounds Dependencies");
            CharacterSounds characterSounds = character.GetComponent<CharacterSounds>();

            if (characterSounds)
            {
                AlertProgress("CharacterSounds Found");
                SetupCharacterSoundsDefaults(characterSounds);
                continute_setup = true;
            }
            else
            {
                AlertProgress(" CharacterSounds not found");
                AlertProgress("Creating CharacterSounds");
                characterSounds = character.AddComponent<CharacterSounds>();
                SetupCharacterSoundsDefaults(characterSounds);
                continute_setup = true;
            }

            AlertProgress("CharacterSounds Setup complete");
            return continute_setup;
        }

        public virtual void SetupCharacterEffectsDefaults(CharacterEffects characterEffects)
        {
            if (characterEffects == false)
            {
                return;
            }
            AlertProgress("Setting Default CharacterEffects values");

            TPCSTCharacterEffects tempCharacterEffects = character_defaults.characterEffects;
            characterEffects.Step = tempCharacterEffects.Step;
            characterEffects.Land = tempCharacterEffects.Land;
            characterEffects.Death = tempCharacterEffects.Death;
            characterEffects.Resurrection = tempCharacterEffects.Resurrection;
            characterEffects.Hurt = tempCharacterEffects.Hurt;
            characterEffects.Block = tempCharacterEffects.Block;
            characterEffects.Hit = tempCharacterEffects.Hit;
            characterEffects.BigHit = tempCharacterEffects.BigHit;
            characterEffects.BigDamageThreshold = tempCharacterEffects.BigDamageThreshold;


            AlertProgress("Setting Default CharacterEffects values complete");
        }

        public virtual bool SetupCharacterEffects()
        {
            bool continute_setup = false;
            AlertProgress("Checking CharacterEffects Dependencies");
            CharacterEffects characterEffects = character.GetComponent<CharacterEffects>();

            if (characterEffects)
            {
                AlertProgress("CharacterEffects Found");
                SetupCharacterEffectsDefaults(characterEffects);
                continute_setup = true;
            }
            else
            {
                AlertProgress("CharacterEffects not found");
                AlertProgress("Creating CharacterEffects");
                characterEffects = character.AddComponent<CharacterEffects>();
                SetupCharacterEffectsDefaults(characterEffects);
                continute_setup = true;
            }

            AlertProgress("CharacterEffects Setup complete");
            return continute_setup;
        }

        public virtual void SetupCharacterAlertsDefaults(CharacterAlerts characterAlerts)
        {
            if (characterAlerts == false)
            {
                return;
            }
            AlertProgress("Setting Default CharacterEffects values");

            TPCSTCharacterAlerts tempCharacterAlerts = character_defaults.characterAlerts;
            characterAlerts.Step = tempCharacterAlerts.Step;
            characterAlerts.Hurt = tempCharacterAlerts.Hurt;
            characterAlerts.Death = tempCharacterAlerts.Death;
            characterAlerts.Jump = tempCharacterAlerts.Jump;
            characterAlerts.Land = tempCharacterAlerts.Land;
            characterAlerts.Resurrect = tempCharacterAlerts.Resurrect;

            AlertProgress("Setting Default CharacterEffects values complete");
        }

        public virtual bool SetupCharacterAlerts()
        {
            bool continute_setup = false;
            AlertProgress("Checking CharacterAlerts Dependencies");
            CharacterAlerts characterAlerts = character.GetComponent<CharacterAlerts>();

            if (characterAlerts)
            {
                AlertProgress("CharacterAlerts Found");
                SetupCharacterAlertsDefaults(characterAlerts);
                continute_setup = true;
            }
            else
            {
                AlertProgress("CharacterAlerts not found");
                AlertProgress("Creating CharacterAlerts");
                characterAlerts = character.AddComponent<CharacterAlerts>();
                SetupCharacterAlertsDefaults(characterAlerts);
                continute_setup = true;
            }

            AlertProgress("CharacterAlerts Setup complete");
            return continute_setup;
        }

        public virtual void SetupCharacterHealthDefaults(CharacterHealth characterHealth)
        {
            if (characterHealth == false)
            {
                return;
            }
            AlertProgress("Setting Default CharacterHealth values");

            TPCSTCharacterHealth tempCharacterHealth = character_defaults.characterHealth;
            characterHealth.Health = tempCharacterHealth.Health;
            characterHealth.MaxHealth = tempCharacterHealth.MaxHealth;
            characterHealth.Regeneration = tempCharacterHealth.Regeneration;
            characterHealth.DamageMultiplier = tempCharacterHealth.DamageMultiplier;
            characterHealth.IsTakingDamage = tempCharacterHealth.IsTakingDamage;
            characterHealth.IsRegisteringHits = tempCharacterHealth.IsRegisteringHits;

            AlertProgress("Setting Default CharacterHealth values complete");
        }

        public virtual bool SetupCharacterHealth()
        {
            bool continute_setup = false;
            AlertProgress("Checking CharacterHealth Dependencies");
            CharacterHealth characterHealth = character.GetComponent<CharacterHealth>();

            if (characterHealth)
            {
                AlertProgress("CharacterHealth Found");
                SetupCharacterHealthDefaults(characterHealth);
                continute_setup = true;
            }
            else
            {
                AlertProgress("CharacterHealth not found");
                AlertProgress("Creating CharacterHealth");
                characterHealth = character.AddComponent<CharacterHealth>();
                SetupCharacterHealthDefaults(characterHealth);
                continute_setup = true;
            }

            AlertProgress("CharacterHealth Setup complete");
            return continute_setup;
        }

        public virtual void SetupCharacterPlatformDefaults(CharacterPlatform characterPlatform)
        {
            if (characterPlatform == false)
            {
                return;
            }
            AlertProgress("Setting Default CharacterPlatform values");

            characterPlatform.Threshold = character_defaults.platformThreshold;

            AlertProgress("Setting Default CharacterPlatform values complete");
        }

        public virtual bool SetupCharacterPlatform()
        {
            bool continute_setup = false;
            AlertProgress("Checking CharacterPlatform Dependencies");
            CharacterPlatform characterPlatform = character.GetComponent<CharacterPlatform>();

            if (characterPlatform)
            {
                AlertProgress("CharacterPlatform Found");
                SetupCharacterPlatformDefaults(characterPlatform);
                continute_setup = true;
            }
            else
            {
                AlertProgress("CharacterPlatform not found");
                AlertProgress("Creating CharacterPlatform");
                characterPlatform = character.AddComponent<CharacterPlatform>();
                SetupCharacterPlatformDefaults(characterPlatform);
                continute_setup = true;
            }

            AlertProgress("CharacterPlatform Setup complete");
            return continute_setup;
        }

        public virtual void SetupCharacterInventoryDefaults(CharacterInventory characterInventory)
        {
            if (characterInventory == false)
            {
                return;
            }
            AlertProgress("Setting Default CharacterInventory values");

            // TODO: set up if inventory scritpable attached
            characterInventory.Weapons = null;

            AlertProgress("Setting Default CharacterInventory values complete");
        }

        public virtual bool SetupCharacterInventory()
        {
            bool continute_setup = false;
            AlertProgress("Checking CharacterInventory Dependencies");
            CharacterInventory characterInventory = character.GetComponent<CharacterInventory>();

            if (characterInventory)
            {
                AlertProgress("CharacterInventory Found");
                SetupCharacterInventoryDefaults(characterInventory);
                continute_setup = true;
            }
            else
            {
                AlertProgress("CharacterInventory not found");
                AlertProgress("Creating CharacterInventory");
                characterInventory = character.AddComponent<CharacterInventory>();
                SetupCharacterInventoryDefaults(characterInventory);
                continute_setup = true;
            }

            AlertProgress("CharacterInventory Setup complete");
            return continute_setup;
        }

        public virtual void SetupResetOnDeathDefaults(ResetOnDeath resetOnDeath)
        {
            if (resetOnDeath == false)
            {
                return;
            }
            AlertProgress("Setting Default ResetOnDeath values");

            resetOnDeath.Delay = character_defaults.resetOnDeathDelay;

            AlertProgress("Setting Default ResetOnDeath values complete");
        }

        public virtual bool SetupResetOnDeath()
        {
            bool continute_setup = false;
            AlertProgress("Checking ResetOnDeath Dependencies");
            ResetOnDeath resetOnDeath = character.GetComponent<ResetOnDeath>();

            if (resetOnDeath)
            {
                AlertProgress("ResetOnDeath Found");
                SetupResetOnDeathDefaults(resetOnDeath);
                continute_setup = true;
            }
            else
            {
                AlertProgress("ResetOnDeath not found");
                AlertProgress("Creating ResetOnDeath");
                resetOnDeath = character.AddComponent<ResetOnDeath>();
                SetupResetOnDeathDefaults(resetOnDeath);
                continute_setup = true;
            }

            AlertProgress("ResetOnDeath Setup complete");
            return continute_setup;
        }

        public virtual bool SetupExitToEscape()
        {
            bool continute_setup = false;
            AlertProgress("Checking ExitToEscape Dependencies");
            ExitToEscape exitToEscape = character.GetComponent<ExitToEscape>();

            if (exitToEscape)
            {
                AlertProgress("ExitToEscape Found");
                continute_setup = true;
            }
            else
            {
                AlertProgress("ExitToEscape not found");
                AlertProgress("Creating ExitToEscape");
                exitToEscape = character.AddComponent<ExitToEscape>();
                continute_setup = true;
            }
            AlertProgress("ExitToEscape Setup complete");

            return continute_setup;
        }

        public virtual bool SetupCharacterFace()
        {
            if (add_character_face == false)
            {
                // Return but dont break the cycle.
                return true;
            }

            bool continute_setup = false;
            AlertProgress("Checking CharacterFace Dependencies");
            CharacterFace characterFace = character.GetComponent<CharacterFace>();

            if (characterFace)
            {
                AlertProgress("CharacterFace Found");
                continute_setup = true;
            }
            else
            {
                AlertProgress("CharacterFace not found");
                AlertProgress("Creating CharacterFace");
                characterFace = character.AddComponent<CharacterFace>();
                continute_setup = true;
            }
            AlertProgress("CharacterFace Setup complete");

            return continute_setup;
        }

        public virtual GameObject CreateFist(string name = "Fist")
        {
            GameObject fistObject = new GameObject
            {
                name = name
            };

            BoxCollider boxCollider = fistObject.AddComponent<BoxCollider>();
            boxCollider.center = new Vector3(0, 0, 0.06f);
            boxCollider.size = new Vector3(0.17f, 0.24f, 0.22f);
            boxCollider.isTrigger = true;

            Melee meleeObject = fistObject.AddComponent<Melee>();
            meleeObject.Type = WeaponType.Fist;
            meleeObject.Damage = 20;
            meleeObject.Cooldown = 0.5f;
            meleeObject.DamageResponseWaitTime = 0;

            CreateObjectAtTransform(fistObject, StaticStrings.aim_transform_key);
            CreateObjectAtTransform(fistObject, StaticStrings.aim_left_hand_transform_key);
            CreateObjectAtTransform(fistObject, StaticStrings.model_transform_key);
            CreateObjectAtTransform(fistObject, StaticStrings.tall_cover_left_transform_key);
            CreateObjectAtTransform(fistObject, StaticStrings.tall_cover_right_transform_key);
            CreateObjectAtTransform(fistObject, StaticStrings.low_cover_left_transform_key);
            CreateObjectAtTransform(fistObject, StaticStrings.low_cover_right_transform_key);

            return fistObject;
        }

        public virtual bool SetupWeaponHandHolders()
        {
            bool continue_setup = true;

            if (left_hand == null || right_hand == null)
            {
                return continue_setup;
            }

            Transform leftHandWeapoNHolder = left_hand.Find(left_hand_weapon_holder_key);
            GameObject weaponHolderTemp = null;

            if (leftHandWeapoNHolder == null)
            {
                weaponHolderTemp = new GameObject
                {
                    name = left_hand_weapon_holder_key,
                };

                weaponHolderTemp.transform.parent = left_hand;
                weaponHolderTemp.transform.localPosition = Vector3.zero;
                weaponHolderTemp.transform.localRotation = Quaternion.identity;
                weaponHolderTemp.transform.localScale = Vector3.one;

                GameObject fist = CreateFist("LeftFist");
                fist.transform.parent = weaponHolderTemp.transform;
                fist.transform.localPosition = Vector3.zero;
                fist.transform.localRotation = Quaternion.identity;
                fist.transform.localScale = Vector3.one;
            }

            Transform rightHandWeapoNHolder = right_hand.Find(right_hand_weapon_holder_key);
            weaponHolderTemp = null;
            if (rightHandWeapoNHolder == null)
            {
                weaponHolderTemp = new GameObject
                {
                    name = right_hand_weapon_holder_key,
                };

                weaponHolderTemp.transform.parent = right_hand;
                weaponHolderTemp.transform.localPosition = Vector3.zero;
                weaponHolderTemp.transform.localRotation = Quaternion.identity;
                weaponHolderTemp.transform.localScale = Vector3.one;

                GameObject fist = CreateFist("RightFist");
                fist.transform.parent = weaponHolderTemp.transform;
                fist.transform.localPosition = Vector3.zero;
                fist.transform.localRotation = Quaternion.identity;
                fist.transform.localScale = Vector3.one;
            }

            return continue_setup;
        }


        public virtual bool CheckCharacterDependencies()
        {
            bool continue_setup = true;
            AlertProgress("Checking Character Dependencies");

            if (character == null)
            {
                AlertProgress("Character prefab unassigned shutting down character generator... I have failed you.");
                continue_setup = false;
                return continue_setup;
            }
            else
            {
                AlertProgress("Character prefab assigned, checking for required scripts");
                continue_setup = SetupRuntimeAnimatorController();
                if (continue_setup == false)
                {
                    return continue_setup;
                }

                continue_setup = SetupRigidBody();
                if (continue_setup == false)
                {
                    return continue_setup;
                }

                continue_setup = SetupCapsuleCollider();
                if (continue_setup == false)
                {
                    return continue_setup;
                }
                continue_setup = SetupActor();
                if (continue_setup == false)
                {
                    return continue_setup;
                }

                continue_setup = SetupCharacterMotor();
                if (continue_setup == false)
                {
                    return continue_setup;
                }

                continue_setup = SetupThirdPersonController();
                if (continue_setup == false)
                {
                    return continue_setup;
                }

                continue_setup = SetupThirdPersonInput();
                if (continue_setup == false)
                {
                    return continue_setup;
                }

                continue_setup = SetupCharacterSounds();
                if (continue_setup == false)
                {
                    return continue_setup;
                }

                continue_setup = SetupCharacterEffects();
                if (continue_setup == false)
                {
                    return continue_setup;
                }

                continue_setup = SetupCharacterAlerts();
                if (continue_setup == false)
                {
                    return continue_setup;
                }

                continue_setup = SetupCharacterHealth();
                if (continue_setup == false)
                {
                    return continue_setup;
                }

                continue_setup = SetupCharacterPlatform();
                if (continue_setup == false)
                {
                    return continue_setup;
                }

                continue_setup = SetupCharacterInventory();
                if (continue_setup == false)
                {
                    return continue_setup;
                }

                //continue_setup = SetupResetOnDeath();
                //if (continue_setup == false)
                //{
                //    return continue_setup;
                //}

                continue_setup = SetupExitToEscape();
                if (continue_setup == false)
                {
                    return continue_setup;
                }

                continue_setup = SetupCharacterFace();
                if (continue_setup == false)
                {
                    return continue_setup;
                }

                continue_setup = SetupWeaponHandHolders();
                if(continue_setup == false)
                {
                    return continue_setup;
                }
            }

            AlertProgress("Check Character Dependencies complete");
            return continue_setup;

        }

        #endregion

        #region Editor GUI

        [MenuItem("CoverShooter/Generators/Quick Setup Character")]
        public static void ShowWindow()
        {
            window = EditorWindow.GetWindow<ThirdPersonCharacterGeneratorWindow>("Quick Character Setup");
            window.minSize = new Vector2(400, 380);
            window.maxSize = new Vector2(400, 380);
            window.Show();
        }

        public virtual void OnEnable()
        {
            splashTexture = (Texture2D)Resources.Load("Textures/Third Person Cover Shooter Template - Character Generator", typeof(Texture2D));
        }

        public override void OnGUI()
        {
            base.OnGUI();

            // SPLASH
            if (splashTexture != null)
            {
                GUILayoutUtility.GetRect(1f, 3f, GUILayout.ExpandWidth(false));
                Rect rect = GUILayoutUtility.GetRect(GUIContent.none, GUIStyle.none, GUILayout.Height(100f));
                GUI.DrawTexture(rect, splashTexture, ScaleMode.ScaleAndCrop, true, 0f);
            }
            else
            {
                // Interneral log dont use debug method here
                Debug.Log("splash texture null");
            }

            EditorGUILayout.BeginVertical(wrapperStyle);
            debug_log = EditorGUILayout.Toggle("Log Setup Progress", debug_log);

            EditorGUILayout.Separator();

            camera_tag = EditorGUILayout.TagField("Camera Tag", camera_tag);
            camera = (GameObject)EditorGUILayout.ObjectField("Player Camera", camera, typeof(GameObject), true);

            EditorGUILayout.Separator();
            selected_layer = EditorGUILayout.LayerField("Player Layer:", selected_layer);

            character = (GameObject)EditorGUILayout.ObjectField("Player Controller", character, typeof(GameObject), true);
            character_defaults = (TPCSTScriptableCharacter)EditorGUILayout.ObjectField("Character Defaults", character_defaults, typeof(TPCSTScriptableCharacter), true);

            left_hand = (Transform)EditorGUILayout.ObjectField("Left Hand", left_hand, typeof(Transform), true);
            right_hand = (Transform)EditorGUILayout.ObjectField("Right Hand", right_hand, typeof(Transform), true);
           
            EditorGUILayout.Separator();

            add_character_face = EditorGUILayout.Toggle("Use Character Face", add_character_face);

            GUI.enabled = character != false && add_character_face;

            if (add_character_face)
            {
                character_face = (GameObject)EditorGUILayout.ObjectField("Face Mesh", character, typeof(GameObject), true);
            }
          
            GUI.enabled = true;

            EditorGUILayout.Separator();

            GUI.enabled = character != null
                && camera != null
                && character_defaults != null
                && left_hand != null
                && right_hand != null;

            if (GUILayout.Button("Make it quick", GUILayout.Height(50)))
            {
                Utils.ClearLogConsole();
                AlertProgress("Im ready master... Im not ready!!!");

                CheckCharacterDependencies();
                CheckCameraDependencies();
                character.layer = selected_layer;

                AlertProgress("Jobs done");

            }
            GUI.enabled = true;

            // -- END WRAPPER --
            EditorGUILayout.EndVertical();


        }

        #endregion
    }
}
