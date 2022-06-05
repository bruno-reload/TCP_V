using System;
using System.Collections;
using UnityEngine;

namespace Game
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float maxTimeInSeconds = 300;
        [SerializeField] private float deltaTime = 1;
        public Action timeOver;
        public Action timeInitalize;
        public Action timerChange;
        private float currentTime;

        public float timeReleased => (maxTimeInSeconds - currentTime);
        public float CurrentTime { get => currentTime; }

        public bool IsTimeOver => (CurrentTime > 0.00f) ? false : true;

        public void ResetTime() => currentTime = maxTimeInSeconds;

        private void OnEnable()
        {
            ResetTime();
            timeInitalize += OnTimeInitialize;
        }

        private void OnDisable()
        {
            timeInitalize -= OnTimeInitialize;
        }

        public void RestartTime()
        {
            ResetTime();
            timeInitalize?.Invoke();
        }

        public void PlayTime()
        {
            Debug.Log("Play");
            StartCoroutine(TimerCountdown());
        }

        public void PauseTime()
        {
            Debug.Log("Pause");
            StopAllCoroutines();
        }

        private void OnTimeInitialize()
        {
            StartCoroutine(TimerCountdown());
        }


        private IEnumerator TimerCountdown()
        {
            while (!IsTimeOver)
            {
                currentTime -= deltaTime;
                timerChange?.Invoke(/*currentTime*/);
                if (IsTimeOver) timeOver?.Invoke();
                yield return new WaitForSeconds(deltaTime);

            }

        }

        public string StringTimeFormated()
        {
            if (currentTime < 0) currentTime = 0;

            float minutes = Mathf.FloorToInt(currentTime / 60);
            float seconds = Mathf.FloorToInt(currentTime % 60);

            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }


    }
}
