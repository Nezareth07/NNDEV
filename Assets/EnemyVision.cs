using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public Transform player;
    public float viewDistance = 10f;
    public float viewAngle = 90f;
    public float timeToDetect = 1.5f;
    public float timeToForget = 3f;
    public Color normalColor = Color.green;
    public Color alertColor = Color.red;
    private Renderer rend;
    private float detection;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (CanSeePlayer())
        {
            detection += Time.deltaTime / timeToDetect;
        }
        else
        {
            detection -= Time.deltaTime / timeToForget;
        }

        detection = Mathf.Clamp01(detection);
        rend.material.color = Color.Lerp(normalColor, alertColor, detection);
    }

    bool CanSeePlayer()
    {
        Vector3 toPlayer = player.position - transform.position;

        if (toPlayer.magnitude > viewDistance)
        {
            return false;
        }

        float angle = Vector3.Angle(transform.forward, toPlayer);
        if (angle > viewAngle / 2f)
        {
            return false;
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, toPlayer.normalized, out hit, viewDistance))
        {
            return hit.transform == player;
        }

        return false;
    }
}