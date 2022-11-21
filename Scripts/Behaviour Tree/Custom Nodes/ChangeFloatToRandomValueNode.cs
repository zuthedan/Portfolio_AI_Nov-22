using UnityEngine;

namespace Behaviour
{
    public class ChangeFloatToRandomValueNode : Node
    {
        #region attributes
        private Float value;
        private float min, max;
        #endregion

        #region constructors
        public ChangeFloatToRandomValueNode(Float value, float min, float max)
        {
            this.value = value;
            this.min = min;
            this.max = max;
        }
        #endregion

        #region methods
        public override BehaviourResult Evaluate()
        {
            value.Value = Random.Range(min, max);
            return BehaviourResult.Success;
        }
        #endregion
    }
}
