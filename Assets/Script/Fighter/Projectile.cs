using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed;
    public Rigidbody2D rigid;
    private float lifetime;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        SetDirection();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.Health -= 3;
                enemy.beHit = true;
                Destroy(gameObject);
            }
        }
        if (other.tag == "Collision")
        {
            Destroy(gameObject);
        }
    } 

    private void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime > 1.25) Destroy(gameObject);
    }

    private void SetDirection()
    {
        if (GameManager.instance.player.rightDirection == true)
        {
            rigid.velocity = transform.right * projectileSpeed;
        }
        else
        {
            Vector3 flip = rigid.transform.localScale;
            flip.x *= -1;
            rigid.transform.localScale = flip;
            rigid.velocity = transform.right * projectileSpeed * -1;
        }
    }
}

