using System;
using System.Collections;
using System.Collections.Generic;
using Team;
using UnityEngine;

namespace Field
{

    //[Serializable]
    public class FieldSide : MonoBehaviour
    {
        [SerializeField] private TEAM team;
        private Collider floorSideCollider;
        public event Action ballDropsOnTeamSide;
        public Collider FloorSideCollider { get => floorSideCollider; }
        public TEAM Team { get => team;}

        private void Awake()
        {
            floorSideCollider = GetComponent<Collider>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.collider.CompareTag("Ball"))
            {
                ballDropsOnTeamSide?.Invoke();
            }
        }

    }
}

