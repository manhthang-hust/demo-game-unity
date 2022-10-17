using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    ////Public fields
    //public int hitpoint;
    //public int maxHitpoint;
    //public float pushRecoverySpeed = 0.2f;

    //// Imumity
    //protected float immuneTime = 1f;
    //protected float lastImmune;

    ////Push
    //protected Vector3 pushDirection;

    //// All fighters can RecieveDamage / Die
    //protected virtual void ReceiveDamage(Damage dmg)
    //{
    //    if(Time.time - lastImmune > immuneTime)
    //    {
    //        lastImmune = Time.time;
    //        hitpoint -= dmg.damageAmount;
    //        pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

    //        if(hitpoint <= 0)
    //        {
    //            hitpoint = 0;
    //            Death();
    //        }
    //    }
    //}
    //protected virtual void Death()
    //{
        
    //}

}
