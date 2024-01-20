using UnityEngine;

public class Spin2 : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Rotate(0f, 0f, speed, Space.Self);
    }
}

