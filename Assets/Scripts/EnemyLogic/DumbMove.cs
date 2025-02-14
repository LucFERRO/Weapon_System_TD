using UnityEngine;

public class DumbMove : MonoBehaviour
{
    public float speed = 1f;
    public float horizontalRange = 5f;
    public float verticalSpeed = 1f;

    private Rigidbody rb;
    private int dir = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        dir = (Random.value > 0.5f) ? -1 : 1;
    }

    private void FixedUpdate()
    {
        Vector3 targetPos = rb.position + Vector3.right * (speed * dir * Time.deltaTime);
        targetPos.z -= verticalSpeed * Time.deltaTime;

        if (targetPos.x <= -horizontalRange || targetPos.x >= horizontalRange)
        {
            dir *= -1;
            targetPos = rb.position + Vector3.right * (speed * dir * Time.deltaTime);
        }

        rb.MovePosition(targetPos);
    }
}
