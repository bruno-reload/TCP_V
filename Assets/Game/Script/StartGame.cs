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
        buttonControl.Last = TRANSITION.banner;
        UIManager.SwitchBackground(buttonControl.Last);
        Invoke("StartAnimarion", 2);
    }
    public void StartAnimarion()
    {
        MakeTransiction(TRANSITION.banner);
        Invoke("EndAnimaition", 2);
    }
    public void EndAnimaition()
    {
        MakeTransiction(TRANSITION.banner);
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
                break;
            case TRANSITION.menu:
                elements.Add(1);
                break;
            case TRANSITION.inGame:
                elements.Add(3);
                break;
            case TRANSITION.configure:
                switch (buttonControl.Last)
                {
                    case TRANSITION.menu:
                        elements.Add(1);
                        break;
                }
                elements.Add(4);
                break;
            case TRANSITION.credits:
                elements.Add(2);
                break;
        }
        foreach (int i in elements)
        {
            UIManager.Change(UIManager.elements[i].stateTag);
        }
    }
}
