<<<<<<< HEAD
=======
using System.Collections;
using System.Collections.Generic;
>>>>>>> 7ffc2ab27ec4dc5d1835e7d80e522af9a5219d43
using UnityEngine;

public class CamFollow : MonoBehaviour
{
<<<<<<< HEAD
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

=======
    public Transform target;
    public float offsetZ = -3;

    public float smoothX;

    private void LateUpdate()
    {
        transform.position = new Vector3
           (Mathf.Lerp(transform.position.x, target.transform.position.x, smoothX * Time.deltaTime), transform.position.y, target.transform.position.z + offsetZ);
    }
}
>>>>>>> 7ffc2ab27ec4dc5d1835e7d80e522af9a5219d43
