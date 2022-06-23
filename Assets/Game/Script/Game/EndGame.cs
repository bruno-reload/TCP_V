using Team;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{

    public class EndGame : MonoBehaviour
    {
        [SerializeField] private Score redScore;
        [SerializeField] private Score blueScore;


        private TEAM GetWinnerTeam()
        {
            if (redScore.TeamScore < blueScore.TeamScore) 
                return TEAM.Blue;
            if (redScore.TeamScore > blueScore.TeamScore) 
                return TEAM.Red;
            return TEAM.NONE;

        }

        public void ShowWinner()
        {
            Debug.Log("Time vencedor: "+GetWinnerTeam());
        }


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ResetGame();
            }
        }


        public void ResetGame()
        {
            SceneManager.LoadScene(0);
        }


    }

}
