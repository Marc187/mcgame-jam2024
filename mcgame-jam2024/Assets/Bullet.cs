using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction = new Vector3(0f, 0f, 0f);


    void Start()
    {
        Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction;
    }

    private void OnTriggerEnter(Collider collision)
    {
        // Check if the collision involves the player and a plane
        if (collision.tag == "Enemy")
        {
            Debug.Log("yes");
            collision.gameObject.GetComponent<SC_NPCEnemy>().ApplyDamage(10f);
        }
    }
}
