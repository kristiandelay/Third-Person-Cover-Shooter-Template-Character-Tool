using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace CoverShooter.Tools
{
    [System.Serializable]
    public class NavMeshObstacle
    {
        #region Public fields

        public NavMeshObstacleShape shape;
        public Vector3 center;
        public float radius;
        public float hieght;
        public bool carve;
        public float move_threshold;
        public float time_to_stationary;
        public bool carve_only_station;

        #endregion

    }
}
