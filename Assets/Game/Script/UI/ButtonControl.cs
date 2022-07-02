using GameUI;
using System;
using System.Collections.Generic;
using UnityEngine;
using static StartGame;

public class ButtonControl : MonoBehaviour
{
    public StartGame startGame;
    private UIManager uIManager;
    private Stack<SCREEN> last;
    public SCREEN Last
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
        this.last = new Stack<SCREEN>();
        uIManager = GetComponent<UIManager>();
    }
    public void menu()
    {
        startGame.MakeTransiction(SCREEN.menu);
        Last = SCREEN.menu;
    }
    public void Credts()
    {
        startGame.MakeTransiction(SCREEN.credits);
        Last = SCREEN.credits;
    }
    public void Configure()
    {
        startGame.MakeTransiction(SCREEN.configure);
        Last = SCREEN.configure;
    }
    public void Banner()
    {
        startGame.MakeTransiction(SCREEN.banner);
        Last = SCREEN.banner;
    }
    public void InGame()
    {
        startGame.MakeTransiction(SCREEN.inGame);
        Last = SCREEN.inGame;
    }
    public void Resume()
    {
        if (last.Count > 0)
        {
            uIManager.SwitchBackground(last.Peek(), false);
            startGame.MakeTransiction(last.Pop());
            uIManager.SwitchBackground(last.Peek());
        }
    }
    public void Pause()
    {
    }

    void Update()
    {
        if (startGame.BiggerTime > 0)
        {
            startGame.BiggerTime -= Time.deltaTime;
            if (startGame.BiggerTime < 0)
            {
                uIManager.SwitchBackground(last.Peek());
            }
        }
    }
}