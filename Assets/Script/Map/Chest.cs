using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Sprite emptyChest;
    public Collider2D chestCollider;

    private void Start()
    {
        chestCollider.enabled = true;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                GameManager.instance.ShowText("+ 40 pesos", 24, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
                GameManager.instance.pesos += 40;
                GetComponent<SpriteRenderer>().sprite = emptyChest;
                chestCollider.enabled = false;
            }
        }
    }
   
}
