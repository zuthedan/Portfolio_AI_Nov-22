using UnityEngine;


namespace Behaviour
{
    public class PlayerInRangeNode : Node
    {
        #region attributes
        private Float searchRadius;
        private Transform agentTransform;
        private Transform playerTransform;
        #endregion

        #region constructors
        public PlayerInRangeNode(Float searchRadius,Transform agentTransform, Transform playerTransform)
        {
            this.searchRadius = searchRadius;
            this.agentTransform = agentTransform;
            this.playerTransform = playerTransform;   
        }
        #endregion

        #region methods
        public override BehaviourResult Evaluate()
        {
            return result = (playerTransform.position
                - agentTransform.position).sqrMagnitude <= searchRadius.Value * searchRadius.Value ? BehaviourResult.Success : BehaviourResult.Fail;
        }
        #endregion
    }
}

