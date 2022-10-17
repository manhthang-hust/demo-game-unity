using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    // Experience
    public int xpValue;


    //Logic
    public float triggerLenght;
    public float chaseLenght;
    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;

    //Hitbox
    public ContactFilter2D filter;
    public BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];


    protected override void Start()
    {
        base.Start();
        hitbox = transform.GetComponent<BoxCollider2D>();
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
    }


    private void FixedUpdate()
    {
        
        if (Vector3.Distance(playerTransform.position, startingPosition) < chaseLenght)
        {
            chasing = Vector3.Distance(playerTransform.position, startingPosition) < triggerLenght;
            if (chasing)
            {
                if (!collidingWithPlayer)
                {
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }
            }
            else
            {
                UpdateMotor(startingPosition - transform.position);
            }
                
        }
       else
        {
            UpdateMotor(startingPosition - transform.position);
            chasing = false;
        }

        //// Check for overlaps
        //collidingWithPlayer = false;
        //boxCollider.OverlapCollider(filter, hits);
        //for (int i = 0; i < hits.Length; i++)
        //{
        //    if (hits[i] == null)
        //        continue;


        //    if(hits[i].name == "Player")
        //    {
        //        collidingWithPlayer = true;
        //        Debug.Log("chase");
        //    }

        //    OnCollider2D(hits[i]);

        //    hits[i] = null;


        //}


        UpdateMotor(Vector3.zero);
    }
    //protected override void Death()
    //{
    //    Destroy(gameObject);
    //    GameManager.instance.experience += xpValue;
    //}

    //protected virtual void OnCollider2D(Collider2D coll)
    //{
    //    Debug.Log(coll.name);
    //}





    public float Health
    {
        set
        {
            health = value;
            if (health <= 0)
            {
                Defeated();
            }
        }
        get
        {
            return health;
        }
    }
    public float health = 2f;
    
    public void Defeated()
    {
        Destroy(gameObject);
    }

    public float damageMonster = 1f;
    
}
