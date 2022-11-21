using UnityEngine;

public class FleeingState : State
{
    public FleeingState(Entity entity) : base(entity) { }

    public override void OnStateEnter()
    {
        entity.Agent.speed = entity.FleeingSpeed;
        entity.MeshRenderer.material.color = Color.green;
    }

    public override void OnStateUpdate()
    {
        entity.Agent.destination = 
            entity.transform.position + (entity.transform.position-entity.Enemy.position).normalized;
    }

    public override void OnStateExit()
    {
        entity.Agent.speed = entity.WalkingSpeed;
        entity.MeshRenderer.material.color = Color.white;
    }

}
