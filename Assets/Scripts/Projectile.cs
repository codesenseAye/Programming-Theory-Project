using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// POLYMORPHISM
public abstract class Projectile : MonoBehaviour
{
    [SerializeField] GameObject particleEffect;
    private float creationTime;
    public float timeToDespawn = 5;

    private void Start()
    {
        creationTime = Time.realtimeSinceStartup;
    }

    protected virtual void DoDamage(GameObject obj)
    {
        // do damage or something idk
        // not necessary to do for this project
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            DoDamage(collision.gameObject);
        }
    }

    private void Update()
    {
        if (creationTime + timeToDespawn < Time.realtimeSinceStartup)
        {
            Destroy(gameObject);
        }
    }
}
