using Character.Control;
using System.Collections;
using UnityEngine;

namespace Character.StateMachine
{
    public class DiveState : State
    {
        public override void EnterState(CharacterControl controller)
        {
            controller.Behaviour.Dive();
            controller.Animator.Floor(false);
            controller.Animator.Dive();
        }

        public override void ExitState(CharacterControl controller)
        {
            controller.Animator.Idle();
        }

        public override void FixedUpdateState(CharacterControl controller, PlayerStateMachine stateMachine)
        {
        }

        public override void OnCollisionEnterState(CharacterControl controller, Collision collision, PlayerStateMachine stateMachine)
        {
            if (collision.collider.CompareTag("Field"))
            {
                //TODO: GettingUp()
                stateMachine.TransitionToState(stateMachine.StateInstances.idleState);
            }
        }

        public override void UpdateState(CharacterControl controller, PlayerStateMachine stateMachine)
        {
            Debug.Log("dive");
            // controller.Animator.Floor(false);
            //controller.Animator.Dive();
        }


        //private IEnumerator GettingUp()
        //{
        //}
    }
}

