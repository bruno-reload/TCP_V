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
    public TRANSITION Last
    {
        get
        {
            return this.last.Peek();
        }
        set
        {
            this.last.Push(value);
        }
    }
    private void Awake()
    {
        this.last = new Stack<TRANSITION>();
        uIManager = GetComponent<UIManager>();
    }
    public void menu()
    {
        startGame.MakeTransiction(TRANSITION.menu);
        Last = TRANSITION.menu;
    }
    public void Credts()
    {
        startGame.MakeTransiction(TRANSITION.credits);
        uIManager.SwitchBackground(TRANSITION.credits);
        Last = TRANSITION.credits;
    }
    public void Configure()
    {
        startGame.MakeTransiction(TRANSITION.configure);
        //uIManager.SwitchBackground(TRANSITION.configure);
        Last = TRANSITION.configure;
    }
    public void Banner(bool value = true)
    {
        startGame.MakeTransiction(TRANSITION.banner);
        uIManager.SwitchBackground(TRANSITION.banner, value);
        Last = TRANSITION.banner;
    }
    public void Resume()
    {
        switch (Last)
        {
            case TRANSITION.credits:
                uIManager.SwitchBackground(TRANSITION.credits, false);
                break;
            case TRANSITION.menu:
                break;
            case TRANSITION.endGame:
                uIManager.SwitchBackground(TRANSITION.endGame, false);
                break;
        }
        if (last.Count > 0)
        {
            startGame.MakeTransiction(last.Pop());
        }
    }
    public void InGame()
    {
        uIManager.SwitchBackground(TRANSITION.banner, false);
        Last = TRANSITION.inGame;
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