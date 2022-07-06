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
        StartGame.MakeTransiction(SCREEN.banner);
    }
    public void InGame()
    {
        StartGame.MakeTransiction(SCREEN.inGame);
    }
    public void Resume()
    {
        if (StartGame.LastState.Count > 0)
        {
            SCREEN current = StartGame.LastState.Pop();
            SCREEN next = StartGame.LastState.Peek();
            StartGame.LastState.Push(current);
            StartGame.MakeTransiction(next); 
        }
    }
}