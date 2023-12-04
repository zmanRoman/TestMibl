using System;
using Abstract;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Player : MoveController
{
    public event Action Collision;
    [SerializeField] private ParticleSystem explosion;
    private Joystick joystick;
    
    public override void Init(float speed)
    {
        Rigidbody = GetComponent<Rigidbody>();
        Speed = speed;
    }

    public void InitJoystick(Joystick joystick)
    {
        this.joystick = joystick;
    }

    public void CollisionDetected()
    {
        Collision?.Invoke();
        explosion.Play();
    }
    
    private void Update()
    {
        if (joystick.Speed > 0f)
        {
            Vector3 direction = new Vector3(joystick.Direction.x, 0, joystick.Direction.y);
            Move(direction, Speed, Rigidbody);
        }
        else
        {
            Stop(Rigidbody);
        }
    }
}
