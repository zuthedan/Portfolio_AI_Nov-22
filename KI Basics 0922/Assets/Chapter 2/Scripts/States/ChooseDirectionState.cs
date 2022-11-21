using UnityEngine;

public class ChooseDirectionState : State
{
    public ChooseDirectionState(Entity entity) : base(entity) { }

    public override void OnStateEnter()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        entity.MovementDirection = new Vector3(randomDirection.x,0,randomDirection.y);

        entity.CurrentWalkTime = 0f;
        entity.MaxWalkTime = Random.Range(5f, 10f);
    }
}
