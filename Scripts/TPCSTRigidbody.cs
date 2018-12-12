using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverShooter.Tools
{
    [System.Serializable]
    public class TPCSTRigidbody {

        #region Public fields

        public float mass;
        public float drag;
        public float angular_drag;
        public bool use_gravity;
        public bool is_kinematic;
        public RigidbodyInterpolation interpolation;
        public CollisionDetectionMode collisionDetectionMode;
        public RigidbodyConstraints constraints = RigidbodyConstraints.FreezeRotation;

        #endregion

    }
}
