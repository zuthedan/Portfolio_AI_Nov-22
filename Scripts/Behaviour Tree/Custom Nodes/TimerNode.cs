using UnityEngine;

namespace Behaviour
{
    public class TimerNode : Node
    {
        #region attributes
        private Float timer;
        private float currentTime;
        #endregion

        #region constructors
        public TimerNode(Float timer)
        {
            this.timer = timer;
        }
        #endregion

        #region methods
        public override BehaviourResult Evaluate()
        {
            currentTime +=Time.deltaTime;

            if(currentTime >= timer.Value)
            {
                currentTime -= timer.Value;
                return BehaviourResult.Success;
            }

            return BehaviourResult.Fail;
        }
        #endregion
    }
}
