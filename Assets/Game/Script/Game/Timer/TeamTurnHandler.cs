using Ball;
using Field;
using System;
using System.Collections;
using Team;
using UnityEngine;


namespace CoreLoop
{
    public class TeamTurnHandler : MonoBehaviour
    {
        [SerializeField] private TEAM teamTurn;
        public event Action<TEAM> nextTeamTurn;
        public event Action<TEAM> turnOver;
        public event Action ballStopped;
        [SerializeField] private BallController ballController;
        [SerializeField] private FieldRangeDetection fieldRangeDectection;
        [SerializeField] private float minBallSpeedLimit;

        public TEAM TeamTurn => teamTurn;

        private void Start()
        {
            nextTeamTurn += ChangeTeamTurn;
            ballController.ballOutField += TurnOver;
        }
        private void OnDestroy()
        {
            nextTeamTurn -= ChangeTeamTurn;
            ballController.ballOutField -= TurnOver;

        }

        private void OnEnable()
        {
            StartCoroutine(UpdateTeamTurn());
           ballStopped += TurnOver;
        }

        private void OnDisable()
        {
            StopCoroutine(UpdateTeamTurn());
            ballStopped -= TurnOver;

        }


        public IEnumerator UpdateTeamTurn()
        {
            while(true)
            {
                if (ballController.xzBallVelocityMagnitude < minBallSpeedLimit) 
                {
                    ballStopped?.Invoke();
                    //yield return null;
                    break;
                }
               
                if(ballController.zPosition < 0.00f && teamTurn != TEAM.Blue)
                {
                   nextTeamTurn?.Invoke(TEAM.Blue);
                }
                if(ballController.zPosition > 0.00f && teamTurn != TEAM.Red)
                {
                    nextTeamTurn?.Invoke(TEAM.Red);
                }

                yield return new WaitForSeconds(0.1f);
            }

        }

        private void ChangeTeamTurn(TEAM team)
        {
            teamTurn = team;
        }


        private void TurnOver()
        {
            Debug.Log("Turn Over!");
            turnOver?.Invoke(teamTurn);
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(10, Screen.height/3, 150, 100),  ballController.xzBallVelocityMagnitude.ToString());
        }



    }

}
