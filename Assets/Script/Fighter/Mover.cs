using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    public bool rightDirection = true;
    public BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    public RaycastHit2D hit;
    public float distance;
    public Rigidbody2D rigid;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rigid = GetComponent<Rigidbody2D>();

    }

    protected virtual void UpdateMotor(Vector3 input)
    {
        float x = Input.GetAxisRaw("Horizontal");
        // Swap sprite direction
        if (rightDirection && x < 0)
        {
            rightDirection = !rightDirection;
            FlipPlayer();
        }
        if (!rightDirection && x > 0)
        {
            rightDirection = !rightDirection;
            FlipPlayer();
        }

        //Reset MoveDelta
        moveDelta = input;

        //hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.fixedDeltaTime), LayerMask.GetMask("Actor", "Blocking"));

        hit = Physics2D.Raycast(transform.position, moveDelta, distance);

        if (hit.collider == null || hit.collider.tag != "Collision")
        {
            //Move
            transform.Translate(0, moveDelta.y * Time.fixedDeltaTime * 2, 0);
            transform.Translate(moveDelta.x * Time.fixedDeltaTime * 2, 0, 0);
        }

    }
    
    void FlipPlayer()
    {
        Vector3 flip = rigid.transform.localScale;
        flip.x *= -1;
        rigid.transform.localScale = flip;
    }

}
