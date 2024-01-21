using UnityEngine;

public class PlayerPlaneCollision : MonoBehaviour
{
    public PlayerStats playerStats;
    // This function is called when the player collides with another object
    private void OnTriggerEnter(Collider collision)
    {
        // Check if the collision involves the player and a plane
        if (collision.tag == "Player")
        {
            playerStats.DecreaseHealth(999999f);
        }
    }
}
