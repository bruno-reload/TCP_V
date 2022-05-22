using Character.Control;
using UnityEngine;


namespace Character.StateMachine
{
    public class FiniteStateMachine : MonoBehaviour
    {
        private State currentState;
        private CharacterControl characterController;
        private StateInstances stateInstances;

        public StateInstances StateInstances { get => stateInstances;}
        private void Awake()
        {
            characterController = GetComponent<CharacterControl>();
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
            currentState.FixedUpdateState(characterController, this);
        }

        public virtual void TransitionToState(State state)
        {
            currentState?.ExitState(characterController);
            currentState = state;
            currentState.EnterState(characterController);

        }

        private void OnCollisionEnter(Collision collision)
        {
            currentState.OnCollisionEnterState(characterController, collision, this);
        }
    }
}


