using UnityEngine;

namespace Character.Control
{
    [RequireComponent(typeof(PlayerInput))]
    public class CharacterControl : MonoBehaviour
    {
        private PlayerInput playerInput;
        private Control control;
        private CharacterBehaviour behaviour;
        private CharacterAnimation anim;
        public Control Control { get => control;private set => control = value; }
        public CharacterBehaviour Behaviour { get => behaviour; set => behaviour = value; }
        public CharacterAnimation Animator { get => anim; set => anim = value; }

        private void Awake()
        {
            behaviour = GetComponent<CharacterBehaviour>();
            anim = GetComponent<CharacterAnimation>();

        }
         public void SetControl(Control control)
        {
            this.control = control;
        }
    }
}

