using GameUI;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public enum TRANSITION { banner, menu, inGame, endGame, resume, credits, configure }
    private static TRANSITION currentUIState = TRANSITION.banner;
    public UIManager UIManager;
    private ButtonControl buttonControl;
    private float time = 0;
    public static TRANSITION UIState { get => currentUIState; set => currentUIState = value; }
    public float BiggerTime { get => this.time; set => this.time = value; }

    #region onlyOne
    private void Start()
    {
        buttonControl = UIManager.gameObject.GetComponent<ButtonControl>();

        UIManager.SwitchBackground(TRANSITION.banner);
        Invoke("StartAnimarion", 2);
    }
    public void StartAnimarion()
    {
        buttonControl.Banner(true);
        Invoke("EndAnimaition", 2);
    }
    public void EndAnimaition()
    {
        buttonControl.Resume();
        Invoke("Continue", 2);
    }
    public void Continue()
    {
        buttonControl.menu();
    }
    #endregion

    public void MakeTransiction(TRANSITION item)
    {
        List<int> elements = new List<int>();
        this.time = 0;
        switch (item)
        {
            case TRANSITION.banner:
                elements.Add(0);
                elements.Add(1);
                break;
            case TRANSITION.menu:
                elements.Add(2);
                elements.Add(3);
                break;
            case TRANSITION.inGame:
                switch (buttonControl.Last)
                {
                    case TRANSITION.menu:
                        elements.Add(2);
                        elements.Add(3);
                        break;
                    case TRANSITION.configure:
                        elements.Add(4);
                        break;
                }
                break;
            case TRANSITION.configure:
                switch (buttonControl.Last)
                {
                    case TRANSITION.menu:
                        elements.Add(2);
                        elements.Add(3);
                        break;
                }
                elements.Add(4);
                break;
            case TRANSITION.credits:
                switch (buttonControl.Last)
                {
                    case TRANSITION.menu:
                        elements.Add(2);
                        elements.Add(3);
                        elements.Add(8);
                        break;
                }
                elements.Add(5);
                elements.Add(6);
                elements.Add(7);
                break;
        }
        foreach (int i in elements)
        {
            UIManager.Change(UIManager.elements[i].name);
            if (time < UIManager.elements[i].value.EndTime)
            {
                time = UIManager.elements[i].value.EndTime;
            }
        }
    }
}
