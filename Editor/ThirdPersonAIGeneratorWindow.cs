using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine.AI;

namespace CoverShooter.Tools
{
    public class ThirdPersonAIGeneratorWindow : TPCSTEditorWindow
    {
        #region Public Variables

        public GameObject ai_prefab;
        public ScriptableAI ai_scriptable;

        static protected ThirdPersonAIGeneratorWindow window;

        #endregion


        #region AI Scripts
        public virtual void DisablePlayerControlledScripts()
        {
            CoverShooter.ThirdPersonInput thirdPersonInput = ai_prefab.GetComponent<CoverShooter.ThirdPersonInput>();
            if(thirdPersonInput)
            {
                thirdPersonInput.enabled = false;
            }
            CoverShooter.ExitToEscape exitToEscape = ai_prefab.GetComponent<CoverShooter.ExitToEscape>();
            if (exitToEscape)
            {
                exitToEscape.enabled = false;
            }
            CoverShooter.ResetOnDeath resetOnDeath = ai_prefab.GetComponent<CoverShooter.ResetOnDeath>();
            if (resetOnDeath)
            {
                resetOnDeath.enabled = false;
                Destroy(ai_prefab.GetComponent<CoverShooter.ResetOnDeath>());
            }


        }

        public virtual void SetupChracterName()
        {
            CoverShooter.CharacterName characterName = ai_prefab.GetComponent<CoverShooter.CharacterName>();
            if (characterName == null)
            {
                characterName = ai_prefab.AddComponent<CoverShooter.CharacterName>();
            }
            CoverShooter.Tools.CharacterName character_name = ai_scriptable.characterName;
            characterName.name = character_name.Name;
        }

        public virtual void SetupHitEffect()
        {
            CoverShooter.HitEffect hitEffect = ai_prefab.GetComponent<CoverShooter.HitEffect>();
            if (hitEffect == null)
            {
                hitEffect = ai_prefab.AddComponent<CoverShooter.HitEffect>();
            }
            CoverShooter.Tools.HitEffect hit_effect = ai_scriptable.hitEffect;
            hitEffect.Bullet = hit_effect.Bullet;
            hitEffect.Melee = hit_effect.Melee;
            hitEffect.DestroyAfter = hit_effect.DestroyAfter;
        }

        public virtual void SetupNavMeshObstacle()
        {
            UnityEngine.AI.NavMeshObstacle navMeshObstacle = ai_prefab.GetComponent<UnityEngine.AI.NavMeshObstacle>();
            if (navMeshObstacle == null)
            {
                navMeshObstacle = ai_prefab.AddComponent<UnityEngine.AI.NavMeshObstacle>();
            }
            CoverShooter.Tools.NavMeshObstacle nav_MeshObstacle = ai_scriptable.navMeshObstacle;
            navMeshObstacle.shape = nav_MeshObstacle.shape;
            navMeshObstacle.center = nav_MeshObstacle.center;
            navMeshObstacle.radius = nav_MeshObstacle.radius;
            navMeshObstacle.carving = nav_MeshObstacle.carve;
            navMeshObstacle.carvingMoveThreshold = nav_MeshObstacle.move_threshold;
            navMeshObstacle.carvingTimeToStationary = nav_MeshObstacle.time_to_stationary;
            navMeshObstacle.carveOnlyStationary = nav_MeshObstacle.carve_only_station;
        }

        public virtual void SetupAIMovement()
        {
            CoverShooter.AIMovement aiMovement = ai_prefab.GetComponent<CoverShooter.AIMovement>();
            if (aiMovement == null)
            {
                aiMovement = ai_prefab.AddComponent<CoverShooter.AIMovement>();
            }
            CoverShooter.Tools.AIMovement ai_movement = ai_scriptable.aiMovement;
            aiMovement.RollTriggerDistance = ai_movement.RollTriggerDistance;
            aiMovement.CircleDelay = ai_movement.CircleDelay;
            aiMovement.ObstructionRadius = ai_movement.ObstructionRadius;
            aiMovement.DebugDestination = ai_movement.DebugDestination;
            aiMovement.DebugPath = ai_movement.DebugPath;
        }

