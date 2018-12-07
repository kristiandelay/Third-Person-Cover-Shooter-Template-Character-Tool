using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace CoverShooter.Tools
{

    public class ThirdPersonCharacterGeneratorWindow : EditorWindow
    {
        #region Variables

        // Character Objects
        public GameObject camera;
        public GameObject character;
        public Transform left_hand;
        public Transform right_hand;
        public GameObject character_face;
        public List<GameObject> weapons_prefabs = new List<GameObject>();

        public bool debug_log = true;
        public bool add_character_face = false;

        // Animations
        Animator character_animator;
        RuntimeAnimatorController runtimeAnimatorController;
        public bool override_animation = true;

        //GUI
        static ThirdPersonCharacterGeneratorWindow window;
        protected Texture2D splashTexture;
        protected GUIStyle titleStyle, subtitleStyle, wrapperStyle;

        #endregion

        #region Debug

        public virtual void AlertProgress(string text)
        {
            if(debug_log)
            {
                ShowNotification(new GUIContent(text));
                Debug.Log(text);
            }
        }

        #endregion

        #region Setup Camera

        public virtual void SetupThirdPersonCameraDefaults(ThirdPersonCamera thirdPersonCamera)
        {
            if (thirdPersonCamera == false)
            {
                return;
            }
            AlertProgress("Setting Default ThirdPersonCamera values");

            thirdPersonCamera.Target = character.GetComponent<CharacterMotor>();
            thirdPersonCamera.AvoidObstacles = true;
            thirdPersonCamera.IgnoreObstaclesWhenZooming = true;
            thirdPersonCamera.Zoom = 10;
            thirdPersonCamera.ShakingAffectsAim = true;
            thirdPersonCamera.AskForSmoothRotations = true;

            // Set Camera States
            Vector3 constantPivot = new Vector3(0, 2, 0);
            float fov = 60;
            float min_angle = -65;
            float max_angle = 45;

            // Set Default Camera State
            CameraState default_state = thirdPersonCamera.States.Default;
            default_state.Offset = new Vector3(0.64f, 0.1f, -2.5f);
            default_state.Orientation = Vector3.zero;
            default_state.Pivot = Pivot.constant;
            default_state.ConstantPivot = constantPivot;
            default_state.FOV = fov;
            default_state.MinAngle = min_angle;
            default_state.MaxAngle = max_angle;

            // Set Aim Camera State
            CameraState aim_state = thirdPersonCamera.States.Aim;
            aim_state.Offset = new Vector3(0.75f, -0.25f, -1.7f);
            aim_state.Orientation = Vector3.zero;
            aim_state.Pivot = Pivot.constant;
            aim_state.ConstantPivot = constantPivot;
            aim_state.FOV = fov;
            aim_state.MinAngle = min_angle;
            aim_state.MaxAngle = max_angle;

            // Set Melee Camera State
            CameraState melee_state = thirdPersonCamera.States.Melee;
            melee_state.Offset = new Vector3(0.3f, -0.3f, -4f);
            melee_state.Orientation = Vector3.zero;
            melee_state.Pivot = Pivot.constant;
            melee_state.ConstantPivot = constantPivot;
            melee_state.FOV = fov;
            melee_state.MinAngle = min_angle;
            melee_state.MaxAngle = max_angle;

            // Set Crouch Camera State
            CameraState crouch_state = thirdPersonCamera.States.Crouch;
            crouch_state.Offset = new Vector3(0.75f, -0.8f, -1f);
            crouch_state.Orientation = Vector3.zero;
            crouch_state.Pivot = Pivot.constant;
            crouch_state.ConstantPivot = constantPivot;
            crouch_state.FOV = fov;
            crouch_state.MinAngle = min_angle;
            crouch_state.MaxAngle = max_angle;

            // Set Low Cover Camera State
            CameraState low_cover_state = thirdPersonCamera.States.LowCover;
            low_cover_state.Offset = new Vector3(0.5f, -0.3f, -1.5f);
            low_cover_state.Orientation = Vector3.zero;
            low_cover_state.Pivot = Pivot.constant;
            low_cover_state.ConstantPivot = new Vector3(0, 1.75f, 0); ;
            low_cover_state.FOV = fov;
            low_cover_state.MinAngle = min_angle;
            low_cover_state.MaxAngle = max_angle;

            // Set Lower Cover Grenade Camera State
            CameraState low_cover_grenade_state = thirdPersonCamera.States.LowCoverGrenade;
            low_cover_grenade_state.Offset = new Vector3(0.23f, -0.23f, -2.2f);
            low_cover_grenade_state.Orientation = Vector3.zero;
            low_cover_grenade_state.Pivot = Pivot.constant;
            low_cover_grenade_state.ConstantPivot = constantPivot;
            low_cover_grenade_state.FOV = fov;
            low_cover_grenade_state.MinAngle = min_angle;
            low_cover_grenade_state.MaxAngle = max_angle;

            // Set Tall Cover Camera State
            CameraState tall_cover_state = thirdPersonCamera.States.TallCover;
            tall_cover_state.Offset = new Vector3(0.5f, -0.8f, -1.5f);
            tall_cover_state.Orientation = Vector3.zero;
            tall_cover_state.Pivot = Pivot.constant;
            tall_cover_state.ConstantPivot = constantPivot;
            tall_cover_state.FOV = fov;
            tall_cover_state.MinAngle = min_angle;
            tall_cover_state.MaxAngle = max_angle;

            // Set Tall Cover Back Camera State
            CameraState tall_cover_back_state = thirdPersonCamera.States.TallCoverBack;
            tall_cover_back_state.Offset = new Vector3(0.65f, -0.2f, -1.5f);
            tall_cover_back_state.Orientation = Vector3.zero;
            tall_cover_back_state.Pivot = Pivot.constant;
            tall_cover_back_state.ConstantPivot = new Vector3(0, 1.6f, 0);
            tall_cover_back_state.FOV = fov;
            tall_cover_back_state.MinAngle = min_angle;
            tall_cover_back_state.MaxAngle = max_angle;

            // Set Corner Camera State
            CameraState corner_state = thirdPersonCamera.States.Corner;
            corner_state.Offset = new Vector3(1.2f, -0.2f, -2.4f);
            corner_state.Orientation = Vector3.zero;
            corner_state.Pivot = Pivot.constant;
            corner_state.ConstantPivot = new Vector3(0, 1.75f, 0);
            corner_state.FOV = fov;
            corner_state.MinAngle = min_angle;
            corner_state.MaxAngle = max_angle;

            // Set Climb State
            CameraState climb_state = thirdPersonCamera.States.Climb;
            climb_state.Offset = new Vector3(0.75f, -0.25f, -1.7f);
            climb_state.Orientation = Vector3.zero;
            climb_state.Pivot = Pivot.constant;
            climb_state.ConstantPivot = constantPivot;
            climb_state.FOV = fov;
            climb_state.MinAngle = min_angle;
            climb_state.MaxAngle = max_angle;

            // Set Dead State
            CameraState dead_state = thirdPersonCamera.States.Dead;
            dead_state.Offset = new Vector3(0, 1, -2.5f);
            dead_state.Orientation = Vector3.zero;
            dead_state.Pivot = Pivot.constant;
            dead_state.ConstantPivot = Vector3.zero;
            dead_state.FOV = fov;
            dead_state.MinAngle = min_angle;
            dead_state.MaxAngle = max_angle;

            // Set Zoom State
            CameraState zoom_state = thirdPersonCamera.States.Zoom;
            zoom_state.Offset = new Vector3(0.5f, 0.15f, -1);
            zoom_state.Orientation = Vector3.zero;
            zoom_state.Pivot = Pivot.constant;
            zoom_state.ConstantPivot = Vector3.zero;
            zoom_state.FOV = 40;
            zoom_state.MinAngle = min_angle;
            zoom_state.MaxAngle = max_angle;

            // Set Low Corner Zoom State
            CameraState low_corner_zoom_state = thirdPersonCamera.States.LowCornerZoom;
            low_corner_zoom_state.Offset = new Vector3(1.2f, -0.2f, -1.2f);
            low_corner_zoom_state.Orientation = Vector3.zero;
            low_corner_zoom_state.Pivot = Pivot.constant;
            low_corner_zoom_state.ConstantPivot = new Vector3(0, 1.35f, 0);
            low_corner_zoom_state.FOV = 40;
            low_corner_zoom_state.MinAngle = min_angle;
            low_corner_zoom_state.MaxAngle = max_angle;

            // Set Tall Corner Zoom State
            CameraState tall_corner_zoom_state = thirdPersonCamera.States.TallCornerZoom;
            tall_corner_zoom_state.Offset = new Vector3(0.8f, -0.2f, -1.2f);
            tall_corner_zoom_state.Orientation = Vector3.zero;
            tall_corner_zoom_state.Pivot = Pivot.constant;
            tall_corner_zoom_state.ConstantPivot = new Vector3(0, 1.75f, 0);
            tall_corner_zoom_state.FOV = 40;
            tall_corner_zoom_state.MinAngle = min_angle;
            tall_corner_zoom_state.MaxAngle = max_angle;


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

            // Setup Crosshair Defaults
            CrosshairSettings default_settings = crossHair.Default;
            default_settings.Scale = 1;
            default_settings.LowAngle = 1.5f;
            default_settings.HighAngle = 10;
            default_settings.Adaptation = 2;
            default_settings.ShakeMultiplier = 2;
            default_settings.RecoilMultiplier = 1;
            default_settings.Sprites = null;

            // Setup Crosshair Pistol
            CrosshairSettings pistol_settings = crossHair.Pistol;
            pistol_settings.Sprites = null;
            pistol_settings.Scale = 1;
            pistol_settings.LowAngle = 1.5f;
            pistol_settings.HighAngle = 10;
            pistol_settings.Adaptation = 2;
            pistol_settings.ShakeMultiplier = 2;
            pistol_settings.RecoilMultiplier = 1;

            Sprite[] pistol_sprite = new Sprite[10];
            Sprite[] sprites = Resources.LoadAll<Sprite>("Assets/UI/crosshairs_animated");
            int sprite_start_index = 10;
            for (int i = 0; i < pistol_sprite.Length; i++)
            {
                pistol_sprite[i] = sprites[sprite_start_index + i];
            }
            crossHair.Pistol.Sprites = pistol_sprite;

            // Setup Crosshair Rifle 
            CrosshairSettings rifle_settings = crossHair.Rifle;
            rifle_settings.Scale = 1;
            rifle_settings.LowAngle = 1.5f;
            rifle_settings.HighAngle = 10;
            rifle_settings.Adaptation = 2;
            rifle_settings.ShakeMultiplier = 2;
            rifle_settings.RecoilMultiplier = 1;

            Sprite[] rifle_sprite = new Sprite[10];
            sprite_start_index = 20;

            for (int i = 0; i < rifle_sprite.Length; i++)
            {
                rifle_sprite[i] = sprites[sprite_start_index + i];
            }
            crossHair.Rifle.Sprites = rifle_sprite;

            // Setup Crosshair Shotgun
            CrosshairSettings shotgun_settings = crossHair.Shotgun;
            shotgun_settings.Scale = 1;
            shotgun_settings.LowAngle = 1.5f;
            shotgun_settings.HighAngle = 10;
            shotgun_settings.Adaptation = 2;
            shotgun_settings.ShakeMultiplier = 2;
            shotgun_settings.RecoilMultiplier = 1;
            shotgun_settings.Sprites = null;

            // Setup Crosshair Sniper
            CrosshairSettings sniper_settings = crossHair.Sniper;
            sniper_settings.Scale = 1;
            sniper_settings.LowAngle = 1.5f;
            sniper_settings.HighAngle = 10;
            sniper_settings.Adaptation = 2;
            sniper_settings.ShakeMultiplier = 2;
            sniper_settings.RecoilMultiplier = 1;
            sniper_settings.Sprites = null;


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
                AlertProgress("Invalid Lifeform Animator not Found. Invalid prefab, prefab must have animation controller to create life");
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

                    character_animator.runtimeAnimatorController = runtimeAnimatorController;
                    continute_setup = true;
                    AlertProgress("Reanimation process is complete");

                }

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

            rigidbody.mass = 60;
            rigidbody.drag = 0;
            rigidbody.angularDrag = 0.05f;
            rigidbody.useGravity = false;
            rigidbody.isKinematic = false;
            rigidbody.interpolation = RigidbodyInterpolation.None;
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
            rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

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
            capsuleCollider.isTrigger = false;

            PhysicMaterial physicMaterial = (PhysicMaterial)Resources.Load("Animations/Mecanim assets/ZeroFriction", typeof(PhysicMaterial)) as PhysicMaterial;
            if(physicMaterial)
            {
                capsuleCollider.material = physicMaterial;
            } 
            else {
                capsuleCollider.material.dynamicFriction = 0;
                capsuleCollider.material.staticFriction = 0;
                capsuleCollider.material.bounciness = 0;
                capsuleCollider.material.frictionCombine = PhysicMaterialCombine.Multiply;
                capsuleCollider.material.bounceCombine = PhysicMaterialCombine.Average;
                capsuleCollider.material.name = "ZeroPhysicsDynamic";
            }

            capsuleCollider.center = new Vector3(0, 0.95f, 0);
            capsuleCollider.radius = 0.3f;
            capsuleCollider.height = 1.9f;
            capsuleCollider.direction = 1; //Y-Axis
            

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

            actor.Side = 1;
            actor.IsAggressive = true;


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

            characterMotor.IsAlive = true;
            characterMotor.Speed = 1.25f;
            characterMotor.MoveMultiplier = 1.35f;
            characterMotor.CanRun = true;
            characterMotor.CanSprint = true;
            characterMotor.GroundThreshold = 0.25f;
            characterMotor.FallThreshold = 1.2f;
            characterMotor.ObstacleDistance = 0.05f;
            characterMotor.Gravity = 18;
            characterMotor.RecoilRecovery = 17;
            characterMotor.IsFiringFromCamera = true;
            characterMotor.ZoomErrorMultiplier = 0.75f;
            characterMotor.CrouchHeight = 1.5f;
            characterMotor.AccelerationDamp = 1;
            characterMotor.DeccelerationDamp = 3;
            characterMotor.MaxSlope = 55;
            characterMotor.DamageMultiplier = 1;
            characterMotor.IsEquipped = false;

            // Configure WeaponDescription
            WeaponDescription weaponDescription = characterMotor.Weapon;
            weaponDescription.PreferSwapping = true;
            weaponDescription.IsDualWielding = true;
            weaponDescription.IsHeavy = false;
            weaponDescription.PreventCovers = false;
            weaponDescription.PreventClimbing = false;
            weaponDescription.PreventArmLowering = false;
            weaponDescription.Aiming = WeaponAiming.input;

            // Configure GrenadeSettings
            GrenadeSettings grenadeSettings = characterMotor.Grenade;
            grenadeSettings.Left = null;
            grenadeSettings.Right = null;
            grenadeSettings.MaxVelocity = 12.5f;
            grenadeSettings.Gravity = 10;
            grenadeSettings.Step = 0.1f;
            grenadeSettings.StandingOrigin = new Vector3(0.33f, 1.88f, 0);
            grenadeSettings.CrouchOrigin = new Vector3(0.5f, 1.43f, 0);
            grenadeSettings.DropOnHit = true;

            // Configure IKSettings
            IKSettings ikSettings = characterMotor.IK;
            ikSettings.Enabled = true;
            ikSettings.MinIterations = 2;
            ikSettings.MaxIterations = 10;
            ikSettings.Delay.Min = 0;
            ikSettings.Delay.Max = 0;
            ikSettings.Delay.MinDistance = 0;
            ikSettings.Delay.MaxDistance = 0;

            // Configure CoverSettings
            CoverSettings coverSettings = characterMotor.CoverSettings;
            coverSettings.CanUseTallCorners = true;
            coverSettings.CanUseLowCorners = true;
            coverSettings.ExitBack = 120;
            coverSettings.LowCapsuleHeight = 0.75f;
            coverSettings.LowAimCapsuleHeight = 1.25f;
            coverSettings.LowRotationSpeed = 10;
            coverSettings.TallRotationSpeed = 15;
            coverSettings.EnterDistance = 0.2f;
            coverSettings.LeaveDistance = 0.25f;
            coverSettings.ClimbDistance = 0.5f;
            coverSettings.MinCrouchDistance = 0.2f;
            coverSettings.MaxCrouchDistance = 1.5f;
            coverSettings.PivotSideMargin = 0.5f;
            coverSettings.CornerAimTriggerDistance = 0.6f;
            coverSettings.TallSideEnterRadius = 0.1f;
            coverSettings.TallSideLeaveRadius = 0.05f;
            coverSettings.LeftTallCornerOffset = 0.2f;
            coverSettings.RightTallCornerOffset = 0.2f;
            coverSettings.LowSideEnterRadius = 0.2f;
            coverSettings.LowSideLeaveRadius = 0.1f;
            coverSettings.LeftLowCornerOffset = 0.4f;
            coverSettings.RightLowCornerOffset = 0.4f;
            coverSettings.DirectionChangeDelay = 0.25f;
            coverSettings.CornerOffset = new Vector3(0.8f, 0, 0);
            coverSettings.Update.IdleNonCover = 10;
            coverSettings.Update.IdleCover = 2;
            coverSettings.Update.MovingNonCover = 0;
            coverSettings.Update.MovingCover = 0;

            // Configure ClimbSettings
            ClimbSettings climbSettings = characterMotor.ClimbSettings;
            climbSettings.CapsuleHeight = 1.5f;
            climbSettings.VerticalScale = 1;
            climbSettings.HorizontalScale = 1.05f;
            climbSettings.Push = 0.5f;
            climbSettings.PushOn = 0.6f;
            climbSettings.PushOff = 0.9f;
            climbSettings.CollisionOff = 0.3f;
            climbSettings.CollisionOn = 0.7f;

            // Configure VaultSettings
            VaultSettings vaultSettings = characterMotor.VaultSettings;
            vaultSettings.CapsuleHeight = 1;
            vaultSettings.VerticalScale = 1.3f;
            vaultSettings.HorizontalScale = 1.4f;
            vaultSettings.Push = 0;
            vaultSettings.PushOn = 0;
            vaultSettings.PushOff = 1;
            vaultSettings.CollisionOff = 0.1f;
            vaultSettings.CollisionOn = 0.7f;

            // Configure JumpSettings
            JumpSettings jumpSettings = characterMotor.JumpSettings;
            jumpSettings.Strength = 6;
            jumpSettings.Speed = 6;
            jumpSettings.CapsuleHeight = 1.5f;
            jumpSettings.HeightDuration = 0.75f;
            jumpSettings.RotationSpeed = 10;

            // Configure RollSettings
            RollSettings rollSettings = characterMotor.RollSettings;
            rollSettings.CapsuleHeight = 1;
            rollSettings.RotationSpeed = 10;

            // Configure AimSettings
            AimSettings aimSettings = characterMotor.AimSettings;
            aimSettings.MaxAimAngle = 60;
            aimSettings.WalkError = 2.5f;
            aimSettings.RunError = 4;
            aimSettings.SprintError = 6;

            // Configure TurnSettings
            TurnSettings turnSettings = characterMotor.TurnSettings;
            turnSettings.StandingRotationSpeed = 20;
            turnSettings.RunningRotationSpeed = 20;
            turnSettings.MeleeIdleRotationSpeed = 7;
            turnSettings.MeleeAttackRotationSpeed = 10;
            turnSettings.SprintingRotationSpeed = 20;
            turnSettings.GrenadeRotationSpeed = 20;

            // Configure ShoulderSettings
            ShoulderSettings shoulderSettings = characterMotor.ShoulderSettings;
            shoulderSettings.Standing = new Vector3(0, 1.6f, 0);
            shoulderSettings.Crouching = new Vector3(0, 1, 0);

            // Configure HitResponseSettings
            HitResponseSettings hitResponseSettings = characterMotor.HitResponseSettings;
            hitResponseSettings.Wait = 0.5f;
            hitResponseSettings.Strength = 20;

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
            thirdPersonController.AutoTakeCover = true;
            thirdPersonController.CoverEnterDelay = 0.1f;
            thirdPersonController.AlwaysAim = false;
            thirdPersonController.AimWhenWalking = false;
            thirdPersonController.CrouchNearCovers = true;
            thirdPersonController.ImmediateTurns = true;
            thirdPersonController.MeleeRadius = 4;
            thirdPersonController.MinMeleeDistance = 1.5f;
            thirdPersonController.AimSustain = 0.3f;
            thirdPersonController.NoAimSustain = 0.14f;
            thirdPersonController.CancelHurt = true;
            thirdPersonController.ThrowAngleOffset = 30;
            thirdPersonController.MaxThrowAngle = 45;
            thirdPersonController.PostLandAimDelay = 0.4f;
            thirdPersonController.ArmLiftDelay = 1.5f;


            GameObject explosionPreview = (GameObject)Resources.Load("Assets/Prefabs/ThrowExplosionPreview", typeof(GameObject));
            thirdPersonController.ExplosionPreview = explosionPreview;

            GameObject pathPreview = (GameObject)Resources.Load("Assets/Prefabs/GrenadePath", typeof(GameObject));
            thirdPersonController.PathPreview = pathPreview;

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

            thirdPersonInput.FastMovement = true;
            thirdPersonInput.WalkWhenZooming = true;
            thirdPersonInput.CameraOverride = null;
            thirdPersonInput.HorizontalRotateSpeed = 6;
            thirdPersonInput.VerticalRotateSpeed = 2;
            thirdPersonInput.ZoomRotateMultiplier = 1;
            thirdPersonInput.RotateWhenUnlocked = false;
            thirdPersonInput.DoubleTapDelay = 0.3f;
            thirdPersonInput.CustomActions = null;
            thirdPersonInput.Disabler = null;

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

            characterSounds.Footstep = null;
            characterSounds.Death = null;
            characterSounds.Jump = null;
            characterSounds.Land = null;

            AudioClip hit_impact = (AudioClip)Resources.Load("Sounds/IMPACT_Generic_09_Short_mono", typeof(AudioClip));
            characterSounds.Block = new AudioClip[1];
            characterSounds.Block[0] = hit_impact;


            AudioClip gore_stab_01_mono = (AudioClip)Resources.Load("Sounds/GORE_Stab_01_mono", typeof(AudioClip));
            AudioClip gore_stab_02_mono = (AudioClip)Resources.Load("Sounds/GORE_Stab_02_mono", typeof(AudioClip));
            AudioClip gore_stab_03_mono = (AudioClip)Resources.Load("Sounds/GORE_Stab_03_mono", typeof(AudioClip));
            characterSounds.Hit = new AudioClip[3];
            characterSounds.Hit[0] = gore_stab_01_mono;
            characterSounds.Hit[1] = gore_stab_02_mono;
            characterSounds.Hit[2] = gore_stab_03_mono;


            AudioClip gore_splat_hit_bubbles_mono = (AudioClip)Resources.Load("Sounds/GORE_Splat_Hit_Bubbles_mono", typeof(AudioClip));
            AudioClip gore_splat_hit_deep_mono = (AudioClip)Resources.Load("Sounds/GORE_Splat_Hit_Deep_mono", typeof(AudioClip));
            AudioClip gore_splat_hit_short_mono = (AudioClip)Resources.Load("Sounds/GORE_Splat_Hit_Short_mono", typeof(AudioClip));
            characterSounds.BigHit = new AudioClip[3];
            characterSounds.BigHit[0] = gore_splat_hit_bubbles_mono;
            characterSounds.BigHit[1] = gore_splat_hit_deep_mono;
            characterSounds.BigHit[2] = gore_splat_hit_short_mono;

            characterSounds.BigDamageThreshold = 50;


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

            GameObject footsteps_test_1 = (GameObject)Resources.Load("Assets/Prefabs/Footsteps Test 1", typeof(GameObject));
            characterEffects.Step = footsteps_test_1;

            GameObject land = (GameObject)Resources.Load("Assets/Prefabs/Land", typeof(GameObject));
            characterEffects.Land = land;

            GameObject death = (GameObject)Resources.Load("Assets/Prefabs/Death", typeof(GameObject));
            characterEffects.Death = death;

            characterEffects.Resurrection = null;

            GameObject hurt = (GameObject)Resources.Load("Assets/Prefabs/Hurt", typeof(GameObject));
            characterEffects.Hurt = hurt;

            GameObject footsteps_test = (GameObject)Resources.Load("Assets/Prefabs/Footsteps Test", typeof(GameObject));
            characterEffects.Block = footsteps_test;

            GameObject hit = (GameObject)Resources.Load("Assets/Gun/Particles/Blood", typeof(GameObject));
            characterEffects.Hit = hit;

            characterEffects.BigHit = null;
            characterEffects.BigDamageThreshold = 50;


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

            characterAlerts.Step = 10;
            characterAlerts.Hurt = 10;
            characterAlerts.Death = 10;
            characterAlerts.Jump = 10;
            characterAlerts.Land = 10;
            characterAlerts.Resurrect = 10;

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

            characterHealth.Health = 500;
            characterHealth.MaxHealth = 400;
            characterHealth.Regeneration = 15;
            characterHealth.DamageMultiplier = 1;
            characterHealth.IsTakingDamage = true;
            characterHealth.IsRegisteringHits = true;

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

            characterPlatform.Threshold = 0.2f;

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

            // TODO: assign weapon prefabs in generator window 
            characterInventory.Weapons = new WeaponDescription[7];

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

            resetOnDeath.Delay = 3;

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

        public virtual bool CheckCharacterDependencies()
        {
            bool continute_setup = true;
            AlertProgress("Checking Character Dependencies");

            if (character == null)
            {
                AlertProgress("Character prefab unassigned shutting down character generator... I have failed you.");
                continute_setup = false;
                return continute_setup;
            }
            else
            {
                AlertProgress("Character prefab assigned, checking for required scripts");
                continute_setup = SetupRuntimeAnimatorController();
                if (continute_setup == false)
                {
                    return continute_setup;
                }

                continute_setup = SetupRigidBody();
                if (continute_setup == false)
                {
                    return continute_setup;
                }

                continute_setup = SetupCapsuleCollider();
                if (continute_setup == false)
                {
                    return continute_setup;
                }
                continute_setup = SetupActor();
                if (continute_setup == false)
                {
                    return continute_setup;
                }

                continute_setup = SetupCharacterMotor();
                if (continute_setup == false)
                {
                    return continute_setup;
                }

                continute_setup = SetupThirdPersonController();
                if (continute_setup == false)
                {
                    return continute_setup;
                }

                continute_setup = SetupThirdPersonInput();
                if (continute_setup == false)
                {
                    return continute_setup;
                }

                continute_setup = SetupCharacterSounds();
                if (continute_setup == false)
                {
                    return continute_setup;
                }

                continute_setup = SetupCharacterEffects();
                if (continute_setup == false)
                {
                    return continute_setup;
                }

                continute_setup = SetupCharacterAlerts();
                if (continute_setup == false)
                {
                    return continute_setup;
                }

                continute_setup = SetupCharacterHealth();
                if (continute_setup == false)
                {
                    return continute_setup;
                }

                continute_setup = SetupCharacterPlatform();
                if (continute_setup == false)
                {
                    return continute_setup;
                }

                continute_setup = SetupCharacterInventory();
                if (continute_setup == false)
                {
                    return continute_setup;
                }

                continute_setup = SetupResetOnDeath();
                if (continute_setup == false)
                {
                    return continute_setup;
                }

                continute_setup = SetupExitToEscape();
                if (continute_setup == false)
                {
                    return continute_setup;
                }

                continute_setup = SetupCharacterFace();
                if (continute_setup == false)
                {
                    return continute_setup;
                }
            }

            AlertProgress("Check Character Dependencies complete");
            return continute_setup;

        }

        #endregion

        #region Editor GUI

        [MenuItem("CoverShooter/Quick Setup Character")]
        public static void ShowWindow()
        {
            window = EditorWindow.GetWindow<ThirdPersonCharacterGeneratorWindow>("Quick Character Setup");
            window.minSize = new Vector2(400, 428);
            window.maxSize = new Vector2(550, 500);
            window.Show();
        }

        public virtual void OnEnable()
        {
            splashTexture = (Texture2D)Resources.Load("Textures/Third Person Cover Shooter Template - Character Generator", typeof(Texture2D));
        }

        public virtual void OnGUI()
        {
            // setup custom styles
            if (titleStyle == null)
            {
                titleStyle = new GUIStyle(GUI.skin.label);
                titleStyle.fontSize = 20;
                titleStyle.fontStyle = FontStyle.Bold;
                titleStyle.alignment = TextAnchor.MiddleCenter;
            }

            if (subtitleStyle == null)
            {
                subtitleStyle = new GUIStyle(titleStyle);
                subtitleStyle.fontSize = 12;
                subtitleStyle.fontStyle = FontStyle.Italic;
            }

            if (wrapperStyle == null)
            {
                wrapperStyle = new GUIStyle(GUI.skin.box);
                wrapperStyle.normal.textColor = GUI.skin.label.normal.textColor;
                wrapperStyle.padding = new RectOffset(8, 8, 16, 8);
            }

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

            camera = (GameObject)EditorGUILayout.ObjectField("Player Camera", camera, typeof(GameObject), true);
            character = (GameObject)EditorGUILayout.ObjectField("Player Controller", character, typeof(GameObject), true);
            runtimeAnimatorController = (RuntimeAnimatorController)EditorGUILayout.ObjectField("Player Animator", runtimeAnimatorController, typeof(RuntimeAnimatorController), true);
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
                && runtimeAnimatorController != null;
                //&& left_hand != null
                //&& right_hand != null;

            if (GUILayout.Button("Make it quick", GUILayout.Height(50)))
            {
                Utils.ClearLogConsole();
                AlertProgress("Im ready master... Im not ready!!!");

                CheckCharacterDependencies();
                CheckCameraDependencies();

                AlertProgress("Jobs done");

            }
            GUI.enabled = true;

            // -- END WRAPPER --
            EditorGUILayout.EndVertical();


        }

        #endregion
    }
}
