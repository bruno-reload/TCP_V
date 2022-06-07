using Field;
using Team;
using TMPro;
using UnityEngine;

namespace Game
{
    public class ScoreBoard : MonoBehaviour
    {
        [SerializeField] private TEAM team;
        [SerializeField] private Score teamScore;
        private TMP_Text text_TeamScore;
        private FieldSide fieldSide;

        public FieldSide SearchFieldToScore(TEAM team)
        {
            FieldSide[] sides = FindObjectsOfType<FieldSide>();
            foreach(FieldSide side in sides)
            {
                if (side.Team != team)
                {
                    return side;
                }
            }
            return null;
        }

        private void Awake()
        {
            text_TeamScore = GetComponentInChildren<TMP_Text>();
            fieldSide = SearchFieldToScore(team);
        }

        private void OnEnable()
        {
            teamScore.updateTeamScore += ShowScoreText;
            fieldSide.ballDropsOnOtherTeamSide += Score;

        }

        private void OnDisable()
        {
            teamScore.updateTeamScore -= ShowScoreText;
            fieldSide.ballDropsOnOtherTeamSide -= Score;
        }

        private void Score()
        {
            Debug.Log("Ponto2");

            teamScore.IncreaseScore();
        }

        private void ShowScoreText(int score)
        {
            text_TeamScore.SetText(score.ToString());
        }

    }
}

