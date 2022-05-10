using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class PlayerMovementSystem : IEcsRunSystem
{
    private EcsFilter<TransformRef, RigidbodyRef, Characteristics> _filter;

    // This function is taken from here: https://forum.unity.com/threads/quaternion-smoothdamp.793533/
    private static Quaternion SmoothDampQuaternion(Quaternion current, Quaternion target, ref Vector3 currentVelocity, float smoothTime)
    {
        Vector3 c = current.eulerAngles;
        Vector3 t = target.eulerAngles;
        return Quaternion.Euler(
            Mathf.SmoothDampAngle(c.x, t.x, ref currentVelocity.x, smoothTime),
            Mathf.SmoothDampAngle(c.y, t.y, ref currentVelocity.y, smoothTime),
            Mathf.SmoothDampAngle(c.z, t.z, ref currentVelocity.z, smoothTime)
        );
    }

    public void Run() {
        foreach (var i in _filter) {
            var transform = _filter.Get1(i).Transform;
            var rigidbody = _filter.Get2(i).Rigidbody;
            var speedTransition =  _filter.Get3(i).GetSpeedMovement();
            var speedRotation = _filter.Get3(i).GetSpeedRotation();
            
            Vector3 velocityRotation = Vector3.zero;
            const float velocityEps = 1e-5f;

            rigidbody.velocity = speedTransition * Vector3.Normalize(new Vector3 (Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical")));
            transform.position = new Vector3 (transform.position.x, 0.0f, transform.position.z);
            transform.rotation = Quaternion.Euler(0.0f, transform.rotation.eulerAngles.y, 0.0f);
            if (Vector3.Magnitude(rigidbody.velocity) > velocityEps) {
                Quaternion targetRotation = Quaternion.LookRotation(rigidbody.velocity, Vector3.up);
                transform.rotation = SmoothDampQuaternion(transform.rotation, targetRotation, ref velocityRotation, 1.0f / speedRotation);
            }
        }
    }
}
