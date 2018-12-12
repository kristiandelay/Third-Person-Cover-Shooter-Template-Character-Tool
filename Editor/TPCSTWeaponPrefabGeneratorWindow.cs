using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace CoverShooter.Tools
{
    public class TPCSTWeaponPrefabGeneratorWindow : TPCSTEditorWindow
    {
        #region Public Variables

        public GameObject weapon_prefab = null;
        public ScriptableWeapon weapon_scriptable;

        static protected TPCSTWeaponPrefabGeneratorWindow window;

        #endregion


        #region Weapon Management

        public virtual void SetupBoxCollider()
        {
            BoxCollider boxCollider = weapon_prefab.GetComponent<BoxCollider>();

            if (boxCollider == null)
            {
                boxCollider = weapon_prefab.AddComponent<BoxCollider>();
            }
        }

        public virtual void SetupGunScript()
        {
            Gun gun = weapon_prefab.GetComponent<Gun>();
            WeaponStats weapon_stats = weapon_scriptable.weapon_stats;

            if (gun == null)
            {
                gun = weapon_prefab.AddComponent<Gun>();
            }

            gun.Type = weapon_stats.Type;
            gun.Name = weapon_stats.Name;
            gun.Zoom = weapon_stats.Zoom;
            gun.Scope = weapon_stats.Scope;
            gun.Rate = weapon_stats.Rate;
            gun.BulletsPerShot = weapon_stats.BulletsPerShot;
            gun.ConsumeSingleBulletPerShot = weapon_stats.ConsumeSingleBulletPerShot;
            gun.Distance = weapon_stats.Distance;
            gun.Damage = weapon_stats.Damage;
            gun.Error = weapon_stats.Error;
            gun.AutoReload = weapon_stats.AutoReload;
            gun.CanInterruptBulletLoad = weapon_stats.CanInterruptBulletLoad;
            gun.PumpAfterFinalLoad = weapon_stats.PumpAfterFinalLoad;
            gun.PumpAfterBulletLoad = weapon_stats.PumpAfterBulletLoad;
            gun.PumpAfterFire = weapon_stats.PumpAfterFire;
            gun.FireOnMobileAim = weapon_stats.FireOnMobileAim;
            gun.LaserOnlyOnZoom = weapon_stats.LaserOnlyOnZoom;
            gun.DebugAim = weapon_stats.DebugAim;

            Transform aim = weapon_prefab.transform.Find(StaticStrings.aim_transform_key);
            gun.Aim = aim.gameObject;

            gun.Bullet = weapon_stats.Bullet;

            Transform left_hand_default = weapon_prefab.transform.Find(StaticStrings.aim_left_hand_transform_key);
            gun.LeftHandDefault = left_hand_default;

            gun.UseCustomCrosshair = weapon_stats.UseCustomCrosshair;
            gun.CustomCrosshair = weapon_stats.CustomCrosshair;
            gun.Recoil = weapon_stats.Recoil;

            Transform tall_cover_left = weapon_prefab.transform.Find(StaticStrings.tall_cover_left_transform_key);
            gun.LeftHandOverwrite.TallCover = tall_cover_left;

            Transform low_cover_left = weapon_prefab.transform.Find(StaticStrings.low_cover_left_transform_key);
            gun.LeftHandOverwrite.LowCover = low_cover_left;

            gun.MagazineSize = weapon_stats.MagazineSize;
            gun.LoadedBullets = weapon_stats.LoadedBullets;
            gun.BulletInventory = weapon_stats.BulletInventory;
        }

        public virtual void SetupGunEffects()
        {
            GunEffects gun_effects = weapon_prefab.GetComponent<GunEffects>();
            WeaponEffects weapon_effects = weapon_scriptable.weapon_effects;
            if (gun_effects == null)
            {
                gun_effects = weapon_prefab.AddComponent<GunEffects>();
            }
            gun_effects.Eject = weapon_effects.Eject;
            gun_effects.Rechamber = weapon_effects.Rechamber;
            gun_effects.Fire = weapon_effects.Fire;
            gun_effects.Pump = weapon_effects.Pump;
            gun_effects.EmptyFire = weapon_effects.EmptyFire;
            gun_effects.Shell = weapon_effects.Shell;
        }

        public virtual void SetupMelee()
        {
            Melee melee = weapon_prefab.GetComponent<Melee>();
            MeleeStats melee_stats = weapon_scriptable.melee_stats;
            if (melee == null)
            {
                melee = weapon_prefab.AddComponent<Melee>();
            }
            melee.Type = melee_stats.Type;
            melee.Damage = melee_stats.Damage;
            melee.Cooldown = melee_stats.Cooldown;
            melee.DamageResponseWaitTime = melee_stats.DamageResponseWaitTime;
        }

        public virtual void SetupGunSounds()
        {
            GunSounds gun_sounds = weapon_prefab.GetComponent<GunSounds>();
            WeaponSounds weapon_sounds = weapon_scriptable.weapon_sounds;
            if(gun_sounds == null)
            {
                gun_sounds = weapon_prefab.AddComponent<GunSounds>();
            }
            gun_sounds.Eject = weapon_sounds.Eject;
            gun_sounds.Rechamber = weapon_sounds.Rechamber;
            gun_sounds.Pump = weapon_sounds.Pump;
            gun_sounds.Fire = weapon_sounds.Fire;
            gun_sounds.EmptyFire = weapon_sounds.EmptyFire;
        }

        public virtual void SetupGunAlerts()
        {
            GunAlerts gun_alerts = weapon_prefab.GetComponent<GunAlerts>();
            WeaponAlerts weapon_alerts = weapon_scriptable.weapon_alerts;
            if (gun_alerts == null)
            {
                gun_alerts = weapon_prefab.AddComponent<GunAlerts>();
            }
            gun_alerts.Fire = weapon_alerts.Fire;
            gun_alerts.EmptyFire = weapon_alerts.EmptyFire;
            gun_alerts.Reload = weapon_alerts.Reload;
        }

        protected virtual void SetupWeaponFromScriptable()
        {
            if(weapon_scriptable == false)
            {
                return;
            }

            SetupBoxCollider();
            SetupGunScript();
            SetupGunEffects();
            SetupMelee();
            SetupGunSounds();
            SetupGunAlerts();
        }


        public virtual bool CreateWeaponPrefab()
        {
            bool continue_setup = true;

            if (weapon_prefab == false)
            {
                continue_setup = false;
                return continue_setup;
            }

            CreateObjectAtTransform(weapon_prefab, StaticStrings.aim_transform_key);
            CreateObjectAtTransform(weapon_prefab, StaticStrings.aim_left_hand_transform_key);
            CreateObjectAtTransform(weapon_prefab, StaticStrings.model_transform_key);
            CreateObjectAtTransform(weapon_prefab, StaticStrings.tall_cover_left_transform_key);
            CreateObjectAtTransform(weapon_prefab, StaticStrings.tall_cover_right_transform_key);
            CreateObjectAtTransform(weapon_prefab, StaticStrings.low_cover_left_transform_key);
            CreateObjectAtTransform(weapon_prefab, StaticStrings.low_cover_right_transform_key);

            // TODO save generated prefab 
            // Needs fix: Not saving with attached scripts
            //GameObject prefab = PrefabUtility.CreatePrefab("Assets/Third-Person-Cover-Shooter-Template-Character-Tool/Resources/Prefabs/" + weapon_prefab.name + ".prefab", (GameObject)weapon_prefab, ReplacePrefabOptions.ReplaceNameBased);



            return true;
        }

        #endregion

        #region Editor GUI

        [MenuItem("CoverShooter/Generators/Create Weapon Prefab")]
        public static void ShowWindow()
        {
            window = EditorWindow.GetWindow<TPCSTWeaponPrefabGeneratorWindow>("Create Weapon Prefab");
            window.minSize = new Vector2(400, 300);
            window.maxSize = new Vector2(400, 300);
            window.Show();
        }

        public virtual void OnEnable()
        {
            splashTexture = (Texture2D)Resources.Load("Textures/Third Person Cover Shooter Template - Weapon Generator", typeof(Texture2D));
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

            weapon_prefab = (GameObject)EditorGUILayout.ObjectField("Weapon Prefab", weapon_prefab, typeof(GameObject), true);
            weapon_scriptable = (ScriptableWeapon)EditorGUILayout.ObjectField("Weapon Script", weapon_scriptable, typeof(ScriptableWeapon), true);

            EditorGUILayout.Separator();

            GUI.enabled = true;

            GUI.enabled = weapon_prefab != null
                && weapon_scriptable != null;

            if (GUILayout.Button("Make it quick", GUILayout.Height(50)))
            {
                Utils.ClearLogConsole();
                AlertProgress("Im ready master... Im not ready!!!");

                CreateWeaponPrefab();
                SetupWeaponFromScriptable();

                AlertProgress("Jobs done");

            }
            GUI.enabled = true;

            // -- END WRAPPER --
            EditorGUILayout.EndVertical();


        }

        #endregion


    }
}