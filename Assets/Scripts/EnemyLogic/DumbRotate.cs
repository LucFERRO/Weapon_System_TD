using UnityEngine;

public class DumbRotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 220f;

    private void Update()
    {
        transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
    }
}
