using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];
    public Sprite Player;
    public Vector3 moveDelta;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        
    }



    protected virtual void FixedUpdate()
    {

        //Collision work
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;


            OnCollider2D(hits[i]);


            hits[i] = null;

            
        }

    }

    protected virtual void OnCollider2D(Collider2D coll)
    {
        //Debug.Log(coll.name);
        
    }

}
