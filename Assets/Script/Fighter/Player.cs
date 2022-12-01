using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : Mover
{
    public SpriteRenderer spriteRenderer;
    private Vector3 move;
    private float cooldown = 1f;
    private float lastSwing;
    private float run;
    public Slider healthSlider;
    public Slider experienceSlider;
    public SwordAttack swordAttack;
    public float HP;
    private bool alive;
    public int gameActive;
    public Animator animator;
    public bool beaten;
    public int level;
    [SerializeField]
    private AudioSource swingSoundEffect;

    // Start is called before the first frame update
    protected override void Start()
    {
        healthSlider = HUDManager.instance.healthSlider;
        experienceSlider = HUDManager.instance.experienceSlider;
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        healthSlider.maxValue = 60;
        experienceSlider.maxValue = 10;
        gameActive = 0;
        alive = true;
        if (level == 1) animator.SetTrigger("LevelUp");
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        float a = Input.GetAxisRaw("Attack");

        //Animation Parameters
        if (move == Vector3.zero)
            run = 0;
        else
            run = 1;
        animator.SetFloat("Run", run);
        animator.SetBool("Alive", alive);
        animator.SetBool("Beaten", beaten);
        beaten = false;
        
        //Update Slider
        healthSlider.value = HP;
        experienceSlider.value = GameManager.instance.experience;

        // Move
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
            gameActive = 1; //game over
            SceneManager.LoadScene(4);
        }

        // Attack
        if (a == 1)
        {
            if (Time.time - lastSwing > cooldown)
            {

                lastSwing = Time.time;
                Swing();
                swingSoundEffect.Play();
            }
        }
    }

    public void Swing()
    {
        if (rightDirection == false)
        {
            swordAttack.attackDirection = SwordAttack.AttackDirection.left;
            swordAttack.AttackLeft();
        }
        else
        {
            swordAttack.attackDirection = SwordAttack.AttackDirection.right;
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
        if (other.tag == "Princess")
        {
            Princess princess = other.GetComponent<Princess>();
            if (princess != null)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }     
        }
    }

    public void swapSprite(int skinId)
    {
        GetComponent<SpriteRenderer>().sprite = GameManager.instance.playerSprites[skinId];
        if (skinId == 1) HP += 20;
        if (HP > 60) HP = 60;
        animator.SetTrigger("LevelUp");
        level = 1;
    }

    public void LoadSpiteOnNewScence()
    {
        if (level == 1)
        {
            animator.SetTrigger("LevelUp");
        }
    }
}

