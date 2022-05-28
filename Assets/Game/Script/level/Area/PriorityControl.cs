using System.Collections;
using System.Collections.Generic;
using Team;
using UnityEngine;

public class PriorityControl : MonoBehaviour
{
    public TeamSelection recipient;
    void Start()
    {
        Debug.Log("nessa linha eu diminuo a escala do tempo pra poder testar");
        Time.timeScale = 0.5f;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.gameObject.CompareTag("Prediction"))
        {
            recipient.Swap();
        }
    }
}
