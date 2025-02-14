using UnityEngine;

public class OutOfBoundsCheck : MonoBehaviour
{
    [SerializeField] private float zLimit = -10f;

    void Update()
    {
        if(transform.position.z < zLimit)
        {
            Destroy(gameObject);
        }
    }
}
