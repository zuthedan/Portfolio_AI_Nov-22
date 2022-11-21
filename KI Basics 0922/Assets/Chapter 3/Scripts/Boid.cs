using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    private List<Boid> neighbours;

    [SerializeField]
    private BoidSettings settings;

    private Vector3 currentVelocity, desiredVelocity;

    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float viewAgle = 60.0f;


    void Start()
    {
        neighbours = new List<Boid>();
    }

    void Update()
    {
        desiredVelocity += (target.position - transform.position).normalized * speed * settings.Target;

        desiredVelocity += Alignment();
        desiredVelocity += Cohesion();
        desiredVelocity += Separation();

        Vector3 diff = desiredVelocity - currentVelocity;
        currentVelocity += diff*Time.deltaTime;

        currentVelocity = Vector3.ClampMagnitude(currentVelocity, speed);
        transform.position += currentVelocity*Time.deltaTime;
        transform.forward = currentVelocity;
    }

    private void LateUpdate()
    {
        desiredVelocity = Vector3.zero;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Boid boid = other.GetComponent<Boid>();

    //    if (boid != null)
    //        neighbours.Add(boid);
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    Boid boid = other.GetComponent<Boid>();

    //    if(boid != null)
    //        neighbours.Remove(boid);
    //}

    private void OnTriggerStay(Collider other)
    {
        Boid boid = other.GetComponent<Boid>();
        if (boid == null) return;

        if(Vector3.Angle(transform.forward,boid.transform.position-transform.position) <viewAgle * 0.5f)
        {
            neighbours.Add(boid);
        }
    }

    /// <summary>
    /// boids move in the same direction as their neighbours
    /// </summary>
    /// <returns></returns>
    private Vector3 Alignment()
    {
        if(neighbours.Count == 0) return Vector3.zero;

        Vector3 alignment= Vector3.zero;

        for (int i = 0; i < neighbours.Count; i++)
        {
            alignment += neighbours[i].currentVelocity;
        }

        alignment/=neighbours.Count;

        return alignment.normalized * speed *settings.Alignment;
    }

    /// <summary>
    /// boids move towards the center of their neighbour positions
    /// </summary>
    /// <returns></returns>
    private Vector3 Cohesion()
    {
        if(neighbours.Count==0) return Vector3.zero;

        Vector3 center = Vector3.zero;

        for(int i = 0; i < neighbours.Count; i++)
        {
            center+=neighbours[i].transform.position;
        }

        center/=neighbours.Count;

        return center.normalized*speed*settings.Cohesion;
    }

    /// <summary>
    /// boid moves away from their neighbours
    /// </summary>
    /// <returns></returns>
    private Vector3 Separation()
    {
        if(neighbours.Count==0) return Vector3.zero;

        Vector3 direction = Vector3.zero;
        Vector3 distance;

        for(int i =0; i<neighbours.Count; i++)
        {
            distance = neighbours[i].transform.position - transform.position;
            direction += distance / distance.sqrMagnitude;
        }

        direction/=neighbours.Count;

        return -direction.normalized*speed*settings.Separation;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position+currentVelocity);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position+desiredVelocity);
    }
}
