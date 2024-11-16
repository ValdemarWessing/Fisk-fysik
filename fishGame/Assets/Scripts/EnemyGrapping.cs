using UnityEngine;

public class EnemyGrapping : MonoBehaviour
{
    public float dragMultiplier = 10;
    public float dashIncrease = 5;

    private void OnTriggerEnter(Collider other)
    {
        FishController fishController = other.GetComponent<FishController>();

        if (fishController != null)
        {
            // Increase Drag
            fishController.GetComponent<Rigidbody>().linearDamping *= dragMultiplier;
            // Increase the dash speed
            fishController.boostMultiplier *= dashIncrease;
        }
    }
     private void OnTriggerExit(Collider other)
    {
        FishController fishController = other.GetComponent<FishController>();

        if (fishController != null)
        {
            // Increase Drag
            fishController.GetComponent<Rigidbody>().linearDamping /= dragMultiplier;
            // Increase the dash speed
            fishController.boostMultiplier /= dashIncrease;

        }
    }
    

}
