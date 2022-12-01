using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;
using Inventory;

public class Portal : Collidable
{
    public InventoryController inventoryCtrl;
    public AgentWeapon weaponSystem;
    protected override void OnCollider2D(Collider2D coll)
    {
        if (coll.name == "statue") 
        {
            GameManager.instance.SaveState();
            inventoryCtrl.SaveToJson();
            weaponSystem.SavaEquippedWeapon();
            SceneManager.LoadScene(2);
            SceneManager.sceneLoaded += GameManager.instance.LoadState;
        }
    }
}
