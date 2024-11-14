using UnityEngine;

public class CameraBehavior : MonoBehaviour {
    private Transform _target;
    public Vector3 CamOffset = new Vector3(0f, 0f, 7); // Adjust as needed for your preferred view

    void Start() 
    {
        _target = GameObject.Find("FishPlayer").transform;
    }

    void LateUpdate() 
    {
        // Position the camera at the target's offset position
        this.transform.position = _target.TransformPoint(CamOffset);

        // Make the camera look directly at the target
        this.transform.LookAt(_target);
    }
}