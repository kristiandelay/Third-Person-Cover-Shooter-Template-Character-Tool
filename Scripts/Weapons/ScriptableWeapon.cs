using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CoverShooter.Tools
{
    [CreateAssetMenu(menuName = "CoverShooter/Weapons/Weapon", order = 0)]
    public class ScriptableWeapon : ScriptableObject
    {
        public WeaponStats weapon_stats;
        public WeaponEffects weapon_effects;
        public MeleeStats melee_stats;
        public WeaponSounds weapon_sounds;
        public WeaponAlerts weapon_alerts;
    }
}
