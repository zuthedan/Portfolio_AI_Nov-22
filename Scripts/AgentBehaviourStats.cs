using System;
using UnityEngine;

[Serializable]
public class AgentBehaviourStats
{
    #region attributes
    public Transform PlayerTransform, AgentTransform;
    public Float AgentSpeed;
    public Rigidbody AgentRigidbody;
    public MeshRenderer AgentMeshRenderer;

    public Float PlayerFov;

    public Vector3 MovementDirection;
    public Float MovementStopTime;

    public Float LookAtAngle;
    public Float SearchRadius;

    public Float Rage;
    public Float RageDistanceScaleFactor;

    public Bool IsVisible;
    public Float TurnVisibleChance;
    public Float TurnInvisibleChance;
    public Float ChangeVisibilityTimer;
    #endregion
}
