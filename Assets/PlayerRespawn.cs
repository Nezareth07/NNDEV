using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 startPosition;
    private Quaternion startRotation;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    public void Respawn()
    {
        controller.enabled = false;
        transform.position = startPosition;
        transform.rotation = startRotation;
        controller.enabled = true;
    }
}