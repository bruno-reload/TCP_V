using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Control
{
    public class AIControl : Control
    {
        public override bool ButtonReturn()
        {
            throw new System.NotImplementedException();
        }

        public override bool ButtonStart()
        {
            throw new System.NotImplementedException();
        }

        public override Vector3 direction()
        {
            return Vector3.zero;
        }

        public override bool dive()
        {
            return false;
        }

        public override bool head()
        {
            return false;
        }

        public override bool jump()
        {
            return false;
        }

        public override bool L()
        {
            return false;
        }

        public override void playerSelect()
        {
        }

        public override bool R()
        {
            return false;
        }

        protected override float xAxis()
        {
            return 0f;
        }

        protected override float yAxis()
        {
            return 0f;
        }
    }

}