        public virtual void SetupFigherBrain()
        {
            CoverShooter.FighterBrain fighterBrain = ai_prefab.GetComponent<CoverShooter.FighterBrain>();
            if (fighterBrain == null)
            {
                fighterBrain = ai_prefab.AddComponent<CoverShooter.FighterBrain>();
            }
            CoverShooter.Tools.FighterBrain fighter_brain = ai_scriptable.fighterBrain;
            fighterBrain.AvoidDistance = fighter_brain.AvoidDistance;
            fighterBrain.AllySpacing = fighter_brain.AllySpacing;
            fighterBrain.StandDuration = fighter_brain.StandDuration;
            fighterBrain.CircleDuration = fighter_brain.CircleDuration;
            fighterBrain.CoverSwitchWait = fighter_brain.CoverSwitchWait;
            fighterBrain.GuessDistance = fighter_brain.GuessDistance;
            fighterBrain.TakeCoverImmediatelyChance = fighter_brain.TakeCoverImmediatelyChance;
            fighterBrain.ImmediateThreatReaction = fighter_brain.ImmediateThreatReaction;
            fighterBrain.AttackAggressors = fighter_brain.AttackAggressors;
            fighterBrain.Start = fighter_brain.Start;
            fighterBrain.Speed = fighter_brain.Speed;
            fighterBrain.Approximation = fighter_brain.Approximation;
            fighterBrain.Retreat = fighter_brain.Retreat;
            fighterBrain.Investigation = fighter_brain.Investigation;
            fighterBrain.GrenadeAvoidance = fighter_brain.GrenadeAvoidance;
            fighterBrain.Grenades = fighter_brain.Grenades;
            fighterBrain.DebugThreat = fighter_brain.DebugThreat;
        }

        public virtual void SetupAIFire()
        {
            CoverShooter.AIFire aiFire = ai_prefab.GetComponent<CoverShooter.AIFire>();
            if (aiFire == null)
            {
                aiFire = ai_prefab.AddComponent<CoverShooter.AIFire>();
            }
            CoverShooter.Tools.AIFire ai_fire = ai_scriptable.aiFire;
            aiFire.InventoryUsage = ai_fire.InventoryUsage;
            aiFire.InventoryIndex = ai_fire.InventoryIndex;
            aiFire.AutoFindType = ai_fire.AutoFindType;
            aiFire.AlwaysAim = ai_fire.AlwaysAim;
            aiFire.Bursts = ai_fire.Bursts;
            aiFire.CoverBursts = ai_fire.CoverBursts;

        }

        public virtual void SetupAICover()
        {
            CoverShooter.AICover aiCover = ai_prefab.GetComponent<CoverShooter.AICover>();
            if (aiCover == null)
            {
                aiCover = ai_prefab.AddComponent<CoverShooter.AICover>();
            }
            CoverShooter.Tools.AICover ai_cover = ai_scriptable.aiCover;
            aiCover.MaxLowCoverThreatAngle = ai_cover.MaxLowCoverThreatAngle;
            aiCover.MaxTallCoverThreatAngle = ai_cover.MaxTallCoverThreatAngle;
            aiCover.MaxDefenseAngle = ai_cover.MaxDefenseAngle;
            aiCover.MinDefenselessDistance = ai_cover.MinDefenselessDistance;
            aiCover.MaxCoverDistance = ai_cover.MaxCoverDistance;
            aiCover.MinSwitchDistance = ai_cover.MinSwitchDistance;
            aiCover.AvoidDistance = ai_cover.AvoidDistance;

        }

