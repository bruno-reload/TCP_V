using Character.StateMachine;
using System.Collections;
using System.Collections.Generic;
using Team;
using UnityEngine;

namespace CoreLoop
{
    public class CharacterRestrictionOnServe : MonoBehaviour
    {
        [SerializeField] private PlayerStateMachine[] redCharacterFSM;
        [SerializeField] private PlayerStateMachine[] blueCharacterFSM;
        [SerializeField] private ScoreRules scoreRules;
        public void RestricMovement()
        {
            if(scoreRules.LastTeamMarkedPoint == TEAM.Blue)
            {
                foreach(PlayerStateMachine stateMachine in redCharacterFSM)
                {
                    stateMachine.GoServeState();
                }
            } else
            {
                foreach (PlayerStateMachine stateMachine in blueCharacterFSM)
                {
                    stateMachine.GoServeState();
                }

            }
        }


    }

}
