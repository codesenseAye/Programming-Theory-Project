using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject? plane;
    [SerializeField] int cameraOffsetY = 25;
    [SerializeField] int cameraOffsetZ = 25;

    // Start is called before the first frame update
    void Start()
    {
        Update();   
    }

    // Update is called once per frame
    void Update()
    {
        if (plane == null)
        {
            // plane hasnt been assigned yet
            return;
        }

        Quaternion rot = plane.transform.rotation * Quaternion.Euler(Vector3.up * 90);

        Vector3 yDir = (rot * Vector3.up) * cameraOffsetY;
        Vector3 zDir = (rot * Vector3.back) * cameraOffsetZ;

        Vector3 pos = plane.transform.position + yDir + zDir;

        transform.SetPositionAndRotation(pos, rot);
    }
}
