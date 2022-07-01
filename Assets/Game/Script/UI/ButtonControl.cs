using GameUI;
using System;
using System.Collections.Generic;
using UnityEngine;
using static StartGame;

public class ButtonControl : MonoBehaviour
{
    public StartGame startGame;
    private UIManager uIManager;
    private Stack<TRANSITION> last;
    public TRANSITION Last { get => this.last.Peek(); private set { } }
    private void Awake()
    {
        uIManager = GetComponent<UIManager>();
        last = new Stack<TRANSITION>();
    }
    public void menu()
    {
        startGame.MakeTransiction(TRANSITION.menu);
        last.Push(TRANSITION.menu);
    }
    public void Credts()
    {
        startGame.MakeTransiction(TRANSITION.credits);
        uIManager.SwitchBackground(TRANSITION.credits);
        last.Push(TRANSITION.credits);
    }
    public void Configure()
    {
        startGame.MakeTransiction(TRANSITION.configure);
        //uIManager.SwitchBackground(TRANSITION.configure);
        last.Push(TRANSITION.configure);
    }
    public void Banner(bool value = true)
    {
        startGame.MakeTransiction(TRANSITION.banner);
        uIManager.SwitchBackground(TRANSITION.banner, value);
        last.Push(TRANSITION.banner);
    }
    public void Resume()
    {
        switch (Last)
        {
            case TRANSITION.credits:
                uIManager.SwitchBackground(TRANSITION.credits, false);
                break;
            case TRANSITION.menu:
                uIManager.SwitchBackground(TRANSITION.menu, false);
                break;
            case TRANSITION.endGame:
                uIManager.SwitchBackground(TRANSITION.endGame, false);
                break;
        }
        if (last.Count > 0)
            startGame.MakeTransiction(last.Pop());
    }
    public void InGame()
    {
        startGame.MakeTransiction(TRANSITION.inGame);
        last.Push(TRANSITION.inGame);
    }
    public void Pause()
    {
    }

    void Update()
    {
        if (last.Count > 0)
            if (startGame.BiggerTime < 0 && last.Peek() == TRANSITION.inGame)
            {
                uIManager.SwitchBackground(TRANSITION.banner, false);
                uIManager.SwitchBackground(TRANSITION.credits, false);
            }
        startGame.BiggerTime -= Time.deltaTime;
    }
}