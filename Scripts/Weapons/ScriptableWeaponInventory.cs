using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace CoverShooter.Tools
{
    [Serializable]
    public struct WeaponInfo
    {
        public bool add_left_hand;
        public bool add_right_hand;
        public GameObject weapon_object;
    }

    [CreateAssetMenu(menuName = "CoverShooter/Inventory", order = 0)]
    public class ScriptableWeaponInventory : ScriptableObject
    {
        public List<WeaponInfo> weapons = new List<WeaponInfo>();
    }
}