using System.Collections;
using System.Collections.Generic;
using Team;
using UnityEngine;

namespace Character
{
    public class DisplacementLimiter : MonoBehaviour
    {
        //[SerializeField] private Transform forwardPoint;
        public float forwardOffset = 5.0f;

        [SerializeField] private SphereCollider fieldRangeCollider;
        [SerializeField] private bool onLimit;
        private TeamSelection teamSelection;
        public bool OnLimit => onLimit;
        public Vector3 forwardPointLimit => transform.position + transform.forward * forwardOffset;
    
        private void Awake()
        {
            teamSelection = GetComponent<TeamSelection>();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, forwardPointLimit);
        }

        public void OnEnable()
        {
            StartCoroutine(VerifyPointOut());
        }

        public void OnDisable()
        {
            StopCoroutine(VerifyPointOut());
        }


        private IEnumerator VerifyPointOut()
        {
            while (true)
            {
                onLimit = (OutFieldRange() || OutTeamZone());
                yield return new WaitForSeconds(0.05f);
            }

        }

        private bool OutFieldRange()
        {
            if (Mathf.Abs(forwardPointLimit.magnitude) > fieldRangeCollider.radius) {
                return true;
            }
            return false;
            
        }

        //team blue is On negative zone < (0,0,0)
        //team red is on positive zone > (0,0,0)
        private bool OutTeamZone()
        {
            if(teamSelection.team == TEAM.Blue )
            {
                return forwardPointLimit.z > 0 ? true : false;
            }
            return forwardPointLimit.z < 0 ? true : false;
        }


    }

}
