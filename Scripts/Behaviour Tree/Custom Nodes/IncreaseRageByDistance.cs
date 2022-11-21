using UnityEngine;

namespace Behaviour
{
    public class IncreaseRageByDistance : Node
    {
        #region attributes
        private Transform agentTransform;
        private Transform playerTransform;
        private Float searchRadius;
        private Float rage;
        private Float rageDistanceScaleFactor;
        #endregion

        #region constructors
        public IncreaseRageByDistance(Transform agentTransform, Transform playerTransform, Float searchRadius, Float rage, Float rageDistanceScaleFactor)
        {
            this.agentTransform = agentTransform;
            this.playerTransform = playerTransform;
            this.searchRadius = searchRadius;
            this.rage = rage;
            this.rageDistanceScaleFactor = rageDistanceScaleFactor;
        }
        #endregion

        #region methods
        public override BehaviourResult Evaluate()
        {
            Vector3 distanceVector = agentTransform.position - playerTransform.position;
            float squareDistance = distanceVector.sqrMagnitude;

            if(squareDistance>searchRadius*searchRadius)return result = BehaviourResult.Fail;

            squareDistance = (distanceVector + distanceVector / distanceVector.magnitude).sqrMagnitude;
            rage.Value += Time.deltaTime*rageDistanceScaleFactor/(squareDistance);
            return result = BehaviourResult.Success;
        }
        #endregion
    }
}
