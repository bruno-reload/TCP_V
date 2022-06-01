using Field;
using Team;
using TMPro;
using UnityEngine;

namespace GameLogic
{
    public class ScoreBoard : MonoBehaviour
    {
        [SerializeField] private TEAM team;
        private TMP_Text text_TeamScore;
        private FieldSide fieldSide;
        private TeamScore teamScore;

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
            teamScore = new TeamScore(team);
        }

        private void OnEnable()
        {
            fieldSide.ballDropsOnTeamSide += Score;

        }

        private void OnDisable()
        {
            fieldSide.ballDropsOnTeamSide -= Score;
        }

        private void Score()
        {
            teamScore.IncreaseScore();
            text_TeamScore.SetText(teamScore.Score.ToString());
        }


    }
}

