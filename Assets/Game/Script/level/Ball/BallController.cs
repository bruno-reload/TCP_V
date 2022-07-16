using CoreLoop;
using System;
using System.Collections;
using System.Collections.Generic;
using Team;
using UnityEngine;


namespace Ball
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private GameObject redMiddleCharacter;
        [SerializeField] private GameObject blueMiddleCharacter;
        [SerializeField] private float yOffset;
        [SerializeField] private int headsCount = 0;
        private TrailRenderer ballTrail;
        private Rigidbody ballRigidbody;
        public event Action HeadOn;
        public event Action<TEAM> Serves;
        public event Action ballOutField;
       [SerializeField] private TeamTurnHandler turnHandler;
        public float zPosition => transform.position.z;
        public float ballVelocityMagnitude => ballRigidbody.velocity.magnitude;


        private void Awake()
        {
            ballRigidbody = GetComponent<Rigidbody>();
            ballTrail = GetComponentInChildren<TrailRenderer>();
        }



        private void OnEnable()
        {
            turnHandler.nextTeamTurn += ResetHeadsCount;
        }

        private void OnDisable()
        {
            turnHandler.nextTeamTurn -= ResetHeadsCount;

        }


        public Vector3 GetSaquePosition(TEAM characterTeam)
        {
            if(characterTeam == TEAM.Blue)
            {
                return blueMiddleCharacter.transform.position + Vector3.up *yOffset;
            }
            return redMiddleCharacter.transform.position + Vector3.up * yOffset;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Head"))
            {
                headsCount++;
                HeadOn?.Invoke();

                //TEAM team = collision.gameObject.GetComponentInParent<TeamSelection>().team;
                //GetComponent<TeamTurnHandler>().VerifyTeamMatchTarget(team);

            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("FieldRange"))
            {
                ballOutField?.Invoke();
            }
        }


        //private void VerifyTeamMatchTarget(TEAM teamCollision)
        //{
        //    if (teamCollision == turnHandler.teamTurn)
        //    {
        //        turnHandler.teamTurn = (turnHandler.teamTurn == TEAM.Blue) ? TEAM.Red : TEAM.Blue;
        //    }

        //}



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

        private void ResetHeadsCount(TEAM t)
        {
            headsCount = 0;
        }

    }
}

