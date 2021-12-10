using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform LipManager;
    private float cameraOffset;
    float offset = -6.0f;

    void Start()
    {
        cameraOffset = offset;
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, LipManager.GetChild(0).position.z + cameraOffset);
    }
}

