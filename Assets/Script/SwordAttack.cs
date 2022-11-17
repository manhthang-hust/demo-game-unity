using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Animator anim;
    public int[] damage = { 1, 2, 3, 4, 5};
    public bool hit = false;
    public int weaponLevel = 0;
    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public enum AttackDirection
    {
        left, right
    }

    public AttackDirection attackDirection;

    public Collider2D swordCollider;
    Vector2 rightattackOffset;


    private void Start()
    {
        anim = GetComponent<Animator>();
        rightattackOffset = transform.position;
    }

    public void Attack()
    {
        
        switch (attackDirection)
        {
            case AttackDirection.left:
                AttackLeft();
                break;
            case AttackDirection.right:
                AttackRight();
                break;
        }
    }

    public void AttackRight()
    {
        swordCollider.enabled = true;
        anim.SetTrigger("Swing");
    }
    public void AttackLeft()
    {
        swordCollider.enabled = true;
        anim.SetTrigger("Swing");
    }
    public void StopAttack()
    {
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.Health -= damage[weaponLevel];
                hit = true;
            }
        }
    }

    public void UpgradeWeapon()
    {
        weaponLevel++;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];
    }
    public void SetWeaponLevel(int level)
    {
        weaponLevel = level;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];
    }
}
