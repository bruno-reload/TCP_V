using System.Collections;
using System.Collections.Generic;
using Team;
using UnityEngine;

public class PriorityControl : MonoBehaviour
{
    public TeamSelection recipient;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Prediction"))
        {
            recipient.Swap();
        }
    }
}
