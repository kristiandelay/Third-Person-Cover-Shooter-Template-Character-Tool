using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverShooter.Tools
{
    [System.Serializable]
    public class CharacterName
    {
        #region Public fields

        /// <summary>
        /// Name of the character to be display in the UI.
        /// </summary>
        [Tooltip("Name of the character to be display in the UI.")]
        public string Name;

        #endregion
    }
}
