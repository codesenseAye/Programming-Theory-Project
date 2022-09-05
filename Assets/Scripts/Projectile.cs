using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] GameObject particleEffect;
    private float creationTime;
    public float timeToDespawn = 5;

    public abstract void DoDamage(GameObject hit);

    private void Start()
    {
        creationTime = Time.realtimeSinceStartup;
    }

    protected void Hit(GameObject obj)
    {
        // do damage or something idk
        // not necessary to do for this project

        DoDamage(obj);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            Hit(collision.gameObject);
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
