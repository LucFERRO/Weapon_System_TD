using UnityEngine;

public class ScheduledDestruction : MonoBehaviour
{
    public float time = 1f;

    private void Start()
    {
        Destroy(gameObject, time);
    }
}
