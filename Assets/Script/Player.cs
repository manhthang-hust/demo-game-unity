using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Mover
{
    

    public Animator anim;

    //public bool alive;
    public bool beaten;
    private Vector3 move;
    

    //public int damagePoint = 1;
    private float cooldown = 1f;
    private float lastSwing;
    private float lastBite;
    public float Speed;
    //public float attackRange;
    //public RaycastHit2D hitmonster;

    public SwordAttack swordAttack;
    public float HP = 5f;
    public bool alive = true;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (move == Vector3.zero) Speed = 0; else Speed = 1;
        anim.SetFloat("Speed", Speed);
        anim.SetBool("Beaten", beaten);
        anim.SetBool("Alive", alive);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        float a = Input.GetAxisRaw("Attack");

        move = new Vector3(x, y, 0);
        
        

        

        // Death
        if (HP > 0)
        {
            UpdateMotor(new Vector3(x, y, 0));
        }
        else
        {
            alive = false;
            //rigid.simulated = false;
        }



        // Attack
        if (a == 1)
        {
            if(Time.time - lastSwing > cooldown)
            {

                lastSwing = Time.time;
                Swing();
            }
        }


        anim.SetFloat("Attack", a);



        //Beaten
        beaten = false;
        //if (ReceiveDamage != null)


    }


    //protected override void Death()
    //{
        
    //}

    //protected override void ReceiveDamage(Damage dmg)
    //{
    //    base.ReceiveDamage(dmg);

    //}


    public void Swing()
    {
        
        //Debug.Log("Swing");
        if (rightDirection == false)
        {
            swordAttack.attackDirection = SwordAttack.AttackDirection.left;
            //Debug.Log("Attack left");
            swordAttack.AttackLeft();
            

        }
        else
        {
            swordAttack.attackDirection = SwordAttack.AttackDirection.right;
            //Debug.Log("Attack right");
            swordAttack.AttackRight();
        }
    }
    public void EndSwordAttack()
    {
        swordAttack.StopAttack();
    }



    public float damageMonster = 1f;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            // deal damage
            
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                if (Time.time - lastBite > cooldown)
                {
                    //Debug.Log("bite");
                    lastBite = Time.time;
                    HP -= damageMonster;
                    beaten = true;
                }
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Heal")
        {
            // heal

            Heal heal = other.GetComponent<Heal>();

            if (heal != null)
            {
                if (HP < 5)
                {
                    HP = 5;
                }
            }

        }
    }
}

