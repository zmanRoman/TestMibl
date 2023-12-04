using Abstract;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Enemy : MoveController
{
    private Transform target;
    
    public override void Init(float speed)
    {
        Rigidbody = GetComponent<Rigidbody>();
        Speed = speed;
    }

    public void InitTarget(Transform target)
    {
        this.target = target;
    }
    
    public void Update()
    {
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Move(direction, Speed, Rigidbody);
        transform.LookAt(target);
    }
}
