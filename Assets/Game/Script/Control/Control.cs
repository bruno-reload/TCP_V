using UnityEngine;

namespace Character.Control
{
    public abstract class Control : MonoBehaviour
    {
        protected abstract float xAxis();
        protected abstract float yAxis();
        public abstract Vector3 direction();

        public abstract bool jump();
        public abstract bool head();
        public abstract bool dive();


    }
}

