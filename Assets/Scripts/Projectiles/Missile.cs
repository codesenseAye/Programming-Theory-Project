using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Projectile
{
    [SerializeField] int speed = 50;

    public override void DoDamage(GameObject hit)
    {
        // not gonna do anything with this yet
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.current.ScreenToWorldPoint(mousePos, Camera.MonoOrStereoscopicEye.Mono);

        Vector3 movementDir = (mousePos - Camera.current.transform.position).normalized;

        transform.Translate(movementDir * Time.deltaTime * speed, Space.Self);

    }
}
