using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Movement;

namespace Behaviour
{
    public class WalkAroundNode : Node
    {
        #region attributes
        private Rigidbody agentRigidbody;
        private Float speed;
        #endregion

        #region constructors
        public WalkAroundNode(Rigidbody agentRigidbody, Float speed)
        {
            this.agentRigidbody = agentRigidbody;
            this.speed = speed;

        }
        #endregion

        #region methods
        public override BehaviourResult Evaluate()
        {
            agentRigidbody.position += agentRigidbody.transform.forward* speed.Value*Time.deltaTime;
            return BehaviourResult.Success;
        }
        #endregion
    }
}
