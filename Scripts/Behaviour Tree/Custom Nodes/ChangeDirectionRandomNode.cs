using UnityEngine;

namespace Behaviour
{
    public class ChangeDirectionRandomNode : Node
    {
        #region attributes
        private Transform agentTransform;
        private Float movementStopTime;
        #endregion

        #region constructors
        public ChangeDirectionRandomNode(Transform agentTransform, Float movementStopTime)
        {
            this.agentTransform = agentTransform;
            this.movementStopTime = movementStopTime;
        }
        #endregion

        #region methods
        public override BehaviourResult Evaluate()
        {
            agentTransform.rotation = Quaternion.Euler(agentTransform.rotation.eulerAngles + new Vector3(0f, Random.Range(-45, 45), 0f));
            movementStopTime.Value = Time.time + Random.Range(0.5f, 1.5f);

            return BehaviourResult.Success;
        }
        #endregion
    }
}
