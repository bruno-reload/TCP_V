using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DetectHead : MonoBehaviour
{
    private bool detect = false;
    public bool Detect { get => detect; set { detect = value; } }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            detect = true;
        }
    }
}
