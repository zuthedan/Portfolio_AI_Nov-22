using UnityEngine;

namespace Behaviour
{
    public class ChangeVisibilityNode : Node
    {
        #region attributes
        private MeshRenderer meshRenderer;
        private Bool isVisible;
        #endregion

        #region constructors
        public ChangeVisibilityNode(MeshRenderer meshRenderer, Bool isVisible)
        {
            this.meshRenderer = meshRenderer;
            this.isVisible = isVisible;
        }
        #endregion

        #region methods
        public override BehaviourResult Evaluate()
        {
            isVisible.Value = (meshRenderer.enabled =! meshRenderer.enabled);
            
            return BehaviourResult.Success;
        }
        #endregion
    }
}
