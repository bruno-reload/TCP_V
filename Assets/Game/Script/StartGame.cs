using GameUI;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public enum SCREEN { banner, menu, inGame, endGame, resume, credits, configure }
    private static SCREEN currentUIState = SCREEN.banner;
    public UIManager UIManager;
    private ButtonControl buttonControl;
    private float time = 0;
    public static SCREEN UIState { get => currentUIState; set => currentUIState = value; }
    public float BiggerTime { get => this.time; set => this.time = value; }

    #region onlyOne
    private void Start()
    {
        buttonControl = UIManager.gameObject.GetComponent<ButtonControl>();
        buttonControl.Last = SCREEN.banner;
        UIManager.SwitchBackground(buttonControl.Last);
        Invoke("StartAnimarion", 2);
    }
    public void StartAnimarion()
    {
        MakeTransiction(SCREEN.banner);
        Invoke("EndAnimaition", 2);
    }
    public void EndAnimaition()
    {
        MakeTransiction(SCREEN.banner);
        Invoke("Continue", 2);
    }
    public void Continue()
    {
        buttonControl.menu();
    }
    #endregion

    public void MakeTransiction(SCREEN item)
    {
        List<int> elements = new List<int>();
        this.time = 0;
        switch (item)
        {
            case SCREEN.banner:
                elements.Add(0);
                break;
            case SCREEN.menu:
                elements.Add(1);
                break;
            case SCREEN.inGame:
                elements.Add(3);
                break;
            case SCREEN.configure:
                switch (buttonControl.Last)
                {
                    case SCREEN.menu:
                        elements.Add(1);
                        break;
                }
                elements.Add(4);
                break;
            case SCREEN.credits:
                elements.Add(1);
                elements.Add(2);
                break;
        }
        foreach (int i in elements)
        {
            UIManager.Change(UIManager.elements[i].screen);
            //foreach (var e in UIManager.elements[i].value)
            //{
            //    if (time < e.EndTime && e.initialPositionOnScreen == STATUS.exit)
            //    {
            //        time = e.EndTime;
            //    }
            //    if (time < e.StartTime && e.initialPositionOnScreen == STATUS.enter)
            //    {
            //        time = e.StartTime;
            //    }
            //}
        }
    }
    public void Delay()
    {
    }
}
