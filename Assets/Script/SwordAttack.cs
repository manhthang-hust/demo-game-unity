using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public float damage = 1f;
    public enum AttackDirection
    {
        left, right
    }

    public AttackDirection attackDirection;

    public Collider2D swordCollider;
    Vector2 rightattackOffset;


    private void Start()
    {
        
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
        //transform.position = rightattackOffset;
    }
    public void AttackLeft()
    {
        swordCollider.enabled = true;
        //transform.position = new Vector3(rightattackOffset.x * -1, rightattackOffset.y);
    }
    public void StopAttack()
    {
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Collide");
        if (other.tag == "Enemy")
        {
            //Debug.Log("colide enemy");
            // deal damage
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                //Debug.Log("damage enemy");
                enemy.Health -= damage;
            }

        }
    }
}
