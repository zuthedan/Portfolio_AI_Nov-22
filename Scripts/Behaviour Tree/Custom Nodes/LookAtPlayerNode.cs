using UnityEngine;

namespace Behaviour
{
    public class LookAtPlayerNode:Node
    {
        #region attributes
        private Transform agentTransform;
        private Transform playerTransform;
        #endregion

        #region constructors
        public LookAtPlayerNode(Transform agentTransform, Transform playerTransform)
        {
            this.agentTransform = agentTransform;
            this.playerTransform = playerTransform;
        }
        #endregion

        #region methods
        public override BehaviourResult Evaluate()
        {
            agentTransform.forward = playerTransform.position - agentTransform.position;
            return BehaviourResult.Success;
        }
        #endregion
    }
}
