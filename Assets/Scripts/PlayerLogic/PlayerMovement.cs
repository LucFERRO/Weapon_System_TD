using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private Vector3 boundsSize = Vector3.one;
    
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 desiredMove = new Vector3(h, 0f, v);
        desiredMove = Vector3.ClampMagnitude(desiredMove, 1f);

        Vector3 targetPos = rb.position + desiredMove * (speed * Time.deltaTime);
        targetPos.x = Mathf.Clamp(targetPos.x, -boundsSize.x * 0.5f, boundsSize.x * 0.5f);
        targetPos.z = Mathf.Clamp(targetPos.z, -boundsSize.z * 0.5f, boundsSize.z * 0.5f);

        rb.MovePosition(targetPos); 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(Vector3.zero, boundsSize);
    }
}