using Inventory.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    [SerializeField]
    private EquippableItemSO weapon;
    
    [SerializeField]
    private InventorySO inventoryData;

    [SerializeField]
    private List<ItemParameter> parametersToModify, itemCurrentState;
    int tempWeaponLevel;
    private void Start()
    {
        tempWeaponLevel = GameManager.instance.weapon.weaponLevel;
    }
    

    public void SetWeapon(EquippableItemSO weaponItemSO, List<ItemParameter> itemState)
    {
        if (weapon != null)
        {
            inventoryData.AddItem(weapon, 1, itemCurrentState);
        }

        this.weapon = weaponItemSO;
        this.itemCurrentState = new List<ItemParameter>(itemState);
        GameManager.instance.weapon.spriteRenderer.sprite = weaponItemSO.ItemImage;
        GameManager.instance.weapon.damage[4] = ((int)weaponItemSO.DefaultParametersList[1].value);
        GameManager.instance.weapon.weaponLevel = 4;
    }

    
    private void FixedUpdate()
    {
        if (GameManager.instance.weapon.hit == true)
        {
            GameManager.instance.weapon.hit = false;
            ModifyParameters();
        }

    }

    public void ModifyParameters()
    {
        foreach (var parameter in parametersToModify)
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
                    GameManager.instance.weapon.weaponLevel = tempWeaponLevel;
                    GameManager.instance.weapon.spriteRenderer.sprite = GameManager.instance.weaponSprites[tempWeaponLevel];                    
                }
            }
        }
        
    }
}