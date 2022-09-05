using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// POLYMORPHISM
public class Bullet : Projectile
{
    [SerializeField] int speed = 50;

    private void Start()
    {
        transform.rotation *= Quaternion.Euler(Vector3.up * 90);
    }

    protected override void DoDamage(GameObject hit)
    {
        // not gonna do anything with this yet
        // concept is there and it would be easy to implement from here
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
    }
}
