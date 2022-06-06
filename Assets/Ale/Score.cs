using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Team
{
    [CreateAssetMenu(fileName ="game Score")]
    public class Score : ScriptableObject
    {
        [SerializeField] private int teamScore = 0;
        public event Action<int> updateTeamScore;

        private void OnEnable()
        {
            ResetScore();
        }

        public void IncreaseScore()
        {
            Debug.Log("Ponto");
            teamScore++;
            updateTeamScore?.Invoke(teamScore);
        }

        public void ResetScore()
        {
            teamScore = 0;
            updateTeamScore?.Invoke(teamScore);

        }
    }
}

