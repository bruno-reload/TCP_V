using Ball;
using CoreLoop;
using Game;
using System.Collections;
using System.Collections.Generic;
using Team;
using UnityEngine;

namespace CoreLoop
{
    public class RollingBall : MonoBehaviour
    {
        [SerializeField] private BallController ballController;
        private TeamTurnHandler teamTurnHandler;
        private CoreLoopController coreLoopController;
        private void Awake()
        {
            teamTurnHandler = GetComponent<TeamTurnHandler>();
            coreLoopController = GetComponentInParent<CoreLoopController>();
        }


        private void OnEnable()
        {
            teamTurnHandler.turnOver += OnTunrOver;
        }
        private void OnDisable()
        {
            teamTurnHandler.turnOver -= OnTunrOver;
        }

        private void OnTunrOver(TEAM teamturn)
        {
            coreLoopController.NextStep();
        }

        


    }

}
