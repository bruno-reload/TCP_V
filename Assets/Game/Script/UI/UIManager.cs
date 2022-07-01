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
        private Dictionary<string, MovimentUi> dict = new Dictionary<string, MovimentUi>();
        private Pair[] pair;
        private float time;
        private float result;
        private bool finish;

        public MovimentUi GetTimeByName(string name)
        {
            return this.dict[name];
        }
        private void Awake()
        {
            this.pair = new Pair[elements.Count];
            for (int i = 0; i < elements.Count; i++)
            {
                dict[elements[i].name] = elements[i].value;
                pair[i] = new Pair();
                pair[i].name = elements[i].name;
                pair[i].positionOnScreen = dict[elements[i].name].initialPositionOnScreen;
            }
            foreach (Couple item in targets)
            {
                dic[item.key] = item.valeu;
            }
        }
        public void CleanAll()
        {

        }
        public void Change(string key = "defaul")
        {
            #region trash
            if (key.Equals("default"))
            {
                return;
            }
            this.finish = false;
            //############essa parte ficou feia de mais#############
            int index = 0;
            foreach (Pair p in pair)
            {
                if (p.name.Equals(key))
                {
                    break;
                }
                index++;
            }
            //#######################################################
            #endregion
            switch (dict[key].axle)
            {
                case AXLE.horizontal:
                    switch (pair[index].positionOnScreen)
                    {
                        case STATUS.enter:
                            dict[key].target.LeanMoveLocalX(dict[key].startPosition, dict[key].EndTime).setEase(dict[key].type);
                            pair[index].positionOnScreen = STATUS.exit;
                            break;
                        case STATUS.exit:
                            dict[key].target.LeanMoveLocalX(dict[key].endPosition, dict[key].StartTime).setEase(dict[key].type);
                            pair[index].positionOnScreen = STATUS.enter;
                            break;
                    }
                    break;
                case AXLE.vertical:
                    switch (pair[index].positionOnScreen)
                    {
                        case STATUS.enter:
                            dict[key].target.LeanMoveLocalY(dict[key].startPosition, dict[key].EndTime).setEase(dict[key].type);
                            pair[index].positionOnScreen = STATUS.exit;
                            break;
                        case STATUS.exit:
                            dict[key].target.LeanMoveLocalY(dict[key].endPosition, dict[key].StartTime).setEase(dict[key].type);
                            pair[index].positionOnScreen = STATUS.enter;
                            break;
                    }
                    break;
            }
        }
        public bool CountTime(string name, RANGE value)
        {
            switch (value)
            {
                case RANGE.start:
                    if (GetTimeByName(name).StartTime > this.time)
                        this.result = GetTimeByName(name).StartTime;
                    break;
                case RANGE.end:
                    if (GetTimeByName(name).EndTime > this.time)
                        this.result = GetTimeByName(name).EndTime;
                    break;
            }
            return this.finish;
        }
        private void Update()
        {
            if (this.result < 0)
            {
                this.finish = true;
            }
            else
            {
                this.result -= Time.deltaTime;
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
        public string name;
        public TRANSITION stateTag;
        public MovimentUi value;
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
    [System.Serializable]
    public struct Pair
    {
        public string name;
        public STATUS positionOnScreen;
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