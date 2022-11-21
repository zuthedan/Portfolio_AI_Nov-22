using UnityEngine;

namespace Behaviour
{
    public class OutOfPlayerViewNode : Node
    {
        #region attributes
        private Float playerFov;
        private Transform playerTransform;
        private Transform otherTransform;
        #endregion

        #region constructors
        public OutOfPlayerViewNode(Float playerFov, Transform playerTransform, Transform otherTransform)
        {
            this.playerFov = playerFov;
            this.playerTransform = playerTransform;
            this.otherTransform = otherTransform;
        }
        #endregion

        #region methods
        public override BehaviourResult Evaluate()
        {
            return result = (Vector3.Angle((otherTransform.position - playerTransform.position),playerTransform.forward) > playerFov*0.5f)? BehaviourResult.Success:BehaviourResult.Fail;
        }
        #endregion
    }
}
