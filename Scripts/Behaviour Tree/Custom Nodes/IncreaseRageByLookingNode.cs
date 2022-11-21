using UnityEngine;

namespace Behaviour
{
    public class IncreaseRageByLookingNode : Node
    {
        #region attributes
        private Transform playerTransform;
        private Transform agentTransform;
        private Float lookAtAngle;
        private Float rage;
        #endregion

        #region constructors
        public IncreaseRageByLookingNode(Transform playerTransform, Transform agentTransform, Float lookAtAngle, Float rage)
        {
            this.playerTransform = playerTransform;
            this.agentTransform = agentTransform;
            this.lookAtAngle = lookAtAngle;
            this.rage = rage;
        }
        #endregion

        #region methods
        public override BehaviourResult Evaluate()
        {

            if(Vector3.Angle(playerTransform.forward, agentTransform.position-playerTransform.position)> lookAtAngle*0.5f) return result = BehaviourResult.Fail;

            rage.Value += Time.deltaTime;
            return result = BehaviourResult.Success;
        }
        #endregion
    }
}
