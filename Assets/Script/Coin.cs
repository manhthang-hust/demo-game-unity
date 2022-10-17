using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collidable
{
    protected override void OnCollider2D(Collider2D coll)
    {
        if (coll.name == "Coin")
            Debug.Log("+ 5 coin");

    }
}
