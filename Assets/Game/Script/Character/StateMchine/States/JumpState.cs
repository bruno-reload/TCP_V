using Character.Control;
using UnityEngine;

namespace Character.StateMachine
{
    public class JumpState : State
    {

        public override void EnterState(CharacterControl controller)
        {
            controller.Behaviour.Jumping();
            controller.Animator.Floor(false);
            controller.Animator.Jumping();
        }
        public override void ExitState(CharacterControl controller)
        {
        }
        public override void FixedUpdateState(CharacterControl controller, FiniteStateMachine stateMachine)
        {
            controller.Behaviour.Moving();
        }

        public override void OnCollisionEnterState(CharacterControl controller, Collision collision, FiniteStateMachine stateMachine)
        {
            if (collision.collider.CompareTag("Field") && controller.gameObject.GetComponent<Rigidbody>().velocity.y < 0)
            {
                stateMachine.TransitionToState(stateMachine.StateInstances.idleState);
                ////if (collision.gameObject.CompareTag("Field"))
            }
        }

        public override void UpdateState(CharacterControl controller, FiniteStateMachine stateMachine)
        {
            Debug.Log("jumping");
            controller.Animator.Floor(false);
            controller.Animator.Jumping();
        }
    }

}
