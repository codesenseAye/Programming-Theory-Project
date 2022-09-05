using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    [SerializeField] int speed = 50;

    public override void DoDamage(GameObject hit)
    {
        // not gonna do anything with this yet
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
    }
}
