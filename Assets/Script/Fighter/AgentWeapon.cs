using Inventory.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AgentWeapon : MonoBehaviour
{
    [SerializeField]
    private EquippableItemSO weapon;
    
    [SerializeField]
    private InventorySO inventoryData;

    [SerializeField]
    private List<ItemParameter> parametersToModify, itemCurrentState;

    private bool loadJson;

    private void Start()
    {
        loadJson = false;
    }

    public void SetWeapon(EquippableItemSO weaponItemSO, List<ItemParameter> itemState)
    {
        if (weapon != null)
        {
            inventoryData.AddItem(weapon, 1, itemCurrentState);
        }

        this.weapon = weaponItemSO;
        this.itemCurrentState = new List<ItemParameter>(itemState);
        GameManager.instance.tempWeaponLevel = GameManager.instance.weapon.weaponLevel;
        GameManager.instance.weapon.spriteRenderer.sprite = weaponItemSO.ItemImage;
        GameManager.instance.weaponSprites[4] = weaponItemSO.ItemImage;
        GameManager.instance.weapon.damage[4] = ((int)weaponItemSO.DefaultParametersList[1].value);
        GameManager.instance.weapon.weaponLevel = 4;
    }

    public void SavaEquippedWeapon()
    {
        GameManager.instance.equippedWeapon = weapon;
        GameManager.instance.equippedWeaponState = itemCurrentState;
    }
        
    private void FixedUpdate()
    {
        if (GameManager.instance.weapon.hit == true)
        {
            GameManager.instance.weapon.hit = false;
            ModifyParameters();
        }
        if (SceneManager.GetActiveScene().buildIndex == 2 && loadJson == false)
        {
            weapon = GameManager.instance.equippedWeapon;
            itemCurrentState = GameManager.instance.equippedWeaponState;
            if (weapon != null) GameManager.instance.weapon.damage[4] = ((int)weapon.DefaultParametersList[1].value);
            loadJson = true;
        }
    }

    public void ModifyParameters()
    {
        foreach (var parameter in parametersToModify)
        {
            if (itemCurrentState != null)
            {
                if (itemCurrentState.Contains(parameter))
                {
                    int index = itemCurrentState.IndexOf(parameter);
                    float newValue = itemCurrentState[index].value + parameter.value;
                    itemCurrentState[index] = new ItemParameter
                    {
                        itemParameter = parameter.itemParameter,
                        value = newValue
                    };
                    if (newValue <= 0)
                    {
                        weapon = null;
                        GameManager.instance.weapon.weaponLevel = GameManager.instance.tempWeaponLevel;
                        GameManager.instance.weapon.spriteRenderer.sprite = GameManager.instance.weaponSprites[GameManager.instance.tempWeaponLevel];
                        itemCurrentState = null;
                    }
                }
            }
        }
        
    }
}