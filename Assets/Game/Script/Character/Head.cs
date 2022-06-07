using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HEAD_ROTATION { action, Idle };
public class Head : MonoBehaviour
{
    public HEAD_ROTATION headRotation = HEAD_ROTATION.Idle;
    public bool dive;
    private Quaternion rotation;
    public Transform forehead;

    private void Start()
    {
        rotation = transform.rotation;
    }
    void Update()
    {
        switch (headRotation)
        {
            case HEAD_ROTATION.action:
                RotateToFoward();
                break;
            case HEAD_ROTATION.Idle:
                GoToIdle();
                break;
        }
    }
    private void RotateToFoward()
    {
        if (dive)
        { }
        else
        {
            transform.rotation = Quaternion.Euler(transform.right * -25);
            forehead.rotation = Quaternion.Euler(transform.forward * -45);
        }
    }

    private void GoToIdle()
    {
        if (dive)
        { }
        else
        {
            transform.rotation = rotation;
            forehead.rotation = Quaternion.Euler(transform.forward * -45);
        }
    }
}
