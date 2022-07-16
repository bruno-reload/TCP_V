using FSMUI;
using Game;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    public void menu()
    {
        StartGame.MakeTransiction(SCREEN.menu);
    }
    public void Credts()
    {
        StartGame.MakeTransiction(SCREEN.credits);
    }
    public void Configure()
    {
        StartGame.MakeTransiction(SCREEN.configure);
    }
    public void Pause()
    {
        StartGame.MakeTransiction(SCREEN.pause);
    }
    public void Banner()
    {
        Time.timeScale = 1;
        StartGame.MakeTransiction(SCREEN.banner);
    }
    public void InGame()
    {
        StartGame.MakeTransiction(SCREEN.inGame);
    }
    public void EndGame()
    {
        StartGame.MakeTransiction(SCREEN.endGame);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        if (StartGame.LastState.Count > 0)
        {
            SCREEN current = StartGame.LastState.Pop();
            SCREEN next = StartGame.LastState.Peek();
            StartGame.LastState.Push(current);
            StartGame.MakeTransiction(next);
        }
    }
    private void Update()
    {
        if (Input.anyKeyDown && StartGame.LastState.Peek() == SCREEN.banner)
        {

            StartGame.MakeTransiction(SCREEN.menu);
        }
        if (StartGame.LastState.Peek() == SCREEN.inGame)
        {
                if (Input.GetButton("Start1") || Input.GetButton("Start2"))
            {
                Time.timeScale = 0;
                Pause();
            }
        }
    }
}