using UnityEngine;

namespace Character.Control
{
    [RequireComponent(typeof(PlayerInput))]
    public class CharacterControl : MonoBehaviour
    {
        private PlayerInput playerInput;
        private Control control;
        private CharacterBehaviour behaviour;
        public Control Control { get => control; set => control = value; }
        public CharacterBehaviour Behaviour { get => behaviour; set => behaviour = value; }

        private void Awake()
        {
            behaviour = GetComponent<CharacterBehaviour>();

        }
        private void Start()
        {
            SetControl(GetComponent<PlayerInput>());

        }
        public void SetControl(Control control)
        {
            this.control = control;
        }


    }


}

