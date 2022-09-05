using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// a bomber can go up/down like a quadcopter?
// a bomber cannot reload
// INHERITANCE
public class Bomber : Plane
{
    [SerializeField] const int quadSpeed = 10;

    private void Update()
    {
        base.CheckAction();

        float quad = Input.GetAxis("BomberQuad");
        transform.Translate(Vector3.up * quadSpeed * quad * Time.deltaTime);
    }
}
