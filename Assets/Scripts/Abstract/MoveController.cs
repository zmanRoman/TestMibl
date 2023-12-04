using UnityEngine;

namespace Abstract
{
    public abstract class MoveController : MonoBehaviour
    {
        protected float Speed;
        protected Rigidbody Rigidbody;
        public abstract void Init(float speed);

        protected void Move(Vector3 direction, float speed, Rigidbody rigidbody)
        {
            Vector3 movement = new Vector3(direction.x, 0f, direction.z).normalized;
            rigidbody.velocity = new Vector3(movement.x, 0f, movement.z) * speed;
        }

        protected void Stop(Rigidbody rigidbody)
        {
            rigidbody.velocity = Vector3.zero;
        }
    }
}