using UnityEngine;

public class PushBodies : MonoBehaviour
{
    public float pushPower = 2f;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic)
        {
            return;
        }

        if (hit.moveDirection.y < -0.3f)
        {
            return;
        }

        Vector3 pushDirection;

        if (Mathf.Abs(hit.moveDirection.x) > Mathf.Abs(hit.moveDirection.z))
        {
            pushDirection = new Vector3(Mathf.Sign(hit.moveDirection.x), 0f, 0f);
        }
        else
        {
            pushDirection = new Vector3(0f, 0f, Mathf.Sign(hit.moveDirection.z));
        }

        body.linearVelocity = new Vector3(
            pushDirection.x * pushPower,
            body.linearVelocity.y,
            pushDirection.z * pushPower);
    }
}