using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// a fight has missiles that track the mouse (good enough to have have a special ability)
// a fighter cannot reload
public class Fighter : Plane
{
    protected new float actionDelay = 0.5f;

    private void Update()
    {
        base.CheckAction();
        base.actionDelay = actionDelay;
    }
}
