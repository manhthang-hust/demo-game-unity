using System.Collections;
using System.Collections.Generic;
using Inventory;
using UnityEngine;
using UnityEngine.SceneManagement;
using Inventory.Model;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //Ressources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //Reference
    public Player player;
    public SwordAttack weapon;
    public FloatingTextManager floatingTextManger;
    public CanvasManager canvasManager;
    public EquippableItemSO equippedWeapon;
    public List<ItemParameter> equippedWeaponState;

    //Logic
    public int pesos;
    public int experience;
    public int tempWeaponLevel;

    private void Awake()
    {
        //SceneManager.sceneLoaded += LoadState;
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        PlayerPrefs.DeleteAll();
        instance = this;
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(canvasManager);
        player = Instantiate(Resources.Load<GameObject>("Prefabs/Player"), new Vector3(-8, -8, 0), Quaternion.identity).GetComponent<Player>(); 
        weapon = player.swordAttack;
    }

    //Player load
    public void LoadPlayerScene1(Scene s, LoadSceneMode mode)
    {
        player = Instantiate(Resources.Load<GameObject>("Prefabs/Player"), new Vector3(-8, -8, 0), Quaternion.identity).GetComponent<Player>(); 
        weapon = player.swordAttack;
        SceneManager.sceneLoaded -= GameManager.instance.LoadPlayerScene1;
    }

    // Floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManger.Show(msg, fontSize, color, position, motion, duration);
    }

    // Upgrade Weapon
    public bool TryUpgradeWeapon()
    {
        if (weapon.weaponLevel == 3)
            return false;

        if (weaponPrices.Count <= weapon.weaponLevel)
            return false;

        if(pesos >= weaponPrices[weapon.weaponLevel])
        {
            pesos -= weaponPrices[weapon.weaponLevel];
            weapon.UpgradeWeapon();
            return true;
        }

        return false;
    }


    public void SaveState()
    {
        string str = "";

        str += "0" + "|";
        str += pesos.ToString() + "|";
        str += experience.ToString() + "|";
        str += weapon.weaponLevel.ToString() + "|";
        str += player.HP.ToString() + "|";
        str += player.level.ToString() + "|";
        str += "0";
        
        PlayerPrefs.SetString("SaveState", str);
        //Debug.Log("SaveState");
        
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        player = Instantiate(Resources.Load<GameObject>("Prefabs/Player"), new Vector3((float)8.7, (float)-13.5, 0), Quaternion.identity).GetComponent<Player>();
        weapon = player.swordAttack;

        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        weapon.SetWeaponLevel(int.Parse(data[3]));
        player.HP = int.Parse(data[4]);
        player.level = int.Parse(data[5]);
         
        SceneManager.sceneLoaded -= GameManager.instance.LoadState;
        //Debug.Log("LoadState");
    }
}