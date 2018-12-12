using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CoverShooter.Tools
{
    [System.Serializable]
    public class WeaponEffects 
    {
        #region Public fields

        /// <summary>
        /// Object to instantiate when ejecting a magazine.
        /// </summary>
        [Tooltip("Object to instantiate when ejecting a magazine.")]
        public GameObject Eject;

        /// <summary>
        /// Object to instantiate when a magazine is put inside the gun.
        /// </summary>
        [Tooltip("Object to instantiate when a magazine is put inside the gun.")]
        public GameObject Rechamber;

        /// <summary>
        /// Object to instantiate on each bullet fire.
        /// </summary>
        [Tooltip("Object to instantiate on each bullet fire.")]
        public GameObject Fire;

        /// <summary>
        /// Object to instantiate on each shotgun pump.
        /// </summary>
        [Tooltip("Object to instantiate on each shotgun pump.")]
        public GameObject Pump;

        /// <summary>
        /// Object to instantiate on each fire attempt with an empty magazine.
        /// </summary>
        [Tooltip("Object to instantiate on each fire attempt with an empty magazine.")]
        public GameObject EmptyFire;

        /// <summary>
        /// Object to instantiate to simulate shell ejection.
        /// </summary>
        [Tooltip("Object to instantiate to simulate shell ejection.")]
        public GameObject Shell;

        #endregion
    }
}