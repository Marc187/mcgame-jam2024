using UnityEngine;

public class SpinTerrain : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Rotate(0f, speed, 0f, Space.Self);
    }
}

