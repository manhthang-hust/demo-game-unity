using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterMenu : MonoBehaviour
{
    // Text fields
    public Text levelText, hpText, pesosText, upgradeCostText, xpText;

    // Logic
    private int currentCharacterSelection = 0;
    public Image characterSelectionSprite;
    public Image weaponSprite;
    public RectTransform xpBar;

    // Character Selection
    public void OnArrowClick(bool right)
    {
        if (right)
        {   if (GameManager.instance.experience > 10)
            {
                currentCharacterSelection++;
                if (currentCharacterSelection == GameManager.instance.playerSprites.Count)
                    currentCharacterSelection = 0;
                OnSelectionChanged();
                GameManager.instance.experience -= 10;
            }
        }
        else
        {
            currentCharacterSelection--;
            if (currentCharacterSelection < 0)
                currentCharacterSelection = GameManager.instance.playerSprites.Count - 1;
            OnSelectionChanged();
        }
    }
    private void OnSelectionChanged()
    {
        characterSelectionSprite.sprite = GameManager.instance.playerSprites[currentCharacterSelection];
        GameManager.instance.player.swapSprite(currentCharacterSelection);
    }

    //Weapon Upgrade
    public void OnClickUpgrade()
    {
        if (GameManager.instance.TryUpgradeWeapon())
            UpdateMenu();
    }

    // Update the character Information
    public void UpdateMenu()
    {
        //Weapon
        weaponSprite.sprite = GameManager.instance.weaponSprites[GameManager.instance.weapon.weaponLevel];
        if (GameManager.instance.weapon.weaponLevel == GameManager.instance.weaponPrices.Count)
            upgradeCostText.text = "MAX";
        else
            upgradeCostText.text = GameManager.instance.weaponPrices[GameManager.instance.weapon.weaponLevel].ToString();

        //Meta
        pesosText.text = GameManager.instance.pesos.ToString();
        levelText.text = ((GameManager.instance.experience)/10+1).ToString();

        //xpBar
        xpText.text = GameManager.instance.experience.ToString() + "/10";
        if (0.1f * GameManager.instance.experience <= 1) xpBar.localScale = new Vector3(0.1f * GameManager.instance.experience, 1, 1);

        hpText.text = GameManager.instance.player.HP.ToString();
    }
}
