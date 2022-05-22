using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    [CreateAssetMenu(fileName = "Character properties")]
    public class CharacterProperties : ScriptableObject
    {
        [SerializeField] private float speed;
        [SerializeField] private float jumpImpulse;
        [SerializeField] private float headForce;
        [SerializeField] private float rotationSpeed;

        public float Speed { get => speed; set => speed = value; }
        public float JumpImpulse { get => jumpImpulse; set => jumpImpulse = value; }
        public float HeadForce { get => headForce; set => headForce = value; }
        public float RotationSpeed { get => rotationSpeed; set => rotationSpeed = value; }
    }
}

