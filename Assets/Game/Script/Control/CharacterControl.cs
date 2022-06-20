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
        private CharacterParticle particle;
        private CharacterHeadControl headControl;
        public Control Control { get => control;private set => control = value; }
        public CharacterBehaviour Behaviour { get => behaviour; set => behaviour = value; }
        public CharacterAnimation Animator { get => anim; set => anim = value; }
        public CharacterParticle Particle { get => particle; set => particle = value; }
        public CharacterHeadControl HeadControl { get => headControl; set => headControl = value; }

        private void Awake()
        {
            behaviour = GetComponent<CharacterBehaviour>();
            anim = GetComponent<CharacterAnimation>();
            particle = GetComponent<CharacterParticle>();
            headControl = GetComponent<CharacterHeadControl>();

        }
         public void SetControl(Control control)
        {
            this.control = control;
        }
    }
}

