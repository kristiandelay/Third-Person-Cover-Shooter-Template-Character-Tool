using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine.AI;
using System;
using System.Runtime.CompilerServices;
using UnityEngine.Internal;

namespace CoverShooter.Tools
{
    public class ThirdPersonWeaponInventoryGeneratorWindow : TPCSTEditorWindow
    {
        #region Public Variables

        public GameObject character_prefab;
        public Transform left_hand_weapon_holder;
        public Transform right_hand_weapon_holder;
        public ScriptableWeaponInventory scriptableWeaponInventory;

        static protected ThirdPersonWeaponInventoryGeneratorWindow window;

        #endregion

        public static void DestroyChildren(Transform transform)
        {
            for (int i = transform.childCount - 1; i >= 0; --i)
            {
                GameObject.Destroy(transform.GetChild(i).gameObject);
            }
            transform.DetachChildren();
        }

        public void SetupInventory()
        {
            if(character_prefab == null 
                || left_hand_weapon_holder == null
                || right_hand_weapon_holder == null
                || scriptableWeaponInventory == null)
            {
                return;
            }

            CharacterInventory characterInventory = character_prefab.GetComponent<CharacterInventory>();
            if(characterInventory == null)
            {
                return;
            }

            characterInventory.Weapons = new WeaponDescription[scriptableWeaponInventory.weapons.Count];

            for (int i = 0; i < scriptableWeaponInventory.weapons.Count; i++)
            {
                WeaponInfo current_weapon = scriptableWeaponInventory.weapons[i];
                if (current_weapon.add_left_hand)
                {
                    Transform found_weapon = left_hand_weapon_holder.Find(current_weapon.weapon_object.name);
                    // check to see if weapon with same name exist already
                    if (found_weapon)
                    {
                        characterInventory.Weapons[i].LeftItem = found_weapon.gameObject;
                    }
                    else
                    {
                        // Attach weapon to hand
                        var new_weapon = Instantiate(current_weapon.weapon_object, left_hand_weapon_holder.position, Quaternion.identity);
                        new_weapon.transform.parent = left_hand_weapon_holder;
                        new_weapon.name = current_weapon.weapon_object.name;

                        // assign to script
                        characterInventory.Weapons[i].LeftItem = new_weapon;
                    }

                }

                current_weapon = scriptableWeaponInventory.weapons[i];
                if (current_weapon.add_right_hand)
                {
                    Transform found_weapon = right_hand_weapon_holder.Find(current_weapon.weapon_object.name);

                    // check to see if weapon with same name exist already
                    if (found_weapon)
                    {
                        characterInventory.Weapons[i].RightItem = found_weapon.gameObject;
                    }
                    else
                    {
                        // Attach weapon to hand
                        var right_weapon = Instantiate(current_weapon.weapon_object, right_hand_weapon_holder.position, Quaternion.identity);
                        right_weapon.transform.parent = right_hand_weapon_holder;
                        right_weapon.name = current_weapon.weapon_object.name;

                        // assign to script
                        characterInventory.Weapons[i].RightItem = right_weapon;
                    }

                }

            }
        }

        #region Editor GUI

        [MenuItem("CoverShooter/Generators/Assign Weapon Inventory")]
        public static void ShowWindow()
        {
            window = EditorWindow.GetWindow<ThirdPersonWeaponInventoryGeneratorWindow>("Assign Inventory");
            window.minSize = new Vector2(400, 300);
            window.maxSize = new Vector2(400, 300);
            window.Show();
        }

        public virtual void OnEnable()
        {
            splashTexture = (Texture2D)Resources.Load("Textures/Third Person Cover Shooter Template - Weapon Inventory Generator", typeof(Texture2D));
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

            character_prefab = (GameObject)EditorGUILayout.ObjectField("Character Prefab", character_prefab, typeof(GameObject), true);
            left_hand_weapon_holder = (Transform)EditorGUILayout.ObjectField("Left Weapon Holder", left_hand_weapon_holder, typeof(Transform), true);
            right_hand_weapon_holder = (Transform)EditorGUILayout.ObjectField("Right Weapon Holder", right_hand_weapon_holder, typeof(Transform), true);
            scriptableWeaponInventory = (ScriptableWeaponInventory)EditorGUILayout.ObjectField("Weapon Inventory", scriptableWeaponInventory, typeof(ScriptableWeaponInventory), true);

            EditorGUILayout.Separator();

            GUI.enabled = true;

            GUI.enabled = character_prefab != null
                && left_hand_weapon_holder != null
                && right_hand_weapon_holder != null
                && scriptableWeaponInventory != null;

            if (GUILayout.Button("Make it quick", GUILayout.Height(50)))
            {
                Utils.ClearLogConsole();
                AlertProgress("Im ready master... Im not ready!!!");

                SetupInventory();

                AlertProgress("Jobs done");

            }
            GUI.enabled = true;

            // -- END WRAPPER --
            EditorGUILayout.EndVertical();


        }

        #endregion
    }
}
