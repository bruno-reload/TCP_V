using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Field
{

    [Serializable]
    public class FieldSide : MonoBehaviour
    {
        [SerializeField] private LayerMask teamLayer;
        [SerializeField] private Color gizmosColor;
        [SerializeField] private Vector3 center;
        [SerializeField] private float xScale;
        [SerializeField] private float zScale;

        public Vector3 scale => new Vector3(xScale, 1, zScale);

        public Vector3 Center { get => center; set => center = value; }
        public float XScale { get => xScale; set => xScale = value; }
        public float ZScale { get => zScale; set => zScale = value; }
        public Color GizmosColor { get => gizmosColor; set => gizmosColor = value; }

        public FieldSide()
        {

        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireCube(center, scale);
        }

    }
}

