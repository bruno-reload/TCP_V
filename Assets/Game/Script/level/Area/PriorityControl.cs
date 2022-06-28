using System.Collections;
using System.Collections.Generic;
using Team;
using UnityEngine;

public class PriorityControl : MonoBehaviour
{
    public TeamSelection recipient;
    private GameObject targetCharacter => recipient?.gameObject;

    public Vector2 initialPosition => new Vector3(transform.position.x, transform.position.z);
    void Start()
    {
        //Debug.Log("nessa linha eu diminuo a escala do tempo pra poder testar");
        //Time.timeScale = 0.5f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Prediction"))
        {
            recipient.Swap();
        }
    }

    public void SetInitialPosition()
    {
        targetCharacter.transform.position = new Vector3(
            initialPosition.x,
            targetCharacter.transform.position.y,
            initialPosition.y);
    }

    public void EnableCharacter(bool value) => targetCharacter.SetActive(value);

    

}
