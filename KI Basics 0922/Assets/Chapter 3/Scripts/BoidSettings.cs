using UnityEngine;

[CreateAssetMenu(menuName ="BoidSettings")]
public class BoidSettings : ScriptableObject
{
    [SerializeField]
    private float alignment, cohesion, separation, target;

    public float Alignment => alignment;
    public float Cohesion => cohesion;
    public float Separation => separation;
    public float Target => target;
}
