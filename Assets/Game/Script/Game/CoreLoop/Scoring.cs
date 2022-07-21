using Character.Control;
using Team;
using UnityEngine;

namespace CoreLoop
{
    public class Scoring : MonoBehaviour
    {
        [SerializeField] private TeamTurnHandler teamTurnHandler;
        [SerializeField] private Score redScore;
        [SerializeField] private Score blueScore;
        private CoreLoopController coreLoopController;

        private Players player;
        private int playerIndex => (int)player + 1;

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

        private void ApplyScore(TEAM team)
        {
            if (team == TEAM.Red) blueScore.IncreaseScore();
            else  redScore.IncreaseScore(); 
        }

        private void UpdateTeamServe(TEAM team)
        {
            player = (team == TEAM.Blue) ? Players.Player1 : Players.Player2;
        }

        private void Update()
        {

            if (Input.GetButtonDown("Dive" + playerIndex.ToString()))
            {
                coreLoopController.NextStep();
            }
        }




    }

}
