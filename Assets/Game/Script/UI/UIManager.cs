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
        private Dictionary<TRANSITION, GameObject> dic = new Dictionary<TRANSITION, GameObject>();
        private Dictionary<TRANSITION, MovimentUi[]> dict = new Dictionary<TRANSITION, MovimentUi[]>();
        private STATUS[] pair;

        public MovimentUi[] GetTimeByName(TRANSITION value)
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

            for (int i = 0; i < elements.Count; i++)
            {
                dict[elements[i].stateTag] = elements[i].value;
                for (int j = 0; j < elements[i].value.Length; j++)
                    pair[i + j] = elements[i].value[j].initialPositionOnScreen;
            }

            foreach (Couple item in targets)
            {
                dic[item.key] = item.valeu;
            }
        }
        public void CleanAll()
        {

        }
        public void Change(TRANSITION stateTag)
        {
            #region trash
            //############essa parte ficou feia de mais#############
            int index = 0;
            foreach (Element e in elements)
            {
                if (e.stateTag == stateTag)
                {
                    break;
                }
                index++;
            }
            //#######################################################
            #endregion
            foreach (var e in dict[elements[index].stateTag])
            {
                //Debug.Log(e.target + " " + pair[index]);
                switch (e.axle)
                {
                    case AXLE.horizontal:
                        switch (pair[index])
                        {
                            case STATUS.enter:
                                e.target.LeanMoveLocalX(e.startPosition, e.EndTime).setEase(e.type);
                                Debug.Log(e.target + " " + pair[index]);
                                pair[index] = STATUS.exit;
                                break;
                            case STATUS.exit:
                                e.target.LeanMoveLocalX(e.endPosition, e.StartTime).setEase(e.type);
                                Debug.Log(e.target + " " + pair[index]);
                                pair[index] = STATUS.enter;
                                break;
                        }
                        break;
                    case AXLE.vertical:
                        switch (pair[index])
                        {
                            case STATUS.enter:
                                e.target.LeanMoveLocalY(e.startPosition, e.EndTime).setEase(e.type);
                                Debug.Log(e.target + " " + pair[index]);
                                pair[index] = STATUS.exit;
                                break;
                            case STATUS.exit:
                                e.target.LeanMoveLocalY(e.endPosition, e.StartTime).setEase(e.type);
                                Debug.Log(e.target + " " + pair[index]);
                                pair[index] = STATUS.enter;
                                break;
                        }
                        break;
                }
                index++;
            }
        }
        public void SwitchBackground(TRANSITION item, bool value = true)
        {
            dic[item].SetActive(value);
        }
    }

    public enum STATUS { enter, exit }
    public enum AXLE { vertical, horizontal }
    public enum RANGE { start, end }
    [System.Serializable]
    public struct Element
    {
        public TRANSITION stateTag;
        public MovimentUi[] value;
    }
    [System.Serializable]
    public struct MovimentUi
    {
        public GameObject target;
        public STATUS initialPositionOnScreen;
        public LeanTweenType type;
        public AXLE axle;
        [SerializeField] private float startTime;
        [SerializeField] private float endTime;
        public float startPosition;
        public float endPosition;

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
        public TRANSITION key;
        public GameObject valeu;
    }
}