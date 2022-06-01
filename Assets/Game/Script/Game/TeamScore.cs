using System;
using System.Collections;
using System.Collections.Generic;
using Team;
using UnityEngine;

namespace Team
{
    public class TeamScore : ScriptableObject
    {
        [SerializeField] private TEAM team;
        [SerializeField] private int score;
        public event Action<int> updateScore;
        public TEAM Team { get => team; }
        public int Score { get => score; set => score = value; }

        public TeamScore(TEAM team)
        {
            this.team = team;
        }
        public void ResetScore() => score = 0;

        public void IncreaseScore()
        {
            score++;
            updateScore?.Invoke(score);
        }


    }

}

