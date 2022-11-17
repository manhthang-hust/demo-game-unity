using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    // Experience
    public int xpValue;
    public int damageMonster;

    //Logic
    public float triggerLenght;
    public float chaseLenght;
    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;
    private float lastBite;
    private float cooldown = 1f;

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
        UpdateMotor(Vector3.zero);
    }

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
        GameManager.instance.experience += 3;
        GameManager.instance.ShowText("+ 3 xp", 24, Color.magenta, transform.position, Vector3.up * 25, 1.5f);       
    }


    // deal damage
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && GameManager.instance.player.gameActive == 0)
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                if (Time.time - lastBite > cooldown)
                {
                    lastBite = Time.time;
                    GameManager.instance.player.HP -= damageMonster;                   
                    GameManager.instance.ShowText("-" + damageMonster.ToString() + " HP", 20, Color.red, transform.position, Vector3.up * 10, 1.5f);                   
                }
            }

        }
    }
}
