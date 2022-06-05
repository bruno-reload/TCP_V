
using TMPro;
using UnityEngine;

namespace Timer
{
    public class TimerManager : Timer
    {
        private TMP_Text text_timer;

        private void Awake()
        {
            text_timer = GetComponentInChildren<TMP_Text>();
        }
        private void Start()
        {
            timerChange += UpdateTimerText;
            StartTime();
            //text_timer.SetText(StringTimeFormated());

        }

        private void OnDestroy()
        {
            timerChange -= UpdateTimerText;

        }

        private void UpdateTimerText(/*float time*/)
        {
            Debug.Log(StringTimeFormated());
            text_timer.SetText(StringTimeFormated());

        }

    }
}

