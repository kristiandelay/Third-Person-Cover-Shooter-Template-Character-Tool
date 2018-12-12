using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace CoverShooter.Tools
{
    [System.Serializable]
    public class HitEffect
    {
        #region Public fields

        /// <summary>
        /// Effect to be instantiated on the point of bullet impact.
        /// </summary>
        [Tooltip("Effect to be instantiated on the point of bullet impact.")]
        [FormerlySerializedAs("Effect")]
        public GameObject Bullet;

        /// <summary>
        /// Effect to be instantiated on the point of melee impact.
        /// </summary>
        [Tooltip("Effect to be instantiated on the point of melee impact.")]
        public GameObject Melee;

        /// <summary>
        /// Time to wait before destroying an instantiated effect object.
        /// </summary>
        [Tooltip("Time to wait before destroying an instantiated effect object.")]
        public float DestroyAfter = 5;

        #endregion


    }
}
