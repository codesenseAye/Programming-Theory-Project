using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// POLYMORPHISM
public class Missile : Projectile
{
    [SerializeField] int speed = 150;

    protected override void DoDamage(GameObject hit)
    {
        // not gonna do anything with this yet
        // concept is there and it would be easy to implement from here
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Camera cam = Camera.main;

        Ray r = cam.ScreenPointToRay(mousePos, Camera.MonoOrStereoscopicEye.Mono);

        Vector3 movementDir = r.direction;
        Debug.Log(movementDir);

        transform.LookAt(transform.position + movementDir);
        transform.Translate(movementDir * Time.deltaTime * speed, Space.World);
        transform.rotation *= Quaternion.Euler(90, 0, 0);
    }
}
