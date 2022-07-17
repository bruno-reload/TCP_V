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

        [SerializeField] private int headsCount = 0;
        private Rigidbody ballRigidbody;
        public event Action HeadOn;
        public event Action ballOutField;
        [SerializeField] private TeamTurnHandler turnHandler;
        public float zPosition => transform.position.z;
        public float ballVelocityMagnitude => ballRigidbody.velocity.magnitude;


        private void Awake()
        {
            ballRigidbody = GetComponent<Rigidbody>();
        }



        private void OnEnable()
        {
            turnHandler.nextTeamTurn += ResetHeadsCount;
        }

        private void OnDisable()
        {
            turnHandler.nextTeamTurn -= ResetHeadsCount;

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


        private void ResetHeadsCount(TEAM t)
        {
            headsCount = 0;
        }

    }
}

