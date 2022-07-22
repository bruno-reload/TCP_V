using Character.Control;
using System.Collections;
using Team;
using UnityEngine;

namespace CoreLoop
{
    public class Scoring : MonoBehaviour
    {
        [SerializeField] private int intervalInSeconds = 3;
        [SerializeField] private TeamTurnHandler teamTurnHandler;
        [SerializeField] private Score redScore;
        [SerializeField] private Score blueScore;
        private CoreLoopController coreLoopController;

        private Players player;
        private int playerIndex => (int)player + 1;

        private bool canSkipState = false;
        
        private void Awake()
        {
            coreLoopController = GetComponentInParent<CoreLoopController>();
        }

        private void Start()
        {
            teamTurnHandler.turnOver += ApplyScore;
            teamTurnHandler.turnOver += UpdateTeamServe;

        }

        private void OnDestroy()
        {
            teamTurnHandler.turnOver -= ApplyScore;
            teamTurnHandler.turnOver -= UpdateTeamServe;

        }

        private void OnEnable()
        {
            StartCoroutine(WaitForSkipState());

        }
        private void OnDisable()
        {
            StopCoroutine(WaitForSkipState());
        }       

        private void ApplyScore(TEAM team)
        {
            if (team == TEAM.Red) redScore.IncreaseScore();
            else  blueScore.IncreaseScore(); 
        }

        private void UpdateTeamServe(TEAM team)
        {
            player = (team == TEAM.Blue) ? Players.Player2 : Players.Player1;
        }

        private IEnumerator WaitForSkipState()
        {
            yield return new WaitForSeconds(intervalInSeconds);
            coreLoopController.NextStep();
        }

        //private void Update()
        //{
        //    if(Input.anyKeyDown)
        //    {
        //        coreLoopController.NextStep();
        //    }
        //}


        //private void Update()
        //{

        //    //if (Input.GetButtonDown("Dive" + playerIndex.ToString()))
        //    //{
        //    //    coreLoopController.NextStep();
        //    //}
        //}




    }

}
