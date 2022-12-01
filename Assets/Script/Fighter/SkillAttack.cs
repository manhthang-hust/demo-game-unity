using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAttack : MonoBehaviour
{
    public Transform firePosition;
    public GameObject projectile;
    private float cooldown = 3f;
    private float lastSkill;

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R) && GameManager.instance.player.level == 1)
        {
            if (Time.time - lastSkill > cooldown)
            {
                Instantiate(projectile, firePosition.position, firePosition.rotation);
                lastSkill = Time.time;
            }
        }
    }
}
