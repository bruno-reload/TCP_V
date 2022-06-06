using Character.Control;
using UnityEngine;

namespace Character.StateMachine
{
    public class JumpState : State
    {

        public override void EnterState(CharacterControl controller)
        {
            controller.Behaviour.Jumping();
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
            if (collision.collider.CompareTag("Field"))
            {
                stateMachine.TransitionToState(stateMachine.StateInstances.idleState);
                controller.gameObject.GetComponentInChildren<Animator>().SetBool("onFloor", true);
            }
        }

        public override void UpdateState(CharacterControl controller, FiniteStateMachine stateMachine)
        {
        }
    }

}
