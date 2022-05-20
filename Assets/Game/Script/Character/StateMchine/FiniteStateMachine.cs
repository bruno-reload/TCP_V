using UnityEngine;
using UnityEngine.Events;

namespace Character.StateMachine
{
    public class FiniteStateMachine : MonoBehaviour
    {

        private State currentState;
        private CharacterBehaviour characterController;
        private StateInstances stateInstances;

        public StateInstances StateInstances { get => stateInstances;}

        private void Awake()
        {
            characterController = GetComponent<CharacterBehaviour>();
            stateInstances = new StateInstances();
        }
        void Start()
        {
            TransitionToState(StateInstances.idleState);
        }


        void Update()
        {
            currentState.UpdateState(characterController, this);
        }

        private void FixedUpdate()
        {
            currentState.FixedUpdateState(characterController);
        }

        public virtual void TransitionToState(State state)
        {
            currentState?.ExitState(characterController);
            currentState = state;
            currentState.EnterState(characterController);

        }

        private void OnCollisionEnter(Collision collision)
        {
            currentState.OnCollisionEnterState(characterController, this, collision);
        }
    }
}


