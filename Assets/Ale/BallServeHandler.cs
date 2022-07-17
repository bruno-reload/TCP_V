using CoreLoop;
using System;
using System.Collections;
using System.Collections.Generic;
using Team;
using UnityEngine;

namespace Ball
{
    public class BallServeHandler : MonoBehaviour
    {
        [SerializeField] private MeshCollider MiddleRedArea;
        [SerializeField] private MeshCollider MiddleBlueArea;
        [SerializeField] private float yServeOffset;
        [SerializeField] private TeamTurnHandler turnHandler;
        private Rigidbody ballRigidbody;
        private TrailRenderer ballTrail;
        public event Action<TEAM> Serves;

        private void Awake()
        {
            ballRigidbody = GetComponent<Rigidbody>();
            ballTrail = GetComponentInChildren<TrailRenderer>();
        }


        public Vector3 GetSaquePosition(TEAM characterTeam)
        {
            Vector3 centerTarget = (characterTeam == TEAM.Blue) ? 
                MiddleBlueArea.sharedMesh.bounds.center :
                MiddleRedArea.sharedMesh.bounds.center;
            return centerTarget / 2 + Vector3.up * yServeOffset;
        }

        public void ServeAntecipation()
        {

            ballRigidbody.isKinematic = true;
            gameObject.transform.position = GetSaquePosition(turnHandler.TeamTurn);
            Serve();
            ballTrail.Clear();
        }

        public void Serve()
        {
            Serves?.Invoke(turnHandler.TeamTurn);
            ballRigidbody.isKinematic = false;


        }
    }
}

