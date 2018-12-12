using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CoverShooter.Tools
{
    [CreateAssetMenu(menuName = "CoverShooter/AI_Actor", order = 0)]
    public class ScriptableAI : ScriptableObject
    {
        public CoverShooter.Tools.CharacterName characterName;
        public CoverShooter.Tools.HitEffect hitEffect;
        public CoverShooter.Tools.NavMeshObstacle navMeshObstacle;
        public CoverShooter.Tools.AIMovement aiMovement;
        public CoverShooter.Tools.FighterBrain fighterBrain;
        public CoverShooter.Tools.AIFire aiFire;
        public CoverShooter.Tools.AICover aiCover;
        public CoverShooter.Tools.AISearch aiSearch;
        public CoverShooter.Tools.AICommunication aiCommunication;
        public CoverShooter.Tools.AISight aiSight;
        public CoverShooter.Tools.AIAim aiAim;
        public CoverShooter.Tools.AIListener aiListener;
        public CoverShooter.Tools.AIRadio aiRadio;
        public CoverShooter.Tools.AIInvestigation aiInvestigation;
        public CoverShooter.Tools.AIForget aiForget;
        public bool addWaypoints;



    }
}
