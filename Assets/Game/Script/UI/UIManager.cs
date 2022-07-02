using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static StartGame;

namespace GameUI
{
    [RequireComponent(typeof(ButtonControl))]
    public class UIManager : MonoBehaviour
    {
        public List<Element> elements;
        public Couple[] targets;
        private Dictionary<SCREEN, GameObject> dic = new Dictionary<SCREEN, GameObject>();
        private Dictionary<SCREEN, MovimentUi[]> dict = new Dictionary<SCREEN, MovimentUi[]>();
        private STATUS[] pair;

        public MovimentUi[] GetTimeByName(SCREEN value)
        {
            return this.dict[value];
        }
        private void Awake()
        {
            var value = 0;
            for (int i = 0; i < elements.Count; i++)
            {
                value += elements[i].value.Length;
            }
            this.pair = new STATUS[value];
            int k = 0;
            for (int i = 0; i < elements.Count; i++)
            {
                dict[elements[i].screen] = elements[i].value;
                for (int j = 0; j < elements[i].value.Length; j++, k++)
                    pair[k] = elements[i].value[j].initialPositionOnScreen;
            }

            foreach (Couple item in targets)
            {
                dic[item.key] = item.valeu;
            }
        }
        public void CleanAll()
        {

        }
        public void Change(SCREEN stateTag)
        {
            #region trash
            //############essa parte ficou feia de mais#############
            int index = 0;
            int k = 0;
            foreach (Element e in elements)
            {
                if (e.screen == stateTag)
                {
                    break;
                }
                k += dict[elements[index].screen].Length;
                index++;
            }
            //#######################################################
            #endregion

            foreach (var e in dict[elements[index].screen])
            {
                switch (e.axle)
                {
                    case AXLE.horizontal:
                        switch (pair[k])
                        {
                            case STATUS.enter:
                                e.target.LeanMoveLocalX(e.startPosition, e.EndTime).setEase(e.type);
                                pair[k] = STATUS.exit;
                                break;
                            case STATUS.exit:
                                e.target.LeanMoveLocalX(e.endPosition, e.StartTime).setEase(e.type);
                                pair[k] = STATUS.enter;
                                break;
                        }
                        break;
                    case AXLE.vertical:
                        switch (pair[k])
                        {
                            case STATUS.enter:
                                e.target.LeanMoveLocalY(e.startPosition, e.EndTime).setEase(e.type);
                                pair[k] = STATUS.exit;
                                break;
                            case STATUS.exit:
                                e.target.LeanMoveLocalY(e.endPosition, e.StartTime).setEase(e.type);
                                pair[k] = STATUS.enter;
                                break;
                        }
                        break;
                }
                k++;
            }
        }
        public void SwitchBackground(SCREEN item, bool value = true)
        {
            if (dic.ContainsKey(item))
                dic[item].SetActive(value);
        }
    }

    public enum STATUS { enter, exit }
    public enum AXLE { vertical, horizontal }
    public enum RANGE { start, end }
    [System.Serializable]
    public struct Element
    {
        public SCREEN screen;
        public MovimentUi[] value;
    }
    [System.Serializable]
    public struct MovimentUi
    {
        public GameObject target;
        public STATUS initialPositionOnScreen;
        public LeanTweenType type;
        [SerializeField]public AXLE axle;
        [SerializeField] private float startTime;
        [SerializeField] private float endTime;
        public float startPosition;
        public float endPosition;
        public float starDelay;
        public float endDelay;

        public float StartTime { get => this.startTime; set => this.startTime = value; }
        public float EndTime { get => this.endTime; set => this.endTime = value; }
        public float[] Time { get => new float[2] { this.startTime, this.endTime }; set { } }
    }
    public struct IdValue
    {
        public int id;
        public float value;
    }

    [System.Serializable]
    public struct Couple
    {
        public SCREEN key;
        public GameObject valeu;
    }
}