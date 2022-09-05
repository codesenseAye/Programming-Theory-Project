using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// a gunner can rotate 180 degrees back at their opponent
// a gunner can reload
public class Gunner : Plane
{
    private void Update()
    {
        base.CheckAction();

        if (Ammo < 1 && Input.GetKeyDown(KeyCode.R))
        {
            Ammo = DefaultAmmo;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            transform.Rotate(Vector3.up * 180);
        }
    }
}
