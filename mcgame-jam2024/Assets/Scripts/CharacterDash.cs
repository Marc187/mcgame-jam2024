using UnityEngine;

public class CharacterDash : MonoBehaviour
{
    public float dashForce = 10f; // The force of the dash
    public float dashDuration = 0.2f; // Duration of the dash
    private Rigidbody rigidbodyPerso;
    private bool isDashing;
    private float dashTimer;

    private void Start()
    {
        rigidbodyPerso = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isDashing)
        {
            StartDash();
        }

        if (isDashing)
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0)
            {
                isDashing = false;
                rigidbodyPerso.velocity = new Vector3(0, rigidbodyPerso.velocity.y, 0); // Stop horizontal dash movement
            }
        }
    }

    private void StartDash()
    {
        isDashing = true;
        dashTimer = dashDuration;
        Vector3 dashDirection = transform.forward; // Dash in the direction the character is currently facing

        // Apply the dash force
        rigidbodyPerso.AddForce(dashDirection * dashForce, ForceMode.VelocityChange);
    }
}
