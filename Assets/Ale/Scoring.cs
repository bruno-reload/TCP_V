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

        private void Awake()
        {
            coreLoopController = GetComponentInParent<CoreLoopController>();
        }

        private void Start()
        {
            teamTurnHandler.turnOver += ApplyScore;
        }

        private void OnDestroy()
        {
            teamTurnHandler.turnOver -= ApplyScore;

        }

        private void ApplyScore(TEAM team)
        {
            if (team == TEAM.Red) redScore.IncreaseScore();
            else  blueScore.IncreaseScore(); 
        }

        private void Update()
        {
            if(Input.anyKeyDown)
            {
                coreLoopController.NextStep();
            }
        }
    }

}