        public virtual void SetupAISearch()
        {
            CoverShooter.AISearch aiSearch = ai_prefab.GetComponent<CoverShooter.AISearch>();
            if (aiSearch == null)
            {
                aiSearch = ai_prefab.AddComponent<CoverShooter.AISearch>();
            }
            CoverShooter.Tools.AISearch ai_search = ai_scriptable.aiSearch;
            aiSearch.VerifyHeight = ai_search.VerifyHeight;
            aiSearch.FieldOfView = ai_search.FieldOfView;
            aiSearch.WalkDistance = ai_search.WalkDistance;
            aiSearch.DebugTarget = ai_search.DebugTarget;
            aiSearch.DebugPoints = ai_search.DebugPoints;

        }

        public virtual void SetupAICommunication()
        {
            CoverShooter.AICommunication aiCommunication = ai_prefab.GetComponent<CoverShooter.AICommunication>();
            if (aiCommunication == null)
            {
                aiCommunication = ai_prefab.AddComponent<CoverShooter.AICommunication>();
            }
            CoverShooter.Tools.AICommunication ai_communication = ai_scriptable.aiCommunication;
            aiCommunication.Distance = ai_communication.Distance;
            aiCommunication.UpdateDelay = ai_communication.UpdateDelay;
            aiCommunication.DebugFriends = ai_communication.DebugFriends;
        }

        public virtual void SetupAISight()
        {
            CoverShooter.AISight aiSight = ai_prefab.GetComponent<CoverShooter.AISight>();
            if (aiSight == null)
            {
                aiSight = ai_prefab.AddComponent<CoverShooter.AISight>();
            }
            CoverShooter.Tools.AISight ai_sight = ai_scriptable.aiSight;
            aiSight.Distance = ai_sight.Distance;
            aiSight.ObstacleIgnoreDistance = ai_sight.ObstacleIgnoreDistance;
            aiSight.FieldOfView = ai_sight.FieldOfView;
            aiSight.UpdateDelay = ai_sight.UpdateDelay;
            aiSight.DebugFOV= ai_sight.DebugFOV;
        }

        public virtual void SetupAIAim()
        {
            CoverShooter.AIAim aiAim = ai_prefab.GetComponent<CoverShooter.AIAim>();
            if (aiAim == null)
            {
                aiAim = ai_prefab.AddComponent<CoverShooter.AIAim>();
            }
            CoverShooter.Tools.AIAim ai_aim = ai_scriptable.aiAim;
            aiAim.Speed = ai_aim.Speed;
            aiAim.SlowSpeed = ai_aim.SlowSpeed;
            aiAim.MinScanDuration = ai_aim.MinScanDuration;
            aiAim.MaxScanDuration = ai_aim.MaxScanDuration;
            aiAim.MinScanDistance = ai_aim.MinScanDistance;
            aiAim.MaxSweepDuration = ai_aim.MaxSweepDuration;
            aiAim.SweepFOV = ai_aim.SweepFOV;
            aiAim.AccuracyError= ai_aim.AccuracyError;
            aiAim.Target = ai_aim.Target;
            aiAim.DebugAim = ai_aim.DebugAim;
        }

        public virtual void SetupAIListener()
        {
            CoverShooter.AIListener aiListener = ai_prefab.GetComponent<CoverShooter.AIListener>();
            if (aiListener == null)
            {
                aiListener = ai_prefab.AddComponent<CoverShooter.AIListener>();
            }
            CoverShooter.Tools.AIListener ai_listener = ai_scriptable.aiListener;
            aiListener.Hearing = ai_listener.Hearing;
        }

        public virtual void SetupAIRadio()
        {
            CoverShooter.AIRadio aiRadio = ai_prefab.GetComponent<CoverShooter.AIRadio>();
            if (aiRadio == null)
            {
                aiRadio = ai_prefab.AddComponent<CoverShooter.AIRadio>();
            }
            CoverShooter.Tools.AIRadio ai_radio = ai_scriptable.aiRadio;
            aiRadio.InventoryUsage = ai_radio.InventoryUsage;
            aiRadio.InventoryIndex = ai_radio.InventoryIndex;
        }

