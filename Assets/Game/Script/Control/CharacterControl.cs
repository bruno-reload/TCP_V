using UnityEngine;

namespace Character.Control
{
    [RequireComponent(typeof(PlayerInput))]
    public class CharacterControl : MonoBehaviour
    {
        private PlayerInput playerInput;
        private Control control;
        public MeshRenderer feedback;
        private CharacterBehaviour behaviour;
        public Control Control { get => control;private set => control = value; }
        public CharacterBehaviour Behaviour { get => behaviour; set => behaviour = value; }

        private void Awake()
        {
            behaviour = GetComponent<CharacterBehaviour>();

        }
         public void SetControl(Control control)
        {
            this.control = control;
        }
    }
}

