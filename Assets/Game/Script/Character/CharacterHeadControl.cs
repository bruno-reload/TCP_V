using head;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHeadControl : MonoBehaviour
{
    private HeaderControl hc;
    private float count = 0;

    private void Awake()
    {
        hc = GetComponentInChildren<HeaderControl>();
    }
    private void Update()
    {
        count -= Time.deltaTime;
        if (count < 0)
        {
            Idle();
        }
    }
  
    public void Head()
    {
        count = 1;
        hc.dive = false;
        hc.header = HEAD_ROTATION.action;
    }
    public void Idle()
    {
        hc.dive = false;
        hc.header = HEAD_ROTATION.Idle;
    }
    public void HeadInDive()
    {
        count = 1;
        hc.dive = true;
        hc.header = HEAD_ROTATION.action;
    }
    public void HeadIdleInDive()
    {
        count = 1;
        hc.dive = true;
        hc.header = HEAD_ROTATION.Idle;
    }
}
