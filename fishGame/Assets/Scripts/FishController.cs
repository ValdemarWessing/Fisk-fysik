using UnityEngine;

public class FishController : MonoBehaviour 
{
    public float moveSpeed = 1f;
    public float boostMultiplier = 4f; // How much faster the boost is
    public float boostDuration = 0.2f; // Duration of the boost
    public float boostCooldown = 2f; // Cooldown period

    private Rigidbody rb;
    private bool isBoosting = false; // Tracks if boost is active
    private float cooldownTimer = 0f; // Timer to track cooldown

      // Method to end the boost
    private void EndBoost() 
    {
        isBoosting = false;
    }

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update() 
    {
        // Decrease cooldown timer
        if (cooldownTimer > 0) 
        {
            cooldownTimer = cooldownTimer - Time.deltaTime;
        }

        // Activate boost if Space is pressed and cooldown is over
        if (Input.GetKeyDown(KeyCode.Space) && cooldownTimer <= 0) 
        {
            isBoosting = true;
            cooldownTimer = boostCooldown; // Set cooldown timer
            Invoke("EndBoost", boostDuration); // End boost after the duration
        }
    }

    void FixedUpdate() 
    {
        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement vector
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0) * moveSpeed;

        // Apply boost if active, else apply normal movement
        if (isBoosting) 
        {
            rb.AddForce(moveDirection * boostMultiplier, ForceMode.VelocityChange);
        } else 
        {
            rb.AddForce(moveDirection, ForceMode.VelocityChange);
        }
    }
}
