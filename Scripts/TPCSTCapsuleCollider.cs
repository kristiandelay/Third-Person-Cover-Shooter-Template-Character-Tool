using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverShooter.Tools
{
    [System.Serializable]
    public class TPCSTCapsuleCollider
    {
        public enum Direction { X_Axis = 0, Y_Axis, Z_Axis};

        #region Public fields

        public bool is_trigger;
        public PhysicMaterial physicMaterial;
        public Vector3 center;
        public float radius;
        public float height;
        public Direction direction;

        #endregion
    }
}
