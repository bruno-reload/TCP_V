using System.Collections;
using System.Collections.Generic;
using Team;
using UnityEngine;

public class PriorityControl : MonoBehaviour
{
    [SerializeField] private Transform centerPointTransform;

    public TeamSelection recipient;
    private GameObject targetCharacter => recipient?.gameObject;
    public Vector2 initialPosition => new Vector3(transform.position.x, transform.position.z);

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Prediction"))
    //    {
    //        Debug.Log("entrou em prediction e fez swap()");
    //        //recipient.Swap();
    //    }
    //}

    public void SetInitialPosition()
    {
        targetCharacter.transform.position = centerPointTransform.position;
    }
    public void EnableCharacter(bool value) => targetCharacter.SetActive(value);
}
