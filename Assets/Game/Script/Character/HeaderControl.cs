using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace head
{
    public enum HEAD_ROTATION { action, Idle };
    public class HeaderControl : MonoBehaviour
    {
        public HEAD_ROTATION header = HEAD_ROTATION.Idle;
        public bool dive;
        public GameObject forehead;
        public Mesh mesh;

        private void Start()
        {
            this.dive = false;

            this.transform.localRotation = Quaternion.Euler(transform.right * -25);
            this.forehead.transform.rotation = Quaternion.Euler(transform.right * 45);
        }
        private void OnValidate()
        {
            if (this.forehead.GetComponent<Rigidbody>())
            {
                this.forehead.GetComponent<Rigidbody>().isKinematic = true;
                this.forehead.GetComponent<Rigidbody>().useGravity = false;
            }
            if (this.forehead.GetComponent<MeshCollider>())
                this.forehead.GetComponent<MeshCollider>().sharedMesh = mesh;

            this.forehead.tag = "Head";
            this.forehead.transform.SetParent(gameObject.transform);
            this.forehead.transform.localPosition = new Vector3(0, .7f, 1);
            this.forehead.transform.localScale = new Vector3(.2f, 1f, .2f);
        }
        private void Reset()
        {
            this.forehead = new GameObject("forehead");
            this.forehead.AddComponent<Rigidbody>();
            this.forehead.layer = LayerMask.NameToLayer("Head");
            this.forehead.AddComponent<MeshCollider>();
            this.forehead.GetComponent<Rigidbody>().isKinematic = true;
            this.forehead.GetComponent<Rigidbody>().useGravity = false;
            this.forehead.GetComponent<MeshCollider>().sharedMesh = mesh;

            this.forehead.transform.SetParent(gameObject.transform);

            this.forehead.transform.localPosition = new Vector3(0, .7f, 1);
            this.forehead.transform.localScale = new Vector3(.2f, 1f, .2f);
        }
        void Update()
        {
            switch (header)
            {
                case HEAD_ROTATION.action:
                    ToAction();
                    break;
                case HEAD_ROTATION.Idle:
                    GoToIdle();
                    break;
            }
        }
        private void ToAction()
        {
            if (dive)
            {
                this.transform.localRotation = Quaternion.Euler(-10, 0, 0);
                this.forehead.transform.localRotation = Quaternion.Euler(30, 0, 0);
            }
            else
            {
                this.transform.localRotation = Quaternion.Euler(-25, 0, 0);
                this.forehead.transform.localRotation = Quaternion.Euler(80, 0, 0);
            }
        }
        private void GoToIdle()
        {
            if (dive)
            {
                this.transform.localRotation = Quaternion.Euler(20, 0, 0);
                this.forehead.transform.localRotation = Quaternion.Euler(40, 0, 0);
            }
            else
            {
                this.transform.localRotation = Quaternion.Euler(-25, 0, 0);
                this.forehead.transform.localRotation = Quaternion.Euler(45, 0, 0);
            }
        }
    }
}
