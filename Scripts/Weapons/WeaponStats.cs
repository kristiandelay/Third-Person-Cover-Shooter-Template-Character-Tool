using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverShooter.Tools
{

    [System.Serializable]
    public class WeaponStats
    {
        #region Public fields

        /// <summary>
        /// Animations and related assets to be used with this weapon.
        /// </summary>
        [Tooltip("Animations and related assets to be used with this weapon.")]
        public WeaponType Type = WeaponType.Pistol;

        /// <summary>
        /// Name of the gun to be display on the HUD.
        /// </summary>
        [Tooltip("Name of the gun to be display on the HUD.")]
        public string Name = "Gun";

        /// <summary>
        /// How many degrees should the camera FOV be reduced when using scope on the gun.
        /// </summary>
        [Tooltip("How many degrees should the camera FOV be reduced when using scope on the gun.")]
        public float Zoom = 30;

        /// <summary>
        /// Sprite that's displayed when zooming in.
        /// </summary>
        [Tooltip("Sprite that's displayed when zooming in.")]
        public Sprite Scope;

        /// <summary>
        /// Rate of fire in shots per second.
        /// </summary>
        [Tooltip("Rate of fire in shots per second.")]
        [Range(0, 1000)]
        public float Rate = 7;

        /// <summary>
        /// Bullets fired per single shot.
        /// </summary>
        [Tooltip("Bullets fired per single shot.")]
        public int BulletsPerShot = 1;

        /// <summary>
        /// If firing multiple bullets per shot, should only a single bullet be removed from the inventory.
        /// </summary>
        [Tooltip("If firing multiple bullets per shot, should only a single bullet be removed from the inventory.")]
        public bool ConsumeSingleBulletPerShot = true;

        /// <summary>
        /// Maximum distance of a bullet hit. Objects further than this value are ignored.
        /// </summary>
        [Tooltip("Maximum distance of a bullet hit. Objects further than this value are ignored.")]
        public float Distance = 50;

        /// <summary>
        /// Damage dealt by a single bullet.
        /// </summary>
        [Tooltip("Damage dealt by a single bullet.")]
        [Range(0, 1000)]
        public float Damage = 10;

        /// <summary>
        /// Maximum degrees of error the gun can make when firing.
        /// </summary>
        [Tooltip("Maximum degrees of error the gun can make when firing.")]
        public float Error = 0;

        /// <summary>
        /// Should the gun be reloaded automatically when the magazine is empty.
        /// </summary>
        [Tooltip("Should the gun be reloaded automatically when the magazine is empty.")]
        public bool AutoReload = false;

        /// <summary>
        /// Is the gun reloaded with whole magazines or bullet by bullet.
        /// </summary>
        [Tooltip("Is the gun reloaded with whole magazines or bullet by bullet.")]
        public bool ReloadWithMagazines = true;

        /// <summary>
        /// If reloading bullet by bullet, can the gun be fired during reload.
        /// </summary>
        [Tooltip("If reloading bullet by bullet, can the gun be fired during reload.")]
        public bool CanInterruptBulletLoad = true;

        /// <summary>
        /// After a new magazine or the last bullet is loaded, should the gun be pumped.
        /// </summary>
        [Tooltip("After a new magazine or the last bullet is loaded, should the gun be pumped.")]
        public bool PumpAfterFinalLoad = false;

        /// <summary>
        /// Should the gun be pumped after each bullet load.
        /// </summary>
        [Tooltip("Should the gun be pumped after each bullet load.")]
        public bool PumpAfterBulletLoad = false;

        /// <summary>
        /// Should the gun be pumped after firing a shot.
        /// </summary>
        [Tooltip("Should the gun be pumped after firing a shot.")]
        public bool PumpAfterFire = false;

        /// <summary>
        /// Will the character fire by just aiming the mobile controller.
        /// </summary>
        [Tooltip("Will the character fire by just aiming the mobile controller.")]
        public bool FireOnMobileAim = true;

        /// <summary>
        /// Should the laser be visible only when zooming.
        /// </summary>
        [Tooltip("Should the laser be visible only when zooming.")]
        public bool LaserOnlyOnZoom = true;

        /// <summary>
        /// Should a debug ray be displayed.
        /// </summary>
        [Tooltip("Should a debug ray be displayed.")]
        public bool DebugAim = false;

          /// <summary>
        /// Object to be instantiated as a bullet.
        /// </summary>
        [Tooltip("Object to be instantiated as a bullet.")]
        public GameObject Bullet;

        /// <summary>
        /// Time in seconds between hits that the target character will respond to with hurt animations.
        /// </summary>
        [Tooltip("Time in seconds between hits that the target character will respond to with hurt animations.")]
        public float DamageResponseWaitTime = 1;

        /// <summary>
        /// Should the gun's crosshair be used instead of the one set in the Crosshair component.
        /// </summary>
        [Tooltip("Should the gun's crosshair be used instead of the one set in the Crosshair component.")]
        public bool UseCustomCrosshair;

        /// <summary>
        /// Custom crosshair settings to override the ones set in the Crosshair component. Used only if UseCustomCrosshair is enabled.
        /// </summary>
        [Tooltip("Custom crosshair settings to override the ones set in the Crosshair component. Used only if UseCustomCrosshair is enabled.")]
        public CrosshairSettings CustomCrosshair = CrosshairSettings.Default();

        /// <summary>
        /// Settings that manage gun's recoil behaviour.
        /// </summary>
        [Tooltip("Settings that manage gun's recoil behaviour.")]
        public GunRecoilSettings Recoil = GunRecoilSettings.Default();

        /// <summary>
        /// Force the pistol to use this laser instead of finding one on its own.
        /// </summary>
        [Tooltip("Force the pistol to use this laser instead of finding one on its own.")]
        public Laser LaserOverwrite;

        /// <summary>
        /// Owning object with a CharacterMotor component.
        /// </summary>
        [HideInInspector]
        public CharacterMotor Character;

        /// <summary>
        /// Number of bullets stored at max in the weapon.
        /// </summary>
        [Tooltip("Number of bullets stored at max in the weapon.")]
        public int MagazineSize = 10;

        /// <summary>
        /// Current number of loaded bullets.
        /// </summary>
        [Tooltip("Current number of loaded bullets.")]
        public int LoadedBullets = 10;

        /// <summary>
        /// Number of bullets that are available to be loaded, not counting the already loaded ones.
        /// </summary>
        [Tooltip("Number of bullets that are available to be loaded, not counting the already loaded ones.")]
        public int BulletInventory = 10000;

        #endregion
    }

}