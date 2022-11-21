using UnityEngine;

namespace Behaviour
{
    public class CalculateChanceNode : Node
    {
        #region attributes
        private Float threshold;
        #endregion

        #region constructors
        /// <param name="percentage"> needs to be between 0.0f and 1.0f </param>
        public CalculateChanceNode(Float percentage)
        {
            threshold = percentage;
        }
        #endregion

        #region methods
        public override BehaviourResult Evaluate()
        {
            return Random.Range(0.0f, 1.0f) < threshold.Value? BehaviourResult.Success:BehaviourResult.Fail;
        }
        #endregion
    }
}