        public virtual void SetupAIInvestigate()
        {
            CoverShooter.AIInvestigation aiInvestigation = ai_prefab.GetComponent<CoverShooter.AIInvestigation>();
            if (aiInvestigation == null)
            {
                aiInvestigation = ai_prefab.AddComponent<CoverShooter.AIInvestigation>();
            }
            CoverShooter.Tools.AIInvestigation ai_investigation = ai_scriptable.aiInvestigation;
            aiInvestigation.VerifyDistance = ai_investigation.VerifyDistance;
            aiInvestigation.VerifyHeight = ai_investigation.VerifyHeight;
            aiInvestigation.FieldOfView = ai_investigation.FieldOfView;
            aiInvestigation.CoverOffset = ai_investigation.CoverOffset;
        }

        public virtual void SetupAIForget()
        {
            CoverShooter.AIForget aiForget = ai_prefab.GetComponent<CoverShooter.AIForget>();
            if (aiForget == null)
            {
                aiForget = ai_prefab.AddComponent<CoverShooter.AIForget>();
            }
            CoverShooter.Tools.AIForget ai_forget = ai_scriptable.aiForget;
            aiForget.Duration = ai_forget.Duration;
        }

        public virtual void SetupAIWaypoints()
        {
            if(ai_scriptable.addWaypoints)
            {
                CoverShooter.AIWaypoints aiWaypoints = ai_prefab.GetComponent<CoverShooter.AIWaypoints>();
                if (aiWaypoints == null)
                {
                    aiWaypoints = ai_prefab.AddComponent<CoverShooter.AIWaypoints>();
                }
            }
        }

        public virtual void SetupAI()
        {
            if(ai_prefab == null || ai_scriptable == null)
            {
                return;
            }

            // TODO: Validate all require components are initalized 
            CapsuleCollider capsuleCollider = ai_prefab.GetComponent<CapsuleCollider>();
            if (capsuleCollider == null)
            {
                return;
            }

            SetupChracterName();
            SetupHitEffect();
            SetupNavMeshObstacle();
            SetupAIMovement();
            SetupFigherBrain();
            SetupAIFire();
            SetupAICover();
            SetupAISearch();
            SetupAICommunication();
            SetupAISight();
            SetupAIAim();
            SetupAIListener();
            SetupAIRadio();
            SetupAIInvestigate();
            SetupAIForget();
            SetupAIWaypoints();
            DisablePlayerControlledScripts();
        }
        #endregion

        #region Editor GUI

        [MenuItem("CoverShooter/Generators/Create AI Actor")]
        public static void ShowWindow()
        {
            window = EditorWindow.GetWindow<ThirdPersonAIGeneratorWindow>("Create AI Prefab");
            window.minSize = new Vector2(400, 300);
            window.maxSize = new Vector2(400, 300);
            window.Show();
        }

        public virtual void OnEnable()
        {
            splashTexture = (Texture2D)Resources.Load("Textures/Third Person Cover Shooter Template - AI Generator", typeof(Texture2D));
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

            ai_prefab = (GameObject)EditorGUILayout.ObjectField("AI Prefab", ai_prefab, typeof(GameObject), true);
            ai_scriptable = (ScriptableAI)EditorGUILayout.ObjectField("AI Script", ai_scriptable, typeof(ScriptableAI), true);

            EditorGUILayout.Separator();

            GUI.enabled = true;

            GUI.enabled = ai_prefab != null
                && ai_scriptable != null;

            if (GUILayout.Button("Make it quick", GUILayout.Height(50)))
            {
                Utils.ClearLogConsole();
                AlertProgress("Im ready master... Im not ready!!!");

                SetupAI();

                AlertProgress("Jobs done");

            }
            GUI.enabled = true;

            // -- END WRAPPER --
            EditorGUILayout.EndVertical();


        }

        #endregion

    }
}
