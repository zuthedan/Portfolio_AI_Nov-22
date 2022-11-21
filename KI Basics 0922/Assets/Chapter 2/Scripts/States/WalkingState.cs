using UnityEngine;

public class WalkingState : State
{
    public WalkingState(Entity entity) : base(entity) { }

    public override void OnStateEnter()
    {
        entity.MeshRenderer.material.color = Color.blue;
    }

    public override void OnStateUpdate()
    {
        entity.Agent.destination = entity.transform.position + entity.MovementDirection;
        entity.CurrentWalkTime += Time.deltaTime;
    }

    public override void OnStateExit()
    {
        entity.MeshRenderer.material.color= Color.white;
    }

}
