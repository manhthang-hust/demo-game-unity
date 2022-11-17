using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Mover
{
    private SpriteRenderer spriteRenderer;

    private Vector3 move;
    private float cooldown = 1f;
    private float lastSwing;
    public float Speed;

    public SwordAttack swordAttack;
    public float HP;
    public bool alive = true;
    public int gameActive = 0;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (move == Vector3.zero) Speed = 0; else Speed = 1;
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
        }

        if (alive == false && gameActive == 0)
        {
            GameManager.instance.ShowText("GAME OVER", 20, Color.red, transform.position, Vector3.up * 25, 1.5f);
            gameActive = 1;
        }

        // Attack
        if (a == 1)
        {
            if (Time.time - lastSwing > cooldown)
            {

                lastSwing = Time.time;
                Swing();  
            }
        }
    }

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Heal")
        {
            // heal

            Heal heal = other.GetComponent<Heal>();

            if (heal != null)
            {
                if (HP < 20)
                {
                    HP += 10;
                    GameManager.instance.ShowText(" + 10 HP", 20, Color.blue, transform.position, Vector3.up * 10, 1.5f);
                }
            }

        }
    }

    public void swapSprite(int skinId)
    {
        GetComponent<SpriteRenderer>().sprite = GameManager.instance.playerSprites[skinId];
        if (skinId == 1) HP += 20;
    }
}

